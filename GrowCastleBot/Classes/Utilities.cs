using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GrowCastleBot.Classes
{
    class Utilities
    {
        public static List<int[]> getCharactersPositions(List<int> characters)
        {
            List<int[]> neededCharacters = new List<int[]>();

            for (int i = 0; i < characters.Count; i++)
            {
                int[] finalCharacter = correctPosition(charactersPositions[characters[i]]);
                neededCharacters.Add(finalCharacter);
            }

            return neededCharacters;
        }

        static int[] currentScreen = { Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height };
        public static int[] correctPosition(int[] posiztions)
        {
            int newX = (int)(Math.Round(posiztions[0] / 1920.0 * currentScreen[0]));
            int newY = (int)(Math.Round(posiztions[1] / 1080.0 * currentScreen[1]));

            int[] newCoordinates = { newX, newY };
            return newCoordinates;
        }

        private static List<int[]> charactersPositions = new List<int[]>
        {
            new int[]{ 435, 75 },
            new int[]{ 555, 75 },
            new int[]{ 675, 75 },
            new int[]{ 435, 220 },
            new int[]{ 555, 220 },
            new int[]{ 675, 220 },
            new int[]{ 435, 360 },
            new int[]{ 555, 360 },
            new int[]{ 675, 360 },
            new int[]{ 435, 495 },
            new int[]{ 555, 495 },
            new int[]{ 675, 495 }
        };

        static int[] clickToSelectGrowCastleWindow = { 900, 170 };
        public static void setupWindows()
        {
            Thread.Sleep(500);

            clickToSelectGrowCastleWindow = Utilities.correctPosition(clickToSelectGrowCastleWindow);
            Clicker.mouseClick(clickToSelectGrowCastleWindow);

            Thread.Sleep(2000);

            Clicker.f11KeyClick();
        }
    }
}
