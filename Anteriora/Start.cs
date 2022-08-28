using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;

namespace Anteriora
{
    public partial class Start : Form
    {
        int ktoraPostac;
        int index = 0;
        DataTable charactersData;
        string isCharactersExists;

        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        public Start()
        {
            InitializeComponent();
           
            timerLadowanie.Start();
        }

        private void TimerLadowanie_Tick(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(pictureBox1.Width + 10, pictureBox1.Height);

            if (pictureBox1.Width == 700)
            {
                pictureBox1.Visible = false;
                pictureBoxName.Visible = true;
                buttonLogIn.Visible = true;
                buttonRegistration.Visible = true;
                buttonExitGame2.Visible = true;
                //button1.Visible = true;
                this.BackgroundImage = Properties.Resources.t2;
                wplayer.URL = "muzyka1.mp3";
                wplayer.controls.play();
                timerLadowanie.Stop();
            }
        }

        private void ButtonWyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLogowanie_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;
            //panel2.Visible = true;
            //panel3.Visible = true;
            //panel8.Visible = true;            
            //panel9.Visible = true;
            //pictureBoxLucznik.Visible = true;
            //pictureBoxWojownik.Visible = true;
            //pictureBoxMag.Visible = true;
            //buttonWojownik.Visible = true;
            //buttonLucznik.Visible = true;
            //buttonMag.Visible = true;

            //buttonPowrot.Visible = true;
            //buttonDalej.Visible = true;
            //buttonLogowanie.Visible = false;
            //buttonRejestracja.Visible = false;
            //buttonWyjscie.Visible = false;
            //pictureBoxNazwa.Visible = false;
            //buttonDalej.Focus();

            buttonLogIn.Visible = false;
            buttonRegistration.Visible = false;
            buttonExitGame2.Visible = false;
            panelLogin.Visible = true;
            panelPassword.Visible = true;
            buttonBackLogin.Visible = true;
            buttonLogIn2.Visible = true;

            textBoxLogin.Text = "";
            textBoxPassword.Text = "";


            textBoxLogin.Focus();
            textBoxPassword.Focus();
            buttonLogIn2.Focus();


            //textBoxNazwaPostaci.Text = "Nazwa postaci";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            wplayer.controls.play();
        }

        private void ButtonPowrot_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panelInformation.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            pictureBoxArcher.Visible = false;
            pictureBoxWarrior.Visible = false;
            pictureBoxSorcerer.Visible = false;
            buttonWarrior.Visible = false;
            buttonArcher.Visible = false;
            buttonSorcerer.Visible = false;
            buttonBack3.Visible = false;
            buttonCreateCharacter.Visible = false;   
            
            buttonNewGame.Visible = true;
            buttonContinue.Visible = true;
            buttonExitGame.Visible = true;
            pictureBoxName.Visible = true;
            panelWelcome.Visible = true;

            if (!string.IsNullOrEmpty(isCharactersExists))
            {
                ChooseCharacter();
                panelCharacter.Visible = true;
            }
        }

        private void ButtonRejestracja_Click(object sender, EventArgs e)
        {
            buttonLogIn.Visible = false;
            buttonRegistration.Visible = false;
            buttonExitGame2.Visible = false;
            panelLogin2.Visible = true;
            panelPassword2.Visible = true;
            panelEmail.Visible = true;
            buttonRegisterNow.Visible = true;
            buttonBack2.Visible = true;

            textBoxLogin2.Text = "";
            textBoxPassword2.Text = "";
            textBoxEmail2.Text = "";


            textBoxLogin2.Focus();
            textBoxPassword2.Focus();
            textBoxEmail2.Focus();
            buttonRegisterNow.Focus();
        }

        private void ButtonPowrotZLogowania_Click(object sender, EventArgs e)
        {
            buttonLogIn.Visible = true;
            buttonRegistration.Visible = true;
            buttonExitGame2.Visible = true; ;
            panelLogin.Visible = false;
            panelPassword.Visible = false;
            buttonBackLogin.Visible = false;
            buttonLogIn2.Visible = false;
        }

        private void ButtonZalogujSie_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                //panel1.Visible = true;
                //panel2.Visible = true;
                //panel3.Visible = true;
                //panel8.Visible = true;
                //panel9.Visible = true;
                //pictureBoxLucznik.Visible = true;
                //pictureBoxWojownik.Visible = true;
                //pictureBoxMag.Visible = true;
                //buttonWojownik.Visible = true;
                //buttonLucznik.Visible = true;
                //buttonMag.Visible = true;

                //buttonPowrot.Visible = true;
                //buttonDalej.Visible = true;

                SQLConnection sql = new SQLConnection();

                if (sql.VerifyLoginAndPassword(textBoxLogin.Text, textBoxPassword.Text))
                {
                    new User(textBoxLogin.Text);
                    buttonNewGame.Visible = true;
                    buttonContinue.Visible = true;
                    buttonExitGame.Visible = true;
                    SetWelcomeInformation();
                    panelWelcome.Visible = true;
                    panelLogin.Visible = false;
                    panelPassword.Visible = false;
                    buttonBackLogin.Visible = false;
                    buttonLogIn2.Visible = false;

                    isCharactersExists = sql.GetField("REF", "USER_CHARACTERS", "USER_REF = " + User.REF).ToString();

                    if (!string.IsNullOrEmpty(isCharactersExists))
                    {
                        charactersData = sql.GetCharacterList(User.REF);
                        ChooseCharacter();
                        panelCharacter.Visible = true;
                    }
                }
                else
                {
                    new Wiadomosc("Podano zły login lub hasło.").Show();
                }
            }
            else
            {
                new Wiadomosc("Nie uzupełniono loginu lub hasła.").Show();
            }

        }

        private void ButtonWyjscieZGry_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonNowaGra_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panelInformation.Visible = true;
            panel8.Visible = true;
            panel9.Visible = true;
            pictureBoxArcher.Visible = true;
            pictureBoxWarrior.Visible = true;
            pictureBoxSorcerer.Visible = true;
            buttonWarrior.Visible = true;
            buttonArcher.Visible = true;
            buttonSorcerer.Visible = true;
            buttonBack3.Visible = true;
            buttonCreateCharacter.Visible = true;

            buttonNewGame.Visible = false;
            buttonContinue.Visible = false;
            buttonExitGame.Visible = false;
            pictureBoxName.Visible = false;
            panelWelcome.Visible = false;
            panelCharacter.Visible = false;
            textBoxCharacterName.Focus();
            buttonCreateCharacter.Focus();
        }

        private void ButtonDalej_Click(object sender, EventArgs e)
        { 
            if(ktoraPostac == 0 || string.IsNullOrEmpty(textBoxCharacterName.Text) || string.IsNullOrWhiteSpace(textBoxCharacterName.Text))
            {
                new Wiadomosc("Nie wybrałeś postaci lub nie podałeś nazwy postaci.").Show();
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panelInformation.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                pictureBoxArcher.Visible = false;
                pictureBoxWarrior.Visible = false;
                pictureBoxSorcerer.Visible = false;
                buttonWarrior.Visible = false;
                buttonArcher.Visible = false;
                buttonSorcerer.Visible = false;
                buttonBack3.Visible = false;
                buttonCreateCharacter.Visible = false;
                pictureBoxName.Visible = false;
                panelWelcome.Visible = false;

                this.BackgroundImage = null;

                SQLConnection sql = new SQLConnection();

                int number = sql.SetCharacterData(ktoraPostac, textBoxCharacterName.Text.Trim());

                if(number > 0)
                {
                    sql.GetCharacterData(User.REF, number);
                    new EkranLadowania(5).Show();
                }
                else
                {
                    new Wiadomosc("Błąd podczas tworzenia postaci.").Show();
                }  
            }
        }

        private void ButtonWojownik_Click(object sender, EventArgs e)
        {
            ktoraPostac = 1;
            buttonWarrior.FlatAppearance.BorderColor = Color.Red;
            buttonSorcerer.FlatAppearance.BorderColor = Color.Black;
            buttonArcher.FlatAppearance.BorderColor = Color.Black;

        }

        private void ButtonLucznik_Click(object sender, EventArgs e)
        {
            ktoraPostac = 2;
            buttonArcher.FlatAppearance.BorderColor = Color.Red;
            buttonSorcerer.FlatAppearance.BorderColor = Color.Black;
            buttonWarrior.FlatAppearance.BorderColor = Color.Black;

        }

        private void ButtonMag_Click(object sender, EventArgs e)
        {
            ktoraPostac = 3;
            buttonSorcerer.FlatAppearance.BorderColor = Color.Red;
            buttonArcher.FlatAppearance.BorderColor = Color.Black;
            buttonWarrior.FlatAppearance.BorderColor = Color.Black;
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();

            rClient.endPoint = "http://172.104.156.223/user/" + textBoxLogin.Text;

            string strResponse = string.Empty;

            strResponse = rClient.makeRequest();

            textBoxGo.Text = strResponse;

        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxLogin2.Text) || string.IsNullOrEmpty(textBoxPassword2.Text) || string.IsNullOrEmpty(textBoxEmail2.Text))
            {
                new Wiadomosc("Nie uzupełniono danych.").Show();
                return;
            }

            SQLConnection sql = new SQLConnection();

            if(sql.VerifyLogin(textBoxLogin2.Text))
            {
                int result = sql.RunSQL(string.Format("insert into USERS (LOGIN, PASSWORD, EMAIL) values ('{0}','{1}','{2}')", textBoxLogin2.Text, textBoxPassword2.Text, textBoxEmail2.Text));

                if (result > 0)
                {
                    new User(textBoxLogin2.Text, textBoxEmail2.Text);

                    buttonNewGame.Visible = true;
                    buttonContinue.Visible = true;
                    buttonExitGame.Visible = true;
                    SetWelcomeInformation();
                    panelWelcome.Visible = true;
                    panelLogin2.Visible = false;
                    panelPassword2.Visible = false;
                    panelEmail.Visible = false;
                    buttonRegisterNow.Visible = false;
                    buttonBack2.Visible = false;
                }
                else
                {
                    new Wiadomosc("Wystąpił błąd.").Show();
                }
            }
            else
            {
                new Wiadomosc("Login zajęty.").Show();
            }
        }

        private void buttonBack2_Click(object sender, EventArgs e)
        {
            buttonLogIn.Visible = true;
            buttonRegistration.Visible = true;
            buttonExitGame2.Visible = true;
            

            panelLogin2.Visible = false;
            panelPassword2.Visible = false;
            panelEmail.Visible = false;
            buttonRegisterNow.Visible = false;
            buttonBack2.Visible = false;
        }

        private void buttonWczytaj_Click(object sender, EventArgs e)
        {
            SQLConnection sql = new SQLConnection();

            if (index+1 > 0)
            {
                buttonNewGame.Visible = false;
                buttonContinue.Visible = false;
                buttonExitGame.Visible = false;
                panelWelcome.Visible = false;
                panelCharacter.Visible = false;

                this.BackgroundImage = null;

                sql.GetCharacterData(User.REF, index+1);
                new EkranLadowania(6).Show();
            }
            else
            {
                new Wiadomosc("Błąd podczas wczytywania postaci.").Show();
            }            
        }

        private void buttonPreviousCharacter_Click(object sender, EventArgs e)
        {
            if(index > 0)
            {
                index--;
                ChooseCharacter();
            }
        }

        private void buttonNextCharacter_Click(object sender, EventArgs e)
        {
            if(index < charactersData.Rows.Count-1)
            {
                index++;
                ChooseCharacter();
            }
        }

        public void SetWelcomeInformation()
        {
            labelWelcome.Text = "Welcome, " + User.login + "!";
        }

        public void ChooseCharacter()
        {
            labelCharacterName.Text = charactersData.Rows[index][0].ToString();

            if (charactersData.Rows[index][1].ToString() == "Warrior")
            {
                pictureBoxCharacter.Image = Properties.Resources.wojownikdol;
            }
            else if (charactersData.Rows[index][1].ToString() == "Archer")
            {
                pictureBoxCharacter.Image = Properties.Resources.lucznikdol;
            }

            labelStatistics.Text = "Class: " + charactersData.Rows[index][1].ToString() + Environment.NewLine + "Level: " + charactersData.Rows[index][2].ToString() +
                                                Environment.NewLine + "EXP: " + charactersData.Rows[index][3].ToString() + Environment.NewLine + "Strength: " + charactersData.Rows[index][4].ToString() +
                                                Environment.NewLine + "Dexterity: " + charactersData.Rows[index][5].ToString() + Environment.NewLine + "Intelligence: " + charactersData.Rows[index][6].ToString() +
                                                Environment.NewLine + "Vitality: " + charactersData.Rows[index][7].ToString() + Environment.NewLine + "HP: " +
                                                ((int)charactersData.Rows[index][7] * 10).ToString() + Environment.NewLine + "MP: " +
                                                ((int)charactersData.Rows[index][6] * 10).ToString();
        }
    }
}
