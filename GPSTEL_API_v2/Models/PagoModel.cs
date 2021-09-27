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
    public class PagoModel
    {
        string _connection = string.Empty;

        public PagoModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<PagoEntity> GetChipsJson()
        {
            List<PagoEntity> PagoList = new List<PagoEntity>();
            string SqlQuery = @"SELECT [idpago]
                                  ,[concepto]
                                  ,[fecha_pago]
                                  ,[idvehiculo]
                                  ,[monto]
                                  ,[estado]
                              FROM [dbo].[Pago] where estado!='E'";
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
                            PagoList.Add(new PagoEntity()
                            {
                                idpago = ManejoNulos.ManageNullInteger(dr["idpago"]),
                                concepto = ManejoNulos.ManageNullStr(dr["concepto"]),
                                fecha_pago = ManejoNulos.ManageNullDate(dr["fecha_pago"]),
                                idvehiculo = ManejoNulos.ManageNullInteger(dr["idvehiculo"]),
                                monto = ManejoNulos.ManageNullDouble(dr["monto"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return PagoList;
        }
        public PagoEntity GetPagoByIdJson(int id)
        {
            PagoEntity Pago = new PagoEntity();
            string SqlQuery = @"SELECT [idpago]
                                  ,[concepto]
                                  ,[fecha_pago]
                                  ,[idvehiculo]
                                  ,[monto]
                                  ,[estado]
                              FROM [dbo].[Pago] where [idpago]=@p0";
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
                            Pago = new PagoEntity()
                            {
                                idpago = ManejoNulos.ManageNullInteger(dr["idpago"]),
                                concepto = ManejoNulos.ManageNullStr(dr["concepto"]),
                                fecha_pago = ManejoNulos.ManageNullDate(dr["fecha_pago"]),
                                idvehiculo = ManejoNulos.ManageNullInteger(dr["idvehiculo"]),
                                monto = ManejoNulos.ManageNullDouble(dr["monto"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Pago;
        }
        public int SavePagoJson(PagoEntity pago)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[Pago]
                               ([concepto]
                               ,[fecha_pago]
                               ,[idvehiculo]
                               ,[monto]
                               ,[estado])
                            OUTPUT INSERTED.idpago
                         VALUES
                               (@p0
                               ,@p1
                               ,@p2
                               ,@p3
                               ,@p4)
                            ";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(pago.concepto.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullDate(pago.fecha_pago));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullInteger(pago.idvehiculo));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullDouble(pago.monto));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullStr(pago.estado));
                    SavedId = (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditStateofPagoJson(PagoEntity pago)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[Pago]
                           SET 
                                [estado] = @p0
                         WHERE idpago=@p1";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(pago.estado.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullInteger(pago.idpago));
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