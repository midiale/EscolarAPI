using AutoMapper;
using Escolar.Application.DTOs;
using Escolar.Application.Interfaces;
using Escolar.Domain.Entities;
using Escolar.Domain.Interfaces;

namespace Escolar.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;

        private readonly IMapper _mapper;
        public AlunoService(IMapper mapper, IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository ??
                 throw new ArgumentNullException(nameof(alunoRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<AlunoDTO>> GetAlunos()
        {
            var alunosEntity = await _alunoRepository.GetAlunosAsync();
            return _mapper.Map<IEnumerable<AlunoDTO>>(alunosEntity);
        }

        public async Task<AlunoDTO> GetById(int? id)
        {
            var alunoEntity = await _alunoRepository.GetByIdAsync(id);
            return _mapper.Map<AlunoDTO>(alunoEntity);
        }

        public async Task Add(AlunoDTO alunoDto)
        {
            var alunoEntity = _mapper.Map<Aluno>(alunoDto);
            await _alunoRepository.CreateAsync(alunoEntity);
        }

        public async Task Update(AlunoDTO alunoDto)
        {

            var alunoEntity = _mapper.Map<Aluno>(alunoDto);
            await _alunoRepository.UpdateAsync(alunoEntity);
        }

        public async Task Remove(int id)
        {
            var alunoEntity = _alunoRepository.GetByIdAsync(id).Result;
            await _alunoRepository.RemoveAsync(alunoEntity);
        }
    }
}
