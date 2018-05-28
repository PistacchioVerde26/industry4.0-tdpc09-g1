using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fasi_produzione : System.Web.UI.MasterPage {

    string CurrentPage;
    List<Lavorazione> Lavorazioni;
    Lavorazione LInCoda;

    static int PostazioneID;
    protected void Page_Load(object sender, EventArgs e) {

        //Controllo redirect page to login se utente non loggato

        //Get current page
        CurrentPage = Page.ToString().Replace("ASP.", "").Replace("_", ".").Replace(".aspx","");
        //Get Postazione id da URL
        if (Request.QueryString["pid"] != null) {
            Int32.TryParse(Request.QueryString["pid"], out PostazioneID);
        }
        CaricaPostazione();

    }

    public void CaricaPostazione() {

        Postazione P = new daoPostazioni().GetByID(PostazioneID);

        img_LogoPostazione.Attributes.Add("src", "imgs/ic" + P.Tipo + ".png");
        lbl_NomePostazione.InnerText = String.Format("{0} - {1}", P.Tipo.ToUpper(), P.Tag);
        
        List<Ordine> ordini = new daoOrdine().GetAllOrdiniList();
        Lavorazioni = new List<Lavorazione>();

        lbl_Message.Text += ordini.Count + " ordini trovati <br/>";
        foreach (Ordine O in ordini) {
            if (O.IsFree(P.ID)) {
                lbl_Message.Text += "Ordine libero ID " + O.ID + "<br />";
                Lavorazione newL = O.Lavorazioni.Find((L) => L.Tipo.Descrizione.Equals(P.Tipo));
                if (newL != null) Lavorazioni.Add(newL);

                //foreach(Lavorazione L in O.Lavorazioni) {
                //    if(L.Tipo.Descrizione.Equals(P.Tipo)) Lavorazioni.Add(L);
                //    lbl_Message.Text += "L.Tipo.Descrizione -> " + L.Tipo.Descrizione + " P.Tipo -> " + P.Tipo + "<br />";
                //}

            }
        }

        LInCoda = Lavorazioni.Find(L => L.Stato == 1);

        if(LInCoda == null) {
            lbl_InCoda.Visible = true;
            lbl_InCoda.InnerText = "Nessuna lavorazione in corso";
        } else {
            lbl_InCoda.Visible = false;
        }

        DrawTable();
    }

    public void DrawTable() {
        tbl_Lavori.Rows.Clear();

        bool LavorazioneInCorso = Lavorazioni.Find(L => L.Stato == 1) == null ? false : true;
        lbl_LavorazioniCoda.InnerText = "LAVORAZIONI IN CODA -> " + (LavorazioneInCorso ? Lavorazioni.Count - 1 : Lavorazioni.Count);

        TableHeaderRow thrR = new TableHeaderRow();
        TableHeaderCell thcIDordine = new TableHeaderCell();
        thcIDordine.Text = "ID ORDINE";
        TableHeaderCell thcOpzione = new TableHeaderCell();
        thcOpzione.Text = "OPZIONE";
        TableHeaderCell thcIDdata = new TableHeaderCell();
        thcIDdata.Text = "DATA";
        TableHeaderCell thcIDstato = new TableHeaderCell();
        thcIDstato.Text = "STATO";
        TableHeaderCell thcIDbtn = new TableHeaderCell();
        thcIDbtn.Text = "PRENDI IN CARICO";

        thrR.Cells.Add(thcIDordine);
        thrR.Cells.Add(thcOpzione);
        thrR.Cells.Add(thcIDdata);
        thrR.Cells.Add(thcIDstato);
        thrR.Cells.Add(thcIDbtn);

        tbl_Lavori.Rows.Add(thrR);

        lbl_Message.Text += Lavorazioni.Count + " lavorazioni trovate<br/>";

        foreach (Lavorazione L in Lavorazioni) {

            TableRow tr = new TableRow();
            tr.CssClass = L.Stato == 1 ? "table-warning" : "";
            TableCell tcIDordine = new TableCell();
            tcIDordine.Text = L.OrdineID.ToString();
            TableCell tcOpzione = new TableCell();
            tcOpzione.Text = L.Opzione;
            TableCell tcIDdata = new TableCell();
            tcIDdata.Text = L.DataOrdine.ToString();
            TableCell tcIDstato = new TableCell();
            Image icon = new Image();
            icon.ImageUrl = @"imgs/ico-lav-" + L.Stato +".png";
            icon.CssClass += "mx-auto";
            icon.Width = new Unit(40);
            tcIDstato.Controls.Add(icon);
            TableCell tcIDbtn = new TableCell();
            Button btn = new Button();
            btn.Text = L.Stato == 1 ? "In corso..." : "Lavora";
            btn.Click += new EventHandler(Btn_Lavoro_Click);
            btn.CssClass = "btn btn-primary";
            tcIDbtn.Controls.Add(btn);

            if (L.Stato == 1 || LavorazioneInCorso || Lavorazioni.IndexOf(L) != 0) btn.Enabled = false;

            tr.Cells.Add(tcIDordine);
            tr.Cells.Add(tcOpzione);
            tr.Cells.Add(tcIDdata);
            tr.Cells.Add(tcIDstato);
            tr.Cells.Add(tcIDbtn);

            tbl_Lavori.Rows.Add(tr);
        }

    }

    protected void Btn_Lavoro_Click(object sender, EventArgs e) {

    }

}
