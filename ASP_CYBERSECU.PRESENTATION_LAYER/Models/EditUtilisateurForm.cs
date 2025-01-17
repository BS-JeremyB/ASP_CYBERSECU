using System.ComponentModel.DataAnnotations;

namespace ASP_CYBERSECU.PRESENTATION_LAYER.Models
{
    public class EditUtilisateurForm
    {
        [Required]
        public int Id {  get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
