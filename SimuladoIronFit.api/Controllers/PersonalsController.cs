
using Microsoft.AspNetCore.Mvc;
using SimuladoIronFit.Api.Data;
using SimuladoIronFit.Api.Models;

namespace SimuladoIronFit.Api.Controllers
{
    public class PersonalsController : Controller
    {
        private Banco db;

        public PersonalsController(Banco banco)
        {
            db = banco;
        }

        public IActionResult Index(string busca)
        {
            var lista = db.Personals.ToList();

            if (!string.IsNullOrEmpty(busca))
            {
                lista = lista.Where(p => p.Nome.Contains(busca)).ToList();
            }

            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personal p)
        {
            db.Personals.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var p = db.Personals.Find(id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Personal p)
        {
            var personal = db.Personals.Find(p.Id);

            if (personal == null)
            {
                return NotFound();
            }

            personal.Nome = p.Nome;
            personal.CPF = p.CPF;
            personal.Telefone = p.Telefone;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
