using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreWeb.Models_View
{
    public class OrderProduct
    {
       //public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        //public string Details { get; set; }
    }
}