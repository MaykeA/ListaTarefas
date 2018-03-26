using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ListaDeTarefas.Models;

namespace ListaDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tarefas
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Tarefas> GetMyTarefas()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);
            return db.Tarefas.ToList().Where(x => x.User == currentUser);

        }

        public ActionResult ConstruirTabelaDeTarefas()
        {
            return PartialView("_TabelaDeTarefas", GetMyTarefas());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descrição,Completo")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "Id,Descrição")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                tarefas.User = currentUser;
                tarefas.Completo = false;
                db.Tarefas.Add(tarefas);
                db.SaveChanges();

            }

            return PartialView("_TabelaDeTarefas", GetMyTarefas());
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descrição,Completo")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefas);
        }

        [HttpPost]
        public ActionResult AJAXEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }else
            {
                tarefas.Completo = value;
                db.Entry(tarefas).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_TabelaDeTarefas", GetMyTarefas());
            }

        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefas tarefas = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
