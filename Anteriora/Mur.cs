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
    public partial class Mur : Form
    {
        //PoleBitwy p;
        Osada o;

        public Mur(Osada c)
        {
            o = c;
            InitializeComponent();
            timer.Start();
        }

        private void ButtonPowrot_Click(object sender, EventArgs e)
        {
            this.Close();
            new OblezenieOsady(o,o.osadaGoblinow,o.osadaGoblinow1).Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            labelLiczebnoscPiechur.Text = o.piechur.liczebnoscAtakujacych.ToString();
            labelLiczebnoscLucznik.Text = o.lucznik.liczebnoscAtakujacych.ToString();
            labelLiczebnoscRycerz.Text = o.rycerz.liczebnoscAtakujacych.ToString();
            labelLiczebnoscCzarnyRycerz.Text = o.czarnyRycerz.liczebnoscAtakujacych.ToString();
            labelLiczebnoscCzarnyLucznik.Text = o.czarnyLucznik.liczebnoscAtakujacych.ToString();
            labelLiczebnoscPiechurMur.Text = o.piechur.liczebnoscBroniacych.ToString();
            labelLiczebnoscLucznikMur.Text = o.lucznik.liczebnoscBroniacych.ToString();
            labelLiczebnoscRycerzMur.Text = o.rycerz.liczebnoscBroniacych.ToString();
            labelLiczebnoscCzarnyRycerzMur.Text = o.czarnyRycerz.liczebnoscBroniacych.ToString();
            labelLiczebnoscCzarnyLucznikMur.Text = o.czarnyLucznik.liczebnoscBroniacych.ToString();

            if (o.piechur.liczebnoscBroniacych > 0)
            {
                pictureBoxPiechurMur.Image = o.piechur.obrazekGora;
            }
            else
            {
                pictureBoxPiechurMur.Image = null;
            }

            if(o.lucznik.liczebnoscBroniacych > 0)
            {
                pictureBoxLucznikMur.Image = o.lucznik.obrazekGora;
            }
            else
            {
                pictureBoxLucznikMur.Image = null;
            }

            if(o.rycerz.liczebnoscBroniacych > 0)
            {
                pictureBoxRycerzMur.Image = o.rycerz.obrazekGora;
            }
            else
            {
                pictureBoxRycerzMur.Image = null;
            }

            if(o.czarnyRycerz.liczebnoscBroniacych > 0)
            {
                pictureBoxCzarnyRycerzMur.Image = o.czarnyRycerz.obrazekGora;
            }
            else
            {
                pictureBoxCzarnyRycerzMur.Image = null;
            }

            if(o.czarnyLucznik.liczebnoscBroniacych > 0 )
            {
                pictureBoxCzarnyLucznikMur.Image = o.czarnyLucznik.obrazekGora;
            }
            else
            {
                pictureBoxCzarnyLucznikMur.Image = null;
            }  
        }

        #region Wpisywanie tylko cyfr do textboxow

        private void TextBoxIloscWyslijPiechur_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }        

        private void TextBoxIloscWyslijLucznik_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscWyslijRycerz_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscWyslijCzarnyRycerz_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscWyslijCzarnyLucznik_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscOdeslijLucznik_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscOdeslijCzarnyLucznik_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscOdeslijCzarnyRycerz_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscOdeslijRycerz_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        private void TextBoxIloscOdeslijPiechur_KeyPress(object sender, KeyPressEventArgs e)
        {
            WpiszTylkoCyfry(e);
        }

        public void WpiszTylkoCyfry(KeyPressEventArgs eventArgs)
        {
            if (!char.IsControl(eventArgs.KeyChar) && !char.IsDigit(eventArgs.KeyChar) && (eventArgs.KeyChar != '.'))
            {
                eventArgs.Handled = true;
            }
        }

        #endregion

        #region Wyslij jednostki na mur

        private void ButtonWyslijPiechur_Click(object sender, EventArgs e)
        {
            WyslijJednostkeNaMur(o.piechur, textBoxIloscWyslijPiechur);
        }

        private void ButtonWyslijLucznik_Click(object sender, EventArgs e)
        {
            WyslijJednostkeNaMur(o.lucznik, textBoxIloscWyslijLucznik);
        }

        private void ButtonWyslijRycerz_Click(object sender, EventArgs e)
        {
            WyslijJednostkeNaMur(o.rycerz, textBoxIloscWyslijRycerz);
        }

        private void ButtonWyslijCzarnyRycerz_Click(object sender, EventArgs e)
        {
            WyslijJednostkeNaMur(o.czarnyRycerz, textBoxIloscWyslijCzarnyRycerz);
        }

        private void ButtonWyslijCzarnyLucznik_Click(object sender, EventArgs e)
        {
            WyslijJednostkeNaMur(o.czarnyLucznik, textBoxIloscWyslijCzarnyLucznik);
        }

        public void WyslijJednostkeNaMur(JednostkiGracza jednostka, TextBox textbox)
        {
            int liczebnoscJednostekDoWyslaniaNaMur = Convert.ToInt32(textbox.Text);

            if (jednostka.liczebnoscAtakujacych > 0 && jednostka.liczebnoscAtakujacych >= liczebnoscJednostekDoWyslaniaNaMur)
            {
                jednostka.liczebnoscAtakujacych -= liczebnoscJednostekDoWyslaniaNaMur;
                jednostka.liczebnoscBroniacych += liczebnoscJednostekDoWyslaniaNaMur;
            }
            else
            {
                new Wiadomosc("Brak odpowiedniej liczby jednostek.").Show();
            }
        }

        #endregion

        #region Odeślij jednostkę

        private void ButtonOdeslijPiechur_Click(object sender, EventArgs e)
        {
            OdeslijJednostke(o.piechur, textBoxIloscOdeslijPiechur);
        }

        private void ButtonOdeslijRycerz_Click(object sender, EventArgs e)
        {
            OdeslijJednostke(o.rycerz, textBoxIloscOdeslijRycerz);
        }

        private void ButtonOdeslijCzarnyRycerz_Click(object sender, EventArgs e)
        {
            OdeslijJednostke(o.czarnyRycerz, textBoxIloscOdeslijCzarnyRycerz);
        }

        private void ButtonOdeslijLucznik_Click(object sender, EventArgs e)
        {
            OdeslijJednostke(o.lucznik, textBoxIloscOdeslijLucznik);
        }

        private void ButtonOdeslijCzarnyLucznik_Click(object sender, EventArgs e)
        {
            OdeslijJednostke(o.czarnyLucznik, textBoxIloscOdeslijCzarnyLucznik);
        }

        public void OdeslijJednostke(JednostkiGracza jednostka, TextBox textbox)
        {
            int liczebnoscJednostekDoOdeslania = Convert.ToInt32(textbox.Text);

            if (jednostka.liczebnoscBroniacych > 0 && jednostka.liczebnoscBroniacych >= liczebnoscJednostekDoOdeslania)
            {
                jednostka.liczebnoscAtakujacych += liczebnoscJednostekDoOdeslania;
                jednostka.liczebnoscBroniacych -= liczebnoscJednostekDoOdeslania;
            }
            else
            {
                new Wiadomosc("Nie masz tylu jednostek na murze.").Show();
            }
        }

        #endregion

        private void Mur_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
