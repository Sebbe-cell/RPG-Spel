using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PepsiMan
{
    class Encounters : BattleSecvence
    {
        //------------------------------------------STORE-----------------------------------------//
        //------------------------------------------STORE-----------------------------------------//
        //------------------------------------------STORE-----------------------------------------//

        //Rutan som visas när man möter shopkeeper. man bes att svara ja eller nej. och inputen hanteras med if metod. 
        public static void Store()
        {
            string input;
            Console.Clear();
            Console.WriteLine("Hello there " + Program.currentPlayer.playerRace + "! Are you here to buy something?");

            while (true)
            {
                Console.WriteLine("╔════════════╗");
                Console.WriteLine("║(J)a        ║");
                Console.WriteLine("║(N)ej       ║");
                Console.WriteLine("╚════════════╝");
                input = Console.ReadLine();

                if (input.ToLower() == "j")
                {
                    Console.Clear();

                    // Priset för en ny armor är spelarens nuvarande ArmorValue * 20c.
                    int armor = 0;//Program.currentPlayer.armorValue * 20;

                    if (Program.currentPlayer.armorValue == 0)
                    {
                        armor = 20;
                    }
                    else
                        armor = Program.currentPlayer.armorValue * 20;

                    Console.WriteLine("Vad vill du köpa?");
                    Console.WriteLine("");
                    tryagain:
                    Console.WriteLine("╔════════════════════");
                    Console.WriteLine("║(K)aststjärna - 10c ");
                    Console.WriteLine("║(A)rmor       - " + armor + "c ");
                    Console.WriteLine("║(P)otion      - 10c ");
                    Console.WriteLine("╚════════════════════");
                    Console.WriteLine("");
                    Console.WriteLine("Dina coins: " + Program.currentPlayer.coins);
                    string userInput = Console.ReadLine();

                    if (userInput.ToLower() == "k" && Program.currentPlayer.coins >= 10) // om man svarat ja till köp samt valt item, så kontrolleras det även om man har tillräcklig med coins.
                    {
                        Console.Clear();
                        Program.currentPlayer.special += 1;
                        Program.currentPlayer.coins -= 10;
                        Console.WriteLine("Smart val, kan komma till användning där ute..");
                        Console.WriteLine("Du har nu : " + Program.currentPlayer.special + " kaststjärnor i ditt bälte");
                        Console.WriteLine("I din läderpung så har du nu: " + Program.currentPlayer.coins + " coins.");
                        Console.ReadKey();
                        continue;
                    }
                    else if (userInput.ToLower() == "a" && Program.currentPlayer.coins >= armor)
                    {
                        Console.Clear();
                        Program.currentPlayer.armorValue += 1;
                        Program.currentPlayer.coins -= armor;
                        Console.WriteLine("Du har nu köpt en ny armor, ingen väntan här utan du sätter på dig din nya rustning direkt.");
                        Console.WriteLine("Du har nu rustningsvärde: " + Program.currentPlayer.armorValue);
                        Console.WriteLine("I din läderpung så har du nu: " + Program.currentPlayer.coins + " coins.");
                        Console.ReadKey();
                        continue;

                    }
                    else if (userInput.ToLower() == "p" && Program.currentPlayer.coins >= 20)
                    {
                        Console.Clear();
                        Program.currentPlayer.HealthPotion += 1;
                        Program.currentPlayer.coins -= 10;
                        Console.WriteLine("Ägaren kastar en potion till dig. 'Varsågod!'");
                        Console.WriteLine("Du har nu: " + Program.currentPlayer.HealthPotion + " potions i din säck.");
                        Console.WriteLine("I din läderpung så har du nu: " + Program.currentPlayer.coins + "coins.");
                        Console.ReadKey();
                        continue;

                    }
                    else if (userInput.ToLower() != "p" || userInput.ToLower() != "a" || userInput.ToLower() != "k")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ursäkta, vad ville du handla sa du?");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto tryagain;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Inte tillräckligt med coins, kom tillbaka när du kan betala!");
                        Console.WriteLine("Du har endast: " + Program.currentPlayer.coins + " coins.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
                else if (input.ToLower() == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Okej då, sluta då störa mig.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ursäkta mig? Förstog inte riktigt vad du sa " + Program.currentPlayer.playerRace + ". \nKan du repetera?");
                    Console.ReadKey();
                }
            }
        }

        //------------------------------------------STORE END-----------------------------------------//
        //------------------------------------------STORE END-----------------------------------------//
        //------------------------------------------STORE END-----------------------------------------//

        public static void Prisoner()
        {
            if (Program.currentPlayer.key == 0)
            {
                Console.Clear();
                Console.WriteLine("You have to save me! If you can kill that warlock over there you can get his key");
                Console.WriteLine("And unlock these chains, please help me!");
                Console.ReadKey();
                Console.Clear();
            }
            else if(Program.currentPlayer.key == 1)
            {
                Console.Clear();
                Console.WriteLine("You did it! You killed him! Help me unlock these chains and lets get out of here before more guards show up!");
                Console.ReadKey();
            }
        }

        public static int OldmansPet { get; private set; }
        public static int OldmansJourny { get; private set; }
        public static void Quest()
        {
            if (Program.currentPlayer.playerRace != "Orc")
            {
                Console.Clear();
                Console.WriteLine("Väl inne i affären så ser du en gammal man sitta ensam vid ett bort till vänster om dig.");
                Console.WriteLine("Han ser förbryllad ut och håller i ett hundkoppel.. Förmodligen en bortsprungen hund.");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╭──────────────────────────────────────╮");
                Console.WriteLine("│             QUEST FOUND!             │");
                Console.WriteLine("│                                      │");
                Console.WriteLine("│    Hitta ägarens hund och bestäm     │");
                Console.WriteLine("│      vad du vill göra med den.       │");
                Console.WriteLine("╰──────────────────────────────────────╯");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hitta hunden för att fortsätta interagera med ägaren. \nTryck på en knapp för att fortsätta.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Väl inne i affären så ser du en gammal man sitta ensam vid ett bort till vänster om dig.");
                Console.WriteLine("Han ser förbryllad ut och håller i ett hundkoppel.. Förmodligen en bortsprungen hund.");
                Console.WriteLine("Du går fram mot honom men innan du hinner sätta dig ner säger han: \n'Umgås inte med din sort " + Program.currentPlayer.playerRace + ".. Lämna mig ifred.'");
                Console.ReadKey();
            }



            if (Program.currentPlayer.pet > 0 && Program.currentPlayer.playerRace != "Orc")
            {
                Console.WriteLine("Han kallar på dig och du sätter dig ner bredvid han.");
                Console.WriteLine("'Du har inte av någon chans sätt min hund? Han sprang iväg för ett tag sen..'");
                Console.WriteLine("'Jag kan betala dig bra om du har någon aning vart han är.'");
                Thread.Sleep(2000);
            again:
                Console.WriteLine("");
                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║(L)jug - Du behåller hans hund och för dig själv.                                 ║");
                Console.WriteLine("║(Å)terförena - Du förlorar hunden men får en belöning för att du hittade hunden.  ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine("");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "l")
                {
                    Console.Clear();
                    Console.WriteLine("Lögn: 'Låter hemskt! Hundar är lojala djur, han kommer nog hitta tillbaka till dig igen!'");
                    Console.WriteLine("Lögn: 'Men jag tror jag gick förbi någon hund ett par kilometer söderut längs floden!'");
                    Console.WriteLine("Den gamla mannen reser sig upp och tackar dig för information \nHan beger sig sedan ut till dina koordinater för att leta rätt på sin hund!");
                    Console.WriteLine("");
                    Console.WriteLine("Du vinkar han ajdö mot vad som säkert är hans sista resa.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╭──────────────────────────────────────╮");
                    Console.WriteLine("│            QUEST COMPLETED!          │");
                    Console.WriteLine("│                                      │");
                    Console.WriteLine("│    Du ljög för mannen och behöll     │");
                    Console.WriteLine("│               hunden.                │");
                    Console.WriteLine("╰──────────────────────────────────────╯");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                    OldmansJourny = 1;
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choice.ToLower() == "å")
                {
                    Console.Clear();
                    Console.WriteLine("'Idag är din turdag! Kan det vara han?'. Du visar upp hunden och återförenar dom!");
                    Program.currentPlayer.pet -= 1;
                    Program.currentPlayer.coins += 60;
                    OldmansPet = 1;
                    Console.WriteLine("'Jaaaaaa! Där är du! Tack för att du hittade han. Nu till betalningen..");
                    Console.WriteLine("Han ger dig 30 coins för hjälpen. Du tackar och ber han hålla bättre koll på hunden i framtiden.");
                    Console.WriteLine("Den gamla mannen reser sig från bordet och går iväg med sin hund..");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╭──────────────────────────────────────╮");
                    Console.WriteLine("│            QUEST COMPLETED!          │");
                    Console.WriteLine("│                                      │");
                    Console.WriteLine("│    Du gav tillbaka hunden och fick   │");
                    Console.WriteLine("│               60 coins!              │");
                    Console.WriteLine("╰──────────────────────────────────────╯");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Ursäkta vad sa du?");
                    goto again;
                }
            }

            else
            {
                Console.Clear();
            }
        }
        public static string guess { get; set; }
        public static string answer { get; set; }
        public static int numberOfGuesses { get; set; }

        public static void Riddle()
        {
            answer = "footsteps";
            guess = "";
            numberOfGuesses = 5;
            bool gameOver = false;

                Console.Clear();
                Console.WriteLine("För att komma in här behöver du svar på denna gåta:");
                Console.WriteLine("The more you take, the more you leave behind. What am I?");

                while (gameOver == false)
                {
                    guess = Console.ReadLine().ToLower();
                    numberOfGuesses--;

                    if (guess != answer && numberOfGuesses > 0)
                    {
                        Console.WriteLine("Fel, försök igen..");
                        Console.WriteLine("Du har: " + numberOfGuesses + " gissningar kvar.");
                    }
                    else if (guess != answer && numberOfGuesses == 0)
                    {
                        Console.WriteLine("Du fick fem försök och lyckades inte, patetiskt..");
                        Console.WriteLine("Får se om du är bättre på att slåss än lösa gåtor.");
                        Console.ReadKey();
                        gameOver = true;
                    }
                    else if (guess == answer)
                    {
                        Console.WriteLine("Aaah du lyckades! Imponerande. Varsågod, kom in..");
                        gameOver = true;
                        Console.ReadKey();
                    }
                }
            Console.Clear();
        }

        public static void Pet()
        {
            Console.Clear();
            Console.WriteLine("Du hittar en bortsprungen hund och han börjar följa efter dig!");
            Console.WriteLine("Han kommer säkert till bra användning mot fiender.");
            Program.currentPlayer.pet += 1;
            Console.WriteLine("Du har nu: " + Program.currentPlayer.pet + " hund som kommer hjälpa dig slåss mot fiender!");
            Console.ReadKey(true);
            Console.Clear();
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

        public static void Note()
        {
            Console.Clear();
            Console.WriteLine("Du hittar ett kuvert vid din byrå med en handskriven lapp i: 'Blablablablabla(not yet completed)'.");
            Console.WriteLine("Du lägger den i din ficka sålänge.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void Chest() //Rutan som visas upp när man möter Skattkistan. 
        {
            Console.Clear();
            Console.WriteLine("Du vandrar längs vägen och hittar en gammal skrutten kista, i bältet kommer du på att du har en dolk, du tar fram den och knäcker upp låset");
            Console.WriteLine("I kistan hittar du 15 coins!");
            Program.currentPlayer.coins += 15;
            Console.WriteLine("Du har nu : " + Program.currentPlayer.coins + " coins i din läderpung");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
        }
        public static void Guard()
        {
            Console.Clear();
            Console.WriteLine("Du ser en gammalt övergivet fort och vid dörren upptäcker du ett vaknade skelett..");
            Console.WriteLine("Som förmodligen skyddar något värdefullt från sitt liv bland de levende.");
            Console.WriteLine("Du drar ditt svärd och attackerar han.");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Guarding Skeleton", 4, 18);
        }

        public static void FirstEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du vandrar längs med en stig och skymtar något längre upp samma stig, \nDu försöker göra så lite ljud som möjligt men råkar trampa på en död kvist..");
            Console.WriteLine("Han vänder sig om..");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Raider", 4, 8); // Enemy 1 - Raider
        }

        public static void BossFight()
        {
            Console.Clear();
            Console.WriteLine("Du har tillslut nått fram till slutet, en stor Warlock står med ryggen mot dig och ser ut att utföra någon ritual..");
            Console.WriteLine("Du smyger dig framåt och drar ditt vapen, han har redan insett att du är där och vänder sig mot dig..");
            Console.WriteLine("Runt hans hals hänger ett halsband med en nyckel..");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Warlock", 10, 40); // Enemy 2 - Warlock

        }

        public static void ThirdEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du stöter på en Zombie!");
            Console.WriteLine("Han springer fort mot dig och ni börjar attackera varandra!");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Zombie", 6, 6); // Enemy 3 - Zombie
        }       
    }
}

