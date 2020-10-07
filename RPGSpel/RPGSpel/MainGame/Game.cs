﻿using RPGSpel.NPC;
using System;
using System.Security.Claims;
using System.Threading;

namespace PepsiMan
{
    class Game
    {
        public GameWorld MyWorld;
        public Player CurrentPlayer;
        public Enemy CurrentEnemy;
        public Enemy CurrentEnemy2;
        public HealthPotion CurrentHP;
        public HealthPotion CurrentHP2;
        public Throwingstar SpecialAtt;
        public Armor CurrentArmor;
        public Note CurrentNote;
        public Enemy CurrentEnemy3;
        public Shopkeep CurrentShopKeep;
        public Chest CurrentChest;

        public void Start()
        {
            Console.Title = "The Game";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            string[,] grid =
            {

                { "╔", "═", "═", "═", "═", "═", "═", "═", "╦", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "╦", "═", "═", "═", "═","═", "═","╗" },
                { "║", "H", "O", "M", "E", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "S", "T", "O", "R", "E", "║", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "╚", "═", "═", " ", " ","═", "═","╣" },
                { "║", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "╠", "═", "═", "═", "═", "═", "═", "═", "╝", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "B", "O", "S", "S", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "╔", "═", "═", "═", " ", " ", "═","═", "═","╣" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "╚", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "╩", "═", "═", "═", "═", "═", "═","═", "═","╝" },
            };


            MyWorld = new GameWorld(grid);

            CurrentEnemy = new Enemy(4, 8);
            CurrentEnemy2 = new Enemy(26, 21);
            CurrentPlayer = new Player(6, 3);
            CurrentHP = new HealthPotion(10, 9);
            CurrentHP2 = new HealthPotion(4, 20);
            SpecialAtt = new Throwingstar(16, 2);
            CurrentArmor = new Armor(26, 15);
            CurrentNote = new Note(1, 5);
            CurrentEnemy3 = new Enemy(6, 15);
            CurrentShopKeep = new Shopkeep(31, 1);
            CurrentChest = new Chest(4, 15);

            RunGameLoop();
        }

        // Ritar upp alla karaktärer i spelvärlden.
        private void DrawFrame()
        {
            Console.Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
            CurrentEnemy.Draw();
            CurrentHP.Draw();
            CurrentHP2.Draw();
            CurrentEnemy2.Draw();
            SpecialAtt.Draw();
            CurrentArmor.Draw();
            CurrentNote.Draw();
            CurrentEnemy3.Draw();
            CurrentShopKeep.Draw();
            CurrentChest.Draw();
        }

        // Visar upp startrutan och ingenting annat, första som syns i konsolen.
        public void GameStartScreen()
        {
            Console.WriteLine("Välkommen till vårt spel!");
            Console.WriteLine("\nInstruktioner");
            Console.WriteLine("- Använd piltangenterna för att förflytta dig i världen");
            Console.WriteLine("- Special - Står för din speciella 'attack-move', i detta fall en Kaststjärna");
            Console.WriteLine("- Attack  - Du attackar med ditt vapen.");
            Console.WriteLine("- Run     - Du försöker fly från fienden. (50/50-chans att du överlever.)");
            Console.WriteLine("- Heal    - Du använder en HP-Potion för att få tillbaka lite av din HP.");
            Console.WriteLine("\nTryck på valfri tangent för att starta spelet.");
            Console.ReadKey(true);
        }

        // Visar upp Game-Over rutan.
        public void GameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("Du dog!");
            Console.WriteLine("Tack för att du spela!");

            Console.WriteLine("\n---- Credits: ----");
            Console.WriteLine("Hafsa");
            Thread.Sleep(1000);
            Console.WriteLine("Linus");
            Thread.Sleep(1000);
            Console.WriteLine("Och Sebastian");
            Thread.Sleep(1000);

            Console.WriteLine("\nTryck på valrfi tangent för att avsluta.");
            Console.ReadKey(true);

        }


        static Random rng = new Random();

        public static void Chest()
        {
            Console.Clear();
            Console.WriteLine("Du vandrar längs vägen och hittar en gammal skrutten kista, i bältet kommer du på att du har en dolk, du tar fram den och knäcker upp låset");
            Console.WriteLine("I kistan hittar du 15 coins!");
            Program.currentPlayer.coins += 15;
            Console.WriteLine("Du har nu : " + Program.currentPlayer.coins + " coins i din läderpung");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
        }

        public static void Store()
        {
            string input;

            Console.Clear();
            Console.WriteLine("Hej där främling! Är du här för att köpa något?");
            Console.WriteLine("---- (J)a ---- (N)ej ----");
            input = Console.ReadLine();

            if (input.ToLower() == "j")
            {
                Console.Clear();
                Console.WriteLine("Alright! Vad vill du köpa?");
                Console.WriteLine("");
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("║(K)aststjärna - 10c ║");
                Console.WriteLine("║(A)rmor       - 20c ║");
                Console.WriteLine("║                    ║");
                Console.WriteLine("╚════════════════════╝");
                Console.WriteLine("");
                string a = Console.ReadLine();
                if (a.ToLower() == "k" && Program.currentPlayer.coins >= 10)
                {
                    Console.Clear();
                    Program.currentPlayer.special += 1;
                    Program.currentPlayer.coins -= 10;
                    Console.WriteLine("Du har nu köpt en kaststjärna!");
                    Console.WriteLine("Du har nu : " + Program.currentPlayer.special + " kaststjärnor i ditt bälte");
                    Console.ReadKey();
                }
                else if (a.ToLower() == "a" && Program.currentPlayer.coins >= 20)
                {
                    Console.Clear();
                    Program.currentPlayer.armorValue += 1;
                    Program.currentPlayer.coins -= 20;
                    Console.WriteLine("Du har nu köpt en armor!");
                    Console.WriteLine("Du har nu rustningsvärde: " + Program.currentPlayer.armorValue);
                    Console.ReadKey();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Inte tillräckligt med coins, kom tillbaka när du kan betala!");
                    Console.ReadKey();
                }
            }
            else if (input.ToLower() == "n")
            {
                Console.Clear();
                Console.WriteLine("Okej då, sluta då störa mig.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ursäkta?");
                Console.ReadKey();
            }
        }

        public static void FirstEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du vandrar längs med en stig och skymtar något längre upp samma stig, \nDu försöker göra så lite ljud som möjligt men råkar trampa på en död kvist..");
            Console.WriteLine("Han vänder sig om..");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Raider", 1, 8);
        }

        public static void SecondEncounter()
        {
            Console.Clear();
            Console.WriteLine("Bortom ett berg ser du att torn stiga upp, du beslutar dig för att gå över berget mot tornet..");
            Console.WriteLine("Äntligen där! Väl framme öppnar du dörren och går du upp för trapporna när du möter..");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Warlock", 4, 30);

        }

        public static void ThirdEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du stöter på en Zombie!");
            Console.WriteLine("Han springer fort mot dig och ni börjar attackera varandra!");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Zombie", 3, 6);
        }

        public static void HealthPotion()
        {
            Console.Clear();
            Console.WriteLine("Du hittar en lila lång glasflaska fylld med NOCCO-Tropial Edition! \nDrick denna dryck för att omedelbart få extra HP!");
            Console.WriteLine("En extra HP-potion har lagts till i din inventory.");
            Program.currentPlayer.HealthPotion += 1;
            Console.WriteLine("Du har nu: " + Program.currentPlayer.HealthPotion + " flaskor NOCCO i din säck.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void Note()
        {
            Console.Clear();
            Console.WriteLine("Du hittar ett kuvert vid din byrå med en handskriven lapp i: 'Blablablablabla(not yet completed)'.");
            Console.WriteLine("Du lägger den i din ficka sålänge.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void KastStjärna()
        {
            Console.Clear();
            Console.WriteLine("Du hittar en rostig men ändå i så pass bra skick att den kan användas!");
            Console.WriteLine("En extra kaststjärna har lagts till i din inventory.");
            Program.currentPlayer.special += 1;
            Console.WriteLine("Du har nu: " + Program.currentPlayer.special + " kaststjärnor i din säck.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void Armor()
        {
            Console.Clear();
            Console.WriteLine("Du hittar en gammal rostig kista med en NOCCO-Special Edition Body Armor!");
            Console.WriteLine("Du tar upp den, ruskar bort alla gamla löv och sätter på dig den.");
            Program.currentPlayer.armorValue += 1;
            Console.WriteLine("Ditt rustningsvärde har nu ökat med: " + Program.currentPlayer.armorValue + ".");
            Console.WriteLine("Du kommer nu kunna absorbera med skada från fiender!");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        public static void Battle(string name, int power, int health)
        {
            string enemyName = "";
            int enemyDmg = 0;
            int enemyHealth = 0;

            enemyName = name;
            enemyDmg = power;
            enemyHealth = health;


            while (enemyHealth > 0)
            {
                Console.Clear();
                Console.WriteLine("Enemy name: " + enemyName);
                Console.WriteLine("Enemy power: " + enemyDmg + " Enemy HP: " + enemyHealth);
                Console.WriteLine("");
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("║      (S)pecial     ║");
                Console.WriteLine("║      (A)ttack      ║");
                Console.WriteLine("║ (R)un       (H)eal ║");
                Console.WriteLine("╚════════════════════╝");
                Console.WriteLine("");
                Console.WriteLine("Health: " + Program.currentPlayer.playerHealth);
                Console.WriteLine("ArmorValue: " + Program.currentPlayer.armorValue);
                Console.WriteLine("\n--Inventory--");
                Console.WriteLine("Potions: " + Program.currentPlayer.HealthPotion);
                Console.WriteLine("Kaststjärnor: " + Program.currentPlayer.special);

                string input = Console.ReadLine();

                if (input.ToLower() == "a")
                {
                    Console.WriteLine("Du går till attack samtidigt som " + enemyName + "!");
                    int damage = enemyDmg - Program.currentPlayer.armorValue;

                    // spelaren attack slumpas fram mellan 0 och spelarens weaponvalue + ett tal mellan 1-4.
                    int playerAttackValue = rng.Next(0, Program.currentPlayer.wepValue) + rng.Next(1, 4);
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine("Du förlorar " + damage + " HP och ger: " + playerAttackValue + " i skada");

                    // uppdaterar spelaren HP.
                    Program.currentPlayer.playerHealth -= damage;

                    // uppdaterar fiendes HP.
                    enemyHealth -= playerAttackValue;
                    Console.WriteLine("Tryck på en knapp för att fortsätta.");

                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        break;
                    }

                }

                else if (input.ToLower() == "s")
                {
                    if (Program.currentPlayer.special == 0)
                    {
                        Console.WriteLine("Du drar din hand mot bältet där du förvarar dina stjärnor, men va? Ingenting där!");
                        int damage = enemyDmg - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Program.currentPlayer.playerHealth -= damage;
                        Console.WriteLine(enemyName + " träffar dig med att starkt slag och du förlorar " + damage + " health");


                    }
                    else
                    {
                        Console.WriteLine("Du backar tillbaka några steg och tar från din kaststjärna ur ditt bälte, du tar i och kastar den mot " + enemyName + ". \nEtt starkt slag!");
                        int attack = rng.Next(3, Program.currentPlayer.specialValue) + rng.Next(1, 2);
                        Program.currentPlayer.special -= 1;
                        int damage = enemyDmg - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du förlorar " + damage + " HP och ger: " + attack + " i skada");
                        Program.currentPlayer.playerHealth -= damage;
                        enemyHealth -= attack;
                        Console.WriteLine("Tryck på en knapp för att fortsätta");
                    }
                }

                else if (input.ToLower() == "r")
                {
                    if (rng.Next(0, 2) == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Du försöker fly från " + enemyName + ", han kastar sitt vapen mot dig" + "\noch träffar dig i ryggen.. du faller ner på marken och träffar huvudet illa");
                        Console.WriteLine("Du blöder ut och ditt äventyr är över..");
                        int damage = enemyDmg - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Program.currentPlayer.playerHealth = 0;
                        Console.ReadKey();
                        break;


                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du använder dina akrobatik-skills och lyckas med minsta möjliga marginal fly från " + enemyName + ".");
                        Console.ReadKey();
                        break;

                    }
                }
                else if (input.ToLower() == "h")
                {
                    if (Program.currentPlayer.HealthPotion == 0)
                    {
                        Console.WriteLine("Du börjar gräva i din väska efter en potion, men förgäves.. Det enda du hittar är en tom burk NOCCO.");
                        int damage = enemyDmg - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Program.currentPlayer.playerHealth -= damage;
                        Console.WriteLine(enemyName + " träffar dig med att starkt slag och du förlorar " + damage + " health");
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Du börjar ivrigt leta i din väska efter en HP-Potion..");
                        int potionValue = 5;
                        Console.WriteLine("Du får " + potionValue + " HP");
                        Program.currentPlayer.playerHealth += potionValue;
                        Program.currentPlayer.HealthPotion -= 1;
                        Console.WriteLine("Samtidigt som du grävde i väskan så skadade " + enemyName + " dig");
                        int damage = (enemyDmg / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du förlorade " + damage + " hp");
                        Console.WriteLine("Tryck på en knapp för att fortsätta");
                    }

                    Console.ReadKey();
                }


                if (enemyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Du dödade " + enemyName + "!!");
                    Console.WriteLine("Du böjer dig ner över din nu döda fiende som droppar en kaststjärna!" + "\nDu tar upp den och förvarar den i ditt bälte från och med nu.");
                    Program.currentPlayer.special += 1;
                    Console.WriteLine("\nPlayer HP = " + Program.currentPlayer.playerHealth);
                    Console.WriteLine("Potions = " + Program.currentPlayer.HealthPotion);
                    Console.WriteLine("Kaststjärnor = " + Program.currentPlayer.special);
                }
                Console.ReadKey();

            }
        }


        private void RunGameLoop()
        {
            GameStartScreen();
            while (true)
            {
                DrawFrame();
                HandlePlayerInput();

                if (CurrentPlayer.X == CurrentNote.X && CurrentPlayer.Y == CurrentNote.Y)
                {
                    Note();
                    CurrentNote.Draw();
                    CurrentNote = new Note(37, 27);
                    continue;

                }

                if (CurrentPlayer.X == CurrentArmor.X && CurrentPlayer.Y == CurrentArmor.Y)
                {
                    Armor();
                    CurrentArmor.Draw();
                    CurrentArmor = new Armor(35, 29);
                    continue;

                }

                if (CurrentPlayer.X == SpecialAtt.X && CurrentPlayer.Y == SpecialAtt.Y)
                {
                    KastStjärna();
                    SpecialAtt.Draw();
                    SpecialAtt = new Throwingstar(35, 28);
                    continue;

                }

                if (CurrentPlayer.X == CurrentHP2.X && CurrentPlayer.Y == CurrentHP2.Y)
                {
                    HealthPotion();
                    CurrentHP2.Draw();
                    CurrentHP2 = new HealthPotion(36, 27);
                    continue;
                }

                if (CurrentPlayer.X == CurrentHP.X && CurrentPlayer.Y == CurrentHP.Y)
                {
                    HealthPotion();
                    CurrentHP.Draw();
                    CurrentHP = new HealthPotion(35, 27);
                    continue;
                }

                if (CurrentPlayer.X == CurrentEnemy.X && CurrentPlayer.Y == CurrentEnemy.Y)
                {

                    CurrentEnemy.Draw();
                    CurrentEnemy = new Enemy(35, 26);
                    FirstEncounter();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                        continue;

                }

                if (CurrentPlayer.X == CurrentEnemy3.X && CurrentPlayer.Y == CurrentEnemy3.Y)
                {

                    CurrentEnemy3.Draw();
                    CurrentEnemy3 = new Enemy(37, 26);
                    ThirdEncounter();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                        continue;

                }

                if (CurrentPlayer.X == CurrentEnemy2.X && CurrentPlayer.Y == CurrentEnemy2.Y)
                { // när spelaren står på samma position som enemy2. så förflyttas karaktären utanför spelplanen. Sen tillkallas 
                  // 2ndencounter metoden, och i den finns battlemetoden....
                    CurrentEnemy2.Draw();
                    CurrentEnemy2 = new Enemy(36, 26);
                    SecondEncounter();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                        continue;

                }

                if (CurrentPlayer.X == CurrentShopKeep.X && CurrentPlayer.Y == CurrentShopKeep.Y)
                {
                    Store();
                    continue;
                }

                if (CurrentPlayer.X == CurrentChest.X && CurrentPlayer.Y == CurrentChest.Y)
                {
                    CurrentChest.Draw();
                    CurrentChest = new Chest(36, 24);
                    Chest();
                    continue;
                }

            }
        }
    }
}
