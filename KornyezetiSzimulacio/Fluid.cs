using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ASS_2
{
    public class Fluid : Futas
    {
        public override void Futtatas()
        {
            Adatok allapot = Adatok.beOlvas();  //Singleton tervezesi minta (csak egyetlen objektumot peldanyositunk a bemenet alapjan, es a kesobbiekben is azt manipulaljuk, nem hozunk ujakat letre!)
            allapot.kiIrat(0);

            allapot.korSzim().kiIrat(1).korSzim().kiIrat(2).korSzim().kiIrat(3).korSzim().kiIrat(4).korSzim().kiIrat(5).korSzim().kiIrat(6).korSzim().kiIrat(7).korSzim().kiIrat(8).korSzim().kiIrat(9).korSzim().kiIrat(10);

            //Fluent interface tervezesi minta (lehetové teszi muveletek lancolasat egy objektumon (itt pl return this segitsegevel))

            allapot.legVizesebbTulajaKiIrasa();

        }
    }
}
