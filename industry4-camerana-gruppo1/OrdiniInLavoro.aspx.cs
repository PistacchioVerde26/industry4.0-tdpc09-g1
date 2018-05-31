using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industry4_camerana_gruppo1
{
    public partial class OrdiniInLavoro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CaricaOrdini();
        }
        protected void CaricaOrdini()
        {

            //tblOdiniLavoro.Rows.Clear();

            //daoLavorazioni daoL = new daoLavorazioni();
            //List<Ordine> listaOr = daoL.GetAllOrdiniCompleto();

            //TableRow tr = new TableRow();
            //TableCell tcNumero = new TableCell();
            //TableCell tcDataInizio = new TableCell();
            //TableCell tcMateriale = new TableCell();
            //TableCell tcColore = new TableCell();
            //TableCell tcForo = new TableCell();
            //TableCell tcTesto = new TableCell();

            //TableCell tcBtnX = new TableCell();
            //TableCell tcBtnModifica = new TableCell();

            //tcNumero.Text = "Numero";
            //tcNumero.BackColor = System.Drawing.Color.LightBlue;
            //tcNumero.Font.Bold = true;
            //tcDataInizio.Text = "Data inserimento";
            //tcDataInizio.BackColor = System.Drawing.Color.LightBlue;
            //tcDataInizio.Font.Bold = true;
            //tcMateriale.Text = "Materiale";
            //tcMateriale.BackColor = System.Drawing.Color.LightBlue;
            //tcMateriale.Font.Bold = true;
            //tcColore.Text = "Colore";
            //tcColore.BackColor = System.Drawing.Color.LightBlue;
            //tcColore.Font.Bold = true;
            //tcForo.Text = "Diametro foro";
            //tcForo.BackColor = System.Drawing.Color.LightBlue;
            //tcForo.Font.Bold = true;
            //tcTesto.Text = "Testo";
            //tcTesto.BackColor = System.Drawing.Color.LightBlue;
            //tcTesto.Font.Bold = true;
            //tcBtnX.Text = "  ";
            //tcBtnX.BackColor = System.Drawing.Color.LightBlue;
            //tcBtnModifica.Text = "  ";
            //tcBtnModifica.BackColor = System.Drawing.Color.LightBlue;
            //tr.Cells.Add(tcNumero);
            //tr.Cells.Add(tcDataInizio);
            //tr.Cells.Add(tcMateriale);
            //tr.Cells.Add(tcColore);
            //tr.Cells.Add(tcForo);
            //tr.Cells.Add(tcTesto);
            //tr.Cells.Add(tcBtnModifica);
            //tr.Cells.Add(tcBtnX);
            //tblOdini.Rows.Add(tr);
            //if (listaOr.Count > 0)
            //{

            //    // tblUtenti.Rows.Add(tr);

            //    int rowNum = 0;
            //    foreach (Ordine Or in listaOr)
            //    {
            //        TableRow tr1 = new TableRow();
            //        TableCell tcNumero1 = new TableCell();
            //        TableCell tcDataInizio1 = new TableCell();
            //        TableCell tcMateriale1 = new TableCell();
            //        TableCell tcColore1 = new TableCell();
            //        TableCell tcForo1 = new TableCell();
            //        TableCell tcTesto1 = new TableCell();
            //        TableCell tcBtnX1 = new TableCell();
            //        TableCell tcBtnModifica1 = new TableCell();
            //        //tblUtenti.Rows.Add(tr);
            //        rowNum += 1;
            //        tcNumero1.Text = rowNum.ToString();
            //        tcDataInizio1.Text = Or.DataInserimento.ToString();
            //        tcMateriale1.Text = Or.Lavorazioni[2].Note;
            //        tcColore1.Text = Or.Lavorazioni[1].Note; ;
            //        tcForo1.Text = Or.Lavorazioni[0].Note;
            //        tcTesto1.Text = Or.Lavorazioni[3].Note;
            //        Button btnM = new Button();
            //        btnM.Text = "Modifica";
            //        //btnM.CommandArgument = u.ID;
            //        //btnM.BackColor = System.Drawing.Color.CadetBlue;
            //        btnM.Click += new EventHandler(operazioneUtente);
            //        btnM.CssClass = "btn btn-warning";
            //        tcBtnModifica1.Controls.Add(btnM);
            //        Button btn = new Button();
            //        btn.Text = "X";
            //        //btn.CommandArgument = u.ID;
            //        btn.ID = "X_" + Or.ID.ToString();
            //        btn.BackColor = System.Drawing.Color.Red;
            //        btn.Attributes.Add("id_ordine", Or.ID.ToString());
            //        btn.Click += new EventHandler(operazioneUtente);
            //        btn.CssClass = "btn btn-danger";
            //        tcBtnX1.Controls.Add(btn);

            //        tr1.Cells.Add(tcNumero1);
            //        tr1.Cells.Add(tcDataInizio1);
            //        tr1.Cells.Add(tcMateriale1);
            //        tr1.Cells.Add(tcColore1);
            //        tr1.Cells.Add(tcForo1);
            //        tr1.Cells.Add(tcTesto1);
            //        tr1.Cells.Add(tcBtnModifica1);
            //        tr1.Cells.Add(tcBtnX1);
            //        tblOdini.Rows.Add(tr1);
             //   }
         //   }
        }
    }
}