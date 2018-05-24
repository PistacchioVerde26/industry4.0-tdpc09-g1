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
    public int OpzioneID { get; set; }
    public string Opzione { get; set; }
    public string Note { get; set; }
    public DateTime Inizio { get; set; }
    public DateTime Fine { get; set; }
    public int Stato { get; set; }
    public int PostazioneID { get; set; }

    public Lavorazione() {}

    public Lavorazione(int ID, TipoLavorazione Tipo, string Opzione, int OpzioneID, string Note, DateTime Inizio, DateTime Fine, int Stato) {
        this.ID = ID;
        this.Tipo = Tipo;
        this.Opzione = Opzione;
        this.OpzioneID = OpzioneID;
        this.Note = Note;
        this.Inizio = Inizio;
        this.Fine = Fine;
        this.Stato = Stato;
    }

}