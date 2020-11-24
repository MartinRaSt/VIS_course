#region FileDescription

// **************************************************************************************************
// Projekt: DataLayer - ZamestnanciGW.cs
// Created:  24.11.2020 18:47
// Modified: 24.11.2020 2020
// Description: TableDataGateway pro třídu Zaměstnanci zápis do XML
// ***************************************************************************************************

#endregion

namespace DataLayer.TableDataGateways
{
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

        #endregion
    } //class
} //namespace