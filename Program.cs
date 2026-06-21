using System;

namespace Project_Zadacha2
{
    class Uchenik
    {
        public double Bel { get; set; }
        public double Matematika { get; set; }

        public bool EdnakavUspeh()
        {
            return Math.Round(Bel, MidpointRounding.AwayFromZero) ==
                   Math.Round(Matematika, MidpointRounding.AwayFromZero);
        }
    }

    internal class Program
    {
        static int VuvediBroiUchenici()
        {
            int n;

            do
            {
                Console.Write("Въведете брой ученици (1-20): ");
                n = int.Parse(Console.ReadLine()!);
            }
            while (n < 1 || n > 20);

            return n;
        }

        static Uchenik VuvediUchenik(int nomer)
        {
            Uchenik u = new Uchenik();

            Console.WriteLine($"\nУченик №{nomer}");

            Console.Write("Успех по Български език и литература: ");
            u.Bel = double.Parse(Console.ReadLine()!);

            Console.Write("Успех по Математика: ");
            u.Matematika = double.Parse(Console.ReadLine()!);

            return u;
        }

        static void PokazhiRezultat(Uchenik[] uchenici)
        {
            Console.WriteLine("\nНомера на учениците с еднакъв успех по двата предмета (след закръгляне):");

            bool imaTakiva = false;

            for (int i = 0; i < uchenici.Length; i++)
            {
                if (uchenici[i].EdnakavUspeh())
                {
                    Console.WriteLine($"Ученик №{i + 1}");
                    imaTakiva = true;
                }
            }

            if (!imaTakiva)
            {
                Console.WriteLine("Няма такива ученици.");
            }
        }

        static void Main(string[] args)
        {
            int broiUchenici = VuvediBroiUchenici();

            Uchenik[] uchenici = new Uchenik[broiUchenici];

            for (int i = 0; i < broiUchenici; i++)
            {
                uchenici[i] = VuvediUchenik(i + 1);
            }

            PokazhiRezultat(uchenici);
        }
    }
}