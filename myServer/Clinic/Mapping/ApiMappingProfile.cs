using AutoMapper.Execution;
using AutoMapper;
using Factory.API.Model;
using Factory.Entities;
using Factory.Core.Entities;

namespace Server.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<WorkerPutModel, Worker>().ReverseMap();
            CreateMap<WorkerPostModel, Worker>().ReverseMap();
            CreateMap<RolePostModel, Role>().ReverseMap();
            CreateMap<RoleToWorkerPostPutModel, RoleToWorker>().ReverseMap();
        }
    }
}
