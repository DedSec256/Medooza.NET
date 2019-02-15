using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using Medooza.NET.Implementations;

namespace Medooza.NET
{
    internal class Program
    {
        private static IKeyboardMouseEvents _mouseClickHooker;
        private static string _filename;

        private static void Main(string[] args)
        {
            _filename = args[0];
            try
            {
                var msgLoop = new ApplicationContext();
                MessageBox.Show($"LeftClick on extract button");
                _mouseClickHooker = Hook.GlobalEvents();
                _mouseClickHooker.MouseClick += _hook_MouseClick;
                Application.Run(msgLoop);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText("error.log", $"{ex.Message}\n{ex.StackTrace}");
            }
        }

        private static void _hook_MouseClick(object sender, MouseEventArgs e)
        {
            _mouseClickHooker.Dispose();

            const int prepareTime = 5;
            MessageBox.Show($"Extract button at {e.Location}\nPrepare for {prepareTime} sec");
            for (var i = 0; i < prepareTime; i++)
            {
                Thread.Sleep(1000);
                SystemSounds.Beep.Play();
            }
            new DataCollector(new System.Windows.Point(e.Location.X, e.Location.Y)).Collect(_filename);
            MessageBox.Show("Data collected");
        }
    }
}
