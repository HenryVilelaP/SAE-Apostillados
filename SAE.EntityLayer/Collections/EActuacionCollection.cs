using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEActuacionCollection : IEnumerable
    {


        #region Propiedades

        IEActuacion this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEActuacion[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEActuacion value);
        bool ContainsKey(string key);
        void Clear();
        IEActuacionCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EActuacionCollection : IEActuacionCollection, IDictionary<string, IEActuacion>
    {
        private Dictionary<string, IEActuacion> _dictionary;

        public EActuacionCollection()
        {
            this._dictionary = new Dictionary<string, IEActuacion>();
        }

        ~EActuacionCollection()
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

        public IEActuacion[] Valores
        {
            get
            {
                IEActuacion[] values = new IEActuacion[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEActuacionCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EActuacion entidad = EActuacion.Create(row);
                this.Add(entidad.CodigoActuacion.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEActuacion>

        public void Add(string key, IEActuacion value)
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

        public bool TryGetValue(string key, out IEActuacion value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEActuacion> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEActuacion this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEActuacion>>

        public void Add(KeyValuePair<string, IEActuacion> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEActuacion> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEActuacion>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEActuacion> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEActuacion>>

        public IEnumerator<KeyValuePair<string, IEActuacion>> GetEnumerator()
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