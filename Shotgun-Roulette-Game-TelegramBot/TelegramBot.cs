using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shotgun_Roulette_Game_TelegramBot
{
    internal class TelegramBot
    {

        private static TelegramBotClient BotClient = null!;
        public static void StartTelegramBot()
        {
            BotClient = new TelegramBotClient("7762140132:AAEU2Iz0juwg80byvemHPyjW_djZu2ycRaQ");
            BotClient?.StartReceiving(updateHandler: HandleUpdate, pollingErrorHandler: HandlePollingError);
        }
        private static async Task HandlePollingError(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            System.IO.File.WriteAllText($"logs\\bot-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt", $"{DateTime.Now}\n{exception.Message}\n\n");
        }
        private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
        {

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                Int64 chatId = update.CallbackQuery.Message.Chat.Id;

                Storage.UserExsistCheckAndWrite(chatId, update.Message.Chat.FirstName, update.Message.Chat.Username);
                Storage.Users[chatId].Messages.Add($"#Click = {update.CallbackQuery.Message}#");
            }
            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                Int64 chatId = update.Message.Chat.Id;
                string massageText = update.Message.Text;

                Storage.UserExsistCheckAndWrite(chatId, update.Message.Chat.FirstName, update.Message.Chat.Username);
                Storage.Users[chatId].Messages.Add(massageText);
            }
            else
            {
                Int64 chatId = update.Message.Chat.Id;

                Storage.UserExsistCheckAndWrite(chatId, update.Message.Chat.FirstName, update.Message.Chat.Username);
                Storage.Users[chatId].Messages.Add("#Wrong_Format_Message#");

                SendMessage(Storage.Users[chatId], "К сожалению, бот не умеет обрабатывать сообщения данного формата, но не переживайте мы его сохраним в реестр сообщений!!!\n\nНапишите /start чтобы пользоваться ботом!");
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
                await BotClient!.SendTextMessageAsync(user.UserId, text);
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
                System.IO.File.WriteAllText($"logs\\bot-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt", $"{DateTime.Now}\n{ex}\n\n");
            }
        }
    }
}
