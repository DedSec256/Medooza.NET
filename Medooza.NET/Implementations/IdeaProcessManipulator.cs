using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
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
        private Application _ideaApp;
        private Window _mainWindow;

        public IdeaProcessManipulator(Point extractButtonPosition)
        {
            _extractButtonPosition = extractButtonPosition;
        }

        public IIdeaProcessManipulator Attach()
        {
            _ideaApp = Application.Attach("idea64");
            _mainWindow = _ideaApp.Find(title => title.Contains("IntelliJ IDEA"), InitializeOption.WithCache);
            return this;
        }

        public IIdeaProcessManipulator GoToNextDuplicatesGroup(int waitTime = 150)
        {
            Thread.Sleep(waitTime);
            _mainWindow.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
            return this;
        }

        public IIdeaProcessManipulator DoIfExtractIsEnabled(Action action, int waitTime = 1500)
        {
            var timer = new Stopwatch();
            timer.Start();
            while (timer.ElapsedMilliseconds < waitTime)
            {
                _mainWindow.Mouse.Click(_extractButtonPosition);
                var extractWindow = _ideaApp.GetWindows().FirstOrDefault(window => window.Title == "Extract method from duplicate code");
                if (extractWindow == null) continue;
                action();
                extractWindow.Close();
                break;
            }
            timer.Stop();
            return this;
        }
    }
}