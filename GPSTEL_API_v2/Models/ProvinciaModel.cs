using GPSTEL_API_v2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Models
{
    public class ProvinciaModel
    {
        string _connection = string.Empty;

        public ProvinciaModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<ProvinciaEntity> GetProvinciasByDepartamentoJson(int iddepartamento)
        {
            List<ProvinciaEntity> ProvinciaList = new List<ProvinciaEntity>();
            string SqlQuery = @"SELECT [idprovincia]
                          ,[nombre]
                          ,[iddepartamento]
                      FROM [GPSTEL].[dbo].[Provincia] where iddepartamento=@p0";
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0",iddepartamento);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ProvinciaList.Add(new ProvinciaEntity()
                            {
                                idprovincia = (int)dr["idprovincia"],
                                nombre = (string)dr["nombre"],
                                iddepartamento = (int)dr["iddepartamento"],
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ProvinciaList;
        }
    }
}