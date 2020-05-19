using Autofac;
using ClientSide.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
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
            
            //Application.Run(new ModeSelectionForm());

            // Initializing factory
            FactoryContainer factory = new FactoryContainer();
            var container = factory.Initialize();

            using (var scope = container.BeginLifetimeScope())
            {
                var form = scope.Resolve<ConnectionForm>();
                Application.Run(form);
            }
        }
    }
}
