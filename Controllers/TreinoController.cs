using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto_BackEnd.Controllers
{
    public class TreinoController : Controller
    {
        public Context context;

        public TreinoController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Treinos.Include(a => a.Aluno));
        }

        public IActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(context.Alunos
                .OrderBy(a => a.Nome), "AlunoId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Treino treino)
        {
            context.Add(treino);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var treino = context.Treinos
                .Include(a => a.Aluno)
                .FirstOrDefault(a => a.AlunoId == id);
            return View(treino);
        }

        public IActionResult Edit(int id)
        {
            var treino = context.Treinos.Find(id);
            ViewBag.AlunoId = new SelectList(context.Personais.OrderBy(a => a.Nome), "AlunoId", "Nome");
            return View(treino);
        }

        [HttpPost]
        public IActionResult Edit(Treino treino)
        {
            //avisa a EF que o registro será modificado
            context.Entry(treino).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var treino = context.Treinos
                .Include(a => a.Aluno)
                .FirstOrDefault(t => t.TreinoId == id);
            return View(treino);
        }

        [HttpPost]
        public IActionResult Delete(Treino treino)
        {
            context.Treinos.Remove(treino);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
