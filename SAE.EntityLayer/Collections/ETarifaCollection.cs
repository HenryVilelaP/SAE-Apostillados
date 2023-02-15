using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;


namespace SAE.EntityLayer.Collections
{
    public interface IETarifaCollection : IEnumerable
    {

        #region Propiedades

        IETarifa this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IETarifa[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IETarifa value);
        bool ContainsKey(string key);
        void Clear();
        IETarifaCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class ETarifaCollection : IETarifaCollection, IDictionary<string, IETarifa>
    {
        private Dictionary<string, IETarifa> _dictionary;

        public ETarifaCollection()
        {
            this._dictionary = new Dictionary<string, IETarifa>();
        }

        ~ETarifaCollection()
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

        public IETarifa[] Valores
        {
            get
            {
                IETarifa[] values = new IETarifa[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IETarifaCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ETarifa entidad = ETarifa.Create(row);
                this.Add(entidad.CodigoTarifa.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IETarifa>

        public void Add(string key, IETarifa value)
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

        public bool TryGetValue(string key, out IETarifa value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IETarifa> Values
        {
            get { return this._dictionary.Values; }
        }

        public IETarifa this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IETarifa>>

        public void Add(KeyValuePair<string, IETarifa> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IETarifa> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IETarifa>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IETarifa> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IETarifa>>

        public IEnumerator<KeyValuePair<string, IETarifa>> GetEnumerator()
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