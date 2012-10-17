using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainApplication.Component;

namespace MainApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (MainGame game = new MainGame())
            {
                game.Form.Size = new System.Drawing.Size(1024, 768);
                game.Form.StartPosition = FormStartPosition.CenterScreen;
                game.Run();
            }
        }
    }
}
