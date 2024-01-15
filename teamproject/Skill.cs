using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamproject
{
    public class Skill
    {
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public float SkillAtk { get; set; }
        public int SkillMp { get; set; }

        public Skill(string skillName, string skillDescription, float skillAtk, int skillMp)
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            SkillAtk = skillAtk;
            SkillMp = skillMp;
        }
        public Skill(string skillName, string skillDescription)
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            SkillAtk = 0;
            SkillMp = 0;
        }
    }
}
