using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Application.Contracts;
using Sale.Infrastructure.Models;
using Newtonsoft.Json;
using Sale.Application.Core;
using Sale.Application.Dtos.Usuario;
using Sale.Web.Models.Responses;






namespace Sale.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService usuarioService) 
        { 
            this.usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var result = this.usuarioService.GetAll();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
