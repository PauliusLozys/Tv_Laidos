using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Tv_Laidos.Models;

namespace Tv_Laidos.Repos
{
    public class SalisRepository
    {
        public List<Salis> getSalis()
        {
            List<Salis> salis = new List<Salis>();

            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT * FROM `salis`";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                salis.Add(new Salis
                {
                    id_SALIS = Convert.ToInt32(item["id_SALIS"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    gyventoju_skaicius = Convert.ToInt32(item["gyventoju_skaicius"])
                });
            }

            return salis;
        }

        public Salis getSalis(int id)
        {
            Salis salis = new Salis();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"SELECT *
                             FROM `salis`
                             WHERE id_SALIS  =" + id;

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                salis.id_SALIS = Convert.ToInt32(item["id_SALIS"]);
                salis.pavadinimas = Convert.ToString(item["pavadinimas"]);
                salis.gyventoju_skaicius = Convert.ToInt32(item["gyventoju_skaicius"]);

            }

            return salis;
        }

        public int addSalis(Salis salis)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `salis`(`pavadinimas`, `gyventoju_skaicius`, `id_SALIS`) 
                                        VALUES (?pavadinimas,?gyventoju_skaicius,NULL)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = salis.pavadinimas;
            mySqlCommand.Parameters.Add("?gyventoju_skaicius", MySqlDbType.Int32).Value = salis.gyventoju_skaicius;


            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);

            return insertedId;
        }

        public bool updateSalis(Salis salis)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `salis` SET 
                                        `pavadinimas`=?pavadinimas,
                                        `gyventoju_skaicius`=?gyventoju_skaicius
                                        WHERE id_SALIS =" + salis.id_SALIS;


            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = salis.pavadinimas;
            mySqlCommand.Parameters.Add("?gyventoju_skaicius", MySqlDbType.Int32).Value = salis.gyventoju_skaicius;

            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteSalis(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM salis WHERE id_SALIS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            //mySqlCommand.Parameters.Add("?id_SALIS", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}