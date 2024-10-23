using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace War_Ai_Game_TelegramBot
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
                return $"\U0001F389*Добро пожаловать* в бота\n*War Ai*\U00002757\n\n" +
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
                    "Все очень просто, уничтожай или будь уничтоженным! " +
                    "Ты выполняешь роль ИИ, " +
                    "сражающегося со своими гадкими ИИ конкурентами, " +
                    "твоя задача испортить сервера противника, " +
                    "чтобы твой противник не мог с тобой конкурировать в сфере ИИ.\r\n\r\n" +
                    "Сначала вам предстоит выбрать какие использовать файлы, " +
                    "а затем вы выбираете куда их отправить, " +
                    "себе на сервера или на сервера противника. " +
                    "Если вы использовали файлы, " +
                    "которые будут работать только во время хода противника или Антивирус, " +
                    "то вы все равно отправляете попутно вредоносные файлы. " +
                    "Выбор отправить себе нужен, так как вы не знаете, " +
                    "что противник мог сделать с вашими файлами. \r\n\r\n" +
                    "У вас, как и у вашего противника, изначально *4* сервера, " +
                    "тот чьи все сервера сломаются первыми проиграет. " +
                    "_За поражение забирают столько очков, сколько выиграл противник_. " +
                    "За победу очки выдаются за количество рабочих серверов на момент финального хода " +
                    "(Они конвертируются 1 сервер = 3 очка). " +
                    "Очки тут называются Server Capacity (Мощность серверов) или же просто С! \r\n\r\n" +
                    "*Сервера можно увеличить за:*\r\n" +
                    "_•Успешное нахождение шифровшика_ *Проверкой с помощью антивируса*. *(+2S)*\r\n" +
                    "_•Отправка себя пустых файлов противника или использование_ *Устранения неполадок*. *(+1S)*\r\n" +
                    "_•Успешное получение данных от_ *Шифровщика*. *(+1S)*\r\n\r\n" +
                    "♯Если ваш противник будет долго выполнять отправку файлов, " +
                    "то вы можете пропустить ход командой */skip*!\r\n" +
                    "♯Если же вы хотите сдастся, то можете просто покинут матч командой */exit*. " +
                    "За это *противник получит ваши сервера!*\r\n" +
                    "♯Таблицу лидеров можно посмотреть командой */top*!\r\n\r\n" +
                    "_2._*Обучение:*\r\n" +
                    "Тут вы просто можете протестировать отправку разных файлов и посмотреть как они работают.\r\n" +
                    "За выход из обучения вы нечего *не теряете*. Чтобы выйти пропишите команду */exit*!\r\n";
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
                for (int i = 0; i < Users[userId].MatchStatistics.Count; i++)
                {
                    if (i == 10)
                    {
                        break;
                    }
                    else if (Users[userId].MatchStatistics[i] >= 0)
                        text += $"_Игра_ - *{Users[userId].MatchStatistics.Count - i}:*\n\U0001F4C8_Победа:_ *+{Users[userId].MatchStatistics[i]}C*\n\n";
                    else
                        text += $"_Игра_ - *{Users[userId].MatchStatistics.Count - i}:*\n\U0001F4C9_Поражение:_ *{Users[userId].MatchStatistics[i]}C*\n\n";
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
                    "*•/exit* _– покинуть матч. За это_ *противник получит ваши сервера!*\r\n" +
                    "*•/skip* _– пропустить ход противника, если он ходит дольше 20 секунд_*!*\r\n" +
                    "*•/message (текст)* или /msg (текст) _– отправить сообщение противнику_*.*\r\n\r\n" +
                    "*♯В обучении:*\r\n" +
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
                return $"\U000026A1*Вы выиграли*!\n" +
                    $"Сервера противника в огне. Хорошая работа!\n" +
                    $"Вы получаете _{Users[userId].Score}_*C*\n" +
                    $"*Вы можете*:\n" +
                    $"Посмотреть топ 20 игроков:\n*/top*\n" +
                    $"Посмотреть свою статистику:\n*/statistics*\n" +
                    $"Вернуться на старт:\n*/start*\n" +
                    $"_Или просто понажимать кнопки снизу_.";

            else if (message == "#Lose#")
                return $"\U0001F525*Вы проиграли*!\n" +
                    $"Эх... Все ваши сервера сгорели и в панике вы сами себя отформатировали.\n" +
                    $"За поражение вы теряете _{Users[Users[userId].EnemyId].Score}_*C*\n" +
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
                case "FileSendСhoice":
                    {
                        var kbrd = new InlineKeyboardMarkup(new InlineKeyboardButton[][] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F4E5На свой сервер", "SendYourself")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("\U0001F4E4На сервер противника", "SendEnemy")
                        }});
                        return kbrd;
                    }
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
                            InlineKeyboardButton.WithCallbackData("\U0001F393Обучение", "Tutorial")
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
