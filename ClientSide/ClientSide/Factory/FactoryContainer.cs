﻿using Autofac;
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
            builder.RegisterType<SocketManager>();
            Container = builder.Build();
            return Container;
        }

    }
}