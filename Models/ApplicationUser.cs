using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RESERVAS_DE_HOTEL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string NombreCompleto { get; set; } = string.Empty;
    }
}