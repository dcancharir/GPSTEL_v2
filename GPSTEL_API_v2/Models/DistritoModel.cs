using GPSTEL_API_v2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Models
{
    public class DistritoModel
    {
        string _connection = string.Empty;

        public DistritoModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<DistritoEntity> GetDistritosByProvinciaJson(int idprovincia)
        {
            List<DistritoEntity> DistritoList = new List<DistritoEntity>();
            string SqlQuery = @"SELECT [iddistrito]
                                  ,[nombre]
                                  ,[idprovincia]
                              FROM [dbo].[Distrito] where idprovincia=@p0";
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
                            DistritoList.Add(new DistritoEntity()
                            {
                                iddistrito = (int)dr["iddistrito"],
                                nombre = (string)dr["nombre"],
                                idprovincia = (int)dr["idprovincia"],
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return DistritoList;
        }
    }
}