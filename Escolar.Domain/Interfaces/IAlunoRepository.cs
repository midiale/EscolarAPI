using Escolar.Domain.Entities;

namespace Escolar.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAlunosAsync();
        Task<Aluno> GetByIdAsync(int? id);
        Task<Aluno> CreateAsync(Aluno aluno);
        Task<Aluno> UpdateAsync(Aluno aluno);
        Task<Aluno> RemoveAsync(Aluno aluno);
    }
}
