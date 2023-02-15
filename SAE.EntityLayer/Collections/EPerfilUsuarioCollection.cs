using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEPerfilUsuarioCollection : IEnumerable
    {


        #region Propiedades

        IEPerfilUsuario this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEPerfilUsuario[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEPerfilUsuario value);
        bool ContainsKey(string key);
        void Clear();
        IEPerfilUsuarioCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EPerfilUsuarioCollection : IEPerfilUsuarioCollection, IDictionary<string, IEPerfilUsuario>
    {
        private Dictionary<string, IEPerfilUsuario> _dictionary;

        public EPerfilUsuarioCollection()
        {
            this._dictionary = new Dictionary<string, IEPerfilUsuario>();
        }

        ~EPerfilUsuarioCollection()
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

        public IEPerfilUsuario[] Valores
        {
            get
            {
                IEPerfilUsuario[] values = new IEPerfilUsuario[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEPerfilUsuarioCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EPerfilUsuario entidad = EPerfilUsuario.Create(row);
                string key =  entidad.CodigoPerfilUsuarioOfi.UINullable; //entidad.Codigo.UINullable + entidad.CodigoPerfil.UINullable;
                this.Add(key, entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEPerfilUsuario>

        public void Add(string key, IEPerfilUsuario value)
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

        public bool TryGetValue(string key, out IEPerfilUsuario value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEPerfilUsuario> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEPerfilUsuario this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEPerfilUsuario>>

        public void Add(KeyValuePair<string, IEPerfilUsuario> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEPerfilUsuario> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEPerfilUsuario>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEPerfilUsuario> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEPerfilUsuario>>

        public IEnumerator<KeyValuePair<string, IEPerfilUsuario>> GetEnumerator()
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