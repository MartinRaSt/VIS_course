#region FileDescription

// **************************************************************************************************
// Projekt: BusinessLayer - IntfKnihaMapper.cs
// Created:  02.12.2020 0:39
// Modified: 02.12.2020 2020
// Description: Definice interface pro DataMapper Kniha
// ***************************************************************************************************

#endregion

using System.Collections.Generic;
using BusinessLayer.BO;

namespace BusinessLayer.Interfaces
{
    public interface IKnihaMapper
    {
        #region Veřejné metody
        bool LoadAll(out List<Entita> seznam, out string errMsg);
        bool SaveAll(List<Entita> seznam, out string errMsg);

        bool InsertOrUpdate(Kniha kniha, out string errMsg);
        bool Delete(long id, out string errMsg);
        bool Find(long id, out Kniha kniha, out string errMsg);
        #endregion
    }//interface

}//namespace