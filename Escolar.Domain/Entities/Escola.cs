﻿using Escolar.Domain.Validation;
using System.Collections.Generic;

namespace Escolar.Domain.Entities
{
    public sealed class Escola : Entity
    {
        public Escola(string nome, string imagemUrl)
        {
            ValidateDomain(nome, imagemUrl);
        }

        public Escola(int id, string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, imagemUrl);
        }

        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public ICollection<Aluno> Alunos { get; set; }

        private void ValidateDomain(string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
                "Nome da imagem inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
               "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(imagemUrl.Length < 5,
                "Nome da imagem deve ter no mínimo 5 caracteres");

            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}
