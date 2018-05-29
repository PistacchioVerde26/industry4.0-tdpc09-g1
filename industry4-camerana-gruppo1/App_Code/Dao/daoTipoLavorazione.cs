using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code.Dao
{
    public class daoTipoLavorazione
    {
        public daoTipoLavorazione() { }

        public TipoLavorazione GetByTipo(string Tipo)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT *
                                            FROM TipoLavorazione 
                                            WHERE descrizione = '{0}'", Tipo);

            DataTable dt = db.eseguiQuery(cmd);

            TipoLavorazione TipoLav = null;

            if (dt.Rows.Count > 0)
            {
                TipoLav = new TipoLavorazione();

                TipoLav.ID = (int)dt.Rows[0]["idtipolav"];
                TipoLav.Descrizione = (string)dt.Rows[0]["descrizione"];

                //Non c'è bisogno di caricare le opzioni per la lavorazione di etichettatura
                if (TipoLav.Descrizione == "etichettatura") return TipoLav;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format(@"SELECT *
                                            FROM OpzioniLavorazione 
                                            WHERE fk_idtipolavorazione = '{0}'", TipoLav.ID);

                DataTable dt2 = db.eseguiQuery(cmd);

                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt2.Rows)
                    {
                        TipoLav.Opzioni.Add((int)dr["idopz"], (string)dr["opzione"]);
                    }
                }
            }

            return TipoLav;
        }

    }

}