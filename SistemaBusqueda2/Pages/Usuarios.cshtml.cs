using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBusqueda2.Modelos;
using SistemaBusqueda2.Repositorios;

namespace SistemaBusqueda2.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<UsuarioListaModelo> Usuarios { get; set; }
        public ActionResult OnGet()
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }
            //cargar los usuarios
            var repo = new UsuarioRepositorio();
            this.Usuarios = repo.ObtenerUsuarios();
            return Page();
        }
    }
}
