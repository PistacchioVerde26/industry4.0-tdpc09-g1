using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code

{
    public class Postazione
    {

        public int ID { get; set; }

        public string Tag { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }

        public int TipoID { get; set; }

        public Postazione() { }

        public Postazione(string Tag, string Tipo)
        {
            this.Tag = Tag;
            this.Tipo = Tipo;
            this.ID = -1;
        }

    }

}