using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per daoOrdine
/// </summary>
public class daoOrdine {

    public daoOrdine() {
        //
        // TODO: aggiungere qui la logica del costruttore
        //
    }

    public Ordine GetOrdine(int ID) {

        DbEntity db = new DbEntity();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT Ordini.*, Lavorazioni.*, TipoLavorazione.* FROM Ordini INNER JOIN Lavorazioni ON Ordini.idordine = Lavorazioni.fkordine INNER JOIN TipoLavorazione ON Lavorazioni.fk_tipolav = TipoLavorazione.idtipolav WHERE Ordini.idordine=" + ID;


        return null;
    }

}