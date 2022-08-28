using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anteriora
{
    public partial class BudynekMieszkalny : Form
    {
        Osada o1;
        public BudynekMieszkalny(Osada c1, Poczatek c2)
        {
            o1 = c1;
            InitializeComponent();

            timerBudynekMieszkalny.Start();

            o1.mieszkancy.OkreslZyczeniaMieszkancow(textBoxListaZyczen,o1.mieszkancy);
        }       

        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerBudynekMieszkalny_Tick(object sender, EventArgs e)
        {
            o1.mieszkancy.OkreslZyczeniaMieszkancow(textBoxListaZyczen, o1.mieszkancy);

            if (o1.mieszkancy.liczbaMiejscBudynku == o1.mieszkancy.liczbaMieszkancow)
            {
                o1.mieszkancy.czyPrzyrostMieszkancow = false;
            }

            labelLiczbaMiejscBudynku.Text = o1.mieszkancy.ObliczLiczbeMiejscBudynku(o1.budynekMieszkalny).ToString();
            labelLiczbaMieszkancow.Text = o1.mieszkancy.liczbaMieszkancow.ToString();
            labelLiczbaPracujacychMieszkancow.Text = o1.mieszkancy.liczbaPracujacychMieszkancow.ToString();
            labelLiczbaBezrobotynchMieszkancow.Text = o1.mieszkancy.ObliczLiczbeBezrobotnychMieszkancow().ToString();
            labelPoziomZadowolenia.Text = o1.mieszkancy.poziomZadowolenia.ToString();

            if(o1.mieszkancy.czyPrzyrostMieszkancow == true)
            {
                pictureBoxStrzalka1.Visible = true;
                pictureBoxStrzalka2.Visible = true;
            }
            else if(o1.mieszkancy.czyPrzyrostMieszkancow == false)
            {
                pictureBoxStrzalka1.Visible = false;
                pictureBoxStrzalka2.Visible = false;
            }
        }

        private void buttonOtwarty_Click(object sender, EventArgs e)
        {
            if(o1.ubraniaMieszkancow.ilosc < 1 && o1.lozko.ilosc < 1)
            {
                new Wiadomosc("Brakuje ubrań lub łóżek dla mieszkańców.").ShowDialog();
            }
            else
            {
                o1.mieszkancy.czyPrzyrostMieszkancow = true;
            }
        }

        private void buttonZamkniety_Click(object sender, EventArgs e)
        {
            o1.mieszkancy.czyPrzyrostMieszkancow = false;
        }

        private void buttonSpelnijZyczenia_Click(object sender, EventArgs e)
        {
            switch(o1.mieszkancy.poziomZadowolenia)
            {
                case 0:
                    if (o1.wood.quantity >= 5 * o1.mieszkancy.liczbaMieszkancow)
                    {
                        o1.wood.quantity -= 5 * o1.mieszkancy.liczbaMieszkancow;
                        o1.mieszkancy.poziomZadowolenia = 1;
                    }
                    else
                    {
                        MessageBox.Show("nie jestes w stanie spelnic zyczen mieszkancow");
                    }
                    break;
                case 1:
                    if(o1.wood.quantity >= 10 * o1.mieszkancy.liczbaMieszkancow)
                    {
                        o1.wood.quantity -= 10 * o1.mieszkancy.liczbaMieszkancow;
                        o1.mieszkancy.poziomZadowolenia = 2;
                    }
                    else
                    {
                        MessageBox.Show("nie jestes w stanie spelnic zyczen mieszkancow");
                    }
                    break;
                case 2:
                    if(o1.wood.quantity >= 20 * o1.mieszkancy.liczbaMieszkancow && o1.stone.quantity >= 10 * o1.mieszkancy.liczbaMieszkancow)
                    {
                        o1.wood.quantity -= 20 * o1.mieszkancy.liczbaMieszkancow;
                        o1.stone.quantity -= 10 * o1.mieszkancy.liczbaMieszkancow;
                        o1.mieszkancy.poziomZadowolenia = 3;
                    }
                    else
                    {
                        MessageBox.Show("nie jestes w stanie spelnic zyczen mieszkancow");
                    }
                    break;
                case 3:
                    if (o1.wood.quantity >= 50 * o1.mieszkancy.liczbaMieszkancow && o1.stone.quantity >= 20 * o1.mieszkancy.liczbaMieszkancow && o1.hay.quantity >= 10 * o1.mieszkancy.liczbaMieszkancow)
                    {
                        o1.wood.quantity -= 50 * o1.mieszkancy.liczbaMieszkancow;
                        o1.stone.quantity -= 20 * o1.mieszkancy.liczbaMieszkancow;
                        o1.hay.quantity -= 10 * o1.mieszkancy.liczbaMieszkancow;
                        o1.mieszkancy.poziomZadowolenia = 4;
                    }
                    else
                    {
                        MessageBox.Show("nie jestes w stanie spelnic zyczen mieszkancow");
                    }
                    break;
            }
        }
    }
}
