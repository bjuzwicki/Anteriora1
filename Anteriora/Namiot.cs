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
    public partial class Namiot : Form
    {
        Osada o;

        public Namiot(Osada c)
        {
            o = c;
            InitializeComponent();
        }

        private void buttonWyjscieNamiot_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBudowaNamiot_Click(object sender, EventArgs e)
        {
            new Budowa(o).ShowDialog();
        }

        private void buttonUlepszanieNamiot_Click(object sender, EventArgs e)
        {
            new Ulepszanie(o).ShowDialog();
        }

        private void buttonZarządzanieNamiot_Click(object sender, EventArgs e)
        {
            new Zarzadzanie(o).ShowDialog();
        }

        private void buttonZapiszStanGryNamiot_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into SAVES(USER_CHARACTER,TIME,WOOD_QUANTITY,WOOD_EXPLOITATION,HAY_QUANTITY,HAY_EXPLOITATION,STONE_QUANTITY,STONE_EXPLOITATION,FOOD_QUANTITY,FOOD_EXPLOITATION,WATER_QUANTITY,WATER_EXPLOITATION,SKIN_QUANTITY,SKIN_EXPLOITATION,GOLD_QUANTITY,GOLD_EXPLOITATION,IRONORE_QUANTITY,IRONORE_EXPLOITATION,OBSIDIANORE_QUANTITY,OBSIDIANORE_EXPLOITATION,WOOL_QUANTITY,WOOL_EXPLOITATION,IRON_QUANTITY,IRON_EXPLOITATION,OBSIDIAN_QUANTITY,OBSIDIAN_EXPLOITATION,LEATHERBELT_QUANTITY,LEATHERBELT_EXPLOITATION,PIECEOFWOOD_QUANTITY,PIECEOFWOOD_EXPLOITATION) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29})", Character.REF,Panel.czasGry,o.wood.quantity, o.wood.exploitationLevel, o.hay.quantity, o.hay.exploitationLevel, o.stone.quantity, o.stone.exploitationLevel, o.food.quantity, o.food.exploitationLevel, o.water.quantity, o.water.exploitationLevel, o.skin.quantity, o.skin.exploitationLevel, o.gold.quantity, o.gold.exploitationLevel, o.ironOre.quantity, o.ironOre.exploitationLevel, o.obsidianOre.quantity, o.obsidianOre.exploitationLevel, o.wool.quantity, o.wool.exploitationLevel, o.iron.quantity, o.iron.exploitationLevel, o.obsidian.quantity, o.obsidian.exploitationLevel, o.leatherBelt.quantity, o.leatherBelt.exploitationLevel, o.pieceOfWood.quantity, o.pieceOfWood.exploitationLevel);

            SQLConnection sql = new SQLConnection();

            if(sql.RunSQL(query) > 0)
            {
                new Wiadomosc("Stan gry został zapisany").Show();
            }
            else
            {
                new Wiadomosc("Wystąpił błąd (1) podczas zapisu danych. Skontaktuj się ze wsparciem.").Show();
            }
        }
    }
}
