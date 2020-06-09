using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Albins_uppgift_alternativ
{
    class spelaren
    {
        //kod som skapar ett randomiserat värde.
        public static readonly Random getrandom = new Random();
        public int RandomNumberSpelaren()
        {
            lock (getrandom)
            {
                return getrandom.Next(1, 6);
            }

        }


        public spelaren(string name) 
        {   
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(name);
            Console.WriteLine("-------------------------------------------");
        }

    }

    class datorn
    {
        public static readonly Random getrandomDatorn = new Random();
        public int RandomNumberDatorn()
        {
            lock (getrandomDatorn) 
            {
                return getrandomDatorn.Next(1, 6);
            }
        }
        public datorn(string name)
        {              
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(name);
            Console.WriteLine("-------------------------------------------");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Variabel som används för att avgöra om det är första gången man spelar
            int repeat = 0;
            bool FirstGame;
            // Hur mycket pengar man har på bordet
            int kapital = 0;
            // Total vinst
            int totalVinst = 0;
                       
            // Oändlig loop som exekveras tills dessa att spelaren väljer att inte spela längre
            while (true)
            {
                // Spelarens första val
                Console.WriteLine("Vill du spela tärning(Y/N)?");
                string choice = Console.ReadLine();

               // Om Y eller y, kör koden, annars avsluta.
                if (choice.Equals("Y",StringComparison.InvariantCultureIgnoreCase))
                {
                repeat++;
                    // Låter spelaren lägga pengar på bordet om det är första spelet eller pengarna är slut
                    if (FirstGame=true | kapital==0)
                    {
                        FirstGame=false;
                        Console.WriteLine("Hur mycket pengar vill du lägga på bordet? (maxinsats 5000 kr)");
                        string userinput = Console.ReadLine();
                        int saldo = Convert.ToInt32(userinput);
                        // Om satsade pengar överstiger 5000 avslutas programmet
                        if (saldo > 5000)
                        {
                            Console.WriteLine("Insatt belopp för högt. Spelet avslutas. Tryck enter");
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        kapital = saldo;
                        
                    }
                // Hur mycket vill spelaren satsa i denna runda    
                Console.WriteLine("Hur mycket vill du satsa på detta spel?");
                string userinput1 = Console.ReadLine();
                int insats = Convert.ToInt32(userinput1);
                   // Kodsnutt som ser till att spelaren inte kan satsa mer än sitt kapital.
                    while (insats > kapital)
                    {
                        Console.WriteLine("Satsat belopp för högt. Försök igen!");
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Hur mycket vill du satsa på detta spel?");
                        string userinput2 = Console.ReadLine();
                        int insats2 = Convert.ToInt32(userinput2);
                        insats = insats2;
                    }

                //Variabler som används i whileloopen
                int WinHuman = 0;
                int WinComputer = 0;
                int Run = 0;
                int RunsVictory = 2;

                //While loop som kör själva spelet (max tre omgångar)
                while (WinHuman < RunsVictory && WinComputer < RunsVictory)
                {
                    Run++;
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Omgång: {0}", Run);
                    Console.WriteLine("--------------------------------------");

                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Ställning: Människa vs Dator: {0}-{1}", WinHuman, WinComputer);
                    Console.WriteLine("--------------------------------------");

                    // Spelaren
                    spelaren ditt = new spelaren("Din tur - tryck enter");
                    Console.ReadKey();
                    int spelaren1 = ditt.RandomNumberSpelaren();
                    int spelaren2 = ditt.RandomNumberSpelaren();
                    int summanS = spelaren1 + spelaren2;
                    Console.WriteLine("Din första tärning: {0}", spelaren1);
                    Console.WriteLine("Din andra tärning: {0}", spelaren2);

                    //Datorn
                    datorn datorns = new datorn("Datorns tur - tryck enter");
                    Console.ReadKey();
                    int datorn1 = datorns.RandomNumberDatorn();
                    int datorn2 = datorns.RandomNumberDatorn();
                    int summanD = datorn1 + datorn2;
                    Console.WriteLine("Datorns första tärning: {0}", datorn1);
                    Console.WriteLine("Datorns andra tärning: {0}", datorn2);

                    // Bestämmer vem som har vunnit
                    if (summanS > summanD)
                    {
                        WinHuman++;
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Du vann!");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Tryck enter för att starta nästa omgång!");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (summanS < summanD)
                    {
                        WinComputer++;
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Datorn vann");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Tryck enter för att starta nästa omgång!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Det blev oavgjort");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Tryck enter för att starta nästa omgång!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                // Skriver ut spelets slutställning 
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Slutställningen blev {0}-{1}", WinHuman, WinComputer);
                Console.WriteLine("---------------------------------------------");

                // Avgör vem som har vunnit
                if (WinHuman > WinComputer)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Du vann - Grattis!");
                    Console.WriteLine("-----------------------------------------");
                    // Kapital efter avslutat spel
                    kapital = kapital + insats;
                    Console.WriteLine("Ditt nya saldo: {0}", kapital);
                    // Total vinst    
                    totalVinst = totalVinst + insats;
                    Console.WriteLine("Ditt totala vinst/förslust är: {0}", totalVinst);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Datorn vann - Bättre lycka nästa gång!");
                    Console.WriteLine("----------------------------------------");
                    kapital = kapital - insats;
                    Console.WriteLine("Ditt nya saldo: {0}", kapital);
                    totalVinst = totalVinst - insats;
                    Console.WriteLine("Ditt totala vinst/förslust är: {0}", totalVinst);
                    Console.ReadKey();
                }
                }
                // Avslutar om spelaren väljer nej på initial fråga
                else
                {
                    Console.WriteLine("Programmet avslutas - tryck enter");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
 }

