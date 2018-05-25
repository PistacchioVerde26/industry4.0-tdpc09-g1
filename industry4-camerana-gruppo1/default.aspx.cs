using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page {

    Utente oUtente;

    protected void Page_Load(object sender, EventArgs e) {

        if (Session["utente"] == null) {
            //Response.Redirect("login.aspx");
        }
        //oUtente = (Utente) Session["utente"];
        //DrawPage();
    }

    public void DrawPage() {
        txt_welcomeMessage.InnerText = String.Format("Bentornato {0}, sei un {1}", oUtente.Username, oUtente.Ruolo);//ruolo è intero, estrarre stringa

        List<Postazione> postazioni = null;
        if (oUtente.Ruolo == 1) {
            postazioni = new daoPostazioni().GetBasedOnUtente(oUtente);
        }else if(oUtente.Ruolo == 3) {
            postazioni = new daoPostazioni().GetAll();
            postazioni.Insert(0, new Postazione("Gestione", "commerciale"));
        } else {
            postazioni = new List<Postazione>();
            postazioni.Add(new Postazione("Gestione", "commerciale"));
        }

        if(postazioni != null) {
            Panel row = new Panel();
            row.CssClass = "row";

            int i = 0;
            foreach (Postazione p in postazioni) {
                if (i - 1 % 4 == 0) {
                    container.Controls.Add(row);
                    row = new Panel();
                    row.CssClass = "row";
                }
                row.Controls.Add(CustomDiv(p));
            }
            container.Controls.Add(row);
        }
    }

    public Panel CustomDiv(Postazione P) {

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
        card.CssClass = "card text-center";

        ImageButton imgBtn = new ImageButton();
        imgBtn.CssClass = "mx-auto d-block width-70";
        imgBtn.ID = P.Tipo;
        imgBtn.ImageUrl = "~/imgs/ic" + P.Tipo + ".png";
        imgBtn.Click += new ImageClickEventHandler(btn_Postazione_Click);
        imgBtn.Attributes.Add("idpostazione", P.ID.ToString());

        Panel cardTitle = new Panel();
        cardTitle.CssClass = "card-title";

        Label title = new Label();
        title.Text = P.Tipo + " - " + P.Tag;

        wrapper.Controls.Add(card);
        card.Controls.Add(imgBtn);
        imgBtn.Controls.Add(cardTitle);
        title.Controls.Add(title);

        return wrapper;
    }

    protected void btn_Postazione_Click(object sender, ImageClickEventArgs e) {
        //Codice in base all'id del bottone

        ImageButton btn = (ImageButton)sender;

        Response.Redirect(btn.ID+".aspx?idpost="+btn.Attributes["idpostazione"]);


    }
}