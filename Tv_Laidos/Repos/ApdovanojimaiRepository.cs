using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Tv_Laidos.Models;

namespace Tv_Laidos.Repos
{
    public class ApdovanojimaiRepository
    {
        public List<Apdovanojimas> getApdovanojimai(int id)
        {
            List<Apdovanojimas> apdovanojimai = new List<Apdovanojimas>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM apdovanojimas
                             WHERE fk_TV_LAIDAid_TV_LAIDA =" + id;
                            


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                apdovanojimai.Add(new Apdovanojimas
                {
                    id_APDOVANOJIMAS = Convert.ToInt32(item["id_APDOVANOJIMAS"]),
                    kategorija = Convert.ToString(item["kategorija"]),
                    nominantas = Convert.ToString(item["nominantas"]),
                    gavimo_metai = Convert.ToInt32(item["gavimo_metai"]),
                    fk_TV_LAIDAid_TV_LAIDA = Convert.ToInt32(item["fk_TV_LAIDAid_TV_LAIDA"])
                });
            }

            return apdovanojimai;
        }

        public bool addApdovanojimas(Apdovanojimas apdovanijimas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `apdovanojimas`(`kategorija`, `nominantas`, `gavimo_metai`, `id_APDOVANOJIMAS`, `fk_TV_LAIDAid_TV_LAIDA`)
                                  VALUES (?kategorija, ?nominantas, ?gavimo_metai, NULL, ?fk_TV_LAIDAid_TV_LAIDA)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?kategorija", MySqlDbType.VarChar).Value = apdovanijimas.kategorija;
            mySqlCommand.Parameters.Add("?nominantas", MySqlDbType.VarChar).Value = apdovanijimas.nominantas;
            mySqlCommand.Parameters.Add("?gavimo_metai", MySqlDbType.Int32).Value = apdovanijimas.gavimo_metai;
            mySqlCommand.Parameters.Add("?fk_TV_LAIDAid_TV_LAIDA", MySqlDbType.Int32).Value = apdovanijimas.fk_TV_LAIDAid_TV_LAIDA;


            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public bool updateApdovanojimas(Apdovanojimas apdovanijimas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery =  @"UPDATE `apdovanojimas` SET `kategorija`= ?kategorija,
                                 `nominantas`= ?nominantas,
                                 `gavimo_metai`= ?gavimo_metai,
                                 `fk_TV_LAIDAid_TV_LAIDA`= ?fk_TV_LAIDAid_TV_LAIDA
                                 WHERE id_APDOVANOJIMAS = " + apdovanijimas.id_APDOVANOJIMAS;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kategorija", MySqlDbType.VarChar).Value = apdovanijimas.kategorija;
            mySqlCommand.Parameters.Add("?nominantas", MySqlDbType.VarChar).Value = apdovanijimas.nominantas;
            mySqlCommand.Parameters.Add("?gavimo_metai", MySqlDbType.Int32).Value = apdovanijimas.gavimo_metai;
            mySqlCommand.Parameters.Add("?fk_TV_LAIDAid_TV_LAIDA", MySqlDbType.Int32).Value = apdovanijimas.fk_TV_LAIDAid_TV_LAIDA;

            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteApdovanojimas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM apdovanojimas WHERE fk_TV_LAIDAid_TV_LAIDA=?fk_TV_LAIDAid_TV_LAIDA";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_TV_LAIDAid_TV_LAIDA", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}