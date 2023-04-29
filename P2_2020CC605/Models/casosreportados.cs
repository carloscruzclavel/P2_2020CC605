using System.ComponentModel.DataAnnotations;

namespace P2_2020CC605.Models
{
    public class casosreportados
    {
        [Key]
        public int id_casoreportado { get; set; }
        public int? confirmados { get; set; }
        public int? recuperados { get; set; }
        public int? fallecidos { get; set; }
        public int id_departamento { get; set; }
        public int id_genero { get; set; }
    }
}
