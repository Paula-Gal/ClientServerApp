using Networking;
using Services;
using System;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class SerialServer : ConcurrentServer
    {
        private IServices server;
        private ClientWorker worker;

        public SerialServer(string host, int port, IServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("Server ..." + host + " " + port);
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientWorker(server, client);
            return new Thread(new ThreadStart(worker.Run));
        }
    }
}
