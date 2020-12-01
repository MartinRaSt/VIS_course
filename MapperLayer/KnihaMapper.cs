#region FileDescription

// **************************************************************************************************
// Projekt: Mappers - KnihaMapper.cs
// Created:  24.11.2020 15:54
// Modified: 24.11.2020 2020
// Description: Tato třída obsahuje DataMapper pro třídu kniha
// ***************************************************************************************************

#endregion

using MapperLayer;

namespace Mappers
{
    public class KnihaMapper:BaseMapper 
    {
        #region Veřejné proměnné

        public static KnihaMapper Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new KnihaMapper());
                }
            }
        }

        #endregion

        #region Privátní proměnné

        private static readonly object m_LockObj = new object();
        private static KnihaMapper m_Instance;

        #endregion

        #region Privátní metody

        private KnihaMapper()
        {
        }

        #endregion

        #region Veřejné metody

        #endregion
    } //class

} //namespace