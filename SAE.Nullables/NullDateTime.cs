using System;
using System.Data;
using System.Xml;

namespace SAE.Nullables
{
    public interface INullDateTime : INullable
    {
        DateTime Value { get; }
    }

    [Serializable]
    public struct NullDateTime : INullDateTime
    {
        private readonly bool _hasValue;
        private readonly DateTime _value;

        private NullDateTime(object value)
        {
            this._hasValue = (value != null && !Convert.IsDBNull(value));
            if (this._hasValue)
            {
                this._value = Convert.ToDateTime(value);
            }
            else
            {
                this._value = DateTime.MinValue;
            }
        }

        public static NullDateTime Empty
        {
            get { return new NullDateTime(DBNull.Value); }
        }

        public static NullDateTime Create(DateTime value)
        {
            return new NullDateTime(value);
        }

        public static NullDateTime Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return NullDateTime.Empty;
            //if(value="") return NullDateTime.
            return new NullDateTime(DateTime.Parse(value));
        }       

        public static NullDateTime Create(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ApplicationException(string.Format("No existe la columna {0} en la tabla {1} a la cual se le hace referencia.", columnName, row.Table.TableName));
            }
            return new NullDateTime(row[columnName]);
        }

        #region Miembros de INullDateTime

        public DateTime Value
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