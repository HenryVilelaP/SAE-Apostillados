using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IELoteCollection : IEnumerable
    {


        #region Propiedades

        IELote this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IELote[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IELote value);
        bool ContainsKey(string key);
        void Clear();
        IELoteCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class ELoteCollection : IELoteCollection, IDictionary<string, IELote>
    {
        private Dictionary<string, IELote> _dictionary;

        public ELoteCollection()
        {
            this._dictionary = new Dictionary<string, IELote>();
        }

        ~ELoteCollection()
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

        public IELote[] Valores
        {
            get
            {
                IELote[] values = new IELote[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IELoteCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ELote entidad = ELote.Create(row);
                this.Add(entidad.CodigoLote.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }


        #region Miembros de IDictionary<string,IELote>

        public void Add(string key, IELote value)
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

        public bool TryGetValue(string key, out IELote value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IELote> Values
        {
            get { return this._dictionary.Values; }
        }

        public IELote this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IELote>>

        public void Add(KeyValuePair<string, IELote> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IELote> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IELote>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IELote> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IELote>>

        public IEnumerator<KeyValuePair<string, IELote>> GetEnumerator()
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