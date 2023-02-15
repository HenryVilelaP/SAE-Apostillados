using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEUsuarioCollection : IEnumerable
    {


        #region Propiedades

        IEUsuario this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEUsuario[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEUsuario value);
        bool ContainsKey(string key);
        void Clear();
        IEUsuarioCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EUsuarioCollection : IEUsuarioCollection, IDictionary<string, IEUsuario>
    {
        private Dictionary<string, IEUsuario> _dictionary;

        public EUsuarioCollection()
        {
            this._dictionary = new Dictionary<string, IEUsuario>();
        }

        ~EUsuarioCollection()
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

        public IEUsuario[] Valores
        {
            get
            {
                IEUsuario[] values = new IEUsuario[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEUsuarioCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EUsuario entidad = EUsuario.Create(row);
                this.Add(entidad.Codigo.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }
        

        #region Miembros de IDictionary<string,IEUsuario>

        public void Add(string key, IEUsuario value)
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

        public bool TryGetValue(string key, out IEUsuario value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEUsuario> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEUsuario this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEUsuario>>

        public void Add(KeyValuePair<string, IEUsuario> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEUsuario> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEUsuario>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEUsuario> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEUsuario>>

        public IEnumerator<KeyValuePair<string, IEUsuario>> GetEnumerator()
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