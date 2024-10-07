using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace War_Ai_Game_TelegramBot
{
    internal class AiWarGame
    {
        public AiWarGame() 
        {

        }
        public static void Game(User user)
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
                        saveMessageToBotMessageIdList: true, replyMarkup: GetSetOfCards(user));
                    TelegramBot.SendMessage(user,
                        $"*Сейчас ход противника!*\n" +
                        $"Если он ходит дольше 20 секунд, то вы можете пропустить его ход командой:" +
                        $"\n*/skip*\n_Но учтите, он что-то мог успеть сделать с файлами!_",
                        saveMessageToBotMessageIdList: true);
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

                { "EmptyFile", "\U0001F4D1Пустой файл.pdf" }, 
                { "Cleaning", "\U0001F9F9Очистка реестра.exe" }, 
                { "EncryptionVirus", "\U0001F510Шифровщик.bat" }, 
                { "Antivirus", "\U0001F6E1Антивирус.exe" }, 
                { "DoubleSending", "\U0001F4E92 вирусных файла" } 
            };
            var buttons = new List<List<InlineKeyboardButton>>();
            
            for (int i = 0; i < user.SkillСards.Count; i++)
            {
                var row = new List<InlineKeyboardButton>() 
                {
                    InlineKeyboardButton.WithCallbackData(NameSkills[user.SkillСards[i]], user.SkillСards[i])
                };
                buttons.Add(row);

            }
            buttons.Add(new List<InlineKeyboardButton>() { InlineKeyboardButton.WithCallbackData("\U0000274EОбычный Вирус.bat", "Empty") });
            return new InlineKeyboardMarkup(buttons);
        }
    }
}
