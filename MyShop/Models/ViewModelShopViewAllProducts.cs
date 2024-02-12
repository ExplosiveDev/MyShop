using BusinessLogic.DTOs;

namespace MyShop.Models
{
    public class ViewModelShopViewAllProducts
    {
        public IEnumerable<ProductDTO> Products { get; set; } = null;
        public IEnumerable<CategoryDTO> Categories { get; set; } = null;
    }
}
