using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using teamproject;

namespace DietDungeon
{
    internal class Program
    {
        static Player player;
        static Job[] jobs;
        static Skill[] skills;
        static Monster[] monsters;
        static Monster[] spawnMonsters;
        static int count;

        static void Main(string[] args)
        {
            PrintStartLogo();
            GameDataSetting();
            PlayerSetting();
            StartMenu();
         }


        // Setting
        private static void PrintStartLogo()
        {
            Console.WriteLine("");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine("");
            Console.WriteLine("   ██     ██ ███████ ██      ██       ██████  ██████  ███    ███  ");
            Console.WriteLine("   ██     ██ ██      ██      ██      ██      ██    ██ ████  ████  ");
            Console.WriteLine("   ██  █  ██ █████   ██      ██      ██      ██    ██ ██ ████ ██  ");
            Console.WriteLine("   ██ ███ ██ ██      ██      ██      ██      ██    ██ ██  ██  ██  ");
            Console.WriteLine("    ███ ███  ███████ ███████ ███████  ██████  ██████  ██      ██  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                  ██████    ██   ███████  ████████                ");
            Console.WriteLine("                  ██   ██   ██   ██          ██                   ");
            Console.WriteLine("                  ██   ██   ██   █████       ██                   ");
            Console.WriteLine("                  ██   ██   ██   ██          ██                   ");
            Console.WriteLine("                  ██████    ██   ███████     ██                   ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("   ██████  ██    ██ ███    ██  ██████  ███████  ██████  ███    ██ ");
            Console.WriteLine("   ██   ██ ██    ██ ████   ██ ██       ██      ██    ██ ████   ██ ");
            Console.WriteLine("   ██   ██ ██    ██ ██ ██  ██ ██   ███ █████   ██    ██ ██ ██  ██ ");
            Console.WriteLine("   ██   ██ ██    ██ ██  ██ ██ ██    ██ ██      ██    ██ ██  ██ ██ ");
            Console.WriteLine("   ██████   ██████  ██   ████  ██████  ███████  ██████  ██   ████ ");
            Console.WriteLine("");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine("                       PRESS ANYKEY TO START                       ");
            Console.WriteLine(" ==================================================================");
            Console.ReadKey();
        }

        private static void GameDataSetting()
        {
            //Monster
            monsters = new Monster[4];
            monsters[0] = new Monster("탕후루", 2, 15, 5);
            monsters[1] = new Monster("떡볶이", 3, 25, 9);
            monsters[2] = new Monster("대창", 5, 20, 8);
            monsters[3] = new Monster("콜라", 1, 10, 7);

            //Skill
            skills = new Skill[5];
            skills[0] = new Skill("X", "스킬을 아직 배우지 못했습니다.");
            skills[1] = new Skill("알파 스트라이크", "공격력의 3배로 하나의 적을 공격합니다.", 3, 20, 1);
            skills[2] = new Skill("더블 스트라이크", "공격력의 1.5배로 2명의 적을 랜덤으로 공격합니다.", 1.5f, 10, 2);
            skills[3] = new Skill("에너지 볼트", "공격력의 2배로 하나의 적을 공격합니다.", 2, 20, 1);
            skills[4] = new Skill("체인 라이트닝", "공격력의 변화는 없지만 3명의 적을 랜덤으로 공격합니다", 1, 10, 3);

            //Job
            jobs = new Job[3];
            jobs[0] = new Job("초보자", skills[0]);
            jobs[1] = new Job("헬스트레이너", 15, 10, 200, 50, skills[1], skills[2]);
            jobs[2] = new Job("식품영양사", 10, 10, 150, 100, skills[3], skills[4]);
        }

        private static void PlayerSetting()
        {
            Console.Clear();
            Console.WriteLine("");
            var existPlayer = FileUtil.ExistPlayer();
            if (existPlayer)
            {
                Console.WriteLine("1. 새로 만들기");
                Console.WriteLine("2. 저장된 플레이어 불러오기");
                Console.WriteLine("");
                switch (CheckInput(1, 2))
                {
                    case 1:
                        CreatePlayer();
                        break;
                    case 2:
                        player = FileUtil.LoadPlayer();
                        break;
                }
            }
            else
            {
                CreatePlayer();
            }
        }

        private static void CreatePlayer()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("캐릭터의 이름을 입력해주세요.");
            Console.WriteLine("");
            Console.Write(">> ");

            string Name = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("캐릭터의 직업을 선택해주세요.");
            Console.WriteLine("");
            Console.WriteLine("1. 헬스트레이너");
            Console.WriteLine("2. 식품영양사");

            switch (CheckInput(1, 2))
            {
                case 1:
                    player = new Player($"{Name}", 1, jobs[1]);
                    break;
                case 2:
                    player = new Player($"{Name}", 1, jobs[2]);
                    break;
            }
        }


        // Menu
        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
            Console.WriteLine("");
            Console.WriteLine("다이어트 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
            Console.WriteLine("");

            Console.WriteLine("< 다이어트 마을 >\n");
            Console.WriteLine("[활동 선택]\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 던전 입장");
            Console.WriteLine("3. 휴식 하기");
            Console.WriteLine("4. 게임 종료");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(1, 4))
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    BattleInfo("[다이어트 던전]");
                    BattleStart();
                    break;
                case 3:
                    Rest();
                    break;
                case 4:
                    Console.WriteLine("■ 게임을 종료합니다 ■");
                    FileUtil.SavePlayer(player);
                    return;
            }
        }

        private static void StatusMenu()
        {
            Console.Clear();

            ShowHighlightedText(" [상태 보기]");
            Console.WriteLine(" 캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            PrintTextwithHighlights(" Lv. ", player.Level.ToString("00")); // 01, 07      
            PrintTextwithHighlights(" EXP : ", player.Exp.ToString());
            PrintTextwithHighlights(" 이름 : ", player.Name);
            PrintTextwithHighlights(" 직업 : ", player.Job.JobName);
            PrintTextwithHighlights(" 공격력 : ", player.Atk.ToString());
            PrintTextwithHighlights(" 방어력 : ", player.Def.ToString());
            PrintTextwithHighlights(" HP : ", player.Hp.ToString());
            PrintTextwithHighlights(" MP : ", player.Mp.ToString());
            PrintTextwithHighlights(" GOLD : ", player.Gold.ToString(), " G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
            }
        }

        private static void Rest()
        {
            int minusGold = 500;

            Console.Clear();

            ShowHighlightedText(" [목욕탕 - 휴식]");
            Console.WriteLine();

            if (player.Hp != player.Job.Hp)
            {
                if(player.Gold >= minusGold)
                {
                    Console.WriteLine(" 체력이 회복되었습니다.");
                    Console.WriteLine($" {player.Name}의 Gold가 {minusGold} G 소모되었습니다.");
                    player.Hp = player.Job.Hp;
                    player.Gold -= minusGold;
                }
                else
                {
                    Console.WriteLine(" Gold가 부족합니다.");
                }
            }
            else
            {
                Console.WriteLine(" 이미 체력이 가득 차 있습니다.");
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
            }
        }

        // Info
        private static void BattleInfo(string dungeonName)
        {
            Console.Clear();

            Console.WriteLine("");
            ShowHighlightedText($" {dungeonName}");
            Console.WriteLine("");
        }

        private static void PlayerInfo(int originlevel = 0)
        {
            Console.WriteLine();
            Console.WriteLine(" [내 정보]");

            if(originlevel != 0 && player.Level != originlevel)
            {
                Console.Write($" Lv.{originlevel} {player.Name} ({player.Job.JobName}) ->");
                PrintTextwithHighlights("",$" Lv.{player.Level}",$" {player.Name} ({player.Job.JobName})");
            }
            else
            {
                Console.WriteLine($" Lv.{player.Level} {player.Name} ({player.Job.JobName})");
            }

            Console.WriteLine(" HP {0}/{1}", player.Hp, player.Job.Hp);
            Console.WriteLine(" MP {0}/{1}", player.Mp, player.Job.Mp);
        }

        private static void MonsterInfo(bool battle = true)
        {
            Console.WriteLine(" [몬스터 정보]");

            for (int i = 0; i < count; i++)
            {
                if (battle == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" {i + 1}");
                    Console.ResetColor();
                }
                spawnMonsters[i].MonsterDescription();
            }
        }

        public static void SkillInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("1");
            Console.ResetColor();
            PrintTextwithHighlights($". {player.Job.skill1.SkillName} - MP ", player.Job.skill1.SkillMp.ToString(), "", ConsoleColor.Cyan);
            Console.WriteLine($"   {player.Job.skill1.SkillDescription}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("2");
            Console.ResetColor();
            PrintTextwithHighlights($". {player.Job.skill2.SkillName} - MP ", player.Job.skill2.SkillMp.ToString(), "", ConsoleColor.Cyan);
            Console.WriteLine($"   {player.Job.skill2.SkillDescription}");
        }


        // Battle
        private static void BattleStart()
        {
            // Monster Setting
            count = new Random().Next(1, 5);
            spawnMonsters = new Monster[count];

            for (int i = 0; i < count; ++i)
            {
                int idx = new Random().Next(0, 4);
                spawnMonsters[i] = new Monster(monsters[idx]);
            }

            MonsterInfo(false);

            PlayerInfo();

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 전투 시작");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(0, 1))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    BattleInfo("Battle!!");
                    PlayerPhase();
                    break;
            }

        }

        private static void PlayerPhase()//PlayerAttack->PlayerPhase
        {
            MonsterInfo();

            PlayerInfo();

            Console.WriteLine("");
            Console.WriteLine("1. 일반 공격");
            Console.WriteLine("2. 스킬 공격");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(1, 2))
            {
                case 1:
                    PlayerAttack();
                    break;
                case 2:
                    PlayerSkillAttack();
                    break;
            }
        }

        private static void PlayerAttack(bool skill = false)
        {
            Console.WriteLine("■ 공격할 대상의 번호를 입력해주세요 ■");

            int CheckValue = CheckInput(0, count);

            switch (CheckValue)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (spawnMonsters[CheckValue - 1].Hp <= 0)
                    {
                        Console.WriteLine("이미 죽은 몬스터 입니다.");
                        Console.WriteLine("다시 입력해주세요.");
                        Console.ReadKey();
                        BattleInfo("Battle!!");
                        PlayerPhase();
                        break;
                    }
                    else if (skill == true) //스킬공격
                    {
                        player.SkillAttack(spawnMonsters[CheckValue - 1], player.Job.skill1);
                        player.Mp -= player.Job.skill1.SkillMp;
                        break;
                    }
                    else
                    {
                        player.Attack(spawnMonsters[CheckValue - 1]);
                        break;
                    }
            }

            Console.WriteLine("1. 다음턴");

            switch (CheckInput(1, 1))
            {
                case 1:
                    BattleInfo("Battle!!");
                    MonsterAttack();
                    break;
            }
        }

        private static void PlayerSkillAttack()
        {         
            Console.WriteLine("[스킬 선택]");
            Console.WriteLine();

            SkillInfo();

            switch (CheckInput(1, 2))
            {
                case 1:
                    if(player.Job.skill1.TargetCount == 1)
                    {
                        PlayerAttack(true);
                        break;
                    }
                    else
                    {
                        PlayerMultySkillAttack(player.Job.skill1);
                        break;
                    }
                case 2:
                    if (player.Job.skill2.TargetCount == 1)
                    {
                        PlayerAttack(true);
                        break;
                    }
                    else
                    {
                        PlayerMultySkillAttack(player.Job.skill2);
                        break;
                    }
            }
        }

        private static void PlayerMultySkillAttack(Skill playerSkill)
        {
            int[] rand;

            rand = new int[playerSkill.TargetCount];
            for (int i = 0; i < playerSkill.TargetCount; i++)
            {
                if (spawnMonsters.All(x => x.Hp == 0))
                {
                    player.Mp -= playerSkill.SkillMp;
                    break;
                }
                else
                {
                    rand[i] = new Random().Next(0, count);
                    while (spawnMonsters[rand[i]].Hp <= 0)
                    {
                        rand[i] = new Random().Next(0, count);
                    }
                    player.SkillAttack(spawnMonsters[rand[i]], playerSkill);
                }
            }
            player.Mp -= playerSkill.SkillMp;

            Console.WriteLine("1. 다음턴");

            switch (CheckInput(1, 1))
            {
                case 1:
                    BattleInfo("Battle!!");
                    MonsterAttack();
                    break;
            }
        }

        private static void MonsterAttack()
        {
            bool result = spawnMonsters.All(x => x.Hp == 0);

            if (result)
            {
                Victory();
                return;
            }
            if (player.Hp <= 0)
            {
                Lose();
                return;
            }
            for (int i = 0; i < count; i++)
            {
                if (spawnMonsters[i].Hp > 0)
                    spawnMonsters[i].Attack(player);
            }

            Console.WriteLine("1. 다음턴");

            switch (CheckInput(1, 1))
            {
                case 1:
                    BattleInfo("Battle!!");
                    PlayerPhase();
                    break;
            }
        }


        // Win / Lose
        private static void Victory()
        {
            BattleInfo("Battle!! - Result");

            ShowHighlightedText(" Victory", ConsoleColor.Green);

            Console.WriteLine("");
            Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다.", count);

            LevelUp();

            Console.WriteLine("");
            ShowHighlightedText(" [아이템 획득]");

            int plusGold = (count * 500);
            player.Gold += plusGold;

            Console.WriteLine(" {0} Gold", plusGold);

            Console.WriteLine("");
            Console.WriteLine("1. 시작화면");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(1, 1))
            {
                case 1:
                    StartMenu();
                    return;
            }
        }

        private static void LevelUp()
        {
            int originExp = player.Exp;
            int originLevel = player.Level;

            for (int i = 0; i < count; i++)
            {
                player.Exp += spawnMonsters[i].Level;
            }

            if (player.Exp >= 10)
            {
                player.Level = 2;
                player.Atk += 0.5f;
                player.Def += 1;
            }
            if (player.Exp >= 35)
            {
                player.Level = 3;
                player.Atk += 0.5f;
                player.Def += 1;
            }
            if (player.Exp >= 65)
            {
                player.Level = 4;
                player.Atk += 0.5f;
                player.Def += 1;
            }
            if (player.Exp >= 100)
            {
                player.Level = 5;
                player.Atk += 0.5f;
                player.Def += 1;
            }

            PlayerInfo(originLevel);
            PrintTextwithHighlights($" Exp {originExp} -> ", $"{player.Exp}");
        }

        private static void Lose()
        {
            BattleInfo("Battle!! - Result");

            ShowHighlightedText(" You Lose", ConsoleColor.Red);
                        
            PlayerInfo();

            Console.WriteLine("");
            Console.WriteLine("1. 시작화면");

            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckInput(1, 1))
            {
                case 1:
                    StartMenu();
                    return;
            }
        }


        //Input Check
        private static int CheckInput(int min, int max)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write(">> ");
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (min <= ret && ret <= max)
                    {
                        Console.WriteLine("");
                        return ret;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
            }

        }

        //Text Color
        private static void PrintTextwithHighlights(string s1, string s2, string s3 = "", ConsoleColor color = ConsoleColor.Green)
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        private static void ShowHighlightedText(string text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}