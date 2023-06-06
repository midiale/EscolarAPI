using AutoMapper;
using Escolar.Application.DTOs;
using Escolar.Application.Interfaces;
using Escolar.Domain.Entities;
using Escolar.Domain.Interfaces;

namespace Escolar.Application.Services
{
    public class EscolaService : IEscolaService
    {
        private IEscolaRepository _escolaRepository;
        private readonly IMapper _mapper;
        public EscolaService(IEscolaRepository escolaRepository, 
            IMapper mapper)
        {
            _escolaRepository = escolaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EscolaDTO>> GetEscolas()
        {
            var escolasEntity = await _escolaRepository.GetEscolasAsync();
            return _mapper.Map<IEnumerable<EscolaDTO>>(escolasEntity);
        }

        public async Task<EscolaDTO> GetById(int? id)
        {
            var escolaEntity = await _escolaRepository.GetByIdAsync(id);
            return _mapper.Map<EscolaDTO>(escolaEntity);
        }

        public async Task Add(EscolaDTO escolaDto)
        {
            var escolaEntity = _mapper.Map<Escola>(escolaDto);
            await _escolaRepository.CreateAsync(escolaEntity);
        }

        public async Task Update(EscolaDTO escolaDto)
        {
            var escolaEntity = _mapper.Map<Escola>(escolaDto);
            await _escolaRepository.UpdateAsync(escolaEntity);
        }

        public async Task Remove(int id)
        {
            var escolaEntity = _escolaRepository.GetByIdAsync(id).Result;
            await _escolaRepository.RemoveAsync(escolaEntity);
        }
    }
}
