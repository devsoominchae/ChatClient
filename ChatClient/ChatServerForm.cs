using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using static ChatClient.ChatClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatClient
{


    public partial class ChatClient : Form
    {
        public class Message
        {
            public int sender_json { get; set; }
            public int recipient_json { get; set; }
            public string message_json { get; set; }
        }

        TcpClient client_socket = new();
        int client_port;
        private readonly HttpClient httpClient = new HttpClient();
        bool client_thread_bool = false;

        public ChatClient()
        {
            InitializeComponent();
            SendTextBox.KeyDown += SendTextBox_KeyDown;
            ConnectedClientComboBox.DropDown += ConnectedClientComboBox_DropDown;
        }

        private void UpdateCurrentChatTextBox(string message)
        {
            if (CurrentChatTextBox.InvokeRequired)
            {
                CurrentChatTextBox.Invoke(new Action<string>(UpdateCurrentChatTextBox), message);
            }
            else
            {
                message += "\r\n";
                CurrentChatTextBox.Text += message;
            }
        }

        public string CreateJsonMessage(int sender, int recipient, string message_text)
        {
            Message message = new Message
            {
                sender_json = sender,
                recipient_json = recipient,
                message_json = message_text
            };

            return JsonConvert.SerializeObject(message);
        }

        public Message ParseJsonMessage(string json)
        {
            return JsonConvert.DeserializeObject<Message>(json);
        }

        void ReceiveMessages(TcpClient client_socket)
        {
            NetworkStream network_stream = client_socket.GetStream();
            while (client_thread_bool)
            {
                try
                {
                    byte[] bytes_from = new byte[client_socket.ReceiveBufferSize];
                    network_stream.Read(bytes_from, 0, client_socket.ReceiveBufferSize);
                    string data_from_server = Encoding.ASCII.GetString(bytes_from);
                    data_from_server = data_from_server.TrimEnd('\0');
                    if (data_from_server != "")
                    {
                        Message received_message = ParseJsonMessage(data_from_server);

                        int sender_id = received_message.sender_json;
                        int recipient_id = received_message.recipient_json;
                        string parsed_mesage = received_message.message_json;
                        if (parsed_mesage == "DISCONNECT")
                        {
                            client_socket.Close();
                            break;
                        }
                        UpdateCurrentChatTextBox(sender_id + " : " + parsed_mesage);
                    }

                }
                catch (Exception e)
                {
                    UpdateCurrentChatTextBox("Error: " + e.Message);
                    break;
                }
            }
            UpdateCurrentChatTextBox("Client disconnected.");
        }

        private void ClientConnectButton_Click(object sender, EventArgs e)
        {
            client_socket = new();
            try
            {
                client_socket.Connect(IPAddressTextBox.Text, int.Parse(PortTextBox.Text));
            }
            catch
            {
                UpdateCurrentChatTextBox("Unable to connect");
                return;
            }

            client_thread_bool = true;
            Thread receive_thread = new(() => ReceiveMessages(client_socket));
            receive_thread.Start();

            UpdateCurrentChatTextBox("Connected to server.");
        }

        public List<int> ParseClientIdsString(string client_ids_string)
        {
            List<int> client_ids = new List<int>();

            if (!string.IsNullOrEmpty(client_ids_string))
            {
                string[] id_strings = client_ids_string.Split(',');
                foreach (string id_string in id_strings)
                {
                    if (int.TryParse(id_string, out int client_id))
                    {
                        client_ids.Add(client_id);
                    }
                }
            }
            else
            {
                Console.WriteLine("Client IDs string is null or empty.");
            }

            return client_ids;
        }

        private void SendMessage()
        {
            // Code to send the message
            StreamWriter writer = new StreamWriter(client_socket.GetStream());
            IPEndPoint client_end_point = (IPEndPoint)client_socket.Client.LocalEndPoint;
            int sender_port = client_end_point.Port;
            string json_message_to_send = CreateJsonMessage(sender_port, int.Parse(ConnectedClientComboBox.Text), SendTextBox.Text);
            writer.WriteLine(json_message_to_send + "\n");
            writer.Flush();

            SendTextBox.Text = "";
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the Enter key from being inserted into the TextBox
                e.SuppressKeyPress = true;

                // Execute the action for sending the message
                SendMessage();
            }
        }

        private void ConnectedClientComboBox_DropDown(object sender, EventArgs e)
        {
            // Update the content of the combo box when the user opens it
            string connected_clients_json = GetConnectedClients();
            List<int> client_list = ParseConnectedJson(connected_clients_json);
            UpdateConnectedClientComboBox(client_list);
        }

        private void UpdateConnectedClientComboBox(List<int> client_list)
        {
            ConnectedClientComboBox.Items.Clear();
            foreach (var port in client_list)
            {
                ConnectedClientComboBox.Items.Add(port); ;
            }
        }

        private List<int> ParseConnectedJson(string connected_clients_json)
        {
            var json_document = JsonDocument.Parse(connected_clients_json);
            var root = json_document.RootElement;

            var value_array = root.GetProperty("value").EnumerateArray();
            List<int> ports = new();

            foreach (var item in value_array)
            {
                // Get "port" property value
                var port = item.GetProperty("port").GetInt32();
                ports.Add(port);
            }

            return ports;
        }

        private string GetConnectedClients()
        {
            HttpClient client = new();
            string api_url = "https://localhost:8080/GetAll";
            string json_response = "";

            HttpResponseMessage response = client.GetAsync(api_url).Result;
            if (response.IsSuccessStatusCode)
            {
                json_response = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                UpdateCurrentChatTextBox($"Error: {response.StatusCode}");
            }

            return json_response;
        }

        private void DisconnectClientButton_Click(object sender, EventArgs e)
        {
            client_thread_bool = false;

            SendTextBox.Text = "DISCONNECT";
            ConnectedClientComboBox.Text = "8888";
            SendMessage();
            ConnectedClientComboBox.Text = "";
            UpdateCurrentChatTextBox("Client disconnected.");
        }
    }
}
