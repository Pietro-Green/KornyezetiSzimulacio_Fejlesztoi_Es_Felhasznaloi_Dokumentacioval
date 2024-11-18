using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ASS_2
{
    public class Klasszikus : Futas
    {
        public override void Futtatas()
        {
            Adatok allapot = Adatok.beOlvas();  //Singleton tervezesi minta (csak egyetlen objektumot peldanyositunk a bemenet alapjan, es a kesobbiekben is azt manipulaljuk, nem hozunk ujakat letre!)
            allapot.kiIrat(0);

            for (int i = 0; i <= 9; i++)
            {
                allapot.korSzim();
                allapot.kiIrat(i + 1);
            }

            allapot.legVizesebbTulajaKiIrasa();
        }
    }
}