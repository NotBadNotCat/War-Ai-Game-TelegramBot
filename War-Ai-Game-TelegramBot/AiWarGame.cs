using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace War_Ai_Game_TelegramBot
{
    internal class AiWarGame
    {
        public static void Game(User user, string сallbackQueryData)
        {
            switch (сallbackQueryData)
            {
                case "Empty":
                    SendChoiceMessage(user);
                    break;
                case "EmptyFile":
                    Storage.Users[user.EnemyId].FileDamage = 0;
                    SendChoiceMessage(user, "\U00002705Вы подменили вирусные файлы противника пустыми фалами\n\n");
                    user.FileExtensions.Remove(сallbackQueryData);
                    break;
                case "Antivirus":
                    {
                        if (user.FileDamage == 1)
                            SendChoiceMessage(user, "\U0000274CАнтивирус *ничего не выявил*!\n\n");
                        else if (user.FileDamage == 0)
                        {
                            SendChoiceMessage(user, "\U00002796Антивирус *нашёл пустые файлы и удалил их*!\n\n");
                            user.FileDamage = 1;
                        }
                        else if (user.FileDamage == -1 || user.FileDamage == -2)
                        {
                            SendChoiceMessage(user, "\U00002705Антивирус *нашёл шифровщика с кодом*! Расшифровав, вы получаете ещё один сервер.\n\n"); user.FileDamage = 1;
                            user.HealthPoints += 1;
                            ReloadServerCount(user);
                        }
                        else
                        {
                        }
                        user.FileExtensions.Remove(сallbackQueryData);
                        break;
                    }
                case "EncryptionVirus":
                    {
                        Storage.Users[user.EnemyId].FileDamage = -1;
                        user.FileExtensions.Remove(сallbackQueryData);
                        SendChoiceMessage(user, "\U00002705Вы подкинули шифровщик противнику! Если он его не найдёт, то следующим ходом он отправит вам данные о секретных серверах!\n\n");
                        break;
                    }
                case "Diagnostics":
                    {
                        user.HealthPoints += 1;
                        ReloadServerCount(user);
                        user.FileExtensions.Remove(сallbackQueryData);
                        SendChoiceMessage(user, "\U00002705Вы провели устранение неполадок на одном из ваших старых серверов и он вернулся в строй!\n\n");
                        break;
                    }
                case "DoubleSending":
                    {
                        user.FileDamage *= 2;
                        user.FileExtensions.Remove(сallbackQueryData);
                        SendChoiceMessage(user, "\U00002705Количество отправляемых файлов увеличено в 2 раза!\n\n");
                        break;
                    }
                case "SendYourself":
                    {
                        user.HealthPoints -= user.FileDamage;
                        if (user.HealthPoints > 0)
                        {
                            TelegramBot.EditMessage(user, user.BotMessagesId[user.BotMessagesId.Count - 1],
                                "\U0000274CВы отправили себе вирус!\n\n" +
                                "\U0001F4C2*Куда отправить файл?*\U000023E9", 
                                replyMarkup: Storage.GetKeyboardMarkup("FileSendСhoice"));
                        }
                        if (user.FileDamage == 0)
                        {
                            TelegramBot.EditMessage(user, user.BotMessagesId[user.BotMessagesId.Count - 1],
                                "\U00002705Вы обнаружили пустой файл!\n\n" +
                                "\U0001F4C2*Куда отправить файл?*\U000023E9", 
                                replyMarkup: Storage.GetKeyboardMarkup("FileSendСhoice"));
                        }
                        else if (user.FileDamage == -1 || user.FileDamage == -2)
                        {
                            TelegramBot.EditMessage(user, user.BotMessagesId[user.BotMessagesId.Count - 1],
                                "\U00002705Вы шифровщик обнаружили !\n\n" +
                                "\U0001F4C2*Куда отправить файл?*\U000023E9", 
                                replyMarkup: Storage.GetKeyboardMarkup("FileSendСhoice"));
                        }
                        

                        if (user.HealthPoints <= 0)
                        {
                            Storage.Users[user.EnemyId].Score += (Storage.Users[user.EnemyId].HealthPoints * 3);
                            WinGame(Storage.Users[user.EnemyId], user);
                        }
                        else
                        {
                            user.FileDamage = 1;
                            ReloadServerCount(user);
                        }
                        break;
                    }
                case "SendEnemy":
                    {
                        Storage.Users[user.EnemyId].HealthPoints -= user.FileDamage;
                        if (Storage.Users[user.EnemyId].HealthPoints <= 0)
                        {
                            user.Score += (user.HealthPoints * 3);
                            WinGame(user, Storage.Users[user.EnemyId]);
                        }
                        else
                        {
                            user.FileDamage = 1;
                            ReloadServerCount(user);
                            MoveTransition(user, Storage.Users[user.EnemyId]);
                        }
                        break;
                    }

            }
        }
        public static void MoveTransition(User fromUser, User toUser)
        {
            fromUser.IsPlayerMove = false;
            toUser.IsPlayerMove = true;
            TelegramBot.DelitMessage(fromUser, fromUser.BotMessagesId[fromUser.BotMessagesId.Count - 1]);
            fromUser.BotMessagesId.RemoveAt(fromUser.BotMessagesId.Count - 1);
            TelegramBot.DelitMessage(toUser, toUser.BotMessagesId[toUser.BotMessagesId.Count - 1]);
            toUser.BotMessagesId.RemoveAt(toUser.BotMessagesId.Count - 1);
            toUser.LastMoveTime = DateTime.Now;
            TelegramBot.SendMessage(fromUser,
                $"*Сейчас ход противника!*\n" +
                $"Если он ходит дольше 20 секунд, то вы можете пропустить его ход командой:" +
                $"\n*/skip*\n_Но учтите, он что-то мог успеть сделать с файлами!_",
                saveMessageToBotMessageIdList: true);
            TelegramBot.SendMessage(toUser,
                $"*Выбирите файл для отправки:*",
                saveMessageToBotMessageIdList: true, replyMarkup: GetSetOfCards(toUser));
        }
        private static void ReloadServerCount(User user)
        {
            string userEmoji = "\U0001F4BE", enemyEmoji = "\U0001F4BE";
            if (user.HealthPoints == 1)
                userEmoji = "\U0001F6A8";
            if (user.HealthPoints == 2)
                userEmoji = "\U000026A0";
            if (Storage.Users[user.EnemyId].HealthPoints == 1)
                enemyEmoji = "\U0001F6A8";
            if (Storage.Users[user.EnemyId].HealthPoints == 2)
                enemyEmoji = "\U000026A0";
            TelegramBot.EditMessage(user, user.BotMessagesId[1],
                $"\U0001F4DF*Счетчик серверов:*\n" +
                $"{enemyEmoji}*{Storage.Users[user.EnemyId].FirstName}*: {Storage.Users[user.EnemyId].HealthPoints}\n" +
                $"{userEmoji}*{user.FirstName}*: {user.HealthPoints}");
            TelegramBot.EditMessage(Storage.Users[user.EnemyId], Storage.Users[user.EnemyId].BotMessagesId[1],
                $"\U0001F4DF*Счетчик серверов:*\n" +
                $"{enemyEmoji}*{Storage.Users[user.EnemyId].FirstName}*: {Storage.Users[user.EnemyId].HealthPoints}\n" +
                $"{userEmoji}*{user.FirstName}*: {user.HealthPoints}");
        }
        private static void SendChoiceMessage(User user, string text = "")
        {
            TelegramBot.DelitMessage(user, user.BotMessagesId[user.BotMessagesId.Count - 1]);
            user.BotMessagesId.RemoveAt(user.BotMessagesId.Count - 1);
            TelegramBot.SendMessage(user, $"{text}\U0001F4C2*Куда отправить файл?*\U000023E9", replyMarkup: Storage.GetKeyboardMarkup("FileSendСhoice"), saveMessageToBotMessageIdList: true);
        }
        public static void Tutorial(User user, string сallbackQueryData)
        {

        }
        public static void StartSearch(User user)
        {
            user.InSearchGame = true;

            foreach (var enemy in Storage.Users)
                if (enemy.Value.Id != user.Id && enemy.Value.InSearchGame)
                {
                    user.InOnlineGame = true;
                    enemy.Value.InOnlineGame = true;
                    enemy.Value.InSearchGame = false;
                    user.InSearchGame = false;
                    TelegramBot.DelitMessage(enemy.Value, enemy.Value.BotMessagesId[enemy.Value.BotMessagesId.Count - 1]);
                    enemy.Value.BotMessagesId.RemoveAt(enemy.Value.BotMessagesId.Count - 1);
                    TelegramBot.SendMessage(enemy.Value,
                        $"*\U0001F47EПротивник найден!*\n" +
                        $"_Ваш противник:_ *{user.FirstName}*\n" +
                        $"_Рейтинг противника:_ _{user.Points}_*C*.", saveMessageToBotMessageIdList: true);
                    TelegramBot.SendMessage(user,
                        $"*\U0001F47EПротивник найден!*\n" +
                        $"_Ваш противник:_ *{enemy.Value.FirstName}*\n" +
                        $"_Рейтинг противника:_ _{enemy.Value.Points}_*C*.", saveMessageToBotMessageIdList: true);
                    user.ReloadGamePoint();
                    enemy.Value.ReloadGamePoint();
                    enemy.Value.EnemyId = user.Id;
                    user.EnemyId = enemy.Key;
                    enemy.Value.IsPlayerMove = true;
                    Storage.Users[user.Id] = user;
                    Storage.Users[enemy.Value.Id] = enemy.Value;
                    TelegramBot.SendMessage(enemy.Value,
                        $"\U0001F4DF*Счетчик серверов:*\n" +
                        $"\U0001F4BE*{enemy.Value.FirstName}*: {enemy.Value.HealthPoints}\n" +
                        $"\U0001F4BE*{user.FirstName}*: {user.HealthPoints}",
                        saveMessageToBotMessageIdList: true);
                    TelegramBot.SendMessage(user,
                        $"\U0001F4DF*Счетчик серверов:*\n" +
                        $"\U0001F4BE*{enemy.Value.FirstName}*: {enemy.Value.HealthPoints}\n" +
                        $"\U0001F4BE*{user.FirstName}*: {user.HealthPoints}",
                        saveMessageToBotMessageIdList: true);
                    TelegramBot.SendMessage(enemy.Value,
                        $"*Выбирите файл для отправки:*",
                        saveMessageToBotMessageIdList: true, replyMarkup: GetSetOfCards(enemy.Value));
                    TelegramBot.SendMessage(user,
                        $"*Сейчас ход противника!*\n" +
                        $"Если он ходит дольше 20 секунд, то вы можете пропустить его ход командой:" +
                        $"\n*/skip*\n_Но учтите, он что-то мог успеть сделать с файлами!_",
                        saveMessageToBotMessageIdList: true);
                    enemy.Value.LastMoveTime = DateTime.Now;
                    Storage.SaveUsers();
                    return;
                }
            TelegramBot.SendMessage(user, "\U0000231B*Идёт поиск игроков!*\U0001F50D\n" +
                "_Если вы хотите отменить поиск, то воспользуйтесь_ */stop* " +
                "_или нажмите_ *кнопку* _ниже_.",
                replyMarkup: Storage.GetKeyboardMarkup("StartSearch"), saveMessageToBotMessageIdList: true);
        }
        public static void WinGame(User winer, User loser)
        {

            for (int i = 0; i < winer.BotMessagesId.Count; i++)
                TelegramBot.DelitMessage(winer, winer.BotMessagesId[i]);

            winer.BotMessagesId.Clear();

            for (int i = 0; i < loser.BotMessagesId.Count; i++)
                TelegramBot.DelitMessage(loser, loser.BotMessagesId[i]);

            loser.BotMessagesId.Clear();

            winer.InOnlineGame = false;
            loser.InOnlineGame = false;
            winer.Points += winer.Score;
            winer.MatchsStatistics.Add(winer.Score);
            loser.MatchsStatistics.Add(-1 * winer.Score);
            if (loser.Points >= winer.Score)
                loser.Points -= winer.Score;
            else
                loser.Points = 0;

            TelegramBot.SendMessage(winer, Storage.GetAnswerToMessage("#Win#", userId: winer.Id), replyMarkup: Storage.GetKeyboardMarkup("ExitOnline"));
            TelegramBot.SendMessage(loser, Storage.GetAnswerToMessage("#Lose#", userId: loser.Id), replyMarkup: Storage.GetKeyboardMarkup("ExitOnline"));
            winer.Score = 0;
            loser.Score = 0;
            Storage.SaveUsers();
        }
        private static InlineKeyboardMarkup GetSetOfCards(User user)
        {
            Dictionary<string, string> NameSkills = new Dictionary<string, string>()
            {
                { "EmptyFile", "\U0001F4D1Подкинуть пустой файл.pdf" },
                { "Antivirus", "\U0001F6E1Проверка с помощью Антивирус.exe" },
                { "EncryptionVirus", "\U0001F510Шифровщик.bat" },
                { "Diagnostics", "\U0001F527Устранение неполадок" },
                { "DoubleSending", "\U0001F4E92 вирусных файла" }
            };
            var buttons = new List<List<InlineKeyboardButton>>();

            for (int i = 0; i < user.FileExtensions.Count; i++)
            {
                var row = new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData(NameSkills[user.FileExtensions[i]], user.FileExtensions[i])
                };
                buttons.Add(row);

            }
            buttons.Add(new List<InlineKeyboardButton>() { InlineKeyboardButton.WithCallbackData("\U0000274EОбычный Вирус.bat", "Empty") });
            return new InlineKeyboardMarkup(buttons);
        }
    }
}
