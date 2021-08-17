using GPSTEL_API_v2.Entities;
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
                              FROM [dbo].[GPS]";
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
                                idgps = (int)dr["idgps"],
                                modelo = (string)dr["modelo"],
                                estado_uso = (string)dr["estado_uso"],
                                garantia = (string)dr["garantia"],
                                idchip = (int)dr["idchip"],
                                fecha_compra = (DateTime)dr["fecha_compra"],
                                imei = (string)dr["imei"],
                            });
                        }
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
                                idgps = (int)dr["idgps"],
                                modelo = (string)dr["modelo"],
                                estado_uso = (string)dr["estado_uso"],
                                garantia = (string)dr["garantia"],
                                idchip = (int)dr["idchip"],
                                fecha_compra = (DateTime)dr["fecha_compra"],
                                imei = (string)dr["imei"],
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
                               ,[imei])
                         VALUES
                               (@p0
                               ,@p1
                               ,@p2
                               ,@p3
                               ,@p4
                               ,@p5)";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", gps.modelo);
                    query.Parameters.AddWithValue("@p1", gps.estado_uso);
                    query.Parameters.AddWithValue("@p2", gps.garantia);
                    query.Parameters.AddWithValue("@p3", gps.idchip);
                    query.Parameters.AddWithValue("@p4", gps.fecha_compra);
                    query.Parameters.AddWithValue("@p5", gps.imei);
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
                    query.Parameters.AddWithValue("@p0", gps.modelo);
                    query.Parameters.AddWithValue("@p1", gps.estado_uso);
                    query.Parameters.AddWithValue("@p2", gps.garantia);
                    query.Parameters.AddWithValue("@p3", gps.idchip);
                    query.Parameters.AddWithValue("@p4", gps.fecha_compra);
                    query.Parameters.AddWithValue("@p5", gps.imei);
                    query.Parameters.AddWithValue("@p6", gps.idgps);
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
    }
}