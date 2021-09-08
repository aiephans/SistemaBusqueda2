using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusqueda2.Repositorios
{
    public class UsuarioRepositorio
    {
        public void InsertarUsuario(string nombres,string apellidos,int rolId, string nombreUsuario, string password)
        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_insertar_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombres", nombres));
            cmd.Parameters.Add(new SqlParameter("@apellidos", apellidos));
            cmd.Parameters.Add(new SqlParameter("@rolId", rolId));
            cmd.Parameters.Add(new SqlParameter("@nombreUsuario", nombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
