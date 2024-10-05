﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun_Roulette_Game_TelegramBot
{
    internal class User
    {
        public User(Int64 userId, string firstName, string nickName) 
        { UserId = userId; FirstName = firstName; NickName = nickName; }

        public string FirstName = null!;
        public string NickName = null!;
        public Int64 UserId;
        public bool IsBanned;

        public List<string> Messages = new List<string>();

        public int Points = 0;

        public bool InOnlineGame;
        public bool InSandbox;
        public bool InSearchGame;
    }
}
