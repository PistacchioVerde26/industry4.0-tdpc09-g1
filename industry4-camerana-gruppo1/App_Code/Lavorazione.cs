using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Lavorazione
/// </summary>
public class Lavorazione {

    public int ID { get; set; }

    public string Tipo { get; set; }
    public string Dettagli { get; set; }
    public DateTime Inizio { get; set; }
    public DateTime Fine { get; set; }
    public int Stato { get; set; }
    public string Opzione { get; set; }

    public Lavorazione() {
        //
        // TODO: aggiungere qui la logica del costruttore
        //
    }
}