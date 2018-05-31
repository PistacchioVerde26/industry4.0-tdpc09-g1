using Industry4_camerana_gruppo1.App_Code;
using Industry4_camerana_gruppo1.App_Code.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industry4_camerana_gruppo1 {
    public partial class addpostazione : System.Web.UI.Page {

        static Dictionary<int, string> Tipi = null;

        protected void Page_Load(object sender, EventArgs e) {
            if (Tipi == null) {
                Tipi = new daoPostazioni().GetTipi();

                drp_Tipo.Items.Clear();
                foreach (KeyValuePair<int, string> R in Tipi) {
                    drp_Tipo.Items.Add(new ListItem(R.Value, R.Key.ToString()));
                }
            }

            pnl_Alert.Visible = false;
        }

        protected void btn_AddNewPostazione_Click(object sender, EventArgs e) {

            string Tag = txt_Tag.Text;
            int IDTipo = Convert.ToInt32(drp_Tipo.SelectedItem.Value);

            if (Tag != "") {
                if (new daoPostazioni().CheckTag(Tag) != false) {

                    Postazione P = new Postazione();
                    P.Tag = Tag;
                    P.TipoID = IDTipo;

                    new daoPostazioni().AddPostazione(P);

                    pnl_Alert.Visible = true;
                    pnl_Alert.CssClass = "alert alert-success";
                    lbl_Alert.Text = "<strong>OK!</strong> Postazione inserita con ID ";

                } else {
                    pnl_Alert.Visible = true;
                    pnl_Alert.CssClass = "alert alert-danger";
                    lbl_Alert.Text = "<strong>Errore!</strong> TAG già presente";
                }
            } else {
                pnl_Alert.Visible = true;
                pnl_Alert.CssClass = "alert alert-danger";
                lbl_Alert.Text = "<strong>Errore!</strong> Inserisci un Tag valido";
            }

        }
    }

}