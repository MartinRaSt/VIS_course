#region FileDescription
// **************************************************************************************************
// Projekt: BusinessLayer - Uzivatel.cs
// Created:  17.11.2020 23:25
// Modified: 21.11.2020 2020
// Description: Třída uživatel IS
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
    /// Třída pro udržování informací o zákaznících/uživatelích IS
    /// </summary>
    public class Uzivatel:Osoba
    {
        #region Privátní vlastnosti
        private DateTime m_ClenemOd;
        private EnHodnoceni m_Spolehlivost;
        private DateTime m_DatumNarozeni = DateTime.MinValue;
        #endregion

        #region Veřejné vlastnosti
        /// <summary>
        /// Kdy se stal členem knihovny
        /// </summary>
        public DateTime ClenemOd
        {
            get => m_ClenemOd;
            set => m_ClenemOd = value;
        }

        /// <summary>
        /// Hodnocení spolehlivosti
        /// </summary>
        public EnHodnoceni Spolehlivost
        {
            get => m_Spolehlivost;
            set => m_Spolehlivost = value;
        }

        /// <summary>
        /// Datum narození uživatele
        /// </summary>
        public DateTime DatumNarozeni
        {
            get => m_DatumNarozeni;
            set => m_DatumNarozeni = value;
        }

        /// <summary>
        /// Věk člena knihovny, pokud není datum narození tak vrací -1
        /// </summary>
        public int Vek
        {
            get
            {
                //nezadane datum narozeni
                if (m_DatumNarozeni.Equals(DateTime.MinValue))
                    return -1;

                var yr = DateTime.Today.Year - m_DatumNarozeni.Year - 1 +
                         (DateTime.Today.Month >= m_DatumNarozeni.Month && DateTime.Today.Day >= m_DatumNarozeni.Day ? 1 : 0);
                return yr < 0 ? 0 : yr;
            }
        }

        #endregion

        #region Veřejné metody
        /// <summary>
        /// Konstruktor třídy
        /// </summary>
        public Uzivatel() : base()
        {

        }
        #endregion


    }//class
}//namespace
