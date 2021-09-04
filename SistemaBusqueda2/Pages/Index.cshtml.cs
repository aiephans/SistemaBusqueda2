using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SistemaBusqueda2.Repositorios;
using Microsoft.AspNetCore.Http;

namespace SistemaBusqueda2.Pages
{
    public class IndexModel : PageModel
    {
        [Display(Name ="Usuario")]
        [BindProperty]
        [Required(ErrorMessage ="El campo usuario es requerido")]
        public string NombreUsuario { get; set; }
        [Display(Name ="Contraseña")]
        [BindProperty]
        [Required(ErrorMessage ="El campo password es requerido")]
        public string Password { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var usuario = this.NombreUsuario;
                var password = this.Password;
                //Validar en la BD
                var respo = new LoginRepositorio();
                bool resultadoValidacion = respo.ExisteUsuario(usuario, password);

                if (resultadoValidacion == true)
                {
                    //Crear y asignar la session
                    Guid idSession = Guid.NewGuid();
                    HttpContext.Session.SetString("idSession", idSession.ToString());
                    return RedirectToPage("./Home");
                }

                ModelState.AddModelError(string.Empty, "Usuario o contraseña invalidos");
                return Page();
                //Return Redirigir a una nueva pagina

            }
            return Page();
        }
    }
}
