using AutoMapper;
using DatunashviliAPI.Dtos;
using DatunashviliAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.WineType, o => o.MapFrom(s => s.WineType.Name))
                .ForMember(d => d.WineYear, o => o.MapFrom(s => s.WineYear.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
