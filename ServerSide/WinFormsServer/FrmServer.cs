﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.AspNet.SignalR;
using System.ComponentModel;
using System.Collections.Generic;

namespace WinFormsServer
{
    public partial class FrmServer : Form
    {
        private IDisposable _signalR;

        public static BindingList<ClientItem> clients = new BindingList<ClientItem>();
        public static BindingList<string> groups = new BindingList<string>();

        public static Queue<string> usersInPool = new Queue<string>();

        public static Dictionary<int, XOGameData> games = new Dictionary<int, XOGameData>();

        public FrmServer()
        {
            InitializeComponent();

            bindListsToControls();

            //Register to static hub events
            SimpleHub.ClientConnected += SimpleHub_ClientConnected;
            SimpleHub.ClientDisconnected += SimpleHub_ClientDisconnected;
            SimpleHub.ClientNameChanged += SimpleHub_ClientNameChanged;
            SimpleHub.ClientJoinedToGroup += SimpleHub_ClientJoinedToGroup;
            SimpleHub.ClientLeftGroup += SimpleHub_ClientLeftGroup;
            SimpleHub.MessageReceived += SimpleHub_MessageReceived;
            SimpleHub.PlayerJoinedGame += SimpleHub_PlayerJoinedGame;
            SimpleHub.GameAction += SimpleHub_GameAction;
        }

        private void SimpleHub_GameAction(int index,Marks marker)
        {
            writeToLog($"Client Did Action In Index : {index} and Marked It With : {marker}");
        }

        private void SimpleHub_PlayerJoinedGame(string playerName)
        {
            writeToLog($"Client Joined To Pool Name : {playerName}");
        }

        private void bindListsToControls()
        {
            //Clients list
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "Id";
            cmbClients.DataSource = clients;

            //Groups list
            cmbGroups.DataSource = groups;
        }

        private void SimpleHub_ClientConnected(string clientId)
        {
            //Add client to our clients list
            this.BeginInvoke(new Action(() => clients.Add(new ClientItem() { Id = clientId, Name = clientId })));

            writeToLog($"Client connected:{clientId}");
        }

        private void SimpleHub_ClientDisconnected(string clientId)
        {
            //Remove client from the list
            this.BeginInvoke(new Action(() =>
            {
                var client = clients.FirstOrDefault(x => x.Id == clientId);
                if (client != null)
                    clients.Remove(client);
            }));

            writeToLog($"Client disconnected:{clientId}");
        }

        private void SimpleHub_ClientNameChanged(string clientId, string newName)
        {
            //Update the client's name if it exists
            this.BeginInvoke(new Action(() =>
            {
                var client = clients.FirstOrDefault(x => x.Id == clientId);
                if (client != null)
                    client.Name = newName;
            }));

            writeToLog($"Client name changed. Id:{clientId}, Name:{newName}");
        }

        private void SimpleHub_ClientJoinedToGroup(string clientId, string groupName)
        {
            //Only add the groups name to our groups list
            this.BeginInvoke(new Action(() =>
            {
                var group = groups.FirstOrDefault(x => x == groupName);
                if (group == null)
                    groups.Add(groupName);
            }));

            writeToLog($"Client joined to group. Id:{clientId}, Group:{groupName}");
        }

        private void SimpleHub_ClientLeftGroup(string clientId, string groupName)
        {
            writeToLog($"Client left group. Id:{clientId}, Group:{groupName}");
        }

        private void SimpleHub_MessageReceived(string senderClientId, string message)
        {
            //One of the clients sent a message, log it
            this.BeginInvoke(new Action(() =>
            {
                string clientName = clients.FirstOrDefault(x => x.Id == senderClientId)?.Name;

                writeToLog($"{clientName}:{message}");
            }));
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            try
            {
                //Start SignalR server with the give URL address
                //Final server address will be "URL/signalr"
                //Startup.Configuration is called automatically
                _signalR = WebApp.Start<Startup>(txtUrl.Text);

                btnStartServer.Enabled = false;
                txtUrl.Enabled = false;
                btnStop.Enabled = true;
                grpBroadcast.Enabled = true;

                writeToLog($"Server started at:{txtUrl.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            clients.Clear();
            groups.Clear();

            SimpleHub.ClearState();

            if (_signalR != null)
            {
                _signalR.Dispose();
                _signalR = null;

                btnStop.Enabled = false;
                btnStartServer.Enabled = true;
                txtUrl.Enabled = true;
                grpBroadcast.Enabled = false;

                writeToLog("Server stopped.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();

            if (rdToAll.Checked)
            {
                hubContext.Clients.All.addMessage("SERVER", txtMessage.Text);
            }
            else if (rdToGroup.Checked)
            {
                hubContext.Clients.Group(cmbGroups.Text).addMessage("SERVER", txtMessage.Text);
            }
            else if (rdToClient.Checked)
            {
                hubContext.Clients.Client((string)cmbClients.SelectedValue).addMessage("SERVER", txtMessage.Text);
            }
        }

        private void writeToLog(string log)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new Action(() => txtLog.AppendText(log + Environment.NewLine)));
            else
                txtLog.AppendText(log + Environment.NewLine);
        }
    }
}
