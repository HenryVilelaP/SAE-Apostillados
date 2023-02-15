//--------------------------------------------------------------------------------
// Sistema de Gestion Consular
//
// Archivo     : EActuacion.cs
// Descripción : Representa a una Actuacion.
// Empresa     : MRE
// Autor       : Daniel Balvis 20/04/2009
// Modificado  : N/A
//--------------------------------------------------------------------------------
using SAE.Nullables;
using System;
using System.Data;

namespace SAE.EntityLayer
{
    public interface IEActuacion 
    {
          NullInt32 CodigoActuacion{get; set;}
          NullInt32 CodigoActuacionXOficina { get; set; }
          NullString NumeroApostilla{get; set;}
          NullDateTime FechaApostilla { get; set; }
          NullString OperacionBancaria { get; set; }
          NullString NombreDocumento { get; set; }
          NullInt32 CodigoTipoDocumento { get; set; }
          NullInt32 CodigoApostillador { get; set; }
          NullInt32 CodigoOficina { get; set; }
          NullInt32 CodigoFirmante { get; set; }
          NullString Serie { get; set; }
          NullString NumeroSerie { get; set; }
          NullString NumeroTicket { get; set; }
          NullString ArchivoFirmaApostillador { get; set; }
          NullString NombreOficina { get; set; }
          NullString NombresAutoridad{ get; set; }
          NullString NombresApostillador { get; set; }
          NullInt32 CorrelativoXApostilladorOficina { get; set; }
   
    }

    [Serializable]
    public class EActuacion :  IEActuacion,  IEAuditoria
    {
      
        private NullInt32 _actu_icodigo_actuacion;
        private NullString _actu_inumero_apostilla;
        private NullDateTime _actu_dfecha_apostilla;
        private NullString _actu_ioperacion_bancaria;
        private NullString _actu_vnombre_documento;
        private NullInt32 _para_icodigo_tipo_documento;
        private NullInt32 _apos_icodigo_apostillador;
        private NullInt32 _ofic_icodigo_oficina;
        private NullInt32 _firm_icodigo_firmante;

        private NullString _actu_vserie;
        private NullString _actu_vnumero_serie;
        private NullString _ofic_vnombre_oficina;
        private NullInt32 _UsuarioRegistro;
        private NullDateTime _FechaRegistro;
        private NullInt32 _UsuarioModifica;
        private NullDateTime _FechaModifica;
        private NullString _SituacionRegistro;
        private NullString actu_vnumero_ticket;
        private NullString _archivo_firma_apostillador;
        private NullInt32 _correlativo_apost_oficina;
        private NullInt32 _actu_icodigo_actuacion_x_oficina;
        private NullString _ofic_vnombre_autoridad;
        private NullString _ofic_vnombre_apostillador;

        private NullInt32 _auditoria_registra;
        private NullInt32 _auditoria_modifica;
        private string _desc_SituacionRegistro;
        
       public static EActuacion Create(DataRow row)
        {
           EActuacion objEntidad = new EActuacion();

           objEntidad.CodigoActuacion = NullInt32.Create(row, "CODIGOACTUACION");
           objEntidad.NumeroApostilla = NullString.Create(row, "NUMEROAPOSTILLA");
           objEntidad.FechaApostilla = NullDateTime.Create(row, "FECHAAPOSTILLA");
           objEntidad.OperacionBancaria = NullString.Create(row, "OPERACIONBANCARIA");
           objEntidad.NombreDocumento = NullString.Create(row, "NOMBREDOCUMENTO");
           objEntidad.SituacionRegistro = NullString.Create(row, "SITUACION");
           objEntidad.CodigoTipoDocumento = NullInt32.Create(row, "CODIGOTIPODOCUMENTO");
           objEntidad.CodigoApostillador = NullInt32.Create(row, "CODIGOAPOSTILLADOR");
           objEntidad.CodigoFirmante = NullInt32.Create(row, "CODIGOFIRMANTE");
           objEntidad.NombresApostillador = NullString.Create(row, "NOMBRESAPOSTILLADOR");
           objEntidad.NombresAutoridad = NullString.Create(row, "NOMBRESFIRMANTE");
           objEntidad.NombreDocumento = NullString.Create(row, "NOMBRETIPODOCUMENTO");
           objEntidad.DescripcionSituacion = NullInt32.Create(row, "SITUACIONDESCRIPCION").UINullable;
           objEntidad.CodigoActuacionXOficina = NullInt32.Create(row, "CODIGOACTUACIONOFICINA");
           objEntidad.CorrelativoXApostilladorOficina = NullInt32.Create(row, "CORRELATIVO");
           objEntidad.NombreOficina = NullString.Create(row, "OFICINA");
           objEntidad.Serie = NullString.Create(row, "SERIE");
           objEntidad.NumeroSerie = NullString.Create(row, "NUMEROSERIE");
           objEntidad.ArchivoFirmaApostillador = NullString.Create(row, "NOMBREARCHIVOFIRMA");
           objEntidad.NumeroTicket = NullString.Create(row, "NUMEROTICKET");

         return objEntidad;
        }
        
        #region IEActuacion Members
       public NullString ArchivoFirmaApostillador{
            get { return _archivo_firma_apostillador; }
            set { _archivo_firma_apostillador = value; }
        }
       public NullString Serie
       {
               
            get
            {
                return _actu_vserie;
            }
            set
            {
                _actu_vserie = value;
            }
           
       }
       public NullString NumeroSerie
       {

           get
           {
               return _actu_vnumero_serie;
           }
           set
           {
               _actu_vnumero_serie = value;
           }

       }
       public NullString NumeroTicket
       {

           get
           {
               return actu_vnumero_ticket;
           }
           set
           {
               actu_vnumero_ticket = value;
           }

       }
       public NullString NombreOficina
       {

            
            get
            {
                return _ofic_vnombre_oficina;
            }
            set
            {
                _ofic_vnombre_oficina = value;
            }
        }
       public NullString NombresAutoridad
       {


           get
           {
               return _ofic_vnombre_autoridad;
           }
           set
           {
               _ofic_vnombre_autoridad = value;
           }
       }
       public NullString NombresApostillador
       {


           get
           {
               return _ofic_vnombre_apostillador;
           }
           set
           {
               _ofic_vnombre_apostillador = value;
           }
       }
       public NullInt32 CodigoOficina
       {


           get
           {
               return _ofic_icodigo_oficina;
           }
           set
           {
               _ofic_icodigo_oficina = value;
           }
       }
       public NullInt32 CodigoActuacion
        {
            get
            {
                return _actu_icodigo_actuacion;
            }
            set
            {
                _actu_icodigo_actuacion = value;
            }
        }
       public NullString NumeroApostilla
        {
            get
            {
                return _actu_inumero_apostilla;
            }
            set
            {
                _actu_inumero_apostilla=value;
            }
        }
       public NullDateTime FechaApostilla
        {
            get
            {
                 return _actu_dfecha_apostilla;
            }
            set
            {
                _actu_dfecha_apostilla = value;
            }
        }
       public NullString OperacionBancaria
        {
            get
            {
                 return  _actu_ioperacion_bancaria;
            }
            set
            {
                _actu_ioperacion_bancaria = value;
            }
        }
       public NullString NombreDocumento
        {
            get
            {
                 return _actu_vnombre_documento;
            }
            set
            {
                  _actu_vnombre_documento=value;
            }
        }
       public NullInt32 CodigoTipoDocumento
        {
            get
            {
                 return  _para_icodigo_tipo_documento;
            }
            set
            {
                _para_icodigo_tipo_documento = value;
            }
        }
       public NullInt32 CodigoApostillador
        {
            get
            {
                 return  _apos_icodigo_apostillador;
            }
            set
            {
                _apos_icodigo_apostillador=value;
            }
        }
       public NullInt32 CodigoFirmante
        {
            get
            {
                 return  _firm_icodigo_firmante;
            }
            set
            {
                _firm_icodigo_firmante=value;
            }
        }
       public NullInt32 CorrelativoXApostilladorOficina
        {
            get
            {
                 return  this._correlativo_apost_oficina;
            }
            set
            {
                _correlativo_apost_oficina = value;
            }
        }
       public NullInt32 CodigoActuacionXOficina
        {
            get
            {
                return this._actu_icodigo_actuacion_x_oficina;
            }
            set
            {
                _actu_icodigo_actuacion_x_oficina = value;
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
                return _auditoria_registra;
            }
            set
            {
                _auditoria_registra = value;
            }
        }
        public NullInt32 UsuarioOficinaPerfilModifica
        {
            get
            {
                return _auditoria_modifica;
            }
            set
            {
                _auditoria_modifica = value;
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
            get { return _desc_SituacionRegistro; }
            set
            {
                _desc_SituacionRegistro = value;
            }
        }
        public string DescripcionTipoAtencion
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
