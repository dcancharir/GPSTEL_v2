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
    public class ObservacionVehiculoModel
    {
        string _connection = string.Empty;

        public ObservacionVehiculoModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<ObservacionVehiculoEntity> GetObservacionesPagoJson()
        {
            List<ObservacionVehiculoEntity> ObsList = new List<ObservacionVehiculoEntity>();
            string SqlQuery = @"SELECT [idobservacion]
                      ,[observacion]
                      ,[estado]
                      ,[idvehiculo]
                  FROM [dbo].[ObservacionVehiculo] where estado!='E'";
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
                            ObsList.Add(new ObservacionVehiculoEntity()
                            {
                                idobservacion = ManejoNulos.ManageNullInteger(dr["idobservacion"]),
                                observacion = ManejoNulos.ManageNullStr(dr["observacion"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                idvehiculo = ManejoNulos.ManageNullInteger(dr["idvehiculo"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ObsList;
        }
        public int SaveObservacionVehiculoJson(ObservacionVehiculoEntity obs)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[ObservacionVehiculo]
                               ([observacion]
                               ,[estado]
                               ,[idvehiculo])
                            OUTPUT INSERTED.idobservacion
                         VALUES
                               (@p0
                               ,@p1
                               ,@p2)";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(obs.observacion));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(obs.estado));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullInteger(obs.idvehiculo));
                    SavedId = (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditStateofObservacionVehiculoJson(ObservacionVehiculoEntity obs)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[ObservacionVehiculo]
                           SET 
                                [estado] = @p0
                         WHERE idobservacion=@p1";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(obs.estado.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullInteger(obs.idobservacion));
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