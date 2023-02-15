using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using  System.EnterpriseServices;
using  System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public interface IPrimitiveEntity
    {
        DataRow ExecuteDataRow(String pstrQuery, String pstrCadenaConexion);
        DataTable ExecuteDataTable(String pstrQuery, String pstrCadenaConexion);
        DataSet ExecuteDataSet(String pstrQuery, String pstrCadenaConexion);
        int ExecuteNonQuery(String pstrQuery, SqlTransaction pobjTx);
        void Add(PrimitiveParameter parameter);
        object Out(int index);
        void Clear();
    }

    public class PrimitiveEntity : ServicedComponent, IPrimitiveEntity
    {
        protected List<PrimitiveParameter> _collection;
        protected PrimitiveCommand _command;

        public PrimitiveEntity()
        {
            this._collection = new List<PrimitiveParameter>();
        }

        ~PrimitiveEntity()
        {
            this._collection = null;
        }

        #region Miembros de IPrimitiveEntity

        public DataRow ExecuteDataRow(String pstrQuery, String pstrCadenaConexion)
        {
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                this._command = new PrimitiveCommand(pstrCadenaConexion, pstrQuery);
                this._command.Assign(_collection);

                da = new SqlDataAdapter(this._command.Command);
                if (da.SelectCommand.Connection.State != ConnectionState.Open)
                    da.SelectCommand.Connection.Open();

                da.Fill(dt);

                if (dt.Rows.Count > 0) return dt.Rows[0];
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.SelectCommand.Connection.Close();
                da = null;
                dt = null;
            }
        }
       
     
        public DataTable ExecuteDataTable(String pstrQuery, String pstrCadenaConexion)
        {
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                this._command = new PrimitiveCommand(pstrCadenaConexion, pstrQuery);
                this._command.Assign(_collection);

                da = new SqlDataAdapter(this._command.Command);
                if (da.SelectCommand.Connection.State != ConnectionState.Open)
                    da.SelectCommand.Connection.Open();

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.SelectCommand.Connection.Close();
                da = null;
            }
        }

        public DataSet ExecuteDataSet(String pstrQuery, String pstrCadenaConexion)
        {
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                this._command = new PrimitiveCommand(pstrCadenaConexion, pstrQuery);
                this._command.Assign(_collection);

                da = new SqlDataAdapter(this._command.Command);
                if (da.SelectCommand.Connection.State != ConnectionState.Open)
                    da.SelectCommand.Connection.Open();

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.SelectCommand.Connection.Close();
                da = null;
                ds = null;
            }
        }

        public int ExecuteNonQuery(String pstrQuery, String pstrCadenaConexion)
        {
            try
            {
                this._command = new PrimitiveCommand(pstrCadenaConexion, pstrQuery);
                this._command.Assign(_collection);

                if (_command.Command.Connection.State != ConnectionState.Open)
                    _command.Command.Connection.Open();

                return this._command.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._command.Command.Connection.Close();
                this._command = null;
            }
        }

    



        public int ExecuteNonQuery(String pstrQuery, SqlTransaction pobjTx)
        {
            try
            {
                this._command = new PrimitiveCommand(pobjTx.Connection, pstrQuery);
                this._command.Assign(_collection);

                if (pobjTx.Connection.State != ConnectionState.Open)
                    pobjTx.Connection.Open();

                this._command.Command.Transaction = pobjTx;
                return _command.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._command = null;
            }
        }

        public void Add(PrimitiveParameter parameter)
        {
            this._collection.Add(parameter);
        }

        public object Out(int index)
        {
            return this._collection[index].Value;
        }

        public void Clear()
        {
            this._collection.Clear();
        }

        #endregion
    }
}
