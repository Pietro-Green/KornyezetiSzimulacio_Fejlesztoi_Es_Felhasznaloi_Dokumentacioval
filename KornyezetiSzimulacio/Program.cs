using System;
using System.IO;

namespace OOP_ASS_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Futas klasszikus = new Klasszikus();
            //klasszikus.Futtatas();
            Futas fluid = new Fluid();
            fluid.Futtatas();

            Console.Write("\n\tA kilepeshez nyomja meg barmely gombot");
            Console.ReadKey();
            Console.Write("\n\n\t\t NEE NE AZT A GOMBOT AAA\n");
        }
    }
}