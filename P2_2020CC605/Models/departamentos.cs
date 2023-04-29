using System.ComponentModel.DataAnnotations;

namespace P2_2020CC605.Models
{
    public class departamentos
    {
        [Key]
        public int id_departamento { get; set; }
        public string? departamento { get; set; }
    }
}
