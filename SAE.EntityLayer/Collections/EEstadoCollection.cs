using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEEstadoCollection : IEnumerable
    {

        #region Propiedades

        IEEstado this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEEstado[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEEstado value);
        bool ContainsKey(string key);
        void Clear();
        IEEstadoCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class EEstadoCollection : IEEstadoCollection, IDictionary<string, IEEstado>
    {
        private Dictionary<string, IEEstado> _dictionary;

        public EEstadoCollection()
        {
            this._dictionary = new Dictionary<string, IEEstado>();
        }

        ~EEstadoCollection()
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

        public IEEstado[] Valores
        {
            get
            {
                IEEstado[] values = new IEEstado[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEEstadoCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EEstado entidad = EEstado.Create(row);
                this.Add(entidad.Codigo.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEEstado>

        public void Add(string key, IEEstado value)
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

        public bool TryGetValue(string key, out IEEstado value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEEstado> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEEstado this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEEstado>>

        public void Add(KeyValuePair<string, IEEstado> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEEstado> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEEstado>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEEstado> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEEstado>>

        public IEnumerator<KeyValuePair<string, IEEstado>> GetEnumerator()
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