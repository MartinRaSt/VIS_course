#region FileDescription

// **************************************************************************************************
// Projekt: BusinessLayer - Entita.cs
// Created:  24.11.2020 15:15
// Modified: 24.11.2020 2020
// Description:
// ***************************************************************************************************

#endregion

namespace BusinessLayer.BO
{
    /// <summary>
    /// Třída představující předka všech business tříd
    /// Implementuje Identity key pro všechny třídy
    /// Pokud je třída nově vytvořená je její Id nastaveno na -1
    /// </summary>
    public class Entita
    {
        #region Privátní proměnné
        private const long PLACEHOLDER_ID = -1;
        private long m_Id = PLACEHOLDER_ID;
        #endregion

        #region Veřejné vlastnosti
        /// <summary>
        /// Identifikátor objektu pro interakci s uložištěm
        /// Hodnota PLACEHOLDER_ID označuje, že je instance nově vytvořená
        /// </summary>
        public long Id
        {
            get => m_Id;
            set => m_Id = value;
        }
        #endregion

        #region Veřejné metody
        /// <summary>
        /// Veřejný konstruktor
        /// </summary>
        public Entita()
        {

        }

        /// <summary>
        /// Test zda je objekt nově vytvořený, tedy ještě nebyl uložen do uložiště
        /// </summary>
        /// <returns>True: objekt ještě nebyl uložen do uložiště, False objekt je načten z uložiště</returns>
        public bool isNew() { return m_Id == PLACEHOLDER_ID; }
        #endregion

    } //class
} //namespace