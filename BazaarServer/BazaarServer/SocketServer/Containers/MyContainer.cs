using BazaarServer.SocketServer.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaarServer.SocketServer.Containers
{
    public class MyContainer : Container, IDependencyInjectionContainer
    {
        public MyContainer(Registry registry): 
            base(registry)
        {

        }

        public MyContainer():
            base()
        {

        }
        
        public MyContainer(Action<ConfigurationExpression> action):
            base(action)
        {

        }

        public MyContainer(PluginGraph pluginGraph):
            base(pluginGraph)
        {

        }
    }
}