using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GrowCastleBot.Classes
{
    class Waves
    {
        Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        List<int[]> trupsToUse = new List<int[]>();
        bool adsEnable;
        bool useDiamonds;
        bool useMimic;

        public Waves(List<int> characters, bool ad, bool diamonds, bool mimic)
        {
            trupsToUse = Utilities.getCharactersPositions(characters);
            adsEnable = ad;
            useDiamonds = diamonds;
            useMimic = mimic;
            setup();
        }
        private void setup()
        {
            startButton = Utilities.correctPosition(startButton);
            adButton = Utilities.correctPosition(adButton);
            closeAdButton = Utilities.correctPosition(closeAdButton);
        }

        int[] startButton = { 1760, 1000 };
        public void startBattle()
        {
            Thread.Sleep(1000);
            Home.checkRoutine(useDiamonds);
            Thread.Sleep(1000);

            Clicker.mouseClick(startButton);
            Thread.Sleep(3000);
            realBattle();
        }

        private void realBattle()
        {
            Battle.gameBattle(trupsToUse, useMimic);

            Thread.Sleep(2000);

            if (adsEnable)
            {
                ad();
            }
            else
            {
                Thread.Sleep(3000);
                startBattle();
            }
        }

        int[] adButton = { 960, 900 };
        int[] closeAdButton = { 1850, 70 };
        private void ad()
        {
            Thread.Sleep(2000);
            Graphics finalScreen = Graphics.FromImage(screen as Image);
            finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);

            if (screen.GetPixel(adButton[0], adButton[1]) == Color.FromArgb(242, 190, 35))
            {
                Clicker.mouseClick(adButton);
                Thread.Sleep(35000);
                Clicker.mouseClick(closeAdButton);
            }

            Thread.Sleep(3000);
            startBattle();
        }
    }
}
