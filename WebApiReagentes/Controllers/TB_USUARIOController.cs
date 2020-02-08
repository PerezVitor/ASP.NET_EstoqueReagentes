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
    public class TB_USUARIOController : Controller
    {
        private Model1 db = new Model1();

        // LOGIN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TB_USUARIO usuario)
        {
            // esta action trata o post (login)
            //if (ModelState.IsValid) //verifica se é válido
            //{
                var validar = db.TB_USUARIO.Where(a => a.DS_NOME.Equals(usuario.DS_NOME) && a.DS_SENHA.Equals(usuario.DS_SENHA)).FirstOrDefault();
                if (validar != null)
                {
                    Session["usuarioLogadoID"] = validar.ID_USUARIO.ToString();
                    Session["nomeUsuarioLogado"] = validar.DS_NOME.ToString();
                    return RedirectToAction("Index");
                }
            //}
            return View(usuario);
        }

        // LOGIN
        public ActionResult Logout()
        {
            Session["usuarioLogadoID"] = null;
            Session["nomeUsuarioLogado"] = null;
            return RedirectToAction("Login");
        }

        // GET: TB_USUARIO
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(db.TB_USUARIO.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }            
        }

        // GET: TB_USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // GET: TB_USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_USUARIO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,DS_NOME,DS_SENHA,DS_EMAIL,DS_TIPO,DS_STATUS")] TB_USUARIO tB_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TB_USUARIO.Add(tB_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_USUARIO);
        }

        // GET: TB_USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // POST: TB_USUARIO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,DS_NOME,DS_SENHA,DS_EMAIL,DS_TIPO,DS_STATUS")] TB_USUARIO tB_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_USUARIO);
        }

        // GET: TB_USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // POST: TB_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            db.TB_USUARIO.Remove(tB_USUARIO);
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
