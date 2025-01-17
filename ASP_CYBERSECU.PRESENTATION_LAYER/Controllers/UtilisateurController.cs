using ASP_CYBERSECU.BLL.Interfaces;
using ASP_CYBERSECU.Domain.Entities;
using ASP_CYBERSECU.PRESENTATION_LAYER.Models;
using ASP_CYBERSECU.PRESENTATION_LAYER.Models.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Delete(int id)
        {
            string? userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login");
            }

            Utilisateur utilisateur = _service.GetById(id);

            if (utilisateur is not null)
            {
                if (utilisateur.Email == userEmail)
                {

                    _service.Delete(id);
                    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
                }
                else
                {
                    return Forbid();
                }
            }

            return RedirectToAction("Index");
           
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            string? userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login");
            }

            Utilisateur utilisateur = _service.GetById(id);

            if(utilisateur is not null)
            {
                if(utilisateur.Email == userEmail)
                {

                    return View(_service.GetById(id).ToEditUtilisateur());
                }
                else
                {
                    return Forbid();
                }
            }

            return RedirectToAction("Index");
            
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


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUtilisateurForm loginUtilisateur)
        {
            if (ModelState.IsValid)
            {
                Utilisateur? utilisateur = _service.Login(loginUtilisateur.Email, loginUtilisateur.Password);

                if (utilisateur != null)
                {
                    // session

                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString()),
                        new Claim(ClaimTypes.Name, utilisateur.Username),
                        new Claim(ClaimTypes.Email, utilisateur.Email)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties authenticationProperties = new AuthenticationProperties 
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(1),
                    };


                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)).Wait();


                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction("Index", "Home");
        }
    }
}
