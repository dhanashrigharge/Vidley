using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.App_Start
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            
            Mapper.CreateMap<Movie, MovieDto>();
            
            Mapper.CreateMap<Genre, GenreDto>();
                   
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}