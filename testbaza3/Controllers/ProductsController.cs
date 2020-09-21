using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testbaza3.DTO;
using testbaza3.Models;

namespace testbaza3.Controllers
{
    public class ProductsController : ApiController
    {
        //Product[] products = new Product[]
        //{
        //    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
        //    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
        //    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        //};

        private ProductContext db = new ProductContext();

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var produkts = from b in db.Products
                        select new ProductDTO()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Price = b.Price
                        };

            return produkts;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
