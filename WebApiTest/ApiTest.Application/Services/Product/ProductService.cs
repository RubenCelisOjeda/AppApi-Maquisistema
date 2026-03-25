using ApiProduct.Application.Dto.Product.Request.Add;
using ApiProduct.Application.Dto.Product.Request.Update;
using ApiProduct.Application.Dto.Product.Response.Response.GetById;
using ApiProduct.Domain.Repository;
using ApiProduct.Shared.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ApiProduct.Application.Services.Product
{
    public class ProductService : IProductService
    {
        #region [Properties]

        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion

        #region [Constructor]

        public ProductService(ILogger<ProductService> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse<GetByIdResponseDto>> GetById(int id)
        {
            BaseResponse<GetByIdResponseDto> baseResponse = null;

            try
            {
                var response = await _productRepository.GetById(id);

                var mapperResponse = _mapper.Map<GetByIdResponseDto>(response);

                if (mapperResponse is not null)
                    baseResponse = BaseResponse<GetByIdResponseDto>.BaseResponseSuccess(mapperResponse);
                else
                    baseResponse = BaseResponse<GetByIdResponseDto>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<GetByIdResponseDto>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse<int>> AddProduct(AddProductRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                #region [Validations]
 
                #endregion

                var mapperRequest = _mapper.Map<ApiProduct.Domain.Entities.Product>(request);

                var response = await _productRepository.AddProduct(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse<int>> UpdateProduct(UpdateProductRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                #region [Validations]
                #endregion

                //Mapper
                var mapperRequest = _mapper.Map<ApiProduct.Domain.Entities.Product>(request);

                //Response
                var response = await _productRepository.UpdateProduct(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        #endregion
    }
}
