using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESERVAS_DE_HOTEL.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioPorNoche { get; set; }

        public string Descripcion { get; set; } = string.Empty;
    }
}