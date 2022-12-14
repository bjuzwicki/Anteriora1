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
    public partial class Mapa : Form
    {
        Osada o1;

        #region punkty ruchu wroga

        Point punkt1 = new Point(309, 675);
        Point punkt2 = new Point(393, 509);
        Point punkt3 = new Point(262, 448);
        Point punkt4 = new Point(695, 486);
        Point punkt5 = new Point(853, 415);
        Point punkt6 = new Point(853, 414);
        Point punkt7 = new Point(1013, 328);
        Point punkt8 = new Point(1121, 426);
        Point punkt9 = new Point(1211, 527);
        Point punkt10 = new Point(1508, 519);
        Point punkt11 = new Point(1521, 635);


        #endregion punkty ruchu wroga

        public Mapa(Osada c1)
        {
            o1 = c1;
            InitializeComponent();
            timerPoruszanieWroga.Start();
        }

        
        private void pictureBoxNamiot_Click(object sender, EventArgs e)
        {
            o1.Visible = true;
            this.Close();

        }

        private void pictureBoxOsadaGoblinow_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new EkranLadowania(null, o1, this, 3).Show();
        }

        private void pictureBoxJaskiniaWezy_Click(object sender, EventArgs e)
        {
            new JaskiniaWezy(o1, this).Show();
        }

        private void timerPoruszanieWroga_Tick(object sender, EventArgs e)
        {  
            #region osada goblinow
            if (o1.osadaGoblinow.czasWroga < o1.osadaGoblinow.czasRuchuWrogow - 2)
            {
                Ruch(o1.osadaGoblinow, 0, 40, punkt3);
                Ruch(o1.osadaGoblinow, 40, 80, punkt2);
                Ruch(o1.osadaGoblinow, 80, 120, punkt1);
            }
            else
            {
                pictureBoxRuchWroga.Visible = false;
            }

            if (o1.jaskiniaWezy.czasWroga < o1.jaskiniaWezy.czasRuchuWrogow - 2)
            {
                Ruch(o1.jaskiniaWezy, 0, 60, punkt4);
                Ruch(o1.jaskiniaWezy, 60, 120, punkt2);
                Ruch(o1.jaskiniaWezy, 120, 180, punkt1);
            }
            else
            {
                pictureBoxRuchWroga.Visible = false;
            }

            #endregion osada goblinow

            /*if (o1.osadaGoblinow.czasWroga > 0 && o1.osadaGoblinow.czasWroga <= 40)
            {
                pictureBoxRuchWroga.Visible = true;
                var o = Properties.Resources.ResourceManager.GetObject(o1.osadaGoblinow.obrazekDol);
                pictureBoxRuchWroga.Image = (Image)o;
                pictureBoxRuchWroga.Location = new Point(punkt3.X,punkt3.Y);
            }
            else if(o1.osadaGoblinow.czasWroga > 40 && o1.osadaGoblinow.czasWroga <= 80)
            {
                pictureBoxRuchWroga.Visible = true;
                var o = Properties.Resources.ResourceManager.GetObject(o1.osadaGoblinow.obrazekDol);
                pictureBoxRuchWroga.Image = (Image)o;
                pictureBoxRuchWroga.Location = new Point(punkt2.X, punkt2.Y);
            }
            else if (o1.osadaGoblinow.czasWroga > 80 && o1.osadaGoblinow.czasWroga <= 120)
            {
                pictureBoxRuchWroga.Visible = true;
                var o = Properties.Resources.ResourceManager.GetObject(o1.osadaGoblinow.obrazekDol);
                pictureBoxRuchWroga.Image = (Image)o;
                pictureBoxRuchWroga.Location = new Point(punkt1.X, punkt1.Y);
            }
            else
            {
                pictureBoxRuchWroga.Visible = false;
            }
            */
        }

        public void ZwiadowcaAkcja(Instancje instancja, int licznik)
        {
            if (instancja.czasZwiadowcy == 0)
            {
                if (instancja.licznikZwiadowca < licznik)
                {
                    if (o1.zwiadowca.liczebnoscAtakujacych == 1)
                    {
                        o1.zwiadowca.liczebnoscAtakujacych--;
                        instancja.akcjaZwiadowca = true;
                        o1.timerZwiadowca.Start();
                        MessageBox.Show("Wysłałeś zwiadowcę.");
                    }
                    else
                    {
                        MessageBox.Show("Potrzebujesz zwiadowcy!");
                    }
                }
                else
                {
                    MessageBox.Show("Nie ma takiej potrzeby :)");
                }
            }
            else
            {
                MessageBox.Show("Już wysłałeś zwiadowcę.");
            }
        }

        public void Ruch(Instancje instancja, int czas1, int czas2, Point point)
        {
            if (instancja.czasWroga > czas1 && instancja.czasWroga <= czas2)
            {
                pictureBoxRuchWroga.Visible = true;
                var o = Properties.Resources.ResourceManager.GetObject(instancja.obrazekDol);
                pictureBoxRuchWroga.BackgroundImage = (Image)o;
                pictureBoxRuchWroga.Location = new Point(point.X, point.Y);
            }
        }

        private void pictureBoxLodowaKraina_Click(object sender, EventArgs e)
        {
            new LodowaKraina(o1, this).Show();
        }

        private void pictureBoxOgnistaKraina_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instancja dostępna wkrótce");
        }

        private void pictureBoxLas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instancja dostępna wkrótce");
        }

        private void pictureBoxZamek_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instancja dostępna wkrótce");
        }
    }
}