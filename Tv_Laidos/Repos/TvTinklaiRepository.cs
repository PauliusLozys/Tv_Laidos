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
    public class TvTinklaiRepository
    {
        public List<TvTinklaiViewModel> getTvTinklai()
        {
            List<TvTinklaiViewModel> tvTinklai = new List<TvTinklaiViewModel>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT
                                a.pavadinimas,
                                a.adresas,
                                a.ziurovu_skaicius,
                                a.savininkas,
                                a.vadovas,
                                a.id_TV_TINKLAS,
                                s.pavadinimas AS salis
                                FROM tv_tinklas a LEFT JOIN salis s
                                ON s.id_SALIS = a.fk_SALISid_SALIS";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                tvTinklai.Add(new TvTinklaiViewModel
                {
                    id_TV_TINKLAS= Convert.ToInt32(item["id_TV_TINKLAS"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    adresas = Convert.ToString(item["adresas"]),
                    savininkas = Convert.ToString(item["savininkas"]),
                    vadovas = Convert.ToString(item["vadovas"]),
                    ziurovu_skaicius = Convert.ToInt32(item["ziurovu_skaicius"]),
                    fk_SALIS_id_SALIS = Convert.ToString(item["salis"])
                });
            }

            return tvTinklai;
        }

        public TvTinklas getTvTinklas(int id)
        {
            TvTinklas kurejas = new TvTinklas();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"SELECT *
                             FROM `tv_tinklas`
                             WHERE id_TV_TINKLAS  =" + id;

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kurejas.id_TV_TINKLAS = Convert.ToInt32(item["id_TV_TINKLAS"]);
                kurejas.pavadinimas = Convert.ToString(item["pavadinimas"]);
                kurejas.adresas = Convert.ToString(item["adresas"]);
                kurejas.savininkas = Convert.ToString(item["savininkas"]);
                kurejas.vadovas = Convert.ToString(item["vadovas"]);
                kurejas.ziurovu_skaicius = Convert.ToInt32(item["ziurovu_skaicius"]);
                kurejas.fk_SALIS_id_SALIS = Convert.ToInt32(item["fk_SALISid_SALIS"]);
            }

            return kurejas;
        }

        public int addTvTinklas(TvTinklas tvTinklas)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `tv_tinklas`(`pavadinimas`, `adresas`, `ziurovu_skaicius`, `savininkas`, `vadovas`, `id_TV_TINKLAS`, `fk_SALISid_SALIS`) 
                                VALUES (?pavadinimas,?adresas,?ziurovu_skaicius,?savininkas,?vadovas,NULL,?fk_SALISid_SALIS)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = tvTinklas.pavadinimas;
            mySqlCommand.Parameters.Add("?adresas", MySqlDbType.VarChar).Value = tvTinklas.adresas;
            mySqlCommand.Parameters.Add("?ziurovu_skaicius", MySqlDbType.Int32).Value = tvTinklas.ziurovu_skaicius;
            mySqlCommand.Parameters.Add("?savininkas", MySqlDbType.VarChar).Value = tvTinklas.savininkas;
            mySqlCommand.Parameters.Add("?vadovas", MySqlDbType.VarChar).Value = tvTinklas.vadovas;
            mySqlCommand.Parameters.Add("?fk_SALISid_SALIS", MySqlDbType.Int32).Value = tvTinklas.fk_SALIS_id_SALIS;


            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);

            return insertedId;
        }

        public bool updateTvTinklas(TvTinklas tvTinklas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `tv_tinklas` SET 
                                        `pavadinimas`=?pavadinimas,
                                        `adresas`=?adresas,
                                        `ziurovu_skaicius`=?ziurovu_skaicius,
                                        `savininkas`=?savininkas,
                                        `vadovas`=?vadovas,
                                        `fk_SALISid_SALIS`=?fk_SALISid_SALIS
                                        WHERE id_TV_TINKLAS =" + tvTinklas.id_TV_TINKLAS;


            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = tvTinklas.pavadinimas;
            mySqlCommand.Parameters.Add("?adresas", MySqlDbType.VarChar).Value = tvTinklas.adresas;
            mySqlCommand.Parameters.Add("?ziurovu_skaicius", MySqlDbType.Int32).Value = tvTinklas.ziurovu_skaicius;
            mySqlCommand.Parameters.Add("?savininkas", MySqlDbType.VarChar).Value = tvTinklas.savininkas;
            mySqlCommand.Parameters.Add("?vadovas", MySqlDbType.VarChar).Value = tvTinklas.vadovas;
            mySqlCommand.Parameters.Add("?fk_SALISid_SALIS", MySqlDbType.Int32).Value = tvTinklas.fk_SALIS_id_SALIS;

            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deletetvTinklas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM tv_tinklas WHERE id_TV_TINKLAS=?id_TV_TINKLAS";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_TV_TINKLAS", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}