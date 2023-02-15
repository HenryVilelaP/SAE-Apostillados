using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEOficinaCollection : IEnumerable
    {


        #region Propiedades

        IEOficina this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEOficina[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEOficina value);
        bool ContainsKey(string key);
        void Clear();
        IEOficinaCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EOficinaCollection : IEOficinaCollection, IDictionary<string, IEOficina>
    {
        private Dictionary<string, IEOficina> _dictionary;

        public EOficinaCollection()
        {
            this._dictionary = new Dictionary<string, IEOficina>();
        }

        ~EOficinaCollection()
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

        public IEOficina[] Valores
        {
            get
            {
                IEOficina[] values = new IEOficina[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEOficinaCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EOficina entidad = EOficina.Create(row);
                this.Add(entidad.CodigoOficina.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEOficina>

        public void Add(string key, IEOficina value)
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

        public bool TryGetValue(string key, out IEOficina value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEOficina> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEOficina this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEOficina>>

        public void Add(KeyValuePair<string, IEOficina> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEOficina> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEOficina>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEOficina> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEOficina>>

        public IEnumerator<KeyValuePair<string, IEOficina>> GetEnumerator()
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