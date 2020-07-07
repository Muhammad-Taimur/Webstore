using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStoreWeb.Models;

namespace WebStoreWeb.Models_View
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public ICollection<ProductBlobModel> ProductBlob { get; set; }
        public ICollection<OrderModel> Order { get; set; }
        public ICollection<ReviewModel> Review { get; set; }

    }
}