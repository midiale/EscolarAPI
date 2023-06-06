using Escolar.Application.DTOs;

namespace Escolar.Application.Interfaces
{
    public interface IEscolaService
    {
        Task<IEnumerable<EscolaDTO>> GetEscolas();
        Task<EscolaDTO> GetById(int? id);
        Task Add(EscolaDTO escolaDto);
        Task Update(EscolaDTO escolaDto);
        Task Remove(int id);
    }
}
