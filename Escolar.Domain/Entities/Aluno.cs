using Escolar.Domain.Validation;
using System;

namespace Escolar.Domain.Entities
{
    public sealed class Aluno : Entity
    {
        public Aluno(string nome, string mae, int serie, string imagemUrl,
            int exAluno)
        {
            ValidateDomain(nome, mae, serie, imagemUrl, exAluno);
        }

        public Aluno(int id, string nome, string mae, int serie, string imagemUrl,
            int exAluno)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, mae, serie, imagemUrl, exAluno);
        }

        public string Nome { get; private set; }
        public string Mae { get; private set; }
        public int Serie { get; private set; }
        public string ImagemUrl { get; private set; }
        public int ExAluno { get; private set; }
        
        public void Update(string nome, string mae, int serie, string imagemUrl, 
            int exAluno, int escolaId)
        {
            ValidateDomain(nome, mae, serie, imagemUrl, exAluno);
            EscolaId = escolaId;
        }

        private void ValidateDomain(string nome, string mae, int serie, string imagemUrl, 
            int exAluno)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(mae),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(mae.Length < 5,
                "A descrição deve ter no mínimo 5 caracteres");

            DomainExceptionValidation.When(serie < 0, "Valor da série inválido");

            DomainExceptionValidation.When(imagemUrl?.Length > 250,
                "O nome da imagem não pode exceder 250 caracteres");

            DomainExceptionValidation.When(exAluno < 0, "ExAluno inválido");

            Nome = nome;
            Mae = mae;
            Serie = serie;
            ImagemUrl = imagemUrl;
            ExAluno = exAluno;
            
        }
        public int EscolaId { get; set; }
        public Escola Escola { get; set; }
    }
}
