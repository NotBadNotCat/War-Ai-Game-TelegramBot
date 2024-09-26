using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shotgun_Roulette_Game_TelegramBot
{
    internal class TelegramBot
    {

        private static TelegramBotClient? BotClient;
        public static void StartTelegramBot()
        {
            BotClient = new TelegramBotClient("5444454");
            BotClient?.StartReceiving(updateHandler: HandleUpdate, pollingErrorHandler: HandlePollingError);
        }
        private static async Task HandlePollingError(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            System.IO.File.WriteAllText($"logs\\bot-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt", $"{DateTime.Now}\n{exception.Message}\n\n");
        }
        private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                
            }
            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                
            }
            else
            {

            }
        }
        public enum MessageId
        {
            None = 0,
            Save = 1
        }
        public async static void SendMessage(User user, string text, MessageId messageId = MessageId.None)
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText($"logs\\bot-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt", $"{DateTime.Now}\n{ex}\n\n");
            }
        }
        public async static void EditMessage(User user, int messageId, string text)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }
        public async static void DelitMessage(User user, int messageId, string text)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }
    }
}
