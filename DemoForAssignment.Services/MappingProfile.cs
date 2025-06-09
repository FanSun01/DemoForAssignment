using AutoMapper;
using DemoForAssignment.Models;
using DemoForAssignment.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForAssignment.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderItem, OrderItemVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
        }

    }
}
