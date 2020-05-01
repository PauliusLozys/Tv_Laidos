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
    public class KuriaRepository
    {
        public List<Kuria> getKuria(int kurejo_id)
        {
            List<Kuria> kuriamos = new List<Kuria>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM kuria
                              WHERE fk_KUREJASid_KUREJAS ="+kurejo_id;


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                kuriamos.Add(new Kuria
                {
                    fk_KUREJASid_KUREJAS = Convert.ToInt32(item["fk_KUREJASid_KUREJAS"]),
                    fk_TV_LAIDAid_TV_LAIDA = Convert.ToInt32(item["fk_TV_LAIDAid_TV_LAIDA"])
                });
            }

            return kuriamos;
        }

        public bool addKuriamas(Kuria kurimas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `kuria`(`fk_TV_LAIDAid_TV_LAIDA`, `fk_KUREJASid_KUREJAS`) 
                            VALUES (?fk_TV_LAIDAid_TV_LAIDA,?fk_KUREJASid_KUREJAS)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_TV_LAIDAid_TV_LAIDA", MySqlDbType.Int32).Value = kurimas.fk_TV_LAIDAid_TV_LAIDA;
            mySqlCommand.Parameters.Add("?fk_KUREJASid_KUREJAS", MySqlDbType.Int32).Value = kurimas.fk_KUREJASid_KUREJAS;



            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteKuria(int Kurejo_id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM kuria WHERE fk_KUREJASid_KUREJAS=?fk_KUREJASid_KUREJAS";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_KUREJASid_KUREJAS", MySqlDbType.Int32).Value = Kurejo_id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}