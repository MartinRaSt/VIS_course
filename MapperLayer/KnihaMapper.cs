#region FileDescription

// **************************************************************************************************
// Projekt: Mappers - KnihaMapper.cs
// Created:  24.11.2020 15:54
// Modified: 24.11.2020 2020
// Description: Tato třída obsahuje DataMapper pro třídu kniha
// ***************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer.BO;
using BusinessLayer.Interfaces;
using DataLayer;
using MapperLayer;

namespace Mappers
{
    public class KnihaMapper:BaseMapper,IKnihaMapper 
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

        /// <summary>
        /// Načtení všech Knih z databáze do objektu typu seznam knih
        /// </summary>
        /// <param name="seznam">Vraci seznam BO objektu</param>
        /// <param name="errMsg">Chybové hlášení, pokud nastala chyba</param>
        /// <returns>True - načtení proběhlo bez chyby, False - chyba při načítání</returns>
        public bool LoadAll(out List<Kniha> seznam , out string errMsg)
        {
            seznam = new List<Kniha>();
            errMsg = string.Empty;

            var sql = "SELECT Id,AutorJmeno,AutorPrijmeni,NazevKnihy,Vydavatel,RokVydani,Vydani,Jazyk FROM Knihy";

            //Nazcteni Knih z uloziste
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
                            if (result.HasRows)
                            {
                                while (result.Read())
                                {
                                    Kniha kn = new Kniha()
                                    {
                                        Id = result.GetInt64(0),
                                        AutorJmeno = result.GetString(1),
                                        AutorPrijmeni = result.GetString(2),
                                        NazevKnihy = result.GetString(3),
                                        Vydavatel = result.GetString(4),
                                        RokVydani = result.GetInt32(5),
                                        Vydani = result.GetInt32(6),
                                        Jazyk = result.GetString(7)
                                    };
                                    seznam.Add(kn);
                                };
                            }
                        }
                        catch (Exception e)
                        {
                            //nastala chyba vykonání SELECT
                            errMsg = $"Chyba při SELECT tabulky Knihy \n{e.Message}";
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
        /// Uložení všech objektů BO kniha do Databáze provede jejich Insert/Update a to v DB transakci
        /// </summary>
        /// <param name="seznam">Seznam BO Kniha, které chcecem uložit/aktualizovat v DB</param>
        /// <param name="errMsg">Chybové hlášení pokud nastala chyba</param>
        /// <returns>True - operace se provedla, False - nastala chyba</returns>
        public bool SaveAll(List<Kniha> seznam, out string errMsg)
        {
            errMsg = string.Empty;

            string sqlInsert =
                "INSERT INTO Knihy (AutorJmeno,AutorPrijmeni,NazevKnihy,Vydavatel,RokVydani,Vydani,Jazyk) " +
                "VALUES (@ajm,@aprij,@nazev,@vydavatel,@rokvyd,@vydani,@jazyk)";
            string sqlUpdate =
                "UPDATE Knihy SET AutorJmeno = @ajm, AutorPrijmeni = @aprij, NazevKnihy = @nazev, " +
                "Vydavatel = @vydavatel, RokVydani = @rokvyd, Vydani = @vydani, Jazyk = @jazyk WHERE (Id=@id)";

            long id = -1;
            
            //Vlozeni nebo aktualizace knihy v ulozisti
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    DataConnection.Instance.BeginTransaction();
                    for (int i = 0; i < seznam.Count; i++)
                    {
                        var sql = id < 0 ? sqlInsert : sqlUpdate;
                        SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                        try
                        {
                            sqlCmd.Parameters.AddWithValue("@id", seznam[i].Id);
                            sqlCmd.Parameters.AddWithValue("@ajm", ((Kniha)(seznam[i])).AutorJmeno);
                            sqlCmd.Parameters.AddWithValue("@aprij", ((Kniha)(seznam[i])).AutorPrijmeni);
                            sqlCmd.Parameters.AddWithValue("@nazev", ((Kniha)(seznam[i])).NazevKnihy);
                            sqlCmd.Parameters.AddWithValue("@vydavatel", ((Kniha)(seznam[i])).Vydavatel);
                            sqlCmd.Parameters.AddWithValue("@rokvyd", ((Kniha)(seznam[i])).RokVydani);
                            sqlCmd.Parameters.AddWithValue("@vydani", ((Kniha)(seznam[i])).Vydani);
                            sqlCmd.Parameters.AddWithValue("@jazyk", ((Kniha)(seznam[i])).Jazyk);
                            try
                            {
                                var result = DataConnection.Instance.ExecuteNonQuery(sqlCmd);
                                //Pokud je návratová hodnota záporná nepovedlo se vložit/upravit
                                if (result < 0)
                                    throw new DataException($"Nepovedlo se uložit Knihu ID:({id})");
                            }
                            catch (Exception e)
                            {
                                //nastala chyba vykonání INSERT/UPDATE - vrátíme změny v DB
                                DataConnection.Instance.Rollback();
                                errMsg = $"Chyba při ukládání objektů Kniha \n{e.Message}";
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
        /// Vložení nebo aktualizace Knihy v DB
        /// </summary>
        ///<param name="kniha">BO Kniha určený pro uložení nebo změnu</param>
        /// <param name="errMsg">Chybové hlášení pokud nastala chyba</param>
        /// <returns>True nebyla chyba, False chyba nastala</returns>
        public bool InsertOrUpdate(Kniha kniha, out string errMsg)
        {
            errMsg = string.Empty;

            string sqlInsert =
                "SET NOCOUNT ON; INSERT INTO Knihy (AutorJmeno,AutorPrijmeni,NazevKnihy,Vydavatel,RokVydani,Vydani,Jazyk) " +
                "VALUES (@ajm,@aprij,@nazev,@vydavatel,@rokvyd,@vydani,@jazyk); SELECT SCOPE_IDENTITY(); SET NOCOUNT OFF;";
            string sqlUpdate =
                "UPDATE Knihy SET AutorJmeno = @ajm, AutorPrijmeni = @aprij, NazevKnihy = @nazev, " +
                "Vydavatel = @vydavatel, RokVydani = @rokvyd, Vydani = @vydani, Jazyk = @jazyk WHERE (Id=@id)";

            var sql = kniha.Id < 0 ? sqlInsert : sqlUpdate;

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
                        sqlCmd.Parameters.AddWithValue("@id", kniha.Id);
                        sqlCmd.Parameters.AddWithValue("@ajm", kniha.AutorJmeno);
                        sqlCmd.Parameters.AddWithValue("@aprij", kniha.AutorPrijmeni);
                        sqlCmd.Parameters.AddWithValue("@nazev", kniha.NazevKnihy);
                        sqlCmd.Parameters.AddWithValue("@vydavatel", kniha.Vydavatel);
                        sqlCmd.Parameters.AddWithValue("@vydani", kniha.Vydani);
                        sqlCmd.Parameters.AddWithValue("@rokvyd", kniha.RokVydani);
                        sqlCmd.Parameters.AddWithValue("@jazyk", kniha.Jazyk);
                        try
                        {

                            var result = -1;
                            if (kniha.Id == -1)
                            {
                                result = DataConnection.Instance.ExecuteScalar(sqlCmd);
                            }
                            else
                            {
                                result = DataConnection.Instance.ExecuteNonQuery(sqlCmd);
                            }

                            //Pokud je návratová hodnota záporná nepovedlo se vložit/upravit
                            if (result < 0)
                                throw new DataException($"Nepovedlo se vložit/upravit Knihu ID:({kniha.Id})");
                            DataConnection.Instance.EndTransaction();
                            if (kniha.Id < 0)
                                kniha.Id = result;  //id vytvořené na DB serveru a přidělené novému záznamu v DB
                        }
                        catch (Exception e)
                        {
                            //nastala chyba vykonání INSERT/UPDATE - vrátíme změny v DB
                            DataConnection.Instance.Rollback();
                            errMsg = $"Chyba při INSERT/UPDATE objektu Kniha \n{e.Message}";
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
        /// Smazání Knihy z DB uložiště
        /// </summary>
        /// <param name="id">ID uživatele</param>
        /// <param name="errMsg">Chybové hlášení</param>
        /// <returns>True smazání se povedlo, False nepovedlo</returns>
        public bool Delete(long id, out string errMsg)
        {
            errMsg = string.Empty;

            var sql = "DELETE FROM Knihy WHERE (Id = @id)";

            //Smazani objektu Kniha z uloziste
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
                            errMsg = $"Chyba při DELETE objektu Kniha \n{e.Message}";
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
        /// Nalezeni Knihy na zaklade jeho ID
        /// </summary>
        /// <param name="id">Hledane ID </param>
        /// <param name="kniha">Nalezeny BO kniha nebo null</param>
        /// <param name="errMsg">Chybové hlášení</param>
        /// <returns>TRUE hledání se provedlo, FALSE nastala chyba hledání</returns>
        public bool Find(long id, out Kniha kniha, out string errMsg)
        {
            errMsg = string.Empty;
            kniha = null;

            //Nalezeni knihy podle jeho id v DB
            try
            {
                DataConnection.Instance.Connect();
                try
                {
                    string sql =
                        "SELECT AutorJmeno,AutorPrijmeni,NazevKnihy,Vydavatel,RokVydani,Vydani,Jazyk FROM Knihy WHERE (Id=@id)";
                    SqlCommand sqlCmd = DataConnection.Instance.CreateCommand(sql);
                    try
                    {
                        sqlCmd.Parameters.AddWithValue("@id", id);
                        var result = DataConnection.Instance.Select(sqlCmd);
                        try
                        {
                            if (result.HasRows)
                            {
                                //Precteme jen prvni nalezeny, podle ID musí být jen jeden
                                result.Read();
                                kniha = new Kniha()
                                {
                                    Id = id,
                                    AutorJmeno = result.GetString(0),
                                    AutorPrijmeni = result.GetString(1),
                                    NazevKnihy = result.GetString(2),
                                    Vydavatel = result.GetString(3),
                                    RokVydani = result.GetInt32(4),
                                    Vydani = result.GetInt32(5),
                                    Jazyk = result.GetString(6)
                                };
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
    } //class

} //namespace