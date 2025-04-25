using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.honhathao;
using Guna.UI2.WinForms;
using static System.Net.Mime.MediaTypeNames;

namespace GUI.honhathao.languages
{
    public partial class BotChat : Form
    {

        private string chat;
        private string usern;
        public BotChat(string usern)
        {
            Console.WriteLine(Language.translate("troli"));
            InitializeComponent();
            this.usern = usern;
            chat = (DateTime.Now.ToString("[HH:mm:ss] \n") + "[" + Language.translate("troli") + "] " + Language.translate("helo")+ "\n\n");
            richTextBox1.Text = chat;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private async Task<string> request(string username, string question)
        {
            using (HttpClient client = new HttpClient())
            {

                string n8nWebhookUrl = "https://honhathao10.app.n8n.cloud/webhook/20777478-c497-47a2-bf0b-ed1b05ada1f6";
            
                var payload = new
                {
                    username = username,
                    question = question
                };
                string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

                var response = await client.PostAsync(n8nWebhookUrl, new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json"));
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> SendMessageToBot(string username, string question)
        {
            try
            {
                string botResponse = await request(username, question);
                return botResponse;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message);
                return null;
            }
        }

        private async Task loadMessageAsync()
        {
            guna2Button1.Enabled = false;
            string text = guna2TextBox1.Text;
            guna2TextBox1.Text = "";
            chat += (DateTime.Now.ToString("[HH:mm:ss]\n") + "[User] " + " " + text + "\n\n");
            richTextBox1.Text = chat;

            string answer = await SendMessageToBot(usern, text);
            answer = answer.Replace("\"","");
            answer = answer.Replace("\\n","");
            answer = answer.Replace("}","");
            answer = answer.Replace("{output:", "");
            Console.WriteLine("\'"+answer+"\'");
            chat += (" " + DateTime.Now.ToString("[HH:mm:ss]")+ " " + answer + "\n\n");
            richTextBox1.Text = chat;

            guna2Button1.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadMessageAsync();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                loadMessageAsync();

            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            guna2TextBox1.Focus();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}