using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullDecimal : INullable
    {
        decimal Value { get; }
    }

    [Serializable]
    public struct NullDecimal : INullDecimal
    {
        private readonly bool _hasValue;
        private readonly decimal _value;

        private NullDecimal(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToDecimal(value);
            }
            else
            {
                this._value = 0;
            }
        }

        public static NullDecimal Empty
        {
            get { return new NullDecimal(DBNull.Value); }
        }

        public static NullDecimal Create(decimal value)
        {
            return new NullDecimal(value);
        }

        public static NullDecimal Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullDecimal.Empty;
            return new NullDecimal(decimal.Parse(value));
        }

        public static NullDecimal Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullDecimal(row[columnName]);
        }

        #region Miembros de INullDecimal

        public decimal Value
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