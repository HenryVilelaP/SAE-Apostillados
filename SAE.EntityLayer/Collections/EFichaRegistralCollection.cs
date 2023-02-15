using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;


namespace SAE.EntityLayer.Collections
{
    public interface IEFichaRegistralCollection : IEnumerable
    {

        #region Propiedades

        IEFichaRegistral this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEFichaRegistral[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEFichaRegistral value);
        bool ContainsKey(string key);
        void Clear();
        IEFichaRegistralCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class EFichaRegistralCollection : IEFichaRegistralCollection, IDictionary<string, IEFichaRegistral>
    {
        private Dictionary<string, IEFichaRegistral> _dictionary;

        public EFichaRegistralCollection()
        {
            this._dictionary = new Dictionary<string, IEFichaRegistral>();
        }

        ~EFichaRegistralCollection()
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

        public IEFichaRegistral[] Valores
        {
            get
            {
                IEFichaRegistral[] values = new IEFichaRegistral[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEFichaRegistralCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EFichaRegistral entidad = EFichaRegistral.Create(row);
                this.Add(entidad.Codigo.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEFichaRegistral>

        public void Add(string key, IEFichaRegistral value)
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

        public bool TryGetValue(string key, out IEFichaRegistral value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEFichaRegistral> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEFichaRegistral this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEFichaRegistral>>

        public void Add(KeyValuePair<string, IEFichaRegistral> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEFichaRegistral> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEFichaRegistral>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEFichaRegistral> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEFichaRegistral>>

        public IEnumerator<KeyValuePair<string, IEFichaRegistral>> GetEnumerator()
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