using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Tv_Laidos.ViewModels;

namespace Tv_Laidos.Repos
{
    public class KurejaiRepository
    {
            public List<KurejasViewModel> getKurejai()
            {
                List<KurejasViewModel> kurejai = new List<KurejasViewModel>();
                string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
                string query = @"SELECT 
                                k.id_KUREJAS,
                                k.vardas,
                                k.pavarde,
                                k.gimimo_metai,
                                k.role,
                                l.name AS lytis
                            FROM kurejas k LEFT JOIN lytis l
                              on k.lytis = l.id_lytis";


                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlConnection.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                mySqlConnection.Close();


                foreach (DataRow item in dt.Rows)
                {
                    kurejai.Add(new KurejasViewModel
                    {
                        id_KUREJAS = Convert.ToInt32(item["id_KUREJAS"]),
                        vardas = Convert.ToString(item["vardas"]),
                        pavarde = Convert.ToString(item["pavarde"]),
                        gimimo_metai = Convert.ToDateTime(item["gimimo_metai"]),
                        role = Convert.ToString(item["role"]),
                        lytis = Convert.ToString(item["lytis"])
                    });
                }

                return kurejai;
            }

            public KurejasEditViewModel getKurejas(int id)
            {
            KurejasEditViewModel kurejas = new KurejasEditViewModel();

                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);

                string query = @"SELECT 
                                k.id_KUREJAS,
                                k.vardas,
                                k.pavarde,
                                k.gimimo_metai,
                                k.role,
                                k.lytis
                            FROM kurejas k
                            WHERE k.id_KUREJAS =" + id;

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlConnection.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                mySqlConnection.Close();

                foreach (DataRow item in dt.Rows)
                {
                    kurejas.id_KUREJAS = Convert.ToInt32(item["id_KUREJAS"]);
                    kurejas.vardas = Convert.ToString(item["vardas"]);
                    kurejas.pavarde = Convert.ToString(item["pavarde"]);
                    kurejas.gimimo_metai = Convert.ToDateTime(item["gimimo_metai"]);
                    kurejas.role = Convert.ToString(item["role"]);
                    kurejas.lytis = Convert.ToInt32(item["lytis"]);
                }

                return kurejas;
            }

            public int addKurejas(KurejasEditViewModel kurejas)
            {
                int insertedId = -1;
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);

                string query = @"INSERT INTO `kurejas`(`vardas`, `pavarde`, `gimimo_metai`, `role`, `lytis`, `id_KUREJAS`) 
                                VALUES (?vardas,?pavarde,?gimimo_metai,?role,?lytis, NULL)";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = kurejas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = kurejas.pavarde;
                mySqlCommand.Parameters.Add("?gimimo_metai", MySqlDbType.Date).Value = kurejas.gimimo_metai;
                mySqlCommand.Parameters.Add("?role", MySqlDbType.VarChar).Value = kurejas.role;
                mySqlCommand.Parameters.Add("?lytis", MySqlDbType.Int32).Value = kurejas.lytis;


                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);

                return insertedId;
            }

            public bool updateKurejas(KurejasEditViewModel kurejas)
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE `kurejas` SET 
                                        `vardas`= ?vardas,
                                        `pavarde`= ?pavarde,
                                        `gimimo_metai`= ?gimimo_metai,
                                        `lytis` = ?lytis,
                                        `role` = ?role
                                        WHERE id_KUREJAS =" + kurejas.id_KUREJAS;


                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = kurejas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = kurejas.pavarde;
                mySqlCommand.Parameters.Add("?gimimo_metai", MySqlDbType.Date).Value = kurejas.gimimo_metai;
                mySqlCommand.Parameters.Add("?lytis", MySqlDbType.Int32).Value = kurejas.lytis;
                mySqlCommand.Parameters.Add("?role", MySqlDbType.VarChar).Value = kurejas.role;

                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                return true;
            }

            public void deleteKurejas(int id)
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"DELETE FROM kurejas WHERE id_KUREJAS=?id_KUREJAS";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id_KUREJAS", MySqlDbType.Int32).Value = id;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }
}