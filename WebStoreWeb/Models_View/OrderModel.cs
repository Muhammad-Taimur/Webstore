using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreWeb.Models_View
{
    public class OrderModel
    {

        //public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string UserAddress { get; set; }
        public string UserName { get; set; }
        //public ICollection <ProductModel> Product { get; set; }
        public virtual OrderProduct Product { get; set; }

    }
}