using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Ordine
/// </summary>
public class Ordine {

    public int ID { get; set; }
    public int UtenteID { get; set; }

    public DateTime DataInserimento { get; set; }
    public IList<Lavorazione> Lavorazioni { get; set; }
    public int Stato { get; set; }
    

    public Ordine() {}

}