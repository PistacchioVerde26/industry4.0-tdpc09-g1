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

}