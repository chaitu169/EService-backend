using AutoMapper;
using Esevice2._0.dtos;
using Esevice2._0.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esevice2._0.Profiles
{
    public class ServicemanProfile:Profile
    {
        public ServicemanProfile()
        {
            CreateMap<ServiceMan, ServicemanReadDto>();
            CreateMap< ServicemanReadDto, ServiceMan>();
            CreateMap<ServicemanCreateDto, ServiceMan>();
            CreateMap<ServicemanUpdateDto, ServiceMan>();
            CreateMap<ServiceMan, ServicemanUpdateDto>();
        }
    }
}
