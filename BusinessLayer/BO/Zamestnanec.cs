#region FileDescription
// **************************************************************************************************
// Projekt: BusinessLayer - Zamestnanec.cs
// Created:  17.11.2020 23:26
// Modified: 21.11.2020 2020
// Description: Třída zaměstnanec
// ***************************************************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Enums;

namespace BusinessLayer.BO
{
    /// <summary>
    /// Třída s vlastnostmi specifickými pro zaměstnance v IS
    /// </summary>
    public class Zamestnanec:Osoba
    {
        #region Privátní proměnné
        private DateTime m_ZamestnanOd;
        private EnTypZamest m_TypZamest;
        #endregion

        #region Večejné proměnné
        /// <summary>
        /// Datum přijetí do zaměstnání
        /// </summary>
        public DateTime ZamestnanOd
        {
            get => m_ZamestnanOd;
            set => m_ZamestnanOd = value;
        }

        /// <summary>
        /// Typ zaměstnance
        /// </summary>
        public EnTypZamest TypZamestnance
        {
            get => m_TypZamest;
            set => m_TypZamest = value;
        }
        #endregion
        
        #region Veřejné metody
        /// <summary>
        /// Konstruktor třídy
        /// </summary>
        public Zamestnanec() : base()
        {

        }
        #endregion

    }//class
}//namespace
