using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teamproject;

namespace DietDungeon
{
    public class Player : Unit
    {
        public Job Job { get; set; }
        public int Gold { get; set; }
        public int SkillCount { get; set; }
        public int Floor { get; set; } = 1;
        public int HpPotion { get; set; } = 3;
        public int MpPotion { get; set; } = 3;

        public Player(string name, int level, Job job)
        {
            Name = name;
            Level = level;
            this.Job = job;
            Hp = job.Hp;
            Atk = job.Atk;
            Def = job.Def;
            Mp = job.Mp;
            Gold = 1500;
            Exp = 0;
            SkillCount = job.SkillCount;
        }

        public void UpgradeJob(Job job)
        {
            this.Job = job;
            Hp = job.Hp;
            Atk = job.Atk;
            Def = job.Def;
            Mp = job.Mp;
            SkillCount++;
        }

    }

    public class Potion
    {
        public string PotionName { get; set; }
        public int Type { get; set; }
        public int PotionCount { get; set; }

        public Potion(string potionName, int type, int potionCount)
        {
            PotionName = potionName;
            Type = type;
            PotionCount = potionCount;
        }
    }
}
