using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code
{
    public class Ordine : IComparable
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
            return Lavorazioni.Find((L) => L.Stato == 1 && L.PostazioneID != PostazioneID) == null ? true : false;
        }

        public bool IsFree() {
            return Lavorazioni.Find((L) => L.Stato == 1) == null ? true : false;
        }

        public int Avanzamento() {
            if (Lavorazioni != null && Lavorazioni.Count > 0) {
                int tot = 0;
                foreach(Lavorazione L in Lavorazioni) {
                    if (L.Stato == 2) tot++;
                }
                return tot * 100 / Lavorazioni.Count;
            }
            return 0;
        }

        public int CompareTo(object obj) {
            return DataInserimento.CompareTo(obj);
        }

    }

}