using AutoMapper;
using Escolar.Application.DTOs;
using Escolar.Domain.Entities;

namespace Escolar.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Escola, EscolaDTO>().ReverseMap();
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
        }
    }
}
