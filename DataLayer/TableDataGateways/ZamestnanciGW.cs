#region FileDescription

// **************************************************************************************************
// Projekt: DataLayer - ZamestnanciGW.cs
// Created:  24.11.2020 18:47
// Modified: 24.11.2020 2020
// Description: TableDataGateway pro třídu Zaměstnanci zápis do XML
// ***************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DTO.Structs;

namespace DataLayer.TableDataGateways
{

    /// <summary>
    /// Pomocná třída pro zapouzdření seznamu Zamestnancu
    /// </summary>
    [Serializable]
    [XmlRoot("ZamestnanciStorage")]
    public class ZamestnanciStorage
    {
        public List<ZamestnanecStruct> Zamestnanci { get; set; }
    }

    /// <summary>
    ///     TableDataGateway pro třidu Zamestnanci vzor singleton
    ///     Použití XML souboru jako uložiště
    /// </summary>
    public class ZamestnanciGW
    {
        #region Privátní metody

        private ZamestnanciGW()
        {
        }

        #endregion

        #region Veřejné proměnné

        public static ZamestnanciGW Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new ZamestnanciGW());
                }
            }
        }

        #endregion

        #region Privátní proměnné

        private static readonly object m_LockObj = new object();
        private static ZamestnanciGW m_Instance;

        #endregion

        #region Veřejné metody
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zamestToSave">Seznam všech zaměstnanců k uložení</param>
        /// <param name="msgErr">Chybové hlášení v případě chyby</param>
        /// <returns></returns>
        public bool Save(List<ZamestnanecStruct> zamestToSave, out string msgErr)
        {
            msgErr = string.Empty;
            var zamS = new ZamestnanciStorage();
            zamS.Zamestnanci = zamestToSave;

            XmlSerializer ser = new XmlSerializer(typeof(ZamestnanciStorage));
            using (FileStream fs = new FileStream(Properties.DBLayer.Default.ZamestXml, FileMode.Create))
            {
                try
                {
                    ser.Serialize(fs, zamS);
                }
                catch (Exception e)
                {
                    msgErr = e.Message;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Nacteni vsech zamestnancu z uloziste
        /// </summary>
        /// <param name="zamest">Seznam zaměstnanců</param>
        /// <param name="msgErr">Chybové hlášení</param>
        /// <returns>True: operace se povedla, False: nastala chyba</returns>
        public bool Load(out List<ZamestnanecStruct> zamest, out string msgErr)
        {
            zamest = null;
            msgErr = string.Empty;
            if (!File.Exists(Properties.DBLayer.Default.ZamestXml))
                return true;
            XmlSerializer ser = new XmlSerializer(typeof(ZamestnanciStorage));
            using (FileStream fs = new FileStream(Properties.DBLayer.Default.ZamestXml, FileMode.Open))
            {
                try
                {
                    var zamS = (ZamestnanciStorage)ser.Deserialize(fs);
                    zamest = zamS.Zamestnanci;
                }
                catch (Exception e)
                {
                    msgErr = e.Message;
                    return false;
                }
            }
            return true;
        }
        #endregion
    } //class
} //namespace