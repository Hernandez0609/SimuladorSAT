using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace SimuladorSAT
{
    public class clsUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }

        // Cadena de conexión a MySQL (ajusta el usuario/contraseña si es necesario)
        private static readonly string CadenaConexion = "Server=localhost;Database=satcontaduria;Uid=root;Pwd=;";

        // Ruta en AppData para la persistencia local
        private static readonly string RutaCarpeta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SimuladorSAT_Datos"
        );
        private static readonly string RutaArchivo = Path.Combine(RutaCarpeta, "alumno.txt");

        public static bool ExisteRegistroLocal()
        {
            return File.Exists(RutaArchivo);
        }

        // Procesa el registro en la BD de MySQL y genera la copia local en disco
        public static bool RegistrarOObtener(string nombre, string matricula, out int idGenerado)
        {
            idGenerado = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CadenaConexion))
                {
                    conn.Open();

                    // 1. Verificar si la matrícula ya existe en la tabla contribuyentes
                    string sqlBuscar = "SELECT id FROM contribuyentes WHERE matricula = @matricula LIMIT 1";
                    using (MySqlCommand cmdBuscar = new MySqlCommand(sqlBuscar, conn))
                    {
                        cmdBuscar.Parameters.AddWithValue("@matricula", matricula);
                        object result = cmdBuscar.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            idGenerado = Convert.ToInt32(result);
                        }
                    }

                    // 2. Si no existe en la BD, la inserta
                    if (idGenerado == 0)
                    {
                        string sqlInsert = "INSERT INTO contribuyentes (matricula, nombre) VALUES (@matricula, @nombre); SELECT LAST_INSERT_ID();";
                        using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@matricula", matricula);
                            cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                            idGenerado = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        }
                    }
                }

                // 3. Crear carpeta y archivo local en AppData con (ID, Nombre, Matricula)
                if (!Directory.Exists(RutaCarpeta))
                {
                    Directory.CreateDirectory(RutaCarpeta);
                }

                string[] datos = { idGenerado.ToString(), nombre, matricula };
                File.WriteAllLines(RutaArchivo, datos);

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error de conexión a la BD: " + ex.Message, "Error MySQL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        // Carga los datos locales guardados previamente
        public static clsUsuario CargarLocal()
        {
            if (!ExisteRegistroLocal()) return null;

            string[] lineas = File.ReadAllLines(RutaArchivo);
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
    }
}