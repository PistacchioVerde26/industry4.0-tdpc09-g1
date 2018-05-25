using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Postazione
/// </summary>
public class Postazione {

    public int ID { get; set; }
    
    public string Tag { get; set; }
    public string Password { get; set; }
    public string Tipo { get; set; }

    public Postazione() {}

    public Postazione(string Tag, string Tipo) {

    }

}