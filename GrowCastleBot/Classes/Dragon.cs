using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GrowCastleBot.Classes
{
    class Dragon
    {
        Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        int dragonToFight;
        bool[] itemsToMat;
        List<int[]> trupsToUse = new List<int[]>();

        public Dragon(List<int> characters, int dragon, bool[] itemsToMat)
        {
            dragonToFight = dragon;
            this.itemsToMat = itemsToMat;
            trupsToUse = Utilities.getCharactersPositions(characters);
            setup();
        }

        private void setup()
        {
            dragonButton = Utilities.correctPosition(dragonButton);
            for (int i = 0; i < dragonChoice.Count; i++)
            {
                dragonChoice[i] = Utilities.correctPosition(dragonChoice[i]);
            }
            pixelToCheck = Utilities.correctPosition(pixelToCheck);
            matButton = Utilities.correctPosition(matButton);
            getButton = Utilities.correctPosition(getButton);
            checkLine = Utilities.correctPosition(checkLine);
            line = (int)(300 / 1920.0 * Screen.PrimaryScreen.Bounds.Width);
        }

        int[] dragonButton = { 930, 350 };
        List<int[]> dragonChoice = new List<int[]> { new int[] { 1720, 230 }, new int[] { 1720, 400 }, new int[] { 1720, 570 } };
        public void startDragon()
        {
            Thread.Sleep(1000);
            Home.checkRoutine(false);
            Thread.Sleep(1000);

            Clicker.mouseClick(dragonButton);
            Thread.Sleep(500);

            Clicker.mouseClick(dragonChoice[dragonToFight]);
            Thread.Sleep(500);
            Clicker.mouseClick(dragonChoice[dragonToFight]);
            Thread.Sleep(500);

            realBattle();
        }

        private void realBattle()
        {
            Battle.gameBattle(trupsToUse);
  
            collectReward();
        }

        private void collectReward()
        {
            waitForItem();

            int item = itemRecognizer();

            if (item != -1 && itemsToMat[item])
                matItem();
            else
                getItem();

            Thread.Sleep(3000);
            startDragon();
        }

        int[] pixelToCheck = { 1130, 350 }; 
        private void waitForItem()
        {
            while (true)
            {
                Graphics finalScreen = Graphics.FromImage(screen as Image);
                finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);

                if (screen.GetPixel(pixelToCheck[0], pixelToCheck[1]) == Color.FromArgb(98, 87, 73))
                    break;

                Thread.Sleep(1000);
            }

            Thread.Sleep(2000);
        }

        int[] matButton = { 860, 810 };
        private void matItem()
        {
            Clicker.mouseClick(matButton);
            Thread.Sleep(500);
            Clicker.mouseClick(matButton);
        }

        int[] getButton = { 1150, 810 };
        private void getItem()
        {
            Clicker.mouseClick(getButton);
        }

        int[] checkLine = { 840, 260 };
        int line = 300;
        private int itemRecognizer()
        {
            Graphics finalScreen = Graphics.FromImage(screen as Image);
            finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);

            //0 = B, 1 = A, 2 = S
            int item = -1;

            for (int i = 0; i < line; i++)
            {
                if (screen.GetPixel(checkLine[0] + i, checkLine[1]) == Color.FromArgb(218, 218, 218))
                {
                    item = 0;
                    break;
                }
                else if (screen.GetPixel(checkLine[0] + i, checkLine[1]) == Color.FromArgb(68, 255, 218))
                {
                    item = 1;
                    break;
                }
                else if (screen.GetPixel(checkLine[0] + i, checkLine[1]) == Color.FromArgb(244, 86, 233))
                {
                    item = 2;
                    break;
                }
            }

            return item;
        }

    }
}
