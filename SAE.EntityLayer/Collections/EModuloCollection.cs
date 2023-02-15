using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEModuloCollection : IEnumerable
    {


        #region Propiedades

        IEModulo this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEModulo[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEModulo value);
        bool ContainsKey(string key);
        void Clear();
        IEModuloCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EModuloCollection : IEModuloCollection, IDictionary<string, IEModulo>
    {
        private Dictionary<string, IEModulo> _dictionary;

        public EModuloCollection()
        {
            this._dictionary = new Dictionary<string, IEModulo>();
        }

        ~EModuloCollection()
        {
            this._dictionary.Clear();
            this._dictionary = null;
        }

        public string[] Codigos
        {
            get
            {
                string[] keys = new string[this.Count];
                this._dictionary.Keys.CopyTo(keys, 0);
                return keys;
            }
        }

        public IEModulo[] Valores
        {
            get
            {
                IEModulo[] values = new IEModulo[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEModuloCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EModulo entidad = EModulo.Create(row);
                this.Add(entidad.CodigoModulo.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEModulo>

        public void Add(string key, IEModulo value)
        {
            this._dictionary.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return this._dictionary.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return this._dictionary.Keys; }
        }

        public bool Remove(string key)
        {
            return this._dictionary.Remove(key);
        }

        public bool TryGetValue(string key, out IEModulo value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEModulo> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEModulo this[string key]
        {
            get
            {
                return this._dictionary[key];
            }
            set
            {
                this._dictionary[key] = value;
            }
        }

        #endregion

        #region Miembros de ICollection<KeyValuePair<string,IEModulo>>

        public void Add(KeyValuePair<string, IEModulo> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEModulo> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEModulo>[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { return this._dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, IEModulo> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEModulo>>

        public IEnumerator<KeyValuePair<string, IEModulo>> GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._dictionary.Values.GetEnumerator();
        }

        #endregion
    }

}