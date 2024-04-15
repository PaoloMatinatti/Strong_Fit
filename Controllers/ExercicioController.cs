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
    public class ExercicioController : Controller
    {

        public Context context;

        public ExercicioController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Exercicios);
        }

        public IActionResult Create()
        {
            ViewBag.ExercicioId = new SelectList(context.Exercicios
                .OrderBy(e => e.Nome), "ExercicioId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Exercicio exercicio)
        {
            context.Add(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var exercicio = context.Exercicios.FirstOrDefault(e => e.ExercicioId == id);
            return View(exercicio);
        }

        public IActionResult Edit(int id)
        {
            var exercicio = context.Personais.Find(id);
            ViewBag.ExrcicioId = new SelectList(context.Exercicios.OrderBy(e => e.Nome), "ExercicioId", "Nome");
            return View(exercicio);
        }

        [HttpPost]
        public IActionResult Edit(Exercicio exercicio)
        {
            //avisa a EF que o registro será modificado
            context.Entry(exercicio).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var exercicio = context.Exercicios.FirstOrDefault(e => e.ExercicioId == id);
            return View(exercicio);
        }

        [HttpPost]
        public IActionResult Delete(Exercicio exercicio)
        {
            context.Exercicios.Remove(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
