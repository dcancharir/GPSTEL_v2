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
    public class ObservacionClienteModel
    {
        string _connection = string.Empty;

        public ObservacionClienteModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<ObservacionClienteEntity> GetObservacionesClienteJson()
        {
            List<ObservacionClienteEntity> ObsList = new List<ObservacionClienteEntity>();
            string SqlQuery = @"SELECT [idobservacion]
                      ,[observacion]
                      ,[estado]
                      ,[idcliente]
                  FROM [dbo].[ObservacionCliente] where estado!='E'";
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
                            ObsList.Add(new ObservacionClienteEntity()
                            {
                                idobservacion = ManejoNulos.ManageNullInteger(dr["idobservacion"]),
                                observacion = ManejoNulos.ManageNullStr(dr["observacion"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                idcliente = ManejoNulos.ManageNullInteger(dr["idcliente"]),
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
        public int SaveObservacionClienteJson(ObservacionClienteEntity obs)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[ObservacionCliente]
                               ([observacion]
                               ,[estado]
                               ,[idcliente])
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
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(obs.idcliente));
                    SavedId = (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditStateofObservacionClienteJson(ObservacionClienteEntity obs)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[ObservacionCliente]
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