
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimuladoIronFit.Api.Data;
using SimuladoIronFit.Api.Models;

namespace SimuladoIronFit.Api.Controllers
{
    public class AgendamentosController : Controller
    {
        private Banco db;

        public AgendamentosController(Banco banco)
        {
            db = banco;
        }

        public IActionResult Index()
        {
            var lista = db.Agendamentos
                .Include(a => a.Aluno)
                .Include(a => a.Personal)
                .OrderBy(a => a.DataAgendamento)
                .ToList();

            return View(lista);
        }

        public IActionResult Create()
        {
            ViewBag.Alunos = new SelectList(
                db.Alunos.ToList(), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Agendamento a)
        {
            var aluno = db.Alunos.Find(a.AlunoId);

            if (aluno == null)
            {
                return BadRequest();
            }

            a.PersonalId = aluno.PersonalId;

            db.Agendamentos.Add(a);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var a = db.Agendamentos.Find(id);

            if (a == null)
            {
                return NotFound();
            }

            ViewBag.Alunos = new SelectList(
                db.Alunos.ToList(), "Id", "Nome", a.AlunoId);

            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Agendamento a)
        {
            var aluno = db.Alunos.Find(a.AlunoId);

            if (aluno == null)
            {
                return BadRequest();
            }

            var agendamento = db.Agendamentos.Find(a.Id);

            if (agendamento == null)
            {
                return NotFound();
            }

            agendamento.DataAgendamento = a.DataAgendamento;
            agendamento.AlunoId = a.AlunoId;
            agendamento.PersonalId = aluno.PersonalId;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
