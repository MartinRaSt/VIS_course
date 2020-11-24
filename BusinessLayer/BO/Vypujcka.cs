#region FileDescription
// **************************************************************************************************
// Projekt: BusinessLayer - Vypujcka.cs
// Created:  17.11.2020 23:27
// Modified: 21.11.2020 2020
// Description: Třída výpůjčka
// ***************************************************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BO
{
    /// <summary>
    /// Reprezentuje jednu výpůjčku knih
    /// </summary>
    public class Vypujcka: Entita
    {
        #region Privátní proměnné
        private List<Kniha> m_PujceneKnihy;
        private DateTime m_DatumVypujcky;
        private Uzivatel m_Zakaznik;
        private Zamestnanec m_Pujcil;
        private int m_Delka;
        #endregion

        #region Veřejné vlastnosti
        /// <summary>
        /// Seznam vypůjčených knih
        /// </summary>
        public System.Collections.Generic.List<Kniha> PujceneKnihy
        {
            get => m_PujceneKnihy;
            set => m_PujceneKnihy = value;
        }

        /// <summary>
        /// Datum výpujčky
        /// </summary>
        public System.DateTime DatumVypujcky
        {
            get => m_DatumVypujcky;
            set => m_DatumVypujcky = value;
        }

        /// <summary>
        ///Zákazník (uživatel), který si vypůjčil knihy
        /// </summary>
        public Uzivatel Zakaznik
        {
            get => m_Zakaznik;
            set => m_Zakaznik = value;
        }
        
        /// <summary>
        /// Zaměstnanec, který vydal knihy
        /// </summary>
        public Zamestnanec Pujcil
        {
            get => m_Pujcil;
            set => m_Pujcil = value;
        }

        /// <summary>
        /// Délka (doba) výpůjčky - počet dní
        /// </summary>
        public int Delka
        {
            get => m_Delka;
            set => m_Delka = value;
        }
        #endregion

        #region Veřejné metody
        /// <summary>
        /// Konstruktor tridy s parametry
        /// </summary>
        /// <param name="vypujcitel"></param>
        /// <param name="obsluha"></param>
        public Vypujcka(Osoba vypujcitel, Osoba obsluha, DateTime okamzikPujcky):base()
        {
            Zakaznik = (Uzivatel)vypujcitel;
            Pujcil = (Zamestnanec)obsluha;
            DatumVypujcky = okamzikPujcky;
            PujceneKnihy = new List<Kniha>();
        }

        /// <summary>
        /// Zjisteni poctu knih
        /// </summary>
        /// <returns>Pocet knih</returns>
        public int PocetKnih()
        {
            //throw new System.NotImplementedException();
            return PujceneKnihy?.Count() ?? 0;
        }
        #endregion
    }//class
}//namespace