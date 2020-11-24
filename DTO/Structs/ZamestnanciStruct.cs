#region FileDescription

// **************************************************************************************************
// Projekt: DTO - ZamestnanciStruct.cs
// Created:  24.11.2020 21:44
// Modified: 24.11.2020 2020
// Description: Přenosový objekt pro zaměstnance
// ***************************************************************************************************

#endregion

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml;

namespace DTO.Structs
{
    [Serializable]
    public struct ZamestnanecStruct: ISerializable
    {
        #region Privátní proměnné
        private long m_Id;
        private string m_Jmeno;
        private string m_Prijmeni;
        private DateTime m_ZamestnanOd;
        private uint m_TypZamest;
        #endregion

        #region Veřejné proměnné
        public long Id
        {
            get => m_Id;
            set => m_Id = value;
        }

        public string Jmeno
        {
            get => m_Jmeno;
            set => m_Jmeno = value;
        }

        public string Prijmeni
        {
            get => m_Prijmeni;
            set => m_Prijmeni = value;
        }

        public DateTime ZamestnanOd
        {
            get => m_ZamestnanOd;
            set => m_ZamestnanOd = value;
        }

        public uint TypZamest
        {
            get => m_TypZamest;
            set => m_TypZamest = value;
        }
        #endregion

        #region Veřejné metody
        public ZamestnanecStruct(long id, string jmeno, string prijmeni, DateTime zamestnanOd, uint typZamest)
        {
            m_Id = id;
            m_Jmeno = jmeno;
            m_Prijmeni = prijmeni;
            m_ZamestnanOd = zamestnanOd;
            m_TypZamest = typZamest;
        }

        /// <summary>
        /// Konstruktor volany při deserializaci
        /// </summary>
        /// <param name="info"></param>
        /// <param name="text"></param>
        public ZamestnanecStruct(SerializationInfo info, StreamingContext text) : this()
        {
            m_Id = info.GetInt64("ID");
            m_Jmeno = info.GetString("Jmeno");
            m_Prijmeni = info.GetString("Prijmeni");
            m_ZamestnanOd = info.GetDateTime("ZamestnanOd");
            m_TypZamest = info.GetUInt32("TypZamest");
        }

        /// <summary>
        /// Metoda se vola pri serializaci
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", m_Id);
            info.AddValue("Jmeno", m_Jmeno);
            info.AddValue("Prijmeni", m_Prijmeni);
            info.AddValue("ZamestnanOd", m_ZamestnanOd);
            info.AddValue("TypZamest", m_TypZamest);
        }

        #endregion

    } //struct
} //namespace