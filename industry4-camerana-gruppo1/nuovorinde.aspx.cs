using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nuovorinde : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        CaricaOpzioni();
    }

    public void CaricaOpzioni() {

        //List<TipoLavorazione> TipiLavorazione = new List<TipoLavorazione>();
        //TipiLavorazione.Add(new daoTipoLavorazione().GetByTipo("foratura"));
        //TipiLavorazione.Add(new daoTipoLavorazione().GetByTipo("etichettatura"));
        //TipiLavorazione.Add(new daoTipoLavorazione().GetByTipo("colore"));
        //TipiLavorazione.Add(new daoTipoLavorazione().GetByTipo("materiale"));

        TipoLavorazione Foratura = new daoTipoLavorazione().GetByTipo("foratura");
        TipoLavorazione Colore = new daoTipoLavorazione().GetByTipo("colore");
        TipoLavorazione Materiale = new daoTipoLavorazione().GetByTipo("materiale");

        foreach(KeyValuePair<int, string> opzione in Foratura.Opzioni) {
            drp_Foro.Items.Add(new ListItem(opzione.Value, opzione.Key.ToString()));
        }
        foreach (KeyValuePair<int, string> opzione in Colore.Opzioni) {
            drp_Colore.Items.Add(new ListItem(opzione.Value, opzione.Key.ToString()));
        }
        foreach (KeyValuePair<int, string> opzione in Materiale.Opzioni) {
            drp_Materiale.Items.Add(new ListItem(opzione.Value, opzione.Key.ToString()));
        }

    }

    protected void btnAggiungi_Click(object sender, EventArgs e)
    {

        ////salva l'ordine nella tabella

        //if (rblColore.SelectedItem.Value == "rosso")
        //{

        //}

        //Ordine oOrdine = new Ordine();
       
        //Utente oUtente = (Utente)Session["utente"];
        //oOrdine.UtenteID = (oUtente!=null)?oUtente.ID:0;
        //oOrdine.DataInserimento = DateTime.Now;
        //oOrdine.Stato = 0;
        
        //Lavorazione lav = new Lavorazione();

        ////materiale
        //lav.OpzioneID = 1;
        //lav.Opzione = rblColore.SelectedItem.Value;
        //oOrdine.Lavorazioni.Add(lav);
        ////foratura
        //lav = new Lavorazione();
        //lav.OpzioneID = 2;
        //lav.Opzione = rblColore.SelectedItem.Value;
        //oOrdine.Lavorazioni.Add(lav);
        ////colorazione
        //lav = new Lavorazione();
        //lav.OpzioneID = 3;
        //lav.Opzione = rblColore.SelectedItem.Value;
        //oOrdine.Lavorazioni.Add(lav);
        ////incisione
        //lav = new Lavorazione();
        //lav.OpzioneID = 4;
        //lav.Opzione = tbTesto.Text;
        //oOrdine.Lavorazioni.Add(lav);

        //daoOrdine daoO = new daoOrdine();
        //int risInserimentoO = daoO.AddNew(oOrdine);

        //tbTesto.Text = "";
        //popolaTabella();
    }

    private void  popolaTabella()
    {
        //tblOrdini.Rows.Clear();
        
    }
}