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
    public class NuevoRolModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }
        public ActionResult OnGet()
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Guardar el registro en la bd
                var repo = new RolRepositorio();
                repo.InsertarRol(this.Nombre);
                return RedirectToPage("./Roles");
            }

            return Page();
        
        }
    }
}
