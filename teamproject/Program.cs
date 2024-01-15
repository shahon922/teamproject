using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DietDungeon
{
    
    internal class Program
    {
        static Character player;
        static Monster[] monsters;
        static Monster[] spawnMonsters;


        static void Main(string[] args)
        {
            PrintStartLogo();
            GameDataSetting();
            StartMenu();
        }

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
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" 캐릭터의 이름을 입력해주세요.");
            Console.WriteLine("");
            Console.Write(" >> ");
            string Name = Console.ReadLine();

            player = new Character($"{Name}", "초보자", 1, 10, 5, 100, 1500);

            monsters = new Monster[3];
            monsters[0] = new Monster("탕후루", 2, 15, 5);
            monsters[1] = new Monster("떡볶이", 3, 25, 9);
            monsters[2] = new Monster("대창", 5, 20, 8);

        }

        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽");
            Console.WriteLine("");
            Console.WriteLine("다이어트 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽");
            Console.WriteLine("");

            Console.WriteLine("< 다이어트 마을 >\n");
            Console.WriteLine("[활동 선택]\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("3. 게임 종료");
            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckValidInput(1, 3))
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    BattleStart();
                    break;
                case 3:
                    return;
            }
        }

        private static void StatusMenu()
        {
            Console.Clear();

            ShowHighlightedText("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            PrintTextwithHighlights("Lv. ", player.Level.ToString("00")); // 01, 07
            Console.WriteLine("{0} ( {1} )", player.Name, player.Job);
            PrintTextwithHighlights("공격력 : ", player.Atk.ToString());
            PrintTextwithHighlights("방어력 : ", player.Def.ToString());
            PrintTextwithHighlights("체력 : ", player.Hp.ToString());
            PrintTextwithHighlights("Gold : ", player.Gold.ToString(), " G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckValidInput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
            }
        }

        private static void BattleStart()
        {
            Console.Clear();

            Console.WriteLine("");
            ShowHighlightedText(" Battle!!");
            Console.WriteLine("");


            int count = new Random().Next(1, 5);
            /*int[] attacktargets = new int[4];*/ //박창현추가
            int[] attacktargets = new int[4];
            spawnMonsters = new Monster[count];

            Console.WriteLine(" [몬스터 정보]");
            for (int i = 0; i < count; ++i)
            {
                int idx = new Random().Next(0, 3);
                monsters[idx].MonsterDescription();
                spawnMonsters[i] = new Monster(monsters[idx]);

                attacktargets[i] = idx; //박창현추가
            }

            Console.WriteLine();
            Console.WriteLine(" [내 정보]");
            Console.WriteLine($" Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine(" HP {0}/100", player.Hp.ToString());//100부분 {1}로 바꿔서 써도 될거같아요

            Console.WriteLine("");
            Console.WriteLine("1. 공격");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckValidInput(1, 1))
            {
                case 1:
                    Attack(count, spawnMonsters); //박창현추가
                    break;
            }

        }



        private static void Attack(int count, Monster[] monster) //박창현추가
        {
            Console.Clear();

            Console.WriteLine("");
            ShowHighlightedText(" Battle!!");
            Console.WriteLine("");

            for (int i = 0; i < count; i++) //
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{i + 1}");
                Console.ResetColor();
                spawnMonsters[i].MonsterDescription(); //랜덤으로 소환된 몬스터 개체수
            }
            Console.WriteLine();
            Console.WriteLine(" [내 정보]");
            Console.WriteLine($" Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine(" HP {0}/100", player.Hp.ToString());//100부분 {1}로 바꿔서 써도 될거같아요

            Console.WriteLine("");
            Console.WriteLine("1. 공격");
            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            switch (CheckValidInput(1, 1))
            {
                case 1:
                    AttackPhase(count, spawnMonsters); 
                    break;
            }
        }

        static void AttackPhase(int count, Monster[] monster) //박창현 추가
        {
            Console.Clear();

            Console.WriteLine("");
            ShowHighlightedText(" Battle!!");
            Console.WriteLine("");

            for (int i = 0; i < count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($" {i + 1}");
                Console.ResetColor();
                spawnMonsters[i].MonsterDescription();
            }
            Console.WriteLine();

            Console.WriteLine("0. 취소");
            Console.WriteLine();

            Console.WriteLine("대상을 선택해주세요.");
            //Console.Write(">> ");

            int CheckValue = CheckValidInput(0, count);

            switch (CheckValue)
            {
                case 0:
                    Attack(count, spawnMonsters);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if (spawnMonsters[CheckValue - 1].Hp <= 0)
                    {
                        Console.WriteLine("이미 죽은 몬스터 입니다");
                        _ = (count, spawnMonsters);
                    }
                    player.Attack(spawnMonsters[CheckValue - 1]);
                    break;
            }
            
            Console.WriteLine("1. 다음턴");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            switch (CheckValidInput(1, 1))
            {
                case 1:
                    EnemyPhase(count, spawnMonsters);
                    break;
            }

            //Console.WriteLine("대상을 선택해주세요.");
            //Console.Write(">> ");
            //var command = Convert.ToInt32(Console.ReadLine());
            //if (command != 0)
            //{
            //    var attackEnemyIndex = command - 1;
            //    if (attackEnemyIndex < 0 || 
            //         attackEnemyIndex >= count ||
            //         monsters[attacktargets[attackEnemyIndex]].Hp <= 0)
            //        
            //    {
            //        Console.WriteLine("잘못된 입력입니다.");
            //    }
            //    else
            //    {
            //        player.Attack(monsters[attacktargets[attackEnemyIndex]]);
            //    }
            //
            //}
        }

        private static void EnemyPhase(int count, Monster[] monster)
        {
            Console.Clear();

            bool result = spawnMonsters.All(x => x.Hp == 0);

            Console.WriteLine("");
            ShowHighlightedText(" Battle!!");
            Console.WriteLine("");

            for (int i = 0; i < count; i++)
            {
                if(result)
                {
                    Victory(count);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($" {i + 1}");
                    Console.ResetColor();
                    spawnMonsters[i].MonsterDescription(); //랜덤으로 소환된 몬스터 개체수

                    Console.WriteLine();
                    Console.WriteLine(player.Hp);
                    Random rand = new Random();

                    if (spawnMonsters[i].Hp <= 0)
                    {
                        Console.WriteLine("이미 죽은 몬스터 입니다");
                        _ = (count, spawnMonsters);
                        continue;
                    }
                    spawnMonsters[i].Attack(player);
                }
                
            }

            if(player.Hp <= 0)
            {
                Lose();
            }

            Console.WriteLine("");
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            Console.WriteLine("대상을 선택해주세요.");
            //Console.WriteLine(">>");

            int CheckValue = CheckValidInput(0, count);

            switch (CheckValue)
            {
                case 0:
                    AttackPhase(count, spawnMonsters);
                    break;
            }   
        }

        private static void Victory(int count)
        {
            Console.Clear();
            ShowHighlightedText("Battle!! - Result");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Victory");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다.", count);

            Console.WriteLine("");
            Console.WriteLine(" [내 정보]");
            Console.WriteLine($" Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine(" HP {0}/100", player.Hp.ToString());//100부분 {1}로 바꿔서 써도 될거같아요

            Console.WriteLine("");
            Console.WriteLine("1. 시작화면");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            switch (CheckValidInput(1, 1))
            {
                case 1:
                    StartMenu(); // 전투가 끝나면 startmenu로 이동
                    break;
            }
        }

        private static void Lose()
        {
            Console.Clear();
            ShowHighlightedText("Battle!! - Result");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Lose");
            Console.ResetColor();
            Console.WriteLine("");

            Console.WriteLine();
            Console.WriteLine(" [내 정보]");
            Console.WriteLine($" Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine(" HP {0}/100", player.Hp.ToString());//100부분 {1}로 바꿔서 써도 될거같아요

            Console.WriteLine("");
            Console.WriteLine("1. 시작화면");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            switch (CheckValidInput(1, 1))
            {
                case 1:
                    StartMenu();// 전투가 끝나면 startmenu로 이동
                    break;
            }
        }



        private static void PrintTextwithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        private static void ShowHighlightedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static int CheckValidInput(int min, int max)
        {
            // 아래 두 가지 상황은 비정상 -> 재입력 수행
            // (1) 숫자가 아닌 입력을 받은 경우
            // (2) 숫자가 최소값 ~ 최대값의 범위를 넘는 경우

            //Console.WriteLine("원하시는 행동을 입력해주세요.");

            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (min <= ret && ret <= max)
                        return ret;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
            }

        }




    }
}