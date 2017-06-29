using carrentalweb.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace carrentalweb
//namespace ApiCarRental
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

        //List Usuario está mal
        public static List<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
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

        public static List<TipoCombustible> GetTiposCombustibles()
        {
            List<TipoCombustible> resultados = new List<TipoCombustible>();
            string procedimiento = "dbo.GET_TiposCombustible";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TipoCombustible tipo = new TipoCombustible();
                tipo.id = (long)reader["id"];
                tipo.denominacion = reader["denominacion"].ToString();
                resultados.Add(tipo);
            }


            return resultados;
        }

        // Está correcto abajo
        //public static List<Coche> GetCoches()
        //{
        //    List<Coche> resultado = new List<Coche>();

        //    // PREPARO EL PROCEDIMIENTO A EJECUTAR
        //    string procedimiento = "dbo.GetCoches";
        //    // PREPARO EL COMANDO PARA LA BD
        //    SqlCommand comando = new SqlCommand(procedimiento, conexion);
        //    // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
        //    comando.CommandType = CommandType.StoredProcedure;
        //    // EJECUTO EL COMANDO
        //    SqlDataReader reader = comando.ExecuteReader();
        //    // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
        //    while (reader.Read())
        //    {
        //        Coche coche = new Coche();
        //        coche.id = (long)reader["id"];
        //        coche.matricula = reader["matricula"].ToString();
        //        coche.color = reader["color"].ToString();
        //        coche.nPlazas = (int)reader["nPlazas"];
        //        coche.fechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
        //        coche.cilindrada = (Decimal)reader["cilindrada"];
        //        coche.marca = new Marca();
        //        coche.marca.denominacion = reader["Marca"].ToString();
        //        coche.tipoCombustible = new TipoCombustible();
        //        coche.tipoCombustible.denominacion = reader["Combustible"].ToString();
        //        // añadiro a la lista que voy
        //        // a devolver
        //        resultado.Add(coche);
        //    }

        //    return resultado;
        //}

        //Está correcto abajo
        //public static List<Coche> GetCochesPorId(long id)
        //{
        //    List<Coche> resultado = new List<Coche>();

        //    // PREPARO EL PROCEDIMIENTO A EJECUTAR
        //    string procedimiento = "dbo.GetCochesPorId";
        //    // PREPARO EL COMANDO PARA LA BD
        //    SqlCommand comando = new SqlCommand(procedimiento, conexion);
        //    // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.Add(new SqlParameter()
        //    {
        //        ParameterName = "id",
        //        SqlDbType = SqlDbType.BigInt,
        //        SqlValue = id
        //    });
        //    // EJECUTO EL COMANDO
        //    SqlDataReader reader = comando.ExecuteReader();
        //    // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
        //    while (reader.Read())
        //    {
        //        Coche coche = new Coche();
        //        coche.id = (long)reader["id"];
        //        coche.matricula = reader["matricula"].ToString();
        //        coche.color = reader["color"].ToString();
        //        coche.nPlazas = (short)reader["nPlazas"];
        //        coche.FechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
        //        coche.cilindrada = (Decimal)reader["cilindrada"];
        //        coche.marca = new Marca();
        //        coche.marca.denominacion = reader["Marca"].ToString();
        //        coche.tipoCombustible = new TipoCombustible();
        //        coche.tipoCombustible.denominacion = reader["Combustible"].ToString();
        //        // añadiro a la lista que voy
        //        // a devolver
        //        resultado.Add(coche);
        //    }

        //    return resultado;
        //}

        //public static int AgregarMarca(Marca marca)
        //{
        //    string procedimiento = "dbo.AgregarMarca";

        //    SqlCommand comando = new SqlCommand(procedimiento, conexion);
        //    comando.CommandType = CommandType.StoredProcedure;
        //    SqlParameter parametro = new SqlParameter();
        //    parametro.ParameterName = "denominacion";
        //    parametro.SqlDbType = SqlDbType.NVarChar;
        //    parametro.SqlValue = marca.denominacion;

        //    comando.Parameters.Add(parametro);
        //    int filasAfectadas = comando.ExecuteNonQuery();

        //    return filasAfectadas;
        //}

        //función hecha por el teacher
        //function eliminar(id, fila)
        //{

        //    if (confirm('Estás seguro de eliminar?'))
        //    { 

        //                $.ajax({
        //        url: '/api/usuarios/${id}',
        //                                    type: "DELETE",
        //                                    success: function(respuesta) {
        //                var table = $('#datatables').DataTable();
        //                table.row(fila).remove().draw();
        //                                        $(fila).fadeOut('slow');
        //                mensajes.showSwal('exito', 'Resultado', 'Usuario eliminado correctamente.')
        //                                                                 },
        //                                         error: function(respuesta) {
        //                mensajes.showSwal('error', 'Resultado', 'No se pudo eliminar el usuario.')
        //                                        )}
        //        };

        //    }
        //}
        //hasta aquí


        // if (confirm('Estás seguro de eliminar?')){
        // table.row(fila).remove().draw();
        // $(fila).fadeOut('slow');
        // mensajes.showSwa1('éxito');

        //}
    }

 
}
