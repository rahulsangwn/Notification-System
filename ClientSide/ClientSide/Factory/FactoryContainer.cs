using Autofac;
using ClientSide.Data;
using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Factory
{
    public class FactoryContainer
    {
        public static IContainer Container { get; set; }
        public IContainer Initialize()
        {
            // Create a container builder
            var builder = new ContainerBuilder();

            builder.RegisterType<ClientSocket>().SingleInstance();
            builder.RegisterType<ConnectionForm>();
            builder.RegisterType<NotificationForm>();
            builder.RegisterType<ModeSelectionForm>();
            builder.RegisterType<SocketManager>().SingleInstance();
            builder.RegisterType<DataExtraction>().SingleInstance();
            Container = builder.Build();
            return Container;
        }

    }
}
