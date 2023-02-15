using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullByte : INullable
    {
        byte Value { get; }
    }

    [Serializable]
    public struct NullByte : INullByte
    {
        private readonly bool _hasValue;
        private readonly byte _value;

        private NullByte(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToByte(value);
            }
            else
            {
                this._value = 0;
            }
        }

        public static NullByte Empty
        {
            get { return new NullByte(DBNull.Value); }
        }

        public static NullByte Create(byte value)
        {
            return new NullByte(value);
        }
       

        public static NullByte Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullByte.Empty;
            return new NullByte(Byte.Parse(value));
        }

        public static NullByte Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullByte(row[columnName]);
        }

        #region Miembros de INullByte

        public byte Value
        {
            get { return this._value; }
        }

        #endregion

        #region Miembros de INullable

        public bool HasValue
        {
            get { return this._hasValue; }
        }

        public object DBNullable
        {
            get
            {
                if (this._hasValue) return this._value;
                return DBNull.Value;
            }
        }

        public string UINullable
        {
            get
            {
                if (this._hasValue) return this._value.ToString();
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return this.UINullable;
        }

        #endregion
    }
}