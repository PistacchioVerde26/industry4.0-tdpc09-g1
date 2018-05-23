using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Lavorazione
/// </summary>
public class Lavorazione {

    public int ID { get; set; }
    public int OrdineID { get; set; }

    public TipoLavorazione Tipo { get; set; }
    public string Dettagli { get; set; }
    public DateTime Inizio { get; set; }
    public DateTime Fine { get; set; }
    public int Stato { get; set; }

    public Lavorazione() {}

    public Lavorazione(int ID, TipoLavorazione Tipo, string Dettagli, DateTime Inizio, DateTime Fine, int Stato) {
        this.ID = ID;
        this.Tipo = Tipo;
        this.Dettagli = Dettagli;
        this.Inizio = Inizio;
        this.Fine = Fine;
        this.Stato = Stato;
    }

}