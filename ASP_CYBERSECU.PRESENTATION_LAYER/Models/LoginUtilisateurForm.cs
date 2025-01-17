using System.ComponentModel.DataAnnotations;

namespace ASP_CYBERSECU.PRESENTATION_LAYER.Models
{
    public class LoginUtilisateurForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
