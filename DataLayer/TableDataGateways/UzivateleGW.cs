#region FileDescription

// **************************************************************************************************
// Projekt: DataLayer - UzivateleGW.cs
// Created:  24.11.2020 18:47
// Modified: 24.11.2020 2020
// Description: TableDataGateway pro Uzivatele IS
// ***************************************************************************************************

#endregion

using System;

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
        
        #endregion

    }//class
}//namespace