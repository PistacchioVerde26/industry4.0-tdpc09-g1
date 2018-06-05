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
    public partial class ordiniInseriti : System.Web.UI.Page
    {
        static bool nascondi = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                CaricaOrdini();
                CaricaOrdiniLav();
            //}

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //CaricaOrdini();
        }

        protected void CaricaOrdini()
        {

            tblOdini.Rows.Clear();

            daoLavorazioni daoL = new daoLavorazioni();
            List<Ordine> listaOr = daoL.GetAllOrdiniCompleto();

            TableRow tr = new TableRow();
            TableCell tcNumero = new TableCell();
            TableCell tcIdOrdine = new TableCell();
            TableCell tcDataInizio = new TableCell();
            TableCell tcMateriale = new TableCell();
            TableCell tcColore = new TableCell();
            TableCell tcForo = new TableCell();
            TableCell tcTesto = new TableCell();

            TableCell tcBtnX = new TableCell();
            //TableCell tcBtnModifica = new TableCell();

            tcNumero.Text = "Numero";
            tcNumero.BackColor = System.Drawing.Color.LightBlue;
            tcNumero.Font.Bold = true;
            tcIdOrdine.Text = "Id";
            tcIdOrdine.BackColor = System.Drawing.Color.LightBlue;
            tcIdOrdine.Font.Bold = true;
            tcDataInizio.Text = "Data inserimento";
            tcDataInizio.BackColor = System.Drawing.Color.LightBlue;
            tcDataInizio.Font.Bold = true;
            tcMateriale.Text = "Materiale";
            tcMateriale.BackColor = System.Drawing.Color.LightBlue;
            tcMateriale.Font.Bold = true;
            tcColore.Text = "Colore";
            tcColore.BackColor = System.Drawing.Color.LightBlue;
            tcColore.Font.Bold = true;
            tcForo.Text = "Diametro foro";
            tcForo.BackColor = System.Drawing.Color.LightBlue;
            tcForo.Font.Bold = true;
            tcTesto.Text = "Testo";
            tcTesto.BackColor = System.Drawing.Color.LightBlue;
            tcTesto.Font.Bold = true;
            tcBtnX.Text = "  ";
            tcBtnX.BackColor = System.Drawing.Color.LightBlue;
            // tcBtnModifica.Text = "  ";
            // tcBtnModifica.BackColor = System.Drawing.Color.LightBlue;
            tr.Cells.Add(tcNumero);
            tr.Cells.Add(tcIdOrdine);
            tr.Cells.Add(tcDataInizio);
            tr.Cells.Add(tcMateriale);
            tr.Cells.Add(tcColore);
            tr.Cells.Add(tcForo);
            tr.Cells.Add(tcTesto);
            // tr.Cells.Add(tcBtnModifica);
            tr.Cells.Add(tcBtnX);
            tblOdini.Rows.Add(tr);
            List<Ordine> newListOr = new List<Ordine>();

            if (listaOr.Count > 0)
            {
                foreach (Ordine Or in listaOr)
                {
                    if (Or.Lavorazioni.All(o => o.Stato == 0))
                    {
                        newListOr.Add(Or);
                    }
                }
            }
            if (newListOr.Count > 0)
            {

                // tblUtenti.Rows.Add(tr);

                int rowNum = 0;
                foreach (Ordine Or in newListOr)
                {
                    TableRow tr1 = new TableRow();
                    TableCell tcNumero1 = new TableCell();
                    TableCell tcIdOrdine1 = new TableCell();
                    TableCell tcDataInizio1 = new TableCell();
                    TableCell tcMateriale1 = new TableCell();
                    TableCell tcColore1 = new TableCell();
                    TableCell tcForo1 = new TableCell();
                    TableCell tcTesto1 = new TableCell();
                    TableCell tcBtnX1 = new TableCell();
                    //TableCell tcBtnModifica1 = new TableCell();
                    //tblUtenti.Rows.Add(tr);
                    rowNum += 1;
                    tcNumero1.Text = rowNum.ToString();
                    tcIdOrdine1.Text = Or.ID.ToString();
                    tcDataInizio1.Text = Or.DataInserimento.ToString();
                    tcMateriale1.Text = Or.Lavorazioni[2].Note;
                    tcColore1.Text = Or.Lavorazioni[1].Note; ;
                    tcForo1.Text = Or.Lavorazioni[0].Note;
                    tcTesto1.Text = Or.Lavorazioni[3].Note;
                    //Button btnM = new Button();
                    //btnM.Text = "Modifica";
                    //btnM.CommandArgument = u.ID;
                    //btnM.BackColor = System.Drawing.Color.CadetBlue;
                    //btnM.Click += new EventHandler(operazioneUtente);
                    //btnM.CssClass = "btn btn-warning";
                    //  tcBtnModifica1.Controls.Add(btnM);
                    Button btn = new Button();
                    btn.Text = "X";
                    //btn.CommandArgument = u.ID;
                    btn.ID = "X_" + Or.ID.ToString();
                    btn.UseSubmitBehavior = true;
                    btn.BackColor = System.Drawing.Color.Red;
                    btn.Attributes.Add("id_ordine", Or.ID.ToString());
                    btn.Click += new EventHandler(operazioneUtente);
                    btn.CssClass = "btn btn-danger";
                    tcBtnX1.Controls.Add(btn);

                    tr1.Cells.Add(tcNumero1);
                    tr1.Cells.Add(tcIdOrdine1);
                    tr1.Cells.Add(tcDataInizio1);
                    tr1.Cells.Add(tcMateriale1);
                    tr1.Cells.Add(tcColore1);
                    tr1.Cells.Add(tcForo1);
                    tr1.Cells.Add(tcTesto1);
                    // tr1.Cells.Add(tcBtnModifica1);
                    tr1.Cells.Add(tcBtnX1);
                    tblOdini.Rows.Add(tr1);
                }
            }
        }
        protected void operazioneUtente(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id_ord = Convert.ToInt32(btn.Attributes["Id_ordine"]);
            if (id_ord != 0)
            {
                daoOrdine daoO = new daoOrdine();
                daoO.DeleteByIdordine(id_ord);
                CaricaOrdini();
            }
        }
        protected void CaricaOrdiniLav()
        {

            tblOdiniLavoro.Rows.Clear();

            daoLavorazioni daoL = new daoLavorazioni();
            List<Ordine> listaOr = daoL.GetOrdiniLavoro();

            TableRow tr = new TableRow();
            TableCell tcNumero = new TableCell();
            TableCell tcIdOrdine = new TableCell();
            TableCell tcDataInizio = new TableCell();
            TableCell tcMateriale = new TableCell();
            TableCell tcColore = new TableCell();
            TableCell tcForo = new TableCell();
            TableCell tcTesto = new TableCell();
            TableCell tcRisultato = new TableCell();


            tcNumero.Text = "Numero";
            tcNumero.BackColor = System.Drawing.Color.LightBlue;
            tcNumero.Font.Bold = true;
            tcIdOrdine.Text = "Id";
            tcIdOrdine.BackColor = System.Drawing.Color.LightBlue;
            tcIdOrdine.Font.Bold = true;
            tcDataInizio.Text = "Data inserimento";
            tcDataInizio.BackColor = System.Drawing.Color.LightBlue;
            tcDataInizio.Font.Bold = true;
            tcMateriale.Text = "Materiale ".PadRight(30);
            tcMateriale.BackColor = System.Drawing.Color.LightBlue;
            tcMateriale.Font.Bold = true;
            tcColore.Text = "Colore ".PadRight(30);
            tcColore.BackColor = System.Drawing.Color.LightBlue;
            tcColore.Font.Bold = true;
            tcForo.Text = "D foro ".PadRight(30);
            tcForo.BackColor = System.Drawing.Color.LightBlue;
            tcForo.Font.Bold = true;
            tcTesto.Text = "Testo ".PadRight(30);
            tcTesto.BackColor = System.Drawing.Color.LightBlue;
            tcTesto.Font.Bold = true;
            tcRisultato.Text = "Risultato ".PadRight(30);
            tcRisultato.BackColor = System.Drawing.Color.LightBlue;
            tcRisultato.Font.Bold = true;

            tr.Cells.Add(tcNumero);
            tr.Cells.Add(tcIdOrdine);
            tr.Cells.Add(tcDataInizio);
            tr.Cells.Add(tcMateriale);
            tr.Cells.Add(tcColore);
            tr.Cells.Add(tcForo);
            tr.Cells.Add(tcTesto);
            tr.Cells.Add(tcRisultato);

            tblOdiniLavoro.Rows.Add(tr);

            List<Ordine> newListOr = new List<Ordine>();

            if (listaOr.Count > 0)
            {
                foreach (Ordine Or in listaOr)
                {
                    if (Or.Lavorazioni.Any(o => o.Stato != 0))
                    {
                        newListOr.Add(Or);
                    }
                }
            }

            if (newListOr.Count > 0)
            {

                // tblUtenti.Rows.Add(tr);

                int rowNum = 0;
                foreach (Ordine Or in newListOr)
                {
                    TableRow tr1 = new TableRow();
                    TableCell tcNumero1 = new TableCell();
                    TableCell tcIdOrdine1 = new TableCell();
                    TableCell tcDataInizio1 = new TableCell();
                    TableCell tcMateriale1 = new TableCell();
                    TableCell tcColore1 = new TableCell();
                    TableCell tcForo1 = new TableCell();
                    TableCell tcTesto1 = new TableCell();
                    TableCell tcRisultato1 = new TableCell();


                    rowNum += 1;
                    tcNumero1.Text = rowNum.ToString();
                    tcIdOrdine1.Text = Or.ID.ToString();
                    tcDataInizio1.Text = Or.DataInserimento.ToString();
                    tcMateriale1.Text = Or.Lavorazioni[2].Note;
                    TimeSpan diffT = new TimeSpan();
                    if (Or.Lavorazioni[2].Stato == 1)
                    {
                        tcMateriale1.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (Or.Lavorazioni[2].Stato == 2)
                    {
                        tcMateriale1.BackColor = System.Drawing.Color.Green;
                        diffT = new TimeSpan();
                        if (!Or.Lavorazioni[2].Inizio.Equals(default(DateTime)) & !Or.Lavorazioni[2].Fine.Equals(default(DateTime))) {
                            diffT += Or.Lavorazioni[2].Fine.Subtract(Or.Lavorazioni[2].Inizio);
                        }
                        tcMateriale1.Text += "- " + diffT.ToString();       // Or.Lavorazioni[2].Fine.ToString();
                    }
                    tcColore1.Text = Or.Lavorazioni[1].Note;
                    if (Or.Lavorazioni[1].Stato == 1)
                    {
                        tcColore1.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (Or.Lavorazioni[1].Stato == 2)
                    {
                        tcColore1.BackColor = System.Drawing.Color.Green;
                        diffT = new TimeSpan();
                        if (!Or.Lavorazioni[1].Inizio.Equals(default(DateTime)) & !Or.Lavorazioni[1].Fine.Equals(default(DateTime)))
                        {
                            diffT += Or.Lavorazioni[1].Fine.Subtract(Or.Lavorazioni[1].Inizio);
                        }
                        tcColore1.Text += "- " + diffT.ToString();       //Or.Lavorazioni[1].Fine.ToString();
                    }
                    tcForo1.Text = Or.Lavorazioni[0].Note;
                    if (Or.Lavorazioni[0].Stato == 1)
                    {
                        tcForo1.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (Or.Lavorazioni[0].Stato == 2)
                    {
                        tcForo1.BackColor = System.Drawing.Color.Green;
                        diffT = new TimeSpan();
                        if (!Or.Lavorazioni[0].Inizio.Equals(default(DateTime)) & !Or.Lavorazioni[0].Fine.Equals(default(DateTime)))
                        {
                            diffT += Or.Lavorazioni[0].Fine.Subtract(Or.Lavorazioni[0].Inizio);
                        }
                        tcForo1.Text += "- " + diffT.ToString();       //Or.Lavorazioni[0].Fine.ToString();
                    }
                    tcTesto1.Text = Or.Lavorazioni[3].Note;
                    if (Or.Lavorazioni[3].Stato == 1)
                    {
                        tcTesto1.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (Or.Lavorazioni[3].Stato == 2)
                    {
                        tcTesto1.BackColor = System.Drawing.Color.Green;
                        diffT = new TimeSpan();
                        if (!Or.Lavorazioni[3].Inizio.Equals(default(DateTime)) & !Or.Lavorazioni[3].Fine.Equals(default(DateTime)))
                        {
                            diffT += Or.Lavorazioni[3].Fine.Subtract(Or.Lavorazioni[3].Inizio);
                        }
                        tcTesto1.Text += "- " + diffT.ToString();       //Or.Lavorazioni[3].Fine.ToString();
                    }
                    
                    //if (Or.Lavorazioni.All(l=>l.Inizio!=null & l.Fine != null))
                    //{
                    //    TimeSpan diffT = new TimeSpan();
                    //    foreach(Lavorazione lav in Or.Lavorazioni)
                    //    {
                            
                    //        if(!lav.Inizio.Equals(default(DateTime)) & !lav.Fine.Equals(default(DateTime))) diffT += lav.Fine.Subtract(lav.Inizio);

                    //    }
                    //    tcRisultato1.Text += diffT.ToString();
                    //}
                    
                    if (Or.Lavorazioni.All(l => l.Stato == 2))
                    {
                        tcRisultato1.Text = "Finito ";
                        if (!Or.Lavorazioni[3].Fine.Equals(default(DateTime)))
                        {
                            tcRisultato1.Text += Or.Lavorazioni[3].Fine.ToString();
                        }
                        tcRisultato1.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        tcRisultato1.Text = "In lavorazione ";
                        tcRisultato1.BackColor = System.Drawing.Color.Yellow;
                    }

                    tr1.Cells.Add(tcNumero1);
                    tr1.Cells.Add(tcIdOrdine1);
                    tr1.Cells.Add(tcDataInizio1);
                    tr1.Cells.Add(tcMateriale1);
                    tr1.Cells.Add(tcColore1);
                    tr1.Cells.Add(tcForo1);
                    tr1.Cells.Add(tcTesto1);
                    tr1.Cells.Add(tcRisultato1);
                    if (tcRisultato1.Text == "In lavorazione ")
                    {
                        tblOdiniLavoro.Rows.Add(tr1);
                    }
                    else
                    {
                        if (!nascondi)
                        {
                            tblOdiniLavoro.Rows.Add(tr1);
                        }
                    }
                }
            }
        }

        protected void cbNascondiOK_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                nascondi = true;
            }
            else
            {
                nascondi = false;
            }
            CaricaOrdini();
            CaricaOrdiniLav();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            CaricaOrdini();
            CaricaOrdiniLav();
        }
    }
}