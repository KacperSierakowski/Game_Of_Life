using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Kacper Sierakowski 218608

namespace Game_Of_Life{

    class Program{

        static int rozmiar=10;
        static int ile_mam_sasiadow = 0;

        static int[,] Tablica_Zycia = new int[rozmiar, rozmiar];
        static int[,] Tablica_Smierci = new int[rozmiar, rozmiar];
        
        //Funkcja ustawiajaca zyjace komorki
        static void Generowanie_Gry() {
            for (int i = 0; i < (Tablica_Smierci.Length / rozmiar) ; i++)
            {
                for (int j = 0; j < (Tablica_Smierci.Length / rozmiar) ; j++)
                {
                    Tablica_Zycia[i, j] = 0;
                    Tablica_Smierci[i, j] = 0;
                }
            }

            Random rand = new Random();
           // Console.WriteLine("Generowanie_Gry");
            for (int i = 1; i < (Tablica_Smierci.Length / rozmiar) - 1; i++)
            {
                for (int j = 1; j < (Tablica_Smierci.Length / rozmiar) - 1; j++)
                {
                    int x = rand.Next(0, 2);
                    Tablica_Zycia[i, j] = x;
                    //Tablica_Smierci[i, j] = x;
                }
            }/*
            Tablica_Zycia[4, 4] = 1;
            Tablica_Zycia[4, 5] = 1;
            Tablica_Zycia[4, 6] = 1;*/
        }
        //Funkcja sprawdzajaca ilosc sasiadow i wykonujaca algorytm
        static void Sprawdzanie_Sasiadow(){

            //Console.WriteLine("Sprawdzam");
            for (int x = 1; x < (Tablica_Zycia.Length / rozmiar) - 1; x++) {
                for (int y = 1; y < (Tablica_Zycia.Length / rozmiar) - 1; y++){
                    //ile sasiadow ma Tablica_Smierci[x, y]
                    ile_mam_sasiadow = Tablica_Zycia[x-1, y-1] + Tablica_Zycia[x-1, y] + Tablica_Zycia[x-1, y+1] 
                                     + Tablica_Zycia[x, y-1]   + Tablica_Zycia[x, y+1]  
                                     + Tablica_Zycia[x+1, y-1] + Tablica_Zycia[x+1, y] + Tablica_Zycia[x+1, y+1];

                    //ile_mam_sasiadow = Tablica_Zycia[x, y] +     Tablica_Zycia[x, y + 1] + Tablica_Zycia[x, y + 2] + Tablica_Zycia[x + 1, y] + Tablica_Zycia[x + 1, y + 2] +  Tablica_Zycia[x + 2, y] + Tablica_Zycia[x + 2, y + 1] + Tablica_Zycia[x + 2, y + 2];
                    //Console.WriteLine(ile_mam_sasiadow);
                    //Każda żywa komórka, która posiada mniej niż dwóch żywych sąsiadów umiera (osamotnienie)
                    if (ile_mam_sasiadow < 2 && Tablica_Zycia[x, y] == 1)
                    {
                        Tablica_Smierci[x, y] = 0;
                    }
                    //Każda żywa komórka, która posiada dwóch lub trzech żywych sąsiadów przeżywa
                    if ((ile_mam_sasiadow == 3 || ile_mam_sasiadow == 2) && Tablica_Zycia[x, y] ==1)
                    {
                        Tablica_Smierci[x, y] = 1;
                    }
                    // Każda żywa komórka, która posiada więcej niż trzech żywych sąsiadów umiera  (przeludnienie)
                     if (ile_mam_sasiadow > 3 && Tablica_Zycia[x, y] == 1) {
                        Tablica_Smierci[x, y] = 0;
                    }
                    //Każda martwa komórka, która posiada  dokładnie trzech sąsiadów, ożywa (reprodukcja)
                    if (ile_mam_sasiadow == 3 && Tablica_Zycia[x, y] == 0)
                    {
                        Tablica_Smierci[x, y] = 1;
                    }
                }
            }
        }

        static void Wypisywanie_Gry(){
            // Console.WriteLine("Wypisuje");//Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.Clear();
            for (int j = 0; j < (Tablica_Smierci.Length / rozmiar) ; j++) {
                for (int i = 0; i < (Tablica_Smierci.Length / rozmiar) ; i++){
                    Console.Write(Tablica_Zycia[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < (Tablica_Smierci.Length / rozmiar) ; j++) {
                for (int i = 0; i < (Tablica_Smierci.Length / rozmiar) ; i++) {
                    Console.Write(Tablica_Smierci[i, j]);
                }
                Console.WriteLine();
            }
            /* Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            for (int j = 1; j < (Tablica_Smierci.Length / rozmiar) - 1; j++) {
                for (int i = 1; i < (Tablica_Smierci.Length / rozmiar) - 1; i++) {
                    Console.Write(Tablica_Zycia[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 1; j < (Tablica_Smierci.Length / rozmiar)-1; j++) {
                for (int i = 1; i < (Tablica_Smierci.Length / rozmiar)-1; i++){
                    Console.Write(Tablica_Smierci[i, j]);
                }
                Console.WriteLine();
            }*/
        }

        static void Main(string[] args){
            
            //Console.WriteLine(Tablica_Zycia.Length/rozmiar);
            Generowanie_Gry();
            
            while (true){
                
                Sprawdzanie_Sasiadow();
                Wypisywanie_Gry();

                for (int x = 1; x < (Tablica_Zycia.Length / rozmiar) - 1; x++)
                {
                    for (int y = 1; y < (Tablica_Zycia.Length / rozmiar) - 1; y++)
                    {
                        Tablica_Zycia[x, y] = Tablica_Smierci[x, y];
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
