using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEUsuarioOficinaCollection : IEnumerable
    {


        #region Propiedades

        IEUsuarioOficina this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEUsuarioOficina[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEUsuarioOficina value);
        bool ContainsKey(string key);
        void Clear();
        IEUsuarioOficinaCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EUsuarioOficinaCollection : IEUsuarioOficinaCollection, IDictionary<string, IEUsuarioOficina>
    {
        private Dictionary<string, IEUsuarioOficina> _dictionary;

        public EUsuarioOficinaCollection()
        {
            this._dictionary = new Dictionary<string, IEUsuarioOficina>();
        }

        ~EUsuarioOficinaCollection()
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

        public IEUsuarioOficina[] Valores
        {
            get
            {
                IEUsuarioOficina[] values = new IEUsuarioOficina[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEUsuarioOficinaCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EUsuarioOficina entidad = EUsuarioOficina.Create(row);
                this.Add(entidad.CodigoUsuarioOficina.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }
        

        #region Miembros de IDictionary<string,IEUsuarioOficina>

        public void Add(string key, IEUsuarioOficina value)
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

        public bool TryGetValue(string key, out IEUsuarioOficina value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEUsuarioOficina> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEUsuarioOficina this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEUsuarioOficina>>

        public void Add(KeyValuePair<string, IEUsuarioOficina> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEUsuarioOficina> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEUsuarioOficina>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEUsuarioOficina> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEUsuario>>

        public IEnumerator<KeyValuePair<string, IEUsuarioOficina>> GetEnumerator()
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