namespace Shotgun_Roulette_Game_TelegramBot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void openChatButton_Click(object sender, EventArgs e)
        {
            if (userIdListBox.SelectedItem != null)
            {
                ChatForm chatForm = new ChatForm(Convert.ToInt64(userIdListBox.SelectedItem));
                chatForm.Show();
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (Storage.Users.Count > 0)
            {
                if (usersRadioButton.Checked)
                {
                    foreach (var user in Storage.Users)
                    {
                        if (!userIdListBox.Items.Contains(user.Key))
                            userIdListBox.Items.Add(user.Key);
                    }
                }
                if (usersBannedRadioButton.Checked)
                {
                    foreach (var user in Storage.Users)
                    {
                        if (user.Value.IsBanned)
                            if (!userIdListBox.Items.Contains(user.Key))
                                userIdListBox.Items.Add(user.Key);
                    }
                }
                int countUserInOnlineGame = 0;
                int countUserInSandbox = 0;
                int countUserInSearchGame = 0;
                int countOfflineUsers = 0;
                int countBannedUsers = 0;

                foreach (var user in Storage.Users)
                {
                    if (user.Value.InOnlineGame)
                        countUserInOnlineGame++;
                    else if (user.Value.InSandbox)
                        countUserInSandbox++;
                    else if (user.Value.InSearchGame)
                        countUserInSearchGame++;
                    else if (user.Value.IsBanned)
                        countBannedUsers++;
                    else
                        countOfflineUsers++;
                }
                matchInfoLabel.Text = $"� ������ ����: {countUserInSearchGame}\n" +
                    $"� ����: {countUserInOnlineGame}\n" +
                    $"� ���������: {countUserInSandbox}\n" +
                    $"�� �������: {countOfflineUsers}\n" +
                    $"� ����: {countBannedUsers}\n" +
                    $"\n�����: {Storage.Users.Count}";
            }

        }

        private void usersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            banUserButton.BackColor = Color.Brown;
            banUserButton.Text = "�������������";
            userIdListBox.Items.Clear();
        }

        private void usersBannedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            banUserButton.BackColor = Color.DarkGreen;
            banUserButton.Text = "��������������";
            userIdListBox.Items.Clear();
        }

        private void banUserButton_Click(object sender, EventArgs e)
        {
            if (usersRadioButton.Checked)
                if (userIdListBox.SelectedItem != null)
                {
                    Storage.Users[Convert.ToInt64(userIdListBox.SelectedItem)].IsBanned = true;
                }
            if (usersBannedRadioButton.Checked)
                if (userIdListBox.SelectedItem != null)
                {
                    Storage.Users[Convert.ToInt64(userIdListBox.SelectedItem)].IsBanned = false;
                    TelegramBot.SendMessage(Storage.Users[Convert.ToInt64(userIdListBox.SelectedItem)], "\U0001F6A8�� *��������*!\U00002705");
                }
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {
            Storage.SaveUsers();
        }

        private void clearMessageDBButton_Click(object sender, EventArgs e)
        {
            foreach (var user in Storage.Users)
            {
                user.Value.Messages.Clear();
            }
        
        }
    }
}