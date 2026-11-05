namespace Zombitamadas
{
    internal class Program
    {
            static Random r = new Random();
        static string[] Nevkiosztas(int elemekSzama)
        {
            string[] nevek = new string[30]
                {
                    "Ádám", "Bence", "Dávid", "Gábor", "Máté",
                    "Péter", "Zoltán", "Balázs", "Levente", "Marcell",
                    "Anna", "Eszter", "Lili", "Réka", "Dóra",
                    "Nóra", "Zsófia", "Hanna", "Laura", "Vivien",
                    "Alex", "Chris", "Daniel", "Kevin", "Martin",
                    "Oliver", "Noah", "Lucas", "Emma", "Sophie"
                };
            string[] tomb = new string[elemekSzama];
            for (int i = 0; i < elemekSzama; i++)
            {
                int index = r.Next(0, nevek.Length);
                tomb[i] = nevek[index];
            }
            return tomb;
        }
        static void kiir(string[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
        static int[] LakossagEreje(int lakkosagszama)
        {
            int[] tomb = new int[lakkosagszama];
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = 100;
            }
            return tomb;
        }

        static int[] zombikErejeKezdeti(int lakkosagszama, int sebzesMin, int sebzesMax)
        {
            int[] tomb = new int[lakkosagszama];
            for (int i = 0; i < lakkosagszama; i++)
            {
                tomb[i] = r.Next(sebzesMin, sebzesMax);
            }
            return tomb;
        }

        static void kiirszamokat(int[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.WriteLine(item+" ");
            }
            Console.WriteLine("\n---------------------------------------");
        }
        static void Harc(string[] lakossag, string[] zombik, int[] lakossagEletereje, int[] zombikEreje)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                int index = r.Next(0, lakossag.Length);
                Console.WriteLine($"{zombik[i]} zombi rátámadt {zombikEreje[i]} erővel {lakossag[index]}, akinek a kezdeti életereje: {lakossagEletereje[index]}");
                lakossagEletereje[index] -= zombikEreje[i];
                if(lakossagEletereje =< 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{lakossag[index]} lakos meghalt");
                    Console.ResetColor();
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hány lakosa legyen a városnak: (1-20) ");
            int lakkosagszama = Convert.ToInt32(Console.ReadLine());
            string[] lakossag = Nevkiosztas(lakkosagszama);
            int[] lakossagEletereje = LakossagEreje(lakkosagszama);
            Console.WriteLine("Lakosság: ");
            kiir(lakossag);
            kiirszamokat(lakossagEletereje);
            string[] zombik = Nevkiosztas(lakkosagszama);
            int sebzesMin = 10;
            int sebzesMax = 30;
            int[] zombikEreje = zombikErejeKezdeti(lakkosagszama, sebzesMin, sebzesMax);

            Console.WriteLine("Zombik: ");
            kiir(zombik);
            kiirszamokat(zombikEreje);

            Harc(lakossag, zombik, lakossagEletereje, zombikEreje);




        }


    }
}
