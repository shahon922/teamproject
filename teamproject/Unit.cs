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

        // targetHealth저장용
        private int targetHealth;

        public int Level { get; set; }
        public String Name { get; set; } = "";
        public float Atk { get; set; }
        public int Def { get; set; } = 0;
        public int Hp { get; set; }
        public int Mp { get; set; } = 0;
        public int Exp { get; set; }

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
                var error = Math.Ceiling(damage / 10.0);
                damage = rand.Next((int)(damage - error), (int)(damage + error));
                targetHealth = Math.Max(target.Hp - (int)damage, 0);

                PrintAttack(target, (int)damage, isCritical);

                target.Hp = targetHealth;
            }


        }

        public void SkillAttack(Unit target, Skill skill)
        {
            var playerAtk = Atk * skill.SkillAtk;

            var rand = new Random();
            var error = Math.Ceiling(playerAtk / 10.0);
            var damage = rand.Next((int)(playerAtk - error), (int)(playerAtk + error));
            targetHealth = (int)(target.Hp - damage);

            Console.WriteLine($"Lv.{Level} {Name} 의 {skill.SkillName} 스킬 공격!");
            Console.WriteLine($"{target.Name} 을(를) 맞췄습니다. [데미지: {damage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{target.Level} {target.Name}");
            Console.Write($"Hp {target.Hp} -> ");

            AttackResult(target);
        }

        private void PrintAttackMiss(Unit target) //치명타 및 회피 기능
        {
            Console.WriteLine($"{target.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
        }

        private void PrintAttack(Unit target, int damage, bool isCritical)
        {
            Console.Write($"{target.Name} 을(를) 맞췄습니다. [데미지: {damage}]");
            if (isCritical)
            {
                Console.WriteLine(" - [치명타 공격!!!]");
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Lv.{target.Level} {target.Name}");
            Console.Write($"Hp {target.Hp} -> ");

            AttackResult(target);
        }

        private void AttackResult(Unit target)
        {
            if (targetHealth > 0)
            {
                Console.WriteLine($"{targetHealth}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Dead");
                Console.WriteLine();

                if(target.Name == "콜라")
                    Console.WriteLine("◇ 모든 콜라가 제로 콜라로 바뀌었습니다! ◇");
                else if (target.Name == "탕후루" || target.Name == "떡볶이" || target.Name == "대창")
                    Console.WriteLine($"◇ {target.Name}집이 망했습니다! ◇");
                else
                    Console.WriteLine("◇ 플레이어가 죽었습니다! ◇");

                targetHealth = 0;

                Console.WriteLine();
            }

            target.Hp = targetHealth;
        }

    }
}