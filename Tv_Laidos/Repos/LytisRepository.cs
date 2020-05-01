using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Tv_Laidos.Models;

namespace Tv_Laidos.Repos
{
    public class LytisRepository
    {
        public List<Lytis> getLytis()
        {
            List<Lytis> lytis = new List<Lytis>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM lytis";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                lytis.Add(new Lytis
                {
                    id_lytis = Convert.ToInt32(item["id_lytis"]),
                    name = Convert.ToString(item["name"])
                });
            }

            return lytis;
        }
    }
}