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
    }
}
