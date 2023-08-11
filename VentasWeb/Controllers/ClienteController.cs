using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePacientes.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Cliente> oListaCliente = CD_Cliente.Instancia.ObtenerClientes();
            return Json(new { data = oListaCliente }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Cliente objeto)
        {
            bool resposta = false;

            if (objeto.IdCliente == 0)
            {
                resposta = CD_Cliente.Instancia.RegistrarCliente(objeto);
            }
            else
            {
                resposta = CD_Cliente.Instancia.ModificarCliente(objeto);
            }


            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool resposta = CD_Cliente.Instancia.EliminarCliente(id);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }
    }
}