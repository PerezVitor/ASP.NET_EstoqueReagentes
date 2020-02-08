using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiReagentes;

namespace WebApiReagentes.Controllers
{
    public class TB_EMPRESTIMOController : Controller
    {
        private Model1 db = new Model1();

        // GET: TB_EMPRESTIMO
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(db.TB_EMPRESTIMO.ToList());
            }
            else
            {
                return RedirectToAction("Login", "TB_USUARIO");
            }
        }

        // GET: TB_EMPRESTIMO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_EMPRESTIMO tB_EMPRESTIMO = db.TB_EMPRESTIMO.Find(id);
            if (tB_EMPRESTIMO == null)
            {
                return HttpNotFound();
            }
            return View(tB_EMPRESTIMO);
        }

        // GET: TB_EMPRESTIMO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_EMPRESTIMO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPRESTIMO,ID_USUARIO,ID_REAGENTE,QT_PESO")] TB_EMPRESTIMO tB_EMPRESTIMO)
        {
            tB_EMPRESTIMO.DS_STATUS = "A";
            tB_EMPRESTIMO.DT_EMPRESTIMO = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.TB_EMPRESTIMO.Add(tB_EMPRESTIMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_EMPRESTIMO);
        }

        // GET: TB_EMPRESTIMO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_EMPRESTIMO tB_EMPRESTIMO = db.TB_EMPRESTIMO.Find(id);
            if (tB_EMPRESTIMO == null)
            {
                return HttpNotFound();
            }
            return View(tB_EMPRESTIMO);
        }

        // POST: TB_EMPRESTIMO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPRESTIMO,ID_USUARIO,ID_REAGENTE,QT_PESO,DT_EMPRESTIMO")] TB_EMPRESTIMO tB_EMPRESTIMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_EMPRESTIMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_EMPRESTIMO);
        }

        // GET: TB_EMPRESTIMO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_EMPRESTIMO tB_EMPRESTIMO = db.TB_EMPRESTIMO.Find(id);
            if (tB_EMPRESTIMO == null)
            {
                return HttpNotFound();
            }
            return View(tB_EMPRESTIMO);
        }

        // POST: TB_EMPRESTIMO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_EMPRESTIMO tB_EMPRESTIMO = db.TB_EMPRESTIMO.Find(id);
            db.TB_EMPRESTIMO.Remove(tB_EMPRESTIMO);
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
