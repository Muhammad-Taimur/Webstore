using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreWeb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name{ get; set; }
        public string Category { get; set; }
        public string Details { get; set; }

        public ICollection<Order> Order{ get; set; }
        public ICollection<ProductBlob> ProductBlob { get; set; }
        public ICollection<Review> Review { get; set; }

    }
}