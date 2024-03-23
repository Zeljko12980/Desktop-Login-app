using System;
using System.Drawing;
using System.Windows.Forms;

namespace DomacaRabota
{
    public partial class frmPIN : Form
    {
        private bool zakljucano = true;
        private int brIspravnih = 0;
        private int brNeispravnih = 0;
        public frmPIN()
        {
            InitializeComponent();
            lblIspravnih.Text = "Ispravnih pokušaja: " + brIspravnih;
            lblNeispravnih.Text = "Pogrešnih pokušaja: " + brNeispravnih;
            zakljucaj();
        }

        private void zakljucaj()
        {
            btnLockUnlock.Text = "Otključaj";
            btnLockUnlock.Image = Properties.Resources.button_Unlock;
            this.BackColor = Color.PapayaWhip;
            statusStrip1.BackColor=Color.PapayaWhip;
            txtPIN.Enabled = true; // Omogući unos PIN koda samo ako je aplikacija zaključana
            zakljucano = true;
        }

        private void otkljucaj()
        {
            if (txtPIN.Text.Trim() == "2177")
            {
                this.BackColor = Color.LightGreen;
                btnLockUnlock.Text = "Zaključaj";
                btnLockUnlock.Image = Properties.Resources.button_Lock;
                txtPIN.Clear();
                brIspravnih++;
                lblIspravnih.Text = "Ispravnih pokušaja: " + brIspravnih;
                zakljucano = false; // Postavi stanje aplikacije na otključano
                statusStrip1.BackColor = Color.LightGreen;

                // Onemogući dugme za unos PIN koda nakon otključavanja
                txtPIN.Enabled = false;
            }
            else
            {
                brNeispravnih++;
                lblNeispravnih.Text = "Pogrešnih pokušaja: " + brNeispravnih;
                txtPIN.Clear();
            }
        }


        private void btnLockUnlock_Click(object sender, EventArgs e)
        {
            if (zakljucano)
            {
                otkljucaj();
            }
            else
            {
                zakljucaj();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(txtPIN.Text.Length<8 && txtPIN.Enabled)
            {
                Button btn=(Button)sender;
                txtPIN.Text += btn.Text;

            }
            else if(txtPIN.Enabled)
            {
                MessageBox.Show("Pin moze da sadrzi maksimalno 8 karaktera!","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtPIN.Clear();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if(txtPIN.Text.Length>0)
            {
                txtPIN.Text=txtPIN.Text.Substring(0,txtPIN.Text.Length-1);
            }
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            txtPIN.Clear();
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            brIspravnih = 0;
            brNeispravnih = 0;
            lblIspravnih.Text = "Ispravnih pokušaja: " + brIspravnih;
            lblNeispravnih.Text = "Pogrešnih pokušaja: " + brNeispravnih;
            txtPIN.Clear();
            zakljucano = true; // Vrati aplikaciju u početno stanje - zaključano
            zakljucaj(); // Ponovo zaključaj aplikaciju
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            DialogResult odgovor = MessageBox.Show("Da li ste sigurni da želite da zatvorite aplikaciju?", "Zatvori aplikaciju", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (odgovor == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
