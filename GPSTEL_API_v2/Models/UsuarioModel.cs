using GPSTEL_API_v2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Models
{
    public class UsuarioModel
    {
        string _connection = string.Empty;

        public UsuarioModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public UsuarioEntity GetUserForLoginJson(string UserName)
        {
            UsuarioEntity LoginUser = new UsuarioEntity();
            string SqlQuery = @"SELECT [idusuario]
                                  ,[nombre]
                                  ,[password]
                                  ,[estado]
                                  ,[tipo]
                              FROM [dbo].[Usuario] where nombre=@p0";
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", UserName);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LoginUser = new UsuarioEntity()
                            {
                                idusuario= (int)dr["idusuario"],
                                nombre = (string)dr["nombre"],
                                password = (string)dr["password"],
                                estado = (string)dr["estado"],
                                tipo = (string)dr["tipo"],
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return LoginUser;
        }
        public UsuarioEntity GetUserByIdJson(int idusuario)
        {
            UsuarioEntity LoginUser = new UsuarioEntity();
            string SqlQuery = @"SELECT [idusuario]
                                  ,[nombre]
                                  ,[estado]
                                  ,[tipo]
                              FROM [dbo].[Usuario] where idusuario=@p0";
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", idusuario);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LoginUser = new UsuarioEntity()
                            {
                                idusuario = (int)dr["idusuario"],
                                nombre = (string)dr["nombre"],
                                estado = (string)dr["estado"],
                                tipo = (string)dr["tipo"],
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return LoginUser;
        }
    }
}