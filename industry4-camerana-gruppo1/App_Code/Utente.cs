using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Utente
/// </summary>
public class Utente {

    public int ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Ruolo { get; set; } //1 Macchinista, 2 Commerciale, 3 Amministratore

    public Utente() {}

    public string RuoloToString() {
        if (Ruolo == 1) return "Macchinista";
        if (Ruolo == 2) return "Commerciale";
        if (Ruolo == 3) return "Amministratore";
        return "";
    }

}