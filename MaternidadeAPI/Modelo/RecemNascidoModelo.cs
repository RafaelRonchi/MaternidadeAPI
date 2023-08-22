using System.ComponentModel.DataAnnotations;

namespace MaternidadeAPI.Modelo
{
    public class RecemNascidoModelo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Genero { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public int PesoGramas { get; set; } = 0;
        public int AlturaCentimetros { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoParto { get; set; }

        public int Apgar { get; set; }

        [MaxLength(500)]
        public string CondicaoSaude { get; set; }

        public int MaeId { get; set; }

        public MaeModelo Mae { get; set; }
    }
}
