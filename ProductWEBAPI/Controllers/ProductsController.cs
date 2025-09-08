using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using ProductWEBAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using static ProductWEBAPI.Mappings.ProductProfile;

namespace ProductWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createDto)
        {
            var productEntity = _mapper.Map<Product>(createDto); // Maps DTO -> Product
                                                                 // ... save entity to database
            var productToReturn = _mapper.Map<ProductDto>(productEntity); // Maps Product -> Dto
            return Ok(productToReturn);
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("I am using Gat Products API");
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id, string category) // 'id' from route, 'category' from query string
        //{
        //    return Ok("I am using Gat Products API");
        //}

        //[HttpGet("{id:int}")]        // Constraint: 'id' must be an integer
        //public IActionResult GetById(int id) { return Ok("I am using Gat Products API"); }

        [HttpGet("{name:alpha}")]    // Constraint: 'name' must consist of letters
        public IActionResult GetByName(string name) { return Ok("I am using Gat Products API"); }

        [HttpGet("{id:min(1)}")]     // Constraint: 'id' must be an integer >= 1
        public IActionResult GetByIdMin(int id)
        {
            return Ok("I am using Gat Products API");
        }



        // Usage in Controller
        //[HttpPost]
        //public ActionResult<Product> CreateProduct(CreateProductDto createDto)
        //{
        //    // Map the DTO to the Product entity
        //    var product = new Product
        //    {
        //        Name = createDto.Name,
        //        Description = createDto.Description,
        //        Price = CalculatePrice() // Price is set by business logic, not the client
        //    };
        //    // ... save to database
        //    return Ok(product);
        //}

        private decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }

    }
}

