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
    public partial class Panel5 : Form
    {
        Osada o1;
        Panel o2;

        bool czyRuch;
        Point start = new Point(0, 0);

        public Panel5(Osada c1, Panel c2)
        {
            o1 = c1;
            o2 = c2;
            InitializeComponent();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelSkora.Text = o1.skin.quantity.ToString();
            labelRudaZelaza.Text = o1.ironOre.quantity.ToString();
            labelZelazo.Text = o1.iron.quantity.ToString();
            labelRudaObsydianu.Text = o1.obsidianOre.quantity.ToString();
            labelObsydian.Text = o1.obsidian.quantity.ToString();
            labelKawalekDrewna.Text = o1.pieceOfWood.quantity.ToString();
            labelSkorzanyPasek.Text = o1.leatherBelt.quantity.ToString();
            labelWelna.Text = o1.wool.quantity.ToString();

            o2.ZmianaKoloruTekstuLabela(o1.skin, labelSkora);
            o2.ZmianaKoloruTekstuLabela(o1.ironOre, labelRudaZelaza);
            o2.ZmianaKoloruTekstuLabela(o1.iron, labelZelazo);
            o2.ZmianaKoloruTekstuLabela(o1.obsidianOre, labelRudaObsydianu);
            o2.ZmianaKoloruTekstuLabela(o1.obsidian, labelObsydian);
            o2.ZmianaKoloruTekstuLabela(o1.pieceOfWood, labelKawalekDrewna);
            o2.ZmianaKoloruTekstuLabela(o1.leatherBelt, labelSkorzanyPasek);
            o2.ZmianaKoloruTekstuLabela(o1.wool, labelWelna);

        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            this.Close();
            o2.czyPanel5Istnieje = false;
        }

        private void PictureBoxRuchOkna_MouseDown(object sender, MouseEventArgs e)
        {
            czyRuch = true;
            start = new Point(e.X, e.Y);
        }

        private void PictureBoxRuchOkna_MouseMove(object sender, MouseEventArgs e)
        {
            if (czyRuch == true)
            {
                Point ruch = PointToScreen(e.Location);
                this.Location = new Point(ruch.X - start.X, ruch.Y - start.Y);
            }
        }

        private void PictureBoxRuchOkna_MouseUp(object sender, MouseEventArgs e)
        {
            czyRuch = false;
        }
    }
}
