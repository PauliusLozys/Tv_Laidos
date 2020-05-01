using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Tv_Laidos.Models;
using Tv_Laidos.ViewModels;

namespace Tv_Laidos.Repos
{
    public class AktoriaiRepository
    {
        public List<AktoriusViewModel> getAktoriai()
        {
            List<AktoriusViewModel> aktoriai = new List<AktoriusViewModel>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT 
                                a.id_AKTORIUS,
                                a.vardas,
                                a.pavarde,
                                a.gimimo_metai,
                                l.name AS lytis
                            FROM aktorius a LEFT JOIN lytis l
                              on a.lytis = l.id_lytis";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                aktoriai.Add(new AktoriusViewModel
                {
                    id_AKTORIUS = Convert.ToInt32(item["id_AKTORIUS"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    gimino_metai = Convert.ToDateTime(item["gimimo_metai"]),
                    lytis = Convert.ToString(item["lytis"])
                });
            }

            return aktoriai;
        }

        public AktoriusEditViewModel getAktorius(int id)
        {
            AktoriusEditViewModel aktorius = new AktoriusEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"SELECT 
                                a.id_AKTORIUS,
                                a.vardas,
                                a.pavarde,
                                a.gimimo_metai,
                                a.lytis
                            FROM aktorius a
                            WHERE a.id_AKTORIUS =" + id;

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                aktorius.id_AKTORIUS = Convert.ToInt32(item["id_AKTORIUS"]);
                aktorius.vardas = Convert.ToString(item["vardas"]);
                aktorius.pavarde = Convert.ToString(item["pavarde"]);
                aktorius.gimimo_metai = Convert.ToDateTime(item["gimimo_metai"]);
                aktorius.lytis = Convert.ToInt32(item["lytis"]);
            }

            return aktorius;
        }

        public bool addAktorius(AktoriusEditViewModel aktorius)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `aktorius`(`vardas`, `pavarde`, `gimimo_metai`, `lytis`, `id_AKTORIUS`) 
                                VALUES (?vardas,?pavarde,?gimimo_metai,?lytis, NULL)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = aktorius.vardas;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = aktorius.pavarde;
            mySqlCommand.Parameters.Add("?gimimo_metai", MySqlDbType.Date).Value = aktorius.gimimo_metai;
            mySqlCommand.Parameters.Add("?lytis", MySqlDbType.Int32).Value = aktorius.lytis;


            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public bool updateAktorius(AktoriusEditViewModel aktorius)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `aktorius` SET 
                                        `vardas`= ?vardas,
                                        `pavarde`= ?pavarde,
                                        `gimimo_metai`= ?gimimo_metai,
                                        `lytis` = ?lytis
                                        WHERE id_AKTORIUS =" + aktorius.id_AKTORIUS;


            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = aktorius.vardas;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = aktorius.pavarde;
            mySqlCommand.Parameters.Add("?gimimo_metai", MySqlDbType.Date).Value = aktorius.gimimo_metai;
            mySqlCommand.Parameters.Add("?lytis", MySqlDbType.Int32).Value = aktorius.lytis;

            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteAktorius(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM aktorius WHERE id_AKTORIUS=?id_AKTORIUS";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_AKTORIUS", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}