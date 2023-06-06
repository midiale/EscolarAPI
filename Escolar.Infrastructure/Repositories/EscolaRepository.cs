using Escolar.Domain.Entities;
using Escolar.Domain.Interfaces;
using Escolar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escolar.Infrastructure.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private ApplicationDbContext _escolaContext;
        public EscolaRepository(ApplicationDbContext context)
        {
            _escolaContext = context;
        }

        public async Task<Escola> CreateAsync(Escola category)
        {
            _escolaContext.Add(category);
            await _escolaContext.SaveChangesAsync();
            return category;
        }

        public async Task<Escola> GetByIdAsync(int? id)
        {
            return await _escolaContext.Escolas.FindAsync(id);
        }

        public async Task<IEnumerable<Escola>> GetEscolasAsync()
        {
            return await _escolaContext.Escolas.ToListAsync();
        }

        public async Task<Escola> RemoveAsync(Escola category)
        {
            _escolaContext.Remove(category);
            await _escolaContext.SaveChangesAsync();
            return category;
        }

        public async Task<Escola> UpdateAsync(Escola category)
        {
            _escolaContext.Update(category);
            await _escolaContext.SaveChangesAsync();
            return category;
        }
    }
}
