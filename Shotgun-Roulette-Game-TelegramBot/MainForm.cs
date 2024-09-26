namespace Shotgun_Roulette_Game_TelegramBot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Directory.CreateDirectory("logs");
        }
    }
}