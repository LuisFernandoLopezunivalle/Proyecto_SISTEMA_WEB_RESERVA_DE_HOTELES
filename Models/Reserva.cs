using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESERVAS_DE_HOTEL.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public string? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public ApplicationUser? Usuario { get; set; }
        public decimal Total { get; set; }
    }
}