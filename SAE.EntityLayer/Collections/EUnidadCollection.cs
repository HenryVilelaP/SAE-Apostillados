using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEUnidadCollection : IEnumerable
    {


        #region Propiedades

        IEUnidad this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEUnidad[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEUnidad value);
        bool ContainsKey(string key);
        void Clear();
        IEUnidadCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EUnidadCollection : IEUnidadCollection, IDictionary<string, IEUnidad>
    {
        private Dictionary<string, IEUnidad> _dictionary;

        public EUnidadCollection()
        {
            this._dictionary = new Dictionary<string, IEUnidad>();
        }

        ~EUnidadCollection()
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

        public IEUnidad[] Valores
        {
            get
            {
                IEUnidad[] values = new IEUnidad[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEUnidadCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EUnidad entidad = EUnidad.Create(row);
                this.Add(entidad.CodigoUnidad.UINullable, entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEUnidad>

        public void Add(string key, IEUnidad value)
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

        public bool TryGetValue(string key, out IEUnidad value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEUnidad> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEUnidad this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEUnidad>>

        public void Add(KeyValuePair<string, IEUnidad> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEUnidad> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEUnidad>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEUnidad> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEUnidad>>

        public IEnumerator<KeyValuePair<string, IEUnidad>> GetEnumerator()
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