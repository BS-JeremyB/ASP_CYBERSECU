using ASP_CYBERSECU.Domain.Entities;

namespace ASP_CYBERSECU.PRESENTATION_LAYER.Models.Mappers
{
    public static class UtilisateurMapper
    {

        public static Utilisateur ToUtilisateur(this CreationUtilisateurForm utilisateur)
        {
            return new Utilisateur
            {
                Username = utilisateur.Username,
                Email = utilisateur.Email,
                Password = utilisateur.Password,
            };
        }

        public static Utilisateur ToUtilisateur(this EditUtilisateurForm utilisateur)
        {
            return new Utilisateur
            {
                Id = utilisateur.Id,
                Email = utilisateur.Email,
                Username = utilisateur.Username,
            };
        }
        public static EditUtilisateurForm ToEditUtilisateur(this Utilisateur utilisateur)
        {
            return new EditUtilisateurForm
            {
                Username = utilisateur.Username,
                Email = utilisateur.Email,
            };
        }
    }
}
