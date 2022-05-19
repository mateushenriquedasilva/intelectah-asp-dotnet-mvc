using System;
using System.ComponentModel.DataAnnotations;

namespace Intelectah.ViewModels
{
    public class CriarPacienteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class CriarTiposDeExameViewModel
    {
        public int Id { get; set; }
        [Required]
        public string NomeDoTipoDeExame { get; set; }
        [Required]
        public string Descricao { get; set; }
    }

    public class CriarCadastroDeExames
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public int IdDoTipoDeExame { get; set; }
    }
}
