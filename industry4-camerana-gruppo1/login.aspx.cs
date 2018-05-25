using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        pnl_Error.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e) {
        if (txbUsername.Text != "" & txbPassword.Text != "") {
            Utente oUtente = new Utente();
            oUtente.Username = txbUsername.Text;
            oUtente.Password = txbPassword.Text;
            daoUtente daoU = new daoUtente();
            oUtente = daoU.getLogin(oUtente);
            if (oUtente.ID > 0) {
                Session.Add("utente", oUtente);
                Response.Redirect("default.aspx");
            } else {
                txbUsername.Text = "";
                txbPassword.Text = "";
                pnl_Error.Visible = true;
            }
        }
        pnl_Error.Visible = true;
    }
}