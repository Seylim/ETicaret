using AutoMapper;
using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Dtos.Requests;
using Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> AddProduct(AddProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            return await repository.AddAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<ProductListResponse> GetProductById(int id)
        {
            Product product = await repository.GetEntityByIdAsync(id);
            var response = mapper.Map<ProductListResponse>(product);
            return response;
        }

        public async Task<ICollection<ProductListResponse>> GetProducts()
        {
            var products = await repository.GetAllEntitiesAsync();
            var productListResponse = mapper.Map<List<ProductListResponse>>(products);
            return productListResponse;
        }

        public async Task<bool> IsExist(int id)
        {
            return await repository.IsExistsAsync(id);
        }

        public async Task<int> UpdateProduct(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            var result = await repository.UpdateAsync(product);
            return result;
        }
    }
}
