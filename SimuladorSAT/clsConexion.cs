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
        public int ObtenerIdCatalogo(string tabla, string columnaDescripcion, string valor)
        {
            using (var conexion = AbrirConexion())
            {
                string query = $"SELECT id FROM {tabla} WHERE {columnaDescripcion} = @valor LIMIT 1";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@valor", valor);
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
        }
        public bool ExisteDeclaracionPendiente(int ejercicio, int periodoId, int tipoDeclaracionId, int contribuyenteId, out int declaracionId)
        {
            declaracionId = 0;
            using (var conexion = AbrirConexion())
            {
                string query = @"SELECT id FROM declaraciones 
                          WHERE ejercicio = @ejercicio 
                          AND periodo_id = @periodoId 
                          AND tipo_declaracion_id = @tipoDeclaracionId 
                          AND contribuyente_id = @contribuyenteId 
                          AND concluida = 0 
                          LIMIT 1";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    cmd.Parameters.AddWithValue("@periodoId", periodoId);
                    cmd.Parameters.AddWithValue("@tipoDeclaracionId", tipoDeclaracionId);
                    cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null)
                    {
                        declaracionId = Convert.ToInt32(resultado);
                        return true;
                    }
                    return false;
                }
            }
        }
        public int InsertarDeclaracion(int contribuyenteId, int ejercicio, int periodicidadId, int periodoId, int tipoDeclaracionId,
                                        bool modIsrFisicas, bool modIsrSalarios, bool modIva)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"INSERT INTO declaraciones 
            (contribuyente_id, ejercicio, periodicidad_id, periodo_id, tipo_declaracion_id,
             modulo_isr_fisicas_seleccionado, modulo_isr_salarios_seleccionado, modulo_iva_seleccionado)
            VALUES (@contribuyenteId, @ejercicio, @periodicidadId, @periodoId, @tipoDeclaracionId,
             @modIsrFisicas, @modIsrSalarios, @modIva);
            SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);
                    cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    cmd.Parameters.AddWithValue("@periodicidadId", periodicidadId);
                    cmd.Parameters.AddWithValue("@periodoId", periodoId);
                    cmd.Parameters.AddWithValue("@tipoDeclaracionId", tipoDeclaracionId);
                    cmd.Parameters.AddWithValue("@modIsrFisicas", modIsrFisicas ? 1 : 0);
                    cmd.Parameters.AddWithValue("@modIsrSalarios", modIsrSalarios ? 1 : 0);
                    cmd.Parameters.AddWithValue("@modIva", modIva ? 1 : 0);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void EliminarDeclaracion(int declaracionId)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "DELETE FROM declaraciones WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public ModeloDeclaracion ObtenerDeclaracionPorId(int declaracionId)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"SELECT d.ejercicio, cp.descripcion AS periodicidad, cper.descripcion AS periodo, 
                                 ctd.descripcion AS tipo_declaracion,
                                 d.modulo_isr_fisicas_seleccionado, d.modulo_isr_salarios_seleccionado, d.modulo_iva_seleccionado,
                                 d.fecha_creacion, d.fecha_ultima_modificacion
                          FROM declaraciones d
                          JOIN cat_tipos_periodicidad cp ON cp.id = d.periodicidad_id
                          JOIN cat_tipos_periodos cper ON cper.id = d.periodo_id
                          JOIN cat_tipos_declaracion ctd ON ctd.id = d.tipo_declaracion_id
                          WHERE d.id = @id";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ModeloDeclaracion
                            {
                                Ejercicio = reader.GetInt32("ejercicio"),
                                Periocidad = reader.GetString("periodicidad"),
                                Periodo = reader.GetString("periodo"),
                                TipoDeclaracion = reader.GetString("tipo_declaracion"),
                                ModuloIsrFisicasSeleccionado = reader.GetBoolean("modulo_isr_fisicas_seleccionado"),
                                ModuloIsrSalariosSeleccionado = reader.GetBoolean("modulo_isr_salarios_seleccionado"),
                                ModuloIvaSimplificadoSeleccionado = reader.GetBoolean("modulo_iva_seleccionado"),
                                FechaCreacion = reader.GetDateTime("fecha_creacion"),
                                FechaUltimaModificacion = reader.GetDateTime("fecha_ultima_modificacion")
                            };
                        }
                    }
                }
            }
            return null;
        }
        public void ObtenerModulosCompletados(int ejercicio, int periodoId, int tipoDeclaracionNormalId, int contribuyenteId, out bool isrFisicas, out bool isrSalarios, out bool iva)
        {
            isrFisicas = false;
            isrSalarios = false;
            iva = false;

            using (var conexion = AbrirConexion())
            {
                string query = @"SELECT modulo_isr_fisicas_completado, modulo_isr_salarios_completado, modulo_iva_completado
                          FROM declaraciones
                          WHERE ejercicio = @ejercicio
                          AND periodo_id = @periodoId
                          AND tipo_declaracion_id = @tipoDeclaracionNormalId
                          AND contribuyente_id = @contribuyenteId
                          ORDER BY id DESC
                          LIMIT 1";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    cmd.Parameters.AddWithValue("@periodoId", periodoId);
                    cmd.Parameters.AddWithValue("@tipoDeclaracionNormalId", tipoDeclaracionNormalId);
                    cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isrFisicas = reader.GetBoolean("modulo_isr_fisicas_completado");
                            isrSalarios = reader.GetBoolean("modulo_isr_salarios_completado");
                            iva = reader.GetBoolean("modulo_iva_completado");
                        }
                    }
                }
            }
        }
        public void MarcarModuloCompletado(int declaracionId, string columnaModulo)
        {
            // Whitelist de columnas válidas — evita inyección SQL en el nombre de columna,
            // ya que los nombres de columna no se pueden parametrizar como los valores.
            var columnasValidas = new HashSet<string>
            {
              "modulo_isr_fisicas_completado",
              "modulo_isr_salarios_completado",
              "modulo_iva_completado"
            };

            if (!columnasValidas.Contains(columnaModulo))
                throw new ArgumentException("Columna de módulo no válida: " + columnaModulo);

            using (var conexion = AbrirConexion())
            {
                string query = $@"UPDATE declaraciones 
                           SET {columnaModulo} = 1, fecha_ultima_modificacion = NOW() 
                           WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<ModeloDeclaracion> ObtenerDeclaracionesPendientes(int contribuyenteId)
        {
            var lista = new List<ModeloDeclaracion>();

            using (var conexion = AbrirConexion())
            {
                string query = @"SELECT d.id, d.ejercicio, cp.descripcion AS periodicidad, cper.descripcion AS periodo,
                                 ctd.descripcion AS tipo_declaracion,
                                 d.modulo_isr_fisicas_seleccionado, d.modulo_isr_salarios_seleccionado, d.modulo_iva_seleccionado,
                                 d.modulo_isr_fisicas_completado, d.modulo_isr_salarios_completado, d.modulo_iva_completado,
                                 d.fecha_creacion, d.fecha_ultima_modificacion
                          FROM declaraciones d
                          JOIN cat_tipos_periodicidad cp ON cp.id = d.periodicidad_id
                          JOIN cat_tipos_periodos cper ON cper.id = d.periodo_id
                          JOIN cat_tipos_declaracion ctd ON ctd.id = d.tipo_declaracion_id
                          WHERE d.contribuyente_id = @contribuyenteId AND d.concluida = 0
                          ORDER BY d.fecha_ultima_modificacion DESC";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ModeloDeclaracion
                            {
                                Id = reader.GetInt32("id"),
                                Ejercicio = reader.GetInt32("ejercicio"),
                                Periocidad = reader.GetString("periodicidad"),
                                Periodo = reader.GetString("periodo"),
                                TipoDeclaracion = reader.GetString("tipo_declaracion"),
                                ModuloIsrFisicasSeleccionado = reader.GetBoolean("modulo_isr_fisicas_seleccionado"),
                                ModuloIsrSalariosSeleccionado = reader.GetBoolean("modulo_isr_salarios_seleccionado"),
                                ModuloIvaSimplificadoSeleccionado = reader.GetBoolean("modulo_iva_seleccionado"),
                                ModuloIsrFisicasCompletado = reader.GetBoolean("modulo_isr_fisicas_completado"),
                                ModuloIsrSalariosCompletado = reader.GetBoolean("modulo_isr_salarios_completado"),
                                ModuloIvaSimplificadoCompletado = reader.GetBoolean("modulo_iva_completado"),
                                FechaCreacion = reader.GetDateTime("fecha_creacion"),
                                FechaUltimaModificacion = reader.GetDateTime("fecha_ultima_modificacion"),
                                Concluida = false
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public void ActualizarFechaModificacion(int declaracionId)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "UPDATE declaraciones SET fecha_ultima_modificacion = NOW() WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string FinalizarDeclaracion(int declaracionId)
        {
            string folio = GenerarFolio();

            using (var conexion = AbrirConexion())
            {
                string query = @"UPDATE declaraciones 
                          SET concluida = 1, fecha_envio = NOW(), numero_operacion = @folio
                          WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    cmd.ExecuteNonQuery();
                }
            }

            return folio;
        }

        private string GenerarFolio()
        {
            // Folio numérico de 9 dígitos, similar al "Número de operación" real del SAT
            var rnd = new Random();
            return rnd.Next(100000000, 999999999).ToString();
        }

        public (string matricula, string nombre) ObtenerDatosContribuyente(int contribuyenteId)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT matricula, nombre FROM contribuyentes WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", contribuyenteId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader.GetString("matricula"), reader.GetString("nombre"));
                        }
                    }
                }
            }
            return ("", "");
        }
    }
}
