using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ApiCarRental
{
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                string cadenaConexion = @"Server=carmencgserver.database.windows.net;
                                          Database=PedroMGB2;
                                          User Id=testuser;
                                          Password=!Curso@2017;";

                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

                //// PREGUNTO POR EL ESTADO DE LA CONEXIÓN
                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("Conexión abierta con éxito");
                //    // CIERRO LA CONEXIÓN
                //    conexion.Close();
                //}
            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {
                // DESTRUYO LA CONEXIÓN
                //if (conexion != null)
                //{
                //    if (conexion.State != ConnectionState.Closed)
                //    {
                //        conexion.Close();
                //        Console.WriteLine("Conexión cerrada con éxito");
                //    }
                //    conexion.Dispose();
                //    conexion = null;
                //}
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        //new
        public static List<Usuario> Login(string email, string password)
        {
            List<Usuario> usuarios = null;
            // PREPARO LA CONSULTA SQL PARA OBTENER LOS USUARIOS
            string consultaSQL = "dbo.Login";
            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "email",
                Value = email,
                SqlDbType = SqlDbType.NVarChar
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "password",
                Value = password,
                SqlDbType = SqlDbType.NVarChar
            });
            // RECOJO LOS DATOS
            SqlDataReader reader = comando.ExecuteReader();
            usuarios = new List<Usuario>();

            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    idUsuario = int.Parse(reader["idUsuario"].ToString()),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    apellidos = reader["apellidos"].ToString(),
                    nif = reader["nif"].ToString(),
                    fechaNacimiento = (DateTime)reader["fechaNacimiento"]
                });
            }

            // DEVUELVO LOS DATOS
            return usuarios;
        }

        public static int EliminarUsuario(int idUsuario)
        {
            // PREPARO LA CONSULTA SQL PARA INSERTAR AL NUEVO USUARIO
            string consultaSQL = "dbo.EliminarUsuario";
            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idUsuario",
                Value = idUsuario,
                SqlDbType = SqlDbType.Int
            });
            // EJECUTO EL COMANDO
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        //función hecha por el teacher
                function eliminar(id, fila)
                {

                    if (confirm('Estás seguro de eliminar?'))
                    { 

                        $.ajax({
                        url: '/api/usuarios/${id}',
                                            type: "DELETE",
                                            success: function(respuesta) {
                                var table = $('#datatables').DataTable();
                                table.row(fila).remove().draw();
                                                $(fila).fadeOut('slow');
                                mensajes.showSwal('exito', 'Resultado', 'Usuario eliminado correctamente.')
                                            },
                                            error: function(respuesta) {
                                mensajes.showSwal('error', 'Resultado', 'No se pudo eliminar el usuario.')
                                                }
                        };

                    }
                }
        //hasta aquí

        // if (confirm('Estás seguro de eliminar?')){
        // table.row(fila).remove().draw();
        // $(fila).fadeOut('slow');
        // mensajes.showSwa1('éxito');

        //}
    }
}
