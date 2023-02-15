//--------------------------------------------------------------------------------
// Sistema de Gestion Consular
//
// Archivo     : EApostillador.cs
// Descripción : Representa a una Apostillador.
// Empresa     : MRE
// Autor       : Daniel Balvis 20/04/2009
// Modificado  : N/A
//--------------------------------------------------------------------------------
using SAE.Nullables;
using System;
using System.Data;

namespace SAE.EntityLayer
{
    public interface IEApostillador 
    {
          NullInt32 CodigoApostillador{get; set;}
          NullString Nombres{get; set;}
          NullString Paterno { get; set; }
          NullString Materno { get; set; }
          NullInt32 Dni { get; set; }
          NullInt32 CodigoCargo { get; set; }
          byte[] Firma { get; set; }
          NullString NombreArchivoFirma { get; set; }
          
    }

    [Serializable]
    public class EApostillador :  IEApostillador,  IEAuditoria
    {
      
        private NullInt32 _apos_icodigo_apostillador;
        private NullString _apos_vnombres;
        private NullString _apos_vpaterno;
        private NullString _apos_vmaterno;
        private NullInt32 _apos_idni;
        private NullInt32 _para_icodigo_cargo;


        private NullInt32 _UsuarioRegistro;
        private NullDateTime _FechaRegistro;
        private NullInt32 _UsuarioModifica;
        private NullDateTime _FechaModifica;
        private NullString _SituacionRegistro;
        private NullString _apos_nombre_firma;
        private byte[] _apos_firma;

        private NullInt32 _UsuarioOficinaPerfilRegistra;
        private NullInt32 _UsuarioOficinaPerfilModifica;

       public static EApostillador Create(DataRow row)
        {
           EApostillador objEntidad = new EApostillador();
           // objEntidad.CodigoRegistro = NullInt32.Create(row, "CODIGOREGISTRO");
           // objEntidad.CodigoApostillador = NullInt32.Create(row, "CODIGOApostillador");
           // objEntidad.CodigoTabla = NullInt32.Create(row, "CODIGOTABLA");
           // objEntidad.Descripcion = NullString.Create(row, "NOMBREApostillador");
           // objEntidad.Valortexto = NullString.Create(row, "VALORTEXTO");
           // objEntidad.ValorNumerico = NullDecimal.Create(row, "VALORNUMERICO");
 
           //// objEntidad.FlagMantenible = NullBoolean.Create(row, "FLAGMODIFICAR");
          return objEntidad;
        }
                
        #region IEApostillador Members
       public NullString NombreArchivoFirma
       {
           get
           {
               return _apos_nombre_firma;
           }
           set
           {
               _apos_nombre_firma = value;
           }
       }
       public byte[] Firma
       {
           get
           {
               return _apos_firma;
           }
           set
           {
               _apos_firma = value;
           }
       }
       public NullInt32 CodigoApostillador
        {
            get
            {
                return _apos_icodigo_apostillador;
            }
            set
            {
                _apos_icodigo_apostillador = value;
            }
        }
        public NullInt32 Dni
        {
            get
            {
                 return  _apos_idni;
            }
            set
            {
                _apos_idni = value;
            }
        }
        public NullInt32 CodigoCargo
        {
            get
            {
                 return  _para_icodigo_cargo;
            }
            set
            {
                _para_icodigo_cargo = value;
            }
        }
        public NullString Nombres
        {
            get
            {
                 return  _apos_vnombres;
            }
            set
            {
                _apos_vnombres = value;
            }
        }
        public NullString Paterno
        {
            get
            {
                 return  _apos_vpaterno;
            }
            set
            {
                _apos_vpaterno = value;
            }
        }
        public NullString Materno
        {
            get
            {
                return _apos_vmaterno;
            }
            set
            {
                _apos_vmaterno = value;
            }
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
 
 

       

        public NullInt32 UsuarioOficinaPerfilRegistro
        {
            get
            {
                return _UsuarioOficinaPerfilRegistra;
            }
            set
            {
                _UsuarioOficinaPerfilRegistra = value;
            }
        }

        public NullInt32 UsuarioOficinaPerfilModifica
        {
            get
            {
                return _UsuarioOficinaPerfilRegistra;
            }
            set
            {
                _UsuarioOficinaPerfilRegistra = value;
            }
        }

        public NullString ATipoAtencion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string DescripcionSituacion
        {
            get { throw new NotImplementedException(); }
        }

        public string DescripcionTipoAtencion
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
