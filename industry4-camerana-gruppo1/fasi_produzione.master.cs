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
        Lavorazioni = new daoLavorazioni().GetForPostazione(P);

        DrawTable();

    }

    public void DrawTable() {
        tbl_Lavori.Rows.Clear();

        TableHeaderRow thrR = new TableHeaderRow();
        TableHeaderCell thcIDordine = new TableHeaderCell();
        thcIDordine.Text = "ID ORDINE";
        TableHeaderCell thcOpzione = new TableHeaderCell();
        thcIDordine.Text = "OPZIONE";
        TableHeaderCell thcIDdata = new TableHeaderCell();
        thcIDordine.Text = "STATO";
        TableHeaderCell thcIDstato = new TableHeaderCell();
        thcIDordine.Text = "LAVORA";
        TableHeaderCell thcIDbtn = new TableHeaderCell();

        thrR.Cells.Add(thcIDordine);
        thrR.Cells.Add(thcOpzione);
        thrR.Cells.Add(thcIDdata);
        thrR.Cells.Add(thcIDstato);
        thrR.Cells.Add(thcIDbtn);

        tbl_Lavori.Rows.Add(thrR);

        foreach (Lavorazione L in Lavorazioni) {

            TableRow tr = new TableRow();
            TableCell tcIDordine = new TableCell();
            thcIDordine.Text = L.OrdineID.ToString();
            TableCell tcOpzione = new TableCell();
            thcIDordine.Text = L.Opzione;
            TableCell tcIDdata = new TableCell();
            thcIDordine.Text = L.DataOrdine.ToString();
            TableCell tcIDstato = new TableCell();
            thcIDordine.Text = L.Stato.ToString();
            TableCell tcIDbtn = new TableCell();

            Button btn = new Button();
            btn.Text = "Lavora";
            btn.Click += new EventHandler(Btn_Lavoro_Click);

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
