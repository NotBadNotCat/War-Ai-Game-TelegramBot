﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery && update.CallbackQuery!.Data != null)
            {
                Int64 chatId = update.CallbackQuery.Message!.Chat.Id;

                Storage.UserExsistCheckAndWrite(chatId, update.CallbackQuery.From.FirstName, update.CallbackQuery.From.Username!);

                if (Storage.Users[chatId].IsBanned)
                {
                    SendMessage(Storage.Users[chatId], "\U0001F6A8Ты *забанен*!\U0001F6AB");
                }
                else
                {
                    Storage.Users[chatId].Messages.Add($"#Click = {update.CallbackQuery.Data}#");

                    if (Storage.Users[chatId].InSearchGame)
                    {
                        if (update.CallbackQuery.Data == "StopSearch")
                        { 
                            Storage.Users[chatId].InSearchGame = false;
                            EditMessage(Storage.Users[chatId], Storage.Users[chatId].BotMessagesId[Storage.Users[chatId].BotMessagesId.Count - 1],
                                "\U0000274E*Поиск отменён!*\nВведите /start");
                            Storage.Users[chatId].BotMessagesId.RemoveAt(Storage.Users[chatId].BotMessagesId.Count - 1);
                        }
                    }
                    else if (Storage.Users[chatId].InOnlineGame)
                    {

                    }
                    else if (Storage.Users[chatId].InSandbox)
                    {

                    }
                    else
                    {
                        string messageText = "";
                        switch (update.CallbackQuery.Data)
                        {
                            case "/game":
                                messageText = update.CallbackQuery.Data; SendMessage(Storage.Users[chatId], Storage.GetAnswerToMessage(messageText, userId: chatId), replyMarkup: Storage.GetKeyboardMarkup(messageText)); break;
                            case "/rules":
                                messageText = update.CallbackQuery.Data; SendMessage(Storage.Users[chatId], Storage.GetAnswerToMessage(messageText, userId: chatId), replyMarkup: Storage.GetKeyboardMarkup(messageText)); break;
                            case "/search":
                                messageText = update.CallbackQuery.Data; SendMessage(Storage.Users[chatId], Storage.GetAnswerToMessage(messageText, userId: chatId), replyMarkup: Storage.GetKeyboardMarkup(messageText)); break;
                            case "StartSearch":
                                {
                                    SendMessage(Storage.Users[chatId], "\U0000231B*Идёт поиск игроков!*\U0001F50D\n" +
                                        "_Если вы хотите отменить поиск, то воспользуйтесь_ */stop* " +
                                        "_или нажмите_ *кнопку* _ниже_.",
                                        replyMarkup: Storage.GetKeyboardMarkup(update.CallbackQuery.Data), saveMessageToBotMessageIdList: true);
                                    StartSearch(Storage.Users[chatId]);
                                    break;
                                }
                            default:
                                SendMessage(Storage.Users[chatId], "А?"); break;
                        }
                    }

                }
            }
            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message && update.Message.Text != null)
            {
                Int64 chatId = update.Message.Chat.Id;

                bool isNewUser = !Storage.UserExsistCheckAndWrite(chatId, update.Message.From.FirstName, update.Message.From.Username);

                if (Storage.Users[chatId].IsBanned)
                {
                    SendMessage(Storage.Users[chatId], "\U0001F6A8Ты *забанен*!\U0001F6AB");
                }
                else
                {
                    string messageText = update.Message.Text;

                    Storage.Users[chatId].Messages.Add(messageText);

                    if (Storage.Users[chatId].InSearchGame)
                    {
                        if (messageText == "/stop")
                        {
                            Storage.Users[chatId].InSearchGame = false;
                            EditMessage(Storage.Users[chatId], Storage.Users[chatId].BotMessagesId[Storage.Users[chatId].BotMessagesId.Count - 1],
                                "\U0000274E*Поиск отменён!*\nВведите /start");
                            Storage.Users[chatId].BotMessagesId.RemoveAt(Storage.Users[chatId].BotMessagesId.Count - 1);
                        }
                    }
                    else if (Storage.Users[chatId].InOnlineGame)
                    {

                    }
                    else if (Storage.Users[chatId].InSandbox)
                    {

                    }
                    else
                    {
                        SendMessage(Storage.Users[chatId], Storage.GetAnswerToMessage(messageText, isNewUser, userId: chatId), replyMarkup: Storage.GetKeyboardMarkup(messageText, isNewUser));
                    }
                }
            }
            else
            {
                Int64 chatId = update.Message.Chat.Id;

                Storage.UserExsistCheckAndWrite(chatId, update.Message.From.FirstName, update.Message.From.Username);
                Storage.Users[chatId].Messages.Add("#Wrong_Format_Message#");

                SendMessage(Storage.Users[chatId], "\U000026D4_К сожалению, бот " +
                    "не умеет обрабатывать сообщения данного формата, " +
                    "но не переживайте мы его сохраним в реестр сообщений_*!!!*\n\n" +
                    "Напишите */start* чтобы пользоваться ботом*!*");
            }
        }

        private static void StartSearch(User user)
        {
            user.InSearchGame = true;

            foreach (var enemy in Storage.Users)
                if (enemy.Value.Id != user.Id && enemy.Value.InSearchGame)
                {
                    user.InOnlineGame = true;
                    enemy.Value.InOnlineGame = true;
                    enemy.Value.InSearchGame = false;
                    user.InSearchGame = false;
                    EditMessage(enemy.Value, enemy.Value.BotMessagesId[enemy.Value.BotMessagesId.Count - 1],
                        $"*\U00002694Противник найден!*\n" +
                        $"_Ваш противник:_ *{user.NickName}*\n" +
                        $"_Рейтинг противника:_ _{user.Points}_*C*.");
                    EditMessage(user, user.BotMessagesId[user.BotMessagesId.Count - 1],
                        $"*\U00002694Противник найден!*\n" +
                        $"_Ваш противник:_ *{enemy.Value.NickName}*\n" +
                        $"_Рейтинг противника:_ _{enemy.Value.Points}_*C*.");
                    user.ReloadGamePoint();
                    enemy.Value.ReloadGamePoint();
                }
        }

        public async static void SendMessage(User user, string text, InlineKeyboardMarkup replyMarkup = null!, bool saveMessageToBotMessageIdList = false)
        {
            try
            {
                Telegram.Bot.Types.Message message = await BotClient!.SendTextMessageAsync(user.Id, text, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, disableWebPagePreview: true, replyMarkup: replyMarkup);
                if (saveMessageToBotMessageIdList)
                    Storage.Users[user.Id].BotMessagesId.Add(message.MessageId);

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
                await BotClient!.EditMessageTextAsync(user.Id, messageId, text, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            }
            catch (Exception ex)
            {
            }
        }
        public async static void DelitMessage(User user, int messageId)
        {
            try
            {
                await BotClient!.DeleteMessageAsync(user.Id, messageId);
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText($"logs\\bot-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt", $"{DateTime.Now}\n{ex}\n\n");
            }
        }
    }
}
