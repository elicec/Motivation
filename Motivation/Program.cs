using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c")           // Config
                {
                    Application.Run(new SettingsForm());
                }
                else if (firstArgument == "/p")      // Preview
                {
                    // TODO
                    ShowScreenSaver();
                }
                else if (firstArgument == "/s")      // Full-screen
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else    // Undefined
                {
                    MessageBox.Show("Invalid Argument: \"" + firstArgument + "\".", "ScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else    // Run Config when no arguments are available
            {
                //ShowScreenSaver();
                Application.Run(new SettingsForm());
                //Application.Run();
            }
        }
       public static void ShowScreenSaver()
        {
            //int i = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                
                MotivationForm motivation = new MotivationForm(screen.Bounds);
               // if(i == 1)
                motivation.Show();
               // i++;
            }
        }
    }
}
