using System.ComponentModel.DataAnnotations;

namespace MaternidadeAPI.Modelo
{
    public class MaeModelo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;

        [RegularExpression(@"^\d{1,3}:\d{2}$", ErrorMessage = "A duração deve estar no formato mm:ss ou hhh:mm:ss.")]
        public string DataNascimento { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string EstadoCivil { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;

        public string Etinia { get; set;} = string.Empty;
        public string Historico { get; set; } = string.Empty;

        // Relação
    }
}
