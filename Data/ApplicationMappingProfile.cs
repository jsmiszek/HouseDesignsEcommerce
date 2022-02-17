using AutoMapper;
using HouseDesignsEcommerce.Data.Entities;
using HouseDesignsEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseDesignsEcommerce.Data
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<HouseDesign, HouseDesignViewModel>()
                .ForMember(h => h.HouseDesignId, ex => ex.MapFrom(h => h.HouseDesignId))
                .ReverseMap();

            CreateMap<Category,CategoryViewModel>()
                .ForMember(c => c.CategoryId, ex => ex.MapFrom(c => c.CategoryId))
                .ReverseMap();
        }
    }
}
