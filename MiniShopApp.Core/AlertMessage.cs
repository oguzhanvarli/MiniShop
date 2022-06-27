using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.Core
{
    public class AlertMessage
    {
        
        public string Title { get; set; }
        public string Message { get; set; }//Uyarı mesajı
        public string AlertType { get; set; }//Uyarı tipi
    }
}
