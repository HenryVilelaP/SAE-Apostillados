using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using  System.EnterpriseServices;
using System.Configuration;
using System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public class PrimitiveCommand
    {
        private SqlCommand _command;

        public PrimitiveCommand()
        {
        }

        public PrimitiveCommand(String connectionString, String query)
        {
            this._command = new SqlCommand(query, PrimitiveConnection.Create(connectionString));
            this._command.CommandType = CommandType.StoredProcedure;
            this._command.CommandTimeout = 13300; 
        }

        public PrimitiveCommand(SqlConnection connection, String query)
        {
            this._command = new SqlCommand(query, connection);
            this._command.CommandType = CommandType.StoredProcedure;
            this._command.CommandTimeout = 13300;
        }

        public SqlCommand Command
        {
            get
            {
                return this._command; 
            }
        }

        public Boolean IsClosedConnection
        {
            get
            {
                return this._command.Connection.State == ConnectionState.Closed;
            }
        }

        public void Assign(List<PrimitiveParameter> collection)
        {
            foreach (PrimitiveParameter item in collection)
            {
                this._command.Parameters.Add(item.Parameter);
            }
        }
    }
}