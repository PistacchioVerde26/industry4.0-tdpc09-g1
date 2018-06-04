using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code.Dao
{
    public class daoLavorazioni
    {
        public daoLavorazioni() { }

        public List<Lavorazione> GetByOrdineID(int ID)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT Lavorazioni.*, OpzioniLavorazione.opzione, TipoLavorazione.*, Ordini.data
                                            FROM Lavorazioni
                                            INNER JOIN OpzioniLavorazione ON OpzioniLavorazione.idopz = Lavorazioni.fk_opzione
                                            INNER JOIN TipoLavorazione ON TipoLavorazione.idtipolav = OpzioniLavorazione.fk_idtipolavorazione
                                            INNER JOIN Ordini ON Ordini.idordine = Lavorazioni.fkordine
                                            WHERE Lavorazioni.fkordine = {0}", ID);

            DataTable dt = db.eseguiQuery(cmd);
            List<Lavorazione> lavorazioni = new List<Lavorazione>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //int ID, TipoLavorazione Tipo, string Opzione, int OpzioneID, string Note, DateTime Inizio, DateTime Fine, int Stato
                    Lavorazione newLav = new Lavorazione();
                    newLav.ID = (int)dr["idlavorazione"];
                    newLav.Tipo = new TipoLavorazione((int)dr["idtipolav"], (string)dr["descrizione"]);
                    newLav.Opzione = (string)dr["opzione"];
                    newLav.OpzioneID = (int)dr["fk_opzione"];
                    newLav.Note = (string)dr["note"];
                    newLav.Inizio = dr.IsNull("inizio") ? default(DateTime) : (DateTime)dr["inizio"];
                    newLav.Fine = dr.IsNull("fine") ? default(DateTime) : (DateTime)dr["fine"];
                    newLav.Stato = (int)dr["stato"];
                    newLav.OrdineID = (int)dr["fkordine"];
                    newLav.PostazioneID = dr.IsNull("fk_postazione") ? -1 : (int)dr["fk_postazione"];
                    newLav.DataOrdine = (DateTime)dr["data"];
                    lavorazioni.Add(newLav);
                }
            }

            return lavorazioni;
        }

        public List<Lavorazione> GetForPostazione(Postazione P)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT *
                                            FROM (SELECT Lavorazioni.*, OpzioniLavorazione.opzione, TipoLavorazione.*, Ordini.data AS DataOrdine
		                                            FROM Lavorazioni
		                                            INNER JOIN OpzioniLavorazione ON OpzioniLavorazione.idopz = Lavorazioni.fk_opzione
		                                            INNER JOIN TipoLavorazione ON TipoLavorazione.idtipolav = OpzioniLavorazione.fk_idtipolavorazione
		                                            INNER JOIN Ordini ON Ordini.idordine = Lavorazioni.fkordine 
		                                            WHERE stato = 0 OR (stato = 1 AND fk_postazione = {1})) AS SUBQUERY
                                            WHERE descrizione = '{0}' AND ((stato = 0 AND inizio IS NULL) OR (stato = 1 AND fk_postazione = {1}))
                                            ORDER BY stato DESC, DataOrdine", P.Tipo, P.ID);

            DataTable dt = db.eseguiQuery(cmd);
            List<Lavorazione> lavorazioni = new List<Lavorazione>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //int ID, TipoLavorazione Tipo, string Opzione, int OpzioneID, string Note, DateTime Inizio, DateTime Fine, int Stato
                    Lavorazione newLav = new Lavorazione();
                    newLav.ID = (int)dr["idlavorazione"];
                    newLav.Tipo = new TipoLavorazione((int)dr["idtipolav"], (string)dr["descrizione"]);
                    newLav.Opzione = (string)dr["opzione"];
                    newLav.OpzioneID = (int)dr["fk_opzione"];
                    newLav.Note = (string)dr["note"];
                    newLav.Inizio = dr.IsNull("inizio") ? default(DateTime) : (DateTime)dr["inizio"];
                    newLav.Fine = dr.IsNull("fine") ? default(DateTime) : (DateTime)dr["fine"];
                    newLav.Stato = (int)dr["stato"];
                    newLav.DataOrdine = (DateTime)dr["DataOrdine"];
                    lavorazioni.Add(newLav);
                }
            }

            return lavorazioni;
        }

        public int AddNew(Lavorazione L)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            int OpzioneID = L.OpzioneID == -1 ? AddNewOpzione(L.Tipo, L.Opzione) : L.OpzioneID;
            cmd.CommandText = String.Format(@"INSERT dbo.Lavorazioni
                                            (
                                                fkordine,
                                                fk_opzione,
                                                note,
                                                stato
                                            )
                                            VALUES
                                            (
                                                {0},
                                                {1},
                                                '{2}',
                                                0
                                            );
                                            SELECT SCOPE_IDENTITY();", L.OrdineID, OpzioneID, L.Note, L.Stato);
            return db.eseguiInsertIDreturn(cmd);
            //SELECT SCOPE_IDENTITY();
        }

        public int AddNewOpzione(TipoLavorazione TipoLav, string Opzione)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"INSERT OpzioniLavorazione
                                            (
                                                opzione,
                                                fk_idtipolavorazione
                                            )
                                            VALUES
                                            (   '{0}', -- opzione - varchar(255)
                                                {1}   -- fk_idtipolavorazione - int
                                            );
                                            SELECT SCOPE_IDENTITY();", Opzione, TipoLav.ID);

            return db.eseguiInsertIDreturn(cmd);
        }

        public void AggiornaStato(Lavorazione L, int PostazioneID)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            if (PostazioneID == -1)
            {
                cmd.CommandText = String.Format(@"UPDATE Lavorazioni
                                                SET stato = {0}, fk_postazione = NULL
                                                WHERE idlavorazione = {1}", L.ID, L.Stato);
            }
            else
            {
                string query = "UPDATE Lavorazioni ";
                if(L.Inizio.Equals(default(DateTime)) && !L.Fine.Equals(default(DateTime))) query += String.Format("SET stato = {0}, fk_postazione = {1}, fine = CAST('{2}' AS DATETIME) ", L.Stato, PostazioneID, L.Fine);
                else if(!L.Inizio.Equals(default(DateTime)) && L.Fine.Equals(default(DateTime))) query += String.Format("SET stato = {0}, fk_postazione = {1}, inizio = CAST('{2}' AS DATETIME) ", L.Stato, PostazioneID, L.Inizio);
                else if(!L.Inizio.Equals(default(DateTime)) && !L.Fine.Equals(default(DateTime))) query += String.Format("SET stato = {0}, fk_postazione = {1}, inizio = CAST('{2}' AS DATETIME), fine = CAST('{3}' AS DATETIME) ", L.Stato, PostazioneID, L.Inizio, L.Fine);
                else query += String.Format("SET stato = {0}, fk_postazione = {1}", L.Stato, PostazioneID);
                query += String.Format("WHERE idlavorazione = {0}", L.ID);

                cmd.CommandText = query;
            }

            db.eseguiQueryNOreturn(cmd);
        }

        public List<Ordine> GetAllOrdiniCompleto()
        {
            Ordine Or = new Ordine();
            Lavorazione Lav = new Lavorazione();
            List<Ordine> listaOr = new List<Ordine>();

            DataTable dt = new DataTable();
            DataTable tempDT = new DataTable();

            DbEntity db = new DbEntity();
            SqlCommand cmd = new SqlCommand();

            List<int> oID = new List<int>();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from ordini";



            dt = db.eseguiQuery(cmd);

            foreach (DataRow row in dt.Rows)
            {
                Or = new Ordine();
                Or.ID = (int)row["idordine"];
                Or.DataInserimento = (DateTime)row["data"];
                Or.UtenteID = (int)row["fk_utente"];

                cmd.CommandText = string.Format(@"select ordini.idordine, ordini.data, lavorazioni.idlavorazione, lavorazioni.stato, opzionilavorazione.opzione 
                                                from ordini inner join lavorazioni on lavorazioni.fkordine = ordini.idordine 
                                                inner join opzionilavorazione on opzionilavorazione.idopz = lavorazioni.fk_opzione 
                                                where ordini.idordine = {0} order by lavorazioni.idlavorazione", Or.ID.ToString());

                tempDT = db.eseguiQuery(cmd);

                foreach (DataRow dr in tempDT.Rows)
                {
                    Lav = new Lavorazione();
                    Lav.ID = (int)dr["idlavorazione"];
                    Lav.Stato = (int)dr["stato"];
                    Lav.Note = (string)dr["opzione"];
                    Or.Lavorazioni.Add(Lav);
                }
                //oID.Add((int)row["idordine"]);
                listaOr.Add(Or);
            }


            return listaOr;
        }

        public List<Ordine> GetOrdiniLavoro()
        {
            Ordine Or = new Ordine();
            Lavorazione Lav = new Lavorazione();
            List<Ordine> listaOr = new List<Ordine>();

            DataTable dt = new DataTable();
            DataTable tempDT = new DataTable();

            DbEntity db = new DbEntity();
            SqlCommand cmd = new SqlCommand();

            List<int> oID = new List<int>();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from ordini";



            dt = db.eseguiQuery(cmd);

            foreach (DataRow row in dt.Rows)
            {
                Or = new Ordine();
                Or.ID = (int)row["idordine"];
                Or.DataInserimento = (DateTime)row["data"];
                Or.UtenteID = (int)row["fk_utente"];

                cmd.CommandText = string.Format(@"select * from ordini inner join lavorazioni on lavorazioni.fkordine=ordini.idordine 
                                                    inner join opzionilavorazione on opzionilavorazione.idopz = lavorazioni.fk_opzione
                                                    inner join tipolavorazione on tipolavorazione.idtipolav=opzionilavorazione.fk_idtipolavorazione where ordini.idordine={0}", Or.ID);

                tempDT = db.eseguiQuery(cmd);


                foreach (DataRow dr in tempDT.Rows)
                {
                    Lav = new Lavorazione();
                    Lav.ID = (int)dr["idlavorazione"];
                    Lav.Note = (string)dr["opzione"];
                    Lav.Tipo = new TipoLavorazione((int)dr["idtipolav"], (string)dr["descrizione"]);
                    Lav.Opzione = (string)dr["opzione"];
                    Lav.OpzioneID = (int)dr["fk_opzione"];

                    Lav.Inizio = dr.IsNull("inizio") ? default(DateTime) : (DateTime)dr["inizio"];
                    Lav.Fine = dr.IsNull("fine") ? default(DateTime) : (DateTime)dr["fine"];
                    Lav.Stato = (int)dr["stato"];
                    Lav.OrdineID = (int)dr["fkordine"];
                    Lav.PostazioneID = dr.IsNull("fk_postazione") ? -1 : (int)dr["fk_postazione"];
                    Lav.DataOrdine = (DateTime)dr["data"];

                    Or.Lavorazioni.Add(Lav);
                }
                //oID.Add((int)row["idordine"]);
                listaOr.Add(Or);
            }


            return listaOr;

        }
        public void DeleteByOrderID(int fkordine)
        {
            DbEntity db = new DbEntity();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format( "delete from lavorazioni where fkordine={0}", fkordine.ToString());
            dt = db.eseguiQuery(cmd);
        }
    }

}