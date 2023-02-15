using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEDetallePerfilUsuarioCollection : IEnumerable
    {


        #region Propiedades

        IEPerfilUsuarioDetalle this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEPerfilUsuarioDetalle[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEPerfilUsuarioDetalle value);
        bool ContainsKey(string key);
        void Clear();
        IEDetallePerfilUsuarioCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EDetallePerfilUsuarioCollection : IEDetallePerfilUsuarioCollection, IDictionary<string, IEPerfilUsuarioDetalle>
    {
        private Dictionary<string, IEPerfilUsuarioDetalle> _dictionary;

        public EDetallePerfilUsuarioCollection()
        {
            this._dictionary = new Dictionary<string, IEPerfilUsuarioDetalle>();
        }

        ~EDetallePerfilUsuarioCollection()
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

        public IEPerfilUsuarioDetalle[] Valores
        {
            get
            {
                IEPerfilUsuarioDetalle[] values = new IEPerfilUsuarioDetalle[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEDetallePerfilUsuarioCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EPerfilUsuarioDetalle entidad = EPerfilUsuarioDetalle.Create(row);
                string key = entidad.CodigoPerfilUsuarioOf.ToString() + entidad.CodigoOpcion.ToString();
                this.Add(key, entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEPerfilUsuarioDetalle>

        public void Add(string key, IEPerfilUsuarioDetalle value)
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

        public bool TryGetValue(string key, out IEPerfilUsuarioDetalle value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEPerfilUsuarioDetalle> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEPerfilUsuarioDetalle this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEPerfilUsuarioDetalle>>

        public void Add(KeyValuePair<string, IEPerfilUsuarioDetalle> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEPerfilUsuarioDetalle> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEPerfilUsuarioDetalle>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEPerfilUsuarioDetalle> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEPerfilUsuarioDetalle>>

        public IEnumerator<KeyValuePair<string, IEPerfilUsuarioDetalle>> GetEnumerator()
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