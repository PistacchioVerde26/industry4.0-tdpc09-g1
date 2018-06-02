using Industry4_camerana_gruppo1.App_Code;
using Industry4_camerana_gruppo1.App_Code.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industry4_camerana_gruppo1 {

    public partial class assegnapostazione : System.Web.UI.Page {

        List<Utente> Macchinisti = null;
        int IDMacchinista;

        protected void Page_Load(object sender, EventArgs e) {

            if (Session["utente"] == null) {
                Response.Redirect("login.aspx");
            }

            Macchinisti = new daoUtente().GetByRuolo("macchinista");

            drp_Macchinisti.Items.Add(new ListItem("Seleziona...", "-1"));
            foreach (Utente U in Macchinisti) {
                drp_Macchinisti.Items.Add(new ListItem(U.Username, U.ID.ToString()));
            }

            if (!Int32.TryParse(Request.QueryString["idm"], out IDMacchinista)) IDMacchinista = -1;
            if (IDMacchinista != -1) {
                Utente U = Macchinisti.Find(M => M.ID == IDMacchinista);
                CaricaPostazioni(U);
            }

        }

        public void CaricaPostazioni(Utente U) {

            //if (drp_Macchinisti.SelectedValue == "-1") return;
            //int IDUtente = Convert.ToInt32(drp_Macchinisti.SelectedItem.Value);

            List<Postazione> Postazioni = new daoPostazioni().GetAll();
            List<int> Relazioni = new daoPostazioni().GetUtentePostazioni(U.ID);

            Panel pnlTitle = new Panel();
            pnlTitle.CssClass = "row";
            pnlTitle.Attributes.Add("style", "margin-bottom: 20px");
            Panel pnlCol = new Panel();
            pnlCol.CssClass = "col text-center";
            Label lblTitle = new Label();
            lblTitle.CssClass = "alert alert-secondary";
            lblTitle.Text = "Macchinista: <strong>" + U.Username.ToUpper() + "</strong>";
            pnlCol.Controls.Add(lblTitle);
            pnlTitle.Controls.Add(pnlCol);

            pnl_Postazioni.Controls.Add(pnlTitle);

            if (Postazioni != null) {
                Panel row = new Panel();
                row.CssClass = "row";
                int i = 0;
                foreach (Postazione p in Postazioni) {
                    if (i % 4 == 0 && i != 0) {
                        pnl_Postazioni.Controls.Add(row);
                        row = new Panel();
                        row.CssClass = "row";
                    }
                    if (Relazioni.Contains(p.ID)) {
                        row.Controls.Add(CustomDiv(p, U.ID, true));
                    } else {
                        row.Controls.Add(CustomDiv(p, U.ID, false));
                    }
                    i++;
                }
                pnl_Postazioni.Controls.Add(row);
            }
        }

        public Panel CustomDiv(Postazione P, int IDUtente, bool Assegnato) {

            //  <div class="col" runat="server" id="div_Foratura">
            //        <div class="card text-center">
            //            <asp:ImageButton ID = "btn_Foratura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/foratura.png" runat="server" />
            //            <div class="card-title">
            //                <h5>Foratura</h5>
            //            </div>
            //        </div>
            //    </div>

            Panel wrapper = new Panel();
            wrapper.CssClass = "col";

            Panel card = new Panel();
            card.CssClass = "card text-center postazione form-group";

            Image img = new Image();
            img.CssClass = "mx-auto d-block width-70";
            img.ID = "btn_" + P.ID;
            img.ImageUrl = "~/imgs/ic" + P.Tipo + ".png";

            Panel cardTitle = new Panel();
            cardTitle.CssClass = "card-title";

            Label title = new Label();
            title.Text = P.Tipo.ToUpper() + " - " + P.Tag;

            Button btn = new Button();
            //btn.ID = "btn_" + P.ID + IDUtente;
            btn.Attributes.Add("PID", P.ID.ToString());
            btn.Attributes.Add("UID", IDUtente.ToString());
            //btn.UseSubmitBehavior = true;
            if (Assegnato) {
                btn.Click += new EventHandler(btn_Rimuovi_Click);
                //btn.Click += delegate {
                //    btn_Rimuovi_Click(btn, null);
                //};
                btn.CssClass = "btn btn-warning mx-auto form-control";
                btn.Text = "Rimuovi";
            } else {
                btn.Click += new EventHandler(btn_Assegna_Click);
                //btn.Click += delegate {
                //    btn_Assegna_Click(btn, null);
                //};
                btn.CssClass = "btn btn-success mx-auto form-control";
                btn.Text = "Assegna";
            }

            card.Controls.Add(img);
            cardTitle.Controls.Add(title);
            card.Controls.Add(cardTitle);
            card.Controls.Add(btn);
            wrapper.Controls.Add(card);

            return wrapper;

        }

        protected void drp_Macchinisti_SelectedIndexChanged(object sender, EventArgs e) {
            RedirectWithParms(-1);
        }

        protected void btn_Rimuovi_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int PID = Convert.ToInt32(btn.Attributes["PID"]);
            int UID = Convert.ToInt32(btn.Attributes["UID"]);
            new daoPostazioni().DeleteRelazione(UID, PID);
            RedirectWithParms(UID);
        }

        protected void btn_Assegna_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int PID = Convert.ToInt32(btn.Attributes["PID"]);
            int UID = Convert.ToInt32(btn.Attributes["UID"]);
            new daoPostazioni().AddRelazione(UID, PID);
            RedirectWithParms(UID);
        }

        public void RedirectWithParms(int IDMacch) {
            int macc = IDMacch != -1 ? IDMacch : Convert.ToInt32(drp_Macchinisti.SelectedItem.Value);
            Response.Redirect("assegnapostazione.aspx?idm=" + macc);
        }

    }

}