using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txbUsername.Text != "" & txbPassword.Text != "")
        {
            Utente oUtente = new Utente();
            oUtente.Username = txbUsername.Text;
            oUtente.Password = txbPassword.Text;
            daoUtente daoU = new daoUtente();
            oUtente = daoU.getLogin(oUtente);
            if (oUtente.ID > 0)
            {
                //loggato redirect alla pagina
                switch (oUtente.Ruolo)
                {
                    case 1:
                        Session.Add("utente", oUtente);
                        Response.Redirect("default.aspx");
                        break;
                    default:
                        break;
                }

            }
            else
            {
                txbUsername.Text = "";
                txbPassword.Text = "";
            }

        }
    }
}