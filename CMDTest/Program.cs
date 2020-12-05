#region FileDescription

// **************************************************************************************************
// Projekt: CMDTest - Program.cs
// Created:  24.11.2020 15:56
// Modified: 24.11.2020 2020
// Description: Testovací projekt pro ladění funkcionality BL+DAL
// ***************************************************************************************************

#endregion

using System;
using System.Linq;
using BusinessLayer.BO;
using BusinessLayer.Controllers;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using Mappers;

namespace CMDTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Ukazka prace s TableDataGateway pro Zamestnance - ulozeni do XML souboru
            int x = SpravaZamestnancu.Instance.CelkovyPocetZamestnancu;
            Console.WriteLine($"Celkovy pocet zamestnanu v IS: {x}");
            //Pokud jich je méně než 5 tak vytvoříme 2 a uložíme
            if (x < 5)
            {
                SpravaZamestnancu.Instance.AddZamestnanec(new Zamestnanec()
                {
                    Jmeno = "Pepa",
                    Prijmeni = "Novák",
                    TypZamestnance = EnTypZamest.eJuniorKnihovnik,
                    ZamestnanOd = new DateTime(2000, 06, 01)
                });

                SpravaZamestnancu.Instance.AddZamestnanec(new Zamestnanec()
                {
                    Jmeno = "Igor",
                    Prijmeni = "Hnízdo",
                    TypZamestnance = EnTypZamest.eSpravce,
                    ZamestnanOd = new DateTime(1993, 01, 26)
                });
                SpravaZamestnancu.Instance.SaveAll();
            }
            Console.WriteLine($"Novy pocet zamestnancu v IS {SpravaZamestnancu.Instance.CelkovyPocetZamestnancu}");

            //Ukazka prace s TableDataGateway pro Uzivatele IS, prace s SQL serverem
            int u = SpravaUzivatelu.Instance.CelkovyPocetUzivatelu;
            Console.WriteLine($"Celkovy pocet Uzivatelu v IS {u}");
            //Pokud je méně uživatelů než 5 tak dva nové vytvoříme a uložíme
            if (u < 5)
            {
                SpravaUzivatelu.Instance.AddUzivatel(new Uzivatel()
                {
                    Jmeno = "Arne",
                    Prijmeni = "Farin",
                    DatumNarozeni = new DateTime(2000,1,10),
                    ClenemOd = new DateTime(2015,6,7),
                    Spolehlivost = EnHodnoceni.eSpolehlivy
                });

                SpravaUzivatelu.Instance.AddUzivatel(new Uzivatel()
                {
                    Jmeno = "Jules",
                    Prijmeni = "Verne",
                    DatumNarozeni = new DateTime(1900, 7, 1),
                    ClenemOd = new DateTime(1920, 3, 19),
                    Spolehlivost = EnHodnoceni.eSpolehlivy
                });

                SpravaUzivatelu.Instance.AddUzivatel(new Uzivatel()
                {
                    Jmeno = "Pepe",
                    Prijmeni = "Novotny",
                    DatumNarozeni = new DateTime(1945, 5, 13),
                    ClenemOd = new DateTime(1955, 11, 9),
                    Spolehlivost = EnHodnoceni.eNespolehlivy
                });
            }
            Console.WriteLine($"Celkovy pocet Uzivatelu v IS {SpravaUzivatelu.Instance.CelkovyPocetUzivatelu}");

            //Update prvni ho uzivatele v seznamu
            var uFirst = SpravaUzivatelu.Instance.Uzivatele.First();
            Console.WriteLine($"Prvni uzivatel ({uFirst.Id})  {uFirst.Jmeno} {uFirst.Prijmeni}");
            //Zmena uzivatele
            uFirst.Jmeno = "Pepa";
            uFirst.Prijmeni = "Mares";
            string err = string.Empty;
            Uzivatel uziv = null;
            if (SpravaUzivatelu.Instance.UpdateUzivatel(uFirst, out err))
            {
                if (SpravaUzivatelu.Instance.FindUzivatel(uFirst.Id, out uziv, out err))
                {
                    Console.WriteLine($"Prvni uzivatel ({uziv.Id}) upraveno v DB {uziv.Jmeno} {uziv.Prijmeni}");
                }
                else
                {
                    Console.WriteLine($"Nastala chyba při hledani uživatele {uFirst.Id} v DB\n {err}");
                }
            }
            else
            {
                Console.WriteLine($"Nastala chyba při aktualizaci uživatele v DB\n {err}");
            }

            //Ukazka použití DataMapperuKniha
            //Vložení dependency - nastavujeme do spravce knih referenci na mapper pomoci interface
            SpravaKnih.KnihaDataMapper = KnihaMapper.Instance;

            //Počet knih v IS, v ramci konstruktoru se zavola nacteni vsech knih z uložistě
            int k = SpravaKnih.Instance.CelkovyPocetKnih;

            Console.WriteLine($"Celkovy pocet Knih v IS {k}");
            //Pokud je méně uživatelů než 5 tak dva nové vytvoříme a uložíme
            if (k < 5)
            {
                SpravaKnih.Instance.AddKniha(new Kniha()
                {
                    AutorJmeno = "Olgoj",
                    AutorPrijmeni = "Chorchoj",
                    NazevKnihy = "Dune",
                    Vydavatel = "Computer Press",
                    RokVydani = 2020,
                    Vydani = 1,
                    Jazyk = "CZ"
                });

                SpravaKnih.Instance.AddKniha(new Kniha()
                {
                    AutorJmeno = "Jan",
                    AutorPrijmeni = "Novak",
                    NazevKnihy = "Rozhledna",
                    Vydavatel = "Mlada Fronta",
                    RokVydani = 1976,
                    Vydani = 5,
                    Jazyk = "CZ"
                });
            }
            Console.WriteLine($"Celkovy pocet Knih v IS {SpravaKnih.Instance.CelkovyPocetKnih}");
            //Pokud je méně uživatelů než 5 tak dva nové vytvoříme a uložíme

            //Upravime v knihach
            Kniha kn = SpravaKnih.Instance.VyhledejKnihu(3);
            kn.AutorPrijmeni = "Upraveny Autor";
            SpravaKnih.Instance.UpdateKniha(kn);

        }


    }//class
}//namespace