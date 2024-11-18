using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OOP_ASS_2
{
    [TestFixture]
    public class Tesztesetek
    {
        [Test]
        public void IdojarasKiszamitas_Teszt()
        {
            FoldTerulet[] teruletek = new FoldTerulet[]
            {
                new FoldTerulet("Bean",     'p', 20),
                new FoldTerulet("Green",    't', 30),
                new FoldTerulet("Dean",     'z', 10)
            };                                                      //Pelda Inicializalas

            Adatok allapot = new Adatok(teruletek, 0);

            string idojaras = allapot.idojarasKiszamitas();         //Vegrehajtas

            Assert.That(idojaras, Is.Not.Null.Or.Not.Empty);        //Teszteles
        }

        [Test]
        public void LegVizesebb_Teszt()
        {
            FoldTerulet[] teruletek = new FoldTerulet[]
            {
                new FoldTerulet("Bean",     'p', 10),
                new FoldTerulet("Green",    'z', 20),
                new FoldTerulet("Dean",     't', 30)
            };                                                      //Pelda Inicializalas

            Adatok allapot = new Adatok(teruletek, 0);

            Adatok eredmeny = allapot.legVizesebbTulajaKiIrasa();   //Vegrehajtas

            Assert.That(eredmeny, Is.EqualTo(allapot));             //Teszteles
        }

        [Test]
        public void KorSzim_Teszt()
        {
            FoldTerulet[] foldTeruletek = new FoldTerulet[]
            {
                new FoldTerulet("Bean",     'p', 10),
                new FoldTerulet("Green",    'p', 20),
                new FoldTerulet("Dean",     'p', 20),
                new FoldTerulet("Teen",     'p', 30)
            };
            Adatok allapot = new Adatok(foldTeruletek, 0);          //Pelda Inicializalas

            allapot.korSzim();                                      //Vegrehajtas

                                                                    // Teszteles
            Assert.AreEqual(12, allapot.paratartalom);              // Az 1. kor utan           az elvart paratartalom

            Assert.AreEqual(7,  allapot.foldTeruletek[0].viz);      // Az elvart vizmennyiseg   az  1. teruleten
            Assert.AreEqual(17, allapot.foldTeruletek[1].viz);      // Az elvart vizmennyiseg   a   2. teruleten
            Assert.AreEqual(17, allapot.foldTeruletek[2].viz);      // Az elvart vizmennyiseg   a   2. teruleten
            Assert.AreEqual(27, allapot.foldTeruletek[3].viz);      // Az elvart vizmennyiseg   a   3. teruleten

            Assert.AreEqual('p', allapot.foldTeruletek[0].fajta);   // Az elvart tipus az   1. teruleten
            Assert.AreEqual('z', allapot.foldTeruletek[1].fajta);   // Az elvart tipus a    2. teruleten
            Assert.AreEqual('z', allapot.foldTeruletek[2].fajta);   // Az elvart tipus a    3. teruleten
            Assert.AreEqual('z', allapot.foldTeruletek[3].fajta);   // Az elvart tipus a    4. teruleten
        }
    }
}