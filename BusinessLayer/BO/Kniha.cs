#region FileDescription
// **************************************************************************************************
// Projekt: BusinessLayer - Kniha.cs
// Created:  17.11.2020 23:24
// Modified: 21.11.2020 2020
// Description: Třída kniha
// ***************************************************************************************************
#endregion

namespace BusinessLayer.BO
{
    /// <summary>
    /// Reprezentuje knihu
    /// </summary>
    public class Kniha: Entita
    {
        #region Privátní proměnné
        private string m_AutorJmeno;
        private string m_AutorPrijmeni;
        private string m_NazevKnihy;
        private string m_Vydavatel;
        private int m_RokVydani;
        private int m_Vydani;
        private string m_Jazyk;
        #endregion

        #region Veřejné vlastnosti
        public string AutorJmeno
        {
            get => m_AutorJmeno;
            set => m_AutorJmeno = value;
        }

        public string AutorPrijmeni
        {
            get => m_AutorPrijmeni;
            set => m_AutorPrijmeni = value;
        }

        public string NazevKnihy
        {
            get => m_NazevKnihy;
            set => m_NazevKnihy = value;
        }

        public string Vydavatel
        {
            get => m_Vydavatel;
            set => m_Vydavatel = value;
        }

        public int RokVydani
        {
            get => m_RokVydani;
            set => m_RokVydani = value;
        }

        public int Vydani
        {
            get => m_Vydani;
            set => m_Vydani = value;
        }

        public string Jazyk
        {
            get => m_Jazyk;
            set => m_Jazyk = value;
        }

        #endregion

        #region Privátní metody

        #endregion

        #region Veřejné metody
        /// <summary>
        /// Konstruktor třídy
        /// </summary>
        public Kniha() : base()
        {

        }
        #endregion

    }//class
}//namespace