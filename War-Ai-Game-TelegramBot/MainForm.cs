namespace War_Ai_Game_TelegramBot
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
                    if (user.Value.IsInOnlineGame)
                        countUserInOnlineGame++;
                    else if (user.Value.IsInTutorial)
                        countUserInSandbox++;
                    else if (user.Value.IsInSearchGame)
                        countUserInSearchGame++;
                    else if (user.Value.IsBanned)
                        countBannedUsers++;
                    else
                        countOfflineUsers++;
                }
                matchInfoLabel.Text = $"В поиске игры: {countUserInSearchGame}\n" +
                    $"В игре: {countUserInOnlineGame}\n" +
                    $"В обучении: {countUserInSandbox}\n" +
                    $"Не активны: {countOfflineUsers}\n" +
                    $"В бане: {countBannedUsers}\n" +
                    $"\nВсего: {Storage.Users.Count}";
            }

        }

        private void usersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            banUserButton.BackColor = Color.Brown;
            banUserButton.Text = "Заблокировать";
            userIdListBox.Items.Clear();
        }

        private void usersBannedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            banUserButton.BackColor = Color.DarkGreen;
            banUserButton.Text = "Разблокировать";
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
                    TelegramBot.SendMessage(Storage.Users[Convert.ToInt64(userIdListBox.SelectedItem)], "\U0001F6A8Ты *разбанен*!\U00002705");
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

        private void stopAllMatchButton_Click(object sender, EventArgs e)
        {
            foreach (var user in Storage.Users)
            {
                if (user.Value.IsInOnlineGame || user.Value.IsInSearchGame || user.Value.IsInTutorial)
                {
                    user.Value.IsInOnlineGame = false;
                    user.Value.IsInSearchGame = false;
                    user.Value.IsInTutorial = false;
                    for (int i = 0; i < user.Value.BotMessagesId.Count; i++)
                        TelegramBot.DelitMessage(user.Value, user.Value.BotMessagesId[i]);
                    TelegramBot.SendMessage(user.Value, "\U0001F6E0*Матч отменён* из-за технических работ\U0001F6A7");
                    Storage.SaveUsers();
                }
            }
        }

        private void loadInfoButton_Click(object sender, EventArgs e)
        {
            User user = Storage.Users[Convert.ToInt64(userIdListBox.SelectedItem)];
            User enemy = Storage.Users[user.Id];

            infoGroupBox.Text = $"Информация о: {user.Id}";
            infoLabel.Text = $"Заблокирован: {user.IsBanned}\n\n" +
                $"Имя: {user.FirstName}\n" +
                $"@{user.NickName}\n" +
                $"Очки: {user.Points}С\n" +
                $"Прошёл туториал: {user.HasCompletedTutorial}\n";
            if (user.IsInSearchGame)
                infoLabel.Text += "\nИщет игру...";
            else if (user.IsInTutorial)
                infoLabel.Text += "\nВ обучении.";
            else if (user.IsInOnlineGame)
                infoLabel.Text += $"\nВ игре:\n" +
                    $"Противник:\n" +
                    $"id: {enemy.Id}" +
                    $"Имя: {enemy.FirstName}" +
                    $"@{enemy.NickName}" +
                    $"Очки: {enemy.Points}С";
            else
                infoLabel.Text += $"\nБездействует.";
            infoLabel.Visible = true;
        }
    }
}