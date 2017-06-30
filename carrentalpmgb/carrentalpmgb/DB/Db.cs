using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarRentelWeb
{
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                //string cadenaConexion = @"Server=.\sqlexpress;
                //                          Database=carrental;
                //                          User Id=testuser;
                //                          Password=!Curso@2017;";

                // string cadenaConexion = @"Server=carmencgserver.database.windows.net;Database=PedroMGB2;User Id=testuser;Password=!Curso@2017;";
                //string cadenaConexion = ConfigurationManager.ConnectionStrings["Miconexion"].ConnectionString;

                // CONEXIÓN CON AZURE
                //string cadenaConexion = @"Server=carmencgserver.database.windows.net;
                //                          Database=PedroMGB2;
                //                          User Id=testuser;
                //                          Password=!Curso@2017;";
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Miconexion"].ConnectionString;

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
            if (conexion !=null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

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
                    password= reader["password"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    apellidos = reader["apellidos"].ToString(),
                    nif = reader["nif"].ToString(),
                    fechaNacimiento = (DateTime)reader["fechaNacimiento"]
                });
            }

            // DEVUELVO LOS DATOS
            return usuarios;
        }

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = null;
            // PREPARO LA CONSULTA SQL PARA OBTENER LOS USUARIOS
            string consultaSQL = "dbo.GetUsuarios";
            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            // RECOJO LOS DATOS
            SqlDataReader reader = comando.ExecuteReader();
            usuarios = new List<Usuario>();

            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    idUsuario = int.Parse(reader["idUsuario"].ToString()),
                    email = reader["email"].ToString(),
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

        //public static void ActualizarUsuario(Usuario usuario)
        //{
        //    // PREPARO LA CONSULTA SQL PARA INSERTAR AL NUEVO USUARIO
        //    string consultaSQL = @"UPDATE Users ";
        //    consultaSQL += "   SET password = '" + usuario.password +"'";
        //    consultaSQL += "      , firstName = '" + usuario.firstName +"'";
        //    consultaSQL += "      , lastName = '" + usuario.lastName +"'";
        //    consultaSQL += "      , photoUrl = '" + usuario.photoUrl +"'";
        //    consultaSQL += "      , searchPreferences = '" + usuario.searchPreferences +"'";
        //    consultaSQL += "      , status = " + (usuario.status ? "1" : "0");
        //    consultaSQL += "      , deleted = " + (usuario.deleted ? "1" : "0");
        //    consultaSQL += "      , isAdmin = " + (usuario.isAdmin ? "1" : "0");
        //    consultaSQL += " WHERE email = '" + usuario.email + "';";

        //    // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
        //    SqlCommand comando = new SqlCommand(consultaSQL, conexion);
        //    // EJECUTO EL COMANDO
        //    comando.ExecuteNonQuery();
        //}

        public static List<Marca> GetMarcas()
        {
            List<Marca> resultado = new List<Marca>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetMarcas";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Marca marca = new Marca();
                marca.id = (long)reader["id"];
                marca.denominacion = reader["denominacion"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(marca);
            }

            return resultado;
        }

        public static List<Marca> GetMarcasPorId(long id)
        {
            List<Marca> resultado = new List<Marca>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetMarcasPorId";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "id";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Marca marca = new Marca();
                marca.id = (long)reader["id"];
                marca.denominacion = reader["denominacion"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(marca);
            }

            return resultado;
        }

        public static List<TipoCombustible> GetTiposCombustibles()
        {
            List<TipoCombustible> resultados = new List<TipoCombustible>();
            string procedimiento = "dbo.GetTiposCombustibles";

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

        public static int AgregarMarca(Marca marca)
        {
            string procedimiento = "dbo.AgregarMarca";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = marca.denominacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarMarca(long id)
        {
            string procedimiento = "dbo.EliminarMarca";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "id";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int ActualizarMarca(long id, Marca marca)
        {
            string procedimiento = "dbo.ActualizarMarca";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "id";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;
            comando.Parameters.Add(parametro);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = marca.denominacion;
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarMarca(int idMarca)
        {
            // PREPARO LA CONSULTA SQL PARA INSERTAR AL NUEVO USUARIO
            string consultaSQL = "dbo.EliminarMarca";
            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "id",
                Value = idMarca,
                SqlDbType = SqlDbType.Int
            });
            // EJECUTO EL COMANDO
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static List<Coche> GetCoches()
        {
            List<Coche> resultado = new List<Coche>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetCoches";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Coche coche = new Coche();
                coche.id = (long)reader["id"];
                coche.matricula = reader["matricula"].ToString();
                coche.color = reader["color"].ToString();
                coche.nPlazas = (short)reader["nPlazas"];
                coche.fechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
                coche.cilindrada = (Decimal)reader["cilindrada"];
                coche.marca = new Marca();
                coche.marca.denominacion = reader["Marca"].ToString();
                coche.tipoCombustible = new TipoCombustible();
                coche.tipoCombustible.denominacion = reader["Combustible"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(coche);
            }

            return resultado;
        }

        public static List<Coche> GetCochesPorId(long id)
        {
            List<Coche> resultado = new List<Coche>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetCochesPorId";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.BigInt,
                SqlValue = id
            });
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Coche coche = new Coche();
                coche.id = (long)reader["id"];
                coche.matricula = reader["matricula"].ToString();
                coche.color = reader["color"].ToString();
                coche.nPlazas = (short)reader["nPlazas"];
                coche.fechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
                coche.cilindrada = (Decimal)reader["cilindrada"];
                coche.marca = new Marca();
                coche.marca.denominacion = reader["Marca"].ToString();
                coche.tipoCombustible = new TipoCombustible();
                coche.tipoCombustible.denominacion = reader["Combustible"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(coche);
            }

            return resultado;
        }

        public static int AgregarCoche(Coche coche)
        {
            string procedimiento = "dbo.AgregarCoche";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "matricula",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = coche.matricula
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idMarca",
                SqlDbType = SqlDbType.BigInt,
                SqlValue = coche.marca.id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "idTipoCombustible",
                SqlDbType = SqlDbType.BigInt,
                SqlValue = coche.tipoCombustible.id
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "color",
                SqlDbType = SqlDbType.NVarChar,
                SqlValue = coche.color
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "cilindrada",
                SqlDbType = SqlDbType.Decimal,
                SqlValue = coche.cilindrada
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "nPlazas",
                SqlDbType = SqlDbType.SmallInt,
                SqlValue = coche.nPlazas
            });
            comando.Parameters.Add(new SqlParameter()
            {
                ParameterName = "fechaMatriculacion",
                SqlDbType = SqlDbType.Date,
                SqlValue = coche.fechaMatriculacion
            }); 

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

    }
}
