using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWEBAPI.Data;
using ProductWEBAPI.Models;

namespace ProductWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductsDbContext _context;
        public ProductsController(IMapper mapper, ProductsDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //[HttpPost]
        //public IActionResult CreateProduct(CreateProductDto createDto)
        //{
        //    var productEntity = _mapper.Map<Product>(createDto); // Maps DTO -> Product
        //                                                         // ... save entity to database
        //    var productToReturn = _mapper.Map<ProductDto>(productEntity); // Maps Product -> Dto
        //    return Ok(productToReturn);
        //}



        [HttpPost]
        public async Task<IActionResult> SaveProduct(CreateProductDto createDto)
        {
            var product = new Product { CategoryId = createDto.CategoryId, Name = createDto.Name, Price = createDto.Price, Description = createDto.Description };
            _context.Products.Add(product);
            var result = await _context.SaveChangesAsync(); // Executes INSERT SQL
            return Ok(result);
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

        //[HttpGet("{name:alpha}")]    // Constraint: 'name' must consist of letters
        //public IActionResult GetByName(string name) { return Ok("I am using Gat Products API"); }

        //[HttpGet("{id:min(1)}")]     // Constraint: 'id' must be an integer >= 1
        //public IActionResult GetByIdMin(int id)
        //{
        //    return Ok("I am using Gat Products API");
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //Get all products
            var allProducts = await _context.Products.ToListAsync();
            return Ok(allProducts);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("No such product found !");
            }
            product.Name = "Updated Name";
            int result = await _context.SaveChangesAsync(); // Executes UPDATE SQL
            return Ok($"{result} {product.Name} updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProdcut(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("No such product found !");
            }
            _context.Products.Remove(product);
            int result = await _context.SaveChangesAsync(); // Executes DELETE SQL
            return Ok($"{result} {product.Name} has been deleted successfully.");
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

