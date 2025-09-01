using AutoMapper;
using ProductWEBAPI.Models;

namespace ProductWEBAPI.Mappings
{

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // CreateMap<Source, Destination>()
            CreateMap<CreateProductDto, Product>(); // Map DTO to Entity
            CreateMap<Product, ProductDto>();        // Map Entity to DTO
        }

        public class ProductDto
        {
            public int Id { get; set; } 
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
