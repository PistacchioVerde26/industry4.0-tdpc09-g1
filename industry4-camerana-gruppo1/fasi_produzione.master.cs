using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fasi_produzione : System.Web.UI.MasterPage {

    string CurrentPage;
    List<Lavorazione> Lavorazioni;

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

        List<Ordine> ordini = new daoOrdine().GetAllOrdiniList();
        Lavorazioni = new List<Lavorazione>();

        lbl_Message.Text += ordini.Count + " ordini trovati <br/>";
        foreach (Ordine O in ordini) {
            if (O.IsFree(P.ID)) {
                lbl_Message.Text += "Ordine libero ID " + O.ID + "<br />";
                Lavorazione newL = O.Lavorazioni.Find((L) => L.Tipo.Descrizione.Equals(P.Tipo));
                if(newL != null) Lavorazioni.Add(newL);

                //foreach(Lavorazione L in O.Lavorazioni) {
                //    if(L.Tipo.Descrizione.Equals(P.Tipo)) Lavorazioni.Add(L);
                //    lbl_Message.Text += "L.Tipo.Descrizione -> " + L.Tipo.Descrizione + " P.Tipo -> " + P.Tipo + "<br />";
                //}

            }
        }

        DrawTable();
    }

    public void DrawTable() {
        tbl_Lavori.Rows.Clear();

        TableHeaderRow thrR = new TableHeaderRow();
        TableHeaderCell thcIDordine = new TableHeaderCell();
        thcIDordine.Text = "ID ORDINE";
        TableHeaderCell thcOpzione = new TableHeaderCell();
        thcOpzione.Text = "OPZIONE";
        TableHeaderCell thcIDdata = new TableHeaderCell();
        thcIDdata.Text = "STATO";
        TableHeaderCell thcIDstato = new TableHeaderCell();
        thcIDstato.Text = "PRENDI IN CARICO";
        TableHeaderCell thcIDbtn = new TableHeaderCell();

        thrR.Cells.Add(thcIDordine);
        thrR.Cells.Add(thcOpzione);
        thrR.Cells.Add(thcIDdata);
        thrR.Cells.Add(thcIDstato);
        thrR.Cells.Add(thcIDbtn);

        tbl_Lavori.Rows.Add(thrR);

        lbl_Message.Text += Lavorazioni.Count + " lavorazioni trovate<br/>";

        foreach (Lavorazione L in Lavorazioni) {

            TableRow tr = new TableRow();
            tr.CssClass = L.Stato == 1 ? "table-warning" : "table-success";
            TableCell tcIDordine = new TableCell();
            tcIDordine.Text = L.OrdineID.ToString();
            TableCell tcOpzione = new TableCell();
            tcOpzione.Text = L.Opzione;
            TableCell tcIDdata = new TableCell();
            tcIDdata.Text = L.DataOrdine.ToString();
            TableCell tcIDstato = new TableCell();
            tcIDstato.Text = L.Stato.ToString();
            TableCell tcIDbtn = new TableCell();
            Button btn = new Button();
            btn.Text = "Lavora";
            btn.Click += new EventHandler(Btn_Lavoro_Click);
            btn.CssClass = "btn btn-primary";
            tcIDbtn.Controls.Add(btn);

            if (L.Stato == 1) btn.Enabled = false;

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
