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
    public partial class Targowisko : Form
    {
        Osada o1;
        public Targowisko(Osada c1)
        {
            o1 = c1;
            InitializeComponent();
        }
        /// <summary>
        /// zamiana surowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Zamiana surowców na złoto i złoto na surowce
        private void buttonZlotoNaWode_Click(object sender, EventArgs e)
        {
            Zamiana(o1.gold, 2, o1.water, 50);
        }

        private void buttonWodaNaZloto_Click(object sender, EventArgs e)
        {
            Zamiana(o1.water, 100, o1.gold, 1);
        }

        private void buttonZlotoNaJedzenie_Click(object sender, EventArgs e)
        {
            Zamiana(o1.gold, 2, o1.food, 60);
        }

        private void buttonJedzenieNaZloto_Click(object sender, EventArgs e)
        {
            Zamiana(o1.food, 120, o1.gold, 1);
        }

        private void buttonZlotoNaSiano_Click(object sender, EventArgs e)
        {
            Zamiana(o1.gold, 2, o1.hay, 40);
        }

        private void buttonSianoNaZloto_Click(object sender, EventArgs e)
        {
            Zamiana(o1.hay, 80, o1.gold, 1);
        }

        private void buttonZlotoNaKamien_Click(object sender, EventArgs e)
        {
            Zamiana(o1.gold, 2, o1.stone, 50);
        }

        private void buttonKamienNaZloto_Click(object sender, EventArgs e)
        {
            Zamiana(o1.stone, 100, o1.gold, 1);
        }

        private void buttonZlotoNaDrewno_Click(object sender, EventArgs e)
        {
            Zamiana(o1.gold, 2, o1.wood, 100);
        }

        private void buttonDrewnoNaZloto_Click(object sender, EventArgs e)
        {
            Zamiana(o1.wood, 200, o1.gold, 1);
        }

        #endregion

        /// <summary>
        ///  metoda zamiany surowców
        /// </summary>
        /// <param name="materialy"></param>
        /// <param name="ilosc"></param>
        /// <param name="materialy2"></param>
        /// <param name="ilosc2"></param>
        public void Zamiana(Materialy materialy, int ilosc, Materialy materialy2, int ilosc2)
        {
            if(materialy.quantity >= ilosc)
            {
                materialy.quantity -= ilosc;
                materialy2.quantity += ilosc2;
            }
            else
            {
                MessageBox.Show("Brak materiałów!");
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
