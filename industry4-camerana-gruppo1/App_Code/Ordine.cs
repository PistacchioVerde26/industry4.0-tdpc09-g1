using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code
{
    public class Ordine
    {

        public int ID { get; set; }
        public int UtenteID { get; set; }

        public DateTime DataInserimento { get; set; }
        public List<Lavorazione> Lavorazioni { get; set; }
        public int Stato { get; set; }

        public Ordine()
        {
            this.Lavorazioni = new List<Lavorazione>();
        }

        public bool IsFree(int PostazioneID)
        {
            //bool result = true;
            //foreach(Lavorazione L in Lavorazioni) {
            //    if(L.Stato != 0 && (L.Stato == 1 && L.PostazioneID != PostazioneID)) {
            //        result = false;
            //    }
            //}
            //return result;
            return Lavorazioni.Find((L) => L.Stato != 0 && (L.Stato == 1 && L.PostazioneID != PostazioneID)) == null ? true : false;
        }

    }

}