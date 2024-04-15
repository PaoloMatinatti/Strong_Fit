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
    public class PersonalController : Controller
    {

        public Context context;

        public PersonalController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Personais);
        }

        public IActionResult Create()
        {
            ViewBag.PersonalID = new SelectList(context.Personais
                .OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personal personal)
        {
            context.Add(personal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var personal = context.Personais.FirstOrDefault(p => p.PersonalId == id);
            return View(personal);
        }

        public IActionResult Edit(int id)
        {
            var personal = context.Personais.Find(id);
            ViewBag.PersonalId = new SelectList(context.Personais.OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View(personal);
        }

        [HttpPost]
        public IActionResult Edit(Personal personal)
        {
            //avisa a EF que o registro será modificado
            context.Entry(personal).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var personal = context.Personais.FirstOrDefault(p => p.PersonalId == id);
            return View(personal);
        }

        [HttpPost]
        public IActionResult Delete(Personal personal)
        {
            context.Personais.Remove(personal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
