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
    public class ActualizarPasswordModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener al menos una Mayuscula, minusculas y digitos")]
        public string Password { get; set; }
        [BindProperty]
        [Display(Name = "Repetir contraseña")]
        [Required(ErrorMessage = "El campo Repetir contraseña es requerido")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener al menos una Mayuscula, minusculas y digitos")]
        public string RePassword { get; set; }
        public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            this.Id = id;

            return Page();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var password = this.Password;
                var repassword = this.RePassword;
                //Valido si las contraseñas son iguales
                if (password != repassword)
                {
                    ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                    return Page();
                };

                //Actualizar la contraseña en la bd
                var repo = new UsuarioRepositorio();
                repo.ActualizarPassword(this.Id, this.Password);
                return RedirectToPage("./Usuarios");
            }

            return Page();
        }
    }
}
