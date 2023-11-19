using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Hrdina_a_drak___úkol_1.Postavy
{
     public class Postava:Object,IComparable<Postava>
    {
        public string Jmeno { get; set; }
        public int Zdravi { get; set; }
        public int MaxPoskozeni { get; set; }
        public int MaxObrana { get; set; }
        Random generovani = new Random();

        public Postava(string jmeno, int zdravi, int maxPoskozeni, int maxObrana)
        {
            this.Jmeno = jmeno;
            this.Zdravi = zdravi;
            this.MaxPoskozeni = maxPoskozeni;
            this.MaxObrana = maxObrana;
        }

        public void Utok(Postava oponent)
        { 
            int poskozeni = Convert.ToInt32(generovani.NextDouble() * MaxPoskozeni);
            if (oponent is Hrdina hrdinaAktualni)
            {
                int obrana = hrdinaAktualni.Obrana();
                poskozeni -= obrana;
                oponent.Zdravi -= poskozeni;
            }
            else
            {
                int obrana = oponent.Obrana();
                poskozeni -= obrana;
                oponent.Zdravi -= poskozeni;
            }

            if (poskozeni < 0)
            {
                poskozeni = -poskozeni;
            }

            Console.WriteLine($"Útok {Jmeno} v hodnotě:" + poskozeni);
            if (oponent.JeZiva())
            {
                Console.WriteLine($"Oponentovi jménem {oponent.Jmeno} zbývá {oponent.Zdravi} života");
            }
            else Console.WriteLine($"{oponent.Jmeno} zbývá 0 života");
        }


        public int Obrana()
        {
            int obrana = 0;
            if (Math.Round(generovani.NextDouble()) <= 0.5)
            {
                obrana = generovani.Next(0, MaxObrana);

                Console.WriteLine($"Obrana postavy jménem {Jmeno} v hodnotě:" + obrana);
            }
            return obrana;
        }

        public bool JeZiva()
        {
            if (Zdravi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Postava VyberOponenta(List<Postava>postavy)
        {
            Postava oponent = null;
            
            foreach(var postava in postavy)
            {
                if(this is Hrdina && postava is Drak && postava.JeZiva())
                {
                    oponent = postava;
                    break;
                }
                else if (this is Drak && postava is Hrdina && postava.JeZiva())
                {
                    oponent = postava;
                    break;
                }
            }
            return oponent;
        }

        public int CompareTo([AllowNull] Postava other)
        {
            if (other == null)
                return 1;

            return this.VypocitejSilu().CompareTo(other.VypocitejSilu());
           
        }
        public  double VypocitejSilu()
        {
            return 0.2 * Zdravi + 0.4 * (MaxPoskozeni) + 0.4 * MaxObrana;
        }
    }
}


