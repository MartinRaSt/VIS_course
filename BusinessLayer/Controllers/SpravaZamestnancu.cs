#region FileDescription

// **************************************************************************************************
// Projekt: BusinessLayer - SpravaZamestnancu.cs
// Created:  24.11.2020 22:54
// Modified: 24.11.2020 2020
// Description: Správa zaměstnanců v IS
// ***************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.BO;
using BusinessLayer.Enums;
using DataLayer.TableDataGateways;
using DTO.Structs;

namespace BusinessLayer.Controllers
{
    /// <summary>
    /// Třída zodpovědná za správu zaměstnanců
    /// </summary>
    public class SpravaZamestnancu
    {
        #region Privátní proměnné

        private static readonly object m_LockObj = new object();
        private static SpravaZamestnancu m_Instance;

        private List<Zamestnanec> m_Zamestnanci;
        #endregion

        #region Veřejné proměnné

        public static SpravaZamestnancu Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new SpravaZamestnancu());
                }
            }
        }

        /// <summary>
        /// Seznam vsech zaměstnanců
        /// </summary>
        public List<Zamestnanec> Zamestnanci
        {
            get => m_Zamestnanci;
        }

        /// <summary>
        /// Celkový počet zaměstnanců
        /// </summary>
        public int CelkovyPocetZamestnancu => m_Zamestnanci.Count;

        #endregion

        #region Privátní metody

        private SpravaZamestnancu()
        {
            m_Zamestnanci  = new List<Zamestnanec>();
            NacteniZUloziste();
        }

        private bool NacteniZUloziste()
        {
            List<ZamestnanecStruct> lstZam = null;
            string errMsg = string.Empty;
            if (ZamestnanciGW.Instance.Load(out lstZam, out errMsg))
            {
                if (lstZam != null)
                {
                    foreach (var zm in lstZam)
                    {
                        Zamestnanci.Add(new Zamestnanec()
                        {
                            Id = zm.Id,
                            Jmeno = zm.Jmeno,
                            Prijmeni = zm.Prijmeni,
                            ZamestnanOd = zm.ZamestnanOd,
                            TypZamestnance = (EnTypZamest) zm.TypZamest
                        });
                    }
                }
                return true;
            }
            else
            {
                //Zalogujeme někam chybu
                throw new Exception($"Zamestnanci: NacteniZUloziste \n{errMsg}");
            }
        }

        private bool ZapisDoUloziste()
        {
            string errMsg = string.Empty;

            //Pomocny seznam pro ukladani
            List<ZamestnanecStruct> lstZam = new List<ZamestnanecStruct>();

            var maxID = m_Zamestnanci.Max(r => r.Id) + 1;

            //Naplneni zamestnancu
            foreach (var zam in m_Zamestnanci)
            {
                lstZam.Add(
                    new ZamestnanecStruct(zam.Id==-1?maxID++:zam.Id,
                        zam.Jmeno,zam.Prijmeni,zam.ZamestnanOd, (uint)zam.TypZamestnance));
            }
            
            if (!ZamestnanciGW.Instance.Save(lstZam, out errMsg))
            {
                //Zalogujeme někam chybu
                throw new Exception($"Zamestnanci: ZapisDoUloziste \n{errMsg}");
            }
            return true;
        }

        #endregion

        #region Veřejné metody

        /// <summary>
        /// Zapsani vsech zamestnancu do uloziste
        /// </summary>
        /// <returns></returns>
        public bool SaveAll()
        {
            return ZapisDoUloziste();
        }

        /// <summary>
        /// Vložení nového zaměstnance
        /// </summary>
        /// <param name="zamestnanec"> Objek třídy zaměstnanec</param>
        public void AddZamestnanec(Zamestnanec zamestnanec)
        {
            m_Zamestnanci.Add(zamestnanec);
        }

        #endregion
    }//class
}//namespace