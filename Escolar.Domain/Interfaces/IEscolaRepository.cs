using Escolar.Domain.Entities;

namespace Escolar.Domain.Interfaces
{
    public interface IEscolaRepository
    {
        Task<IEnumerable<Escola>> GetEscolasAsync();
        Task<Escola> GetByIdAsync(int? id);
        Task<Escola> CreateAsync(Escola escola);
        Task<Escola> UpdateAsync(Escola escola);
        Task<Escola> RemoveAsync(Escola escola);
    }
}
