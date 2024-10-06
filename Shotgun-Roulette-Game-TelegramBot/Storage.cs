using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shotgun_Roulette_Game_TelegramBot
{
    internal class Storage
    {
        /*
         * Unicode:
         * \U********
         * К примеру:
         *      ❌ - hex code = 274c
         *      То:
         *      Unicode = \U0000274c
         * Ссылка на сайт с эмодзи: https://apps.timwhitlock.info/emoji/tables/unicode
         */
        public static Dictionary<Int64, User> Users = new Dictionary<Int64, User>();

        public static bool UserExsistCheckAndWrite(Int64 userId, string firstName, string nickName)
        {
            if (Users.ContainsKey(userId))
            {
                Users[userId].FirstName = firstName;
                Users[userId].NickName = nickName;
                return true;
            }
            else
            {
                Users.Add(userId, new User(userId, firstName, nickName));
                SaveUsers();
                return false;
            }
        }
        public static string GetAnswerToMessage(string message, bool isNewUser = false, Int64 userId = 0)
        {
            if (message == "/start" && isNewUser)
                return $"\U0001F389*Добро пожаловать* в бота\n*Shotgun Roulette*\U00002757\n\n" +
                    "_Прочитайте правила._";

            else if ((message == "/start" || message == "/s") && !isNewUser)
                return "\U0001F3AF*Выберите действие.*";

            else if (message == "/game" || message == "/g")
                return "*\U0001F6A9Выберите режим игры.*";

            else if (message == "/search" || message == "/src")
                return "\U000026A0Вы хотите *начать поиск*\U00002753";

            else if (message == "/rules" || message == "/r")
            {
                return "\U00002753*Как играть:*\U00002753\r\n\r\n" +
                    "_1._*Обычный режим:*\r\n" +
                    "Все очень просто, убей или будь убитым! " +
                    "На столе лежит дробовик, заряженный патронами, " +
                    "ещё на столе лежит пять карт способностей и счётчик жизни. \r\n\r\n" +
                    "Сначала вам предстоит выбрать какую карту использовать, " +
                    "а затем вы берете дробовик в руки и выбираете в кого выстрелить, " +
                    "в себя или в противника. Выбор выстрелить в себя нужен, " +
                    "так как вы не знаете, что противник мог сделать с дробовиком. \r\n\r\n" +
                    "У вас, как и у вашего противника, изначально *4* жизни, " +
                    "тот чьи жизни закончатся первым проиграет. " +
                    "_За поражение забирают столько очков сколько выиграл противник_. " +
                    "За победу очки выдаются за риск, " +
                    "очки тут называются *Playing Chips* или же просто *C*! \r\n" +
                    "Баллы риска дают за ваши действия, например если вы выстрелите в себя, " +
                    "то вам дадут больше баллов риска чем если вы выстрелите в противника. " +
                    "_Сколько баллов риска вы получите столько и очков вам дадут за победу_!\r\n\r\n" +
                    "*Риском считается:*\r\n" +
                    "_•Выбрать пустую карту._ *(+4C)*\r\n" +
                    "_•Выстрелить в себя._ *(+3C)*\r\n" +
                    "_•Использование карты Холостой._ *(+2C)*\r\n" +
                    "_•Ход при низком (при одном или двум) количестве жизней._ *(+2C)*\r\n" +
                    "_•Победа при большом количестве жизней._ *(+3C)*\r\n" +
                    "_•Остальное даёт малый плюс к риску._ *(+1C)*\r\n\r\n" +
                    "♯Если ваш противник будет долго думать, " +
                    "то вы можете пропустить ход командой */skip*!\r\n" +
                    "♯Если же вы хотите сдастся, то можете просто покинут матч командой */exit*. За это вы *получите штраф!*\r\n" +
                    "♯Таблицу лидеров можно посмотреть командой */top*!\r\n\r\n" +
                    "_2._*Песочница:*\r\n" +
                    "Тут вы просто можете протестировать карты.\r\n" +
                    "За выход вы нечего *не теряете*. Чтобы выйти пропишите команду */exit*!\r\n";
            }

            else if (message == "/statistics" || message == "/st")
            {
                List<User> usersToSort = new List<User>();
                int positionInTop = -1;

                foreach (var user in Users)
                    usersToSort.Add(user.Value);
                if (usersToSort.Count > 0)
                {
                    usersToSort.Sort((u1, u2) => u2.Points.CompareTo(u1.Points));

                    for (int i = 0; i < usersToSort.Count; i++)
                        if (usersToSort[i].Id == userId)
                        {
                            positionInTop = i + 1;
                            break;
                        }
                }
                string text = "";
                for (int i = 0; i < Users[userId].MatchsStatistics.Count; i++)
                {
                    if (i == 10)
                    {
                        break;
                    }
                    else if (Users[userId].MatchsStatistics[i] >= 0)
                        text += $"_Игра_ - *{Users[userId].MatchsStatistics.Count - i}:*\n\U0001F4C8_Победа:_ *+{Users[userId].MatchsStatistics[i]}C*\n\n";
                    else
                        text += $"_Игра_ - *{Users[userId].MatchsStatistics.Count - i}:*\n\U0001F4C9_Поражение:_ *{Users[userId].MatchsStatistics[i]}C*\n\n";
                }
                if (text == "")
                    text = "\U0000274c_Вы ещё не играли!_";
                if (userId != 0)
                    return $"\U0001F4CAСтатистика *{Users[userId].FirstName}*: _{Users[userId].Points}_*C*\n" +
                    $"Вы: *{positionInTop}* в топе*!*\n" +
                    $"*Статистика последних 10 игр:*\n\n{text}";
                else
                    return "";
            }

            else if (message == "/top")
            {
                List<User> usersToSort = new List<User>();
                string text = "\U0001F4E2*Топ* _20_ *игроков:*\n\n";
                if (Users.ContainsKey(1932903539))
                    text += $"\U00002728*Создатель* [NeVova](https://github.com/NotBadNotCat): *{Users[1932903539].Points}С*\n\n";
                else
                    text += $"\U00002728*Создатель:* [NeVova](https://github.com/NotBadNotCat): *-------С*\n\n";

                foreach (var user in Users)
                    if (user.Value.Points != 0)
                        usersToSort.Add(user.Value);

                if (usersToSort.Count > 0)
                {
                    usersToSort.Sort((u1, u2) => u2.Points.CompareTo(u1.Points));

                    for (int i = 0; i < usersToSort.Count; i++)
                    {
                        if (i == 30)
                            break;

                        else if (i == 0)
                            text += $"\U0001F451*{i + 1}*. _{usersToSort[i].FirstName}_: *{usersToSort[i].Points}С*\n\n";

                        else if (i == 1)
                            text += $"\U0001F451*{i + 1}*. _{usersToSort[i].FirstName}_: *{usersToSort[i].Points}С*\n\n";

                        else if (i == 2)
                            text += $"\U0001F451*{i + 1}*. _{usersToSort[i].FirstName}_: *{usersToSort[i].Points}С*\n\n";

                        else
                            text += $"*{i + 1}*. _{usersToSort[i].FirstName}_: _{usersToSort[i].Points}С_\n\n";
                    }
                }
                else
                {
                    text += "_Пока пусто_\U0000274c";
                }
                return text;
            }

            else if (message == "/help" || message == "/h")
            {
                string text = "\U0001F527*Команды бота:*\n\n" +
                    "*♯Обычные:*\r\n" +
                    "*•/start* или /s _- выводит стартовое меню выбора_*.*\r\n" +
                    "*•/rules* или /r _- выводит правила игры_*.*\r\n" +
                    "*•/game* или /g _- выводит меню выбора режим игры_*.*\r\n" +
                    "*•/search* или /src _-Запускает поиск игроков в онлайн режиме_*.*\r\n" +
                    "*•/statistics* или /st _- выводит вашу статистику_*.*\r\n" +
                    "*•/top* _- выводит таблицу лидеров_*.*\r\n" +
                    "*•/help* или /h _– выводит все команды бота_*.*\r\n\r\n" +
                    "*♯В поиске игроков:*\r\n" +
                    "*•/stop* _- останавливает поиск игроков_*.*\r\n\r\n" +
                    "*♯В игре:*\r\n" +
                    "*•/exit* _– покинуть матч. Но за это будет начислен_ *штраф!*\r\n" +
                    "*•/skip* _– пропустить ход противника, если он ходит дольше 20 секунд_*!*\r\n" +
                    "*•/message (текст)* или /msg (текст) _– отправить сообщение противнику_*.*\r\n\r\n" +
                    "*♯В песочнице:*\r\n" +
                    "*•/exit* _– выйти из песочницы. Штрафа_ *не* _будет_*!*\r\n";

                return text;
            }

            else if (message == "/stop")
                return "\U000026D4*Вы не в поиске матча!*\nВведите /start.";

            else if (message == "/exit" || message.Contains("/message ") || message.Contains("/msg "))
                return "\U000026D4*Вы не в матче!*\nВведите /start.";

            else if (message.Contains("/"))
                return "\U000026D4*Такой команды нет!*\nЧтобы узнать все существующие команды бота воспользуйтесь /help.";

            else if (message == "#Win#")
                return $"\U0001F3C6*Вы выиграли*!\n" +
                    $"Вы получаете чемодан с _{Users[userId].Score}_*C*\n" +
                    $"*Вы можете*:\n" +
                    $"Посмотреть топ 20 игроков:\n*/top*\n" +
                    $"Посмотреть свою статистику:\n*/statistics*\n" +
                    $"Вернуться на старт:\n*/start*\n" +
                    $"_Или просто понажимать кнопки снизу_.";

            else if (message == "#Lose#")
                return $"\U0001F480*Вы проиграли*!\n" +
                    $"За поражение мы забираем _{Users[Users[userId].EnemyId].Score}_*C*\n" +
                    $"*Вы можете*:\n" +
                    $"Посмотреть топ 20 игроков:\n*/top*\n" +
                    $"Посмотреть свою статистику:\n*/statistics*\n" +
                    $"Вернуться на старт:\n*/start*\n" +
                    $"_Или просто понажимать кнопки снизу_.";

            else
                return "\U000026D4*Вы ввели некорректное сообщение!*\nВведите /start.";
        }
        public static InlineKeyboardMarkup GetKeyboardMarkup(string callbackQueryId, bool isNewUser = false)
        {
            switch (callbackQueryId)
            {
                case "/start":
                case "/s":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F3AEИграть", "/game")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F4D6Правила", "/rules")
                        }});

                        if (isNewUser)
                        {
                            kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                            new[]
                            {
                            InlineKeyboardButton.WithCallbackData("\U0001F4D6Правила", "/rules")
                            } });
                            return kbrd;
                        }
                        else
                        {
                            return kbrd;
                        }
                    }
                case "/game":
                case "/g":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F30DИграть против игроков", "/search")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F3D6Песочница", "Sandbox")
                        }});
                        return kbrd;
                    }
                case "/rules":
                case "/r":
                case "/st":
                case "/statistics":
                case "/top":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F3AEИграть", "/game")
                        }});
                        return kbrd;
                    }
                case "/search":
                case "/src":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U00002705Начать", "StartSearch")
                        }});
                        return kbrd;
                    }
                case "StartSearch":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0000274CОстановить поиск", "StopSearch")
                        }});
                        return kbrd;
                    }
                case "ExitOnline":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F3AFНа старт", "/start")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F4E2Посмотреть топ", "/top")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F4CAМоя статистика", "/statistics")
                        }
                        });
                        return kbrd;
                    }
                default:
                    {
                        return null!;
                    }
            }
        }
        public static void SaveUsers()
        {
            Directory.CreateDirectory("db");
            string jsonString = JsonConvert.SerializeObject(Users);
            System.IO.File.WriteAllText($"db\\save.json", jsonString);
        }
        public static void LoadUsers()
        {
            if (File.Exists($"db\\save.json"))
                Users = JsonConvert.DeserializeObject<Dictionary<Int64, User>>(File.ReadAllText("db\\save.json"))!;
        }
    }
}
