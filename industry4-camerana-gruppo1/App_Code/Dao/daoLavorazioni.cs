using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per daoLavorazioni
/// </summary>
public class daoLavorazioni {
    public daoLavorazioni() {}

    public List<Lavorazione> GetByOrdineID(int ID) {
        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = String.Format(@"SELECT *, TipoLavorazione.idtipolav
                                        FROM Lavorazioni
                                        INNER JOIN TipoLavorazione ON Lavorazioni.fk_tipolav = TipoLavorazione.idtipolav
                                        WHERE Lavorazioni.fkordine = {0}", ID);

        DataTable dt = db.eseguiQuery(cmd);
        List<Lavorazione> lavorazioni = new List<Lavorazione>();

        if (dt.Rows.Count > 0) {
            foreach(DataRow dr in dt.Rows) {
                //int ID, string Tipo, string Dettagli, DateTime Inizio, DateTime Fine, int Stato
                Lavorazione newLav = new Lavorazione();
                newLav.ID = (int)dr["idlavorazione"]; 
                newLav.Tipo = new TipoLavorazione((int)dr["idtipolav"], (string)dr["descrizione"]);
                newLav.Dettagli = (string)dr["dettagli"];
                newLav.Inizio = (DateTime)dr["inizio"]; //probablimente da fare controlli per campi vuoti
                newLav.Fine = (DateTime)dr["fine"];
                newLav.Stato = (int)dr["stato"];
                lavorazioni.Add(newLav);
            }
        }

        return lavorazioni;
    }

    public int AddNew(Lavorazione L) {

        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = String.Format(@"INSERT dbo.Lavorazioni
                                            (
                                                fkordine,
                                                fk_tipolav,
                                                dettagli,
                                                stato
                                            )
                                            VALUES
                                            (
                                                {0},
                                                {1},
                                                '{2}',
                                                {3}
                                            );
                                            SELECT SCOPE_IDENTITY();", L.OrdineID, L.Tipo.ID, L.Dettagli, L.Stato);
        return db.eseguiInsertIDreturn(cmd);
        //SELECT SCOPE_IDENTITY();
    }

    public void AggiornaStato(Lavorazione L) {
        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = String.Format(@"UPDATE Lavorazioni
                                            SET stato = {0}
                                            WHERE idlavorazione = {1}", L.ID, L.Stato);
        db.eseguiQueryNOreturn(cmd);
    }

}