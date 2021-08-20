using GPSTEL_API_v2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Models
{
    public class DepartamentoModel
    {
        string _connection = string.Empty;

        public DepartamentoModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<DepartamentoEntity> GetDepartamentosJson()
        {
            List<DepartamentoEntity> DepartamentoList = new List<DepartamentoEntity>();
            string SqlQuery = @"SELECT [iddepartamento]
                                  ,[nombre]
                              FROM [dbo].[Departamento]";
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
                            DepartamentoList.Add(new DepartamentoEntity()
                            {
                                iddepartamento = (int)dr["iddepartamento"],
                                nombre = (string)dr["nombre"],
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return DepartamentoList;
        }
    }
}