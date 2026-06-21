using System;

namespace Project_Zadacha2
{
    class Uchenik
    {
        public string Ime { get; set; } = null!;
        public double Bel { get; set; }
        public double Matematika { get; set; }

        public bool EdnakavUspeh()
        {
            return Math.Round(Bel) == Math.Round(Matematika);
        }

        public double SredenUspeh()
        {
            return (Bel + Matematika) / 2.0;
        }
    }

    internal class Program
    {
        static int VuvediBroiUchenici()
        {
            int n;

            do
            {
                Console.Write("Брой ученици (1-20): ");
                n = int.Parse(Console.ReadLine()!);
            }
            while (n < 1 || n > 20);

            return n;
        }

        static Uchenik VuvediUchenik(int nomer)
        {
            Uchenik u = new Uchenik();

            Console.WriteLine($"\nУченик №{nomer}");

            Console.Write("Име: ");
            u.Ime = Console.ReadLine()!;

            Console.Write("Успех по БЕЛ: ");
            u.Bel = double.Parse(Console.ReadLine()!);

            Console.Write("Успех по Математика: ");
            u.Matematika = double.Parse(Console.ReadLine()!);

            return u;
        }

        static void PokazhiRezultat(Uchenik[] uchenici)
        {
            Console.WriteLine("\nУченици с еднакъв успех по двата предмета:");

            bool nameren = false;

            for (int i = 0; i < uchenici.Length; i++)
            {
                if (uchenici[i].EdnakavUspeh())
                {
                    Console.WriteLine($"Ученик №{i + 1}");
                    nameren = true;
                }
            }

            if (!nameren)
            {
                Console.WriteLine("Няма такива ученици.");
            }
        }

        static void BroiSlabiOcenki(Uchenik[] uchenici)
        {
            int broi = 0;

            foreach (var u in uchenici)
            {
                if (u.Bel < 3.00) broi++;
                if (u.Matematika < 3.00) broi++;
            }

            Console.WriteLine($"\nБрой слаби оценки: {broi}");
        }

        static void SredenUspehPoUchenici(Uchenik[] uchenici)
        {
            Console.WriteLine("\nСреден успех на учениците:");

            for (int i = 0; i < uchenici.Length; i++)
            {
                double sreden = (uchenici[i].Bel + uchenici[i].Matematika) / 2.0;

                Console.WriteLine(
                    $"{i + 1}. {uchenici[i].Ime} -> {sreden:F2}"
                );
            }
        }

        static void Main(string[] args)
        {
            int n = VuvediBroiUchenici();

            Uchenik[] uchenici = new Uchenik[n];

            for (int i = 0; i < n; i++)
            {
                uchenici[i] = VuvediUchenik(i + 1);
            }

            PokazhiRezultat(uchenici);
            BroiSlabiOcenki(uchenici);
            SredenUspehPoUchenici(uchenici);
        }
    }
}