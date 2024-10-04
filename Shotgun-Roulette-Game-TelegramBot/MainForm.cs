namespace Shotgun_Roulette_Game_TelegramBot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TelegramBot.StartTelegramBot();
            Directory.CreateDirectory("logs");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void openChatButton_Click(object sender, EventArgs e)
        {

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (Storage.Users.Count > 0)
            {
                if (userIdListBox.Items.Count != Storage.Users.Count)
                {
                    userIdListBox.Items.Clear();
                    foreach (var user in Storage.Users)
                    {
                        userIdListBox.Items.Add(user.Key);
                    }
                }
                int countUserInOnlineGame = 0;
                int countUserInSandbox = 0;
                int countUserInSearchGame = 0;
                int countOfflineUser = 0;

                foreach (var user in Storage.Users)
                {
                    if(user.Value.InOnlineGame)
                        countUserInOnlineGame++;
                    else if(user.Value.InSandbox)
                        countUserInSandbox++;
                    else if(user.Value.InSearchGame)
                        countUserInSearchGame++;
                    else
                        countOfflineUser++;
                }
                matchInfoLabel.Text = $"В поиске игры: {countUserInSearchGame}\n" +
                    $"В игре: {countUserInOnlineGame}\n" +
                    $"В песочнице: {countUserInSandbox}\n" +
                    $"Не активны: {countOfflineUser}\n" +
                    $"\nВсего: {Storage.Users.Count}";
            }

        }
    }
}