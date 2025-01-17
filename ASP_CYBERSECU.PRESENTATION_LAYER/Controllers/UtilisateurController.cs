using ASP_CYBERSECU.BLL.Interfaces;
using ASP_CYBERSECU.Domain.Entities;
using ASP_CYBERSECU.PRESENTATION_LAYER.Models;
using ASP_CYBERSECU.PRESENTATION_LAYER.Models.Mappers;
using Microsoft.AspNetCore.Authorization;
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
        [ValidateAntiForgeryToken]
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

        public IActionResult Details(int id)
        {
            
            return View(_service.GetById(id));
        }


        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetById(id).ToEditUtilisateur());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditUtilisateurForm editUtilisateur)
        {
            if (ModelState.IsValid)
            {
                Utilisateur utilisateur = _service.UpdateUtilisateur(editUtilisateur.ToUtilisateur());
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { Id = editUtilisateur.Id});
        }
    }
}
