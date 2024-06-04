using AutoMapper.Execution;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Entities;
using Factory.DTOs;
using Factory.Core.DTOs;
using Factory.Core.Entities;

namespace Factory.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Worker, WorkerDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleToWorker, RoleToWorkerDto>().ReverseMap();
        }
    }
}
