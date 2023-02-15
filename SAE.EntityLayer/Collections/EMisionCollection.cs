using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGC.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEMisionCollection : IEnumerable
    {


        #region Propiedades

        IEMision this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEMision[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEMision value);
        bool ContainsKey(string key);
        void Clear();
        IEMisionCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EMisionCollection : IEMisionCollection, IDictionary<string, IEMision>
    {
        private Dictionary<string, IEMision> _dictionary;

        public EMisionCollection()
        {
            this._dictionary = new Dictionary<string, IEMision>();
        }

        ~EMisionCollection()
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

        public IEMision[] Valores
        {
            get
            {
                IEMision[] values = new IEMision[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEMisionCollection Fill(DataTable dt)
        {
            this.Clear();
            
            foreach (DataRow row in dt.Rows)
            {
                EMision entidad = EMision.Create(row);
                this.Add(entidad.CodigoMision.UINullable.ToString() , entidad);
                entidad = null;
              
            }
            return this;
        }

        #region Miembros de IDictionary<string,IEMision>

        public void Add(string key, IEMision value)
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

        public bool TryGetValue(string key, out IEMision value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEMision> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEMision this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEMision>>

        public void Add(KeyValuePair<string, IEMision> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEMision> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEMision>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEMision> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEMision>>

        public IEnumerator<KeyValuePair<string, IEMision>> GetEnumerator()
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