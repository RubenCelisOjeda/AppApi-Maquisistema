using ApiProduct.Application.Dto.Product.Request.Add;
using ApiProduct.Application.Dto.Product.Request.Update;
using ApiProduct.Application.Dto.Product.Response.Response.GetById;
using ApiProduct.Shared.Utils;

namespace ApiProduct.Application.Services.Product
{
    public interface IProductService
    {
        public Task<BaseResponse<GetByIdResponseDto>> GetById(int id);
        public Task<BaseResponse<int>> AddProduct(AddProductRequestDto request);
        public Task<BaseResponse<int>> UpdateProduct(UpdateProductRequestDto request);
    }
}
