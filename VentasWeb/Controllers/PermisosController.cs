using CamadaDados;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePacientes.Controllers
{
    public class PermisosController : Controller
    {
        // GET: Permisos
        public ActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Obtener(int id)
        {
            List<Permisos> olista = CD_Permisos.Instancia.ObtenerPermisos(id);

            return Json(olista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(string xml)
        {
            bool resposta = CD_Permisos.Instancia.ActualizarPermisos(xml);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

    }
}