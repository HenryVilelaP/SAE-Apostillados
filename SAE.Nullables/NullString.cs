using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullString : INullable
    {
        string Value { get; }
    }

    [Serializable]
    public struct NullString : INullString
    {
        private readonly bool _hasValue;
        private readonly string _value;

        private NullString(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToString(value);
            }
            else
            {
                this._value = null;
            }
        }

        public static NullString Empty
        {
            get { return new NullString(DBNull.Value); }
        }

        public static NullString Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullString.Empty;
            return new NullString(value);
        }
        /// <summary>
        /// si el valor es cero lo cnvierte a nulo
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Cero"></param>
        /// <returns></returns>
        public static NullString Create(string value, Boolean Cero)
        {
           if (value == "0") new NullString(value);
            return new NullString(value);
        }

        public static NullString Create(DataRow row, int columnIndex)
        {
            return new NullString(row[columnIndex]);
        }

        public static NullString Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullString(row[columnName]);
        }

        #region Miembros de INullString

        public string Value
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