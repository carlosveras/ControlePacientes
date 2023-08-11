using CamadaDados;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlePacientes.Utilidades;

namespace ControlePacientes.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Proveedor> olista = CD_Proveedor.Instancia.ObtenerProveedor();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Proveedor objeto)
        {
            bool resposta = false;

            if (objeto.IdProveedor == 0)
            {

                resposta = CD_Proveedor.Instancia.RegistrarProveedor(objeto);
            }
            else
            {
                resposta = CD_Proveedor.Instancia.ModificarProveedor(objeto);
            }


            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool resposta = CD_Proveedor.Instancia.EliminarProveedor(id);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

    }
}