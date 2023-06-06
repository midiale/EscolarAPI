﻿using Escolar.Application.DTOs;

namespace Escolar.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> GetAlunos();
        Task<AlunoDTO> GetById(int? id);
        Task Add(AlunoDTO alunoDto);
        Task Update(AlunoDTO alunoDto);
        Task Remove(int id);
    }
}
