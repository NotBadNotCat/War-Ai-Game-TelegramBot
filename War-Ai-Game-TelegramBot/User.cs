﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Ai_Game_TelegramBot
{
    internal class User
    {
        public User(Int64 userId, string firstName, string nickName)
        { Id = userId; FirstName = firstName; NickName = nickName; }

        public Int64 Id;
        public string FirstName = null!;
        public string NickName = null!;

        public List<int> BotMessagesId = new List<int>();
        public List<string> Messages = new List<string>();

        public bool IsBanned;
        public bool HasCompletedTutorial;

        public bool IsInOnlineGame;
        public bool IsInTutorial;
        public bool IsInSearchGame;

        public int Points = 0;
        public int Score = 0;
        public List<int> MatchStatistics = new List<int>();

        public Int64 EnemyId;
        public bool IsPlayerTurn;
        public bool IsUserSendCards;
        public DateTime LastMoveTime;
        public int FileDamage = 1;
        public int HealthPoints = 4;
        public List<string> FileExtensions = new List<string>() { "EmptyFile", "Antivirus", "EncryptionVirus", "Diagnostics", "DoubleSending" };

        public void ReloadGameParameters()
        {
            EnemyId = 0;
            IsPlayerTurn = false;
            IsUserSendCards = false;
            FileDamage = 1;
            HealthPoints = 4;
            Score = 0;
            FileExtensions = new List<string>() { "EmptyFile", "Antivirus", "EncryptionVirus", "Diagnostics", "DoubleSending" };

        }
    }
}
