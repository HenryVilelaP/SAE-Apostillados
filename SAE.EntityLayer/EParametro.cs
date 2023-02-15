//--------------------------------------------------------------------------------
// Sistema de Gestion Consular
//
// Archivo     : EParametro.cs
// Descripción : Representa a una Parametro.
// Empresa     : MRE
// Autor       : Daniel Balvis 20/04/2009
// Modificado  : N/A
//--------------------------------------------------------------------------------
using SAE.Nullables;
using System;
using System.Data;

namespace SAE.EntityLayer
{
    public interface IEParametro  
    {
        NullInt32 CodigoParametro { get; set; }
        NullInt32 CodigoTabla { get;set;}
        NullInt32 CodigoRegistro { get; set; }
        NullString Descripcion { get;set;}
        NullString Valortexto { get;set;}
        NullDecimal ValorNumerico { get;set;}
        NullString FlagMantenible { get; set; }
        NullString FlagEliminar { get; set; }
        NullString FlagModificar { get; set; }

      
    }

    [Serializable]
    public class EParametro :  IEParametro
    {
      
        private NullInt32 _intCodigoRegistro;
        private NullInt32 _intCodigoParametro;
        private NullInt32 _intCodigoTabla;
        private NullString _strDescripcion;
        private NullString _strValortexto;
        private NullString _strValortexto2;
        private NullDecimal _intValorNumerico;
        private NullInt32 _intValorEntero;
        private NullString _booFlagMantenible;
        private NullString _booFlagModificable;
        private NullString _booFlagEliminable;

        private NullInt32 _UsuarioRegistro;
        private NullDateTime _FechaRegistro;
        private NullInt32 _UsuarioModifica;
        private NullDateTime _FechaModifica;
        private NullString _SituacionRegistro; 

        public static EParametro Create(DataRow row)
        {
            EParametro objEntidad = new EParametro();
            objEntidad.CodigoRegistro = NullInt32.Create(row, "CODIGOREGISTRO");
            objEntidad.CodigoParametro = NullInt32.Create(row, "CODIGOPARAMETRO");
            objEntidad.CodigoTabla = NullInt32.Create(row, "CODIGOTABLA");
            objEntidad.Descripcion = NullString.Create(row, "NOMBREPARAMETRO");
            objEntidad.Valortexto = NullString.Create(row, "VALORTEXTO");
            objEntidad.ValorNumerico = NullDecimal.Create(row, "VALORNUMERICO");
            objEntidad.FlagMantenible = NullString.Create(row, "FLAGMODIFICAR");
            return objEntidad;
        }

        #region Miembros de IEParametro

        public NullInt32 CodigoRegistro
        {
            get { return this._intCodigoRegistro; }
            set { this._intCodigoRegistro = value; }
        }

        public NullInt32 CodigoParametro
        {
            get { return this._intCodigoParametro; }
            set { this._intCodigoParametro = value; }
        }

        public NullString Descripcion
        {
            get { return this._strDescripcion; }
            set { this._strDescripcion = value; }
        }

        public NullInt32 CodigoTabla
        {
            get { return this._intCodigoTabla; }
            set { this._intCodigoTabla = value; }
        }


        public NullString Valortexto
        {
            get { return this._strValortexto; }
            set { this._strValortexto = value; }
        }

        public NullString Valortexto2
        {
            get { return this._strValortexto2; }
            set { this._strValortexto2 = value; }
        }

        public NullDecimal ValorNumerico
        {
            get { return this._intValorNumerico; }
            set { this._intValorNumerico = value; }
        }

        public NullInt32 ValorEntero
        {
            get { return this._intValorEntero; }
            set { this._intValorEntero = value; }
        }


        public NullString FlagMantenible
        {
            get { return this._booFlagMantenible; }
            set { this._booFlagMantenible = value; }
        }

        public NullString FlagEliminar
        {
            get { return this._booFlagEliminable; }
            set { this._booFlagEliminable = value; }
        }

        public NullString FlagModificar
        {
            get { return this._booFlagModificable; }
            set { this._booFlagModificable = value; }
        }

        #endregion

        #region IEAuditoria Members


        public NullInt32 UsuarioRegistro
        {
            get
            {
                return _UsuarioRegistro;
            }
            set
            {
                _UsuarioRegistro = value;
            }
        }
        public NullDateTime FechaRegistro
        {
            get
            {
                return _FechaRegistro;
            }
            set
            {
                _FechaRegistro = value;
            }
        }
        public NullInt32 UsuarioModifica
        {
            get
            {
                return _UsuarioModifica;
            }
            set
            {
                _UsuarioModifica = value;
            }
        }
        public NullDateTime FechaModifica
        {
            get
            {
                return _FechaModifica;
            }
            set
            {
                _FechaModifica = value;
            }
        }
        public NullString SituacionRegistro
        {
            get
            {
                return _SituacionRegistro;
            }
            set
            {
                _SituacionRegistro = value;
            }
        }



        #endregion
    }
}
