using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEDocumentoCollection : IEnumerable
    {


        #region Propiedades

        IEDocumento this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEDocumento[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEDocumento value);
        bool ContainsKey(string key);
        void Clear();
        IEDocumentoCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EDocumentoCollection : IEDocumentoCollection, IDictionary<string, IEDocumento>
    {
        private Dictionary<string, IEDocumento> _dictionary;

        public EDocumentoCollection()
        {
            this._dictionary = new Dictionary<string, IEDocumento>();
        }

        ~EDocumentoCollection()
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

        public IEDocumento[] Valores
        {
            get
            {
                IEDocumento[] values = new IEDocumento[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEDocumentoCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EDocumento entidad = EDocumento.Create(row);
                this.Add(entidad.CodigoDocumento.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }
        

        #region Miembros de IDictionary<string,IEDocumento>

        public void Add(string key, IEDocumento value)
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

        public bool TryGetValue(string key, out IEDocumento value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEDocumento> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEDocumento this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEDocumento>>

        public void Add(KeyValuePair<string, IEDocumento> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEDocumento> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEDocumento>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEDocumento> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEDocumento>>

        public IEnumerator<KeyValuePair<string, IEDocumento>> GetEnumerator()
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