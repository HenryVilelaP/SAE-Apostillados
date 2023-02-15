using System;
using System.Data;
using System.Data.SqlClient;
using  System.EnterpriseServices;
using  System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public class PrimitiveConnection : ServicedComponent 
	{
		private SqlConnection _connection;

        public PrimitiveConnection()
		{
		}

		public SqlConnection Connection 
		{
			get { return this._connection; }
            set { this._connection = value; }
		}

        public static SqlConnection Create(string pstrConnectionString) 
		{
            return new SqlConnection(pstrConnectionString);
		}
	}
}
