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
    public class EliminarUsuarioModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string NombreUsuario { get; set; }
        public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }
            this.Id = id;
            var repo = new UsuarioRepositorio();
            var usuario = repo.ObtenerUsuarioPorId(id);
            this.NombreUsuario = usuario.NombreUsuario;

            return Page();
        }
        public ActionResult OnPost()
        {
            var repo = new UsuarioRepositorio();
            repo.EliminarUsuario(this.Id);
            return RedirectToPage("./Usuarios");
        }
    }
}
