using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("I am using Gat Users API");
        }


        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var product = _repository.GetProduct(id);
        //    if (product is null)
        //    {
        //        return NotFound(); // Returns 404 NotFoundResult
        //    }
        //    return Ok(product); // Returns 200 OK with product data
        //}


        //[HttpGet("{id}")]
        //public ActionResult<Product> GetById(int id) // Swagger knows a success returns a 'Product'
        //{
        //    var product = _repository.GetProduct(id);
        //    if (product is null)
        //    {
        //        return NotFound(); // Still return IActionResult for errors
        //    }
        //    return product; // Can return the object directly (implicitly converts to OkObjectResult)
        //}

    }

}
