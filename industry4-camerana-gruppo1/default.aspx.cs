using Industry4_camerana_gruppo1.App_Code;
using Industry4_camerana_gruppo1.App_Code.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industry4_camerana_gruppo1
{
    public partial class _default : System.Web.UI.Page
    {
        Utente oUtente;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["utente"] == null)
            {
                Response.Redirect("login.aspx");
            }
            oUtente = (Utente)Session["utente"];
            DrawPage();
        }

        public void DrawPage()
        {
            txt_welcomeMessage.InnerText = String.Format("Bentornato {0}, sei un {1}", oUtente.Username, oUtente.RuoloToString());//ruolo è intero, estrarre stringa

            List<Postazione> postazioni = null;
            if (oUtente.Ruolo == 1)
            {
                postazioni = new daoPostazioni().GetBasedOnUtente(oUtente);
            }
            else if (oUtente.Ruolo == 3)
            {
                postazioni = new daoPostazioni().GetAll();
                postazioni.Add(new Postazione("Gestione", "commerciale"));
            }
            else
            {
                postazioni = new List<Postazione>();
                postazioni.Add(new Postazione("Gestione", "commerciale"));
            }

            if (postazioni != null)
            {
                Panel row = new Panel();
                row.CssClass = "row";

                int i = 0;
                foreach (Postazione p in postazioni)
                {
                    if (i % 4 == 0)
                    {
                        container.Controls.Add(row);
                        row = new Panel();
                        row.CssClass = "row";
                    }
                    row.Controls.Add(CustomDiv(p));
                    i++;
                }
                container.Controls.Add(row);
            }
        }

        public Panel CustomDiv(Postazione P)
        {

            //  <div class="col" runat="server" id="div_Foratura">
            //        <div class="card text-center">
            //            <asp:ImageButton ID = "btn_Foratura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/foratura.png" runat="server" />
            //            <div class="card-title">
            //                <span>Foratura</span>
            //            </div>
            //        </div>
            //    </div>

            Panel wrapper = new Panel();
            wrapper.CssClass = "col";


            Panel card = new Panel();
            card.CssClass = "card text-center postazione";

            ImageButton imgBtn = new ImageButton();
            imgBtn.CssClass = "mx-auto d-block width-70";
            imgBtn.ID = P.Tipo;
            imgBtn.ImageUrl = "~/imgs/ic" + P.Tipo + ".png";
            imgBtn.Click += new ImageClickEventHandler(btn_Postazione_Click);
            imgBtn.Attributes.Add("idpostazione", P.ID.ToString());
            imgBtn.Attributes.Add("tipo", P.Tipo);

            Panel cardTitle = new Panel();
            cardTitle.CssClass = "card-title";

            Label title = new Label();
            title.Text = P.Tipo + " - " + P.Tag;

            card.Controls.Add(imgBtn);
            cardTitle.Controls.Add(title);
            card.Controls.Add(cardTitle);
            wrapper.Controls.Add(card);

            return wrapper;
        }

        protected void btn_Postazione_Click(object sender, ImageClickEventArgs e)
        {
            //Codice in base all'id del bottone

            ImageButton btn = (ImageButton)sender;

            if (btn.Attributes["tipo"] != "commerciale")
                Response.Redirect(btn.ID + ".aspx?pid=" + btn.Attributes["idpostazione"]);
            else
                Response.Redirect("nuovordine.aspx");
        }

        protected void btn_Materiale_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}