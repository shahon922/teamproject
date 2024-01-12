namespace DietDungeon
{
    public abstract class Unit
    {
        protected string name;
        protected int level = 1;
        protected int atk;
        protected int hp;

        public int Level { get => level; set => level = value; }
        public String Name { get => name; set => name = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Hp { get => hp; set => hp = value; }

        public abstract void Print();
        public void Attack(Unit target)
        {
            var rand = new Random();
            Console.WriteLine($"Lv.{level} {name} 의 공격!");
            Console.WriteLine($"{target.Name} 을(를) 맞췄습니다. [데미지: {atk}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{target.Level} {target.Name}");
            Console.Write($"Hp {target.hp} -> ");

            var error = (int)(Math.Ceiling(atk / 10.0));
            var damage = rand.Next(atk - error, atk + error);
            var targetHealth = Math.Max(target.hp - damage, 0);


            if (targetHealth > 0)
            {
                Console.WriteLine($"{targetHealth}");
            }
            else
            {
                Console.WriteLine($"Dead");
            }

            target.Hp = targetHealth;
        }

        public object Clone()
        {
            return this.MemberwiseClone(); //랜덤 몬스터 동시 적용돼서 클론으로 적용
        }
    }
}
