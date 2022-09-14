using Api.DTOs;
using AutoMapper;
using Core.Entities;

namespace Api.Helpers;

public class ProductUrlResolver : IValueResolver<Product, ProductReturnDto, string>
{
    private readonly IConfiguration _configuration;

    public ProductUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductReturnDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _configuration["ApiUrl"] + source.PictureUrl;
        }

        return null;
    }
}