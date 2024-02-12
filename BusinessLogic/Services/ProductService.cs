using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Interfaces;
using MyShop.Interfaces;

namespace MyShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _ProductRepository.Get(includeProperties: new[] { "Category" });
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int Id)
        {
            var b = await GetAll();
            return b.FirstOrDefault(x => x.Id == Id);
        }
    }
}
