using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStoreWeb.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [ForeignKey ("Product")]
        public int ProductId{ get; set; }
        public string UserID { get; set; }
        public string UserAddress { get; set; }
        public string  UserName { get; set; }

        //Navigation Propery
        public virtual  Product Product { get; set; }

    }
}