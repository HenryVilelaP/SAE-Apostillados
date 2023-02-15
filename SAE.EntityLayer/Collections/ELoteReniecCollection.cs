using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IELoteReniecCollection : IEnumerable
    {


        #region Propiedades

        IELoteReniec this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IELoteReniec[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IELoteReniec value);
        bool ContainsKey(string key);
        void Clear();
        IELoteReniecCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class ELoteReniecCollection : IELoteReniecCollection, IDictionary<string, IELoteReniec>
    {
        private Dictionary<string, IELoteReniec> _dictionary;

        public ELoteReniecCollection()
        {
            this._dictionary = new Dictionary<string, IELoteReniec>();
        }

        ~ELoteReniecCollection()
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

        public IELoteReniec[] Valores
        {
            get
            {
                IELoteReniec[] values = new IELoteReniec[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IELoteReniecCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ELoteReniec entidad = ELoteReniec.Create(row);
                this.Add(entidad.CodigoLoteReniec.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }


        #region Miembros de IDictionary<string,IELoteReniec>

        public void Add(string key, IELoteReniec value)
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

        public bool TryGetValue(string key, out IELoteReniec value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IELoteReniec> Values
        {
            get { return this._dictionary.Values; }
        }

        public IELoteReniec this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IELoteReniec>>

        public void Add(KeyValuePair<string, IELoteReniec> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IELoteReniec> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IELoteReniec>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IELoteReniec> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IELoteReniec>>

        public IEnumerator<KeyValuePair<string, IELoteReniec>> GetEnumerator()
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