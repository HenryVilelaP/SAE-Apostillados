using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEPaisCollection : IEnumerable
    {


        #region Propiedades

        IEPais this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEPais[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEPais value);
        bool ContainsKey(string key);
        void Clear();
        IEPaisCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EPaisCollection : IEPaisCollection, IDictionary<string, IEPais>
    {
        private Dictionary<string, IEPais> _dictionary;

        public EPaisCollection()
        {
            this._dictionary = new Dictionary<string, IEPais>();
        }

        ~EPaisCollection()
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

        public IEPais[] Valores
        {
            get
            {
                IEPais[] values = new IEPais[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEPaisCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EPais entidad = EPais.Create(row);
                this.Add(entidad.CodigoPais.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }
        

        #region Miembros de IDictionary<string,IEPais>

        public void Add(string key, IEPais value)
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

        public bool TryGetValue(string key, out IEPais value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEPais> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEPais this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEPais>>

        public void Add(KeyValuePair<string, IEPais> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEPais> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEPais>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEPais> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEPais>>

        public IEnumerator<KeyValuePair<string, IEPais>> GetEnumerator()
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