using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_VNR.ClienteWinForms1
{
    internal class GuardarBaseDatos
    {
        public class GestorDeDatos
        {
            // Cadena de conexión 
            private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RuidoAmbientalDB;Integrated Security=True";

            /// <summary>
            /// Guarda un Lugar y su Medición de Ruido en una sola transacción.
            /// </summary>
            public void GuardarLevantamientoMultiple(string nombreLugar, string tipoZona, double lat, double lng, List<MedicionData> mediciones)
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Iniciar Transacción
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // --- 1. INSERTAR LUGAR Y OBTENER ID ---
                            string queryLugar = @"
                            INSERT INTO Lugar (Nombre, Latitud, Longitud) 
                            VALUES (@Nombre, @Lat, @Lng);
                            SELECT SCOPE_IDENTITY();";

                            int nuevoLugarId = 0;

                            using (SqlCommand cmdLugar = new SqlCommand(queryLugar, conn, transaction))
                            {
                                cmdLugar.Parameters.AddWithValue("@Nombre", nombreLugar);
                                cmdLugar.Parameters.AddWithValue("@Lat", lat);
                                cmdLugar.Parameters.AddWithValue("@Lng", lng);

                                // ExecuteScalar obtiene el ID generado (SCOPE_IDENTITY())
                                nuevoLugarId = Convert.ToInt32(cmdLugar.ExecuteScalar());
                            }

                            // --- 2. INSERTAR MÚLTIPLES MEDICIONES ---
                            string queryMedicion = @"
                            INSERT INTO MedicionRuido (LugarId, FechaHora, NivelDecibelios, TipoZona) 
                            VALUES (@LugarId, @Fecha, @Decibelios, @TipoZona)";

                            using (SqlCommand cmdMedicion = new SqlCommand(queryMedicion, conn, transaction))
                            {
                                // Configuramos los parámetros que son fijos para todas las inserciones
                                cmdMedicion.Parameters.AddWithValue("@LugarId", nuevoLugarId);
                                cmdMedicion.Parameters.AddWithValue("@TipoZona", tipoZona);

                                // Definimos los parámetros que van a cambiar en el bucle
                                // Es más eficiente definir los tipos de SQL que usar AddWithValue directamente en el bucle
                                SqlParameter fechaParam = cmdMedicion.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime2);
                                SqlParameter dbParam = cmdMedicion.Parameters.Add("@Decibelios", System.Data.SqlDbType.Float);

                                // Iterar sobre cada medición y ejecutar el INSERT
                                foreach (var medicion in mediciones)
                                {
                                    fechaParam.Value = medicion.FechaHora;
                                    dbParam.Value = medicion.NivelDecibelios;
                                    cmdMedicion.ExecuteNonQuery();
                                }
                            }

                            // 3. Confirmar la Transacción (si todo salió bien)
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // 4. Revertir la Transacción (si algo falló, se deshacen todos los INSERTs)
                            transaction.Rollback();
                            throw new Exception("Error al guardar múltiples mediciones en la base de datos: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}

