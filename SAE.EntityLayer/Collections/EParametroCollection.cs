//--------------------------------------------------------------------------------
// Sistema de Gestion Consular
//
// Archivo     : EParametroCollection.cs
// Descripción : Representa a una Parametro.
// Empresa     : MRE
// Autor       : Daniel Balvis 20/04/2009
// Modificado  : N/A
//--------------------------------------------------------------------------------

using SAE.EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SAE.EntityLayer.Collections
{
    public interface IEParametroCollection : IEnumerable
    {
        // Propiedades
        IEParametro this[string key] { get; set; }
        int Count { get; }
        string[] Codigos { get; }
        IEParametro[] Valores { get; }

        // Métodos
        void Add(string key, IEParametro value);
        bool ContainsKey(string key);
        void Clear();
        IEParametroCollection Fill(DataTable dt);
        bool Remove(string key);
    }

    [Serializable]
    public class EParametroCollection : IEParametroCollection, IDictionary<string, IEParametro>
    {
        private Dictionary<string, IEParametro> _dictionary;

        public EParametroCollection()
        {
            this._dictionary = new Dictionary<string, IEParametro>();
        }

        ~EParametroCollection()
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

        public IEParametro[] Valores
        {
            get
            {
                IEParametro[] values = new IEParametro[this.Count];
                this._dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }

        public IEParametroCollection Fill(DataTable dt)
        {
            this.Clear();
            foreach (DataRow row in dt.Rows)
            {
                EParametro entidad = EParametro.Create(row);
                this.Add(entidad.CodigoRegistro.Value + "|" + entidad.CodigoTabla.Value, entidad);
                entidad = null;
            }
            return this;
        }

        #region Miembros de IDictionary<string,IEParametro>

        public void Add(string key, IEParametro value)
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

        public bool TryGetValue(string key, out IEParametro value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public ICollection<IEParametro> Values
        {
            get { return this._dictionary.Values; }
        }

        public IEParametro this[string key]
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

        #region Miembros de ICollection<KeyValuePair<string,IEParametro>>

        public void Add(KeyValuePair<string, IEParametro> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            this._dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, IEParametro> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CopyTo(KeyValuePair<string, IEParametro>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<string, IEParametro> item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IEnumerable<KeyValuePair<string,IEParametro>>

        public IEnumerator<KeyValuePair<string, IEParametro>> GetEnumerator()
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
