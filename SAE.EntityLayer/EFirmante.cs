//--------------------------------------------------------------------------------
// Sistema de Gestion Consular
//
// Archivo     : EFirmante.cs
// Descripción : Representa a una Firmante.
// Empresa     : MRE
// Autor       : Daniel Balvis 20/04/2009
// Modificado  : N/A
//--------------------------------------------------------------------------------
using SAE.Nullables;
using System;
using System.Data;
using System.Text;

namespace SAE.EntityLayer
{
    public interface IEFirmante 
    {
          NullInt32 CodigoFirmante{get; set;}
          NullString Nombres{get; set;}
          NullString Paterno { get; set; }
          NullString Materno { get; set; }
          NullInt32 Dni { get; set; }
          NullInt32 CodigoCargo { get; set; }
          NullInt32 CodigoEntidad { get; set; }
         
    }

    [Serializable]
    public class EFirmante :  IEFirmante,  IEAuditoria
    {
      
        private NullInt32 _firm_icodigo_Firmante;
        private NullString _firm_vnombres;
        private NullString _firm_vpaterno;
        private NullString _firm_vmaterno;
        private NullInt32 _firm_idni;
        private NullInt32 _para_icodigo_cargo;
        private NullInt32 _para_icodigo_entidad;
        

        private NullInt32 _UsuarioRegistro;
        private NullDateTime _FechaRegistro;
        private NullInt32 _UsuarioModifica;
        private NullDateTime _FechaModifica;
        private NullString _SituacionRegistro;
        
       public static EFirmante Create(DataRow row)
        {

            EFirmante objEntidad = new EFirmante();
        
            return objEntidad;
        }
                
        #region IEFirmante Members

        public NullInt32 CodigoFirmante
        {
            get
            {
                return _firm_icodigo_Firmante;
            }
            set
            {
                _firm_icodigo_Firmante = value;
            }
        }
        public NullInt32 Dni
        {
            get
            {
                 return  _firm_idni;
            }
            set
            {
                _firm_idni = value;
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
        public NullInt32 CodigoEntidad
        {
            get
            {
                return _para_icodigo_entidad;
            }
            set
            {
                _para_icodigo_entidad = value;
            }
        }
        public NullString Nombres
        {
            get
            {
                 return  _firm_vnombres;
            }
            set
            {
                _firm_vnombres = value;
            }
        }
        public NullString Paterno
        {
            get
            {
                 return  _firm_vpaterno;
            }
            set
            {
                _firm_vpaterno = value;
            }
        }
        public NullString Materno
        {
            get
            {
                return _firm_vmaterno;
            }
            set
            {
                _firm_vmaterno = value;
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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public NullInt32 UsuarioOficinaPerfilModifica
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
