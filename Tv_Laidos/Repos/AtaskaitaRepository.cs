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
    public class AtaskaitaRepository
    {
        public List<SAtaskaitaViewModel> getAtaskaita(int? NuoMetai, int? IkiMetai, int? NuoReitingas, int? LaidosBusena)
        {
            List<SAtaskaitaViewModel> tvLaidos = new List<SAtaskaitaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT
                                tv_laida.pavadinimas,
                                tv_laida.ziurovu_vidutinis_ivertinimas AS ZiurovuIvertinimas,
                                tv_laida.isleidimo_metai AS Metai,
                                kat.name AS Zanras,
                                busena.name AS Laidos_Busena,

                                IFNULL(epInfo.EpizoduKiekis,-1) AS EpizoduKiekis,
                                IFNULL(ap.Apdovanojimu_Kiekis, -1) AS Apdovanojimu_Kiekis,
                                IFNULL(t.Kureju_Kiekis,-1) AS Kureju_Kiekis,

                                IFNULL(sezonas.sezono_numeris, -1) AS sezono_numeris,
                                IFNULL(sezonuInfo.SezonuKiekis, -1) AS SezonuKiekis,
                                IFNULL(sezonuInfo.MinSezIvertinimas, -1) AS MinSezIvertinimas,
                                IFNULL(sezonuInfo.MaxSezIvertinimas, -1) AS MaxSezIvertinimas,
                                IFNULL(sezonas.isleidimo_data, -1) AS IsleidimoData,
                                IFNULL(sezonas.pabaigos_data, -1) AS PabaigosData

                                FROM tv_laida LEFT JOIN sezonas
                                ON tv_laida.id_TV_LAIDA = sezonas.fk_TV_LAIDAid_TV_LAIDA

                                LEFT JOIN ( SELECT 
                                             IF(COUNT(kuria.fk_KUREJASid_KUREJAS) = 0, -1, COUNT(kuria.fk_KUREJASid_KUREJAS)) AS Kureju_Kiekis,
                                             kuria.fk_TV_LAIDAid_TV_LAIDA as Tv_Laida,
                                             tv.pavadinimas
                                            FROM kuria INNER JOIN tv_laida tv
                                             on kuria.fk_TV_LAIDAid_TV_LAIDA = tv.id_TV_LAIDA AND kuria.fk_KUREJASid_KUREJAS IS NOT NULL
                                            GROUP BY tv.pavadinimas) as t 
                                ON t.Tv_Laida = tv_laida.id_TV_LAIDA

                                LEFT JOIN (SELECT 
           	                                IF(COUNT(apd.id_APDOVANOJIMAS) = 0, -1, COUNT(apd.id_APDOVANOJIMAS)) AS Apdovanojimu_Kiekis,
           	                                apd.fk_TV_LAIDAid_TV_LAIDA AS TVID
                                           FROM apdovanojimas as apd INNER JOIN tv_laida tv
                                           ON apd.fk_TV_LAIDAid_TV_LAIDA = tv.id_TV_LAIDA
                                           GROUP BY apd.fk_TV_LAIDAid_TV_LAIDA) as ap
                                ON ap.TVID = tv_laida.id_TV_LAIDA

                                LEFT JOIN (SELECT 
			                                IF(COUNT(sez.id_SEZONAS) = 0, -1, COUNT(sez.id_SEZONAS)) AS SezonuKiekis,
                                            MIN(sez.ivertinimas) as MinSezIvertinimas,
			                                MAX(sez.ivertinimas) as MaxSezIvertinimas,
                                            sez.fk_TV_LAIDAid_TV_LAIDA as ID
                                           FROM sezonas as sez INNER JOIN tv_laida as tv
                                            ON sez.fk_TV_LAIDAid_TV_LAIDA = tv.id_TV_LAIDA
                                           GROUP BY sez.fk_TV_LAIDAid_TV_LAIDA) as sezonuInfo
                                ON sezonuInfo.ID = tv_laida.id_TV_LAIDA

                                LEFT JOIN (SELECT 
                                            COUNT(ep.id_EPIZODAS) as EpizoduKiekis,
           	                                ep.fk_SEZONASid_SEZONAS as ID
                                           FROM epizodas as ep INNER JOIN sezonas as sez
                                            ON ep.fk_SEZONASid_SEZONAS = sez.id_SEZONAS
                                           GROUP BY sez.fk_TV_LAIDAid_TV_LAIDA) as epInfo
                                ON epInfo.ID = sezonas.id_SEZONAS


                                LEFT JOIN kategorija AS kat 
                                ON tv_laida.zanras = kat.id_kategorija

                                INNER JOIN laidos_busena as busena
                                ON busena.id_laidos_busena = tv_laida.busena

                                WHERE tv_laida.ziurovu_vidutinis_ivertinimas >= ?ivertis AND YEAR(tv_laida.isleidimo_metai) >= ?metainuo AND  YEAR(tv_laida.isleidimo_metai) <= ?metaiiki AND tv_laida.busena = ?busena

                                GROUP BY sezonas.id_SEZONAS, tv_laida.id_TV_LAIDA
                                ORDER BY tv_laida.id_TV_LAIDA, sezonas.sezono_numeris";

            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?ivertis", MySqlDbType.Float).Value = NuoReitingas;
            mySqlCommand.Parameters.Add("?metainuo", MySqlDbType.Int32).Value = NuoMetai;
            mySqlCommand.Parameters.Add("?metaiiki", MySqlDbType.Int32).Value = IkiMetai;
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.Int32).Value = LaidosBusena;

            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                tvLaidos.Add(new SAtaskaitaViewModel
                {
                    ApdovanojimuKiekis = Convert.ToInt32(item["Apdovanojimu_Kiekis"]),
                    EpizoduSkaicius = Convert.ToInt32(item["EpizoduKiekis"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                    Metai = Convert.ToDateTime(item["Metai"]),
                    kurejuKiekis = Convert.ToInt32(item["Kureju_Kiekis"]),
                    Zanras = Convert.ToString(item["Zanras"]),
                    ZiurovuIvertinimas = (float)Convert.ToDouble(item["ZiurovuIvertinimas"]),
                    Laidos_Busena = Convert.ToString(item["Laidos_Busena"]),
                    SezonuKiekis = Convert.ToInt32(item["SezonuKiekis"]),
                    SezonoNumeris = Convert.ToInt32(item["sezono_numeris"]),
                    MinIvertinimas = Convert.ToInt32(item["MinSezIvertinimas"]),
                    MaxIvertinimas = Convert.ToInt32(item["MaxSezIvertinimas"]),
                    IsleidimoData = Convert.ToInt32(item["IsleidimoData"]),
                    PabaigosData = Convert.ToInt32(item["PabaigosData"])
                });
            }
            return tvLaidos;
        }
    }
}