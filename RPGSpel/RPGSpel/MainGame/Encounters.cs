using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PepsiMan
{
    class Encounters
    {
        //------------------------------------------STORE-----------------------------------------//
        //------------------------------------------STORE-----------------------------------------//
        //------------------------------------------STORE-----------------------------------------//

        //Rutan som visas när man möter shopkeeper. man bes att svara ja eller nej. och inputen hanteras med if metod. 
        public static void Store()
        {
            string input;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hej där främling! Är du här för att köpa något?");
                Console.WriteLine("╔════════════╗");
                Console.WriteLine("║(J)a        ║");
                Console.WriteLine("║(N)ej       ║");
                Console.WriteLine("╚════════════╝");
                input = Console.ReadLine();

                if (input.ToLower() == "j")
                {
                    Console.Clear();
                    Console.WriteLine("Vad vill du köpa?");
                    Console.WriteLine("");
                    Console.WriteLine("╔════════════════════╗");
                    Console.WriteLine("║(K)aststjärna - 10c ║");
                    Console.WriteLine("║(A)rmor       - 20c ║");
                    Console.WriteLine("║(P)otion      - 10c ║");
                    Console.WriteLine("╚════════════════════╝");
                    Console.WriteLine("");
                    Console.WriteLine("Dina coins: " + Program.currentPlayer.coins);
                    string a = Console.ReadLine();

                    if (a.ToLower() == "k" && Program.currentPlayer.coins >= 10) // om man svarat ja till köp samt valt item, så kontrolleras det även om man har tillräcklig med coins.
                    {
                        Console.Clear();
                        Program.currentPlayer.special += 1;
                        Program.currentPlayer.coins -= 10;
                        Console.WriteLine("Smart val, kan komma till användning där ute..");
                        Console.WriteLine("Du har nu : " + Program.currentPlayer.special + " kaststjärnor i ditt bälte");
                        Console.WriteLine("I din läderpung så har du nu: " + Program.currentPlayer.coins + "coins.");
                        Console.ReadKey();
                        continue;
                    }
                    else if (a.ToLower() == "a" && Program.currentPlayer.coins >= 20)
                    {
                        Console.Clear();
                        Program.currentPlayer.armorValue += 1;
                        Program.currentPlayer.coins -= 20;
                        Console.WriteLine("Du har nu köpt en armor, ingen väntan här utan du sätter på dig din nya rustning direkt.");
                        Console.WriteLine("Du har nu rustningsvärde: " + Program.currentPlayer.armorValue);
                        Console.WriteLine("I din läderpung så har du nu: " + Program.currentPlayer.coins + "coins.");
                        Console.ReadKey();
                        continue;

                    }
                    else if (a.ToLower() == "p" && Program.currentPlayer.coins >= 20)
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
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Inte tillräckligt med coins, kom tillbaka när du kan betala!");
                        Console.WriteLine("Du har endast: " + Program.currentPlayer.coins + "coins.");
                        Console.ReadKey();
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
                    Console.WriteLine("Ursäkta?");
                    Console.ReadKey();
                }
            }
        }

        //------------------------------------------STORE END-----------------------------------------//
        //------------------------------------------STORE END-----------------------------------------//
        //------------------------------------------STORE END-----------------------------------------//



        public static int OldmansPet { get; private set; }
        public static int OldmansJourny { get; private set; }
        public static void Quest()
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



            if(Program.currentPlayer.pet > 0)
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
                    Program.currentPlayer.coins += 30;
                    OldmansPet = 1;
                    Console.WriteLine("'Jaaaaaa! Där är du! Tack för att du hittade han. Nu till betalningen..");
                    Console.WriteLine("Han ger dig 30 coins för hjälpen. Du tackar och ber han hålla bättre koll på hunden i framtiden.");
                    Console.WriteLine("Den gamla mannen reser sig från bordet och går iväg med sin hund..");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╭──────────────────────────────────────╮");
                    Console.WriteLine("│            QUEST COMPLETED!          │");
                    Console.WriteLine("│                                      │");
                    Console.WriteLine("│    Du gav tillbaka hunden och fick   │");
                    Console.WriteLine("│               30 coins!              │");
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
            Battle("Guarding Skeleton", 3, 18);
        }

        public static void FirstEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du vandrar längs med en stig och skymtar något längre upp samma stig, \nDu försöker göra så lite ljud som möjligt men råkar trampa på en död kvist..");
            Console.WriteLine("Han vänder sig om..");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Raider", 1, 8); // Enemy 1 - Raider
        }

        public static void BossFight()
        {
            Console.Clear();
            Console.WriteLine("Bortom ett berg ser du att torn stiga upp, du beslutar dig för att gå över berget mot tornet..");
            Console.WriteLine("Äntligen där! Väl framme öppnar du dörren och går du upp för trapporna när du möter..");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Warlock", 6, 40); // Enemy 2 - Warlock

        }

        public static void ThirdEncounter()
        {
            Console.Clear();
            Console.WriteLine("Du stöter på en Zombie!");
            Console.WriteLine("Han springer fort mot dig och ni börjar attackera varandra!");
            Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            Battle("Zombie", 3, 6); // Enemy 3 - Zombie
        }

        static Random rng = new Random();
        static Random drop = new Random();

        public static void Battle(string name, int power, int health) // METODEN Battle som startas när man träffar en enemy av olika slag. man skriver in argument för parametrarna;
        {                                                             // name, power, health. 
            string enemyName = "";
            int enemyDmg = 0;
            int enemyHealth = 0;

            enemyName = name;
            enemyDmg = power;
            enemyHealth = health;


            while (enemyHealth > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enemy name: " + enemyName);
                Console.WriteLine("Enemy power: " + enemyDmg + " Enemy HP: " + enemyHealth);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("║      (S)pecial     ║");
                Console.WriteLine("║      (A)ttack      ║");
                Console.WriteLine("║ (R)un       (H)eal ║");
                Console.WriteLine("╚════════════════════╝");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Health: " + Program.currentPlayer.playerHealth);
                Console.WriteLine("Rustningsvärde: " + Program.currentPlayer.armorValue);
                Console.WriteLine("Attack Damage: " + Program.currentPlayer.wepValue);
                Console.WriteLine("Extra Damage from Pet: " + Program.currentPlayer.pet);
                Console.WriteLine("\n--Inventory--");
                Console.WriteLine("Potions: " + Program.currentPlayer.HealthPotion);
                Console.WriteLine("Kaststjärnor: " + Program.currentPlayer.special);

                string input = Console.ReadLine();

                if (input.ToLower() == "a")
                {
                    Console.WriteLine("Du går till attack samtidigt som " + enemyName + "!");
                    int damage = enemyDmg - Program.currentPlayer.armorValue;

                    // spelaren attack slumpas fram mellan 0 och spelarens weaponvalue + ett tal mellan 1-4.
                    int playerAttackValue = rng.Next(0, Program.currentPlayer.wepValue + Program.currentPlayer.pet) + rng.Next(1, 4);
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

                    int randomEnemyDrop = rng.Next(1, 3 + 1);

                    if (randomEnemyDrop == 1)
                    {
                        Console.WriteLine("Du böjer dig ner över den döda " + enemyName + " som droppar en slipsten för ditt vapen!" + "\nDu kommer nu att göra mer skada på dina fiender!");
                        Program.currentPlayer.wepValue += 1;
                        Console.WriteLine("\nPlayer HP = " + Program.currentPlayer.playerHealth);
                        Console.WriteLine("Potions = " + Program.currentPlayer.HealthPotion);
                        Console.WriteLine("Kaststjärnor = " + Program.currentPlayer.special);
                        Console.WriteLine("Attackdamage = " + Program.currentPlayer.wepValue);
                    }
                    else if (randomEnemyDrop == 2)
                    {
                        Console.WriteLine("Du böjer dig ner över den döda " + enemyName + " som droppar en potion!");
                        Program.currentPlayer.HealthPotion += 1;
                        Console.WriteLine("\nPlayer HP = " + Program.currentPlayer.playerHealth);
                        Console.WriteLine("Potions = " + Program.currentPlayer.HealthPotion);
                        Console.WriteLine("Kaststjärnor = " + Program.currentPlayer.special);
                        Console.WriteLine("Attackdamage = " + Program.currentPlayer.wepValue);
                    }
                    else if (randomEnemyDrop == 3)
                    {
                        Console.WriteLine("Du böjer dig ner över den döda " + enemyName + " som droppar en kaststjärna!");
                        Program.currentPlayer.special += 1;
                        Console.WriteLine("\nPlayer HP = " + Program.currentPlayer.playerHealth);
                        Console.WriteLine("Potions = " + Program.currentPlayer.HealthPotion);
                        Console.WriteLine("Kaststjärnor = " + Program.currentPlayer.special);
                        Console.WriteLine("Attackdamage = " + Program.currentPlayer.wepValue);
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
