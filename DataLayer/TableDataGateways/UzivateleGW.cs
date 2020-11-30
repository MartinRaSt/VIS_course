#region FileDescription

// **************************************************************************************************
// Projekt: DataLayer - UzivateleGW.cs
// Created:  24.11.2020 18:47
// Modified: 24.11.2020 2020
// Description: TableDataGateway pro Uzivatele IS
// ***************************************************************************************************

#endregion

using System;
using System.Data;
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
        /// <summary>
        /// Načtení všech uživatelů z databáze do objektu typu DataTable (DTO)
        /// </summary>
        /// <param name="dtUzivatele">Tabulka načtených uživatelů</param>
        /// <param name="errMsg">Chybové hlášení, pokud nastala chyba</param>
        /// <returns>True - načtení proběhlo bez chyby, False - chyba při načítání</returns>
        public bool LoadAll(out DataTable dtUzivatele, out string errMsg)
        {
            dtUzivatele = null;
            errMsg = string.Empty;

            var sql = "SELECT Id, Jmeno, Prijmeni, DatumNarozeni, ClenemOd, Spolehlivost FROM Uzivatele";

            //Vlozeni nebo aktualizace uzivatele v ulozisti
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                    try
                    {
                        try
                        {
                            var result = DataConnection.Instance.Select(sqlCmd);
                            dtUzivatele = new DataTable();
                            dtUzivatele.Load(result);
                        }
                        catch (Exception e)
                        {
                            //nastala chyba vykonání SELECT
                            dtUzivatele = null;
                            errMsg = $"Chyba při SELECT tabulky Uživatelů \n{e.Message}";
                            return false;
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
                errMsg = $"Chyba při Connection do DB \n{e.Message}";
                return false;
            }
            return true;
        }//LoadAll

        /// <summary>
        /// Uložení všech objektů uživatelů do Databáze provede jejich Insert/Update a to v DB transakci
        /// </summary>
        /// <param name="dtUzivatele">DataTable se seznamem uživatelů, které chcecem uložit do DB</param>
        /// <param name="errMsg">Chybové hlášení pokud nastala chyba</param>
        /// <returns>True - operace se provedla, False - nastala chyba</returns>
        public bool SaveAll(DataTable dtUzivatele, out string errMsg)
        {
            errMsg = string.Empty;

            string sqlInsert =
                "INSERT INTO Uzivatele (Jmeno,Prijmeni,DatumNarozeni,ClenemOd,Spolehlivost) " +
                "VALUES (@jm,@prij,@datN,@clenO,@spol); SELECT SCOPE_IDENTITY();";
            string sqlUpdate =
                "UPDATE Uzivatele SET Jmeno = @jm, Prijmeni = @prij, DatumNarozeni = @datN, " +
                "ClenemOd = @clenO, Spolehlivost = @spol WHERE (Id=@id)";

            long id = -1;
            string jmeno = string.Empty;
            string prijmeni = String.Empty;
            DateTime datumNarozeni = DateTime.MinValue;
            DateTime clenemOd = DateTime.MinValue;
            UInt16 spolehlivost = 0;

            //Vlozeni nebo aktualizace uzivatele v ulozisti
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    DataConnection.Instance.BeginTransaction();
                    for (int i = 0; i < dtUzivatele.Rows.Count; i++)
                    {

                        id = (long) dtUzivatele.Rows[i]["Id"];
                        jmeno = dtUzivatele.Rows[i]["Jmeno"].ToString();
                        prijmeni = dtUzivatele.Rows[i]["Prijmeni"].ToString();
                        datumNarozeni = (DateTime) dtUzivatele.Rows[i]["DatumNarozeni"];
                        clenemOd = (DateTime) dtUzivatele.Rows[i]["ClenemOd"];
                        spolehlivost = (UInt16) dtUzivatele.Rows[i]["Spolehlivost"];

                        var sql = id < 0 ? sqlInsert : sqlUpdate;
                        SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                        try
                        {
                            sqlCmd.Parameters.AddWithValue("@id", id);
                            sqlCmd.Parameters.AddWithValue("@jm", jmeno);
                            sqlCmd.Parameters.AddWithValue("@prij", prijmeni);
                            sqlCmd.Parameters.AddWithValue("@datN", datumNarozeni);
                            sqlCmd.Parameters.AddWithValue("@clenO", clenemOd);
                            sqlCmd.Parameters.AddWithValue("@spol", spolehlivost);
                            try
                            {
                                var result = DataConnection.Instance.ExecuteNonQuery(sqlCmd);
                                //Pokud je návratová hodnota záporná nepovedlo se vložit/upravit
                                if (result < 0)
                                    throw new DataException($"Nepovedlo se uložit Uživatele ID:({id})");
                            }
                            catch (Exception e)
                            {
                                //nastala chyba vykonání INSERT/UPDATE - vrátíme změny v DB
                                DataConnection.Instance.Rollback();
                                errMsg = $"Chyba při ukládání objektů Uživatelů \n{e.Message}";
                                return false;
                            }
                        }
                        finally
                        {
                            sqlCmd.Dispose();
                        }
                    }
                    DataConnection.Instance.EndTransaction();
                }
                finally
                {
                    DataConnection.Instance.Close();
                }
            }
            catch (Exception e)
            {
                errMsg = $"Chyba při Connection do DB \n{e.Message}";
                return false;
            }
            return true;
        }//SaveAll


        /// <summary>
        /// Vložení nebo aktualizace Uživatele v DB
        /// </summary>
        /// <param name="id">Pokud je záporné ID, pak se jedná o nového uživatele a bude vytvořen, id po návratu obsahujé přidělené ID z DB, jinak se provede update</param>
        /// <param name="jmeno">Jméno uživatele</param>
        /// <param name="prijmeni">Příjmení</param>
        /// <param name="datumNarozeni">Datum narození</param>
        /// <param name="clenemOd">Datum, od kterého je uživatel členem knihovny</param>
        /// <param name="spolehlivost">Typ spolehlivosti uživatele</param>
        /// <param name="errMsg">Chybové hlášení pokud nastala chyba</param>
        /// <returns>True nebyla chyba, False chyba nastala</returns>
        public bool InsertOrUpdate(ref long id, 
            string jmeno, 
            string prijmeni,
            DateTime datumNarozeni,
            DateTime clenemOd,
            UInt16 spolehlivost,
            out string errMsg)
        {
            errMsg = string.Empty;

            string sqlInsert =
                "INSERT INTO Uzivatele (Jmeno,Prijmeni,DatumNarozeni,ClenemOd,Spolehlivost) " +
                "VALUES (@jm,@prij,@datN,@clenO,@spol); SELECT SCOPE_IDENTITY();";
            string sqlUpdate =
                "UPDATE Uzivatele SET Jmeno = @jm, Prijmeni = @prij, DatumNarozeni = @datN, " +
                "ClenemOd = @clenO, Spolehlivost = @spol WHERE (Id=@id)";
            var sql = id < 0 ? sqlInsert : sqlUpdate;

            //Vlozeni nebo aktualizace uzivatele v ulozisti
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    DataConnection.Instance.BeginTransaction();
                    SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                    try
                    {
                        sqlCmd.Parameters.AddWithValue("@id", id);
                        sqlCmd.Parameters.AddWithValue("@jm", jmeno);
                        sqlCmd.Parameters.AddWithValue("@prij", prijmeni);
                        sqlCmd.Parameters.AddWithValue("@datN", datumNarozeni);
                        sqlCmd.Parameters.AddWithValue("@clenO", clenemOd);
                        sqlCmd.Parameters.AddWithValue("@spol", spolehlivost);
                        try
                        {
                            var result = DataConnection.Instance.ExecuteNonQuery(sqlCmd);
                            //Pokud je návratová hodnota záporná nepovedlo se vložit/upravit
                            if (result < 0)
                                throw new DataException($"Nepovedlo se vložit/upravit Uživatele ID:({id})");
                            DataConnection.Instance.EndTransaction();
                            if (id < 0)
                                id = result;  //id vytvořené na DB serveru a přidělené novému záznamu v DB
                        }
                        catch (Exception e)
                        {
                            //nastala chyba vykonání INSERT/UPDATE - vrátíme změny v DB
                            DataConnection.Instance.Rollback();
                            errMsg = $"Chyba při INSERT/UPDATE objektu Uživatele \n{e.Message}";
                            return false;
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
                errMsg = $"Chyba při Connection do DB \n{e.Message}";
                return false;
            }
            return true;
        }//InsertOrUpdate

        /// <summary>
        /// Smazání uživatele z DB uložiště
        /// </summary>
        /// <param name="id">ID uživatele</param>
        /// <param name="errMsg">Chybové hlášení</param>
        /// <returns>True smazání se povedlo, False nepovedlo</returns>
        public bool Delete(long id, out string errMsg)
        {
            errMsg = string.Empty;

            var sql = "DELETE FROM Uzivatele WHERE (Id = @id)";

            //Vlozeni nebo aktualizace uzivatele v ulozisti
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    DataConnection.Instance.BeginTransaction();
                    SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                    try
                    {
                        sqlCmd.Parameters.AddWithValue("@id", id);
                        try
                        {
                            var result = DataConnection.Instance.ExecuteNonQuery(sqlCmd);
                            //Pokud je návratová hodnota záporná nepodlo se smazat uživatele
                            if (result < 0)
                                throw new DataException($"Nepovedlo se smazat Uživatele ID:({id})");

                            DataConnection.Instance.EndTransaction();
                        }
                        catch (Exception e)
                        {
                            //nastala chyba vykonání DELETE - vrátíme změny v DB
                            DataConnection.Instance.Rollback();
                            errMsg = $"Chyba při DELETE objektu Uživatele \n{e.Message}";
                            return false;
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
                errMsg = $"Chyba při Connection do DB \n{e.Message}";
                return false;
            }
            return true;
        }//Delete

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
                errMsg = $"Chyba při Connection do DB \n{e.Message}";
                return false;
            }

            return true;
        }//Find
        #endregion

    }//class
}//namespace