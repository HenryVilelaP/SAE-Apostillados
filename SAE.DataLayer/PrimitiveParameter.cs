using SAE.Nullables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using  System.EnterpriseServices;
using  System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    sealed public class PrimitiveParameter
    {
        private SqlParameter _parameter;

        public PrimitiveParameter()
        {
        }

        private PrimitiveParameter(
            string name,
            Object value,
            int size,
            ParameterDirection direction,
            SqlDbType type,
            Boolean nullable)
        {
            this._parameter = new SqlParameter(name, type, size);
            this._parameter.Direction = direction;
            this._parameter.IsNullable = nullable;
            this._parameter.Value = value;
        }

        private PrimitiveParameter(
            string name,
            Object value,
            int size,
            ParameterDirection direction,
            SqlDbType type,
            Boolean nullable,
            Byte precision,
            Byte scale)
        {
            this._parameter = new SqlParameter(name, type, size);
            this._parameter.IsNullable = nullable;
            this._parameter.Direction = direction;
            this._parameter.Value = value;
            this._parameter.Precision = precision;
            this._parameter.Scale = scale;
        }

        public SqlParameter Parameter
        {
            get { return this._parameter; }
        }

        public String Name
        {
            get { return this._parameter.ParameterName; }
        }

        public Object Value
        {
            get { return this._parameter.Value; }
        }

        #region Parámetros de Entrada
        public static PrimitiveParameter CreateInput(string name, bool value)
        {
            return new PrimitiveParameter(name, value, 1, ParameterDirection.Input, SqlDbType.Bit, false);
        }

        public static PrimitiveParameter CreateInput(string name, NullBoolean value)
        {
            return new PrimitiveParameter(name, value.DBNullable, 1, ParameterDirection.Input, SqlDbType.Bit, true);
        }

        public static PrimitiveParameter CreateInput(string name, byte value)
        {
            return new PrimitiveParameter(name, value, 1, ParameterDirection.Input, SqlDbType.TinyInt, false);
        }

        public static PrimitiveParameter CreateInput(string name, NullByte value)
        {
            return new PrimitiveParameter(name, value.DBNullable, 1, ParameterDirection.Input, SqlDbType.TinyInt, true);
        }
        //addon dbs
        public static PrimitiveParameter CreateInput(string name, NullByte[] value)
        {
          //  return new PrimitiveParameter(name, value.DBNullable, 1, ParameterDirection.Input, SqlDbType.Binary, true);
            return new PrimitiveParameter(name, value,1,  ParameterDirection.Input, SqlDbType.Binary, true);
        }

        public static PrimitiveParameter CreateInput(string name, byte[] value, int size)
        {
            return new PrimitiveParameter(name, value, size, ParameterDirection.Input, SqlDbType.Binary, true);
        }

        public static PrimitiveParameter CreateInput(string name, Int16 value)
        {
            return new PrimitiveParameter(name, value, 2, ParameterDirection.Input, SqlDbType.Int, false);
        }

        public static PrimitiveParameter CreateInput(string name, NullInt16 value)
        {
            return new PrimitiveParameter(name, value.DBNullable, 2, ParameterDirection.Input, SqlDbType.Int, true);
        }

        public static PrimitiveParameter CreateInput(string name, Int32 value)
        {
            return new PrimitiveParameter(name, value, 4, ParameterDirection.Input, SqlDbType.Int, false);
        }

        public static PrimitiveParameter CreateInput(string name, NullInt32 value)
        {
            return new PrimitiveParameter(name, value.DBNullable, 4, ParameterDirection.Input, SqlDbType.Int, true);
        }

        public static PrimitiveParameter CreateInput(string name, decimal value)
        {
            return new PrimitiveParameter(name, value, 8, ParameterDirection.Input, SqlDbType.Decimal, false);
        }

        public static PrimitiveParameter CreateInput(string name, NullDecimal value)
        {
            return new PrimitiveParameter(name, value.DBNullable, 8, ParameterDirection.Input, SqlDbType.Decimal, true);
        }

        public static PrimitiveParameter CreateInput(string name, DateTime value)
        {
            return new PrimitiveParameter(name, value, 8, ParameterDirection.Input, SqlDbType.DateTime, false);
        }

        public static PrimitiveParameter CreateInput(string name, DateTime? value)
        {
            return new PrimitiveParameter(name, value, 8, ParameterDirection.Input, SqlDbType.DateTime, false);
        }

        public static PrimitiveParameter CreateInput(string name, NullDateTime value)
        {
            return new PrimitiveParameter(name, value.DBNullable, 8, ParameterDirection.Input, SqlDbType.DateTime, true);
        }

        public static PrimitiveParameter CreateInput(string name, string value, int size)
        {
            return new PrimitiveParameter(name, (value != null ? (object)value : (object)DBNull.Value), size, ParameterDirection.Input, SqlDbType.VarChar, true);
        }

        public static PrimitiveParameter CreateInput(string name, NullString value, int size)
        {
            return new PrimitiveParameter(name, value.DBNullable, size, ParameterDirection.Input, SqlDbType.VarChar, true);
        }

        public static PrimitiveParameter CreateInputChar(string name, string value, int size)
        {
            return new PrimitiveParameter(name, (value != null ? (object)value : (object)DBNull.Value), size, ParameterDirection.Input, SqlDbType.Char, true);
        }

        public static PrimitiveParameter CreateInputChar(string name, NullString value, int size)
        {
            return new PrimitiveParameter(name, value.DBNullable, size, ParameterDirection.Input, SqlDbType.VarChar, true);
        }

        public static PrimitiveParameter CreateInput(string name, int? value)
        {
            return new PrimitiveParameter(name, value, 4, ParameterDirection.Input, SqlDbType.Int, false);
        }
        #endregion

        #region Parámetros de Salida
        public static PrimitiveParameter CreateOutputBoolean(string name)
        {
            return new PrimitiveParameter(name, null, 1, ParameterDirection.Output, SqlDbType.Bit, false);
        }

        public static PrimitiveParameter CreateOutputByte(string name)
        {
            return new PrimitiveParameter(name, null, 1, ParameterDirection.Output, SqlDbType.TinyInt, false);
        }

        public static PrimitiveParameter CreateOutputInt16(string name)
        {
            return new PrimitiveParameter(name, null, 2, ParameterDirection.Output, SqlDbType.SmallInt, false);
        }

        public static PrimitiveParameter CreateOutputInt32(string name)
        {
            return new PrimitiveParameter(name, null, 8, ParameterDirection.Output, SqlDbType.Int, false);
        }

        public static PrimitiveParameter CreateOutputInt64(string name)
        {
            return new PrimitiveParameter(name, null,16, ParameterDirection.Output, SqlDbType.Int , false);
        }

        public static PrimitiveParameter CreateOutputNumeric(string name, byte precision, byte scale)
        {
            return new PrimitiveParameter(name, null, 11, ParameterDirection.Output, SqlDbType.Decimal, false, precision, scale);
        }

        public static PrimitiveParameter CreateOutputChar(string name, int size)
        {
            return new PrimitiveParameter(name, null, size, ParameterDirection.Output, SqlDbType.Char, false);
        }

        public static PrimitiveParameter CreateOutputString(string name, int size)
        {
            return new PrimitiveParameter(name, null, size, ParameterDirection.Output, SqlDbType.VarChar, false);
        }

        public static PrimitiveParameter CreateOutputDateTime(string name)
        {
            return new PrimitiveParameter(name, null, 8, ParameterDirection.Output, SqlDbType.DateTime, false);
        }
        #endregion
    }
}
