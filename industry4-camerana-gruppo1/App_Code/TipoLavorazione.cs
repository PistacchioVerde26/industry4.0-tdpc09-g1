using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code
{
    public class TipoLavorazione
    {

        public int ID { get; set; }
        public string Descrizione { get; set; }
        public Dictionary<int, string> Opzioni { get; set; }

        public TipoLavorazione()
        {
            this.Opzioni = new Dictionary<int, string>();
        }

        public TipoLavorazione(int ID, string Descrizione)
        {
            this.Opzioni = null;
            this.ID = ID;
            this.Descrizione = Descrizione;
        }

    }

}