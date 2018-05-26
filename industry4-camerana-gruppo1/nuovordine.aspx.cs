using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nuovorinde : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        //Controllo utente loggato

        pnl_Result.Visible = false;
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
        TipoLavorazione Etichetta = new daoTipoLavorazione().GetByTipo("etichettatura");

        foreach (KeyValuePair<int, string> opzione in Foratura.Opzioni) {
            drp_Foro.Items.Add(new ListItem(opzione.Value, opzione.Key.ToString()));
        }
        drp_Foro.Attributes.Add("tipo", Foratura.Descrizione);
        drp_Foro.Attributes.Add("tipoID", Foratura.ID.ToString());

        foreach (KeyValuePair<int, string> opzione in Colore.Opzioni) {
            drp_Colore.Items.Add(new ListItem(opzione.Value, opzione.Key.ToString()));
        }
        drp_Colore.Attributes.Add("tipo", Colore.Descrizione);
        drp_Colore.Attributes.Add("tipoID", Colore.ID.ToString());

        foreach (KeyValuePair<int, string> opzione in Materiale.Opzioni) {
            drp_Materiale.Items.Add(new ListItem(opzione.Value, opzione.Key.ToString()));
        }
        drp_Materiale.Attributes.Add("tipo", Materiale.Descrizione);
        drp_Materiale.Attributes.Add("tipoID", Materiale.ID.ToString());

        txt_Etichetta.Attributes.Add("tipo", Etichetta.Descrizione);
        txt_Etichetta.Attributes.Add("tipoID", Etichetta.ID.ToString());
    }

    protected void btn_Inserisci_Click(object sender, EventArgs e) {

        if(txt_Etichetta.Text != "") {

            Lavorazione Foro = new Lavorazione();
            Foro.Tipo = new TipoLavorazione(Int32.Parse(drp_Foro.Attributes["tipoID"]), drp_Foro.Attributes["tipo"]);
            Foro.OpzioneID = Int32.Parse(drp_Foro.SelectedItem.Value);
            Foro.Opzione = drp_Foro.SelectedItem.Text;
            Foro.Stato = 0;

            Lavorazione Colore = new Lavorazione();
            Colore.Tipo = new TipoLavorazione(Int32.Parse(drp_Colore.Attributes["tipoID"]), drp_Colore.Attributes["tipo"]);
            Colore.OpzioneID = Int32.Parse(drp_Colore.SelectedItem.Value);
            Colore.Opzione = drp_Colore.SelectedItem.Text;
            Colore.Stato = 0;

            Lavorazione Materiale = new Lavorazione();
            Materiale.Tipo = new TipoLavorazione(Int32.Parse(drp_Materiale.Attributes["tipoID"]), drp_Foro.Attributes["tipo"]);
            Materiale.OpzioneID = Int32.Parse(drp_Materiale.SelectedItem.Value);
            Materiale.Opzione = drp_Materiale.SelectedItem.Text;
            Materiale.Stato = 0;

            Lavorazione Etichetta = new Lavorazione();
            Etichetta.Tipo = new TipoLavorazione(Int32.Parse(txt_Etichetta.Attributes["tipoID"]), txt_Etichetta.Attributes["tipo"]);
            Etichetta.OpzioneID = -1;
            Etichetta.Opzione = txt_Etichetta.Text;
            Etichetta.Stato = 0;

            Ordine newOrdine = new Ordine();
            newOrdine.Lavorazioni.Add(Foro);
            newOrdine.Lavorazioni.Add(Colore);
            newOrdine.Lavorazioni.Add(Materiale);
            newOrdine.Lavorazioni.Add(Etichetta);
            newOrdine.UtenteID = ((Utente)Session["utente"]).ID;

            int insertedID = new daoOrdine().AddNew(newOrdine);
            
            if(insertedID != -1) {
                pnl_Result.Visible = true;
                lbl_Result.Text += " ID: " + insertedID;
            } else {
                pnl_Result.Visible = true;
                lbl_Result.Text = "<strong>Error!</strong> Errore inserimento ordine - " + insertedID;
            }

        } else {
            pnl_Result.Visible = true;
            lbl_Result.Text = "<strong>Error!</strong> Errore inserimento ordine";
        }


    }
}