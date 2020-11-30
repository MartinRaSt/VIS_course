#region FileDescription

// **************************************************************************************************
// Projekt: BusinessLayer - SpravaUzivatelu.cs
// Created:  01.12.2020 0:18
// Modified: 01.12.2020 2020
// Description: Správa uživatelů v IS
// ***************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using BusinessLayer.BO;
using BusinessLayer.Enums;
using DataLayer.TableDataGateways;

namespace BusinessLayer.Controllers
{
    public class SpravaUzivatelu
    {
        #region Privátní proměnné

        private static readonly object m_LockObj = new object();
        private static SpravaUzivatelu m_Instance;

        private List<Uzivatel> m_Uzivatele;
        #endregion

        #region Veřejné proměnné

        public static SpravaUzivatelu Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new SpravaUzivatelu());
                }
            }
        }

        /// <summary>
        /// Seznam všech uživatelů
        /// </summary>
        public List<Uzivatel> Uzivatele
        {
            get => m_Uzivatele;
        }

        /// <summary>
        /// Celkový počet Uzivatelů
        /// </summary>
        public int CelkovyPocetUzivatelu => m_Uzivatele.Count;

        #endregion

        #region Privátní metody

        /// <summary>
        /// Objekt spravy uživatelů
        /// </summary>
        private SpravaUzivatelu()
        {
            m_Uzivatele = new List<Uzivatel>();
            NacteniZUloziste();
        }

        private bool NacteniZUloziste()
        {
            DataTable dtUzivatele = null;
            string errMsg = string.Empty;
            if (UzivateleGW.Instance.LoadAll(out dtUzivatele, out errMsg))
            {
                if (dtUzivatele != null)
                {
                    foreach (DataRow row in dtUzivatele.Rows)
                    {
                        Uzivatele.Add(new Uzivatel()
                        {
                            Id = (long)row["Id"],
                            Jmeno = row["Jmeno"].ToString(),
                            Prijmeni = row["Prijmeni"].ToString(),
                            DatumNarozeni = (DateTime)row["DatumNarozeni"],
                            ClenemOd = (DateTime)row["ClenemOd"],
                            Spolehlivost = (EnHodnoceni)((int)row["Spolehlivost"])
                        });
                    }
                }
                return true;
            }
            else
            {
                //Zalogujeme někam chybu
                throw new Exception($"Uživatelé: Načteni uživatelů z uložiště \n{errMsg}");
            }
        }//NacteniZUloziste

        private bool ZapisDoUloziste()
        {
            string errMsg = string.Empty;

            //Pomocny seznam pro ukladani
            DataTable dtUzivatele = new DataTable();

            //Naplneni uzivatelu do datatable
            foreach (var zam in m_Uzivatele)
            {
                //lstZam.Add(
                //    new ZamestnanecStruct(zam.Id == -1 ? maxID++ : zam.Id,
                //        zam.Jmeno, zam.Prijmeni, zam.ZamestnanOd, (uint)zam.TypZamestnance));
            }

            if (!UzivateleGW.Instance.SaveAll(dtUzivatele, out errMsg))
            {
                //Zalogujeme někam chybu
                throw new Exception($"Uzivatele: ZapisDoUloziste \n{errMsg}");
            }
            return true;
        }//ZapisDoUloziste

        #endregion

        #region Veřejné metody

        /// <summary>
        /// Zapsani vsech uzivatelu do uloziste
        /// </summary>
        /// <returns></returns>
        public bool SaveAll()
        {
            return ZapisDoUloziste();
        }

        /// <summary>
        /// Vložení nového zaměstnance
        /// </summary>
        /// <param name="uzivatel"> Objekt třídy uzivatel</param>
        public void AddZamestnanec(Uzivatel uzivatel)
        {
            m_Uzivatele.Add(uzivatel);
        }

        #endregion
    }//class
}//namespace