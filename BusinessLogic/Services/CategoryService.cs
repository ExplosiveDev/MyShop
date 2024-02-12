using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Interfaces;
using MyShop.Interfaces;

namespace MyShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _categoryRepository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = await _categoryRepository.Get();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
    }
}
