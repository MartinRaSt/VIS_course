#region FileDescription

// **************************************************************************************************
// Projekt: CMDTest - Program.cs
// Created:  24.11.2020 15:56
// Modified: 24.11.2020 2020
// Description: Testovací projekt pro ladění funkcionality BL+DAL
// ***************************************************************************************************

#endregion

using System;
using BusinessLayer.BO;
using BusinessLayer.Controllers;
using BusinessLayer.Enums;

namespace CMDTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int x = SpravaZamestnancu.Instance.CelkovyPocetZamestnancu;
            Console.WriteLine(x);
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
            Console.WriteLine(SpravaZamestnancu.Instance.CelkovyPocetZamestnancu);
        }
    }//class
}//namespace