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
    public class RolesModel : PageModel
    {
        public List<RolListaModelo> Roles { get; set; }
        public ActionResult OnGet()
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            //obtener los registros de la bd y cargarselos a la propiedad Roles

            var repo = new RolRepositorio();

            this.Roles = repo.ObtenerRoles();

            return Page();
        }
    }
}
