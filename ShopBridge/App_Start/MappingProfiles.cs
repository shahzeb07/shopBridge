using AutoMapper;
using ShopBridge.DTOs;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.App_Start
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            Mapper.CreateMap<Item, ItemDTO>();
            Mapper.CreateMap<ItemDTO, Item>();
            Mapper.CreateMap<Category, CategoryDTO>();
            Mapper.CreateMap<CategoryDTO, Category>();
        }
    }
}