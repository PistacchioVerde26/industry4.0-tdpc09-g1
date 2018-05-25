using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per daoPostazioni
/// </summary>
public class daoPostazioni {
    public daoPostazioni() {}

    public Postazione GetByID(int ID) {
        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = String.Format(@"SELECT Postazioni.*, dbo.TipoPostazione.descrizione
                            FROM Postazioni
                            INNER JOIN TipoPostazione ON TipoPostazione.idtipopost = Postazioni.fk_tipo
                            WHERE idpostazione = {0}", ID);

        DataTable dt = db.eseguiQuery(cmd);
        Postazione newPost = null;
        if (dt.Rows.Count > 0) {
                newPost = new Postazione();
                newPost.ID = (int)dt.Rows[0]["fk_postazione"];
                newPost.Tag = (string)dt.Rows[0]["tag"];
                newPost.Tipo = (string)dt.Rows[0]["descrizione"];
            }
        return newPost;
    }

    public List<Postazione> GetAll() {
        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = @"SELECT Postazioni.*, dbo.TipoPostazione.descrizione
                            FROM Postazioni
                            INNER JOIN TipoPostazione ON TipoPostazione.idtipopost = Postazioni.fk_tipo";

        DataTable dt = db.eseguiQuery(cmd);
        List<Postazione> postazioni = null;
    
        if(dt.Rows.Count > 0) {
            postazioni = new List<Postazione>();
            foreach (DataRow dr in dt.Rows) {
                Postazione newPost = new Postazione();
                newPost.ID = (int)dr["fk_postazione"];
                newPost.Tag = (string)dr["tag"];
                newPost.Tipo = (string)dr["descrizione"];

                postazioni.Add(newPost);
            }
        }

        return postazioni;
    }

    public List<Postazione> GetBasedOnUtente(Utente U) {
        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = String.Format(@"SELECT Postazioni.*, dbo.TipoPostazione.descrizione
                            FROM Postazioni
                            INNER JOIN TipoPostazione ON TipoPostazione.idtipopost = Postazioni.fk_tipo
                            INNER JOIN Utenti_postazioni ON Utenti_postazioni.fk_postazione = Postazioni.idpostazione
                            INNER JOIN Utenti ON Utenti.idutente = Utenti_postazioni.fk_utente
                            WHERE Utente.idutente = {0}", U.ID);

        DataTable dt = db.eseguiQuery(cmd);
        List<Postazione> postazioni = null;

        if (dt.Rows.Count > 0) {
            postazioni = new List<Postazione>();
            foreach (DataRow dr in dt.Rows) {
                Postazione newPost = new Postazione();
                newPost.ID = (int)dr["fk_postazione"];
                newPost.Tag = (string)dr["tag"];
                newPost.Tipo = (string)dr["descrizione"];

                postazioni.Add(newPost);
            }
        }

        return postazioni;
    }

}