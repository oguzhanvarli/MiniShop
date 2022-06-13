using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MiniShopApp.Business.Abstract;
using MiniShopApp.Core;
using MiniShopApp.Entity;
using MiniShopApp.WebUI.Identity;
using MiniShopApp.WebUI.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OrderItem = MiniShopApp.Entity.OrderItem;

namespace MiniShopApp.WebUI.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private ICardService _cardService;
        private UserManager<User> _userManager;
        private IOrderService _orderService;
        

        public CardController(ICardService cardService, UserManager<User> userManager, IOrderService orderService)
        {
            _cardService = cardService;
            _userManager = userManager;
            _orderService = orderService;
        }

        public IActionResult Index() 
        {
            var userId = _userManager.GetUserId(User);      //login olan user ın idsini alır.
            var card = _cardService.GetCardByUserId(userId);
            return View(new CardModel() {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel()  //cardItem olarak at ama CardItemModel Tipinde at.
                {
                    CardItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            });
        }
        public IActionResult GetOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = _orderService.GetOrders(userId);
            var orderListModal = new List<OrderListModal>();
            OrderListModal orderModel;
            foreach (var order in orders)
            {
                orderModel = new OrderListModal();
                orderModel.OrderId = order.Id;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.Address = order.Address;
                orderModel.City = order.City;
                orderModel.Phone = order.Phone;
                orderModel.Email = order.Email;
                orderModel.OrderState = order.OrderState;
                orderModel.PaymentType = order.PaymentType;
                orderModel.OrderItems = order.OrderItems.Select(i => new OrderItemModal()
                {
                    OrderItemId = i.Id,
                    Name = i.Product.Name,
                    Price = (double)i.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.Product.ImageUrl
                }).ToList();
                orderListModal.Add(orderModel);
            }
            return View("Orders",orderListModal);       //benim view adım Orders olacak dedik ve order listmodel ile git dedik
        }
        [HttpPost]
        public IActionResult AddToCard(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            _cardService.AddToCard(userId, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCard(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cardService.DeleteFromCard(userId, productId);
            return RedirectToAction("Index");
        }
        public IActionResult Checkout()
        {
            var userId = _userManager.GetUserId(User);
            var card = _cardService.GetCardByUserId(userId);
            var orderModal = new OrderModal();
            orderModal.CardModel = new CardModel()
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel()
                {
                    CardItemId = i.CardId,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            };
            return View(orderModal);
        }
        [HttpPost]
        public IActionResult CheckOut(OrderModal orderModal)
        {
            
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var card = _cardService.GetCardByUserId(userId);
                var cardId = card.Id;
                orderModal.CardModel = new CardModel()
                {
                    CardId = card.Id,
                    CardItems = card.CardItems.Select(i => new CardItemModel()
                    {
                        CardItemId = i.Id,
                        ProductId = i.ProductId,
                        Name = i.Product.Name,
                        Price = (double)i.Product.Price,
                        ImageUrl = i.Product.ImageUrl,
                        Quantity = i.Quantity
                    }).ToList()
                };
                //Ödeme Alma işlemine başlayacağız
                //if (!CardNumberControl(orderModal.CardNumber))
                //{
                //    TempData["Message"] = JobManager.CreateMessage("HATAL", "Kart Numarası Hatalıdır", "danger");
                //    return View(orderModal);
                //}
                var payment = PaymentProcess(orderModal);
                if (payment.Status =="success")     //başarılıysa
                {
                    SaveOrder(orderModal, payment, userId);
                    _cardService.ClearCard(cardId);      
                    TempData["Message"] = JobManager.CreateMessage("", "Ödemeniz Başarıyla alınmıştır.", "success");
                    return View("Success");
                }
                else
                {
                    TempData["Message"] = JobManager.CreateMessage("",payment.ErrorMessage, "danger");
                }
            }
            return View(orderModal);

        }

        private void SaveOrder(OrderModal orderModal, Payment payment, string userId)
        {
            var order = new Order();

            order.OrderNumber = new Random().Next(111111111, 999999999).ToString();
            order.OrderState = EnumOrderState.Completed;
            order.PaymentType = EnumPaymentType.CreditCard;
            order.PaymentId = payment.PaymentId;
            order.ConversationId = payment.ConversationId;
            order.OrderDate = new DateTime();
            order.FirstName = orderModal.FirstName;
            order.LastName = orderModal.LastName;
            order.City = orderModal.City;
            order.Email = orderModal.Email;
            order.Phone = orderModal.Phone;
            order.Address = orderModal.Address;
            order.UserId = userId;
            order.OrderItems = new List<OrderItem>();
            foreach (var item in orderModal.CardModel.CardItems)
            {
                var orderItem = new OrderItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems.Add(orderItem);
            }
            //artık bu bilgileri kullanarak order kaydı yaratılabilir.
            _orderService.Create(order);
               
            
        }

        private Payment PaymentProcess(OrderModal orderModal)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-THtnHmRsMONKUa4ymXerdMMIv12x7qYY";
            options.SecretKey = "sandbox-4h4icfoPPpVQoIsxlrTeUIAKPBKr0uID";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();      //ödeme isteği başlatıyor
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111,999999999).ToString(); //id
            request.Price = orderModal.CardModel.TotalPrice().ToString();        //total price
            request.PaidPrice = orderModal.CardModel.TotalPrice().ToString();    //esas alınacak ödeme indirim vs.
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = orderModal.CardName;
            paymentCard.CardNumber = orderModal.CardNumber;
            paymentCard.ExpireMonth = orderModal.ExpirationMonth;
            paymentCard.ExpireYear = orderModal.ExpirationYear;
            paymentCard.Cvc = orderModal.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;


            //paymentCard.CardNumber = "5528790000000008";
            //paymentCard.ExpireMonth = "12";
            //paymentCard.ExpireYear = "2030";
            //paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = orderModal.FirstName;
            buyer.Surname = orderModal.LastName;
            buyer.GsmNumber = orderModal.Phone;
            buyer.Email = orderModal.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = orderModal.Address;
            buyer.Ip = "85.34.78.112";
            buyer.City = orderModal.City;
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            BasketItem basketItem;
            foreach (var item in orderModal.CardModel.CardItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "General";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = (item.Quantity * item.Price).ToString();
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;

           return Payment.Create(request, options);
        }

        //private bool CheckCard(string cardNo)     BENİM LOHN ALGORİTMAM
        //{
        //    int total = 0;

        //    for (int i = 1; i < cardNo.Length; i++)
        //    {

        //        if (cardNo[i] % 2 != 0)
        //        {
        //            if (cardNo[i] * 2 >= 10)
        //            {
        //                int mod = (cardNo[i] * 2) % 10;
        //                total += mod + 1;
        //            }
        //            else
        //            {
        //                total += cardNo[i] * 2;
        //            }
        //        }
        //    }
        //    if (total % 10 == 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        private bool CardNumberControl(string cardNumber)
        {
            var cardNumberLenght = cardNumber.Length;
            int total = 0;
            if (cardNumberLenght != 16)
            {
                return false;
            }
            else
            {
                int ovenTotal = 0;
                int oddTotal = 0;
                for (int i = 0; i < cardNumberLenght; i++)
                {
                    int nextNumber = Convert.ToInt32(cardNumber[i].ToString());
                    if (i % 2 == 0)
                    {
                        oddTotal += NumberControl((nextNumber * 2).ToString());
                    }
                    else
                    {
                        ovenTotal += nextNumber;
                    }
                }
                total = ovenTotal + oddTotal;
            }
            if (total % 10 == 0)
            {
                return true;
            }
            return false;
        }
        private int NumberControl(string number)
        {
            int numberLenght = number.Length;
            if (numberLenght == 1)
            {
                return Convert.ToInt32(number);
            }
            int total = 0;
            for (int i = 0; i < numberLenght; i++)
            {
                total += Convert.ToInt32(number[i].ToString());
            }
            return total;
        }
        
    }
}
