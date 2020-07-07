using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStoreWeb.Models
{
    public class Review
    {

        public int ReviewId { get; set; }

        [ForeignKey ("Product")]
        public int ProductId{ get; set; }

        public string UserId { get; set; }
        public string UserName{ get; set; }

        public Product Product { get; set; }
    }
}