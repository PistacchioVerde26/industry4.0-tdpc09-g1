using Industry4_camerana_gruppo1.App_Code;
using Industry4_camerana_gruppo1.App_Code.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Industry4_camerana_gruppo1 {
    public partial class avanzamento : System.Web.UI.Page {

        Utente Logged;
        static List<Ordine> Ordini;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["utente"] == null) {
                Response.Redirect("login.aspx");
            } else {
                Logged = (Utente)Session["utente"];
            }

            CaricaOrdini();
        }

        public void CaricaOrdini() {

            Ordini = null;

            if (Logged.Ruolo == 2) {
                Ordini = new daoOrdine().GetAllOrdiniByUtente(Logged.ID);
            } else if (Logged.Ruolo == 3) {
                Ordini = new daoOrdine().GetAllOrdiniList();
            }

            if (Ordini != null && Ordini.Count > 0) {
                tbl_Ordini.Rows.Clear();

                TableHeaderRow thR = new TableHeaderRow();
                TableHeaderCell thcID = new TableHeaderCell();
                thcID.Text = "ID";
                TableHeaderCell thcData = new TableHeaderCell();
                thcData.Text = "DATA";
                TableHeaderCell thcAvanzamento = new TableHeaderCell();
                thcAvanzamento.Text = "AVANZAMENTO";
                TableHeaderCell thcStato = new TableHeaderCell();
                thcStato.Text = "STATO";
                TableHeaderCell thcView = new TableHeaderCell();
                thcView.Text = "VISUALIZZA";

                thR.Cells.Add(thcID);
                thR.Cells.Add(thcData);
                thR.Cells.Add(thcAvanzamento);
                thR.Cells.Add(thcStato);
                thR.Cells.Add(thcView);

                tbl_Ordini.Rows.Add(thR);

                Ordini.Sort((x, y) => -1 * x.CompareTo(y.DataInserimento));

                foreach (Ordine O in Ordini) {

                    TableRow tr = new TableRow();
                    TableCell tcID = new TableCell();
                    tcID.Text = O.ID.ToString();
                    TableCell tcData = new TableCell();
                    tcData.Text = O.DataInserimento.ToString();
                    TableCell tcAvanzamento = new TableCell();
                    tcAvanzamento.Text = O.Avanzamento() + "%";

                    TableCell tcStato = new TableCell();
                    Image icon = new Image();
                    if (O.Avanzamento() == 100) icon.ImageUrl = @"imgs/ico-lav-2.png";
                    else if (O.IsFree()) icon.ImageUrl = @"imgs/ico-lav-0.png";
                    else icon.ImageUrl = @"imgs/ico-lav-1.png";
                    icon.CssClass += "mx-auto";
                    icon.Width = new Unit(35);
                    tcStato.Controls.Add(icon);

                    TableCell tcBtn = new TableCell();
                    Button btn = new Button();
                    btn.UseSubmitBehavior = true;
                    btn.ID = "btn_" + O.ID.ToString();
                    btn.Text = "Dettagli";
                    btn.Click += new EventHandler(btn_ViewOrdine_Click);
                    btn.CssClass = "btn btn-info";
                    btn.Attributes.Add("id_ordine", O.ID.ToString());
                    tcBtn.Controls.Add(btn);

                    tr.Cells.Add(tcID);
                    tr.Cells.Add(tcData);
                    tr.Cells.Add(tcAvanzamento);
                    tr.Cells.Add(tcStato);
                    tr.Cells.Add(tcBtn);

                    tbl_Ordini.Rows.Add(tr);

                }
            }

        }

        public void DrawDetails(Ordine O) {

            tbl_OrderDetails.Rows.Clear();

            TableHeaderRow thrR = new TableHeaderRow();
            TableHeaderCell thcTipo = new TableHeaderCell();
            thcTipo.Text = "TIPO";
            TableHeaderCell thcOpzione = new TableHeaderCell();
            thcOpzione.Text = "OPZIONE";
            TableHeaderCell thcInizio = new TableHeaderCell();
            thcInizio.Text = "INIZIO";
            TableHeaderCell thcFine = new TableHeaderCell();
            thcFine.Text = "FINE";
            TableHeaderCell thcIDstato = new TableHeaderCell();
            thcIDstato.Text = "STATO";
            TableHeaderCell thcPostazione = new TableHeaderCell();
            thcPostazione.Text = "POSTAZIONE";

            thrR.Cells.Add(thcTipo);
            thrR.Cells.Add(thcOpzione);
            thrR.Cells.Add(thcInizio);
            thrR.Cells.Add(thcFine);
            thrR.Cells.Add(thcIDstato);
            thrR.Cells.Add(thcPostazione);

            tbl_OrderDetails.Rows.Add(thrR);

            lbl_OrderDetails.Text = "Dettagli ordine ID " + O.ID + " | del " + O.DataInserimento;

            foreach (Lavorazione L in O.Lavorazioni) {

                TableRow tr = new TableRow();
                TableCell tcTipo = new TableCell();
                tcTipo.Text = L.Tipo.Descrizione;
                TableCell tcOpzione = new TableCell();
                tcOpzione.Text = L.Opzione;
                TableCell tcInizio = new TableCell();
                tcInizio.Text = L.Inizio != default(DateTime) ? L.Inizio.ToString() : "--";
                TableCell tcFine = new TableCell();
                tcFine.Text = L.Fine != default(DateTime) ? L.Fine.ToString() : "--";
                TableCell tcIDstato = new TableCell();
                Image icon = new Image();
                icon.ImageUrl = @"imgs/ico-lav-" + L.Stato + ".png";
                icon.CssClass += "mx-auto";
                icon.Width = new Unit(25);
                tcIDstato.Controls.Add(icon);

                TableCell tcPostazione = new TableCell();
                tcPostazione.Text = L.PTag;

                tr.Cells.Add(tcTipo);
                tr.Cells.Add(tcOpzione);
                tr.Cells.Add(tcInizio);
                tr.Cells.Add(tcFine);
                tr.Cells.Add(tcIDstato);
                tr.Cells.Add(tcPostazione);

                tbl_OrderDetails.Rows.Add(tr);

            }

        }

        protected void btn_ViewOrdine_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int IDordine = Convert.ToInt32(btn.Attributes["id_ordine"]);

            Ordine Ord = Ordini.Find(O => O.ID == IDordine);

            if (Ord != null) {
                DrawDetails(Ord);
            }
        }
    }

}