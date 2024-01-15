using DietDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietDungeon
{
    public class Monster : Unit
    {
        public Monster(String name, int level, int hp, int atk)
        {
            this.Name = name;
            this.Level = level;
            this.Hp = hp;
            this.Atk = atk;
        }
        public Monster(Monster other)
        {
            this.Name = other.Name;
            this.Level = other.Level;
            this.Hp = other.Hp;
            this.Atk = other.Atk;
        }

        public void MonsterDescription()
        {
            if (Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" Lv.{Level} {Name} | DEAD");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($" Lv.{Level} {Name} | HP {Hp}");
            }
        }
    }
}
