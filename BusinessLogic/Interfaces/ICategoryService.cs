using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace MyShop.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
