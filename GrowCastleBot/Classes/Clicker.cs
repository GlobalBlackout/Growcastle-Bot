using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace GrowCastleBot.Classes
{
    class Clicker
    {
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButton, int ewExtraInfo);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public static void mouseClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
        public static void mouseClick(int[] coordinates)
        {
            SetCursorPos(coordinates[0], coordinates[1]);
            mouse_event(MOUSEEVENTF_LEFTDOWN, coordinates[0], coordinates[1], 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, coordinates[0], coordinates[1], 0, 0);
        }

        const int VK_F11 = 0x7a;
        const int KEYEVENTF_KEYUP = 0x0002;
        public static void f11KeyClick()
        {
            keybd_event(VK_F11, 0, 0, 0);
            Thread.Sleep(100);
            keybd_event(VK_F11, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
