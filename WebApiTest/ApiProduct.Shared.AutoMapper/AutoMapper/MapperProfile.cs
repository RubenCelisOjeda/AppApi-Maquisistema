using ApiProduct.Application.Dto.Product.Request.Add;
using ApiProduct.Application.Dto.Product.Request.Update;
using ApiProduct.Application.Dto.Product.Response.Response.GetById;
using ApiProduct.Domain.Entities;
using AutoMapper;


namespace ApiProduct.Shared.AutoMapper.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region [ Product ]

            #region [Request]
            //Add
            CreateMap<AddProductRequestDto, Product>();

            //Update
            CreateMap<UpdateProductRequestDto, Product>();
            #endregion

            #region [Response]
            //Get
            CreateMap<Product, GetByIdResponseDto>();

            #endregion

            #endregion
        }
    }
}
