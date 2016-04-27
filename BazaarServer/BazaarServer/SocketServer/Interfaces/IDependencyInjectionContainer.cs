using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarServer.SocketServer.Interfaces
{
    public interface IDependencyInjectionContainer
    {
        object GetInstance(Type pluginType);
    }
}
