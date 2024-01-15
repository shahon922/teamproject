using System.Numerics;

namespace DietDungeon
{
    public abstract class Unit
    {
        public int Level { get; set; }
        public String Name { get; set; } = "";
        public int Atk { get; set; }
        public int Def { get; set; } = 0;
        public int Hp { get; set; }
        public int Mp { get; set; } = 0;

        public void Attack(Unit target)
        {
            var rand = new Random();
            var error = (int)(Math.Ceiling(Atk / 10.0));
            var damage = rand.Next(Atk - error, Atk + error);
            var targetHealth = (int)(target.Hp - damage);

            Console.WriteLine($"Lv.{Level} {Name} 의 공격!");
            Console.WriteLine($"{target.Name} 을(를) 맞췄습니다. [데미지: {damage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{target.Level} {target.Name}");
            Console.Write($"Hp {target.Hp} -> ");

            if (targetHealth > 0)
            {
                Console.WriteLine($"{targetHealth}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Dead");
                targetHealth = 0;
                Console.WriteLine();
            }

            target.Hp = targetHealth;
        }
    }
}
