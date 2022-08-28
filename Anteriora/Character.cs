using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anteriora
{
    class Character
    {
        public static int REF { get; set; }
        public static string characterName { get; set; }
        public static int characterClass { get; set; }
        public static int level { get; set; }
        public static int EXP { get; set; } // experience points
        public static int strength { get; set; }
        public static int dexterity { get; set; }
        public static int intelligence { get; set; }
        public static int vitality { get; set; }
        public static int HP { get; set; } // health points
        public static int MP { get; set; } // mana points
        public static int AR { get; set; } // armor
        public static int MR { get; set; } // magic resistance
        public static Bitmap pictureUp { get; set; }
        public static Bitmap pictureDown { get; set; }
        public static Bitmap pictureLeft { get; set; }
        public static Bitmap pictureRight { get; set; }

        public Character(string login, int type, string name)
        {
            characterName = name;

            characterClass = type;

            if(characterClass == 1)
            {
                pictureUp = Properties.Resources.wojownikgora;
                pictureDown = Properties.Resources.wojownikdol;
                pictureLeft = Properties.Resources.wojowniklewo;
                pictureRight = Properties.Resources.wojownikprawo;
            }
            else if(characterClass == 2)
            {
                pictureUp = Properties.Resources.lucznikgora;
                pictureDown = Properties.Resources.lucznikdol;
                pictureRight = Properties.Resources.lucznikprawo;
                pictureLeft = Properties.Resources.luczniklewo;
            }
            else if(characterClass == 3)
            {
                // obrazki dla maga
            }
        }

        public Character(int REF, string name, int type, int level, int EXP, int strength, int dexterity, int intelligence, int vitality)
        {
            Character.REF = REF;

            Character.characterName = name;

            Character.characterClass = type;

            Character.level = level;

            Character.EXP = EXP;

            Character.strength = strength;

            Character.dexterity = dexterity;

            Character.intelligence = intelligence;

            Character.vitality = vitality;

            if (Character.characterClass == 1)
            {
                pictureUp = Properties.Resources.wojownikgora;
                pictureDown = Properties.Resources.wojownikdol;
                pictureLeft = Properties.Resources.wojowniklewo;
                pictureRight = Properties.Resources.wojownikprawo;
            }
            else if (Character.characterClass == 2)
            {
                pictureUp = Properties.Resources.lucznikgora;
                pictureDown = Properties.Resources.lucznikdol;
                pictureRight = Properties.Resources.lucznikprawo;
                pictureLeft = Properties.Resources.luczniklewo;
            }
            else if (Character.characterClass == 3)
            {
                // obrazki dla maga
            }
        }
    }
}
