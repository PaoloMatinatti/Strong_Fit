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
    public class AlunosController : Controller
    {
        public Context context;

        public AlunosController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Alunos.Include(p => p.Personal));
        }

        public IActionResult Create() 
        {
            ViewBag.PersonalID = new SelectList(context.Personais
                .OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            context.Add(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details (int id)
        {
            var aluno = context.Alunos
                .Include(p => p.Personal)
                .FirstOrDefault(a => a.AlunoId == id);
            return View(aluno);
        }

        public IActionResult Edit(int id)
        {
            var aluno = context.Alunos.Find(id);
            ViewBag.PersonalId = new SelectList(context.Personais.OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Edit(Aluno aluno)
        {
            //avisa a EF que o registro será modificado
            context.Entry(aluno).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var aluno = context.Alunos
                .Include(p => p.Personal)
                .FirstOrDefault(a => a.AlunoId == id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Delete(Aluno aluno)
        {
            context.Alunos.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}




