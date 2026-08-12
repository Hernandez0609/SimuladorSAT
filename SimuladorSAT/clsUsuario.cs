using System;
using System.IO;
using System.Data.SQLite;

namespace SimuladorSAT
{
    public class clsUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }

        private static readonly string RutaCarpeta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SimuladorSAT_Datos"
        );

        private static readonly string RutaArchivoTxt = Path.Combine(RutaCarpeta, "alumno.txt");
        private static readonly string RutaBD = Path.Combine(RutaCarpeta, "satcontaduria.db");

        // Ruta de la base de datos original que viene con el ejecutable
        private static readonly string RutaBDSemilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "satcontaduria.db");

        private static readonly string CadenaConexion = $"Data Source={RutaBD};Version=3;";

        public static bool ExisteRegistroLocal()
        {
            return File.Exists(RutaArchivoTxt);
        }

        public static void InicializarBaseDatos()
        {
            if (!Directory.Exists(RutaCarpeta))
            {
                Directory.CreateDirectory(RutaCarpeta);
            }

            // Si no existe la BD en AppData del usuario, copiamos el archivo completo que viene con el programa
            if (!File.Exists(RutaBD))
            {
                if (File.Exists(RutaBDSemilla))
                {
                    File.Copy(RutaBDSemilla, RutaBD, true);
                }
                else
                {
                    throw new FileNotFoundException("No se encontró el archivo base de la base de datos 'satcontaduria.db' en la carpeta del ejecutable.");
                }
            }
        }

        public static bool RegistrarOObtener(string nombre, string matricula, out int idGenerado)
        {
            idGenerado = 0;
            try
            {
                InicializarBaseDatos();

                using (SQLiteConnection conn = new SQLiteConnection(CadenaConexion))
                {
                    conn.Open();

                    string sqlBuscar = "SELECT id FROM contribuyentes WHERE matricula = @matricula LIMIT 1;";
                    using (SQLiteCommand cmdBuscar = new SQLiteCommand(sqlBuscar, conn))
                    {
                        cmdBuscar.Parameters.AddWithValue("@matricula", matricula);
                        object result = cmdBuscar.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            idGenerado = Convert.ToInt32(result);
                        }
                    }

                    if (idGenerado == 0)
                    {
                        string sqlInsert = "INSERT INTO contribuyentes (matricula, nombre) VALUES (@matricula, @nombre); SELECT last_insert_rowid();";
                        using (SQLiteCommand cmdInsert = new SQLiteCommand(sqlInsert, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@matricula", matricula);
                            cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                            idGenerado = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        }
                    }
                }

                string[] datos = { idGenerado.ToString(), nombre, matricula };
                File.WriteAllLines(RutaArchivoTxt, datos);

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al conectar con la base de datos local: " + ex.Message, "Error SQLite", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static clsUsuario CargarLocal()
        {
            if (!ExisteRegistroLocal()) return null;

            string[] lineas = File.ReadAllLines(RutaArchivoTxt);
            if (lineas.Length >= 3)
            {
                return new clsUsuario
                {
                    Id = int.Parse(lineas[0]),
                    Nombre = lineas[1],
                    Matricula = lineas[2]
                };
            }
            return null;
        }

        // Devuelve la cadena formateada "RFC: MATRICULA | NOMBRE" para usar en los encabezados
        public static string ObtenerTextoEncabezado()
        {
            var usuario = Program.usuarioActual;
            if (usuario != null)
            {
                return $"RFC: {usuario.Matricula.ToUpper()} | {usuario.Nombre.ToUpper()}";
            }
            return "RFC: XXXXXXXXX | ALUMNO NO REGISTRADO";
        }
    }
}