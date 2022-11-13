namespace Projekt_2_vistula
{
    internal class Program
    {
        static int[] tablica = new int[20];
        static void Main(string[] args)
        {
            //Projekt
            //Generacja tablicy o wieklkosci 20 z losowymi numerami
            Random random = new Random();
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = random.Next(0, 101);
            }
            //Wyswietlanie tablicy
            DisplayArray(tablica);

            Console.WriteLine("Algorytm dziala");
            //Algorytm babelkowy
            int krok = 0;
            int oldCounter = -1;
            int n = 0;
            int nPlus = 1;
            bool done = true;
            while (done)
            {
                //resetuje wartosci jesli wychodza poza array
                if (nPlus > tablica.Length - 1)
                {
                    n = 0;
                    nPlus = 1;
                }
                //sprawdzam czy 1 jest wieksza od drugiej i zamieniam
                if (tablica[n] < tablica[nPlus])
                {
                    oldCounter++;
                    if (tablica.Length < oldCounter)
                    {
                        done = false;
                    }
                }
                else if (tablica[n] > tablica[nPlus])
                {
                    oldCounter = 0;
                    int temp = tablica[n];
                    tablica[n] = tablica[nPlus];
                    tablica[nPlus] = temp;
                    krok++;
                }
                n++;
                nPlus++;
            }
            DisplayArray(tablica);
        }
        private static void DisplayArray(int[] tablica)
        {
            for (int i = 0; i < tablica.Length; i++)
            {
                Console.WriteLine(tablica[i]);
            }
        }
    }
}