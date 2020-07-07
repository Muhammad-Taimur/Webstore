using AutoMapper;
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
using WebStoreWeb.Models_View;

namespace WebStoreWeb.Controllers
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IMapper mapper;

        public ProductsController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: api/Products
        public IHttpActionResult GetProducts()
        {
            /*var response = Request.CreateResponse(HttpStatusCode.OK);

            //var response = Ok(db.ProductsBlob);
            
            //Give path to Image
            var root = ("~/Images/"+ "ac91288f-b0b5-43b8-ae77-4f624b7e4342.jpg");
            //var provider = new MultipartFormDataStreamProvider(root);

            root = System.Web.Hosting.HostingEnvironment.MapPath(root);
            var ext = System.IO.Path.GetExtension(root).Replace(".","");

            
            var contents = System.IO.File.ReadAllBytes(root);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(contents);

            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/"+ext );

            return response;*/
            try
            {
                var result = db.Products;
                var resultmapper = mapper.Map <IEnumerable<ProductModel>>(result.Include("productBlob").Include("order").Include("Review"));

                //return Ok(db.Products.Include("productBlob").Include("Review"));
                return Ok(resultmapper);
            }
            catch
            {
                return BadRequest();

            }
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            //Product product = db.Products.Find(id);

            db.Products.Where(p => p.ProductId == id);
            // if (product == null)
            // {
            //     return NotFound();
            // }
            //.Include("ReviewModel")
            //.Include("productBlob")
            var result = db.Products.Where(p => p.ProductId == id);
           // var result = db.Products;

            var mapperdresult = mapper.Map <IEnumerable<ProductModel>>(result.Include("productBlob").Include("order").Include("Review"));

            //return Ok(db.Products.Include("productBlob").Include("Review").Where(p => p.ProductId == id));
            return Ok(mapperdresult);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Products.Add(product);
            //db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);


            var serverPath = "https://localhost:44362/images/";


            //Agr Req multiform nhe hui tow Ye Error dega.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //Give path to Image
            var root = HttpContext.Current.Server.MapPath("~/Images");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider); 

                foreach(MultipartFileData file in provider.FileData)
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
                    /*byte[] blobByte
                    using (var fs=new  FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        blobByte = new byte[fs.Length];
                         fs.Read(blobByte, 0, Convert.ToInt32(fs.Length));
                    }*/

                   

                    //Adding Multiple files/Images in 1 Product ID ForeignKey
                   // for (var i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    //{
                    
                    ProductBlob productBlob = new ProductBlob();

                     //   productBlob.ProductId = product.ProductId;
                        productBlob.ImageName = newfileName;
                        //productBlob.ImageBinray = blobByte;
                        productBlob.ImagePath = serverPath +"" + newfileName;

                   
                    db.ProductsBlob.Add(productBlob);
                    //}
                    
                    //db.Products.Add(product);
                    //db.ProductsBlob.Add(productBlob);
                    //db.SaveChanges();

                }

                Product product = new Product();

                product.Name = HttpContext.Current.Request["name"];
                product.Category = HttpContext.Current.Request["category"];
                product.Details = HttpContext.Current.Request["details"];
                db.Products.Add(product);
                db.SaveChanges();

               return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {

                throw new HttpException("Error-" + ex.Message);

            }

            //return Content(HttpStatusCode.Created, "Image Uploaded in Server");



        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}