using System.Numerics;
using teamproject;


namespace DietDungeon
{
    public abstract class Unit
    {
        // 치명타 및 회피 확률
        private const double CriticalChance = 0.15;
        private const double CriticalMultiply = 1.6;
        private const double MissChance = 0.1;

        public int Level { get; set; }
        public String Name { get; set; } = "";
        public int Atk { get; set; }
        public int Def { get; set; } = 0;
        public int Hp { get; set; }
        public int Mp { get; set; } = 0;

        public void Attack(Unit target)
        {
            Console.WriteLine($"Lv.{Level} {Name} 의 공격!");
            var rand = new Random();

            bool isMiss = rand.Next(100) < MissChance * 100;
            if (isMiss)
            {
                PrintAttackMiss(target);
            }
            else
            {
                var isCritical = rand.Next(100) < CriticalChance * 100;
                var damage = Atk;
                if (isCritical)
                {
                    damage = (int)(damage * CriticalMultiply);
                }
                var error = (int)Math.Ceiling(damage / 10.0);
                damage = rand.Next(damage - error, damage + error);
                var targetHealth = Math.Max(target.Hp - damage, 0);

                PrintAttack(target, damage, isCritical, targetHealth);

                target.Hp = targetHealth;
            }


        }

        public void SkillAttack(Unit target, Skill skill)
        {
            var playerAtk = Atk * skill.SkillAtk;

            var rand = new Random();
            var error = Math.Ceiling(playerAtk / 10.0);
            var damage = rand.Next((int)(playerAtk - error), (int)(playerAtk + error));
            var targetHealth = (int)(target.Hp - damage);

            Console.WriteLine($"Lv.{Level} {Name} 의 {skill.SkillName} 스킬 공격!");
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

        private void PrintAttackMiss(Unit target) //치명타 및 회피 기능
        {
            Console.WriteLine($"{target.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
        }

        private void PrintAttack(Unit target, int damage, bool isCritical, int targetHealth)
        {
            Console.Write($"{target.Name} 을(를) 맞췄습니다. [데미지: {damage}]");
            if (isCritical)
            {
                Console.WriteLine("- [치명타 공격]!!!");
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Lv.{target.Level} {target.Name}");
            Console.Write($"Hp {target.Hp} -> ");

            if (targetHealth > 0)
            {
                Console.WriteLine($"{targetHealth}");
            }
            else
            {
                Console.WriteLine($"Dead");
            }
        }
    }
}