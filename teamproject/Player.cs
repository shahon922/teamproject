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
        public Job job { get; set; }
        public int gold { get; set; }

        public Player(string name, int level, Job job)
        {
            Name = name;
            Level = level;
            this.job = job;
            Hp = job.Hp;
            Atk = job.Atk;
            Def = job.Def;
            Mp = job.Mp;
            gold = 1500;
        }

        public void UpgradeJob(Job job)
        {
            this.job = job;
            Hp = job.Hp;
            Atk = job.Atk;
            Def = job.Def;
            Mp = job.Mp;
        }

    }
}
