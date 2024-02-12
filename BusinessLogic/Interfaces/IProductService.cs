using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace MyShop.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int Id);
    }
}
