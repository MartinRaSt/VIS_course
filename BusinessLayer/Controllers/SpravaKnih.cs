#region FileDescription

// **************************************************************************************************
// Projekt: BusinessLayer - SpravaKnih.cs
// Created:  04.12.2020 0:18
// Modified: 04.12.2020 2020
// Description: Třída správce knih
// ***************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using BusinessLayer.BO;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Controllers
{
    public sealed class SpravaKnih
    {
        #region Privátní proměnné
        /// <summary>
        /// Privátní statická proměnná udržující vytvořenou instanci třídy
        /// </summary>
        private static SpravaKnih m_Instance = null;

        /// <summary>
        /// Pomocný objekt sloužící pro zajištění thread safe přístupu při vytváření instance
        /// </summary>
        private static readonly object m_LockObj = new object();

        /// <summary>
        /// Seznam všech knih v IS
        /// </summary>
        private List<Kniha> m_SeznamKnih;

        /// <summary>
        /// Zde je uložen odkaz na objekt implementující rozhraní Mapperu Kniha IKnihaMapper
        /// </summary>
        private static IKnihaMapper m_KnihaDataMapper = null;

        #endregion

        #region Veřejné vlastnosti

        /// <summary>
        /// Mapper zodpovědný za práci s třídou Kniha a seznamem Knih
        /// </summary>
        public static IKnihaMapper KnihaDataMapper
        {
            set => m_KnihaDataMapper = value;
        }

        /// <summary>
        /// Seznam všech knih v systému
        /// </summary>
        public List<Kniha> SeznamKnih => m_SeznamKnih;

        /// <summary>
        /// Celkový počet včech knih v systému
        /// </summary>
        public int CelkovyPocetKnih => m_SeznamKnih.Count;

        /// <summary>
        /// Statická vlastnost třídy, přes kterou se přistupuje ke třídě jako singletonu
        /// </summary>
        public static SpravaKnih Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new SpravaKnih());
                }
            }
        }

        #endregion

        #region Privátní metody
        /// <summary>
        /// Privátní konstruktor, třídu nelze vytvořit jinak, než přes přístup na valstnost Instance
        /// V rámci konstruktoru načte všechny knihy z uložiště
        /// </summary>
        private SpravaKnih()
        {

            m_SeznamKnih = new List<Kniha>();
            if (m_KnihaDataMapper != null)
            {
                string errMsg = string.Empty;
                List<Kniha> lstK;
                if (m_KnihaDataMapper.LoadAll(out lstK, out errMsg))
                {
                    m_SeznamKnih = lstK ;
                }
                else
                {
                    throw new DataException($"Nastala chyba při načtení knih z uložiště\n {errMsg}");
                }

            }
            else
            {
                throw new Exception("Není inicializován odkaz na interfaced object KnihaDataMapper");
            }
        }

        /// <summary>
        /// Vložení nebo aktualizace objektu Kniha v uložišti
        /// </summary>
        /// <param name="kniha"></param>
        private bool InsertOrUpdate(Kniha kniha)
        {
            if (m_KnihaDataMapper != null)
            {
                string errMsg = string.Empty;
                if (!m_KnihaDataMapper.InsertOrUpdate(kniha, out errMsg))
                {
                    throw new DataException($"Nastala chyba při vložení/aktualizaci knihy v uložiště\n {errMsg}");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new Exception("Není inicializován odkaz na interfaced object KnihaDataMapper");
            }
        }

        /// <summary>
        /// Smazání knihy z Uložiště
        /// </summary>
        /// <param name="kniha">Objekt, který chceme smazat</param>
        /// <returns>True, pokud se povedlo smazání</returns>
        private bool Delete(Kniha kniha)
        {
            if (m_KnihaDataMapper != null)
            {
                string errMsg = string.Empty;
                if (!m_KnihaDataMapper.Delete(kniha.Id, out errMsg))
                {
                    throw new DataException($"Nastala chyba při mazání knihy z uložiště\n {errMsg}");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new Exception("Není inicializován odkaz na interfaced object KnihaDataMapper");
            }
        }

        #endregion

        #region Veřejné metody

        /// <summary>
        /// Uložení všech knih
        /// </summary>
        public void SaveAllData()
        {
            if (m_KnihaDataMapper != null)
            {
                string errMsg = string.Empty;
                if (! m_KnihaDataMapper.SaveAll(m_SeznamKnih, out errMsg))
                {
                    throw new DataException($"Nastala chyba při zápisu knih do uložiště\n {errMsg}");
                }
            }
            else
            {
                throw new Exception("Není inicializován odkaz na interfaced object KnihaDataMapper");
            }
        }

        /// <summary>
        /// Vyhledani knihy podle jejího ID
        /// </summary>
        /// <param name="id">ID knihy</param>
        /// <returns>Vrací instanci objektu kniha nebo null pokud se nic nenašlo</returns>
        public Kniha VyhledejKnihu(int id)
        {
            //Zaporne ID značí neuložený nový záznam, takže ho asi nevyhledáme podle iD
            if (id < 0)
                return null;

            //Ověříme, že nemáme knihu již v načteném seznamu, pokud ano tak tento objekt vrátíme
            Kniha kn = m_SeznamKnih.Find(x => x.Id == id);
            if (kn != null)
                return kn;

            //Nebyl nalezen objekt v seznamu, tak zkusíme uložíště
            if (m_KnihaDataMapper != null)
            {
                string errMsg = string.Empty;
                Kniha knh = null;
                if (!m_KnihaDataMapper.Find(id,out knh, out errMsg))
                {
                    throw new DataException($"Nastala chyba při vyhledání knihy v uložiště\n {errMsg}");
                }
                else
                {
                    return knh;
                }
            }
            else
            {
                throw new Exception("Není inicializován odkaz na interfaced object KnihaDataMapper");
            }
        }

        /// <summary>
        /// Vloží novou knihu do seznamu knih a současně i do DB
        /// </summary>
        /// <param name="kniha">Objekt Kniha, ktrerý budeme vkládat</param>
        public void AddKniha(Kniha kniha)
        {
            if (InsertOrUpdate(kniha))
            {
                m_SeznamKnih.Add(kniha);
            }
        }

        /// <summary>
        /// Aktualizuje knihu v uložišti
        /// </summary>
        /// <param name="kniha">Objekt kniha, který chceme aktualizovat v uložišti</param>
        public void UpdateKniha(Kniha kniha)
        {
            //Aktualizace v ulozisti
            if (InsertOrUpdate(kniha))
            {
                //Aktualizovat musime i objekt v seznamu
                Kniha kn = m_SeznamKnih.Find(x => x.Id == kniha.Id);
                kn.NazevKnihy = kniha.NazevKnihy;
                kn.AutorPrijmeni = kniha.AutorPrijmeni;
                kn.AutorJmeno = kniha.AutorJmeno;
                kn.RokVydani = kniha.RokVydani;
                kn.Vydani = kniha.Vydani;
                kn.Jazyk = kniha.Jazyk;
            }
        }

        /// <summary>
        /// Smazání knihy z uložiště i ze seznamu knih
        /// </summary>
        /// <param name="kniha"></param>
        public void DeleteKniha(Kniha kniha)
        {
            //Mažeme objekt kniha v uložišti
           if (Delete(kniha))
           {
                //Musíme smazat i v seznamu knih
                m_SeznamKnih.Remove(kniha);
           }
        }


        #endregion

    }//class
}//namespace