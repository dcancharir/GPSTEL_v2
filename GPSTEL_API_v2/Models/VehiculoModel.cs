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
    public class VehiculoModel
    {
        string _connection = string.Empty;

        public VehiculoModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<VehiculoEntity> GetVehiculosJson()
        {
            List<VehiculoEntity> VehiculoList = new List<VehiculoEntity>();
            string SqlQuery = @"SELECT [idvehiculo]
                                      ,[placa]
                                      ,[marca]
                                      ,[modelo]
                                      ,[anio_vehiculo]
                                      ,[color]
                                      ,[nro_motor]
                                      ,[particular_mtc]
                                      ,[estado]
                                      ,[idgps]
                                      ,[fecha_instalacion]
                                      ,[idcliente]
                                      ,[mensualidad]
                                  FROM [dbo].[Vehiculo] where estado!='E'";
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
                            VehiculoList.Add(new VehiculoEntity()
                            {
                                idvehiculo = ManejoNulos.ManageNullInteger(dr["idvehiculo"]),
                                placa = ManejoNulos.ManageNullStr(dr["placa"]),
                                marca= ManejoNulos.ManageNullStr(dr["marca"]),
                                modelo = ManejoNulos.ManageNullStr(dr["modelo"]),
                                anio_vehiculo = ManejoNulos.ManageNullStr(dr["anio_vehiculo"]),
                                color = ManejoNulos.ManageNullStr(dr["color"]),
                                nro_motor = ManejoNulos.ManageNullStr(dr["nro_motor"]),
                                particular_mtc = ManejoNulos.ManageNullStr(dr["particular_mtc"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                idgps = ManejoNulos.ManageNullInteger(dr["idgps"]),
                                fecha_instalacion = ManejoNulos.ManageNullDate(dr["fecha_instalacion"]),
                                idcliente = ManejoNulos.ManageNullInteger(dr["idcliente"]),
                                mensualidad = ManejoNulos.ManageNullStr(dr["mensualidad"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return VehiculoList;
        }
        public VehiculoEntity GetVehiculoByIdJson(int id)
        {
            VehiculoEntity Vechiculo = new VehiculoEntity();
            string SqlQuery = @"SELECT [idvehiculo]
                                      ,[placa]
                                      ,[marca]
                                      ,[modelo]
                                      ,[anio_vehiculo]
                                      ,[color]
                                      ,[nro_motor]
                                      ,[particular_mtc]
                                      ,[estado]
                                      ,[idgps]
                                      ,[fecha_instalacion]
                                      ,[idcliente]
                                      ,[mensualidad]
                                  FROM [dbo].[Vehiculo] where [idvehiculo]=@p0";
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
                            Vechiculo = new VehiculoEntity()
                            {
                                idvehiculo = ManejoNulos.ManageNullInteger(dr["idvehiculo"]),
                                placa = ManejoNulos.ManageNullStr(dr["placa"]),
                                marca = ManejoNulos.ManageNullStr(dr["marca"]),
                                modelo = ManejoNulos.ManageNullStr(dr["modelo"]),
                                anio_vehiculo = ManejoNulos.ManageNullStr(dr["anio_vehiculo"]),
                                color = ManejoNulos.ManageNullStr(dr["color"]),
                                nro_motor = ManejoNulos.ManageNullStr(dr["nro_motor"]),
                                particular_mtc = ManejoNulos.ManageNullStr(dr["particular_mtc"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                idgps = ManejoNulos.ManageNullInteger(dr["idgps"]),
                                fecha_instalacion = ManejoNulos.ManageNullDate(dr["fecha_instalacion"]),
                                idcliente = ManejoNulos.ManageNullInteger(dr["idcliente"]),
                                mensualidad = ManejoNulos.ManageNullStr(dr["mensualidad"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Vechiculo;
        }
        public int SaveVechiculoJson(VehiculoEntity vehiculo)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[Vehiculo]
                                       ([placa]
                                       ,[marca]
                                       ,[modelo]
                                       ,[anio_vehiculo]
                                       ,[color]
                                       ,[nro_motor]
                                       ,[particular_mtc]
                                       ,[estado]
                                       ,[idgps]
                                       ,[fecha_instalacion]
                                       ,[idcliente]
                                       ,[mensualidad])
                                OUTPUT INSERTED.idvehiculo
                                 VALUES
                                       (@p0
                                       ,@p1
                                       ,@p2
                                       ,@p3
                                       ,@p4
                                       ,@p5
                                       ,@p6
                                       ,@p7
                                       ,@p8
                                       ,@p9
                                       ,@p10
                                       ,@p11)";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(vehiculo.placa));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(vehiculo.marca));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(vehiculo.modelo));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullStr(vehiculo.anio_vehiculo));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullStr(vehiculo.color));
                    query.Parameters.AddWithValue("@p5", ManejoNulos.ManageNullStr(vehiculo.nro_motor));
                    query.Parameters.AddWithValue("@p6", ManejoNulos.ManageNullStr(vehiculo.particular_mtc));
                    query.Parameters.AddWithValue("@p7", ManejoNulos.ManageNullStr(vehiculo.estado));
                    query.Parameters.AddWithValue("@p8", ManejoNulos.ManageNullInteger(vehiculo.idgps));
                    query.Parameters.AddWithValue("@p9", ManejoNulos.ManageNullDate(vehiculo.fecha_instalacion));
                    query.Parameters.AddWithValue("@p10", ManejoNulos.ManageNullInteger(vehiculo.idcliente));
                    query.Parameters.AddWithValue("@p11", ManejoNulos.ManageNullDouble(vehiculo.mensualidad));
                    SavedId = (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditVehiculoJson(VehiculoEntity vehiculo)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[Vehiculo]
                           SET [placa] = @p0
                              ,[marca] = @p1
                              ,[modelo] = @p2
                              ,[anio_vehiculo] = @p3
                              ,[color] = @p4
                              ,[nro_motor] = @p5
                              ,[particular_mtc] = @p6
                              ,[idgps] = @p7
                              ,[fecha_instalacion] = @p8
                              ,[idcliente] = @p9
                              ,[mensualidad] = @p10
                             WHERE [idvehiculo]=@p11";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(vehiculo.placa));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(vehiculo.marca));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(vehiculo.modelo));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullStr(vehiculo.anio_vehiculo));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullStr(vehiculo.color));
                    query.Parameters.AddWithValue("@p5", ManejoNulos.ManageNullStr(vehiculo.nro_motor));
                    query.Parameters.AddWithValue("@p6", ManejoNulos.ManageNullStr(vehiculo.particular_mtc));
                    query.Parameters.AddWithValue("@p7", ManejoNulos.ManageNullInteger(vehiculo.idgps));
                    query.Parameters.AddWithValue("@p8", ManejoNulos.ManageNullDate(vehiculo.fecha_instalacion));
                    query.Parameters.AddWithValue("@p9", ManejoNulos.ManageNullInteger(vehiculo.idcliente));
                    query.Parameters.AddWithValue("@p10", ManejoNulos.ManageNullDouble(vehiculo.mensualidad));
                    query.Parameters.AddWithValue("@p11", ManejoNulos.ManageNullInteger(vehiculo.idvehiculo));
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
        public bool EditStateofVehiculoJson(VehiculoEntity vehiculo)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[Vehiculo]
                           SET 
                                [estado] = @p0
                         WHERE idvehiculo=@p1";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(vehiculo.estado.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullInteger(vehiculo.idvehiculo));
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