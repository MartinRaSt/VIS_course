#region FileDescription

// **************************************************************************************************
// Projekt: DesktopApp - UIHelper.cs
// Created:  07.12.2020 23:25
// Modified: 07.12.2020 2020
// Description: Správce UI aplikace, pomocné objekty a metody
// ***************************************************************************************************

#endregion

using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BusinessLayer.Controllers;
using Mappers;

namespace DesktopApp
{
    public class UIHelper
    {

        #region Privátní proměnné

        private const string coJmenoAdmin = "admin";
        private const string coHesloAdmin = "admin";
        private const string coJmenoUser = "user";
        private const string coHesloUser = "user";


        private bool m_Prihlasen;

        private bool m_Uzivatel;

        private string m_Jmeno;

        /// <summary>
        /// Privátní statická proměnná udržující vytvořenou instanci třídy
        /// </summary>
        private static UIHelper m_Instance = null;

        /// <summary>
        /// Pomocný objekt sloužící pro zajištění thread safe přístupu při vytváření instance
        /// </summary>
        private static readonly object m_LockObj = new object();

        private SpravaKnih m_SpravceKnih;
        private SpravaUzivatelu m_SpravceUzivatelu;
        private SpravaZamestnancu m_SpravceZamestnancu;

        #endregion

        #region Veřejné vlastnosti

        /// <summary>
        /// Přihlášený je uživatel jinak je to správce
        /// </summary>
        public bool Uzivatel
        {
            get => m_Uzivatel;
            set => m_Uzivatel = value;
        }

        /// <summary>
        /// Je přihlášen někdo do systému
        /// </summary>
        public bool Prihlasen
        {
            get => m_Prihlasen;
            set => m_Prihlasen = value;
        }

        /// <summary>
        /// Jméno přihlášeného uživatele
        /// </summary>
        public string Jmeno
        {
            get => m_Jmeno;
            set => m_Jmeno = value;
        }

        public SpravaKnih SpravceKnihBL
        {
            get => m_SpravceKnih;
        }

        public SpravaUzivatelu SpravceUzivateluBL
        {
            get => m_SpravceUzivatelu;
        }

        public SpravaZamestnancu SpravceZamestnancuBL
        {
            get => m_SpravceZamestnancu;
        }

    /// <summary>
    /// Statická vlastnost třídy, přes kterou se přistupuje ke třídě jako singletonu
    /// </summary>
    public static UIHelper Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new UIHelper());
                }
            }
        }
        #endregion

        #region Privátní metody

        /// <summary>
        /// Inicializuje a vytvoří objekty v jednotlivých třídách
        /// </summary>
        private void InitLayersObjects()
        {
            //Vložení dependency - nastavujeme do spravce knih referenci na mapper pomoci interface
            SpravaKnih.KnihaDataMapper = KnihaMapper.Instance;

            //Vytvoření business objektů pro správu 
            m_SpravceUzivatelu = SpravaUzivatelu.Instance;
            m_SpravceKnih = SpravaKnih.Instance;
            m_SpravceZamestnancu = SpravaZamestnancu.Instance;

        }

        /// <summary>
        /// Privátní konstruktor, třídu nelze vytvořit jinak, než přes přístup na vlastnost Instance
        /// </summary>
        private UIHelper()
        {
            InitLayersObjects();

            Jmeno = string.Empty;
            Uzivatel = false;
            Prihlasen = false;
        }
        #endregion

        #region Veřejné metody

        public bool ValidateLogin(string jmeno, string heslo)
        {
            if (jmeno == coJmenoAdmin && heslo == coHesloAdmin)
            {
                Jmeno = jmeno;
                Prihlasen = true;
                Uzivatel = false;
            }
            else if (jmeno == coJmenoUser && heslo == coHesloUser)
            {
                Jmeno = jmeno;
                Prihlasen = true;
                Uzivatel = true;
            }
            else
            {
                Jmeno = string.Empty;
                Prihlasen = false;
                Uzivatel = false;
                return false;
            }

            return true;
        }
        #endregion

    } //Class
} //Namespace