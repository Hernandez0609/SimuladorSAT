using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SimuladorSAT
{
    internal class clsConexion
    {
        private static readonly string RutaBD = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SimuladorSAT_Datos",
            "satcontaduria.db"
        );

        private readonly string cadenaConexion = $"Data Source={RutaBD};Version=3;Journal Mode=Wal;";

        // Bandera estática para evitar el bucle infinito y ejecutar la inicialización 1 sola vez
        private static bool _baseDatosInicializada = false;

        public SQLiteConnection AbrirConexion()
        {
            // 1. Asegurar que el directorio de datos en %AppData% exista
            string directorio = Path.GetDirectoryName(RutaBD);
            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            // 2. Si la base de datos no existe en %AppData%, copiar el archivo predefinido del ejecutable
            if (!File.Exists(RutaBD))
            {
                string rutaBDOrigen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "satcontaduria.db");
                if (File.Exists(rutaBDOrigen))
                {
                    File.Copy(rutaBDOrigen, RutaBD, true);
                }
            }

            // 3. Ejecutar la inicialización pública de la clase clsUsuario solo una vez al iniciar la app
            if (!_baseDatosInicializada)
            {
                _baseDatosInicializada = true;
                clsUsuario.InicializarBaseDatos();
            }

            SQLiteConnection conexion = new SQLiteConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        public int ObtenerIdCatalogo(string tabla, string columnaDescripcion, string valor)
        {
            using (var conexion = AbrirConexion())
            {
                string query = $"SELECT id FROM {tabla} WHERE {columnaDescripcion} = @valor LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conexion))
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
                using (var cmd = new SQLiteCommand(query, conexion))
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
            SELECT last_insert_rowid();";

                using (var cmd = new SQLiteCommand(query, conexion))
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
                using (var cmd = new SQLiteCommand(query, conexion))
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

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ModeloDeclaracion
                            {
                                Ejercicio = Convert.ToInt32(reader["ejercicio"]),
                                Periocidad = reader["periodicidad"].ToString(),
                                Periodo = reader["periodo"].ToString(),
                                TipoDeclaracion = reader["tipo_declaracion"].ToString(),
                                ModuloIsrFisicasSeleccionado = Convert.ToBoolean(reader["modulo_isr_fisicas_seleccionado"]),
                                ModuloIsrSalariosSeleccionado = Convert.ToBoolean(reader["modulo_isr_salarios_seleccionado"]),
                                ModuloIvaSimplificadoSeleccionado = Convert.ToBoolean(reader["modulo_iva_seleccionado"]),
                                FechaCreacion = Convert.ToDateTime(reader["fecha_creacion"]),
                                FechaUltimaModificacion = Convert.ToDateTime(reader["fecha_ultima_modificacion"]),
                                ContribuyenteId = Convert.ToInt32(reader["contribuyente_id"]),
                                ModuloIsrFisicasCompletado = Convert.ToBoolean(reader["modulo_isr_fisicas_completado"]),
                                ModuloIsrSalariosCompletado = Convert.ToBoolean(reader["modulo_isr_salarios_completado"]),
                                ModuloIvaSimplificadoCompletado = Convert.ToBoolean(reader["modulo_iva_completado"]),
                                MontoIsrFisicas = Convert.ToDecimal(reader["monto_isr_fisicas"]),
                                MontoIsrSalarios = Convert.ToDecimal(reader["monto_isr_salarios"]),
                                MontoIva = Convert.ToDecimal(reader["monto_iva"]),
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

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    cmd.Parameters.AddWithValue("@periodoId", periodoId);
                    cmd.Parameters.AddWithValue("@tipoDeclaracionNormalId", tipoDeclaracionNormalId);
                    cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isrFisicas = Convert.ToBoolean(reader["modulo_isr_fisicas_completado"]);
                            isrSalarios = Convert.ToBoolean(reader["modulo_isr_salarios_completado"]);
                            iva = Convert.ToBoolean(reader["modulo_iva_completado"]);
                        }
                    }
                }
            }
        }

        public void MarcarModuloCompletado(int declaracionId, string columnaModulo)
        {
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
                           SET {columnaModulo} = 1, fecha_ultima_modificacion = datetime('now', 'localtime') 
                           WHERE id = @id";
                using (var cmd = new SQLiteCommand(query, conexion))
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

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ModeloDeclaracion
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Ejercicio = Convert.ToInt32(reader["ejercicio"]),
                                Periocidad = reader["periodicidad"].ToString(),
                                Periodo = reader["periodo"].ToString(),
                                TipoDeclaracion = reader["tipo_declaracion"].ToString(),
                                ModuloIsrFisicasSeleccionado = Convert.ToBoolean(reader["modulo_isr_fisicas_seleccionado"]),
                                ModuloIsrSalariosSeleccionado = Convert.ToBoolean(reader["modulo_isr_salarios_seleccionado"]),
                                ModuloIvaSimplificadoSeleccionado = Convert.ToBoolean(reader["modulo_iva_seleccionado"]),
                                ModuloIsrFisicasCompletado = Convert.ToBoolean(reader["modulo_isr_fisicas_completado"]),
                                ModuloIsrSalariosCompletado = Convert.ToBoolean(reader["modulo_isr_salarios_completado"]),
                                ModuloIvaSimplificadoCompletado = Convert.ToBoolean(reader["modulo_iva_completado"]),
                                FechaCreacion = Convert.ToDateTime(reader["fecha_creacion"]),
                                FechaUltimaModificacion = Convert.ToDateTime(reader["fecha_ultima_modificacion"]),
                                ContribuyenteId = Convert.ToInt32(reader["contribuyente_id"]),
                                MontoIsrFisicas = Convert.ToDecimal(reader["monto_isr_fisicas"]),
                                MontoIsrSalarios = Convert.ToDecimal(reader["monto_isr_salarios"]),
                                MontoIva = Convert.ToDecimal(reader["monto_iva"]),
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
                string query = "UPDATE declaraciones SET fecha_ultima_modificacion = datetime('now', 'localtime') WHERE id = @id";
                using (var cmd = new SQLiteCommand(query, conexion))
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
                          SET concluida = 1, fecha_envio = datetime('now', 'localtime'), numero_operacion = @folio
                          WHERE id = @id";
                using (var cmd = new SQLiteCommand(query, conexion))
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
            var rnd = new Random();
            return rnd.Next(100000000, 999999999).ToString();
        }

        public (string matricula, string nombre) ObtenerDatosContribuyente(int contribuyenteId)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT matricula, nombre FROM contribuyentes WHERE id = @id";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", contribuyenteId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader["matricula"].ToString(), reader["nombre"].ToString());
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
                    using (var cmd = new SQLiteCommand(queryUpdate, conexion))
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
                SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(queryInsert, conexion))
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

            GuardarDetalleIngresos("ingresos_detalles_cobrados", ingresosIsrId, modelo.ListaTotalPercibidosDetalle);
            GuardarDetalleIngresos("ingresos_detalles_disminuir", ingresosIsrId, modelo.ListaIngresosADisminuir);
            GuardarDetalleIngresos("ingresos_adicionales", ingresosIsrId, modelo.ListaIngresosAdicionales);
            GuardarDetalleEgresos(ingresosIsrId, modelo);
        }

        private void AgregarParametrosIsrFisicas(SQLiteCommand cmd, ModeloIsrPersonasFisicas modelo)
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
            int ivaSimplificadoId;
            using (var conexion = AbrirConexion())
            {
                int idExistente = ObtenerIdModulo(conexion, "iva_simplificado", declaracionId);
                if (idExistente > 0)
                {
                    ivaSimplificadoId = idExistente;
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
                    using (var cmd = new SQLiteCommand(queryUpdate, conexion))
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
         @saldoFavorAnterior, @compensaciones, @estimulos);
        SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(queryInsert, conexion))
                    {
                        cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                        cmd.Parameters.AddWithValue("@contribuyenteId", contribuyenteId);
                        cmd.Parameters.AddWithValue("@periodoMes", periodoMes);
                        cmd.Parameters.AddWithValue("@periodoAnio", periodoAnio);
                        cmd.Parameters.AddWithValue("@tipoDeclaracionId", tipoDeclaracionId);
                        AgregarParametrosIva(cmd, modelo);
                        ivaSimplificadoId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                GuardarDetalleDevolucionesIva(ivaSimplificadoId, modelo);
            }
        }

        private void AgregarParametrosIva(SQLiteCommand cmd, ModeloIva modelo)
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
                    using (var cmd = new SQLiteCommand(queryUpdate, conexion))
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
                    using (var cmd = new SQLiteCommand(queryInsert, conexion))
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

        private void AgregarParametrosIsrSalarios(SQLiteCommand cmd, ModeloIsrRetencionesSalarios modelo)
        {
            cmd.Parameters.AddWithValue("@cantTrabajadores", modelo.NumeroTrabajadores);
            cmd.Parameters.AddWithValue("@totalSueldosPagados", modelo.PagoSueldos);
            cmd.Parameters.AddWithValue("@totalSueldosExentos", modelo.PagosExentos);
            cmd.Parameters.AddWithValue("@isrRetenidoSat", modelo.IsrRetenidoSueldos);
            cmd.Parameters.AddWithValue("@isrRetenidoContribuyente", modelo.IsrRetenidoRegistroContribuyente);
            cmd.Parameters.AddWithValue("@subsidioEmpleo", modelo.SubsidioParaElEmpleo);
            cmd.Parameters.AddWithValue("@estimulos", modelo.Estimulos);
        }

        private int ObtenerIdModulo(SQLiteConnection conexion, string tabla, int declaracionId)
        {
            var tablasValidas = new HashSet<string> { "ingresos_isr", "iva_simplificado", "declaraciones_retenciones_salarios" };
            if (!tablasValidas.Contains(tabla))
                throw new ArgumentException("Tabla de módulo no válida: " + tabla);

            string query = $"SELECT id FROM {tabla} WHERE declaracion_id = @declaracionId LIMIT 1";
            using (var cmd = new SQLiteCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
        }

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

        public int ObtenerNumeroMes(string nombreMes)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                               "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            int indice = Array.IndexOf(meses, nombreMes);
            if (indice == -1)
                throw new ArgumentException("Nombre de mes no reconocido: " + nombreMes);
            return indice + 1;
        }

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
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.TotalIngresosCobrados = Convert.ToDecimal(reader["total_ingresos_cobrados"]);
                            m.Descuentos = Convert.ToDecimal(reader["descuentos_devoluciones_bonificaciones"]);
                            m.DescuentosCapturado = m.Descuentos != 0;
                            m.IngresosADisminuir = Convert.ToDecimal(reader["ingresos_a_disminuir"]);
                            m.TieneIngresosADisminuir = m.IngresosADisminuir != 0;
                            m.IngresosADisminuirCapturado = m.TieneIngresosADisminuir;
                            m.IngresosAdicionales = Convert.ToDecimal(reader["ingresos_adicionales"]);
                            m.TieneIngresosAdicionales = m.IngresosAdicionales != 0;
                            m.IngresosAdicionalesCapturado = m.TieneIngresosAdicionales;
                            m.TotalIngresosPercibidos = Convert.ToDecimal(reader["total_ingresos_percibidos"]);
                            m.TotalPercibidosCapturado = m.TotalIngresosPercibidos != 0;
                            m.TasaAplicable = Convert.ToDecimal(reader["tasa_aplicable"]);
                            m.ImpuestoMensual = Convert.ToDecimal(reader["impuesto_mensual"]);
                            m.IsrRetenidoPersonasMorales = Convert.ToDecimal(reader["isr_retenido_pm"]);
                            m.IsrRetenidoCapturado = m.IsrRetenidoPersonasMorales != 0;
                            m.ImpuestoACargo = Convert.ToDecimal(reader["impuesto_a_cargo"]);
                            m.DeterminacionCompleta = m.IsrRetenidoCapturado;
                            m.SubsidioParaElEmpleo = Convert.ToDecimal(reader["subsidio_empleo"]);
                            m.Compensaciones = Convert.ToDecimal(reader["compensaciones_aplicadas"]);
                            m.TieneCompensaciones = m.Compensaciones != 0;
                            m.CompensacionesCapturado = m.TieneCompensaciones;
                            m.Estimulos = Convert.ToDecimal(reader["estimulos_aplicados"]);
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
                CargarDetalleEgresos(ingresosIsrId, m);
            }
            Program.modeloIsrFisicas = m;
        }

        private void CargarIva(int declaracionId)
        {
            var m = new ModeloIva();
            int ivaId = 0;
            using (var conexion = AbrirConexion())
            {
                ivaId = ObtenerIdModulo(conexion, "iva_simplificado", declaracionId);
                string query = "SELECT * FROM iva_simplificado WHERE declaracion_id = @declaracionId LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.ActividadesGravadas16 = Convert.ToDecimal(reader["actividades_16"]);
                            m.ActividadesGravadas0 = Convert.ToDecimal(reader["actividades_0"]);
                            m.ActividadesGravadas0Capturado = m.ActividadesGravadas0 != 0;
                            m.ActividadesExentas = Convert.ToDecimal(reader["actividades_exentas"]);
                            m.ActividadesNoObjeto = Convert.ToDecimal(reader["actividades_no_objeto"]);
                            m.IvaNoCobradoDevoluciones = Convert.ToDecimal(reader["iva_devoluciones_ventas"]);
                            m.IvaRetenido = Convert.ToDecimal(reader["iva_retenido"]);
                            m.IvaAcreditablePeriodo = Convert.ToDecimal(reader["iva_acreditable"]);
                            m.IvaAcreditablePeriodoCapturado = m.IvaAcreditablePeriodo != 0;
                            m.IvaPorDevolucionesGastos = Convert.ToDecimal(reader["iva_devoluciones_gastos"]);
                            m.AcreditamientoSaldoFavorAnterior = Convert.ToDecimal(reader["saldo_favor_anterior"]);
                            m.Compensaciones = Convert.ToDecimal(reader["compensaciones_aplicadas"]);
                            m.TieneCompensaciones = m.Compensaciones != 0;
                            m.Estimulos = Convert.ToDecimal(reader["estimulos_aplicados"]);
                            m.TieneEstimulos = m.Estimulos != 0;
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
            if (ivaId > 0)
            {
                CargarDetalleDevolucionesIva(ivaId, m);
            }
            Program.modeloIva = m;
        }

        private void CargarIsrSalarios(int declaracionId)
        {
            var m = new ModeloIsrRetencionesSalarios();
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT * FROM declaraciones_retenciones_salarios WHERE declaracion_id = @declaracionId LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@declaracionId", declaracionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.NumeroTrabajadores = Convert.ToInt32(reader["cant_trabajadores"]);
                            m.PagoSueldos = Convert.ToDecimal(reader["total_sueldos_pagados"]);
                            m.PagosExentos = Convert.ToDecimal(reader["total_sueldos_exentos"]);
                            m.IsrRetenidoSueldos = Convert.ToDecimal(reader["isr_retenido_sat"]);
                            m.IsrRetenidoRegistroContribuyente = Convert.ToDecimal(reader["isr_retenido_contribuyente"]);
                            m.IsrRetenidoRegistroCapturado = m.IsrRetenidoRegistroContribuyente != 0;
                            m.ImpuestoACargo = m.IsrRetenidoRegistroContribuyente;
                            m.DeterminacionCompleta = m.IsrRetenidoRegistroCapturado;
                            m.SubsidioParaElEmpleo = Convert.ToDecimal(reader["subsidio_empleo"]);
                            m.Estimulos = Convert.ToDecimal(reader["estimulos_aplicados"]);
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

        public void GuardarMontosDeclaracion(int declaracionId, decimal montoIsrFisicas, decimal montoIsrSalarios, decimal montoIva)
        {
            using (var conexion = AbrirConexion())
            {
                string query = @"UPDATE declaraciones SET
            monto_isr_fisicas = @montoIsrFisicas,
            monto_isr_salarios = @montoIsrSalarios,
            monto_iva = @montoIva
            WHERE id = @id";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@montoIsrFisicas", montoIsrFisicas);
                    cmd.Parameters.AddWithValue("@montoIsrSalarios", montoIsrSalarios);
                    cmd.Parameters.AddWithValue("@montoIva", montoIva);
                    cmd.Parameters.AddWithValue("@id", declaracionId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GuardarDetalleIngresos(string tabla, int ingresosIsrId, List<(string Concepto, decimal Importe)> lista)
        {
            var tablasValidas = new HashSet<string> { "ingresos_adicionales", "ingresos_detalles_disminuir", "ingresos_detalles_cobrados" };
            if (!tablasValidas.Contains(tabla))
                throw new ArgumentException("Tabla de detalle no válida: " + tabla);

            using (var conexion = AbrirConexion())
            {
                // Inicia la transacción
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        string queryDelete = $"DELETE FROM {tabla} WHERE ingresos_isr_id = @ingresosIsrId";
                        // Pasa 'transaccion' como tercer parámetro al comando
                        using (var cmdDelete = new SQLiteCommand(queryDelete, conexion, transaccion))
                        {
                            cmdDelete.Parameters.AddWithValue("@ingresosIsrId", ingresosIsrId);
                            cmdDelete.ExecuteNonQuery();
                        }

                        foreach (var renglon in lista)
                        {
                            string queryInsert = $"INSERT INTO {tabla} (ingresos_isr_id, concepto, importe) VALUES (@ingresosIsrId, @concepto, @importe)";
                            // Pasa 'transaccion' como tercer parámetro al comando
                            using (var cmdInsert = new SQLiteCommand(queryInsert, conexion, transaccion))
                            {
                                cmdInsert.Parameters.AddWithValue("@ingresosIsrId", ingresosIsrId);
                                cmdInsert.Parameters.AddWithValue("@concepto", renglon.Concepto);
                                cmdInsert.Parameters.AddWithValue("@importe", renglon.Importe);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                        // Guarda todo en disco de un solo golpe
                        transaccion.Commit();
                    }
                    catch
                    {
                        // Si algo falla, revierte los cambios para no dejar datos corruptos
                        transaccion.Rollback();
                        throw;
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
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ingresosIsrId", ingresosIsrId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add((reader["concepto"].ToString(), Convert.ToDecimal(reader["importe"])));
                        }
                    }
                }
            }
            return lista;
        }

        public void GuardarDetalleEgresos(int ingresosIsrId, ModeloIsrPersonasFisicas modelo)
        {
            using (var conexion = AbrirConexion())
            {
                string queryDelete = "DELETE FROM ingresos_detalles_egresos WHERE ingresos_isr_id = @id";
                using (var cmdDelete = new SQLiteCommand(queryDelete, conexion))
                {
                    cmdDelete.Parameters.AddWithValue("@id", ingresosIsrId);
                    cmdDelete.ExecuteNonQuery();
                }

                string queryInsert = @"INSERT INTO ingresos_detalles_egresos
            (ingresos_isr_id, mes_nombre, facturas_canceladas_cant, facturas_vigentes_cant,
             facturas_subtotal, facturas_descuento, total_egresos_sat,
             descuentos_copropiedad, total_descuentos_aplicados)
            VALUES
            (@id, @mes, @canceladas, @vigentes, @subtotal, @descuento, @neto, @copropiedad, @total)";
                using (var cmd = new SQLiteCommand(queryInsert, conexion))
                {
                    decimal neto = modelo.DetalleEgresosSubtotal - modelo.DetalleEgresosDescuento;
                    if (neto < 0) neto = 0;

                    cmd.Parameters.AddWithValue("@id", ingresosIsrId);
                    cmd.Parameters.AddWithValue("@mes", Program.declaracionActual?.Periodo ?? "");
                    cmd.Parameters.AddWithValue("@canceladas", modelo.DetalleEgresosFacturasCanceladas);
                    cmd.Parameters.AddWithValue("@vigentes", modelo.DetalleEgresosFacturasVigentes);
                    cmd.Parameters.AddWithValue("@subtotal", modelo.DetalleEgresosSubtotal);
                    cmd.Parameters.AddWithValue("@descuento", modelo.DetalleEgresosDescuento);
                    cmd.Parameters.AddWithValue("@neto", neto);
                    cmd.Parameters.AddWithValue("@copropiedad", modelo.DescuentosCopropiedad);
                    cmd.Parameters.AddWithValue("@total", modelo.Descuentos);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CargarDetalleEgresos(int ingresosIsrId, ModeloIsrPersonasFisicas modelo)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT * FROM ingresos_detalles_egresos WHERE ingresos_isr_id = @id LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", ingresosIsrId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            modelo.DetalleEgresosFacturasCanceladas = Convert.ToInt32(reader["facturas_canceladas_cant"]);
                            modelo.DetalleEgresosFacturasVigentes = Convert.ToInt32(reader["facturas_vigentes_cant"]);
                            modelo.DetalleEgresosSubtotal = Convert.ToDecimal(reader["facturas_subtotal"]);
                            modelo.DetalleEgresosDescuento = Convert.ToDecimal(reader["facturas_descuento"]);
                            modelo.DescuentosCopropiedad = Convert.ToDecimal(reader["descuentos_copropiedad"]);
                        }
                    }
                }
            }
        }

        public void GuardarDetalleDevolucionesIva(int ivaSimplificadoId, ModeloIva modelo)
        {
            using (var conexion = AbrirConexion())
            {
                string queryDelete = "DELETE FROM iva_detalles_devoluciones WHERE iva_simplificado_id = @id";
                using (var cmdDelete = new SQLiteCommand(queryDelete, conexion))
                {
                    cmdDelete.Parameters.AddWithValue("@id", ivaSimplificadoId);
                    cmdDelete.ExecuteNonQuery();
                }

                string queryInsert = @"INSERT INTO iva_detalles_devoluciones
            (iva_simplificado_id, mes_nombre, facturas_canceladas_cant, facturas_vigentes_cant,
             facturas_subtotal, facturas_descuento, iva_8_egresos, iva_16_egresos, total_iva_no_cobrado)
            VALUES
            (@id, @mes, @canceladas, @vigentes, @subtotal, @descuento, @iva8, @iva16, @total)";
                using (var cmd = new SQLiteCommand(queryInsert, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", ivaSimplificadoId);
                    cmd.Parameters.AddWithValue("@mes", Program.declaracionActual?.Periodo ?? "");
                    cmd.Parameters.AddWithValue("@canceladas", modelo.DetalleDevolucionesFacturasCanceladas);
                    cmd.Parameters.AddWithValue("@vigentes", modelo.DetalleDevolucionesFacturasVigentes);
                    cmd.Parameters.AddWithValue("@subtotal", modelo.DetalleDevolucionesSubtotal);
                    cmd.Parameters.AddWithValue("@descuento", modelo.DetalleDevolucionesDescuento);
                    cmd.Parameters.AddWithValue("@iva8", modelo.Iva8PorcentoEgresos);
                    cmd.Parameters.AddWithValue("@iva16", modelo.Iva16PorcentoEgresos);
                    cmd.Parameters.AddWithValue("@total", modelo.IvaNoCobradoDevoluciones);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CargarDetalleDevolucionesIva(int ivaSimplificadoId, ModeloIva modelo)
        {
            using (var conexion = AbrirConexion())
            {
                string query = "SELECT * FROM iva_detalles_devoluciones WHERE iva_simplificado_id = @id LIMIT 1";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", ivaSimplificadoId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            modelo.DetalleDevolucionesFacturasCanceladas = Convert.ToInt32(reader["facturas_canceladas_cant"]);
                            modelo.DetalleDevolucionesFacturasVigentes = Convert.ToInt32(reader["facturas_vigentes_cant"]);
                            modelo.DetalleDevolucionesSubtotal = Convert.ToDecimal(reader["facturas_subtotal"]);
                            modelo.DetalleDevolucionesDescuento = Convert.ToDecimal(reader["facturas_descuento"]);
                            modelo.Iva8PorcentoEgresos = Convert.ToDecimal(reader["iva_8_egresos"]);
                            modelo.Iva16PorcentoEgresos = Convert.ToDecimal(reader["iva_16_egresos"]);
                        }
                    }
                }
            }
        }
    }
}