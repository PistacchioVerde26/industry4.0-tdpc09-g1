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

        protected void Page_Load(object sender, EventArgs e) {
            if(Session["utente"] == null) {
                Response.Redirect("login.aspx");
            } else {
                Logged =(Utente) Session["utente"];
            }

            CaricaOrdini();
        }

        public void CaricaOrdini() {
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

            List<Ordine> Ordini = null;

            if(Logged.Ruolo == 2) {
                Ordini = new daoOrdine().GetAllOrdiniByUtente(Logged.ID);
            } else if(Logged.Ruolo == 3){
                Ordini = new daoOrdine().GetAllOrdiniList();
            }

            Ordini.Sort((x, y) => DateTime.Compare(x.DataInserimento, y.DataInserimento));

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
                if(O.Avanzamento() == 100) icon.ImageUrl = @"imgs/ico-lav-3.png";
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
                btn.Attributes.Add("id_lavorazione", O.ID.ToString());
                tcBtn.Controls.Add(btn);

                //tcBtn.Controls.Add(BuildModalButton(O));
                //pnl_Modals.Controls.Add(BuildModal(O));

                tr.Cells.Add(tcID);
                tr.Cells.Add(tcData);
                tr.Cells.Add(tcAvanzamento);
                tr.Cells.Add(tcStato);
                tr.Cells.Add(tcBtn);

                tbl_Ordini.Rows.Add(tr);

            }

        }

        //public HtmlGenericControl BuildModalButton(Ordine O) {

        //    //< button type = "button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
        //    //        Launch demo modal
        //    //    </button>

        //    HtmlGenericControl first = new HtmlGenericControl();
        //    first.TagName = "button";
        //    first.Attributes.Add("class", "btn btn-info");
        //    first.Attributes.Add("data-toggle", "modal");
        //    first.Attributes.Add("data-target", "#modal_oid"+O.ID);
        //    first.InnerText = "Dettagli";

        //    return first;
        //}

        //public HtmlGenericControl BuildModal(Ordine O) {
        //    //< div class="modal fade" id="exampleModalCenter" role="dialog">
        //    //    <div class="modal-dialog modal-dialog-centered" role="document">
        //    //        <div class="modal-content">
        //    //            <div class="modal-header">
        //    //                <h5 class="modal-title">Modal title</h5>
        //    //            </div>
        //    //            <div class="modal-body">
        //    //                ...
        //    //            </div>
        //    //            <div class="modal-footer">
        //    //                <button type = "button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        //    //            </div>
        //    //        </div>
        //    //    </div>
        //    //</div>

        //    HtmlGenericControl first = new HtmlGenericControl();

        //    first.TagName = "div";
        //    first.Attributes.Add("class", "modal fade");
        //    first.Attributes.Add("id", "modal_oid" + O.ID);
        //    first.Attributes.Add("role", "dialog");

        //    first.InnerHtml = String.Format(@"");

        //    HtmlGenericControl second = new HtmlGenericControl();
        //    second.TagName = "div";
        //    second.Attributes.Add("class", "modal-dialog modal-dialog-centered");
        //    second.Attributes.Add("role", "document");

        //    HtmlGenericControl third = new HtmlGenericControl();
        //    third.TagName = "div";
        //    third.Attributes.Add("class", "modal-content");

        //    HtmlGenericControl fourth = new HtmlGenericControl();
        //    fourth.TagName = "div";
        //    fourth.Attributes.Add("class", "modal-header");

        //    HtmlGenericControl fifth = new HtmlGenericControl();
        //    fifth.TagName = "h5";
        //    fifth.Attributes.Add("class", "modal-title");
        //    fifth.InnerText = "Dettagli ordine ID " + O.ID + " | del " + O.DataInserimento; 

        //    HtmlGenericControl sixth = new HtmlGenericControl();
        //    sixth.TagName = "div";
        //    sixth.Attributes.Add("class", "modal-body");

        //    Table tbl = new Table();
        //    tbl.CssClass = "table table-hover table-sm";

        //    TableHeaderRow thrR = new TableHeaderRow();
        //    TableHeaderCell thcTipo = new TableHeaderCell();
        //    thcTipo.Text = "TIPO";
        //    TableHeaderCell thcOpzione = new TableHeaderCell();
        //    thcOpzione.Text = "OPZIONE";
        //    TableHeaderCell thcInizio = new TableHeaderCell();
        //    thcInizio.Text = "INIZIO";
        //    TableHeaderCell thcFine = new TableHeaderCell();
        //    thcFine.Text = "FINE";
        //    TableHeaderCell thcIDstato = new TableHeaderCell();
        //    thcIDstato.Text = "STATO";
        //    TableHeaderCell thcPostazione = new TableHeaderCell();
        //    thcPostazione.Text = "POSTAZIONE";

        //    thrR.Cells.Add(thcTipo);
        //    thrR.Cells.Add(thcOpzione);
        //    thrR.Cells.Add(thcInizio);
        //    thrR.Cells.Add(thcFine);
        //    thrR.Cells.Add(thcIDstato);
        //    thrR.Cells.Add(thcPostazione);

        //    tbl.Rows.Add(thrR);

        //    foreach (Lavorazione L in O.Lavorazioni) {

        //        TableRow tr = new TableRow();
        //        TableCell tcTipo = new TableCell();
        //        tcTipo.Text = L.Tipo.Descrizione;
        //        TableCell tcOpzione = new TableCell();
        //        tcOpzione.Text = L.Opzione;
        //        TableCell tcInizio = new TableCell();
        //        tcInizio.Text = L.Inizio != default(DateTime) ? L.Inizio.ToString() : "--";
        //        TableCell tcFine = new TableCell();
        //        tcFine.Text = L.Fine != default(DateTime) ? L.Fine.ToString() : "--";
        //        TableCell tcIDstato = new TableCell();
        //        Image icon = new Image();
        //        icon.ImageUrl = @"imgs/ico-lav-" + L.Stato + ".png";
        //        icon.CssClass += "mx-auto";
        //        icon.Width = new Unit(25);
        //        tcIDstato.Controls.Add(icon);

        //        TableCell tcPostazione = new TableCell();
        //        tcPostazione.Text = L.PostazioneID+"";

        //        tr.Cells.Add(tcTipo);
        //        tr.Cells.Add(tcOpzione);
        //        tr.Cells.Add(tcInizio);
        //        tr.Cells.Add(tcFine);
        //        tr.Cells.Add(tcIDstato);
        //        tr.Cells.Add(tcPostazione);

        //        tbl.Rows.Add(tr);

        //    }
        //    sixth.Controls.Add(tbl);


        //    HtmlGenericControl seventh = new HtmlGenericControl();
        //    seventh.TagName = "div";
        //    seventh.Attributes.Add("class", "modal-footer");

        //    HtmlGenericControl eight = new HtmlGenericControl();
        //    eight.TagName = "button";
        //    eight.Attributes.Add("type", "button");
        //    eight.Attributes.Add("class", "btn btn-secondary");
        //    eight.Attributes.Add("data-dismiss", "modal");
        //    eight.InnerText = "Chiudi";


        //    seventh.Controls.Add(eight);
        //    sixth.Controls.Add(seventh);
        //    fifth.Controls.Add(sixth);
        //    fourth.Controls.Add(fifth);
        //    third.Controls.Add(fourth);
        //    second.Controls.Add(third);
        //    first.Controls.Add(second);

        //    return first;
        //}

        protected void btn_ViewOrdine_Click(object sender, EventArgs e) {

        }
    }
}