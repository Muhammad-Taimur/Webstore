using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStoreWeb.Models
{
    public class ProductBlob
    {

        public int ProductBlobId { get; set; }

        [ForeignKey ("Product")]
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public byte[]  ImageBinray{ get; set; }

        public virtual Product Product { get; set; }
    }
}