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
                string query = @"SELECT d.contribuyente_id, d.ejercicio, cp.descripcion AS periodicidad, cper.descripcion AS periodo, 
                 ctd.descripcion AS tipo_declaracion,
                 d.modulo_isr_fisicas_seleccionado, d.modulo_isr_salarios_seleccionado, d.modulo_iva_seleccionado,
                 d.modulo_isr_fisicas_completado, d.modulo_isr_salarios_completado, d.modulo_iva_completado,
                 d.monto_isr_fisicas, d.monto_isr_salarios, d.monto_iva,
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
                                FechaUltimaModificacion = reader.GetDateTime("fecha_ultima_modificacion"),
                                ContribuyenteId = reader.GetInt32("contribuyente_id"),
                                ModuloIsrFisicasCompletado = reader.GetBoolean("modulo_isr_fisicas_completado"),
                                ModuloIsrSalariosCompletado = reader.GetBoolean("modulo_isr_salarios_completado"),
                                ModuloIvaSimplificadoCompletado = reader.GetBoolean("modulo_iva_completado"),
                                MontoIsrFisicas = reader.GetDecimal("monto_isr_fisicas"),
                                MontoIsrSalarios = reader.GetDecimal("monto_isr_salarios"),
                                MontoIva = reader.GetDecimal("monto_iva"),
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
                string query = @"SELECT d.id, d.contribuyente_id, d.ejercicio, cp.descripcion AS periodicidad, cper.descripcion AS periodo,
                             ctd.descripcion AS tipo_declaracion,
                             d.modulo_isr_fisicas_seleccionado, d.modulo_isr_salarios_seleccionado, d.modulo_iva_seleccionado,
                             d.modulo_isr_fisicas_completado, d.modulo_isr_salarios_completado, d.modulo_iva_completado,
                             d.monto_isr_fisicas, d.monto_isr_salarios, d.monto_iva,
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
                                ContribuyenteId = reader.GetInt32("contribuyente_id"),
                                MontoIsrFisicas = reader.GetDecimal("monto_isr_fisicas"),
                                MontoIsrSalarios = reader.GetDecimal("monto_isr_salarios"),
                                MontoIva = reader.GetDecimal("monto_iva"),
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
        public void GuardarIsrFisicas(int declaracionId, int contribuyenteId, int periodoMes, int periodoAnio, int tipoDeclaracionId, ModeloIsrPersonasFisicas modelo)
        {
            int ingresosIsrId;
            using (var conexion = AbrirConexion())
            {
                int idExistente = ObtenerIdModulo(conexion, "ingresos_isr", declaracionId);

                if (idExistente > 0)
                {
                    ingresosIsrId = idExistente;
                    string queryUpdate = @"UPDATE ingresos_isr SET
                total_ingresos_cobrados = @totalIngresosCobrados,
                descuentos_devoluciones_bonificaciones = @descuentos,
                ingresos_a_disminuir = @ingresosADisminuir,
                ingresos_adicionales = @ingresosAdicionales,
                total_ingresos_percibidos = @totalIngresosPercibidos,
                tasa_aplicable = @tasaAplicable,
                impuesto_mensual = @impuestoMensual,
                isr_retenido_pm = @isrRetenidoPm,
                impuesto_a_cargo = @impuestoACargo,
                subsidio_empleo = @subsidioEmpleo,
                compensaciones_aplicadas = @compensaciones,
                estimulos_aplicados = @estimulos
                WHERE id = @id";
                    using (var cmd = new MySqlCommand(queryUpdate, conexion))
                    {
                        AgregarParametrosIsrFisicas(cmd, modelo);
                        cmd.Parameters.AddWithValue("@id", idExistente);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string queryInsert = @"INSERT INTO ingresos_isr
                (declaracion_id, contribuyente_id, periodo_mes, periodo_anio, tipo_declaracion_id,
                 total_ingresos_cobrados, descuentos_devoluciones_bonificaciones, ingresos_a_disminuir,
                 ingresos_adicionales, total_ingresos_percibidos, tasa_aplicable, impuesto_mensual,
                 isr_retenido_pm, impuesto_a_cargo, subsidio_empleo, compensaciones_aplicadas, estimulos_aplicados)
                VALUES
                (@declaracionId, @contribuyenteId, @periodoMes, @periodoAnio, @tipoDeclaracionId,
                 @totalIngresosCobrados, @descuentos, @ingresosADisminuir,
                 @ingresosAdicionales, @totalIngresosPercibidos, @tasaAplicable, @impuestoMensual,
                 @isrRetenidoPm, @impuestoACargo, @subsidioEmpleo, @compensaciones, @estimulos);
                SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(queryInsert, conexion))
                    {
                        cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                        cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);
                        cmd.Parameters.AddWithValue("@periodoMes", periodoMes);
                        cmd.Parameters.AddWithValue("@periodoAnio", periodoAnio);
                        cmd.Parameters.AddWithValue("@tipoDeclaracionId", tipoDeclaracionId);
                        AgregarParametrosIsrFisicas(cmd, modelo);
                        ingresosIsrId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }

            // Guarda las 3 listas de detalle contra el id real de ingresos_isr
            GuardarDetalleIngresos("ingresos_detalles_cobrados", ingresosIsrId, modelo.ListaTotalPercibidosDetalle);
            GuardarDetalleIngresos("ingresos_detalles_disminuir", ingresosIsrId, modelo.ListaIngresosADisminuir);
            GuardarDetalleIngresos("ingresos_adicionales", ingresosIsrId, modelo.ListaIngresosAdicionales);
        }

        private void AgregarParametrosIsrFisicas(MySqlCommand cmd, ModeloIsrPersonasFisicas modelo)
        {
            cmd.Parameters.AddWithValue("@totalIngresosCobrados", modelo.TotalIngresosCobrados);
            cmd.Parameters.AddWithValue("@descuentos", modelo.Descuentos);
            cmd.Parameters.AddWithValue("@ingresosADisminuir", modelo.IngresosADisminuir);
            cmd.Parameters.AddWithValue("@ingresosAdicionales", modelo.IngresosAdicionales);
            cmd.Parameters.AddWithValue("@totalIngresosPercibidos", modelo.TotalIngresosPercibidos);
            cmd.Parameters.AddWithValue("@tasaAplicable", modelo.TasaAplicable);
            cmd.Parameters.AddWithValue("@impuestoMensual", modelo.ImpuestoMensual);
            cmd.Parameters.AddWithValue("@isrRetenidoPm", modelo.IsrRetenidoPersonasMorales);
            cmd.Parameters.AddWithValue("@impuestoACargo", modelo.ImpuestoACargo);
            cmd.Parameters.AddWithValue("@subsidioEmpleo", modelo.SubsidioParaElEmpleo);
            cmd.Parameters.AddWithValue("@compensaciones", modelo.Compensaciones);
            cmd.Parameters.AddWithValue("@estimulos", modelo.Estimulos);
        }

        public void GuardarIva(int declaracionId, int contribuyenteId, int periodoMes, int periodoAnio, int tipoDeclaracionId, ModeloIva modelo)
        {
            using (var conexion = AbrirConexion())
            {
                int idExistente = ObtenerIdModulo(conexion, "iva_simplificado", declaracionId);

                if (idExistente > 0)
                {
                    string queryUpdate = @"UPDATE iva_simplificado SET
                actividades_16 = @actividades16,
                actividades_0 = @actividades0,
                actividades_exentas = @actividadesExentas,
                actividades_no_objeto = @actividadesNoObjeto,
                iva_devoluciones_ventas = @ivaDevolucionesVentas,
                iva_retenido = @ivaRetenido,
                iva_acreditable = @ivaAcreditable,
                iva_devoluciones_gastos = @ivaDevolucionesGastos,
                saldo_favor_anterior = @saldoFavorAnterior,
                compensaciones_aplicadas = @compensaciones,
                estimulos_aplicados = @estimulos
                WHERE id = @id";
                    using (var cmd = new MySqlCommand(queryUpdate, conexion))
                    {
                        AgregarParametrosIva(cmd, modelo);
                        cmd.Parameters.AddWithValue("@id", idExistente);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string queryInsert = @"INSERT INTO iva_simplificado
                (declaracion_id, contribuyente_id, periodo_mes, periodo_anio, tipo_declaracion_id,
                 actividades_16, actividades_0, actividades_exentas, actividades_no_objeto,
                 iva_devoluciones_ventas, iva_retenido, iva_acreditable, iva_devoluciones_gastos,
                 saldo_favor_anterior, compensaciones_aplicadas, estimulos_aplicados)
                VALUES
                (@declaracionId, @contribuyenteId, @periodoMes, @periodoAnio, @tipoDeclaracionId,
                 @actividades16, @actividades0, @actividadesExentas, @actividadesNoObjeto,
                 @ivaDevolucionesVentas, @ivaRetenido, @ivaAcreditable, @ivaDevolucionesGastos,
                 @saldoFavorAnterior, @compensaciones, @estimulos)";
                    using (var cmd = new MySqlCommand(queryInsert, conexion))
                    {
                        cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                        cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);
                        cmd.Parameters.AddWithValue("@periodoMes", periodoMes);
                        cmd.Parameters.AddWithValue("@periodoAnio", periodoAnio);
                        cmd.Parameters.AddWithValue("@tipoDeclaracionId", tipoDeclaracionId);
                        AgregarParametrosIva(cmd, modelo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void AgregarParametrosIva(MySqlCommand cmd, ModeloIva modelo)
        {
            cmd.Parameters.AddWithValue("@actividades16", modelo.ActividadesGravadas16);
            cmd.Parameters.AddWithValue("@actividades0", modelo.ActividadesGravadas0);
            cmd.Parameters.AddWithValue("@actividadesExentas", modelo.ActividadesExentas);
            cmd.Parameters.AddWithValue("@actividadesNoObjeto", modelo.ActividadesNoObjeto);
            cmd.Parameters.AddWithValue("@ivaDevolucionesVentas", modelo.IvaNoCobradoDevoluciones);
            cmd.Parameters.AddWithValue("@ivaRetenido", modelo.IvaRetenido);
            cmd.Parameters.AddWithValue("@ivaAcreditable", modelo.IvaAcreditablePeriodo);
            cmd.Parameters.AddWithValue("@ivaDevolucionesGastos", modelo.IvaPorDevolucionesGastos);
            cmd.Parameters.AddWithValue("@saldoFavorAnterior", modelo.AcreditamientoSaldoFavorAnterior);
            cmd.Parameters.AddWithValue("@compensaciones", modelo.Compensaciones);
            cmd.Parameters.AddWithValue("@estimulos", modelo.Estimulos);
        }

        public void GuardarIsrSalarios(int declaracionId, int contribuyenteId, int periodoMes, int periodoAnio, int tipoDeclaracionId, ModeloIsrRetencionesSalarios modelo)
        {
            using (var conexion = AbrirConexion())
            {
                int idExistente = ObtenerIdModulo(conexion, "declaraciones_retenciones_salarios", declaracionId);

                if (idExistente > 0)
                {
                    string queryUpdate = @"UPDATE declaraciones_retenciones_salarios SET
                cant_trabajadores = @cantTrabajadores,
                total_sueldos_pagados = @totalSueldosPagados,
                total_sueldos_exentos = @totalSueldosExentos,
                isr_retenido_sat = @isrRetenidoSat,
                isr_retenido_contribuyente = @isrRetenidoContribuyente,
                subsidio_empleo = @subsidioEmpleo,
                estimulos_aplicados = @estimulos
                WHERE id = @id";
                    using (var cmd = new MySqlCommand(queryUpdate, conexion))
                    {
                        AgregarParametrosIsrSalarios(cmd, modelo);
                        cmd.Parameters.AddWithValue("@id", idExistente);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string queryInsert = @"INSERT INTO declaraciones_retenciones_salarios
                (declaracion_id, contribuyente_id, periodo_mes, periodo_anio, tipo_declaracion_id,
                 cant_trabajadores, total_sueldos_pagados, total_sueldos_exentos,
                 isr_retenido_sat, isr_retenido_contribuyente, subsidio_empleo, estimulos_aplicados)
                VALUES
                (@declaracionId, @contribuyenteId, @periodoMes, @periodoAnio, @tipoDeclaracionId,
                 @cantTrabajadores, @totalSueldosPagados, @totalSueldosExentos,
                 @isrRetenidoSat, @isrRetenidoContribuyente, @subsidioEmpleo, @estimulos)";
                    using (var cmd = new MySqlCommand(queryInsert, conexion))
                    {
                        cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                        cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);
                        cmd.Parameters.AddWithValue("@periodoMes", periodoMes);
                        cmd.Parameters.AddWithValue("@periodoAnio", periodoAnio);
                        cmd.Parameters.AddWithValue("@tipoDeclaracionId", tipoDeclaracionId);
                        AgregarParametrosIsrSalarios(cmd, modelo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void AgregarParametrosIsrSalarios(MySqlCommand cmd, ModeloIsrRetencionesSalarios modelo)
        {
            cmd.Parameters.AddWithValue("@cantTrabajadores", modelo.NumeroTrabajadores);
            cmd.Parameters.AddWithValue("@totalSueldosPagados", modelo.PagoSueldos);
            cmd.Parameters.AddWithValue("@totalSueldosExentos", modelo.PagosExentos);
            cmd.Parameters.AddWithValue("@isrRetenidoSat", modelo.IsrRetenidoSueldos);
            cmd.Parameters.AddWithValue("@isrRetenidoContribuyente", modelo.IsrRetenidoRegistroContribuyente);
            cmd.Parameters.AddWithValue("@subsidioEmpleo", modelo.SubsidioParaElEmpleo);
            cmd.Parameters.AddWithValue("@estimulos", modelo.Estimulos);
        }

        // Helper compartido por los 3 métodos de guardado — busca si ya existe fila para esta declaración
        private int ObtenerIdModulo(MySqlConnection conexion, string tabla, int declaracionId)
        {
            var tablasValidas = new HashSet<string> { "ingresos_isr", "iva_simplificado", "declaraciones_retenciones_salarios" };
            if (!tablasValidas.Contains(tabla))
                throw new ArgumentException("Tabla de módulo no válida: " + tabla);

            string query = $"SELECT id FROM {tabla} WHERE declaracion_id = @declaracionId LIMIT 1";
            using (var cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
        }

        // Guarda los 3 módulos de un jalón — úsalo en Guardar, Administración de la declaración, Inicio y Cerrar
        public void GuardarTodosLosModulos(ModeloDeclaracion declaracion)
        {
            if (declaracion == null || declaracion.Id <= 0) return;
            int periodoMes = ObtenerNumeroMes(declaracion.Periodo);
            int tipoDeclaracionId = ObtenerIdCatalogo("cat_tipos_declaracion", "descripcion", declaracion.TipoDeclaracion);

            if (Program.modeloIsrFisicas != null)
                GuardarIsrFisicas(declaracion.Id, declaracion.ContribuyenteId, periodoMes, declaracion.Ejercicio, tipoDeclaracionId, Program.modeloIsrFisicas);

            if (Program.modeloIsrSalarios != null)
                GuardarIsrSalarios(declaracion.Id, declaracion.ContribuyenteId, periodoMes, declaracion.Ejercicio, tipoDeclaracionId, Program.modeloIsrSalarios);

            if (Program.modeloIva != null)
                GuardarIva(declaracion.Id, declaracion.ContribuyenteId, periodoMes, declaracion.Ejercicio, tipoDeclaracionId, Program.modeloIva);

            ActualizarFechaModificacion(declaracion.Id);
        }
        // Convierte "Enero".."Diciembre" a 1-12. Reutiliza la misma lista que ModeloDeclaracion.CalcularVencimiento()
        public int ObtenerNumeroMes(string nombreMes)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                               "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            int indice = Array.IndexOf(meses, nombreMes);
            if (indice == -1)
                throw new ArgumentException("Nombre de mes no reconocido: " + nombreMes);
            return indice + 1;
        }



        // ====================================================================
        // CARGA INVERSA — repuebla los 3 modelos en memoria desde la BD
        // ====================================================================
        public void CargarModulosEnMemoria(int declaracionId)
        {
            CargarIsrFisicas(declaracionId);
            CargarIva(declaracionId);
            CargarIsrSalarios(declaracionId);
        }

        private void CargarIsrFisicas(int declaracionId)
        {
            var m = new ModeloIsrPersonasFisicas();
            int ingresosIsrId = 0;
            using (var conexion = AbrirConexion())
            {
                ingresosIsrId = ObtenerIdModulo(conexion, "ingresos_isr", declaracionId);
                string query = "SELECT * FROM ingresos_isr WHERE declaracion_id = @declaracionId LIMIT 1";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.TotalIngresosCobrados = reader.GetDecimal("total_ingresos_cobrados");
                            m.Descuentos = reader.GetDecimal("descuentos_devoluciones_bonificaciones");
                            m.DescuentosCapturado = m.Descuentos != 0;
                            m.IngresosADisminuir = reader.GetDecimal("ingresos_a_disminuir");
                            m.TieneIngresosADisminuir = m.IngresosADisminuir != 0;
                            m.IngresosADisminuirCapturado = m.TieneIngresosADisminuir;
                            m.IngresosAdicionales = reader.GetDecimal("ingresos_adicionales");
                            m.TieneIngresosAdicionales = m.IngresosAdicionales != 0;
                            m.IngresosAdicionalesCapturado = m.TieneIngresosAdicionales;
                            m.TotalIngresosPercibidos = reader.GetDecimal("total_ingresos_percibidos");
                            m.TotalPercibidosCapturado = m.TotalIngresosPercibidos != 0;
                            m.TasaAplicable = reader.GetDecimal("tasa_aplicable");
                            m.ImpuestoMensual = reader.GetDecimal("impuesto_mensual");
                            m.IsrRetenidoPersonasMorales = reader.GetDecimal("isr_retenido_pm");
                            m.IsrRetenidoCapturado = m.IsrRetenidoPersonasMorales != 0;
                            m.ImpuestoACargo = reader.GetDecimal("impuesto_a_cargo");
                            m.DeterminacionCompleta = m.IsrRetenidoCapturado;
                            m.SubsidioParaElEmpleo = reader.GetDecimal("subsidio_empleo");
                            m.Compensaciones = reader.GetDecimal("compensaciones_aplicadas");
                            m.TieneCompensaciones = m.Compensaciones != 0;
                            m.CompensacionesCapturado = m.TieneCompensaciones;
                            m.Estimulos = reader.GetDecimal("estimulos_aplicados");
                            m.TieneEstimulos = m.Estimulos != 0;
                            m.EstimulosCapturado = m.TieneEstimulos;
                            m.CantidadAPagar = m.ImpuestoACargo - m.SubsidioParaElEmpleo - m.Compensaciones - m.Estimulos;
                            if (m.CantidadAPagar < 0) m.CantidadAPagar = 0;
                        }
                    }
                }
            }
            if (ingresosIsrId > 0)   
            {
                m.ListaTotalPercibidosDetalle = CargarDetalleIngresos("ingresos_detalles_cobrados", ingresosIsrId);
                m.ListaIngresosADisminuir = CargarDetalleIngresos("ingresos_detalles_disminuir", ingresosIsrId);
                m.ListaIngresosAdicionales = CargarDetalleIngresos("ingresos_adicionales", ingresosIsrId);
            }
            Program.modeloIsrFisicas = m;
        }

        private void CargarIva(int declaracionId)
        {
            var m = new ModeloIva();
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT * FROM iva_simplificado WHERE declaracion_id = @declaracionId LIMIT 1";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.ActividadesGravadas16 = reader.GetDecimal("actividades_16");
                            m.ActividadesGravadas0 = reader.GetDecimal("actividades_0");
                            m.ActividadesGravadas0Capturado = m.ActividadesGravadas0 != 0;
                            m.ActividadesExentas = reader.GetDecimal("actividades_exentas");
                            m.ActividadesNoObjeto = reader.GetDecimal("actividades_no_objeto");
                            m.IvaNoCobradoDevoluciones = reader.GetDecimal("iva_devoluciones_ventas");
                            m.IvaRetenido = reader.GetDecimal("iva_retenido");
                            m.IvaAcreditablePeriodo = reader.GetDecimal("iva_acreditable");
                            m.IvaAcreditablePeriodoCapturado = m.IvaAcreditablePeriodo != 0;
                            m.IvaPorDevolucionesGastos = reader.GetDecimal("iva_devoluciones_gastos");
                            m.AcreditamientoSaldoFavorAnterior = reader.GetDecimal("saldo_favor_anterior");
                            m.Compensaciones = reader.GetDecimal("compensaciones_aplicadas");
                            m.TieneCompensaciones = m.Compensaciones != 0;
                            m.Estimulos = reader.GetDecimal("estimulos_aplicados");
                            m.TieneEstimulos = m.Estimulos != 0;

                            // Recalcula lo derivado con la misma fórmula que usa fmResico
                            m.IvaACargo16 = Math.Round(m.ActividadesGravadas16 * 0.16m, 2);
                            m.TotalIvaACargo = m.IvaACargo16;
                            decimal cantidadCargoCruda = m.TotalIvaACargo - m.IvaNoCobradoDevoluciones
                                - m.IvaRetenido - m.IvaAcreditablePeriodo + m.IvaPorDevolucionesGastos;

                            if (cantidadCargoCruda >= 0)
                            {
                                m.EsImpuestoAFavor = false;
                                m.CantidadACargo = cantidadCargoCruda;
                                m.ImpuestoFinal = cantidadCargoCruda - m.AcreditamientoSaldoFavorAnterior;
                                if (m.ImpuestoFinal < 0) m.ImpuestoFinal = 0;
                            }
                            else
                            {
                                m.EsImpuestoAFavor = true;
                                m.ImpuestoFinal = Math.Abs(cantidadCargoCruda);
                            }

                            m.DeterminacionCompleta = m.ActividadesGravadas0Capturado && m.IvaAcreditablePeriodoCapturado;

                            decimal totalAplic = m.TieneCompensaciones ? m.Compensaciones : 0;
                            totalAplic += m.TieneEstimulos ? m.Estimulos : 0;
                            m.TotalAplicaciones = totalAplic;
                            m.CantidadACargoPago = m.EsImpuestoAFavor ? 0 : Math.Max(0, m.ImpuestoFinal - totalAplic);
                            m.CantidadAPagar = m.CantidadACargoPago;
                        }
                    }
                }
            }
            Program.modeloIva = m;
        }

        private void CargarIsrSalarios(int declaracionId)
        {
            var m = new ModeloIsrRetencionesSalarios();
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT * FROM declaraciones_retenciones_salarios WHERE declaracion_id = @declaracionId LIMIT 1";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.NumeroTrabajadores = reader.GetInt32("cant_trabajadores");
                            m.PagoSueldos = reader.GetDecimal("total_sueldos_pagados");
                            m.PagosExentos = reader.GetDecimal("total_sueldos_exentos");
                            m.IsrRetenidoSueldos = reader.GetDecimal("isr_retenido_sat");
                            m.IsrRetenidoRegistroContribuyente = reader.GetDecimal("isr_retenido_contribuyente");
                            m.IsrRetenidoRegistroCapturado = m.IsrRetenidoRegistroContribuyente != 0;
                            m.ImpuestoACargo = m.IsrRetenidoRegistroContribuyente;
                            m.DeterminacionCompleta = m.IsrRetenidoRegistroCapturado;
                            m.SubsidioParaElEmpleo = reader.GetDecimal("subsidio_empleo");
                            m.Estimulos = reader.GetDecimal("estimulos_aplicados");
                            m.TieneEstimulos = m.Estimulos != 0;
                            m.TotalAplicaciones = m.SubsidioParaElEmpleo;
                            m.CantidadACargo = Math.Max(0, m.ImpuestoACargo - m.TotalAplicaciones);
                            m.CantidadAPagar = m.CantidadACargo;
                        }
                    }
                }
            }
            Program.modeloIsrSalarios = m;
        }

        // Guarda los montos finales por módulo directamente en declaraciones (para el Total a pagar de Administración)
        public void GuardarMontosDeclaracion(int declaracionId, decimal montoIsrFisicas, decimal montoIsrSalarios, decimal montoIva)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"UPDATE declaraciones SET
            monto_isr_fisicas = @montoIsrFisicas,
            monto_isr_salarios = @montoIsrSalarios,
            monto_iva = @montoIva
            WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@montoIsrFisicas", montoIsrFisicas);
                    cmd.Parameters.AddWithValue("@montoIsrSalarios", montoIsrSalarios);
                    cmd.Parameters.AddWithValue("@montoIva", montoIva);
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Guarda una lista de renglones (concepto/importe) en una tabla de detalle de ingresos.
        // Borra todo lo existente para ese ingresos_isr_id y vuelve a insertar (más simple y confiable que hacer diff).
        public void GuardarDetalleIngresos(string tabla, int ingresosIsrId, List<(string Concepto, decimal Importe)> lista)
        {
            var tablasValidas = new HashSet<string> { "ingresos_adicionales", "ingresos_detalles_disminuir", "ingresos_detalles_cobrados" };
            if (!tablasValidas.Contains(tabla))
                throw new ArgumentException("Tabla de detalle no válida: " + tabla);

            using (var conexion = AbrirConexion())
            {
                string queryDelete = $"DELETE FROM {tabla} WHERE ingresos_isr_id = @ingresosIsrId";
                using (var cmdDelete = new MySqlCommand(queryDelete, conexion))
                {
                    cmdDelete.Parameters.AddWithValue("@ingresosIsrId", ingresosIsrId);
                    cmdDelete.ExecuteNonQuery();
                }

                foreach (var renglon in lista)
                {
                    string queryInsert = $"INSERT INTO {tabla} (ingresos_isr_id, concepto, importe) VALUES (@ingresosIsrId, @concepto, @importe)";
                    using (var cmdInsert = new MySqlCommand(queryInsert, conexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@ingresosIsrId", ingresosIsrId);
                        cmdInsert.Parameters.AddWithValue("@concepto", renglon.Concepto);
                        cmdInsert.Parameters.AddWithValue("@importe", renglon.Importe);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<(string Concepto, decimal Importe)> CargarDetalleIngresos(string tabla, int ingresosIsrId)
        {
            var tablasValidas = new HashSet<string> { "ingresos_adicionales", "ingresos_detalles_disminuir", "ingresos_detalles_cobrados" };
            if (!tablasValidas.Contains(tabla))
                throw new ArgumentException("Tabla de detalle no válida: " + tabla);

            var lista = new List<(string, decimal)>();
            using (var conexion = AbrirConexion())
            {
                string query = $"SELECT concepto, importe FROM {tabla} WHERE ingresos_isr_id = @ingresosIsrId";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ingresosIsrId", ingresosIsrId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add((reader.GetString("concepto"), reader.GetDecimal("importe")));
                        }
                    }
                }
            }
            return lista;
        }
    }
}
