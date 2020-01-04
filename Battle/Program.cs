using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Player player = new Player();
            p.CreateCharacter(player);
            p.GameLoop(player);
        }

        public  void CreateCharacter(Player player)
        {
            Console.WriteLine("Enter your name: ");
            player.Name = Console.ReadLine();
            Console.WriteLine("Enter your race: ");
            player.Race = Console.ReadLine();
            Console.WriteLine("Enter your class: ");
            player.Class = Console.ReadLine();
            player.Health = 100;
            player.Weapon = "Sword";
            player.Damage = 20;
            Console.Clear();
        }

        public int DamageDealt(int weaponDamage)
        {
            Random r = new Random();
            int damageDealt = r.Next(weaponDamage / 2, weaponDamage);
            return damageDealt;
        }

        public int RandomSelector(int rand)
        {
            Random r = new Random();
            int selection = r.Next(1, rand);
            return selection;
        }

        public int PlayerTurn(Player player, Enemy e1, int eoutput)
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}s Health: {player.Health}                                                       {e1.GetName()}s Health: {e1.GetHealth()}");
            Console.WriteLine($"{player.Name}s Turn\n");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine($"Enter '1' to attack with your {player.Weapon}");
            Console.WriteLine("Enter '2' to block");
            string str = "";
            int caseSwitch;
            do
            {
                str = Console.ReadLine();
            } while (!int.TryParse(str, out caseSwitch));

            switch (caseSwitch)
            {
                case 1:
                    int damageDealt = DamageDealt(player.Damage);
                    Console.WriteLine($"You swing your {player.Weapon} and deal {damageDealt} damage.");
                    if (eoutput == 2)
                    {
                        Console.WriteLine($"The {e1.GetName()}s' shield lessens the blow!");
                        e1.SetHealth(e1.GetHealth() - (damageDealt / 2));
                    }
                    else
                    {
                        e1.SetHealth(e1.GetHealth() - damageDealt);
                    }
                    return 1;
                case 2:
                    Console.WriteLine("You raise your shield and ready for impact.");
                    return 2;
                default:
                    Console.WriteLine("Error: Invalid Input");
                    return 0;
            }
        }

        public int EnemyTurn(Player player, Enemy e1, int poutput)
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}s Health: {player.Health}                                                       {e1.GetName()}s Health: {e1.GetHealth()}");
            Console.WriteLine($"{e1.GetName()}s Turn\n");
            int caseSwitch = RandomSelector(2);
            switch (caseSwitch)
            {
                case 1:
                    int damageDealt = DamageDealt(e1.GetDamage());
                    Console.WriteLine($"The {e1.GetName()} swings his {e1.GetWeapon()} and deals {damageDealt} damage.");
                    if(poutput == 2)
                    {
                        Console.WriteLine("Your shield lessens the blow!");
                        player.Health -= damageDealt/2;
                    }
                    else
                    {
                        player.Health -= damageDealt;
                    }
                    return 1;
                case 2:
                    Console.WriteLine($"The {e1.GetName()} raises his shield and readies for impact.");
                    return 2;
                default:
                    Console.WriteLine("Default case");
                    return 0;
            }
        }

        public Enemy SelectBattle()
        {
            switch (RandomSelector(4))
            {
                case 1:
                    Enemy Orc = new Enemy("Orc", "Wooden Club", 50, 10);
                    return Orc;
                case 2:
                    Enemy Goblin = new Enemy("Goblin", "Rusty Iron Dagger", 30, 10);
                    return Goblin;
                case 3:
                    Enemy Skeleton = new Enemy("Skeleton", "Wooden Bow", 40, 15);
                    return Skeleton;
                default:
                    Console.WriteLine("Error: No enemy");
                    Enemy Error = new Enemy("Orc", "Wooden Club", 50, 10);
                    return Error;
            }
        }

        public void GameLoop(Player player)
        {
            do
            {
                Console.WriteLine("Are you ready for your next battle?\nY or N");
                ConsoleKeyInfo readyCheck;
                char ready;
                readyCheck = Console.ReadKey();
                ready = readyCheck.KeyChar;
                ready = char.ToLower(ready);
                if (ready == 'y')
                {
                    Console.Clear();
                    Battle(player, SelectBattle());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{player.Name} the {player.Race} {player.Class} returns home after a day of adventuring.");
                    Console.ReadLine();
                    break;
                }
            } while (true);
        }

        public void Battle(Player player, Enemy e1)
        {
            int poutput = 0;
            int eoutput = 0;
            string eName = e1.GetName().ToLower();
            string aOrAn;
            if(eName[0] == 'a' || eName[0] == 'e' || eName[0] == 'i' || eName[0] == 'o' || eName[0] == 'u')
            {
                aOrAn = "an";
            }
            else
            {
                aOrAn = "a";
            }
            Console.WriteLine($"You encounter {aOrAn} {e1.GetName()} whilst adventuring!");
            Console.WriteLine("Let the battle begin!");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            do
            {
                if (player.Health > 0)
                {
                    poutput = PlayerTurn(player, e1, eoutput);
                }
                else
                {
                    break;
                }
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                if (e1.GetHealth() > 0)
                {
                    eoutput = EnemyTurn(player, e1, poutput);
                }
                else
                {
                    break;
                }
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();

            } while (player.Health > 0 || e1.GetHealth() > 0);
            Console.Clear();
            if(player.Health <= 0)
            {
                Console.WriteLine($"You have been defeated by {aOrAn} {e1.GetName()}!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"The {e1.GetName()} has been slain by the mighty {player.Race} {player.Class}, {player.Name}!");
                Console.ReadLine();
            }
            Console.Clear();
        }
    }
}
