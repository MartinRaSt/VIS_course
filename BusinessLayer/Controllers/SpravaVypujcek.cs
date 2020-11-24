#region FileDescription
// **************************************************************************************************
// Projekt: BusinessLayer - SpravaVypujcek.cs
// Created:  21.11.2020 11:39
// Modified: 21.11.2020 2020
// Description: Třída pro správu výpůjček
// ***************************************************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.BO;

namespace BusinessLayer.Controllers
{
    /// <summary>
    /// Třída pro správu výpůjček
    /// </summary>
    /// <remarks>
    /// Tato třída používá vzor singleton pro zajištění jedné instance
    /// </remarks>
    /// <example>Volání se provádí jako např. SpravaVypujcek.Instance.CelkovyPocetVypujcek</example>
    public sealed class SpravaVypujcek
    {
        #region Privátní proměnné
        /// <summary>
        /// Privátní statická proměnná udržující vytvořenou instanci třídy
        /// </summary>
        private static SpravaVypujcek m_Instance = null;

        /// <summary>
        /// Pomocný objekt sloužící pro zajištění thread safe přístupu při vytváření instance
        /// </summary>
        private static readonly  object m_LockObj = new object();

        /// <summary>
        /// Seznam včech výpůjček v IS
        /// </summary>
        private readonly List<Vypujcka> m_Vypujcky;

        #endregion

        #region Veřejné vlastnosti
        /// <summary>
        /// Seznam všech výpůjček v systému
        /// </summary>
        public List<Vypujcka> Vypujcky => m_Vypujcky;

        /// <summary>
        /// Celkový počet výpujček v systému
        /// </summary>
        public int CelkovyPocetVypujcek => m_Vypujcky.Count;

        /// <summary>
        /// Statická vlastnost třídy, přes kterou se přistupuje ke třídě jako singletonu
        /// </summary>
        public static SpravaVypujcek Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new SpravaVypujcek());
                }
            }
        }
        #endregion

        #region Privátní metody
        /// <summary>
        /// Privátní konstruktor, třídu nelze vytvořit jinak, než přes přístup na valstnost Instance
        /// </summary>
        private SpravaVypujcek()
        {
            
            m_Vypujcky = new List<Vypujcka>();
        }
        #endregion

    }//class
}//namespace