using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clicking_game
{
    public partial class Bugs : Form
    {

        public static void sendDiscordWebhook(string URL, string profilepic, string username, string message)
        {
            NameValueCollection discordValues = new NameValueCollection();
            discordValues.Add("username", username);
            discordValues.Add("avatar_url", profilepic);
            discordValues.Add("content", message);
            new WebClient().UploadValues(URL, discordValues);
        }
        public Bugs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendDiscordWebhook("https://discord.com/api/webhooks/897142527310852097/b8EnHkw0KMoN1jEwTeNee8k5logItwy0orCkrvpKOEgvcPqbZ5Xo9py7J_t--ziXgD5V", "https://freepngimg.com/download/nike/28134-5-nike-logo.png", "Clicking Game Dev", "Bug Report: " + this.textBox1.Text);
        }
    }
}
