using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code.Dao
{
    public class daoPostazioni
    {
        public daoPostazioni() { }

        public Postazione GetByID(int ID)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT Postazioni.*, dbo.TipoPostazione.descrizione
                            FROM Postazioni
                            INNER JOIN TipoPostazione ON TipoPostazione.idtipopost = Postazioni.fk_tipo
                            WHERE idpostazione = {0}", ID);

            DataTable dt = db.eseguiQuery(cmd);
            Postazione newPost = null;
            if (dt.Rows.Count > 0)
            {
                newPost = new Postazione();
                newPost.ID = (int)dt.Rows[0]["idpostazione"];
                newPost.Tag = (string)dt.Rows[0]["tag"];
                newPost.Tipo = (string)dt.Rows[0]["descrizione"];
            }
            return newPost;
        }

        public List<Postazione> GetAll()
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT Postazioni.*, dbo.TipoPostazione.descrizione
                            FROM Postazioni
                            INNER JOIN TipoPostazione ON TipoPostazione.idtipopost = Postazioni.fk_tipo";

            DataTable dt = db.eseguiQuery(cmd);
            List<Postazione> postazioni = null;

            if (dt.Rows.Count > 0)
            {
                postazioni = new List<Postazione>();
                foreach (DataRow dr in dt.Rows)
                {
                    Postazione newPost = new Postazione();
                    newPost.ID = (int)dr["idpostazione"];
                    newPost.Tag = (string)dr["tag"];
                    newPost.Tipo = (string)dr["descrizione"];

                    postazioni.Add(newPost);
                }
            }

            return postazioni;
        }

        public List<Postazione> GetBasedOnUtente(Utente U)
        {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT Postazioni.*, dbo.TipoPostazione.descrizione
                            FROM Postazioni
                            INNER JOIN TipoPostazione ON TipoPostazione.idtipopost = Postazioni.fk_tipo
                            INNER JOIN Utenti_postazioni ON Utenti_postazioni.fk_postazione = Postazioni.idpostazione
                            INNER JOIN Utenti ON Utenti.idutente = Utenti_postazioni.fk_utente
                            WHERE Utenti.idutente = {0}", U.ID);

            DataTable dt = db.eseguiQuery(cmd);
            List<Postazione> postazioni = null;

            if (dt.Rows.Count > 0)
            {
                postazioni = new List<Postazione>();
                foreach (DataRow dr in dt.Rows)
                {
                    Postazione newPost = new Postazione();
                    newPost.ID = (int)dr["idpostazione"];
                    newPost.Tag = (string)dr["tag"];
                    newPost.Tipo = (string)dr["descrizione"];

                    postazioni.Add(newPost);
                }
            }

            return postazioni;
        }

        public Dictionary<int, string> GetTipi() {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * FROM TipoPostazione");

            DataTable dt = db.eseguiQuery(cmd);

            Dictionary<int, string> tipi = null;

            if (dt.Rows.Count > 0) {
                tipi = new Dictionary<int, string>();
                foreach (DataRow dr in dt.Rows) {
                    tipi.Add((int)dr["idtipopost"], (string)dr["descrizione"]);
                }
            }
            return tipi;
        }

        public bool CheckTag(string Tag) {

            DataTable dt = new DataTable();
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Postazioni WHERE tag = '" + Tag + "';";

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                return false;
            }

            return true;

        }

        public void AddPostazione(Postazione P) {
            DataTable dt = new DataTable();
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"INSERT Postazioni
                                        (
                                            tag,
                                            fk_tipo
                                        )
                                        VALUES
                                        (   '{0}', -- tag - varchar(55)
                                            {1}   -- fk_tipo - int
                                        )", P.Tag, P.TipoID);

            db.eseguiQueryNOreturn(cmd);

        }

        public List<int> GetUtentePostazioni(int IDUtente) {

            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Utenti_postazioni WHERE fk_utente =" + IDUtente + " ORDER BY fk_postazione";

            DataTable dt = db.eseguiQuery(cmd);

            List<int> Relazioni = null;

            if (dt.Rows.Count > 0) {
                Relazioni = new List<int>();
                foreach (DataRow dr in dt.Rows) {
                    Relazioni.Add((int)dr["fk_postazione"]);
                }
            }

            return Relazioni;

        }

        public void AddRelazione(int IDUtente, int IDPostazione) {
            DataTable dt = new DataTable();
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"INSERT dbo.Utenti_postazioni
                                                (
                                                    fk_utente,
                                                    fk_postazione
                                                )
                                                VALUES
                                                (   {0}, -- fk_utente - int
                                                    {0} -- fk_postazione - int
                                                )", IDUtente, IDPostazione);
            int a = 3;
            db.eseguiQueryNOreturn(cmd);

        }

        public void DeleteRelazione(int IDUtente, int IDPostazione) {
            DataTable dt = new DataTable();
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"DELETE dbo.Utenti_postazioni
                                                WHERE fk_utente ={0} AND fk_postazione = {1}", IDUtente, IDPostazione);

            db.eseguiQueryNOreturn(cmd);
        }

    }

}