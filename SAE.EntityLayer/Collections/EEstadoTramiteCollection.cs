using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEEstadoTramiteCollection : IEnumerable
    {

        #region Propiedades

        IEEstadoTramite this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEEstadoTramite[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEEstadoTramite value);
        bool ContainsKey(string key);
        void Clear();
        IEEstadoTramiteCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }


    [Serializable]
    public class EEstadoTramiteCollection : IEEstadoTramiteCollection, IDictionary<string, IEEstadoTramite>
    {
        private Dictionary<string, IEEstadoTramite> _dictionary;

        public EEstadoTramiteCollection()
        {
            this._dictionary = new Dictionary<string, IEEstadoTramite>();
        }

        ~EEstadoTramiteCollection()
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

        public IEEstadoTramite[] Valores
        {
            get
            {
                IEEstadoTramite[] values = new IEEstadoTramite[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEEstadoTramiteCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EEstadoTramite entidad = EEstadoTramite.Create(row);
                this.Add(entidad.CodigoEstado.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEEstadoTramite>

        public void Add(string key, IEEstadoTramite value)
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

        public bool TryGetValue(string key, out IEEstadoTramite value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEEstadoTramite> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEEstadoTramite this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEEstadoTramite>>

        public void Add(KeyValuePair<string, IEEstadoTramite> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEEstadoTramite> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEEstadoTramite>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEEstadoTramite> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEEstadoTramite>>

        public IEnumerator<KeyValuePair<string, IEEstadoTramite>> GetEnumerator()
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