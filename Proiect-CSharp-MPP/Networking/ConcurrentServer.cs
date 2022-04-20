using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking
{
    public abstract class ConcurrentServer : AbstractServer
    {
        public ConcurrentServer(string host, int port) : base(host, port) { }
        public override void ProcessRequest(TcpClient client)
        {
            Thread thread = createWorker(client);
            thread.Start();
        }

        protected abstract Thread createWorker(TcpClient client);
    }
}
