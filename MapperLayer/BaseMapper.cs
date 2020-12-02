#region FileDescription

// **************************************************************************************************
// Projekt: Mappers - BaseMapper.cs
// Created:  02.12.2020 0:34
// Modified: 02.12.2020 2020
// Description: Bázová abstraktní třída pro všechny mappery
// ***************************************************************************************************

#endregion

using System.Collections.Generic;
using BusinessLayer.BO;

namespace MapperLayer
{
    /// <summary>
    /// Abstraktni metody, ktere jsou volany z potomků
    /// </summary>
    public abstract class BaseMapper
    {
        #region Veřejné metody
        public abstract bool LoadAll(out List<Entita> seznam, out string errMsg);
        public abstract bool SaveAll(List<Entita> seznam, out string errMsg);
        #endregion
    }//class

}//namespace