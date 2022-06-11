using Dtos.Requests;
using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<ICollection<ProductListResponse>> GetProducts();
        Task<int> AddProduct(AddProductRequest product);
        Task<bool> IsExist(int id);
        Task<ProductListResponse> GetProductById(int id);
        Task<int> UpdateProduct(UpdateProductRequest request);
        Task DeleteProduct(int id);
    }
}
