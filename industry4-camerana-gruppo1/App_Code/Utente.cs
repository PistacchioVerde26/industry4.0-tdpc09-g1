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
    public int Ruolo { get; set; } //0 Macchinista, 1 Commerciale, 2 Amministratore

    public Utente() {}

}