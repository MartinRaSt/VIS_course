#region FileDescription

// **************************************************************************************************
// Projekt: DataLayer - UzivateleGW.cs
// Created:  24.11.2020 18:47
// Modified: 24.11.2020 2020
// Description: TableDataGateway pro Uzivatele IS
// ***************************************************************************************************

#endregion

using System;
using System.Data.SqlClient;

namespace DataLayer.TableDataGateways
{


    /// <summary>
    /// TableDataGateway použití vzoru pro třídu uživatelé
    /// </summary>
    public class UzivateleGW
    {
       
        #region Veřejné proměnné

        public static UzivateleGW Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new UzivateleGW());
                }
            }
        }

        #endregion

        #region Privátní proměnné

        private static readonly object m_LockObj = new object();
        private static UzivateleGW m_Instance;

        #endregion

        #region Privátní metody

        private UzivateleGW()
        {
        }

        #endregion

        #region Veřejné metody

        public bool LoadAll(out string errMsg)
        {
            errMsg = string.Empty;

            return true;
        }

        public bool SaveAll(out string errMsg)
        {
            errMsg = string.Empty;

            return true;
        }

        public bool InsertOrUpdate(ref long id, 
            out string jmeno, 
            out string prijmeni,
            out DateTime datumNarozeni,
            out DateTime clenemOd,
            out UInt16 spolehlivost,
            out string errMsg)
        {
            errMsg = string.Empty;
            jmeno = string.Empty;
            prijmeni = string.Empty;
            datumNarozeni = DateTime.MinValue;
            clenemOd = DateTime.MinValue;
            spolehlivost = 0;

            return true;
        }

        public bool Delete(long id, out string errMsg)
        {
            errMsg = string.Empty;

            return true;
        }

        /// <summary>
        /// Nalezeni uzivatele na zaklade jeho ID
        /// </summary>
        /// <param name="id">Hledane ID </param>
        /// <param name="jmeno">Jméno uživatele</param>
        /// <param name="prijmeni">Příjmení uživatele</param>
        /// <param name="datumNarozeni">Datum narození</param>
        /// <param name="clenemOd">Datum začátku členství</param>
        /// <param name="spolehlivost">Spolehlivost uživatele</param>
        /// <param name="errMsg">Chybové hlášení</param>
        /// <returns>TRUE hledání se provedlo, FALSE nastala chyba hledání</returns>
        public bool Find(long id, 
            out string jmeno, 
            out string prijmeni, 
            out DateTime datumNarozeni, 
            out DateTime clenemOd , 
            out UInt16 spolehlivost, 
            out string errMsg)
        {
            errMsg = string.Empty;
            jmeno = string.Empty;
            prijmeni = string.Empty;
            datumNarozeni = DateTime.MinValue;
            clenemOd = DateTime.MinValue;
            spolehlivost = 0;

            //Nalezeni uzivatele podle jeho id v DB
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    string sql =
                        "SELECT Jmeno,Prijmeni,DatumNarozeni,ClenemOd,Spolehlivost FROM Uzivatele WHERE (Id=@id)";
                    SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                    try
                    {
                        sqlCmd.Parameters.AddWithValue("@id", id);
                        var result = DataConnection.Instance.Select(sqlCmd);
                        try
                        {
                            if (result.HasRows)
                            {
                                while (result.Read())
                                {
                                    jmeno = result.GetString(0);
                                    prijmeni = result.GetString(1);
                                    datumNarozeni = result.GetDateTime(2);
                                    clenemOd = result.GetDateTime(3);
                                    spolehlivost = (ushort) result.GetInt16(4);
                                }
                            }
                        }
                        finally
                        {
                            result.Close();
                        }
                    }
                    finally
                    {
                        sqlCmd.Dispose();
                    }
                }
                finally
                {
                    DataConnection.Instance.Close();
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }

            return true;
        }
        #endregion

    }//class
}//namespace