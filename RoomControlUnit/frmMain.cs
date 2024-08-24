using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RoomControlUnit
{
    public partial class frmMain : Form
    {
        Socket ClientSocket;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var args = new SocketAsyncEventArgs();
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint sendPoint = new IPEndPoint(IPAddress.Any, 9999);
            args.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), Convert.ToInt32(txtPortNo.Text));
            args.Completed += Connected;
            ClientSocket.ConnectAsync(args);
        }

        private void Connected(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                DisplayMessage("Anda terhubung ke server penerima.");
                this.Invoke(new Action(() => { btnConnect.Enabled = false; }));
            }
            else
            {
                DisplayMessage("Tidak dapat terhubung ke server penerima.");
            }
        }

        private void DisplayMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { DisplayMessage(message); }));
            }
            else
            {
                lblMessage.Text = message;
            }
        }

        private void tmrSend_Tick(object sender, EventArgs e)
        {
            int temperature = new Random().Next(18, 30);

            lblTemperature.Text = temperature.ToString();

            if (ClientSocket != null && ClientSocket.Connected)
            {
                KeyStatusEnum keyStatus;

                if (rdoGuestKey.Checked)
                    keyStatus = KeyStatusEnum.GuestKey;
                else if(rdoMasterKey.Checked)
                    keyStatus = KeyStatusEnum.MasterKey; 
                else
                    keyStatus = KeyStatusEnum.Empty;

                var packet = new RcuPacket
                {
                    RcuId = (int)numRcuId.Value,
                    Temperature = temperature,
                    DoorStatus = rdoOpen.Checked ? DoorStatusEnum.Opened : DoorStatusEnum.Closed,
                    KeyStatus = keyStatus
                };

                string json = JsonConvert.SerializeObject(packet);
                byte[] bytesToSend = Encoding.Default.GetBytes(json);

                var args = new SocketAsyncEventArgs();
                args.SetBuffer(bytesToSend, 0, bytesToSend.Length);
                args.Completed += SendCompleted;
                ClientSocket.SendAsync(args);
            }
        }

        private void SendCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                DisplayMessage($"[{DateTime.Now.ToString("HH:mm:ss")}] Data Anda telah berhasil ditransfer.");
            }
            else
            {
                DisplayMessage($"[{DateTime.Now.ToString("HH:mm:ss")}] Transmisi data gagal.");
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
