using ApiPractice.Api.Dtos;
using ApiPractice.Domain.Entities;
using AutoMapper;

namespace ApiPractice.Api.Helpers;

public class MappingEntities : Profile
{
    public MappingEntities()
    {
        CreateMap<Student, StudentResponse>().ReverseMap();
    }
}