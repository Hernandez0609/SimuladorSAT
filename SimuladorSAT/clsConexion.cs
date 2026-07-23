using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SimuladorSAT
{
    internal class clsConexion
    {
        // Cadena donde indica los datos con la que se conecta al sistema 
        private readonly string cadenaConexion = "server=localhost;port=3306;database=satcontaduria;user=root;password=''";

        // Método para conectar
        public MySqlConnection AbrirConexion()
        {
            var conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar a la base de datos: " + ex.Message, ex);
            }
        }
    }
}
