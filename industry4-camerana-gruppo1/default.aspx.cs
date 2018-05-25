using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["utente"] == null)
        {
            //Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {

            Utente oUtente = (Utente)Session["utente"];
            if (oUtente == null)
            {
                Response.Redirect("login.aspx");
            }
            txt_welcomeMessage.InnerText = string.Format("Bentornato {0} - sei un Amministratore ", oUtente.Username);

        }
    }

    protected void btn_Commerciale_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nuovordine.aspx");
    }
}