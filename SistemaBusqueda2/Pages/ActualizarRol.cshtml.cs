using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBusqueda2.Repositorios;

namespace SistemaBusqueda2.Pages
{
    public class ActualizarRolModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }
        public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }
            //ir a buscar a la bd el registro por su id
            var repo = new RolRepositorio();
            var rol = repo.ObtenerRolPorId(id);
            this.Id = rol.Id;
            this.Nombre = rol.Nombre;

            return Page();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // actualizar el registro en la bd
                var repo = new RolRepositorio();
                repo.ActualizarRol(this.Id, this.Nombre);
                return RedirectToPage("./Roles");

            }

            return Page();
        }
    }
}
