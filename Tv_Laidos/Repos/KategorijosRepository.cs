using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Tv_Laidos.Models;

namespace Tv_Laidos.Repos
{
    public class KategorijosRepository
    {
        public List<Kategorija> getKategorija()
        {
            List<Kategorija> kategorijos = new List<Kategorija>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM kategorija";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kategorijos.Add(new Kategorija
                {
                    id_kategorija = Convert.ToInt32(item["id_kategorija"]),
                    name = Convert.ToString(item["name"])
                });
            }
            return kategorijos;
        }
    }
}