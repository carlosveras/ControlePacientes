using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePacientes.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Tienda> lista = CD_Tienda.Instancia.ObtenerTiendas();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost]
        public JsonResult Guardar(Tienda objeto)
        {
            bool resposta = false;

            if (objeto.IdTienda == 0)
            {

                resposta = CD_Tienda.Instancia.RegistrarTienda(objeto);
            }
            else
            {
                resposta = CD_Tienda.Instancia.ModificarTienda(objeto);
            }


            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool resposta = CD_Tienda.Instancia.EliminarTienda (id);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }
    }
}