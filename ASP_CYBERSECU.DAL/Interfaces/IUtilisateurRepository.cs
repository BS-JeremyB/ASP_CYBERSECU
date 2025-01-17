using ASP_CYBERSECU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_CYBERSECU.DAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur? GetById(int id);
        Utilisateur? GetByEmail(string email);
        bool Delete(int id);
        Utilisateur? UpdateUtilisateur(Utilisateur utilisateur);
        Utilisateur? Register(Utilisateur utilisateur);
        Utilisateur? Login(string email , string password);
    }
}
