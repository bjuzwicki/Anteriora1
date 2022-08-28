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
    public partial class Budowa : Form
    {      
        Osada o;

        public Budowa(Osada c)
        {
            o = c;
            InitializeComponent();
        }
              
        #region Opis budowli
        private void buttonTartakOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja drewna (można wybudować dwa tartaki).");
        }

        private void buttonKamieniolomOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja kamienia (można wybudować dwa kamieniołomy).");
        }

        private void buttonChatkaRolnikaOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja siana.");
        }

        private void buttonHodowlaOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja jedzenia.");
        }

        private void buttonSadOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja jedzenia.");
        }

        private void buttonKwateraRybackaOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja jedzenia.");
        }

        private void buttonStudniaOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja wody.");
        }

        private void buttonMagazynOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skład materiałów.");
        }

        private void buttonBudynekMieszkalnyOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wzrost liczby osadników.");
        }

        private void buttonKuzniaOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produkcja nowych surowców.");
        }

        private void buttonTargowiskoOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Handel materiałami.");
        }

        private void buttonKoszaryOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rekrutacja jednostek militarnych.");
        }

        private void buttonMostOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pozwala dostać się na południowo-wschodnią część mapy.");
        }

        private void buttonMurOpis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ochrona przed atakami najeźdźców.");
        }

        #endregion

        #region Budowanie cz.1 

        private void buttonTartakBudowa_Click(object sender, EventArgs e)                          
        {
            if (o.pictureBoxTartak1.Visible == false)
            {
                o.KosztBudowyOsada(o.wood, 50, o.hay,0, o.tartak1);
            }
            else if (o.pictureBoxTartak1.Visible == true)
            {
                o.KosztBudowyOsada(o.wood, 50,o.hay,0, o.tartak2);
            }
        }

        private void buttonKamieniolomBudowa_Click(object sender, EventArgs e)
        {
            if (o.pictureBoxKamieniolom1.Visible == false)
            {
                o.KosztBudowyOsada(o.wood, 200,o.hay,0, o.kamieniolom1);
            }
            else if(o.pictureBoxKamieniolom1.Visible == true)
            {
                o.KosztBudowyOsada(o.wood, 200,o.hay,0, o.kamieniolom2);
            }
        }

        private void buttonChatkaRolnikaBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 50,o.hay,50, o.chatkaRolnika);
        }

        private void buttonHodowlaBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 100,o.hay,100, o.hodowla);
        }

        private void buttonSadBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 50, o.hay, 50, o.chataMaga);
        }

        private void buttonKwateraRybacka_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 50,o.hay,50, o.kwateraRybacka);
        }

        private void buttonStudniaBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 50,o.stone,100, o.studnia);
        }

        private void buttonMagazynBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 100,o.hay,100, o.magazyn);
        }

        private void buttonBudynekMieszkalnyBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 100,o.hay,100, o.budynekMieszkalny);
        }

        private void buttonKuzniaBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 200,o.hay,0, o.kuznia);
        }
        private void buttonTargowiskoBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 300,o.stone,150, o.targowisko);
        }

        private void buttonKoszaryBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 50,o.stone,300, o.koszary);
        }

        private void buttonMostBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 100,o.hay,0, o.most);
        }

        private void buttonMurBudowa_Click(object sender, EventArgs e)
        {
            o.KosztBudowyOsada(o.wood, 300,o.hay,0, o.mur);
        }
        
        #endregion

        private void buttonAnulujBudowa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Budowa_Load(object sender, EventArgs e)
        {

        }
    }
}
