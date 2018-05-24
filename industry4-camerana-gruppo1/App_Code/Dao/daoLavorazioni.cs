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
        cmd.CommandText = String.Format(@"SELECT Lavorazioni.*, OpzioniLavorazione.opzione, TipoLavorazione.*
                                            FROM Lavorazioni
                                            INNER JOIN OpzioniLavorazione ON OpzioniLavorazione.idopz = Lavorazioni.fk_opzione
                                            INNER JOIN TipoLavorazione ON TipoLavorazione.idtipolav = OpzioniLavorazione.fk_idtipolavorazione
                                            WHERE Lavorazioni.idlavorazione = {0}", ID);

        DataTable dt = db.eseguiQuery(cmd);
        List<Lavorazione> lavorazioni = new List<Lavorazione>();

        if (dt.Rows.Count > 0) {
            foreach(DataRow dr in dt.Rows) {
                //int ID, TipoLavorazione Tipo, string Opzione, int OpzioneID, string Note, DateTime Inizio, DateTime Fine, int Stato
                Lavorazione newLav = new Lavorazione();
                newLav.ID = (int)dr["idlavorazione"]; 
                newLav.Tipo = new TipoLavorazione((int)dr["idtipolav"], (string)dr["descrizione"]);
                newLav.Opzione = (string)dr["opzione"];
                newLav.OpzioneID = (int)dr["fk_opzione"];
                newLav.Note = (string)dr["note"];
                newLav.Inizio = (DateTime)dr["inizio"]; //probablimente da fare controlli per campi vuoti
                newLav.Fine = (DateTime)dr["fine"]; //probablimente da fare controlli per campi vuoti
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
                                            SELECT SCOPE_IDENTITY();", L.OrdineID, L.OpzioneID, L.Note, L.Stato);
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