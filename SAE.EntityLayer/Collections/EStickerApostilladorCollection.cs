using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAE.EntityLayer;

namespace SAE.EntityLayer.Collections
{
    public interface IEStickerApostilladorCollection : IEnumerable
    {


        #region Propiedades

        IEStickerApostillador this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEStickerApostillador[] Valores { get; }

        #endregion

        #region Métodos

        void Add(string key, IEStickerApostillador value);
        bool ContainsKey(string key);
        void Clear();
        IEStickerApostilladorCollection Fill(DataTable dt);

        bool Remove(string key);

        #endregion
    }

    [Serializable]
    public class EStickerApostilladorCollection : IEStickerApostilladorCollection, IDictionary<string, IEStickerApostillador>
    {
        private Dictionary<string, IEStickerApostillador> _dictionary;

        public EStickerApostilladorCollection()
        {
            this._dictionary = new Dictionary<string, IEStickerApostillador>();
        }

        ~EStickerApostilladorCollection()
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

        public IEStickerApostillador[] Valores
        {
            get
            {
                IEStickerApostillador[] values = new IEStickerApostillador[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEStickerApostilladorCollection Fill(DataTable dt)
        {
            this.Clear();

            foreach (DataRow row in dt.Rows)
            {
                EStickerApostillador entidad = EStickerApostillador.Create(row);
                this.Add(entidad.CodigoStikerApostillador.UINullable.ToString(), entidad);
                entidad = null;

            }
            return this;
        }

        #region Miembros de IDictionary<string,IEStickerApostillador>

        public void Add(string key, IEStickerApostillador value)
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

        public bool TryGetValue(string key, out IEStickerApostillador value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEStickerApostillador> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEStickerApostillador this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEStickerApostillador>>

        public void Add(KeyValuePair<string, IEStickerApostillador> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEStickerApostillador> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEStickerApostillador>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEStickerApostillador> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEStickerApostillador>>

        public IEnumerator<KeyValuePair<string, IEStickerApostillador>> GetEnumerator()
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