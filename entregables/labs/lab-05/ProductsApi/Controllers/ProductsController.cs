using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //https://codeshare.io/21d7on
        private readonly ILogger<ProductsController> _logger;
        private readonly object[] _products;
        //private readonly AdventureWorksDbContext _context;

        public ProductsController(ILogger<ProductsController> logger, object[] products
            //, AdventureWorksDbContext context
            )
        {
            _logger = logger;
            _products = products;
            _logger.LogInformation("ProductsController constructor");
            //_context = context; 
        }
        // CRUD 
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return _products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_products[0]);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Models.Product value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new ObjectResult(new object()) { StatusCode = (int)HttpStatusCode.NotImplemented };
        }

    }
}
