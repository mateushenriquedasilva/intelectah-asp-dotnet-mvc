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
}
