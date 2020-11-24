#region FileDescription
// **************************************************************************************************
// Projekt: DataLayer - DataConnection.cs
// Created:  23.11.2020 21:00
// Modified: 23.11.2020 2020
// Description:
// ***************************************************************************************************
#endregion


using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataConnection
    {
        //connection string do skoly
        // "server=dbsys.cs.vsb.cz\\STUDENT;database=userID;user=userID;password=heslo;"
        //connection string do lokalniho souboru
        // "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Q:\VSB_Vyuka\VIS_2020\Projekt_cv2\Data\Knihovna.mdf;Integrated Security=True;Connect Timeout=30"

        private SqlConnection m_Connection;
        private SqlTransaction m_SqlTransaction;
        private static readonly Object m_LockObj = new object();
        private static DataConnection m_Instance = null;

        public SqlTransaction SqlTransaction
        {
            get => m_SqlTransaction;
            set => m_SqlTransaction = value;
        }

        public SqlConnection Connection
        {
            get => m_Connection;
            set => m_Connection = value;
        }

        public static DataConnection Instance
        {
            get
            {
                lock (m_LockObj)
                {
                    return m_Instance ?? (m_Instance = new DataConnection());
                }
            }
        }


        private DataConnection()
        {
            m_Connection = new SqlConnection();
        }

        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                //Connection string je v konfiguračním souboru xxxx.dll.config
                Connection.ConnectionString = Properties.DBLayer.Default.ConnString;
                Connection.Open();
            }
            return true;
        }

        /// <summary>
        /// Close
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// End a transaction.
        /// </summary>
        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        /// <summary>
        /// If a transaction is failed call it.
        /// </summary>
        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        /// <summary>
        /// Insert a record encapulated in the command.
        /// </summary>
        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rowNumber;
        }

        /// <summary>
        /// Create command
        /// </summary>
        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        /// <summary>
        /// Select encapulated in the command.
        /// </summary>
        public SqlDataReader Select(SqlCommand command)
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

    }//class
}//namespace