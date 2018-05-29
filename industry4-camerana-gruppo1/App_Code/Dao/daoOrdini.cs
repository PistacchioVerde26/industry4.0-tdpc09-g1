using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code.Dao
{
    public class daoOrdine
    {

        public daoOrdine() { }

        public Ordine GetOrdine(int ID)
        {

            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT Ordini.*
                                            FROM Ordini 
                                            WHERE Ordini.idordine = {0}", ID);

            DataTable dt = db.eseguiQuery(cmd);

            Ordine newOrd = null;

            if (dt.Rows.Count == 1)
            {
                newOrd = new Ordine();

                newOrd.ID = (int)dt.Rows[0]["idordine"];
                newOrd.DataInserimento = (DateTime)dt.Rows[0]["data"]; //probabile conversione di tipo necessaria

                newOrd.Lavorazioni = new daoLavorazioni().GetByOrdineID(newOrd.ID);

            }

            return newOrd;
        }

        /// Il parametro Param può avere i seguenti valori
        /// 0 -> Tutte le lavorazioni di quel tipo
        /// 1 -> Lavorazioni da iniziare
        /// 2 -> Lavorazioni da terminare, quindi sia iniziate che non
        /// 3 -> Lavorazioni terminate
        public List<Ordine> GetByLavorazione(string TipoLavorazione, int Param)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            string query = @"SELECT Ordini.*
                         FROM Ordini 
                         INNER JOIN Lavorazioni ON Ordini.idordine = Lavorazioni.fkordine
                         INNER JOIN OpzioniLavorazione ON OpzioniLavorazione.idopz = Lavorazioni.fk_opzione
                         INNER JOIN TipoLavorazione ON TipoLavorazione.idtipolav = OpzioniLavorazione.fk_idtipolavorazione ";

            if (Param == 0) query += String.Format("WHERE TipoLavorazione.descrizione = '{0}'", TipoLavorazione);
            if (Param == 1) query += String.Format("WHERE TipoLavorazione.descrizione = '{0}' AND inizio = ''", TipoLavorazione);
            if (Param == 2) query += String.Format("WHERE TipoLavorazione.descrizione = '{0}' AND fine = ''", TipoLavorazione);
            if (Param == 3) query += String.Format("WHERE TipoLavorazione.descrizione = '{0}' AND fine != ''", TipoLavorazione);

            cmd.CommandText = query;

            DataTable dt = db.eseguiQuery(cmd);
            List<Ordine> Ordini = null;

            if (dt.Rows.Count > 0)
            {
                Ordini = new List<Ordine>();
                foreach (DataRow dr in dt.Rows)
                {
                    Ordine Ord = new Ordine();
                    Ord.ID = (int)dr["idordine"];
                    Ord.DataInserimento = (DateTime)dr["data"];
                    Ord.Lavorazioni = new daoLavorazioni().GetByOrdineID(Ord.ID);

                    Ordini.Add(Ord);
                }
            }

            return Ordini;
        }

        public int AddNew(Ordine O)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"INSERT Ordini
                                            (
                                                data,
                                                fk_utente
                                            )
                                            VALUES
                                            (
                                                GETDATE(),
                                                {0}
                                            );
                                            SELECT SCOPE_IDENTITY();", O.UtenteID);
            int insertedID = db.eseguiInsertIDreturn(cmd);

            foreach (Lavorazione L in O.Lavorazioni)
            {
                L.OrdineID = insertedID;
                new daoLavorazioni().AddNew(L);
            }

            return insertedID;
        }

        public List<Ordine> GetAllOrdiniList()
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT Ordini.*
                                            FROM Ordini 
                                            ");

            DataTable dt = db.eseguiQuery(cmd);

            List<Ordine> ordini = null;

            if (dt.Rows.Count > 0)
            {
                ordini = new List<Ordine>();
                foreach (DataRow dr in dt.Rows)
                {
                    Ordine newOrd = new Ordine();

                    newOrd.ID = (int)dr["idordine"];
                    newOrd.DataInserimento = (DateTime)dr["data"]; //probabile conversione di tipo necessaria
                                                                   //DateTime.TryParse(dr[""]);
                    newOrd.UtenteID = (int)dr["fk_utente"];

                    newOrd.Lavorazioni = new daoLavorazioni().GetByOrdineID(newOrd.ID);
                    ordini.Add(newOrd);
                }
            }
            return ordini;
        }

        public DataTable getAllOrdini()
        {

            DataTable dt = new DataTable();
            DataTable tempDT = new DataTable();
            DbEntity db = new DbEntity();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Ordini.* FROM Ordini";

            dt = db.eseguiQuery(cmd);

            return dt;
        }

    }

}