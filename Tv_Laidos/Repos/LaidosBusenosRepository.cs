using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Tv_Laidos.Models;

namespace Tv_Laidos.Repos
{
    public class LaidosBusenosRepository
    {
        public List<LaidosBusena> getLaidosBusenos()
        {
            List<LaidosBusena> busenos = new List<LaidosBusena>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM laidos_busena";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                busenos.Add(new LaidosBusena
                {
                    id_laidos_busena = Convert.ToInt32(item["id_laidos_busena"]),
                    name = Convert.ToString(item["name"])
                });
            }

            return busenos;
        }
    }
}