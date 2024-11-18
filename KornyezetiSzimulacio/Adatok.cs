using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ASS_2
{
    internal class Adatok
    {
        public FoldTerulet[]    foldTeruletek;
        public int              paratartalom;

        public Adatok(FoldTerulet[] foldTeruletek, int paratartalom)   //ctrl + . al generaltam azert ilyen
        {
            this.foldTeruletek  = foldTeruletek;
            this.paratartalom   = paratartalom;
        }

        public static Adatok beOlvas()
        {
            Console.Write("File neve: ");
            string? fajlNev = Console.ReadLine();

            try
            {
                string[] sorok = File.ReadAllLines(fajlNev);

                Console.WriteLine("\nTartalma:");

                int hossz = int.Parse(sorok[0]);

                FoldTerulet[] teruletek = new FoldTerulet[hossz];

                for (int i = 1; i <= hossz; i++)
                {
                    string[] sor = sorok[i].Split(' ');

                    string  tulaj   = sor[0];
                    char    fajta   = char.Parse(sor[1]);
                    int     viz     = int.Parse(sor[2]);

                    FoldTerulet terulet = new FoldTerulet(tulaj, fajta, viz);

                    teruletek[i-1] = terulet;
                }

                int paraTartalom = int.Parse(sorok[hossz+1]);

                //Console.WriteLine("\n\tParatartalom: {0}\n", paraTartalom);

                return new Adatok(teruletek,paraTartalom);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nincs ilyen file (a kiterjesztest is meg kell adni).");

                return new Adatok(new FoldTerulet[0], 0);
            }
        }

        public Adatok kiIrat(int sorszam)
        {
            Console.WriteLine("A szimulacio {0}. kore utan az idojaras {1}, valamint", sorszam , this.idojarasKiszamitas());

            FoldTerulet[]   foldTeruletek   = this.foldTeruletek;
            int             paraTartalom    = this.paratartalom;

            Console.Write("\n");
            for (int i = 0; i < foldTeruletek.Length; i++)  { Console.WriteLine("\tTulaj: {0}\tFajta: {1}\tViz: {2} km^3", foldTeruletek[i].tulaj, foldTeruletek[i].fajta, foldTeruletek[i].viz); }
            Console.WriteLine("\n\tParatartalom: {0}%\n", paraTartalom);

            return this;
        }

        public string idojarasKiszamitas()          //azert angolul, hogy rovidebb legyen a fuggveny neve
        {
            string idojaras = "";

            if (this.paratartalom > 70)
            {
                idojaras = "esos";
                this.paratartalom = 30;
            }
            else if (this.paratartalom < 40) { idojaras = "napos"; }
            else
            {
                Random random = new Random();
                int veletlenSzam = random.Next(0, 101);

                if ((this.paratartalom - 40) * 3.3 < veletlenSzam) { idojaras = "esos"; }
                else { idojaras = "felhos"; }
            }
            return idojaras;
        }

        public Adatok korSzim()                     //Szimulalja, hogy egy kor utan a bemeno adatok alapjan a kovetkezo korre milyen adatok mennek ki
        {
            /* //idojaras
            if (adatok.paratartalom > 70)
            {
                idojaras = "esos";
                adatok.paratartalom = 30;
            }
            else if (adatok.paratartalom < 40)  { idojaras = "napos";   }
            else
            {
                Random random   = new Random();
                int veletlenSzam= random.Next(0, 101);

                if( (adatok.paratartalom - 40) * 3.3 < veletlenSzam)    { idojaras = "esos";    }
                else                                                    { idojaras = "felhos";  }
            }*/
            string idojaras = "";

            foreach (FoldTerulet terulet in this.foldTeruletek)
            {
                idojaras = this.idojarasKiszamitas();   //A feladatleiras szerint nem vagyok benne biztos, hogy ezt minden teruletszamitashoz meg kell hivni, ha nem, akkor ezt a foreach ele kell helyezni!

                if (terulet.fajta == 'p')
                {
                    if (idojaras == "napos")
                    {
                        terulet.viz -= 3;
                        if (terulet.viz < 0)        { terulet.viz = 0;  }   //egyetlen foldterulet vizmennyisege sem lehet negativ
                    }
                    else if (idojaras == "felhos")  { terulet.viz += 1; }
                    else if (idojaras == "esos")    { terulet.viz += 5; }

                    this.paratartalom += 3;
                    if (terulet.viz > 15)           { terulet.fajta = 'z';  }

                }
                else if (terulet.fajta == 'z')
                {
                    if (idojaras == "napos")
                    {
                        terulet.viz -= 6;
                        if (terulet.viz < 0)        { terulet.viz = 0;  }   //egyetlen foldterulet vizmennyisege sem lehet negativ
                    }
                    else if (idojaras == "felhos")  { terulet.viz += 2; }
                    else if (idojaras == "esos")    { terulet.viz += 10;}

                    this.paratartalom += 7;
                    if      (terulet.viz > 50)      { terulet.fajta = 't'; }
                    else if (terulet.viz < 16)      { terulet.fajta = 'p'; }

                }
                else if (terulet.fajta == 't')
                {
                    if (idojaras == "napos")
                    {
                        terulet.viz -= 10;
                        if (terulet.viz < 0)        { terulet.viz = 0;  }   //egyetlen foldterulet vizmennyisege sem lehet negativ
                    }
                    else if (idojaras == "felhos")  { terulet.viz += 3; }
                    else if (idojaras == "esos")    { terulet.viz += 15;}

                    this.paratartalom += 10;
                    if (terulet.viz < 51)           { terulet.fajta = 'z'; }
                }
            }

            return this;

            //A paratartalomrol nem irja a feladat, hogy nem mehet 100% fole, azert nem korlatoztam
            /* Terv
            Megkapja az adatokat                                                    ✓
            A paratartalom alapjan meghatarozza az idojarast                        ✓
            Foreachel vegigmegy a FoldTerulet[]-on                                  ✓
                Az idojaras es az adott foldterulet fuggvenyeben vegez muveletet
                Az idojaras es az adott foldterulet fuggvenyeben vegez muveletet
                .
                .
                .
            Az uj paratartalom alapjan megadja az uj idojarast                      ✓
                Ki is iratjuk                                                       ✓
            */
        }

        public Adatok legVizesebbTulajaKiIrasa()    //Gyűjtemények bejárása a tanult programozási tételek alapján (itt maximum kiválasztás tétele alapján)
        {
            int     vizMennyiseg        = this.foldTeruletek[0].viz;    //Inicializaljuk
            string  legVizesebbTulaja   = this.foldTeruletek[0].tulaj;  //A legelso elemre


            foreach (FoldTerulet terulet in this.foldTeruletek)
            {
                if (vizMennyiseg < terulet.viz)
                {
                    vizMennyiseg        = terulet.viz;
                    legVizesebbTulaja   = terulet.tulaj;
                }
            }
            Console.WriteLine("\n\tA 10. kor utan\n\t\tA legvizesebb terulet tulaja:\t{0}\n\t\tA viz mennyisege pedig\t    :\t{1}", legVizesebbTulaja, vizMennyiseg);

            return this;
        }
    }
}