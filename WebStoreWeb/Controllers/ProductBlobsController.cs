using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebStoreWeb.Models;

namespace WebStoreWeb.Controllers
{
    public class ProductBlobsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProductBlobs
        public IEnumerable<ProductBlob> GetProductsBlob()
        {
            return db.ProductsBlob.ToList();
        }

        // GET: api/ProductBlobs/5
        [ResponseType(typeof(ProductBlob))]
        public IHttpActionResult GetProductBlob(int id)
        {
            ProductBlob productBlob = db.ProductsBlob.Find(id);
            if (productBlob == null)
            {
                return NotFound();
            }

            return Ok(productBlob);
        }

        // PUT: api/ProductBlobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductBlob(int id, ProductBlob productBlob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productBlob.ProductBlobId)
            {
                return BadRequest();
            }

            db.Entry(productBlob).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBlobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductBlobs
        [ResponseType(typeof(ProductBlob))]
        public async Task <IHttpActionResult> PostProductBlob()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.ProductsBlob.Add(productBlob);
            //db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = productBlob.ProductBlobId }, productBlob);

            //Agr Req multiform nhe hui tow Ye Error dega.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //Give path to Image
            var root = HttpContext.Current.Server.MapPath("~/Images");
            var provider = new MultipartFormDataStreamProvider(root);

            //try
            //{
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    //Replace / from file name 
                    string name = file.Headers.ContentDisposition.FileName.Replace("\"", "");

                    //Create file name with Guid
                    string newfileName = Guid.NewGuid() + Path.GetExtension(name);

                    //Move file from current location to Target Folder
                    File.Move(file.LocalFileName, Path.Combine(root, newfileName));

                    //Combining path as example E:\folder\imagefile.jpg
                    var filePath = root + "\\" + newfileName;

                    //Create Binray Array
                    byte[] blobByte;

                    //
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        blobByte = new byte[fs.Length];
                        fs.Read(blobByte, 0, Convert.ToInt32(fs.Length));
                    }

                  ProductBlob productBlob = new ProductBlob();


                    productBlob.ImageName = newfileName;
                    //productBlob.ImageBinray = blobByte;
                    productBlob.ImagePath = root + "\\" + newfileName; 

                    db.ProductsBlob.Add(productBlob);
                    db.SaveChanges();

                    return CreatedAtRoute("DefaultApi", new { id = productBlob.ProductBlobId }, productBlob);

                }
            //}
            //catch (Exception ex)
            //{

            //    throw new HttpException("Error-" + ex.Message);

            //}

            return Content(HttpStatusCode.Created, "Image Uploaded in Server");

        }

        // DELETE: api/ProductBlobs/5
        [ResponseType(typeof(ProductBlob))]
        public IHttpActionResult DeleteProductBlob(int id)
        {
            ProductBlob productBlob = db.ProductsBlob.Find(id);
            if (productBlob == null)
            {
                return NotFound();
            }

            db.ProductsBlob.Remove(productBlob);
            db.SaveChanges();

            return Ok(productBlob);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductBlobExists(int id)
        {
            return db.ProductsBlob.Count(e => e.ProductBlobId == id) > 0;
        }
    }
}