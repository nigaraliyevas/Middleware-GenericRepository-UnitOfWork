using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Extentions;
using AcademyApp.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Profiles
{
    public class MapperProfile : Profile
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MapperProfile(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            var uriBuilder = new UriBuilder(
                _httpContextAccessor.HttpContext.Request.Scheme,
                _httpContextAccessor.HttpContext.Request.Host.Host,
                _httpContextAccessor.HttpContext.Request.Host.Port.Value);
            var uri = uriBuilder.Uri.AbsoluteUri;
            CreateMap<GroupCreateDto, Group>();
            CreateMap<StudentCreateDto, Student>()
                .ForMember(d => d.FileName, map => map.MapFrom(s => s.File.Save(Directory.GetCurrentDirectory(), "uploads/img")))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.FullName));
            CreateMap<Student, StudentReturnDto>()
                .ForMember(d => d.FileName, map => map.MapFrom(s => uri + "uploads/img/" + s.FileName));

        }
    }
}
