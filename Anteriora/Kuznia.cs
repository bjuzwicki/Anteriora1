using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Anteriora
{
    public partial class Kuznia : Form
    {

        Osada o1;

        List<PictureBox> sloty = new List<PictureBox>();

        Bitmap skora = Properties.Resources.skora;
        Bitmap kamien = Properties.Resources.kamien;
        Bitmap drewno = Properties.Resources.drewno;
        Bitmap zelazo = Properties.Resources.zelazo;
        Bitmap obsydian = Properties.Resources.obsydian;
        Bitmap rudaObsydianu = Properties.Resources.ruda_obsydianu;
        Bitmap rudaZelaza = Properties.Resources.ruda_zelaza;
        Bitmap welna = Properties.Resources.welna;
        Bitmap skorzanyPasek = Properties.Resources.skorzany_pasek;
        Bitmap kawalekDrewna = Properties.Resources.patyk;

        string zawartosc;
        int iloscWytwarzanychPrzedmiotow;


        public Kuznia(Osada c1)
        {
            o1 = c1;

            InitializeComponent();

            sloty.AddRange(new PictureBox[] { pictureBoxSlot1, pictureBoxSlot2, pictureBoxSlot3, pictureBoxSlot4, pictureBoxSlot5, pictureBoxSlot6, pictureBoxSlot7, pictureBoxSlot8, pictureBoxSlot9 });

            foreach (var item in sloty)
            {
                item.AllowDrop = true;
            }

            pictureBoxSkora.BackgroundImage = skora;
            pictureBoxKamien.BackgroundImage = kamien;
            pictureBoxDrewno.BackgroundImage = drewno;
            pictureBoxZelazo.BackgroundImage = zelazo;
            pictureBoxObsydian.BackgroundImage = obsydian;
            pictureBoxRudaZelaza.BackgroundImage = rudaZelaza;
            pictureBoxRudaObsydianu.BackgroundImage = rudaObsydianu;
            pictureBoxWelna.BackgroundImage = welna;
            pictureBoxKawalekDrewna.BackgroundImage = kawalekDrewna;
            pictureBoxSkorzanyPasek.BackgroundImage = skorzanyPasek;
        }

        private void pictureBoxKowadlo_Click(object sender, EventArgs e)
        {
            iloscWytwarzanychPrzedmiotow = Convert.ToInt16(textBoxIlosc.Text);  // liczebnoscAtakujacych przedmiotow, które chcemy wytworzyć
            zawartosc = "";

            foreach (var item in sloty)
            {
                if (item.BackgroundImage == skora)
                {
                    zawartosc += "1";
                }
                else if (item.BackgroundImage == kamien)
                {
                    zawartosc += "2";
                }
                else if (item.BackgroundImage == drewno)
                {
                    zawartosc += "3";
                }
                else if (item.BackgroundImage == zelazo)
                {
                    zawartosc += "4";
                }
                else if (item.BackgroundImage == obsydian)
                {
                    zawartosc += "5";
                }
                else if(item.BackgroundImage == rudaZelaza)
                {
                    zawartosc += "6";
                }
                else if(item.BackgroundImage == rudaObsydianu)
                {
                    zawartosc += "7";
                }
                else if(item.BackgroundImage == welna)
                {
                    zawartosc += "8";
                }
                else if(item.BackgroundImage == skorzanyPasek)
                {
                    zawartosc += "9";
                }
                else if(item.BackgroundImage == kawalekDrewna)
                {
                    zawartosc += "0";
                }
                else
                {
                    zawartosc += "X";
                }
            }

            WytworzUzbrojenieSkorzane(o1.skorzanaZbroja);
            WytworzUzbrojenieSkorzane(o1.skorzaneSpodnie);
            WytworzUzbrojenieSkorzane(o1.skorzanyHelm);
            WytworzUzbrojenieSkorzane(o1.skorzaneButy);
            WytworzUzbrojenieZelazne(o1.zelaznaZbroja);
            WytworzUzbrojenieZelazne(o1.zelazneSpodnie);
            WytworzUzbrojenieZelazne(o1.zelaznyHelm);
            WytworzUzbrojenieZelazne(o1.zelazneButy);
            WytworzUzbrojenieObsydianowe(o1.obsydianowaZbroja);
            WytworzUzbrojenieObsydianowe(o1.obsydianoweSpodnie);
            WytworzUzbrojenieObsydianowe(o1.obsydianowyHelm);
            WytworzUzbrojenieObsydianowe(o1.obsydianoweButy);
            PrzetopRude(o1.iron, o1.ironOre, rudaZelaza, zelazo);
            PrzetopRude(o1.obsidian, o1.obsidianOre, rudaObsydianu, obsydian);
            WytworzKamiennaBron(o1.kamiennyMiecz);
            WytworzZelaznaBron(o1.zelaznyMiecz);
            WytworzObsydianowaBron(o1.obsydianowyMiecz);
            WytworzLuk(o1.luk);
            WytworzZelaznaTarcze();
            WytworzObsydianowaTarcze();
            WytworzUbraniaMieszkancow();
            WytworzLozko();
            RabDrewno();
            TnijSkore();
        }

        public void WytworzUzbrojenieSkorzane(Uzbrojenie uzbrojenie)
        {
            if (zawartosc == uzbrojenie.kod1 || zawartosc == uzbrojenie.kod2)
            {
                int iloscPotrzebnegoMaterialu = uzbrojenie.iloscPotrzebnejSkory * iloscWytwarzanychPrzedmiotow;
                if (o1.skin.quantity >= iloscPotrzebnegoMaterialu)
                {
                    uzbrojenie.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.skin.quantity -= iloscPotrzebnegoMaterialu;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = uzbrojenie.obrazek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzUzbrojenieZelazne(Uzbrojenie uzbrojenie)
        {
            if (zawartosc == uzbrojenie.kod1 || zawartosc == uzbrojenie.kod2)
            {
                int iloscPotrzebnegoMaterialu = uzbrojenie.iloscPotrzebnegoZelaza * iloscWytwarzanychPrzedmiotow;
                if (o1.iron.quantity >= iloscPotrzebnegoMaterialu)
                {
                    uzbrojenie.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.iron.quantity -= iloscPotrzebnegoMaterialu;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = uzbrojenie.obrazek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzUzbrojenieObsydianowe(Uzbrojenie uzbrojenie)
        {
            if (zawartosc == uzbrojenie.kod1 || zawartosc == uzbrojenie.kod2)
            {
                int iloscPotrzebnegoMaterialu = uzbrojenie.iloscPotrzebnegoObsydianu * iloscWytwarzanychPrzedmiotow;
                if (o1.obsidian.quantity >= iloscPotrzebnegoMaterialu)
                {
                    uzbrojenie.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.obsidian.quantity -= iloscPotrzebnegoMaterialu;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = uzbrojenie.obrazek;
                    MessageBox.Show("Wytworzyłeś " + iloscWytwarzanychPrzedmiotow + " " + uzbrojenie.nazwa);
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void PrzetopRude(Materialy material, Materialy material2, Bitmap obrazek1, Bitmap obrazek2)
        {
            if (sloty.FindAll(x => x.BackgroundImage == obrazek1).Count == Materialy.oreAmountNeeded)
            {
                int iloscPotrzebnegoMaterialu = Materialy.oreAmountNeeded * iloscWytwarzanychPrzedmiotow;
                if (material2.quantity >= iloscPotrzebnegoMaterialu)
                {
                    material.quantity += iloscWytwarzanychPrzedmiotow;
                    material2.quantity -= iloscPotrzebnegoMaterialu;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = obrazek2;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void RabDrewno()
        {
            if (sloty.FindAll(x => x.BackgroundImage == drewno).Count == 1 && sloty.FindAll(x => x.BackgroundImage == null).Count == 8)
            {
                if(o1.wood.quantity >= iloscWytwarzanychPrzedmiotow)
                {
                    o1.pieceOfWood.quantity += 4 * iloscWytwarzanychPrzedmiotow;
                    o1.wood.quantity -= iloscWytwarzanychPrzedmiotow;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = kawalekDrewna;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void TnijSkore()
        {
            if (sloty.FindAll(x => x.BackgroundImage == skora).Count == 1 && sloty.FindAll(x => x.BackgroundImage == null).Count == 8)
            {
                if (o1.skin.quantity >= iloscWytwarzanychPrzedmiotow)
                {
                    o1.leatherBelt.quantity += 4 * iloscWytwarzanychPrzedmiotow;
                    o1.skin.quantity -= iloscWytwarzanychPrzedmiotow;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = skorzanyPasek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzKamiennaBron(Bronie bron)
        {
            if(zawartosc == bron.kod1 || zawartosc == bron.kod2 || zawartosc == bron.kod3)
            {
                int iloscPotrzebnychKawalkowDrewna = bron.iloscPotrzebnychKawalkowDrewna * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnegoKamienia = bron.iloscPotrzebnegoKamienia * iloscWytwarzanychPrzedmiotow;

                if(o1.pieceOfWood.quantity >= iloscPotrzebnychKawalkowDrewna && o1.stone.quantity >= iloscPotrzebnegoKamienia)
                {
                    bron.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.pieceOfWood.quantity -= iloscPotrzebnychKawalkowDrewna;
                    o1.stone.quantity -= iloscPotrzebnegoKamienia;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = bron.obrazek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów");
                }
            }
        }

        public void WytworzZelaznaBron(Bronie bron)
        {
            if (zawartosc == bron.kod1 || zawartosc == bron.kod2 || zawartosc == bron.kod3)
            {
                int iloscPotrzebnychKawalkowDrewna = bron.iloscPotrzebnychKawalkowDrewna * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnegoZelaza = bron.iloscPotrzebnegoZelaza * iloscWytwarzanychPrzedmiotow;

                if(o1.wood.quantity >= iloscPotrzebnychKawalkowDrewna && o1.stone.quantity >= iloscPotrzebnegoZelaza)
                {
                    bron.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.pieceOfWood.quantity -= iloscPotrzebnychKawalkowDrewna;
                    o1.stone.quantity -= iloscPotrzebnegoZelaza;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = bron.obrazek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

       
        public void WytworzObsydianowaBron(Bronie bron)
        {
            if (zawartosc == bron.kod1 || zawartosc == bron.kod2 || zawartosc == bron.kod3)
            {
                int iloscPotrzebnychKawalkowDrewna = bron.iloscPotrzebnychKawalkowDrewna * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnegoObsydianu = bron.iloscPotrzebnegoObsydianu * iloscWytwarzanychPrzedmiotow;

                if(o1.wood.quantity >= iloscPotrzebnychKawalkowDrewna&& o1.obsidian.quantity >= iloscPotrzebnegoObsydianu)
                {
                    bron.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.pieceOfWood.quantity -= iloscPotrzebnychKawalkowDrewna;
                    o1.obsidian.quantity -= iloscPotrzebnegoObsydianu;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = bron.obrazek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzLuk(Bronie bron)
        {
            if(zawartosc == bron.kod1 || zawartosc == bron.kod2)
            {
                int iloscPotrzebnychKawałkowDrewna = bron.iloscPotrzebnychKawalkowDrewna * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnychSkorzanychPaskow = bron.iloscPotrzebnychSkorzanychPaskow * iloscWytwarzanychPrzedmiotow;

                if(o1.pieceOfWood.quantity >= iloscPotrzebnychKawałkowDrewna && o1.leatherBelt.quantity >= iloscPotrzebnychSkorzanychPaskow)
                {
                    bron.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.pieceOfWood.quantity -= iloscPotrzebnychKawałkowDrewna;
                    o1.leatherBelt.quantity -= iloscPotrzebnychSkorzanychPaskow;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = bron.obrazek;
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }

            }
        }

        public void WytworzZelaznaTarcze()
        {
            if (zawartosc == o1.zelaznaTarcza.kod1)
            {
                int iloscPotrzebnegoZelaza = o1.zelaznaTarcza.iloscPotrzebnegoZelaza * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnegoDrewna = o1.zelaznaTarcza.iloscPotrzebnegoDrewna * iloscWytwarzanychPrzedmiotow;

                if (o1.iron.quantity >= iloscPotrzebnegoZelaza && o1.wood.quantity >= iloscPotrzebnegoDrewna)
                {
                    o1.zelaznaTarcza.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.iron.quantity -= iloscPotrzebnegoZelaza;
                    o1.wood.quantity -= iloscPotrzebnegoDrewna;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = o1.zelaznaTarcza.obrazek;
                    MessageBox.Show("Wytworzyłeś " + iloscWytwarzanychPrzedmiotow + " " + o1.zelaznaTarcza.nazwa);
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzObsydianowaTarcze()
        {
            if (zawartosc == o1.obsydianowaTarcza.kod1)
            {
                int iloscPotrzebnegoObsydianu = o1.obsydianowaTarcza.iloscPotrzebnegoObsydianu * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnegoDrewna = o1.obsydianowaTarcza.iloscPotrzebnegoDrewna * iloscWytwarzanychPrzedmiotow;

                if (o1.obsidian.quantity >= iloscPotrzebnegoObsydianu && o1.wood.quantity >= iloscPotrzebnegoDrewna)
                {
                    o1.obsydianowaTarcza.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.obsidian.quantity -= iloscPotrzebnegoObsydianu;
                    o1.wood.quantity -= iloscPotrzebnegoDrewna;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = o1.obsydianowaTarcza.obrazek;
                    MessageBox.Show("Wytworzyłeś " + iloscWytwarzanychPrzedmiotow + " " + o1.obsydianowaTarcza.nazwa);
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzUbraniaMieszkancow()
        {
            if(zawartosc == o1.ubraniaMieszkancow.kod1)
            {
                int iloscPotrzebnejWelny = o1.ubraniaMieszkancow.iloscPotrzebnejWelny * iloscWytwarzanychPrzedmiotow;

                if(o1.wool.quantity >= iloscPotrzebnejWelny)
                {
                    o1.ubraniaMieszkancow.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.wool.quantity -= iloscPotrzebnejWelny;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = o1.ubraniaMieszkancow.obrazek;
                    MessageBox.Show("Wytworzyłeś " + iloscWytwarzanychPrzedmiotow + " " + o1.ubraniaMieszkancow.nazwa);
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        public void WytworzLozko()
        {
            if(zawartosc == o1.lozko.kod1)
            {
                int iloscPotrzebnejWelny = o1.lozko.iloscPotrzebnejWelny * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnychSkorzanychPaskow = o1.lozko.iloscPotrzebnychSkorzanychPaskow * iloscWytwarzanychPrzedmiotow;
                int iloscPotrzebnegoDrewna = o1.lozko.iloscPotrzebnegoDrewna * iloscWytwarzanychPrzedmiotow;

                if(o1.wool.quantity >= iloscPotrzebnejWelny && o1.leatherBelt.quantity >= iloscPotrzebnychSkorzanychPaskow && o1.wood.quantity >= iloscPotrzebnegoDrewna)
                {
                    o1.lozko.ilosc += iloscWytwarzanychPrzedmiotow;
                    o1.wool.quantity -= iloscPotrzebnejWelny;
                    o1.leatherBelt.quantity -= iloscPotrzebnychSkorzanychPaskow;
                    o1.wood.quantity -= iloscPotrzebnegoDrewna;
                    pictureBoxStworzonyPrzedmiot.BackgroundImage = o1.lozko.obrazek;
                    MessageBox.Show("Wytworzyłeś " + iloscWytwarzanychPrzedmiotow + " " + o1.lozko.nazwa);
                }
                else
                {
                    MessageBox.Show("Niewystarczająca ilość materiałów!");
                }
            }
        }

        private void pictureBoxSlot1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot1_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot1.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot2_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot2.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot3_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot3.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot4_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot4.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot5_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot5.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot6_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot6_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot6.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot7_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot7_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot7.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot8_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot8_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot8.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSlot9_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxSlot9_DragDrop(object sender, DragEventArgs e)
        {
            pictureBoxSlot9.BackgroundImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pictureBoxSkora_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxSkora.DoDragDrop(pictureBoxSkora.BackgroundImage, DragDropEffects.Copy);
        }

        private void pictureBoxKamien_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxKamien.DoDragDrop(pictureBoxKamien.BackgroundImage, DragDropEffects.Copy);
        }

        private void pictureBoxDrewno_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxDrewno.DoDragDrop(pictureBoxDrewno.BackgroundImage, DragDropEffects.Copy);
        }

        private void pictureBoxZelazo_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxZelazo.DoDragDrop(pictureBoxZelazo.BackgroundImage, DragDropEffects.Copy);
        }

        private void PictureBoxObsydian_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxObsydian.DoDragDrop(pictureBoxObsydian.BackgroundImage, DragDropEffects.Copy);
        }

        private void PictureBoxRudaZelaza_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxRudaZelaza.DoDragDrop(pictureBoxRudaZelaza.BackgroundImage, DragDropEffects.Copy);
        }

        private void PictureBoxRudaObsydianu_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxRudaObsydianu.DoDragDrop(pictureBoxRudaObsydianu.BackgroundImage, DragDropEffects.Copy);
        }

        private void PictureBoxWelna_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxWelna.DoDragDrop(pictureBoxWelna.BackgroundImage, DragDropEffects.Copy);
        }

        private void PictureBoxKawalekDrewna_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxKawalekDrewna.DoDragDrop(pictureBoxKawalekDrewna.BackgroundImage, DragDropEffects.Copy);
        }

        private void PictureBoxSkorzanyPasek_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxSkorzanyPasek.DoDragDrop(pictureBoxSkorzanyPasek.BackgroundImage, DragDropEffects.Copy);
        }

        private void pictureBoxSlot1_Click(object sender, EventArgs e)
        {
            pictureBoxSlot1.BackgroundImage = null;
        }

        private void pictureBoxSlot2_Click(object sender, EventArgs e)
        {
            pictureBoxSlot2.BackgroundImage = null;
        }

        private void pictureBoxSlot3_Click(object sender, EventArgs e)
        {
            pictureBoxSlot3.BackgroundImage = null;
        }

        private void pictureBoxSlot4_Click(object sender, EventArgs e)
        {
            pictureBoxSlot4.BackgroundImage = null;
        }

        private void pictureBoxSlot5_Click(object sender, EventArgs e)
        {
            pictureBoxSlot5.BackgroundImage = null;
        }

        private void pictureBoxSlot6_Click(object sender, EventArgs e)
        {
            pictureBoxSlot6.BackgroundImage = null;
        }

        private void pictureBoxSlot7_Click(object sender, EventArgs e)
        {
            pictureBoxSlot7.BackgroundImage = null;
        }

        private void pictureBoxSlot8_Click(object sender, EventArgs e)
        {
            pictureBoxSlot8.BackgroundImage = null;
        }

        private void pictureBoxSlot9_Click(object sender, EventArgs e)
        {
            pictureBoxSlot9.BackgroundImage = null;
        }

        private void buttonWyjscie_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void WyczyscSloty()
        {
            foreach (var item in sloty)
            {
                item.BackgroundImage = null;
            }

            pictureBoxStworzonyPrzedmiot.BackgroundImage = null;
        }

        private void buttonWyczysc_Click(object sender, EventArgs e)
        {
            WyczyscSloty();
        }

        private void textBoxIlosc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBoxKowadlo.Focus();
            }
        }

        private void PictureBoxStworzonyPrzedmiot_Click(object sender, EventArgs e)
        {
            pictureBoxStworzonyPrzedmiot.BackgroundImage = null;
        }
    }
}
