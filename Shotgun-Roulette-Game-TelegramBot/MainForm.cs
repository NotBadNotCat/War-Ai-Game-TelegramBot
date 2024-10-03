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
    }
}