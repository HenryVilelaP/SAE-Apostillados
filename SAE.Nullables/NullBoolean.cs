using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullBoolean : INullable
    {
        bool Value { get; }
    }

    [Serializable]
    public struct NullBoolean : INullBoolean
    {
        private readonly bool _hasValue;
        private readonly bool _value;

        private NullBoolean(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToBoolean(value);
            }
            else
            {
                this._value = false;
            }
        }

        public static NullBoolean Empty
        {
            get { return new NullBoolean(DBNull.Value); }
        }

        public static NullBoolean Create(bool value)
        {
            return new NullBoolean(value);
        }

        public static NullBoolean Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullBoolean.Empty;
            return new NullBoolean(bool.Parse(value));
        }

        public static NullBoolean Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullBoolean(row[columnName]);
        }

        #region Miembros de INullBoolean

        public bool Value
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