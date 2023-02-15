using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IETramiteCollection : IEnumerable
    {
        
        #region Propiedades

        IETramite this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IETramite[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IETramite value);
        bool ContainsKey(string key);
        void Clear();
        IETramiteCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class ETramiteCollection : IETramiteCollection, IDictionary<string, IETramite>
    {
        private Dictionary<string, IETramite> _dictionary;

        public ETramiteCollection()
        {
            this._dictionary = new Dictionary<string, IETramite>();
        }

        ~ETramiteCollection()
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

        public IETramite[] Valores
        {
            get
            {
                IETramite[] values = new IETramite[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IETramiteCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ETramite entidad = ETramite.Create(row);
                this.Add(entidad.CodigoTramite.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IETramite>

        public void Add(string key, IETramite value)
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

        public bool TryGetValue(string key, out IETramite value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IETramite> Values
        {
            get { return this._dictionary.Values; }
        }

        public IETramite this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IETramite>>

        public void Add(KeyValuePair<string, IETramite> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IETramite> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IETramite>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IETramite> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IETramite>>

        public IEnumerator<KeyValuePair<string, IETramite>> GetEnumerator()
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