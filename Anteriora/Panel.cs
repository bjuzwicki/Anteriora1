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
    public partial class Panel : Form
    {
        Osada o1;
        public static int czasGry;
        public bool czyPanel2Istnieje;
        public bool czyPanel3Istnieje;
        public bool czyPanel4Istnieje;
        public bool czyPanel5Istnieje;
        public bool czyPanel6Istnieje;
        public bool czyPanel7Istnieje;
        public bool czyPanel8Istnieje;

        bool czyRuch;
        Point start = new Point(0, 0);

        public Panel(Osada c1, int czasGry = 1)
        {
            o1 = c1;
            Panel.czasGry = czasGry;
            InitializeComponent();
                       
            timerPanel.Start();
        }

        private void timerPanel_Tick(object sender, EventArgs e)
        {
            czasGry++;
            labelCzasGry.Text = czasGry.ToString();            
            labelDrewno.Text = o1.wood.quantity.ToString();
            labelKamien.Text = o1.stone.quantity.ToString();
            labelSiano.Text = o1.hay.quantity.ToString();           
            labelJedzenie.Text = o1.food.quantity.ToString();
            labelWoda.Text = o1.water.quantity.ToString();
            labelZloto.Text = o1.gold.quantity.ToString();

            ZmianaKoloruTekstuLabela(o1.wood, labelDrewno);
            ZmianaKoloruTekstuLabela(o1.stone, labelKamien);
            ZmianaKoloruTekstuLabela(o1.hay, labelSiano);
            ZmianaKoloruTekstuLabela(o1.food, labelJedzenie);
            ZmianaKoloruTekstuLabela(o1.water, labelWoda);
           
            ZmienKolorLabelaPrzyGlodzie();
        }

        #region Zmiana koloru labela jedzenia i wody podczas głodu

        public void ZmienKolorLabelaPrzyGlodzie()
        {
            if (o1.food.quantity < 0)
            {
                labelJedzenie.ForeColor = Color.DarkRed;
            }
            else if (labelJedzenie.ForeColor == Color.DarkRed && o1.food.quantity >= 0)
            {
                labelJedzenie.ForeColor = Color.Black;
            }

            if (o1.water.quantity < 0)
            {
                labelWoda.ForeColor = Color.DarkRed;
            }
            else if (labelWoda.ForeColor == Color.DarkRed && o1.water.quantity >= 0)
            {
                labelWoda.ForeColor = Color.Black;
            }
        }

        #endregion

        #region Zmiana koloru tekstu labela przy przepełnieniu magazynu materiałami

        public void ZmianaKoloruTekstuLabela(Materialy material, Label label)
        {
            if (o1.magazyn.poziomUlepszenia == 0)
            {
                if (material.quantity >= 99)
                {
                    label.ForeColor = Color.DarkGreen;
                }
                else if (material.quantity < 99)
                {
                    label.ForeColor = Color.Black;
                }
            }
            else if (o1.magazyn.poziomUlepszenia == 1)
            {
                if (material.quantity >= 999)
                {
                    label.ForeColor = Color.DarkGreen;
                }
                else if (material.quantity < 999)
                {
                    label.ForeColor = Color.Black;
                }
            }
            else if (o1.magazyn.poziomUlepszenia == 2)
            {
                if (material.quantity >= 1999)
                {
                    label.ForeColor = Color.DarkGreen;
                }
                else if (material.quantity < 1999)
                {
                    label.ForeColor = Color.Black;
                }
            }
            else if (o1.magazyn.poziomUlepszenia == 3)
            {
                if (material.quantity >= 2999)
                {
                    label.ForeColor = Color.DarkGreen;
                }
                else if (material.quantity < 2999)
                {
                    label.ForeColor = Color.Black;
                }
            }
        }

        #endregion

        private void buttonPozostale_Click(object sender, EventArgs e)
        {
            if(czyPanel2Istnieje == false)
            {
                Panel2 panel = new Panel2(o1, this);
                panel.Show();
                czyPanel2Istnieje = true;
            }

            if(czyPanel3Istnieje == false)
            {
                Panel3 panel = new Panel3(o1, this);
                panel.Show();
                czyPanel3Istnieje = true;
            }

            if(czyPanel4Istnieje == false)
            {
                Panel4 panel = new Panel4(o1, this);
                panel.Show();
                czyPanel4Istnieje = true;
            }

            if(czyPanel5Istnieje == false)
            {
                Panel5 panel = new Panel5(o1, this);
                panel.Show();
                czyPanel5Istnieje = true;
            }
            
            if(czyPanel6Istnieje == false)
            {
                Panel6 panel = new Panel6(o1, this);
                panel.Show();
                czyPanel6Istnieje = true;
            }

            if(czyPanel7Istnieje == false)
            {
                Panel7 panel = new Panel7(o1, this);
                panel.Show();
                czyPanel7Istnieje = true;
            }

            if(czyPanel8Istnieje == false)
            {
                Panel8 panel = new Panel8(o1, this);
                panel.Show();
                czyPanel8Istnieje = true;
            }

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
