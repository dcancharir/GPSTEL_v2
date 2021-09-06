using GPSTEL_API_v2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Models
{
    public class ChipModel
    {
        string _connection = string.Empty;

        public ChipModel()
        {
            _connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; ;
        }
        public List<ChipEntity> GetChipsJson()
        {
            List<ChipEntity> ChipList = new List<ChipEntity>();
            string SqlQuery = @"SELECT [idchip]
                              ,[operador]
                              ,[tipo_contrato]
                              ,[numero]
                          FROM [dbo].[CHIP]";
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
                            ChipList.Add(new ChipEntity() {
                                idchip = (int)dr["idchip"],
                                operador = (string)dr["operador"],
                                tipo_contrato = (string)dr["tipo_contrato"],
                                numero = (string)dr["numero"],
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ChipList;
        }
        public ChipEntity GetChipByIdJson(int id)
        {
            ChipEntity Chip = new ChipEntity();
            string SqlQuery = @"SELECT [idchip]
                              ,[operador]
                              ,[tipo_contrato]
                              ,[numero]
                          FROM [dbo].[CHIP] where [idchip]=@p0";
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
                           Chip=new ChipEntity()
                            {
                                idchip = (int)dr["idchip"],
                                operador = (string)dr["operador"],
                                tipo_contrato = (string)dr["tipo_contrato"],
                                numero = (string)dr["numero"],
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Chip;
        }
        public int SaveChipJson(ChipEntity chip)
        {
            int SavedId = 0;
            string SqlQuery = @"INSERT INTO [dbo].[CHIP]
                               ([operador]
                               ,[tipo_contrato]
                               ,[numero])
                            OUTPUT INSERTED.idchip
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
                    query.Parameters.AddWithValue("@p0",chip.operador.Trim());
                    query.Parameters.AddWithValue("@p1",chip.tipo_contrato.Trim());
                    query.Parameters.AddWithValue("@p2",chip.numero.Trim());
                    SavedId= (int)query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                SavedId = 0;
            }

            return SavedId;
        }
        public bool EditChipJson(ChipEntity chip)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[CHIP]
                           SET [operador] = @p0
                              ,[tipo_contrato] = @p1
                                ,[numero] = @p2
                         WHERE idchip=@p3";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", chip.operador.Trim());
                    query.Parameters.AddWithValue("@p1", chip.tipo_contrato.Trim());
                    query.Parameters.AddWithValue("@p2", chip.numero.Trim());
                    query.Parameters.AddWithValue("@p3", chip.idchip);
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