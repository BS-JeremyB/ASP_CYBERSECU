using ASP_CYBERSECU.BLL.Interfaces;
using ASP_CYBERSECU.DAL.Interfaces;
using ASP_CYBERSECU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_CYBERSECU.BLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _repository;

        public UtilisateurService(IUtilisateurRepository repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            return _repository.GetAll();
        }

        public Utilisateur? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Utilisateur? Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Utilisateur? Register(Utilisateur utilisateur)
        {
            return _repository.Register(utilisateur);
        }

        public Utilisateur? UpdateUtilisateur(Utilisateur utilisateur)
        {
            return _repository.UpdateUtilisateur(utilisateur);
        }
    }
}
