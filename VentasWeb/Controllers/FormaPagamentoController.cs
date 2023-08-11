using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePacientes.Controllers
{
    public class FormaPagamentoController : Controller
    {
        // GET: Categoria
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<FormaPagamento> lista = CD_FormaPagamento.Instancia.ObterFormaPagamento();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(FormaPagamento objeto)
        {
            bool resposta = false;

            if (objeto.IdFormaPagto == 0)
            {

                resposta = CD_FormaPagamento.Instancia.RegistrarFormaPagamento(objeto);
            }
            else
            {
                resposta = CD_FormaPagamento.Instancia.ModificarFormaPagamento(objeto);
            }


            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool resposta = CD_FormaPagamento.Instancia.EliminarFormaPagamento(id);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

    }
}