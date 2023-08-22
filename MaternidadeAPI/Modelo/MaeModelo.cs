using System.ComponentModel.DataAnnotations;

namespace MaternidadeAPI.Modelo
{
    public class MaeModelo
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string Sobrenome { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;

        public string Rg { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; } = string.Empty;

        public string EstadoCivil { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string Historico { get; set; } = string.Empty;
        // Relação
    }
}
