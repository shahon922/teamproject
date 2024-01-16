using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace teamproject
{
    public class Job
    {
        public string JobName { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public Skill Skill1 { get; set; }
        public Skill Skill2 { get; set; }
        public int SkillCount { get; set; }

        [JsonConstructor]
        public Job(string jobName, int atk, int def, int hp, int mP, Skill skill1, Skill skill2)
        {
            JobName = jobName;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mP;
            this.Skill1 = skill1;
            this.Skill2 = skill2;
            SkillCount = 2;
        }
        public Job(string jobName, Skill skill1)
        {
            JobName = jobName;
            Atk = 5;
            Def = 5;
            Hp = 100;
            Mp = 0;
            this.Skill1 = skill1;
            this.Skill2 = skill1;
            SkillCount = 0;
        }
    }
}
