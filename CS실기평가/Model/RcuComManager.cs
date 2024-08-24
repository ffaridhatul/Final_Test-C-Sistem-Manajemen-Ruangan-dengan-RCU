using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public class RcuComManager
    {
        public delegate void RcuPacketHandler(RcuPacket rcuPacket);
        public event RcuPacketHandler RcuPacketArrived;

        private Socket ServerSocket;

        public RcuComManager(int port)
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint sendPoint = new IPEndPoint(IPAddress.Any, 9999);
            ServerSocket.Bind(sendPoint);
            ServerSocket.Listen(10);
        }

        public void Start()
        {
            AcceptClient();
        }

        private void AcceptClient()
        {
            SocketAsyncEventArgs args1 = new SocketAsyncEventArgs();
            args1.Completed += AcceptFromServer;
            ServerSocket.AcceptAsync(args1);
        }

        private void AcceptFromServer(object sender, SocketAsyncEventArgs e)
        {
            ReceivePacket(e.AcceptSocket);
            AcceptClient();
        }

        private void ReceivePacket(Socket socket)
        {
            SocketAsyncEventArgs args1 = new SocketAsyncEventArgs();
            args1.SetBuffer(new byte[1024], 0, 1024);
            args1.AcceptSocket = socket;
            args1.Completed += PacketArrived;
            socket.ReceiveAsync(args1);
        }

        private void PacketArrived(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                byte[] buffer = new byte[e.BytesTransferred];
                Array.Copy(e.Buffer, buffer, buffer.Length);

                ProcessPacket(buffer);

                ReceivePacket(e.AcceptSocket);
            }
        }

        private void ProcessPacket(byte[] bytes)
        {
            string packetStr = Encoding.Default.GetString(bytes);
            var packet = JsonConvert.DeserializeObject<RcuPacket>(packetStr);

            RcuPacketArrived?.Invoke(packet);
        }
    }
}
