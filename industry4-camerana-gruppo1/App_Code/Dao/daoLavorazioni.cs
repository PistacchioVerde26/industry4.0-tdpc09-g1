﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
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

    public List<Lavorazione> GetForPostazione(Postazione P) {
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

        if (dt.Rows.Count > 0) {
            foreach (DataRow dr in dt.Rows) {
                //int ID, TipoLavorazione Tipo, string Opzione, int OpzioneID, string Note, DateTime Inizio, DateTime Fine, int Stato
                Lavorazione newLav = new Lavorazione();
                newLav.ID = (int)dr["idlavorazione"];
                newLav.Tipo = new TipoLavorazione((int)dr["idtipolav"], (string)dr["descrizione"]);
                newLav.Opzione = (string)dr["opzione"];
                newLav.OpzioneID = (int)dr["fk_opzione"];
                newLav.Note = (string)dr["note"];
                //newLav.Inizio = (DateTime)dr["inizio"]; //probablimente da fare controlli per campi vuoti
                //newLav.Fine = (DateTime)dr["fine"]; //probablimente da fare controlli per campi vuoti
                newLav.Stato = (int)dr["stato"];
                newLav.DataOrdine = (DateTime)dr["DataOrdine"];
                lavorazioni.Add(newLav);
            }
        }

        return lavorazioni;
    }

    public int AddNew(Lavorazione L) {
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

    public int AddNewOpzione(TipoLavorazione TipoLav, string Opzione) {
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

    public void AggiornaStato(Lavorazione L, int PostazioneID) {
        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;

        if (PostazioneID == -1) {
            cmd.CommandText = String.Format(@"UPDATE Lavorazioni
                                                SET stato = {0}, fk_postazione = NULL
                                                WHERE idlavorazione = {1}", L.ID, L.Stato);
        } else {
            cmd.CommandText = String.Format(@"UPDATE Lavorazioni
                                                SET stato = {0}, fk_postazione = {1}
                                                WHERE idlavorazione = {2}", L.ID, L.PostazioneID, L.Stato);
        }
            
        db.eseguiQueryNOreturn(cmd);
    }

}