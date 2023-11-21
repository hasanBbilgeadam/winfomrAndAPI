using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        //get
        //getbyıd

        [HttpGet("")]
        public IActionResult GetProduct()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_context.Products.Find(id));
        }

        [HttpPost("")]
        public IActionResult Add(Product p)
        {
            if (p.Price<10)
            {
                return BadRequest("fiyat 10'dan küçük olamaz"); 
            }
            _context.Products.Add(new() { Name = p.Name, Price = p.Price });
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("")]
        public IActionResult Update(Product p)
        {
            _context.Update(p);
            _context.SaveChanges();
            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Products.Find(id);

            if (item == null)
            {
                return BadRequest("böyle bir ürün yok");
            }
            
            _context.Products.Remove(item);
            _context.SaveChanges();
            return Ok();

        }



    }
}
