using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEOpcionCollection : IEnumerable
    {


        #region Propiedades

        IEOpcion this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEOpcion[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEOpcion value);
        bool ContainsKey(string key);
        void Clear();
        IEOpcionCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EOpcionCollection : IEOpcionCollection, IDictionary<string, IEOpcion>
    {
        private Dictionary<string, IEOpcion> _dictionary;

        public EOpcionCollection()
        {
            this._dictionary = new Dictionary<string, IEOpcion>();
        }

        ~EOpcionCollection()
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

        public IEOpcion[] Valores
        {
            get
            {
                IEOpcion[] values = new IEOpcion[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEOpcionCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EOpcion entidad = EOpcion.Create(row);
                this.Add(entidad.CodigoOpcion.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEOpcion>

        public void Add(string key, IEOpcion value)
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

        public bool TryGetValue(string key, out IEOpcion value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEOpcion> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEOpcion this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEOpcion>>

        public void Add(KeyValuePair<string, IEOpcion> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEOpcion> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEOpcion>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEOpcion> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEOpcion>>

        public IEnumerator<KeyValuePair<string, IEOpcion>> GetEnumerator()
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