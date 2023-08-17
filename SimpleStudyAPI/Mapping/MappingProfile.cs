using AutoMapper;
using SimpleStudyAPI.DTO;
using SimpleStudyAPI.Models;

namespace SimpleStudyAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
