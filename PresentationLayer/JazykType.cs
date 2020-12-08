#region FileDescription
// **************************************************************************************************
// Projekt: PresentationLayerHelper - Class1.cs
// Created:  17.11.2020 23:21
// Modified: 21.11.2020 2020
// Description: Třída mapující typ jazyka text reprezentaci
// ***************************************************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class JazykType
    {
        #region Privátní vlastnosti

        /// <summary>
        /// Privátní statická proměnná udržující vytvořenou instanci třídy
        /// </summary>
        private static JazykType m_Instance = null;

        /// <summary>
        /// Pomocný objekt sloužící pro zajištění thread safe přístupu při vytváření instance
        /// </summary>
        private static readonly object m_LockObj = new object();

        private Dictionary<string, string> m_LangType;


        #endregion

        #region Veřejné vlastnosti
        public Dictionary<string, string> LangType
        {
            get => m_LangType;
        }

        /// <summary>
        /// Statická vlastnost třídy, přes kterou se přistupuje ke třídě jako singletonu
        /// </summary>
        public static JazykType Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new JazykType());
                }
            }
        }

        #endregion

        #region Privátní metody

        /// <summary>
        /// Prvotní naplnění jazyky
        /// </summary>
        private void FillDefaultLang()
        {
            m_LangType.Add("Cz", "Čeština");
            m_LangType.Add("En", "Angličtina");
            m_LangType.Add("Fr", "Francouzština");
            m_LangType.Add("Ru", "Ruština");
            m_LangType.Add("Es", "Španělština");
        }

        /// <summary>
        /// Konsruktor třídy
        /// </summary>
        private JazykType()
        {
            m_LangType = new Dictionary<string, string>();
            FillDefaultLang();
        }

        #endregion

        #region Veřejné metody

        /// <summary>
        /// Vrátí seznam jazyků
        /// </summary>
        /// <returns></returns>
        public List<string> GetJazyky()
        {
            List<string> str = new List<string>();
            foreach (var hodnota in m_LangType)
            {
                str.Add($"{hodnota.Key} - {hodnota.Value}");
            }

            return str;
        }

        /// <summary>
        /// Získá zkratku jazyka z Indexu
        /// </summary>
        /// <param name="ix">index jazyka</param>
        /// <returns>Vrací zkratku jazyka pro uložení do DB</returns>
        public string GetJazykFromIx(int ix)
        {
            return m_LangType.Keys.ToArray()[ix];
        }
        #endregion

    }//class
}//namespace
