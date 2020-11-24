#region FileDescription

// **************************************************************************************************
// Projekt: BusinessLayer - enTypZamest.cs
// Created:  24.11.2020 16:14
// Modified: 24.11.2020 2020
// Description: Typ zaměstnance
// ***************************************************************************************************

#endregion

namespace BusinessLayer.Enums
{
    /// <summary>
    /// Výčtový typ pro typ zaměstnance
    /// </summary>
    public enum EnTypZamest:uint
    {
        eJuniorKnihovnik = 0,
        eSeniorKnihovnik = 1,
        eSpravce = 100
    }//enum
}//namespace