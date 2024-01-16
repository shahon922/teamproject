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
}
