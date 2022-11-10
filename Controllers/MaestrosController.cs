using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Maestros
        public ActionResult Index()
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                

                return View(dbMaestros.Maestros.ToList());
            }
        }
        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                Maestro maestro = dbMaestros.Maestros.Find(id);
                if (maestro == null)
                {
                    return HttpNotFound();
                }
                return View(maestro);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Maestro prof)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                dbMaestros.Maestros.Add(prof);
                dbMaestros.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matrícula == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(Maestro prof)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                dbMaestros.Entry(prof).State = EntityState.Modified;
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matrícula == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(Maestro prof, int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                Maestro mae = dbMaestros.Maestros.Where(x => x.Matrícula == id).FirstOrDefault();
                dbMaestros.Maestros.Remove(mae);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}