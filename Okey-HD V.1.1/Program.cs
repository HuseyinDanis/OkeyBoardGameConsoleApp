using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Project_Okey
{
    class Program
    {
        private static int gosterge;
        private static int okey = -1;  //-1

        public static  int[] first, second, third, fourth;

        static void Main(string[] args)
        {
            ArrayList tasListesi = new ArrayList();
            
            for (int i = 0; i < 106; i++)
            {
                
                tasListesi.Add(i);
            }


            GöstergeSecim(); //  Gösterge seçen fonksiyon
            
            Console.WriteLine("********* ");
            Console.WriteLine("Gösterge = "+ gosterge);
            Console.WriteLine("********* ");
            tasListesi.Remove(gosterge);  // Gösterge taşların arasından çıkar.


            if (gosterge <52)       //Sahte OKey ayarı   ve Okey ayarı
            {
                tasListesi[tasListesi.IndexOf(52)] = tasListesi[tasListesi.IndexOf(gosterge + 1)];
                tasListesi[tasListesi.IndexOf(gosterge + 1)] = okey;
                tasListesi[tasListesi.IndexOf(105)] = tasListesi[tasListesi.IndexOf(gosterge + 53)];
                tasListesi[tasListesi.IndexOf(gosterge + 53)] = okey;
            }
            else
            {
                tasListesi[tasListesi.IndexOf(52)] = tasListesi[tasListesi.IndexOf(gosterge + 1)];
                tasListesi[tasListesi.IndexOf(gosterge + 1)] = okey;
                tasListesi[tasListesi.IndexOf(105)] = tasListesi[tasListesi.IndexOf((gosterge + 1)%52)];
                tasListesi[tasListesi.IndexOf((gosterge + 1) % 52)] = okey;
            }
            //******************************************************************************************
            
            shuffle(tasListesi); // Karıştırma Fonksiyonu

            foreach (var item in tasListesi)  //Karıştırılan taşlar yazılır.
            {
                Console.Write(" "+item);

            }
            Console.WriteLine(" ");
            Console.WriteLine("*********************");


            // Karıştırılan Taşlar Oyunculara verilmek üzere dağıtılır.Not: Daha sonra bu taşlar oyuncu sırası belirlenme durumuna göre oyunculara verilir.
            int[] player1 = new int[15];
            tasListesi.CopyTo(0, player1, 0, 15);

            //--------------------------------

            int[] player2 = new int[14];
            tasListesi.CopyTo(15,player2, 0, 14);

            //--------------------------------
            int[] player3 = new int[14];
            tasListesi.CopyTo(29, player3, 0, 14);
            //--------------------------------
            int[] player4 = new int[14];
            tasListesi.CopyTo(43, player4, 0, 14);

            //--------------------------------



            SırayıBelirleDagıt();  //Sırayı belirleyen ve Oyunculara taşlarını veren fonksiyon

            //Oyuncu Taşlarını Yaz
            Console.WriteLine("Player1");
            foreach (var item in first)
            {
                Console.Write(item);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Player2");
            foreach (var item in second)
            {
                Console.Write(item);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Player3");
            foreach (var item in third)
            {
                Console.Write(item);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Player4");
            foreach (var item in fourth)
            {
                Console.Write(item);
            }
            //----------



            void GöstergeSecim()  //Gösterge Seç  
            {
                Random rastgele1 = new Random();
                 gosterge = rastgele1.Next(1, 104);
                if(gosterge == 52 || gosterge == 104) //Sahte okeyler gösterge olamaz.
                {
                    GöstergeSecim();
                }    
            }


            void shuffle(ArrayList arrayRandom)   // Taşları karıştır.
            {
                for (int t = 1; t < arrayRandom.Count; t++)
                {
                    Random random = new Random();
                    int tmp = (int)arrayRandom[t];
                    int r = random.Next(t, arrayRandom.Count);
                    arrayRandom[t] = arrayRandom[r];
                    arrayRandom[r] = tmp;
                }
            }

            void SırayıBelirleDagıt()  //  Oyuncuların sırasını random verir ve Önceden dağıtılmış taş dizilerini oyunculara atar.
            {
                int randomPlayer;
                Random random = new Random();
                randomPlayer = random.Next(1, 4);

                
                    if(randomPlayer == 1)
                    {
                        first = (int[])player1;
                        second = (int[])player2;
                        third = (int[])player3;
                        fourth = (int[])player4;

                    }
                    else if (randomPlayer == 2)
                    {
                        first = (int[])player4;
                        second = (int[])player1;
                        third = (int[])player2;
                        fourth = (int[])player3;
                    }
                    else if (randomPlayer == 3)
                    {
                        first = (int[])player3;
                        second = (int[])player4;
                        third = (int[])player1;
                        fourth = (int[])player2;
                    }
                    else
                    {
                        first = (int[])player2;
                        second = (int[])player3;
                        third = (int[])player4;
                        fourth = (int[])player1;
                    }

                

            }





        }
    }
}
