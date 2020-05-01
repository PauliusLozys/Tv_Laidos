using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Tv_Laidos.Models;

namespace Tv_Laidos.Repos
{
    public class AmziausCenzaiRepository
    {
        public List<AmziausCenzas> getAmziausCenzai()
        {
            List<AmziausCenzas> cenzai = new List<AmziausCenzas>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM amziaus_cenzas";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                cenzai.Add(new AmziausCenzas
                {
                    id_amziaus_cenzas = Convert.ToInt32(item["id_amziaus_cenzas"]),
                    name = Convert.ToString(item["name"])
                });
            }

            return cenzai;
        }
    }
}