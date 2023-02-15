using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEPerfilCollection : IEnumerable
    {


        #region Propiedades

        IEPerfil this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEPerfil[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEPerfil value);
        bool ContainsKey(string key);
        void Clear();
        IEPerfilCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EPerfilCollection : IEPerfilCollection, IDictionary<string, IEPerfil>
    {
        private Dictionary<string, IEPerfil> _dictionary;

        public EPerfilCollection()
        {
            this._dictionary = new Dictionary<string, IEPerfil>();
        }

        ~EPerfilCollection()
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

        public IEPerfil[] Valores
        {
            get
            {
                IEPerfil[] values = new IEPerfil[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEPerfilCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EPerfil entidad = EPerfil.Create(row);
                this.Add(entidad.CodigoPerfil.UINullable, entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEPerfil>

        public void Add(string key, IEPerfil value)
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

        public bool TryGetValue(string key, out IEPerfil value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEPerfil> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEPerfil this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEPerfil>>

        public void Add(KeyValuePair<string, IEPerfil> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEPerfil> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEPerfil>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEPerfil> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEPerfil>>

        public IEnumerator<KeyValuePair<string, IEPerfil>> GetEnumerator()
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