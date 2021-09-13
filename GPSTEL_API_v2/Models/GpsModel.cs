using GPSTEL_API_v2.Entities;
using GPSTEL_API_v2.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Models
{
    public class GpsModel
    {
        string _connection = string.Empty;

        public GpsModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<GpsEntity> GetGpssJson()
        {
            List<GpsEntity> GpsList = new List<GpsEntity>();
            string SqlQuery = @"SELECT [idgps]
                                  ,[modelo]
                                  ,[estado_uso]
                                  ,[garantia]
                                  ,[idchip]
                                  ,[fecha_compra]
                                  ,[imei]
                                  ,[estado]
                              FROM [dbo].[GPS] where estado!='E'";
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            GpsList.Add(new GpsEntity()
                            {
                                idgps = ManejoNulos.ManageNullInteger(dr["idgps"]),
                                modelo = ManejoNulos.ManageNullStr(dr["modelo"]),
                                estado_uso = ManejoNulos.ManageNullStr(dr["estado_uso"]),
                                garantia = ManejoNulos.ManageNullStr(dr["garantia"]),
                                idchip = ManejoNulos.ManageNullInteger(dr["idchip"]),
                                fecha_compra = ManejoNulos.ManageNullDate(dr["fecha_compra"]),
                                imei = ManejoNulos.ManageNullStr(dr["imei"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                            });
                        }
                    }
                    foreach(var gps in GpsList)
                    {
                        SetChip(con, gps);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return GpsList;
        }
        public GpsEntity GetGpsByIdJson(int id)
        {
            GpsEntity Gps = new GpsEntity();
            string SqlQuery = @"SELECT [idgps]
                                  ,[modelo]
                                  ,[estado_uso]
                                  ,[garantia]
                                  ,[idchip]
                                  ,[fecha_compra]
                                  ,[imei]
                                  ,[estado]
                              FROM [dbo].[GPS] where [idgps]=@p0";
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", id);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Gps = new GpsEntity()
                            {
                                idgps = ManejoNulos.ManageNullInteger(dr["idgps"]),
                                modelo = ManejoNulos.ManageNullStr(dr["modelo"]),
                                estado_uso = ManejoNulos.ManageNullStr(dr["estado_uso"]),
                                garantia = ManejoNulos.ManageNullStr(dr["garantia"]),
                                idchip = ManejoNulos.ManageNullInteger(dr["idchip"]),
                                fecha_compra = ManejoNulos.ManageNullDate(dr["fecha_compra"]),
                                imei = ManejoNulos.ManageNullStr(dr["imei"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Gps;
        }
        public int SaveGpsJson(GpsEntity gps)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[GPS]
                               ([modelo]
                               ,[estado_uso]
                               ,[garantia]
                               ,[idchip]
                               ,[fecha_compra]
                               ,[imei]
                               ,[estado]
                                )
                         VALUES
                               (@p0
                               ,@p1
                               ,@p2
                               ,@p3
                               ,@p4
                               ,@p5
                                ,@p6)";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(gps.modelo));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(gps.estado_uso));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(gps.garantia));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullInteger(gps.idchip));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullDate(gps.fecha_compra));
                    query.Parameters.AddWithValue("@p5", ManejoNulos.ManageNullStr(gps.imei));
                    query.Parameters.AddWithValue("@p6", ManejoNulos.ManageNullStr(gps.estado));
                    SavedId = (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditGpsJson(GpsEntity gps)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[GPS]
                               SET [modelo] = @p0
                                  ,[estado_uso] = @p1
                                  ,[garantia] = @p2
                                  ,[idchip] = @p3
                                  ,[fecha_compra] = @p4
                                  ,[imei] = @p5
                             WHERE [idgps]=@p6";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(gps.modelo));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(gps.estado_uso));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(gps.garantia));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullInteger(gps.idchip));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullDate(gps.fecha_compra));
                    query.Parameters.AddWithValue("@p5", ManejoNulos.ManageNullStr(gps.imei));
                    query.Parameters.AddWithValue("@p6", ManejoNulos.ManageNullInteger(gps.idgps));
                    query.ExecuteNonQuery();
                    Edited = true;
                }
            }
            catch (Exception ex)
            {
                Edited = false;
            }

            return Edited;
        }
        public bool EditStateofGpsJson(GpsEntity gps)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[GPS]
                           SET 
                                [estado] = @p0
                         WHERE idgps=@p1";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(gps.estado.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullInteger(gps.idgps));
                    query.ExecuteNonQuery();
                    Edited = true;
                }
            }
            catch (Exception ex)
            {
                Edited = false;
            }
            return Edited;
        }
        public void SetChip(SqlConnection con,GpsEntity gps)
        {
            string consulta = @"SELECT [idchip]
                              ,[operador]
                              ,[tipo_contrato]
                              ,[numero],[estado]
                          FROM [dbo].[CHIP] where [idchip]=@p0";
            var query = new SqlCommand(consulta, con);
            query.Parameters.AddWithValue("@p0", gps.idchip);
            using(var reader = query.ExecuteReader())
            {
                reader.Read();
                gps.Chip = new ChipEntity()
                {
                    idchip=ManejoNulos.ManageNullInteger(reader["idchip"]),
                    operador=ManejoNulos.ManageNullStr(reader["operador"]),
                    tipo_contrato=ManejoNulos.ManageNullStr(reader["tipo_contrato"]),
                    numero=ManejoNulos.ManageNullStr(reader["numero"]),
                    estado=ManejoNulos.ManageNullStr(reader["estado"]),
                };
            }
        }
    }
}