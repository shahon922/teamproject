using System.Numerics;

namespace DietDungeon
{
    public abstract class Unit
    {
        static Monster[] spawnMonsters;

        protected string name;
        protected int level = 1;
        protected int atk;
        protected int hp;
        private int health;
        private int count;

        public int Level { get => level; set => level = value; }
        public String Name { get => name; set => name = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Hp { get => hp; set => hp = value; }

        public abstract void Print();
        public void Attack(Unit target)
        {
            var rand = new Random();
            var error = (int)(Math.Ceiling(atk / 10.0));
            var damage = rand.Next(atk - error, atk + error);
            var targetHealth = Math.Max(target.hp - damage, 0);

            Console.WriteLine($"Lv.{level} {name} 의 공격!");
            Console.WriteLine($"{target.Name} 을(를) 맞췄습니다. [데미지: {damage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{target.Level} {target.Name}");
            Console.Write($"Hp {target.hp} -> ");

            if (targetHealth > 0)
            {
                Console.WriteLine($"{targetHealth}");
            }
            else
            {
                Console.WriteLine($"Dead");
            }

            target.Hp = targetHealth;


            for (int i = 0; i < count; i++)
            {
                if (target.hp > 0)
                {
                    var rand1 = new Random();
                    var error1 = (int)(Math.Ceiling(target.atk / 10.0)); // 올림처리
                    var damage1 = rand.Next(target.atk - error1, target.atk + error1); // 10퍼 랜덤 데미지
                    var health = Math.Max(hp - damage1, 0); // 적이 죽었음

                    Console.WriteLine("");
                    Console.WriteLine($"Lv.{target.level} {target.Name} 의 공격!");
                    Console.WriteLine($"{Name} 을(를) 맞췄습니다. [데미지: {damage1}]");
                    Console.WriteLine();
                    Console.WriteLine($"Lv.{Level} {Name}");
                    Console.Write($"Hp {hp} -> ");
                    
                }
                else if (target.hp <= 0)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Lv.{target.level} {target.Name} Dead");
                    Console.ResetColor();
                    Console.WriteLine($"Lv.{Level} {Name}");
                    Console.Write($"Hp {hp} -> ");
                }

                if (hp > 0)
                {
                    Console.WriteLine($"{hp}");
                }
                else
                {
                    Console.WriteLine($"Dead");
                }
                Hp = health;
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone(); //랜덤 몬스터 동시 적용돼서 클론으로 적용
        }
    }
}
