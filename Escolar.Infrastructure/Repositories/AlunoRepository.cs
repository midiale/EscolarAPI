using Escolar.Domain.Entities;
using Escolar.Domain.Interfaces;
using Escolar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escolar.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private ApplicationDbContext _alunoContext;
        public AlunoRepository(ApplicationDbContext context)
        {
            _alunoContext = context;
        }

        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            _alunoContext.Add(aluno);
            await _alunoContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> GetByIdAsync(int? id)
        {
            //return await _alunoContext.Alunos.FindAsync(id);
            return await _alunoContext.Alunos.Include(c => c.Escola)
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosAsync()
        {
            return await _alunoContext.Alunos.ToListAsync();
        }

        public async Task<Aluno> RemoveAsync(Aluno aluno)
        {
            _alunoContext.Remove(aluno);
            await _alunoContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> UpdateAsync(Aluno aluno)
        {
            _alunoContext.Update(aluno);
            await _alunoContext.SaveChangesAsync();
            return aluno;
        }
    }
}
