using ASP_CYBERSECU.BLL.Interfaces;
using ASP_CYBERSECU.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CYBERSECU.PRESENTATION_LAYER.Controllers
{
    public class UtilisateurController : Controller
    {

        private readonly IUtilisateurService _service;

        public UtilisateurController(IUtilisateurService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Utilisateur> utilisateurs = _service.GetAll().ToList();
            return View(utilisateurs);
        }
    }
}
