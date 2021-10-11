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
    public partial class SecRoom : Form
    {
        public static void sendDiscordWebhook(string URL, string profilepic, string username, string message)
        {
            NameValueCollection discordValues = new NameValueCollection();
            discordValues.Add("username", username);
            discordValues.Add("avatar_url", profilepic);
            discordValues.Add("content", message);
            new WebClient().UploadValues(URL, discordValues);
        }
        public SecRoom()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 1)
            {
                this.textBox1.Visible = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string anonuname = this.textBox1.Text;
            Player ply = new Player();
            if (this.comboBox1.SelectedIndex == 1) {
                sendDiscordWebhook("https://discord.com/api/webhooks/897140378392756304/nQtt18aoKrwW3UpW9S70Kpx55zWyMgqJ37UHpCbhtn-QMIiflJaLcP2W-3ubNsrItN3w", "https://freepngimg.com/download/nike/28134-5-nike-logo.png", "Clicking Game Dev", anonuname + " has **" + ply.Coins() + "** Coins and " + ply.Multiplier() + " Multiplier. Feature them!" );
            } else if (comboBox1.SelectedIndex == 0)
            {
                sendDiscordWebhook("https://discord.com/api/webhooks/897140378392756304/nQtt18aoKrwW3UpW9S70Kpx55zWyMgqJ37UHpCbhtn-QMIiflJaLcP2W-3ubNsrItN3w", "https://freepngimg.com/download/nike/28134-5-nike-logo.png", "Clicking Game Dev", "**Anonymous**" + " has **" + ply.Coins() + "** Coins and " + ply.Multiplier() + " Multiplier. Feature them!");
            } else if (comboBox1.SelectedIndex == 2)
            {
                sendDiscordWebhook("https://discord.com/api/webhooks/897140378392756304/nQtt18aoKrwW3UpW9S70Kpx55zWyMgqJ37UHpCbhtn-QMIiflJaLcP2W-3ubNsrItN3w", "https://freepngimg.com/download/nike/28134-5-nike-logo.png", "Clicking Game Dev", Dns.GetHostName() + " has **" + ply.Coins() + "** Coins and " + ply.Multiplier() + " Multiplier. Feature them!");
            }
            await Task.Delay(30000);

        }
    }
}
