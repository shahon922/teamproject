using DietDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietDungeon
{
    //public class Monster : Unit
    //{
    //    public string Name { get; }
    //    public int Level { get; }
    //    public int Hp { get; }
    //    public int Atk { get; }

    //    public Monster(string name, int level, int hp, int atk)
    //    {
    //        Name = name;
    //        Level = level;
    //        Hp = hp;
    //        Atk = atk;
    //    }

    //    public void MonsterDescription()
    //    {
    //        Console.WriteLine($" Lv.{Level} {Name} | HP {Hp}");
    //    }

    //    public override void Print()
    //    {

    //    }
    //}

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
            this.Name = other.name;
            this.Level = other.level;
            this.Hp = other.hp;
            this.Atk = other.atk;
        }

        public String getInfo()
        {
            return $"Lv.{level} {name} {hp} {atk}";
        }

        public override void Print()
        {
            Console.Write($"Lv.{level} {name} ");
            if (hp > 0)
            {
                Console.WriteLine($"{hp} {atk}");
            }
            else
            {
                Console.WriteLine($"Dead");
            }

        }
        public void MonsterDescription()
        {
            Console.WriteLine($" Lv.{Level} {Name} | HP {Hp}");
        }

        internal void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
