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
    public class ActualizarUsuarioModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "El campo Nombre de usuario es requerido")]
        public string NombreUsuario { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        public string Nombres { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        public string Apellidos { get; set; }
        [BindProperty]
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo Rol es requerido")]
        public int? RolId { get; set; }
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

            var usuarioId = id;

            //buscar el usuario en la BD

            var repo = new UsuarioRepositorio();
            var usuario = repo.ObtenerUsuarioPorId(usuarioId);
            this.Id = usuario.Id;
            this.Nombres = usuario.Nombres;
            this.Apellidos = usuario.Apellidos;
            this.NombreUsuario = usuario.NombreUsuario;
            this.RolId = usuario.RolId;
            this.Password = usuario.Password;
            this.RePassword = usuario.Password;

            return Page();
        }
    }
}
