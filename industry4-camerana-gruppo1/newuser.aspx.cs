using Industry4_camerana_gruppo1.App_Code;
using Industry4_camerana_gruppo1.App_Code.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industry4_camerana_gruppo1 {
    public partial class newuser : System.Web.UI.Page {

        static Dictionary<int, string> Ruoli = null;

        protected void Page_Load(object sender, EventArgs e) {

            if (Session["utente"] == null) {
                Response.Redirect("login.aspx");
            }

            if (Ruoli == null) {
                Ruoli = new daoGeneric().GetAllRuoli();

                drp_Ruolo.Items.Clear();
                foreach (KeyValuePair<int, string> R in Ruoli) {
                    drp_Ruolo.Items.Add(new ListItem(R.Value, R.Key.ToString()));
                }
            }

            pnl_Alert.Visible = false;

        }

        protected void btn_AddNewUser_Click(object sender, EventArgs e) {

            string Nome = txt_Nome.Text;
            string Pw = txt_Password.Text;
            int idRuolo = Convert.ToInt32(drp_Ruolo.SelectedItem.Value);

            if(Nome != "" && Pw != "") {
                if(new daoUtente().CheckUsername(Nome) != false) {
                    Utente U = new Utente();
                    U.Username = Nome;
                    U.Password = Pw;
                    U.Ruolo = idRuolo;

                    new daoUtente().insertUtente(U);

                    pnl_Alert.Visible = true;
                    pnl_Alert.CssClass = "alert alert-success";
                    lbl_Alert.Text = "<strong>OK!</strong> Utente inserito con ID ";

                }
            } else {
                pnl_Alert.Visible = true;
                pnl_Alert.CssClass = "alert alert-danger";
                lbl_Alert.Text = "<strong>Errore!</strong> Inserisci un nome utente e una password validi";
            }

        }
    }
}