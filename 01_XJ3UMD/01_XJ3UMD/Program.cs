using System;

namespace _01_XJ3UMD;

class Program
{
    static void Main(string[] args)
    {
        //Feladat_1();
        Feladat_2();
    }
    static void Feladat_1()
    {
        Console.WriteLine("RAM összerakása\n");

        //Kérje be a felhasználótól, hogy hány RAM slot van az alaplapon! Ellenőrizze, hogy legalább 2, legfeljebb 6 legyen!
        int ramSlotokSzama = 0;
        while (ramSlotokSzama < 2 || ramSlotokSzama > 6)
        {
            Console.Write("Adja meg a RAM slotok számát: (2 és 6 között): ");
            ramSlotokSzama = int.Parse(Console.ReadLine());

            if (ramSlotokSzama < 2 || ramSlotokSzama > 6)
            {
                Console.WriteLine("A RAM slotok száma csak 2 és 6 között lehet!");
            }
        }
        //b) Kérje be a felhasználótól, hogy az egyes slot - okba mekkora RAM-okat illeszt be!
        int[] ramok = new int[ramSlotokSzama];
        int osszRam = 0;

        for (int i = 0; i < ramSlotokSzama; i++)
        {
            int ramMeret = 0;
            bool ervenyesRam = false;
            while (!ervenyesRam)
            {
                Console.Write($"Adja meg a {i + 1}. RAM slot méretét (2, 4, 6, 8 GB): ");
                ramMeret = int.Parse(Console.ReadLine());

                if (ramMeret == 2 || ramMeret == 4 || ramMeret == 6 || ramMeret == 8)
                {
                    if (osszRam + ramMeret <= 32)
                    {
                        ervenyesRam = true;
                        ramok[i] = ramMeret;
                        osszRam += ramMeret;
                    }
                    else
                    {
                        Console.WriteLine("Az összes RAM mérete nem haladhatja meg a 32GB-t.");
                    }
                }
                else
                {
                    Console.WriteLine("Csak 2, 4, 6 és 8 GB-os RAM-okat fogadunk el! Próbálja újra.");
                }
            }
        }
        int ramSlotokMennyisege = 0;
        for (int i = 0; i < ramok.Length; i++)
        {
            if (ramok[i] > 0)
            {
                Console.WriteLine(ramok[i]);
                ramSlotokMennyisege++;
            }
        }
        Console.WriteLine($"Összesen {ramSlotokMennyisege} slotba került RAM");
        Console.WriteLine($"Az alaplapon lévő RAM összesen {osszRam} GB.");
    }
    static void Feladat_2()
    {
        int versenyzokSzama;

        //Kérje be ellenőrzötten a felhasználótól, hogy hány versenyző indult!A versenyzők száma egy 15 és 100 közötti egész érték!
        do
        {
            Console.Write("Adja meg a versenyzők számát (15 és 100 között): ");
            if (!int.TryParse(Console.ReadLine(), out versenyzokSzama) || versenyzokSzama < 1 || versenyzokSzama > 100)
            {
                Console.WriteLine("Hibás, kérem adja meg újra ");
            }
        } while (versenyzokSzama < 1 || versenyzokSzama > 100);

        int[] halakTomege = new int[versenyzokSzama];
        Random rnd = new Random();

        for (int i = 0; i < versenyzokSzama; i++)
        {
            halakTomege[i] = rnd.Next(1500, 25001);

        }

        //Írja ki a képernyőre a halak átlagos tömegét!
        int halakOsszTomege = 0;
        for (int i = 0; i < halakTomege.Length; i++)
        {
            halakOsszTomege += halakTomege[i];

        }
        double atlagosTomeg = (double)halakOsszTomege / versenyzokSzama;
        Console.WriteLine($"A halak átlagos tömege következő: {atlagosTomeg:F2} gramm");


        //Írja ki a képernyőre a legnagyobb hal tömegét kg - ban és a versenyző sorszámát!
        int legnagyobbHal = 0;
        int versenyzoSorszama = 0;

        for (int i = 0; i < halakTomege.Length; i++)
        {
            Console.WriteLine(halakTomege[i]);
            if (halakTomege[i] > legnagyobbHal)
            {
                legnagyobbHal = halakTomege[i];
                versenyzoSorszama = i;
            }
        }
        double legnagyobbHalValtas = kgValtas(legnagyobbHal);
        Console.WriteLine($"A legnagyobb halat {legnagyobbHalValtas} kg a {versenyzoSorszama + 1}. sorszámú versenyző fogta.");

        //A 8 kg - nál kisebb halakat haza lehet vinni 2350 F t/ kg áron.Írja ki a képernyőre
        //mekkora bevétele lesz a verseny szervezőinek, ha az összes ilyen halat kiárusítják!

        int kisHalak = 0;
        double teljesBevetel = 0;
        for (int i = 0; i < halakTomege.Length; i++)
        {
            if (halakTomege[i] < 8000)
            {
                kisHalak += halakTomege[i];
                teljesBevetel = kgValtas(kisHalak) * 2350;
            }
        }

        if (teljesBevetel > 0)
        {
            Console.WriteLine($"A verseny szervezőinek bevétele a 8 kg-nál kisebb halakból: {teljesBevetel} Ft");
        }
        else
        {
            Console.WriteLine("Nincs olyan hal, ami 8 kg alatti lenne.");
        }

        static double kgValtas(int grammKgra)
        {
            return grammKgra / 1000.0;
        }
    }
}
