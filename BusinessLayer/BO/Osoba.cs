#region FileDescription
// **************************************************************************************************
// Projekt: BusinessLayer - Osoba.cs
// Created:  17.11.2020 23:25
// Modified: 21.11.2020 2020
// Description: Společný předek pro všechny uživatele/osoby v IS
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
    /// Bázový kontejner se společnými vlastnostmi pro uživatele IS
    /// </summary>
    public class Osoba: Entita
    {
        #region Privátní proměnné
        private string m_Jmeno;
        private string m_Prijmeni;
        #endregion

        #region Veřejné vlastnosti
        /// <summary>
        /// Jméno osoby
        /// </summary>
        public string Jmeno
        {
            get => m_Jmeno;
            set => m_Jmeno = value;
        }

        /// <summary>
        /// Příjmení osoby
        /// </summary>
        public string Prijmeni
        {
            get => m_Prijmeni;
            set => m_Prijmeni = value;
        }
        #endregion

        #region Veřejné metody
        /// <summary>
        /// Konstruktor třídy
        /// </summary>
        public Osoba() : base()
        {

        }
        #endregion

    }//class
}//namespace
