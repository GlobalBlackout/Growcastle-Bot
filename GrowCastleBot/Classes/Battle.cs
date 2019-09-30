using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace GrowCastleBot.Classes
{
    static class Battle
    {
        static int[] waveDuration = { 1550, 80 };
        static Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        static int pixelToAddForActivateAbility = 50;
        static public void gameBattle(List<int[]> trupsToUse, bool mimic = true)
        {
            setup();

            Graphics finalScreen = Graphics.FromImage(screen as Image);

            while (true)
            {
                Thread.Sleep(1000);
                finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);

                for (int i = 0; i < trupsToUse.Count; i++)
                {
                    if(screen.GetPixel(trupsToUse[i][0], trupsToUse[i][1]) == Color.FromArgb(84, 188, 255))
                    {
                        Clicker.mouseClick(trupsToUse[i][0], trupsToUse[i][1] + pixelToAddForActivateAbility);
                        Thread.Sleep(200);
                    }
                }

                Color endColor = screen.GetPixel(waveDuration[0], waveDuration[1]);

                if (endColor != Color.FromArgb(255, 255, 255) && endColor != Color.FromArgb(0, 0, 0) && endColor != Color.FromArgb(232, 77, 77))
                {
                    Thread.Sleep(1000);

                    finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);
                    endColor = screen.GetPixel(waveDuration[0], waveDuration[1]);

                    if (endColor != Color.FromArgb(255, 255, 255) && endColor != Color.FromArgb(0, 0, 0) && endColor != Color.FromArgb(232, 77, 77))
                    {
                        break;                 
                    }
                }

                if(mimic)
                    findMimic();
            }        
        }

        static int[] mimicPosition = { 1050, 850 };
        static int mimicRangePosition = 100;
        static Color[] mimicSpots = new Color[9];

        private static void setupMimicColors()
        {
            Graphics finalScreen = Graphics.FromImage(screen as Image);
            finalScreen.CopyFromScreen(0, 0, 0, 0, screen.Size);

            for (int i = 0; i < mimicSpots.Length; i++)
            {
                mimicSpots[i] = screen.GetPixel(mimicPosition[0] + (mimicRangePosition * i), mimicPosition[1]);
            }
        }
        private static void findMimic()
        {
            for (int i = 0; i < mimicSpots.Length; i++)
            {
                int pixelWrong = 0;
                if(screen.GetPixel(mimicPosition[0] + (mimicRangePosition * i), mimicPosition[1]) != mimicSpots[i])
                {
                    Clicker.mouseClick(mimicPosition[0] + (mimicRangePosition * i), mimicPosition[1]);
                    pixelWrong++;
                }

                if (pixelWrong > 7)
                    setupMimicColors();
            }
        }

        private static void setup()
        {
            waveDuration = Utilities.correctPosition(waveDuration);
            mimicPosition = Utilities.correctPosition(mimicPosition);
            
            pixelToAddForActivateAbility = (int)(pixelToAddForActivateAbility / 1080.0 * Screen.PrimaryScreen.Bounds.Height);
            mimicRangePosition = (int)(mimicRangePosition / 1920.0 * Screen.PrimaryScreen.Bounds.Width);

            setupMimicColors();
        }
    }
}