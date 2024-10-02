using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun_Roulette_Game_TelegramBot
{
    internal class Storage
    {
        public static Dictionary<Int64, User> Users = new Dictionary<Int64, User>();

        public static bool UserExsistCheckAndWrite(Int64 userId)
        {
            if (Users.ContainsKey(userId))
            { 
                return true;
            }
            else
            {
                Users.Add(userId, new User());
                return false;
            }
        }
    }
}
