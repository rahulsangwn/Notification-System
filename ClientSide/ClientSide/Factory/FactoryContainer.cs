using Autofac;
using ClientSide.Data;
using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            builder.RegisterType<ConnectionForm>();
            builder.RegisterType<NotificationForm>();
            builder.RegisterType<ModeSelectionForm>();
            builder.RegisterType<ClientSocket>().As<IClientSocket>().SingleInstance();
            builder.RegisterType<SocketManager>().As<ISocketManager>().SingleInstance();
            builder.RegisterType<DataExtraction>().As<IDataExtraction>().SingleInstance();

            Container = builder.Build();

            return Container;
        }

    }
}
