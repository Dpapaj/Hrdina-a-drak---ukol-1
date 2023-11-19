using Hrdina_a_drak___úkol_1.Postavy;
using System;
using System.Collections.Generic;

namespace Hrdina_a_drak___úkol_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hrdina hrdina = new Hrdina("Geralt", 250, 35, 40);
            Drak drak = new Drak("Alduin", 450, 44, 50);

            List<Postava> postavy = new List<Postava>();
            postavy.Add(hrdina);
            postavy.Add(drak);

            postavy.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, postavy));
            Console.WriteLine(Environment.NewLine + Environment.NewLine);


            for (int i = 0; PocetZivychHrdinu(postavy)>0 && PocetZivychDraku(postavy)>0; i++)
            {
                Console.WriteLine("Kolo č.:" + i);

                for (int j = 0;j < postavy.Count; ++j)
                {
                    Postava utocnik = postavy[j];
                    if (utocnik.JeZiva())
                    {
                        Postava oponent = utocnik.VyberOponenta(postavy);
                        if (oponent != null)
                        {
                            if (utocnik is Hrdina hrdinaAktualni)
                            {
                                hrdinaAktualni.Utok(oponent);
                            }
                            utocnik.Utok(oponent);
                        }
                        else
                            continue;
                    }
                    
                    Console.WriteLine(Environment.NewLine + Environment.NewLine);
                }
            }

            if (PocetZivychHrdinu(postavy) > 0)
            {
                Console.WriteLine("Hrdinové vyhráli");
            }
            else if (PocetZivychDraku(postavy) > 0)
             {
                Console.WriteLine("Draci vyhráli");
            }
            else
            {
                Console.WriteLine("Nikdo vyhrál");
            }
        }

        public static int PocetZivychHrdinu(List<Postava> postavy)
        {
            int pocetZivychHrdinu = 0;
            foreach(Postava postava in postavy)
            {
                if (postava is Hrdina && postava.JeZiva())
                {
                    ++pocetZivychHrdinu;
                }
            }
            return pocetZivychHrdinu;
        }

        public static int PocetZivychDraku(List<Postava> postavy)
        {
            int pocetZivychDraku = 0;
            foreach (Postava postava in postavy)
            {
                if (postava is Drak && postava.JeZiva())
                {
                    ++pocetZivychDraku;
                }
            }
            return pocetZivychDraku;
        }
    }
}
