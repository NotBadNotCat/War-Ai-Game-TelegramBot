using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return false;
            }
        }
        public static string GetAnswerToMessage(string message, bool isNewUser = false)
        {
            if (message == "/start" && isNewUser)
                return $"\U0001F389*Добро пожаловать* в бота\n*Shotgun Roulette*\U00002757\n\n" +
                    "_Прочитайте правила._";

            else if (message == "/start" && !isNewUser)
                return "\U0001F3AF*Выберите действие!*";

            else if (message == "/game")
                return "";

            else if (message == "/rules")
                return "";

            else if (message == "/statistics")
                return "";

            else if (message == "/top")
            {
                List<User> usersToSort = new List<User>();
                string text = "\U0001F4E2*Топ* _20_ *игроков:*\n\n";
                if (Users.ContainsKey(1932903539))
                    text += $"\U00002728*Создатель* [NeVova](https://github.com/NotBadNotCat): *{ Users[1932903539].Points}С*\n\n";
                else
                    text += $"\U00002728*Создатель:* [NeVova](https://github.com/NotBadNotCat): *-------С*\n\n";

                foreach (var user in Users)
                    if (user.Value.Points != 0)
                        usersToSort.Add(user.Value);

                if (usersToSort.Count > 0)
                {
                    usersToSort.Sort((u1, u2) => u1.Points.CompareTo(u2.Points));

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

            else if (message == "/help")
                return "";

            else if (message == "/stop")
                return "\U000026D4*Вы не в поиске матча!*\nВведите /start.";

            else if (message == "/exit")
                return "\U000026D4*Вы не в матче!*\nВведите /start.";

            else if (message.Contains("/"))
                return "\U000026D4*Такой команды нет!*\nЧтобы узнать все существующие команды бота пропишите /help.";

            else
                return "\U000026D4*Вы ввели некорректное сообщение!*\nВведите /start.";
        }

    }
}
