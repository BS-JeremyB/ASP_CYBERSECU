using ASP_CYBERSECU.BLL.Interfaces;
using ASP_CYBERSECU.Domain.Entities;
using ASP_CYBERSECU.PRESENTATION_LAYER.Models;
using ASP_CYBERSECU.PRESENTATION_LAYER.Models.Mappers;
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

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreationUtilisateurForm utilisateur)
        {
            if (ModelState.IsValid)
            {

                _service.Register(utilisateur.ToUtilisateur());
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Create");
            }
        }
    }
}
