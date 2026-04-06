using System.ComponentModel.DataAnnotations;

namespace RESERVAS_DE_HOTEL.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public string UsuarioId { get; set; } = string.Empty;

        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }
    }
}