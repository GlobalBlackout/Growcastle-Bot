using GrowCastleBot.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace GrowCastleBot
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if (!cb_battle.Checked && !cb_dragon.Checked)
                return;

            WindowState = FormWindowState.Minimized;
            Utilities.setupWindows();

            List<int> characters = getCharactersChecked();

            if (cb_battle.Checked)
            {
                bool ad = cb_ads.Checked;
                bool useGems = cb_useGemsCastle.Checked;
                bool useMImic = cb_mimic.Checked;

                Waves waves = new Waves(characters, ad, useGems, useMImic);
                waves.startBattle();
            }
            else if (cb_dragon.Checked)
            {
                int dragonChoice = dragChoice();
                bool[] itemsToMat = checkItems();

                Dragon dragon = new Dragon(characters, dragonChoice, itemsToMat);
                dragon.startDragon();
            }
        }
        private int dragChoice()
        {
            int d = 0;

            if (cb_gd.Checked)
                d = 0;
            else if (cb_bd.Checked)
                d = 1;
            else if (cb_rd.Checked)
                d = 2;

            return d;
        }

        private bool[] checkItems()
        {
            bool[] items = new bool[] { cb_b.Checked, cb_a.Checked, cb_s.Checked };
            return items;
        }

        private List<int> getCharactersChecked()
        {
            List<int> c = new List<int>();

            if (cb_char_1.Checked)
                c.Add(0);

            if (cb_char_2.Checked)
                c.Add(1);

            if (cb_char_3.Checked)
                c.Add(2);

            if (cb_char_4.Checked)
                c.Add(3);

            if (cb_char_5.Checked)
                c.Add(4);

            if (cb_char_6.Checked)
                c.Add(5);

            if (cb_char_7.Checked)
                c.Add(6);

            if (cb_char_8.Checked)
                c.Add(7);

            if (cb_char_9.Checked)
                c.Add(8);

            if (cb_char_10.Checked)
                c.Add(9);

            if (cb_char_11.Checked)
                c.Add(10);

            if (cb_char_12.Checked)
                c.Add(11);

            return c;
        }

        private void Cb_battle_CheckedChanged(object sender, EventArgs e)
        {
            bool dragonEnable = !cb_battle.Checked;

            cb_dragon.Enabled = dragonEnable;
            cb_gd.Enabled = dragonEnable;
            cb_bd.Enabled = dragonEnable;
            cb_rd.Enabled = dragonEnable;
            cb_b.Enabled = dragonEnable;
            cb_a.Enabled = dragonEnable;
            cb_s.Enabled = dragonEnable;

            btn_start.Enabled = cb_battle.Checked;
        }

        private void Cb_dragon_CheckedChanged(object sender, EventArgs e)
        {
            bool battleEnable = !cb_dragon.Checked;

            cb_battle.Enabled = battleEnable;
            cb_ads.Enabled = battleEnable;
            cb_useGemsCastle.Enabled = battleEnable;
            cb_mimic.Enabled = battleEnable;

            btn_start.Enabled = cb_dragon.Checked;
        }
    }
}
