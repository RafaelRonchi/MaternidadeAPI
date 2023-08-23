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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;

        public int PesoGramas { get; set; } = 0;
        public int AlturaCentimetros { get; set; } = 0;

        [Required]
        [MaxLength(50)]
        public string TipoParto { get; set; } = string.Empty;

        public int Apgar { get; set; } = 0;

        [MaxLength(500)]
        public string CondicaoSaude { get; set; } = string.Empty;

        public int MaeId { get; set; }
        public MaeModelo Mae { get; set; } = new MaeModelo();
    }
}
