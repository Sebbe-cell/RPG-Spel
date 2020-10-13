using RPGSpel.NPC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PepsiMan
{
    class Game : Encounters

    {
        // Fields som ska ge plats för klass objekten när de instantieras.
        public GameWorld MyWorld;
        public Player CurrentPlayer;
        public Enemy EnemyOne;
        public Enemy Boss;
        public HealthPotion HealthPotionDrop;
        public HealthPotion HealthPotionDrop2;
        public Throwingstar SpecialAtt;
        public Armor ArmorDrop;
        public Note NoteDrop;
        public Enemy EnemyTwo;
        public Shopkeep ShopKeep;
        public Chest ChestDrop;
        public Enemy EnemyThree;
        public Enemy RiddleKeeper;
        public Chest ChestDropTwo;
        public QuestGiver QuestGiver1;
        public Pet Dog;
        public Prisoner PrisonerOne;

        public void Start()
        {
            Console.Title = "Sine Qua Non";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            string[,] grid =
            { 
                // 2D-Array som används som argument när draw metoden i GameWorld ska rita ut spelet.

                { "╔", "═", "═", "═", "═", "═", "═", "═", "╦", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "╦", "═", "═", "═", "═","═", "═","╗" },
                { "║", "H", "O", "M", "E", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "S", "T", "O", "R", "E", "║", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "╚", "═", "═", " ", " ","═", "═","╣" },
                { "║", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "╠", "═", "═", "═", "═", "═", "═", "═", "╝", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "╔", "═","═", "═","╣" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "╚", "═","═", "═","╣" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "B", "O", "S", "S", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "╔", "═", "═", "═", "═", " ", "═","═", "═","╣" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "║", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "║", " ", " ", " ", " ", " ", " "," ", " ","║" },
                { "╚", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "╩", "═", "═", "═", "═", "═", "═","═", "═","╝" },
            };

            // Objekt av de olika klasserna instantieras, med 2D-Array / Positioner som argument. 
            MyWorld = new GameWorld(grid);

            Random spawn = new Random();

            // Första integern symboliserar den Horisontella linjen
            // Andra integern symboliserar den Vertikala linjen

            CurrentPlayer = new Player(6, 1);
            EnemyOne = new Enemy(spawn.Next(2, 9), spawn.Next(8, 15));
            EnemyTwo = new Enemy(spawn.Next(2, 9), spawn.Next(16, 23));
            RiddleKeeper = new Enemy(30, 20);
            EnemyThree = new Enemy(30, 8);
            Boss = new Enemy(26, 21);
            ChestDrop = new Chest(spawn.Next(2,15), spawn.Next(8,15));
            ChestDropTwo = new Chest(32, 10);
            HealthPotionDrop = new HealthPotion(10, 9);
            HealthPotionDrop2 = new HealthPotion(4, 20);
            SpecialAtt = new Throwingstar(16, 2);
            ArmorDrop = new Armor(26, 15);
            NoteDrop = new Note(1, 5);
            ShopKeep = new Shopkeep(32, 1);
            QuestGiver1 = new QuestGiver(28, 2);
            Dog = new Pet(10, 1);
            PrisonerOne = new Prisoner(32, 22);

            RunGameLoop();
        }

      

        // Ritar upp  spelplanen och alla karaktärer i spelvärlden. Ingår i RunGameLoop().
        private void DrawFrame()
        {
            MyWorld.Draw();
            CurrentPlayer.Draw();
            EnemyOne.Draw();
            HealthPotionDrop.Draw();
            HealthPotionDrop2.Draw();
            Boss.Draw();
            SpecialAtt.Draw();
            ArmorDrop.Draw();
            NoteDrop.Draw();
            EnemyTwo.Draw();
            RiddleKeeper.Draw();
            ShopKeep.Draw();
            ChestDrop.Draw();
            EnemyThree.Draw();
            ChestDropTwo.Draw();
            QuestGiver1.Draw();
            Dog.Draw();
            PrisonerOne.Draw();
        }
        public void ChooseCharater()
        {

            string name;

            Console.WriteLine("Innan vi börjar så måste vi veta ditt namn, fyll i det nu:");
            Console.ForegroundColor = ConsoleColor.Green;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Program.currentPlayer.playerName = name;

            if (name == "")
            {
                Console.WriteLine("Du vill alltså hålla din identitet hemlig? Okej jag förstår..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Välkommen " + name + ". Nästa steg är att välja vilken karaktär du vill spela som.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            Console.Clear();
        again:
            Console.WriteLine("Välj vad du ska spela som:");
            Console.WriteLine("(O)rc - Stark karaktär med bra rustning, men fattig.");
            Console.WriteLine("(H)uman - Medelstark karaktär med bra HP och en del coins.");
            Console.WriteLine("(E)lf - Låg styrka men bra HP och mycket coins.");
            Console.WriteLine("(D)warf - Bra attackskada och lagom mycket coins.");
            string input = Console.ReadLine();
            Console.Clear();

            while (true)
            {

                if (input.ToLower() == "o")
                {
                    Program.currentPlayer.playerRace = "Orc";
                    Console.WriteLine("Rustningsvärde: " + (Program.currentPlayer.armorValue = 3));
                    Console.WriteLine("Player Health: " + (Program.currentPlayer.playerHealth = 10));
                    Console.WriteLine("Attack styrka: " + (Program.currentPlayer.wepValue = 2));
                    Console.WriteLine("Coins: " + (Program.currentPlayer.coins = 25));
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else if (input.ToLower() == "h")
                {
                    Program.currentPlayer.playerRace = "Human";
                    Console.WriteLine("Rustningsvärde: " + (Program.currentPlayer.armorValue = 1));
                    Console.WriteLine("Player Health: " + (Program.currentPlayer.playerHealth = 20));
                    Console.WriteLine("Attack styrka: " + (Program.currentPlayer.wepValue = 1));
                    Console.WriteLine("Coins: " + (Program.currentPlayer.coins = 60));
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else if (input.ToLower() == "d")
                {
                    Program.currentPlayer.playerRace = "Dwarf";
                    Console.WriteLine("Rustningsvärde: " + (Program.currentPlayer.armorValue = 1));
                    Console.WriteLine("Player Health: " + (Program.currentPlayer.playerHealth = 15));
                    Console.WriteLine("Attack styrka: " + (Program.currentPlayer.wepValue = 2));
                    Console.WriteLine("Coins: " + (Program.currentPlayer.coins = 45));
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else if (input.ToLower() == "e")
                {
                    Program.currentPlayer.playerRace = "Elf";
                    Console.WriteLine("Rustningsvärde: " + (Program.currentPlayer.armorValue = 0));
                    Console.WriteLine("Player Health: " + (Program.currentPlayer.playerHealth = 25));
                    Console.WriteLine("Attack styrka: " + (Program.currentPlayer.wepValue = 1));
                    Console.WriteLine("Coins: " + (Program.currentPlayer.coins = 80));
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input. Try again \nPress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    goto again;
                }
            }
            Console.Clear();
        }

        // Visar upp startrutan och ingenting annat, första som syns i konsolen.
        public void MainMenu()
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
            Console.Clear();
        }

        // Visar upp Game-Over rutan.
        public void GameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("Du dog!");
            Console.WriteLine("Tack för att du spela!");

            Console.WriteLine("\n---- Credits: ----");
            Console.WriteLine("Hafsa");
            Thread.Sleep(1000); // ger några ms mellan rum innan nästa mening kommer upp.
            Console.WriteLine("Linus");
            Thread.Sleep(1000);
            Console.WriteLine("Och Sebastian");
            Thread.Sleep(1000);

            Console.WriteLine("\nTryck på valrfi tangent för att avsluta.");
            Console.ReadKey(true);

        }

        public void LevelCompleted()
        {
            Console.Clear();
            Console.WriteLine("Du lyckades! Warlocken är död. Ni tar er båda ut ur fortet och börjar resan hemåt.");
            Thread.Sleep(2000);
            Console.WriteLine("\nTack för att du spelat vårt spel. \n---- Credits: ----");
            Console.WriteLine("Hafsa");
            Thread.Sleep(1000); // ger några ms mellan rum innan nästa mening kommer upp.
            Console.WriteLine("Linus");
            Thread.Sleep(1000);
            Console.WriteLine("Och Sebastian");
            Thread.Sleep(1000);

            Console.WriteLine("\nTryck på valrfi tangent för att avsluta.");
            Console.ReadKey(true);
        }

        // METOD med switch som hanterar inputen från användaren. Från de fyra piltangenterna.
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1)) // kollar först om positionen är
                    {                                                                     // möjlig att gå på. om den är det
                        CurrentPlayer.Y -= 1;                                             // returneras bool true. och spelaren rör
                    }                                                                     // sig bakåt i y led, dvs uppåt med en position.  
                    break;                                                                //osv..
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

        // METOD som håller igång spelet, med de andra relevanta metoderna i den.
        // GameStartScreen, DrawFrame, HandlePlayerInput.
        public void RunGameLoop()  
        {                           
            MainMenu(); // <- När spelet startas så dyker först startskärmen upp.

            ChooseCharater();

            Console.Clear(); // <- Raderar startskärmen från spelet och visar istället upp spelvärlden.

            while (true)
            {
                DrawFrame(); // <- Ritar upp spelvärlden.

                HandlePlayerInput(); // <- Hanterar spelarens input och hoppar in i If-statements när villkoren möts.;

                if (CurrentPlayer.X == NoteDrop.X && CurrentPlayer.Y == NoteDrop.Y)
                {
                    Note();
                    NoteDrop.Draw();
                    NoteDrop = new Note(37, 27);
                    continue;

                }

                if (CurrentPlayer.X == ArmorDrop.X && CurrentPlayer.Y == ArmorDrop.Y)
                {
                    Armor();
                    ArmorDrop.Draw();
                    ArmorDrop = new Armor(35, 29);
                    continue;

                }

                if (CurrentPlayer.X == SpecialAtt.X && CurrentPlayer.Y == SpecialAtt.Y)
                {
                    KastStjärna();
                    SpecialAtt.Draw();
                    SpecialAtt = new Throwingstar(35, 28);
                    continue;

                }

                if (CurrentPlayer.X == HealthPotionDrop2.X && CurrentPlayer.Y == HealthPotionDrop2.Y)
                {
                    HealthPotion();
                    HealthPotionDrop2.Draw();
                    HealthPotionDrop2 = new HealthPotion(36, 27);
                    continue;
                }

                if (CurrentPlayer.X == HealthPotionDrop.X && CurrentPlayer.Y == HealthPotionDrop.Y)
                {
                    HealthPotion();
                    HealthPotionDrop.Draw();
                    HealthPotionDrop = new HealthPotion(35, 27);
                    continue;
                }

                if (CurrentPlayer.X == EnemyOne.X && CurrentPlayer.Y == EnemyOne.Y)
                {

                    EnemyOne.Draw();
                    EnemyOne = new Enemy(35, 26);
                    FirstEncounter();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                        continue;

                }

                if (CurrentPlayer.X == EnemyThree.X && CurrentPlayer.Y == EnemyThree.Y)
                {

                    EnemyThree.Draw();
                    EnemyThree = new Enemy(38, 26);
                    Guard();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Påväg in i fortet så hittar du några coins på marken som du plockar upp.");
                        Program.currentPlayer.coins += 5;
                        Console.WriteLine("Du har nu: " + Program.currentPlayer.coins + " coins.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                }

                if (CurrentPlayer.X == EnemyTwo.X && CurrentPlayer.Y == EnemyTwo.Y)
                {

                    EnemyTwo.Draw();
                    EnemyTwo = new Enemy(37, 26);
                    ThirdEncounter();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                        continue;

                }

                // När spelaren står på samma position som enemy2 så förflyttas karaktären utanför spelplanen. Sen tillkallas
                // secondEncounter metoden, och i den finns battlemetoden....
                if (CurrentPlayer.X == Boss.X && CurrentPlayer.Y == Boss.Y)
                {
                    Boss.Draw();
                    Boss = new Enemy(36, 26);
                    BossFight();
                    if (Program.currentPlayer.playerHealth <= 0)
                    {
                        GameOverScreen();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Program.currentPlayer.key = 1;
                        Console.Clear();
                        Console.WriteLine("Du sliter av nycklarna till låset av Warlocken.");
                        Console.ReadKey();
                        continue;
                    }

                }

                if (CurrentPlayer.X == ShopKeep.X && CurrentPlayer.Y == ShopKeep.Y)
                {
                    Store();
                    continue;
                }

                if (CurrentPlayer.X == ChestDrop.X && CurrentPlayer.Y == ChestDrop.Y)
                {
                    ChestDrop.Draw();
                    ChestDrop = new Chest(36, 24);
                    Chest();
                    continue;
                }

                if (CurrentPlayer.X == ChestDropTwo.X && CurrentPlayer.Y == ChestDropTwo.Y)
                {
                    ChestDropTwo.Draw();
                    ChestDropTwo = new Chest(36, 29);
                    Chest();
                    continue;
                }

                if (CurrentPlayer.X == Dog.X && CurrentPlayer.Y == Dog.Y)
                {
                    Dog.Draw();
                    Dog = new Pet(35, 2);
                    Dog.PetColor = ConsoleColor.Black;
                    Pet();
                    continue;
                }

                if (CurrentPlayer.X == QuestGiver1.X && CurrentPlayer.Y == QuestGiver1.Y)
                {
                    Quest();
                    if (OldmansPet == 1 || OldmansJourny == 1)
                    {
                        QuestGiver1.Draw();
                        QuestGiver1 = new QuestGiver(35, 3);
                        QuestGiver1.QuestGiverColor = ConsoleColor.Black;
                    }
                    continue;
                }

                if (CurrentPlayer.X == RiddleKeeper.X && CurrentPlayer.Y == RiddleKeeper.Y)
                {
                    Riddle();
                    if (guess == answer)
                    {
                        RiddleKeeper.Draw();
                        RiddleKeeper = new Enemy(35, 3);
                        RiddleKeeper.EnemyColor = ConsoleColor.Black;
                        continue;
                    }
                    else if (guess != answer && numberOfGuesses == 0)
                    {
                        Battle("RiddleKeeper", 4, 15);
                        RiddleKeeper.Draw();
                        RiddleKeeper = new Enemy(35, 3);
                        RiddleKeeper.EnemyColor = ConsoleColor.Black;
                        if (Program.currentPlayer.playerHealth <= 0)
                        {
                            GameOverScreen();
                            Environment.Exit(0);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (CurrentPlayer.X == PrisonerOne.X && CurrentPlayer.Y == PrisonerOne.Y)
                {
                    Prisoner();

                    if (Program.currentPlayer.key == 1)
                    {
                        LevelCompleted();
                        Environment.Exit(0);
                    }
                    else
                        continue;
                }
            }
        }
    }
}
