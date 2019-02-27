using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Medooza.NET.Extensions;
using Medooza.NET.Interfaces;
using TestStack.White.Factory;
using TestStack.White.WindowsAPI;
using Application = TestStack.White.Application;
using Window = TestStack.White.UIItems.WindowItems.Window;

namespace Medooza.NET.Implementations
{
    public class IdeaProcessManipulator : IIdeaProcessManipulator
    {
        private readonly Point _extractButtonPosition;
        private Window _mainWindow;
        private uint _turnedOffPixel;
        private IntPtr _intPtr;

        public IdeaProcessManipulator(Point extractButtonPosition)
        {
            _extractButtonPosition = extractButtonPosition;
        }

        public IIdeaProcessManipulator Attach()
        {
            _mainWindow = Application.Attach("idea64")
                                     .Find(title => title.Contains("IntelliJ IDEA"), InitializeOption.WithCache);
            _intPtr = GetDC(IntPtr.Zero);
            _turnedOffPixel = GetPixel(_intPtr, (int)_extractButtonPosition.X, (int)_extractButtonPosition.Y);
            return this;
        }

        public IIdeaProcessManipulator GoToNextDuplicatesGroup(int waitTime = 120)
        {
            Thread.Sleep(waitTime);
            _mainWindow.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
            return this;
        }

        public IIdeaProcessManipulator DoIfExtractIsEnabled(Action action, int waitTime = 2500)
        {
            if (Waiter.WaitWhile(() => GetPixel(_intPtr, (int)_extractButtonPosition.X, (int)_extractButtonPosition.Y) != _turnedOffPixel,
                waitTime, 1200))
            {
                SystemSounds.Beep.Play();
                action();
            }
            return this;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern uint GetPixel(IntPtr dc, int x, int y);
    }
}