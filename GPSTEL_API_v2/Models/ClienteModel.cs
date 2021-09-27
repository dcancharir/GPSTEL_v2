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
    public class ClienteModel
    {
        string _connection = string.Empty;

        public ClienteModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<ClienteEntity> GetClientesJson()
        {
            List<ClienteEntity> ClienteList = new List<ClienteEntity>();
            string SqlQuery = @"SELECT [idcliente]
                                  ,[fecha_contrato]
                                  ,[estado]
                                  ,[nombre]
                                  ,[apellido]
                                  ,[dni_ruc]
                                  ,[telefono]
                                  ,[celular]
                                  ,[correo]
                                  ,[direccion]
                                  ,[iddistrito]
                              FROM [dbo].[Cliente] where estado!='E'";
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
                            ClienteList.Add(new ClienteEntity()
                            {
                                idcliente = ManejoNulos.ManageNullInteger(dr["idcliente"]),
                                fecha_contrato = ManejoNulos.ManageNullDate(dr["fecha_contrato"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                nombre = ManejoNulos.ManageNullStr(dr["nombre"]),
                                apellido = ManejoNulos.ManageNullStr(dr["apellido"]),
                                dni_ruc = ManejoNulos.ManageNullStr(dr["dni_ruc"]),
                                telefono = ManejoNulos.ManageNullStr(dr["telefono"]),
                                celular = ManejoNulos.ManageNullStr(dr["celular"]),
                                correo = ManejoNulos.ManageNullStr(dr["correo"]),
                                direccion = ManejoNulos.ManageNullStr(dr["direccion"]),
                                iddistrito = ManejoNulos.ManageNullInteger(dr["iddistrito"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ClienteList;
        }
        public ClienteEntity GetClienteByIdJson(int id)
        {
            ClienteEntity Cliente = new ClienteEntity();
            string SqlQuery = @"SELECT [idcliente]
                                  ,[fecha_contrato]
                                  ,[estado]
                                  ,[nombre]
                                  ,[apellido]
                                  ,[dni_ruc]
                                  ,[telefono]
                                  ,[celular]
                                  ,[correo]
                                  ,[direccion]
                                  ,[iddistrito]
                              FROM [dbo].[Cliente] where [idcliente]=@p0";
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
                            Cliente = new ClienteEntity()
                            {
                                idcliente = ManejoNulos.ManageNullInteger(dr["idcliente"]),
                                fecha_contrato = ManejoNulos.ManageNullDate(dr["fecha_contrato"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                nombre = ManejoNulos.ManageNullStr(dr["nombre"]),
                                apellido = ManejoNulos.ManageNullStr(dr["apellido"]),
                                dni_ruc = ManejoNulos.ManageNullStr(dr["dni_ruc"]),
                                telefono = ManejoNulos.ManageNullStr(dr["telefono"]),
                                celular = ManejoNulos.ManageNullStr(dr["celular"]),
                                correo = ManejoNulos.ManageNullStr(dr["correo"]),
                                direccion = ManejoNulos.ManageNullStr(dr["direccion"]),
                                iddistrito = ManejoNulos.ManageNullInteger(dr["iddistrito"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Cliente;
        }
        public ClienteEntity GetClienteByNroDniRucJson(string dni_ruc)
        {
            ClienteEntity Cliente = new ClienteEntity();
            string SqlQuery = @"SELECT [idcliente]
                                  ,[fecha_contrato]
                                  ,[estado]
                                  ,[nombre]
                                  ,[apellido]
                                  ,[dni_ruc]
                                  ,[telefono]
                                  ,[celular]
                                  ,[correo]
                                  ,[direccion]
                                  ,[iddistrito]
                              FROM [dbo].[Cliente] where [dni_ruc]=@p0";
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", dni_ruc);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cliente = new ClienteEntity()
                            {
                                idcliente = ManejoNulos.ManageNullInteger(dr["idcliente"]),
                                fecha_contrato = ManejoNulos.ManageNullDate(dr["fecha_contrato"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
                                nombre = ManejoNulos.ManageNullStr(dr["nombre"]),
                                apellido = ManejoNulos.ManageNullStr(dr["apellido"]),
                                dni_ruc = ManejoNulos.ManageNullStr(dr["dni_ruc"]),
                                telefono = ManejoNulos.ManageNullStr(dr["telefono"]),
                                celular = ManejoNulos.ManageNullStr(dr["celular"]),
                                correo = ManejoNulos.ManageNullStr(dr["correo"]),
                                direccion = ManejoNulos.ManageNullStr(dr["direccion"]),
                                iddistrito = ManejoNulos.ManageNullInteger(dr["iddistrito"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Cliente;
        }
        public int SaveClienteJson(ClienteEntity cliente)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[Cliente]
                                   ([fecha_contrato]
                                   ,[estado]
                                   ,[nombre]
                                   ,[apellido]
                                   ,[dni_ruc]
                                   ,[telefono]
                                   ,[celular]
                                   ,[correo]
                                   ,[direccion]
                                   ,[iddistrito])
                         OUTPUT INSERTED.idchip
                             VALUES
                                   (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullDate(cliente.fecha_contrato));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(cliente.estado.Trim()));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(cliente.nombre.Trim()));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullStr(cliente.apellido.Trim()));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullStr(cliente.dni_ruc.Trim()));
                    query.Parameters.AddWithValue("@p5", ManejoNulos.ManageNullStr(cliente.telefono.Trim()));
                    query.Parameters.AddWithValue("@p6", ManejoNulos.ManageNullStr(cliente.celular.Trim()));
                    query.Parameters.AddWithValue("@p7", ManejoNulos.ManageNullStr(cliente.correo.Trim()));
                    query.Parameters.AddWithValue("@p8", ManejoNulos.ManageNullStr(cliente.direccion.Trim()));
                    query.Parameters.AddWithValue("@p9", ManejoNulos.ManageNullInteger(cliente.iddistrito));
                    SavedId = (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditClienteJson(ClienteEntity cliente)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[Cliente]
                           SET [fecha_contrato] = @p0
                              ,[nombre] = @p1
                              ,[apellido] = @p2
                              ,[dni_ruc] = @p3
                              ,[telefono] = @p4
                              ,[celular] = @p5
                              ,[correo] = @p6
                              ,[direccion] = @p7
                              ,[iddistrito] = @p8
                         WHERE idcliente=@p9";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullDate(cliente.fecha_contrato));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(cliente.nombre.Trim()));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(cliente.apellido.Trim()));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullStr(cliente.dni_ruc.Trim()));
                    query.Parameters.AddWithValue("@p4", ManejoNulos.ManageNullStr(cliente.telefono.Trim()));
                    query.Parameters.AddWithValue("@p5", ManejoNulos.ManageNullStr(cliente.celular.Trim()));
                    query.Parameters.AddWithValue("@p6", ManejoNulos.ManageNullStr(cliente.correo.Trim()));
                    query.Parameters.AddWithValue("@p7", ManejoNulos.ManageNullStr(cliente.direccion.Trim()));
                    query.Parameters.AddWithValue("@p8", ManejoNulos.ManageNullInteger(cliente.iddistrito));
                    query.Parameters.AddWithValue("@p9", ManejoNulos.ManageNullInteger(cliente.idcliente));
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
        public bool EditStateofClienteJson(ClienteEntity cliente)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[Cliente]
                           SET 
                                [estado] = @p0
                         WHERE idcliente=@p1";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(cliente.estado.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullInteger(cliente.idcliente));
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