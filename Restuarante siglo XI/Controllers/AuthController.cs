using Restaurante_siglo_XI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace Restuarante_siglo_XI.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login (Cliente usuario, String ReturnUrl)
        {
            if (IsValid(usuario))
            {
                //usuario.buscarClientecorreo(usuario.correoCliente);

                FormsAuthentication.SetAuthCookie(usuario.correoCliente, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                String correoCliente = usuario.correoCliente;
                //PersonaController pcl = new PersonaController();
                //ActionResult re = pcl.homeUser(correoCliente);

                //return re;
                //return pcl.homeUser(ViewBag.correoC);
                return RedirectToAction("homeUser","Persona", new { correo = correoCliente });
            }
            TempData["mensaje"] = "Credenciales incorrectas";
            return View(usuario);
        }

        private bool IsValid(Cliente usuario)
        {
            return usuario.AutenticarCLiente();
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }

        private bool IsValidAdmin(Personal perso)
        {
            return perso.AutenticarPersonal();
        }

        [HttpPost]
        public ActionResult LoginAdmin(Personal perso, String ReturnUrl)
        {
            if (IsValidAdmin(perso))
            {
                FormsAuthentication.SetAuthCookie(perso.Correo_personal, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                String correoAdmin = perso.Correo_personal;
                return RedirectToAction("homeAdmin", "Persona");
            }
            TempData["mensaje"] = "Credenciales incorrectas";
            return View(perso);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}