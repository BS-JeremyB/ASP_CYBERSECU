using ASP_CYBERSECU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_CYBERSECU.BLL.Interfaces
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur? GetById(int id);
        bool Delete(int id);
        Utilisateur? UpdateUtilisateur(int id, Utilisateur utilisateur);
        Utilisateur? Register(Utilisateur utilisateur);
        Utilisateur? Login(string email, string password);


    }
}
