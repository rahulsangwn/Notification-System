using ServerUI.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUI
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
            // Start Listening to incoming Connection
            //ServerSocket server = new ServerSocket();
            //server.ConnectionListner();
            Application.Run(new Emitter());

        }
    }
}
