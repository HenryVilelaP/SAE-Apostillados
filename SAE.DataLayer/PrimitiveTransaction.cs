using System;
using System.Data;
using System.Data.SqlClient;
using  System.EnterpriseServices;
using  System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public interface IPrimitiveTransaction
    {
        SqlTransaction Transaction { get; set; }
        SqlConnection Connection { get; }
        void BeginTransaction(string pstrConnection);
        void Commit();
        void Rollback();
    }
public class PrimitiveTransaction : ServicedComponent, IPrimitiveTransaction

    {
        private SqlTransaction _trans;
        private SqlConnection _connection;

        public PrimitiveTransaction()
        {
            this._connection = new SqlConnection();
        }

        public SqlTransaction Transaction
        {
            get { return this._trans; }
            set { this._trans = value; }
        }

        public SqlConnection Connection
        {
            get { return this._trans.Connection; }
        }

        public void Commit()
        {
            this._trans.Commit();
            if (this._connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
            if (this._connection != null)
            {
              //  ((IDisposable)this._connection).Dispose();
                this._connection = null;
            }
            if (this._trans != null)
            {
                _trans.Dispose();
            }
            this._trans = null;
        }

        public void Rollback()
        {
            this._trans.Rollback();
            if (this._connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
            if (this._connection != null)
            {
               // ((IDisposable)this._connection).Dispose();
                this._connection = null;
            }
            if (this._trans != null)
            {
                this._trans.Dispose();
            }
            this._trans = null;
        }

        public void BeginTransaction(string connectionString)
        {
            try
            {
                this._connection = PrimitiveConnection.Create(connectionString);
                this._connection.Open();
                this._trans = this._connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
