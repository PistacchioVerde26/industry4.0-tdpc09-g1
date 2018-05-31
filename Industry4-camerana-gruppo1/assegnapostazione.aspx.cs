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

        static List<Utente> Macchinisti = null;

        protected void Page_Load(object sender, EventArgs e) {

            if (Macchinisti == null) {
                Macchinisti = new daoUtente().GetByRuolo("macchinista");

                drp_Macchinisti.Items.Add(new ListItem("Seleziona...", "-1"));
                foreach (Utente U in Macchinisti) {
                    drp_Macchinisti.Items.Add(new ListItem(U.Username, U.ID.ToString()));
                }

            }

        }

        public void CaricaPostazioni() {

            //if (drp_Macchinisti.SelectedValue == "-1") return;

            int IDUtente = Convert.ToInt32(drp_Macchinisti.SelectedItem.Value);

            List<Postazione> Postazioni = new daoPostazioni().GetAll();
            Dictionary<int, int> Relazioni = new daoPostazioni().GetUtentePostazioni(IDUtente);

            if (Postazioni != null) {
                Panel row = new Panel();
                row.CssClass = "row";
                int i = 0;
                foreach (Postazione p in Postazioni) {
                    if (i % 4 == 0) {
                        pnl_Postazioni.Controls.Add(row);
                        row = new Panel();
                        row.CssClass = "row";
                    }
                    if (Relazioni.ContainsKey(p.ID)) {
                        row.Controls.Add(CustomDiv(p, IDUtente, true));
                    } else {
                        row.Controls.Add(CustomDiv(p, IDUtente, false));
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
            btn.ID = "btn_" + P.ID + IDUtente;
            btn.Attributes.Add("PID", P.ID.ToString());
            btn.Attributes.Add("UID", IDUtente.ToString());
            btn.Click += Assegnato ? new EventHandler(btn_Rimuovi_Click) : new EventHandler(btn_Assegna_Click);
            if (Assegnato) {
                btn.Click += new EventHandler(btn_Rimuovi_Click);
                btn.CssClass = "btn btn-warning mx-auto form-control";
                btn.Text = "Rimuovi";
            } else {
                btn.Click += new EventHandler(btn_Assegna_Click);
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
            CaricaPostazioni();
        }

        protected void btn_Rimuovi_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;

            new daoPostazioni().AddRelazione(Convert.ToInt32(btn.Attributes["UID"]), Convert.ToInt32(btn.Attributes["PID"]));
            CaricaPostazioni();
        }

        protected void btn_Assegna_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            new daoPostazioni().DeleteRelazione(Convert.ToInt32(btn.Attributes["UID"]), Convert.ToInt32(btn.Attributes["PID"]));
            CaricaPostazioni();
        }

    }

}