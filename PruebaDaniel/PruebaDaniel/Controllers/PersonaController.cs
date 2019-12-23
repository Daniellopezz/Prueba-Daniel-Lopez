using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaDaniel.Models.ViewModel;
using PruebaDaniel.Models;

namespace PruebaDaniel.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<ListPersonaViewModel> lst;

            using (pruebaEntities db = new pruebaEntities())
            {
                 lst = (from d in db.Persona
                           select new ListPersonaViewModel
                           {
                               ID = d.ID,
                               Nombre = d.Nombre,
                               Fecha_Nacimiento = d.Fecha_Nacimiento
                           }).ToList();
            }


            return View(lst);
        }

       public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (pruebaEntities db = new pruebaEntities())
                    {
                        var oPersona = new Persona();
                        oPersona.Nombre = model.Nombre;
                        oPersona.Fecha_Nacimiento = model.Fecha_Nacimiento;

                        db.Persona.Add(oPersona);
                        db.SaveChanges();

                       
                    }
                    return Redirect("~/Persona/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        
        public ActionResult Editar(int ID)
        {
            PersonaViewModel model = new PersonaViewModel();
            using (pruebaEntities db = new pruebaEntities())
            {
                var oPersona = db.Persona.Find(ID);
                model.Nombre = oPersona.Nombre;
                model.Fecha_Nacimiento = oPersona.Fecha_Nacimiento;
                model.ID = oPersona.ID;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (pruebaEntities db = new pruebaEntities())
                    {
                        var oPersona = db.Persona.Find(model.ID);
                        oPersona.Nombre = model.Nombre;
                        oPersona.Fecha_Nacimiento = model.Fecha_Nacimiento;

                        db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }
                    return Redirect("~/Persona/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int ID)
        {
           
            using (pruebaEntities db = new pruebaEntities())
            {
                var oPersona = db.Persona.Find(ID);
                db.Persona.Remove(oPersona);
                db.SaveChanges();
            }
            return Redirect("~/Persona/");
        }
    }
}