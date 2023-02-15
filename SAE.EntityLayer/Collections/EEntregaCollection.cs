using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEEntregaCollection : IEnumerable
    {

        #region Propiedades

        IEEntrega this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEEntrega[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEEntrega value);
        bool ContainsKey(string key);
        void Clear();
        IEEntregaCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class EEntregaCollection : IEEntregaCollection, IDictionary<string, IEEntrega>
    {
        private Dictionary<string, IEEntrega> _dictionary;

        public EEntregaCollection()
        {
            this._dictionary = new Dictionary<string, IEEntrega>();
        }

        ~EEntregaCollection()
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

        public IEEntrega[] Valores
        {
            get
            {
                IEEntrega[] values = new IEEntrega[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEEntregaCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EEntrega entidad = EEntrega.Create(row);
                this.Add(entidad.Codigo.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEEntrega>

        public void Add(string key, IEEntrega value)
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

        public bool TryGetValue(string key, out IEEntrega value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEEntrega> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEEntrega this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEEntrega>>

        public void Add(KeyValuePair<string, IEEntrega> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEEntrega> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEEntrega>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEEntrega> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEEntrega>>

        public IEnumerator<KeyValuePair<string, IEEntrega>> GetEnumerator()
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