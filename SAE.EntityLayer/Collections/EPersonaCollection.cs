using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;


namespace SAE.EntityLayer.Collections
{
    public interface IEPersonaCollection : IEnumerable
    {

        #region Propiedades

        IEPersona this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEPersona[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEPersona value);
        bool ContainsKey(string key);
        void Clear();
        IEPersonaCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class EPersonaCollection : IEPersonaCollection, IDictionary<string, IEPersona>
    {
        private Dictionary<string, IEPersona> _dictionary;

        public EPersonaCollection()
        {
            this._dictionary = new Dictionary<string, IEPersona>();
        }

        ~EPersonaCollection()
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

        public IEPersona[] Valores
        {
            get
            {
                IEPersona[] values = new IEPersona[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEPersonaCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EPersona entidad = EPersona.Create(row);
                this.Add(entidad.CodigoPersona.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEPersona>

        public void Add(string key, IEPersona value)
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

        public bool TryGetValue(string key, out IEPersona value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEPersona> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEPersona this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEPersona>>

        public void Add(KeyValuePair<string, IEPersona> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEPersona> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEPersona>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEPersona> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEPersona>>

        public IEnumerator<KeyValuePair<string, IEPersona>> GetEnumerator()
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