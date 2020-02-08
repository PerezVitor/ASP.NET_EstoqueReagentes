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
    public class TB_REAGENTEController : Controller
    {
        private Model1 db = new Model1();

        // GET: TB_REAGENTE
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(db.TB_REAGENTE.ToList());
            }
            else
            {
                return RedirectToAction("Login", "TB_USUARIO");
            }            
        }

        // GET: TB_REAGENTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_REAGENTE tB_REAGENTE = db.TB_REAGENTE.Find(id);
            if (tB_REAGENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_REAGENTE);
        }

        // GET: TB_REAGENTE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_REAGENTE/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REAGENTE,NM_DESCRICAO,CD_INTERNO,NR_CAS,QT_PESO,UN_MEDIDA,DS_OBS,DS_STATUS")] TB_REAGENTE tB_REAGENTE)
        {
            if (ModelState.IsValid)
            {
                db.TB_REAGENTE.Add(tB_REAGENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_REAGENTE);
        }

        // GET: TB_REAGENTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_REAGENTE tB_REAGENTE = db.TB_REAGENTE.Find(id);
            if (tB_REAGENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_REAGENTE);
        }

        // POST: TB_REAGENTE/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REAGENTE,NM_DESCRICAO,CD_INTERNO,NR_CAS,QT_PESO,UN_MEDIDA,DS_OBS")] TB_REAGENTE tB_REAGENTE)
        {
            tB_REAGENTE.DS_STATUS = "A";
            if (ModelState.IsValid)
            {
                db.Entry(tB_REAGENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_REAGENTE);
        }

        // GET: TB_REAGENTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_REAGENTE tB_REAGENTE = db.TB_REAGENTE.Find(id);
            if (tB_REAGENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_REAGENTE);
        }

        // POST: TB_REAGENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_REAGENTE tB_REAGENTE = db.TB_REAGENTE.Find(id);
            db.TB_REAGENTE.Remove(tB_REAGENTE);
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
