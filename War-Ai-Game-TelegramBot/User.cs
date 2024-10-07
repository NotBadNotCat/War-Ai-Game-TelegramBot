using System;
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
        public bool InOnlineGame;
        public bool InSandbox;
        public bool InSearchGame;

        public int Points = 0;
        public int Score = 0;
        public List<int> MatchsStatistics = new List<int>();

        public Int64 EnemyId;
        public bool IsPlayerMove;
        public DateTime LastMoveTime;
        public int ShotGunDamage = 1;
        public int HealthPoints = 4;
        public List<string> SkillСards = new List<string>() { "BlankСartridge", "Reload", "MedicineBullet", "MedKit", "Amplifier" };

        public void ReloadGamePoint()
        {
            EnemyId = 0;
            IsPlayerMove = false;
            ShotGunDamage = 1;
            HealthPoints = 4;
            Score = 0;
            SkillСards = new List<string>() { "BlankСartridge", "Reload", "MedicineBullet", "MedKit", "Amplifier" };
        }
    }
}
