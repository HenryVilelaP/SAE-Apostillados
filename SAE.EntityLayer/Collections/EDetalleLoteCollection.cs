using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEDetalleLoteCollection : IEnumerable
    {


        #region Propiedades

        IEDetalleLote this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEDetalleLote[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEDetalleLote value);
        bool ContainsKey(string key);
        void Clear();
        IEDetalleLoteCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EDetalleLoteCollection : IEDetalleLoteCollection, IDictionary<string, IEDetalleLote>
    {
        private Dictionary<string, IEDetalleLote> _dictionary;

        public EDetalleLoteCollection()
        {
            this._dictionary = new Dictionary<string, IEDetalleLote>();
        }

        ~EDetalleLoteCollection()
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

        public IEDetalleLote[] Valores
        {
            get
            {
                IEDetalleLote[] values = new IEDetalleLote[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEDetalleLoteCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EDetalleLote entidad = EDetalleLote.Create(row);
                this.Add(entidad.CodigoDetalleLote.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }


        #region Miembros de IDictionary<string,IEDetalleLote>

        public void Add(string key, IEDetalleLote value)
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

        public bool TryGetValue(string key, out IEDetalleLote value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEDetalleLote> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEDetalleLote this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEDetalleLote>>

        public void Add(KeyValuePair<string, IEDetalleLote> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEDetalleLote> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEDetalleLote>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEDetalleLote> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEDetalleLote>>

        public IEnumerator<KeyValuePair<string, IEDetalleLote>> GetEnumerator()
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