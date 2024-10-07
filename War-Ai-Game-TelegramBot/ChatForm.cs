using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types;

namespace War_Ai_Game_TelegramBot
{
    public partial class ChatForm : Form
    {
        Int64 UserId;
        public ChatForm(long userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (userMessageListBox.Items.Count != Storage.Users[UserId].Messages.Count && Storage.Users[UserId].Messages.Count > userMessageListBox.Items.Count && Storage.Users[UserId].Messages.Count != 0)
            {
                userMessageListBox.Items.Clear();
                foreach (var message in Storage.Users[UserId].Messages)
                    userMessageListBox.Items.Add(message);
            }
        }

        private void clearUserMessagesButton_Click(object sender, EventArgs e)
        {
            Storage.Users[UserId].Messages.Clear();
            userMessageListBox.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            messageTextBox.Text = "";
        }

        private void seeFullMessageButton_Click(object sender, EventArgs e)
        {
            if (userMessageListBox.SelectedItem != null)
                MessageBox.Show(Convert.ToString(userMessageListBox.SelectedItem));
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            botMessageListBox.Items.Add(messageTextBox.Text);
            TelegramBot.SendMessage(Storage.Users[UserId], messageTextBox.Text);
        }
    }
}
