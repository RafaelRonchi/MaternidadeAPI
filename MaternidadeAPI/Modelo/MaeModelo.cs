using System.ComponentModel.DataAnnotations;

namespace MaternidadeAPI.Modelo
{
    public class MaeModelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [RegularExpression(@"^\d{1,3}:\d{2}$", ErrorMessage = "A duração deve estar no formato mm:ss ou hhh:mm:ss.")]
        public string DataNascimento { get; set; } = string.Empty;
        public string Rg { get; set; }
        public string Cpf {  get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }

        public string Etinia { get; set;}
        public string Historico { get; set; }

        // Relação
    }
}
