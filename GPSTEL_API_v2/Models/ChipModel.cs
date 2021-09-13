using GPSTEL_API_v2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GPSTEL_API_v2.Utilities;

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
                              ,[estado]
                          FROM [dbo].[CHIP] where estado!='E'";
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
                                idchip = ManejoNulos.ManageNullInteger(dr["idchip"]),
                                operador = ManejoNulos.ManageNullStr(dr["operador"]),
                                tipo_contrato = ManejoNulos.ManageNullStr(dr["tipo_contrato"]),
                                numero = ManejoNulos.ManageNullStr(dr["numero"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
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
                              ,[numero],[estado]
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
                                idchip = ManejoNulos.ManageNullInteger(dr["idchip"]),
                                operador = ManejoNulos.ManageNullStr(dr["operador"]),
                                tipo_contrato = ManejoNulos.ManageNullStr(dr["tipo_contrato"]),
                                numero = ManejoNulos.ManageNullStr(dr["numero"]),
                                estado = ManejoNulos.ManageNullStr(dr["estado"]),
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
                               ,[numero],[estado])
                            OUTPUT INSERTED.idchip
                         VALUES
                               (@p0
                               ,@p1
                               ,@p2,@p3)";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(chip.operador.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(chip.tipo_contrato.Trim()));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(chip.numero.Trim()));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullStr(chip.estado.Trim()));
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
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(chip.operador.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullStr(chip.tipo_contrato.Trim()));
                    query.Parameters.AddWithValue("@p2", ManejoNulos.ManageNullStr(chip.numero.Trim()));
                    query.Parameters.AddWithValue("@p3", ManejoNulos.ManageNullInteger(chip.idchip));
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
        public bool EditStateofChipJson(ChipEntity chip)
        {
            bool Edited = false;
            string SqlQuery = @"UPDATE [dbo].[CHIP]
                           SET 
                                [estado] = @p0
                         WHERE idchip=@p1";

            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    con.Open();
                    var query = new SqlCommand(SqlQuery, con);
                    query.Parameters.AddWithValue("@p0", ManejoNulos.ManageNullStr(chip.estado.Trim()));
                    query.Parameters.AddWithValue("@p1", ManejoNulos.ManageNullInteger(chip.idchip));
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