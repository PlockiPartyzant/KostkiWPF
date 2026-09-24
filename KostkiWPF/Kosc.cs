using System;

namespace KostkiWPF
{
    public class Kosc
    {
        public static int LiczbaInstancji = 0;

        public static string[] NazwyObrazow =
        {
            "kosc0.png",
            "kosc1.png",
            "kosc2.png",
            "kosc3.png",
            "kosc4.png",
            "kosc5.png",
            "kosc6.png"
        };

        public int LiczbaOczek { get; private set; }

        public int IdentyfikatorPliku { get; private set; }

        public bool Dostepna { get; private set; }

        private static Random random = new Random();

        public Kosc(int wartosc)
        {
            if (wartosc < 1 || wartosc > 6)
            {
                wartosc = 0;
            }

            LiczbaOczek = wartosc;
            IdentyfikatorPliku = wartosc;
            Dostepna = true;

            LiczbaInstancji++;
        }

        public Kosc()
        {
            LiczbaOczek = random.Next(1, 7);
            IdentyfikatorPliku = LiczbaOczek;
            Dostepna = true;

            LiczbaInstancji++;
        }

        public void Rzut()
        {
            if (!Dostepna)
            {
                return;
            }

            LiczbaOczek = random.Next(1, 7);
            IdentyfikatorPliku = LiczbaOczek;
        }

        public void Zablokuj()
        {
            Dostepna = false;
        }

        public void Odblokuj()
        {
            Dostepna = true;
        }


        public string PobierzWartoscTekstowa()
        {
            switch (LiczbaOczek)
            {
                case 1:
                    return "jeden";

                case 2:
                    return "dwa";

                case 3:
                    return "trzy";

                case 4:
                    return "cztery";

                case 5:
                    return "pięć";

                case 6:
                    return "sześć";

                default:
                    return "zero";
            }
        }

        public string PobierzNazweObrazu()
        {
            return NazwyObrazow[IdentyfikatorPliku];
        }
    }
}
