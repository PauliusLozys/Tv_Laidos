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
    public class TvLaidosRepository
    {
        public List<TvLaidaViewModel> getShows()
        {
            List<TvLaidaViewModel> laidos = new List<TvLaidaViewModel>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT a.id_TV_LAIDA,
                                    a.pavadinimas,
                                    a.isleidimo_metai,
                                    b.name AS cenzas
                            FROM tv_laida a LEFT JOIN amziaus_cenzas b
                                ON b.id_amziaus_cenzas = a.amziaus_reikalavimas";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                laidos.Add(new TvLaidaViewModel
                {
                    id = Convert.ToInt32(item["id_TV_LAIDA"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    isleidimo_metai = Convert.ToDateTime(item["isleidimo_metai"]),
                    amziaus_reikalavimas = Convert.ToString(item["cenzas"])
                });
            }

            return laidos;
        }

        public TvLaidaEditViewModel getShow(int id)
        {
            TvLaidaEditViewModel modelis = new TvLaidaEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"SELECT 
                                a.id_TV_LAIDA,
                                a.pavadinimas,
                                a.trukme,
                                a.isleidimo_metai,
                                a.reitingai,
                                a.ziurovu_vidutinis_ivertinimas,
                                a.aprasymas,
                                a.busena,
                                a.zanras,
                                a.amziaus_reikalavimas
                            FROM tv_laida a
                            WHERE a.id_TV_LAIDA =" + id;

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelis.id_TV_LAIDA = Convert.ToInt32(item["id_TV_LAIDA"]) ;
                modelis.pavadinimas = Convert.ToString(item["pavadinimas"]);
                modelis.trukme = Convert.ToInt32(item["trukme"]);
                modelis.isleidimo_metai = Convert.ToDateTime(item["isleidimo_metai"]);
                modelis.reitingai = (float)Convert.ToDouble(item["reitingai"]);
                modelis.ziurovu_vidutinis_ivertinimas = (float)Convert.ToDouble(item["ziurovu_vidutinis_ivertinimas"]);
                modelis.aprasymas = Convert.ToString(item["aprasymas"]);
                modelis.busena = Convert.ToInt32(item["busena"]);
                modelis.zanras = Convert.ToInt32(item["zanras"]);
                modelis.amziaus_reikalavimas = Convert.ToInt32(item["amziaus_reikalavimas"]);
            }

            return modelis;
        }

        public int addShow(TvLaidaEditViewModel laida)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `tv_laida` (`pavadinimas`, `trukme`, `isleidimo_metai`, `reitingai`, `ziurovu_vidutinis_ivertinimas`, `aprasymas`, `busena`, `zanras`, `amziaus_reikalavimas`, `id_TV_LAIDA`)
                                VALUES(?pavadinimas, ?trukme, ?isleidimo_metai, ?reitingai, ?ziurovu_vidutinis_ivertinimas, ?aprasymas, ?busena, ?zanras, ?amziaus_reikalavimas, NULL)";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = laida.pavadinimas;
            mySqlCommand.Parameters.Add("?trukme", MySqlDbType.Int32).Value = laida.trukme;
            mySqlCommand.Parameters.Add("?isleidimo_metai", MySqlDbType.Date).Value = laida.isleidimo_metai;
            mySqlCommand.Parameters.Add("?reitingai", MySqlDbType.Float).Value = laida.reitingai;
            mySqlCommand.Parameters.Add("?ziurovu_vidutinis_ivertinimas", MySqlDbType.Float).Value = laida.ziurovu_vidutinis_ivertinimas;
            mySqlCommand.Parameters.Add("?aprasymas", MySqlDbType.VarChar).Value = laida.aprasymas;
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.Int32).Value = laida.busena;
            mySqlCommand.Parameters.Add("?zanras", MySqlDbType.Int32).Value = laida.zanras;
            mySqlCommand.Parameters.Add("?amziaus_reikalavimas", MySqlDbType.Int32).Value = laida.amziaus_reikalavimas;

            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);
            return insertedId;
        }

        public bool updateShow(TvLaidaEditViewModel laida)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `tv_laida` SET
                                    `pavadinimas` = ?pavadinimas,
                                    `trukme` = ?trukme,
                                    `isleidimo_metai` = ?isleidimo_metai,
                                    `reitingai` = ?reitingai,
                                    `ziurovu_vidutinis_ivertinimas` = ?ziurovu_vidutinis_ivertinimas,
                                    `aprasymas` = ?aprasymas,
                                    `busena` = ?busena,
                                    `zanras` = ?zanras,
                                    `amziaus_reikalavimas` = ?amziaus_reikalavimas
                                    WHERE id_TV_LAIDA =" + laida.id_TV_LAIDA;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = laida.pavadinimas;
            mySqlCommand.Parameters.Add("?trukme", MySqlDbType.Int32).Value = laida.trukme;
            mySqlCommand.Parameters.Add("?isleidimo_metai", MySqlDbType.Date).Value = laida.isleidimo_metai;
            mySqlCommand.Parameters.Add("?reitingai", MySqlDbType.Float).Value = laida.reitingai;
            mySqlCommand.Parameters.Add("?ziurovu_vidutinis_ivertinimas", MySqlDbType.Float).Value = laida.ziurovu_vidutinis_ivertinimas;
            mySqlCommand.Parameters.Add("?aprasymas", MySqlDbType.VarChar).Value = laida.aprasymas;
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.Int32).Value = laida.busena;
            mySqlCommand.Parameters.Add("?zanras", MySqlDbType.Int32).Value = laida.zanras;
            mySqlCommand.Parameters.Add("?amziaus_reikalavimas", MySqlDbType.Int32).Value = laida.amziaus_reikalavimas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteShow(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM tv_laida where id_TV_LAIDA=?id_TV_LAIDA";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_TV_LAIDA", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}