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
            return Page();
        }

        public IActionResult OnPost()
        {
            var repo = new UsuarioRepositorio();
            repo.ActualizarUsuario(this.Id, this.Nombres, this.Apellidos, (int)this.RolId);
            return RedirectToPage("Usuarios");

        }
    }
}
