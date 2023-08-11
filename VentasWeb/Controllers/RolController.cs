using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePacientes.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Obtener()
        {
            List<Rol> olista = CD_Rol.Instancia.ObtenerRol();
           
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(Rol objeto)
        {
            bool resposta = false;

            if (objeto.IdRol == 0)
            {

                resposta = CD_Rol.Instancia.RegistrarRol(objeto);
            }
            else
            {
                resposta = CD_Rol.Instancia.ModificarRol(objeto);
            }


            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool resposta = CD_Rol.Instancia.EliminarRol(id);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

    }
}