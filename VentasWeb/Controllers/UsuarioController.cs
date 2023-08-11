﻿using CamadaDados;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlePacientes.Utilidades;

namespace ControlePacientes.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Usuario> oListaUsuario = CD_Usuario.Instancia.ObtenerUsuarios();
            return Json(new { data = oListaUsuario }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Usuario objeto)
        {
            bool resposta = false;

            if (objeto.IdUsuario == 0)
            {
                objeto.Clave = Encriptar.GetSHA256(objeto.Clave);

                resposta = CD_Usuario.Instancia.RegistrarUsuario(objeto);
            }
            else
            {
                resposta = CD_Usuario.Instancia.ModificarUsuario(objeto);
            }


            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool resposta = CD_Usuario.Instancia.EliminarUsuario(id);

            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

    }
}