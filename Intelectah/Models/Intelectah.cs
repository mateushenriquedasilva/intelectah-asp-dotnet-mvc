using System;

namespace Intelectah.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }

    public class TiposDeExame
    { 
        public int Id { get; set; }
        public string NomeDoTipoDeExame { get; set; }
        public string Descricao { get; set; }
    }
}