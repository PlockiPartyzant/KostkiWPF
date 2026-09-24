using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KostkiWPF
{
    public partial class MainWindow : Window
    {
        private Kosc[] kosci;

        private Image[] obrazyKosci;

        public MainWindow()
        {
            InitializeComponent();

            kosci = new Kosc[5];

            for (int i = 0; i < kosci.Length; i++)
            {
                kosci[i] = new Kosc(0);
            }

            obrazyKosci = new Image[]
            {
                Kosc1,
                Kosc2,
                Kosc3,
                Kosc4,
                Kosc5
            };
        }

        private void RzutButton_Click(object sender, RoutedEventArgs e)
        {
            int suma = 0;

            for (int i = 0; i < kosci.Length; i++)
            {
                kosci[i].Rzut();

                UstawObrazKosci(
                    obrazyKosci[i],
                    kosci[i].LiczbaOczek
                );

                suma += kosci[i].LiczbaOczek;
            }

            WynikTextBlock.Text = suma.ToString();
        }


        private void Kosc_Click(object sender, MouseButtonEventArgs e)
        {
            Image kliknietaKosc = sender as Image;

            if (kliknietaKosc == null)
            {
                return;
            }

            int indeks = PobierzIndeksKosci(kliknietaKosc);

            if (indeks == -1)
            {
                return;
            }

            if (kosci[indeks].Dostepna)
            {
                kosci[indeks].Zablokuj();

                kliknietaKosc.Opacity = 0.5;
            }
            else
            {
                kosci[indeks].Odblokuj();

                kliknietaKosc.Opacity = 1.0;
            }
        }

        private int PobierzIndeksKosci(Image obraz)
        {
            if (obraz == Kosc1)
            {
                return 0;
            }

            if (obraz == Kosc2)
            {
                return 1;
            }

            if (obraz == Kosc3)
            {
                return 2;
            }

            if (obraz == Kosc4)
            {
                return 3;
            }

            if (obraz == Kosc5)
            {
                return 4;
            }

            return -1;
        }

        private void UstawObrazKosci(Image obraz, int wartosc)
        {
            string sciezka =
                $"pack://application:,,,/Images/kosc{wartosc}.png";

            obraz.Source = new BitmapImage(
                new Uri(sciezka, UriKind.Absolute)
            );
        }
    }
}