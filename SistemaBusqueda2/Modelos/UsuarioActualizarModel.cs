using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusqueda2.Modelos
{
    public class UsuarioActualizarModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int RolId { get; set; }
        public string Password { get; set; }
    }
}
