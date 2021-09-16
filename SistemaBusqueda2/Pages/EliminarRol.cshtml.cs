using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBusqueda2.Repositorios;

namespace SistemaBusqueda2.Pages
{
    public class EliminarRolModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
        public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            //obtener el registro de la bd
            var repo = new RolRepositorio();
            var rol = repo.ObtenerRolPorId(id);
            this.Id = rol.Id ;
            this.Nombre = rol.Nombre;
            return Page();
        }

        public ActionResult OnPost()
        {
            //eliminar el registro de la bd
            var repo = new RolRepositorio();
            repo.EliminarRol(this.Id);
            return RedirectToPage("./Roles");
        }

    }
}
