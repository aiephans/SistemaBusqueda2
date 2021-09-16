using SistemaBusqueda2.Modelos;
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

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            bool respuesta = false;
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_check_nombre_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombreUsuario", nombreUsuario));
            sql.Open();
            int resultadoQuery = (int)cmd.ExecuteScalar();
            if (resultadoQuery > 0)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public List<UsuarioListaModelo> ObtenerUsuarios()
        {
            var respuesta = new List<UsuarioListaModelo>();
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_mostrar_usuarios", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoUsuario = new UsuarioListaModelo() {
                        Id = (int)reader["id"],
                        NombreUsuario = reader["nombreUsuario"].ToString(),
                        Nombres = reader["nombres"].ToString(),
                        Apellidos = reader["apellidos"].ToString(),
                        RolId = (int)reader["rolId"]
                    };

                    respuesta.Add(nuevoUsuario);
                }
            }
                return respuesta;
        }

        public UsuarioActualizarModel ObtenerUsuarioPorId(int id)
        {
            var respuesta = new UsuarioActualizarModel();
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_obtener_usuario_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoUsuario = new UsuarioActualizarModel()
                    {
                        Id = (int)reader["id"],
                        NombreUsuario = reader["nombreUsuario"].ToString(),
                        Nombres = reader["nombres"].ToString(),
                        Apellidos = reader["apellidos"].ToString(),
                        RolId = (int)reader["rolId"],
                        Password = reader["password"].ToString()
                    };

                    respuesta = nuevoUsuario;
                }
            }
            return respuesta;
        }

        public void ActualizarUsuario(int id,string nombres, string apellidos, int rolId)
        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_actualiza_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@nombres", nombres));
            cmd.Parameters.Add(new SqlParameter("@apellidos", apellidos));
            cmd.Parameters.Add(new SqlParameter("@rolId", rolId));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public void ActualizarPassword(int id, string password)
        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_actualizar_password", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public void EliminarUsuario(int id)
        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_eliminar_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
