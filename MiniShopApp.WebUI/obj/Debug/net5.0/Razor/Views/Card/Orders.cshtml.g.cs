#pragma checksum "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40896e7e47d74db2b1c5f2657292d9649b059c40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Card_Orders), @"mvc.1.0.view", @"/Views/Card/Orders.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40896e7e47d74db2b1c5f2657292d9649b059c40", @"/Views/Card/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32df49b1e93c638c1b5fce74e8e1fde56f9e8fb7", @"/Views/_ViewImports.cshtml")]
    public class Views_Card_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderListModal>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("30"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h6 class=\"display-4\">Orders</h6>\r\n<hr/>\r\n");
#nullable restore
#line 5 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
 foreach (var order in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-sm table-bordered mb-3\">\r\n        <thead>\r\n            <tr class=\"bg-info\">\r\n                <th colspan=\"2\">Order Id: #");
#nullable restore
#line 10 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
                                      Write(order.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>Price</th>\r\n                <th>Quantity</th>\r\n                <th>Quantity</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 17 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
             foreach (var orderItem in order.OrderItems)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "40896e7e47d74db2b1c5f2657292d9649b059c405931", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 577, "~/img/", 577, 6, true);
#nullable restore
#line 21 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
AddHtmlAttributeValue("", 583, orderItem.ImageUrl, 583, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(orderItem.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(orderItem.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(orderItem.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n        <tfoot>\r\n            <tr>\r\n                <th colspan=\"2\">Customer Name:</th>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(order.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 32 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
                                Write(order.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>Total: ");
#nullable restore
#line 33 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
                      Write(order.TotalPrice().ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th colspan=\"2\">Address:</th>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(order.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th colspan=\"2\">City:</th>\r\n                <td>");
#nullable restore
#line 41 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(order.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th colspan=\"2\">Email:</th>\r\n                <td>");
#nullable restore
#line 45 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(order.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th colspan=\"2\">Order Status:</th>\r\n                <td>");
#nullable restore
#line 49 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(order.OrderState);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th colspan=\"2\">Payment Type:</th>\r\n                <td>");
#nullable restore
#line 53 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
               Write(order.PaymentType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tfoot>\r\n    </table>\r\n");
#nullable restore
#line 57 "C:\Users\oguzh\Documents\GitHub\Web7_Projects\Week_18\MiniShopApp\MiniShopApp.WebUI\Views\Card\Orders.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderListModal>> Html { get; private set; }
    }
}
#pragma warning restore 1591
