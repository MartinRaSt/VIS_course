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
                            Id = Convert.ToInt64(row["Id"]),
                            Jmeno = row["Jmeno"].ToString(),
                            Prijmeni = row["Prijmeni"].ToString(),
                            DatumNarozeni = (DateTime)row["DatumNarozeni"],
                            ClenemOd = (DateTime)row["ClenemOd"],
                            Spolehlivost = (EnHodnoceni)(Convert.ToUInt16(row["Spolehlivost"]))
                        });
                    }
                }
                return true;
            }
            else
            {
                //Zalogujeme někam chybu
                throw new Exception($"Chyba Uživatelé: Načteni uživatelů z uložiště \n{errMsg}");
            }
        }//NacteniZUloziste

        private bool ZapisDoUloziste()
        {
            string errMsg = string.Empty;

            //Pomocny seznam pro ukladani
            DataTable dtUzivatele = new DataTable();

            //definice struktury datatable
            dtUzivatele.Columns.Add("Id", typeof(int));
            dtUzivatele.Columns.Add("Jmeno", typeof(string));
            dtUzivatele.Columns.Add("Prijmeni", typeof(string));
            dtUzivatele.Columns.Add("DatumNarozeni", typeof(DateTime));
            dtUzivatele.Columns.Add("ClenemOd", typeof(DateTime));
            dtUzivatele.Columns.Add("Spolehlivost", typeof(UInt32));

            
            //Naplneni uzivatelu do datatable
            foreach (var zam in m_Uzivatele)
            {
                DataRow row = dtUzivatele.NewRow();
                row["Id"] = zam.Id;
                row["Jmeno"] = zam.Jmeno;
                row["Prijmeni"] = zam.Prijmeni;
                row["DatumNarozeni"] = zam.DatumNarozeni;
                row["ClenemOd"] = zam.ClenemOd;
                row["Spolehlivost"] = (uint)zam.Spolehlivost;
                dtUzivatele.Rows.Add(row);
            }
            //Potvrdime zmeny z tabulce
            dtUzivatele.AcceptChanges();

            if (!UzivateleGW.Instance.SaveAll(dtUzivatele, out errMsg))
            {
                //Zalogujeme někam chybu
                throw new Exception($"Chyba Uživatelé: Zápis do uložiště \n{errMsg}");
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
        /// Vložení nového uživatele
        /// </summary>
        /// <param name="uzivatel"> Objekt třídy uzivatel</param>
        public void AddUzivatel(Uzivatel uzivatel)
        {
            m_Uzivatele.Add(uzivatel);
            var id = uzivatel.Id;
            string err = string.Empty;
            //Vlozime do DB
            if ( UzivateleGW.Instance.InsertOrUpdate(
                ref id,
                uzivatel.Jmeno,
                uzivatel.Prijmeni,
                uzivatel.DatumNarozeni,
                uzivatel.ClenemOd,
                (ushort) uzivatel.Spolehlivost,
                out err))
            {
                //Nastavime spravne ID ktere nam vratila DB
                uzivatel.Id = id;
            }
        }

        /// <summary>
        /// Změna uživatele 
        /// </summary>
        /// <param name="uzivatel"> Objekt třídy uzivatel</param>
        /// <param name="error">Text chyby pokud nastala</param>
        /// <returns>True zmena se provedla, False nastala chyba</returns>
        public bool UpdateUzivatel(Uzivatel uzivatel, out string error)
        {
            var id = uzivatel.Id;
            return UzivateleGW.Instance.InsertOrUpdate(
                ref id,
                uzivatel.Jmeno,
                uzivatel.Prijmeni,
                uzivatel.DatumNarozeni,
                uzivatel.ClenemOd,
                (ushort) uzivatel.Spolehlivost,
                out error);
        }

        public bool FindUzivatel(long uID, out Uzivatel uzivatel,  out string error)
        {
            error = String.Empty;
            string jmeno = string.Empty;
            string prijmeni = string.Empty;
            DateTime datumNarozeni = DateTime.MinValue; 
            DateTime clenemOd = DateTime.MinValue;
            ushort spolehlivost = 0;
            uzivatel = null;

            if (UzivateleGW.Instance.Find(
                uID,
                out jmeno,
                out prijmeni,
                out datumNarozeni,
                out clenemOd,
                out spolehlivost,
                out error))
            {
                uzivatel = new Uzivatel ()
                    {
                        Id = uID,
                        Jmeno = jmeno,
                        Prijmeni = prijmeni,
                        DatumNarozeni = datumNarozeni,
                        ClenemOd = clenemOd,
                        Spolehlivost = (EnHodnoceni)spolehlivost
                    };
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }//class
}//namespace