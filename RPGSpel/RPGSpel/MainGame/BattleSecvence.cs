using System;

namespace PepsiMan
{
    class BattleSecvence
    {

        static Random rng = new Random();
        static Random drop = new Random();

        public static void Battle(string name, int power, int health) // METODEN Battle som startas när man träffar en enemy av olika slag. man skriver in argument för parametrarna;
        {                                                             // name, power, health. 

            string enemyName = name;
            int enemyDmg = power;
            int enemyHealth = health;


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
                Console.ForegroundColor = ConsoleColor.Green;
                if (Program.currentPlayer.playerName != "")
                {
                    Console.WriteLine("Player: " + Program.currentPlayer.playerName + " Race: " + Program.currentPlayer.playerRace);
                }
                else
                {
                    Console.WriteLine("Player: Okänd " + Program.currentPlayer.playerRace);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Health: " + Program.currentPlayer.playerHealth);
                Console.WriteLine("Rustningsvärde: " + Program.currentPlayer.armorValue);
                Console.WriteLine("Attack Damage: " + Program.currentPlayer.wepValue);
                Console.WriteLine("Extra Damage from Pet: " + Program.currentPlayer.pet);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═════════════════════════╣");
                Console.WriteLine("║         INVENTORY");
                Console.WriteLine("║Potions: " + Program.currentPlayer.HealthPotion);
                Console.WriteLine("║Kaststjärnor: " + Program.currentPlayer.special);
                Console.WriteLine("║");
                Console.WriteLine("╚═════════════════════════╣");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose your action:");

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
                        int attack = rng.Next(3, Program.currentPlayer.specialValue) + rng.Next(1, 3);
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
                Console.Clear();
            }
        }
    }
}

