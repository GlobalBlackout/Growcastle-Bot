using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GrowCastleBot.Classes
{
    class Home
    {
        static Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        public static void checkRoutine(bool diamonds)
        {
            setup();

            if(diamonds)
                checkDiamonds(); 
        }

        static int[] maxDiamondPoint = { 500, 30 };
        static int diamondStripe = 60;
        private static void checkDiamonds()
        {
            Graphics finalScreen = Graphics.FromImage(screen as Image);
            finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);

            for (int i = 0; i < 60; i++)
            {
                if (screen.GetPixel(maxDiamondPoint[0] + i, maxDiamondPoint[1]) == Color.FromArgb(86, 213, 255))
                {
                    Thread.Sleep(500);
                    useDiamonds();
                    break;
                }               
            }
        }

        static int[] buttonToEnterTower = { 570, 690 };
        static int[] buttonToSelectTower = { 570, 570 };
        static int[] buttonToSelectTower2 = { 1635, 235 };
        static int[] buttonToSelectTower3 = { 1635, 550 };
        static int[] buttonToUpgradeTower = { 1325, 720 };
        static int[] buttonEscUpgrade = { 1460, 245 };
        static int[] buttonEscTower = { 1830, 110 };

        private static void useDiamonds()
        {

            Thread.Sleep(500);
            Clicker.mouseClick(buttonToEnterTower);

            Thread.Sleep(500);
            Clicker.mouseClick(buttonToSelectTower);
            
            Thread.Sleep(500);
            Clicker.mouseClick(buttonToSelectTower2);

            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(200);
                Clicker.mouseClick(buttonToUpgradeTower);
            }

            Thread.Sleep(500);
            Clicker.mouseClick(buttonEscUpgrade);
            
            Thread.Sleep(1000);
            Clicker.mouseClick(buttonToSelectTower3);

            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(200);
                Clicker.mouseClick(buttonToUpgradeTower);
            }

            Thread.Sleep(500);
            Clicker.mouseClick(buttonEscUpgrade);

            Thread.Sleep(500);
            Clicker.mouseClick(buttonEscTower);
        }

        private static void setup()
        {
            maxDiamondPoint = Utilities.correctPosition(maxDiamondPoint);
            diamondStripe = (int)(diamondStripe / 1920.0 * Screen.PrimaryScreen.Bounds.Width);

            buttonToEnterTower = Utilities.correctPosition(buttonToEnterTower);
            buttonToSelectTower = Utilities.correctPosition(buttonToSelectTower);
            buttonToSelectTower2 = Utilities.correctPosition(buttonToSelectTower2);
            buttonToSelectTower3 = Utilities.correctPosition(buttonToSelectTower3);
            buttonToUpgradeTower = Utilities.correctPosition(buttonToUpgradeTower);
            buttonEscUpgrade = Utilities.correctPosition(buttonEscUpgrade);
            buttonEscTower = Utilities.correctPosition(buttonEscTower);
        }
    }
}
