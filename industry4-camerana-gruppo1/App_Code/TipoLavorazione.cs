using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per TipoLavorazione
/// </summary>
public class TipoLavorazione {
    
    public int ID { get; set; }
    public string Descrizione { get; set; }
    public List<string> Opzioni { get; set; }

    public TipoLavorazione() {}

    public TipoLavorazione(int ID, string Descrizione) {
        this.Opzioni = null;
        this.ID = ID;
        this.Descrizione = Descrizione;
    }

}