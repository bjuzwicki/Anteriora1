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
    public partial class Zarzadzanie : Form
    {
        Osada o1;

        List<Label> podatki = new List<Label>();
        List<Label> drewno = new List<Label>();
        List<Label> kamien = new List<Label>();
        List<Label> siano = new List<Label>();
        List<Label> jedzenie = new List<Label>();
        List<Label> woda = new List<Label>();
        List<Label> skora = new List<Label>();
        List<Label> welna = new List<Label>();
        List<Label> rudaZelaza = new List<Label>();
        List<Label> rudaObsydianu = new List<Label>();

        public Zarzadzanie(Osada c1)
        {
            o1 = c1;
            InitializeComponent();

            #region Dodanie elementów do list

            podatki.AddRange(new Label[] { labelPodatekPoziom0, labelPodatekPoziom1, labelPodatekPoziom2, labelPodatekPoziom3, labelPodatekPoziom4, labelPodatekPoziom5 });
            drewno.AddRange(new Label[] { labelDrewnoPoziom0, labelDrewnoPoziom1, labelDrewnoPoziom2, labelDrewnoPoziom3, labelDrewnoPoziom4, labelDrewnoPoziom5 });
            kamien.AddRange(new Label[] { labelKamienPoziom0, labelKamienPoziom1, labelKamienPoziom2, labelKamienPoziom3, labelKamienPoziom4, labelKamienPoziom5 });
            siano.AddRange(new Label[] { labelSianoPoziom0, labelSianoPoziom1, labelSianoPoziom2, labelSianoPoziom3, labelSianoPoziom4, labelSianoPoziom5 });
            jedzenie.AddRange(new Label[] { labelJedzeniePoziom0, labelJedzeniePoziom1, labelJedzeniePoziom2, labelJedzeniePoziom3, labelJedzeniePoziom4, labelJedzeniePoziom5 });
            woda.AddRange(new Label[] { labelWodaPoziom0, labelWodaPoziom1, labelWodaPoziom2, labelWodaPoziom3, labelWodaPoziom4, labelWodaPoziom5 });
            skora.AddRange(new Label[] { labelSkoraPoziom0, labelSkoraPoziom1, labelSkoraPoziom2, labelSkoraPoziom3, labelSkoraPoziom4, labelSkoraPoziom5 });
            welna.AddRange(new Label[] { labelWelnaPoziom0, labelWelnaPoziom1, labelWelnaPoziom2, labelWelnaPoziom3, labelWelnaPoziom4, labelWelnaPoziom5 });
            rudaZelaza.AddRange(new Label[] { labelRudaZelazaPoziom0, labelRudaZelazaPoziom1, labelRudaZelazaPoziom2, labelRudaZelazaPoziom3, labelRudaZelazaPoziom4, labelRudaZelazaPoziom5 });
            rudaObsydianu.AddRange(new Label[] { labelRudaObsydianuPoziom0, labelRudaObsydianuPoziom1, labelRudaObsydianuPoziom2, labelRudaObsydianuPoziom3, labelRudaObsydianuPoziom4, labelRudaObsydianuPoziom5 });

            #endregion

            #region Sprawdzanie poziomu podatkow i materiałów

            SprawdzPoziomPodatkow(podatki);

            SprawdzPoziomEksploatacji(o1.wood, drewno);

            SprawdzPoziomEksploatacji(o1.stone, kamien);

            SprawdzPoziomEksploatacji(o1.hay, siano);

            SprawdzPoziomEksploatacji(o1.food, jedzenie);

            SprawdzPoziomEksploatacji(o1.skin, skora);

            SprawdzPoziomEksploatacji(o1.wool, welna);

            SprawdzPoziomEksploatacji(o1.water, woda);

            SprawdzPoziomEksploatacji(o1.ironOre, rudaZelaza);

            SprawdzPoziomEksploatacji(o1.obsidianOre, rudaObsydianu);

            

            #endregion

            OdblokujPoziomyEksploatacji(o1.tartak1, o1.tartak2, drewno);
            OdblokujPoziomyEksploatacji(o1.kamieniolom1, o1.kamieniolom2,o1.kopalniaKamienia, kamien);
            OdblokujPoziomyEksploatacji(o1.chatkaRolnika, o1.chatkaRolnika, siano);
            OdblokujPoziomyEksploatacji(o1.hodowla, o1.kwateraRybacka, jedzenie);
            OdblokujPoziomyEksploatacji(o1.studnia, o1.studnia, woda);
            OdblokujPoziomyEksploatacji(o1.hodowla, o1.hodowla, skora);
            OdblokujPoziomyEksploatacji(o1.hodowla, o1.hodowla, welna);
            OdblokujPoziomyEksploatacji(o1.kopalniaRudyZelaza1, o1.kopalniaRudyZelaza2, rudaZelaza);
            OdblokujPoziomPodatkow();
        }

        #region Ustawianie poziomu podatków

        private void LabelPodatekPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomPodatkow(labelPodatekPoziom0, 0);
        }

        private void labelPodatekPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomPodatkow(labelPodatekPoziom1, 1);
        }

        private void labelPodatekPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomPodatkow(labelPodatekPoziom2, 2);

        }

        private void labelPodatekPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomPodatkow(labelPodatekPoziom3, 3);

        }

        private void labelPodatekPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomPodatkow(labelPodatekPoziom4, 4);

        }

        private void labelPodatekPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomPodatkow(labelPodatekPoziom5, 5);

        }
        #endregion Ustawianie poziomu podatków

        #region Ustawianie poziomu eksploatacji:

        #region Drewno

        private void LabelDrewnoPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wood, labelDrewnoPoziom0, 0, drewno);
        }

        private void labelDrewnoPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wood, labelDrewnoPoziom1, 1, drewno);
        }

        private void labelDrewnoPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wood, labelDrewnoPoziom2, 2, drewno);

        }

        private void labelDrewnoPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wood, labelDrewnoPoziom3, 3, drewno);

        }

        private void labelDrewnoPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wood, labelDrewnoPoziom4, 4, drewno);

        }

        private void labelDrewnoPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wood, labelDrewnoPoziom5, 5, drewno);

        }

        #endregion Drewno

        #region Kamien

        private void LabelKamienPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.stone, labelKamienPoziom0, 0, kamien);
        }

        private void labelKamienPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.stone, labelKamienPoziom1, 1, kamien);
        }

        private void labelKamienPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.stone, labelKamienPoziom2, 2, kamien);
        }

        private void labelKamienPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.stone, labelKamienPoziom3, 3, kamien);
        }

        private void labelKamienPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.stone, labelKamienPoziom4, 4, kamien);
        }

        private void labelKamienPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.stone, labelKamienPoziom5, 5, kamien);
        }

        #endregion Kamien

        #region Siano

        private void LabelSianoPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.hay, labelSianoPoziom0, 0, siano);
        }

        private void labelSianoPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.hay, labelSianoPoziom1, 1, siano);
        }

        private void labelSianoPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.hay, labelSianoPoziom2, 2, siano);
        }

        private void labelSianoPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.hay, labelSianoPoziom3, 3, siano);
        }

        private void labelSianoPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.hay, labelSianoPoziom4, 4, siano);
        }

        private void labelSianoPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.hay, labelSianoPoziom5, 5, siano);
        }

        #endregion Siano

        #region Jedzenie

        private void LabelJedzeniePoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.food, labelJedzeniePoziom0, 0, jedzenie);
        }

        private void labelJedzeniePoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.food, labelJedzeniePoziom1, 1, jedzenie);
        }

        private void labelJedzeniePoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.food, labelJedzeniePoziom2, 2, jedzenie);
        }

        private void labelJedzeniePoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.food, labelJedzeniePoziom3, 3, jedzenie);
        }

        private void labelJedzeniePoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.food, labelJedzeniePoziom4, 4, jedzenie);
        }

        private void labelJedzeniePoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.food, labelJedzeniePoziom5, 5, jedzenie);
        }


        #endregion Jedzenie

        #region Skora

        private void LabelSkoraPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.skin, labelSkoraPoziom0, 0, skora);
        }

        private void labelSkoraPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.skin, labelSkoraPoziom1, 1, skora);
        }

        private void labelSkoraPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.skin, labelSkoraPoziom2, 2, skora);
        }

        private void labelSkoraPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.skin, labelSkoraPoziom3, 3, skora);
        }

        private void labelSkoraPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.skin, labelSkoraPoziom4, 4, skora);
        }

        private void labelSkoraPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.skin, labelSkoraPoziom5, 5, skora);
        }

        #endregion Skora

        #region Welna

        private void LabelWelnaPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wool, labelWelnaPoziom0, 0, welna);
        }

        private void LabelWelnaPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wool, labelWelnaPoziom1, 1, welna);
        }

        private void LabelWelnaPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wool, labelWelnaPoziom2, 2, welna);
        }

        private void LabelWelnaPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wool, labelWelnaPoziom3, 3, welna);
        }

        private void LabelWelnaPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wool, labelWelnaPoziom4, 4, welna);
        }

        private void LabelWelnaPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.wool, labelWelnaPoziom5, 5, welna);
        }

        #endregion Welna

        #region Woda

        private void LabelWodaPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.water, labelWodaPoziom0, 0, woda);
        }

        private void labelWodaPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.water, labelWodaPoziom1, 1, woda);
        }

        private void labelWodaPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.water, labelWodaPoziom2, 2, woda);
        }

        private void labelWodaPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.water, labelWodaPoziom3, 3, woda);
        }

        private void labelWodaPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.water, labelWodaPoziom4, 4, woda);
        }

        private void labelWodaPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.water, labelWodaPoziom5, 5, woda);
        }

        #endregion Woda

        #region Ruda zelaza

        private void LabelRudaZelazaPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.ironOre, labelRudaZelazaPoziom0, 0, rudaZelaza);
        }

        private void LabelRudaZelazaPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.ironOre, labelRudaZelazaPoziom1, 1, rudaZelaza);
        }

        private void LabelRudaZelazaPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.ironOre, labelRudaZelazaPoziom2, 2, rudaZelaza);
        }

        private void LabelRudaZelazaPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.ironOre, labelRudaZelazaPoziom3, 3, rudaZelaza);
        }

        private void LabelRudaZelazaPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.ironOre, labelRudaZelazaPoziom4, 4, rudaZelaza);
        }

        private void LabelRudaZelazaPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.ironOre, labelRudaZelazaPoziom5, 5, rudaZelaza);
        }

        #endregion Ruda zelaza

        #region Ruda obsydianu

        private void LabelRudaObsydianuPoziom0_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.obsidianOre, labelRudaObsydianuPoziom0, 0, rudaObsydianu);
        }

        private void LabelRudaObsydianuPoziom1_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.obsidianOre, labelRudaObsydianuPoziom1, 1, rudaObsydianu);
        }

        private void LabelRudaObsydianuPoziom2_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.obsidianOre, labelRudaObsydianuPoziom2, 2, rudaObsydianu);
        }

        private void LabelRudaObsydianuPoziom3_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.obsidianOre, labelRudaObsydianuPoziom3, 3, rudaObsydianu);
        }

        private void LabelRudaObsydianuPoziom4_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.obsidianOre, labelRudaObsydianuPoziom4, 4, rudaObsydianu);
        }

        private void LabelRudaObsydianuPoziom5_Click(object sender, EventArgs e)
        {
            UstawPoziomEksploatacji(o1.obsidianOre, labelRudaObsydianuPoziom5, 5, rudaObsydianu);
        }

        #endregion Ruda obsydianu


        #endregion Ustawianie poziomu eksploatacji:


        public void UstawPoziomPodatkow(Label label, int poziomPodatkow)
        {
            foreach (var item in podatki)
            {
                item.BackColor = Color.Transparent;
            }

            label.BackColor = Color.Red;
            o1.mieszkancy.poziomPodatkow = poziomPodatkow;
        }

        public void UstawPoziomEksploatacji(Materialy material,Label label, int poziomEksploatacji, List<Label> list)
        {
            if (o1.mieszkancy.ObliczLiczbeBezrobotnychMieszkancow() >= (material.improvementLevel * poziomEksploatacji) - (material.improvementLevel*material.exploitationLevel))
            {
                foreach (var item in list)
                {
                    item.BackColor = Color.Transparent;
                }

                label.BackColor = Color.Red;

                int poziomEksploatacjiAktualnie = material.exploitationLevel;

                o1.mieszkancy.liczbaPracujacychMieszkancow -= poziomEksploatacjiAktualnie * material.improvementLevel;

                material.exploitationLevel = poziomEksploatacji;

                o1.mieszkancy.liczbaPracujacychMieszkancow += poziomEksploatacji * material.improvementLevel;
            }
            else
            {
                MessageBox.Show("Nie ma ludzi do pracy");
            }
           
        }

        public void SprawdzPoziomPodatkow(List<Label> list)
        {
            switch (o1.mieszkancy.poziomPodatkow)
            {
                case 0:
                    list[0].BackColor = Color.Red;
                    break;
                case 1:
                    list[1].BackColor = Color.Red;
                    break;
                case 2:
                    list[2].BackColor = Color.Red;
                    break;
                case 3:
                    list[3].BackColor = Color.Red;  
                    break;
                case 4:
                    list[4].BackColor = Color.Red;
                    break;
                case 5:
                    list[5].BackColor = Color.Red;
                    break;
            }
        }

        public void SprawdzPoziomEksploatacji(Materialy materiał, List<Label> list)
        {
            switch (materiał.exploitationLevel)
            {
                case 0:
                    list[0].BackColor = Color.Red;
                    break;
                case 1:
                    list[1].BackColor = Color.Red;
                    break;
                case 2:
                    list[2].BackColor = Color.Red;
                    break;
                case 3:
                    list[3].BackColor = Color.Red;
                    break;
                case 4:
                    list[4].BackColor = Color.Red;
                    break;
                case 5:
                    list[5].BackColor = Color.Red;
                    break;
            }
        }

        public void OdblokujPoziomyEksploatacji(Budowle budowla1, Budowle budowla2, List<Label> list)
        {
            switch (budowla1.poziomUlepszenia + budowla2.poziomUlepszenia)
            {
                case 0:
                    list[0].Enabled = true;
                    break;
                case 1:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    break;
                case 2:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    break;
                case 3:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    break;
                case 4:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    list[4].Enabled = true;
                    break;
                case 6:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    list[4].Enabled = true;
                    list[5].Enabled = true;
                    break;
            }
        }

        public void OdblokujPoziomyEksploatacji(Budowle budowla1, Budowle budowla2, Budowle budowla3, List<Label> list)
        {
            switch (budowla1.poziomUlepszenia + budowla2.poziomUlepszenia + budowla3.poziomUlepszenia)
            {
                case 0:
                    list[0].Enabled = true;
                    break;
                case 1:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    break;
                case 2:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    break;
                case 3:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    break;
                case 4:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    break;
                case 5:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    break;
                case 6:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    list[4].Enabled = true;
                    break;
                case 7:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    list[4].Enabled = true;
                    break;
                case 8:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    list[4].Enabled = true;
                    break;
                case 9:
                    list[0].Enabled = true;
                    list[1].Enabled = true;
                    list[2].Enabled = true;
                    list[3].Enabled = true;
                    list[4].Enabled = true;
                    list[5].Enabled = true;
                    break;
            }
        }

        public void OdblokujPoziomPodatkow()
        {
            o1.mieszkancy.poziomPodatkow = o1.mieszkancy.poziomZadowolenia;

            switch(o1.mieszkancy.poziomPodatkow)
            {
                case 0:
                    podatki[0].Enabled = true;
                    break;
                case 1:
                    podatki[0].Enabled = true;
                    podatki[1].Enabled = true;
                    break;
                case 2:
                    podatki[0].Enabled = true;
                    podatki[1].Enabled = true;
                    podatki[2].Enabled = true;
                    break;
                case 3:
                    podatki[0].Enabled = true;
                    podatki[1].Enabled = true;
                    podatki[2].Enabled = true;
                    podatki[3].Enabled = true;
                    break;
                case 4:
                    podatki[0].Enabled = true;
                    podatki[1].Enabled = true;
                    podatki[2].Enabled = true;
                    podatki[3].Enabled = true;
                    podatki[4].Enabled = true;
                    break;
                case 5:
                    podatki[0].Enabled = true;
                    podatki[1].Enabled = true;
                    podatki[2].Enabled = true;
                    podatki[3].Enabled = true;
                    podatki[4].Enabled = true;
                    podatki[5].Enabled = true;
                    break;
            }

        }

        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            this.Close();
            podatki.Clear();
        }
    }
}
