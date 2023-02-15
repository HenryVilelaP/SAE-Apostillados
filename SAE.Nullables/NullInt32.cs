using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullInt32 : INullable
    {
        Int32 Value { get; }
    }

    [Serializable]
    public struct NullInt32 : INullInt32
    {
        private readonly bool _hasValue;
        private readonly Int32 _value;

        private NullInt32(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToInt32(value);
            }
            else
            {
                this._value = 0;
            }
        }

        public static NullInt32 Empty
        {
            get { return new NullInt32(DBNull.Value); }
        }

        public static NullInt32 Create(Int32 value)
        {
            return new NullInt32(value);
        }

        public static NullInt32 Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullInt32.Empty;
            return new NullInt32(Int32.Parse(value));
        }

        public static NullInt32 Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullInt32(row[columnName]);
        }

        #region Miembros de INullInt32

        public Int32 Value
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