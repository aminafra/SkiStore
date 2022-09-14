using Api.DTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductReturnDto>()
            .ForMember(destMember => destMember.ProductBrand,
                memberConfiguration => memberConfiguration.MapFrom(product => product.ProductBrand.Name))
            .ForMember(desMember => desMember.ProductType,
                memberConfiguration => memberConfiguration.MapFrom(product => product.ProductType.Name))
            .ForMember(destMember => destMember.PictureUrl,
                memberConfiguration => memberConfiguration.MapFrom<ProductUrlResolver>());
    }
}