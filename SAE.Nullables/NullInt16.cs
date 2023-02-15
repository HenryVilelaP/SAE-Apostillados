using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullInt16 : INullable
    {
        Int16 Value { get; }
    }

    [Serializable]
    public struct NullInt16 : INullInt16
    {
        private readonly bool _hasValue;
        private readonly Int16 _value;

        private NullInt16(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToInt16(value);
            }
            else
            {
                this._value = 0;
            }
        }

        public static NullInt16 Empty
        {
            get { return new NullInt16(DBNull.Value); }
        }

        public static NullInt16 Create(Int16 value)
        {
            return new NullInt16(value);
        }

        public static NullInt16 Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullInt16.Empty;
            return new NullInt16(Int16.Parse(value));
        }

        public static NullInt16 Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullInt16(row[columnName]);
        }

        #region Miembros de INullInt16

        public Int16 Value
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