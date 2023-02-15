//--------------------------------------------------------------------------------
// Sistema de Gestion Consular -    SAE
//
// Archivo     : EStickerApostillador.cs
// Descripción : Representa a un Usuario
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : N/A
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using SAE.Nullables;
using SAE.EntityLayer.Collections;
using SAE.EntityLayer;
using System.Data;

namespace SAE.EntityLayer
{
    public interface IEStickerApostillador : IEAuditoria  
    {
        NullInt32 CodigoStikerApostillador { get;set;}
        NullInt32 CodigoApostillador { get; set; }
        NullInt32 CodigoOficina { get; set; }
        NullString NombresApostillador { get; set; }
        NullString Oficina { get;set;}
        NullString Serie { get;set;}
        NullString CorrelativoInicial { get;set;}
        NullString CorrelativoFinal { get; set; }
        NullInt32 CodigoUbicacionOficina{ get; set; }
    }

    [Serializable]
    public class EStickerApostillador :  IEStickerApostillador  ,IEAuditoria
    {
            NullInt32 para_icodigo_ubicacion;
            NullInt32 stic_icodigo_sticker_apostillador;
            NullInt32 icodigo_apostillador;
            NullInt32 icodigo_oficina;
            NullString _nombres_apostillador;
            NullString ofic_vnombre_oficina;
            NullString stic_vserie;
            NullString seri_vcorrelativo_inicial;
            NullString seri_vcorrelativo_final;
            NullString seri_csituacion;
            string seri_descripcionsituacion;

            NullInt32 _auditoria_registra;
            NullInt32 _auditoria_modifica;
            NullDateTime _fecha_registra;
            NullDateTime _fecha_modifica;


        public EStickerApostillador()
        {
            
        }
        
        public static EStickerApostillador Create(DataRow row)
        {
                 
            EStickerApostillador objEntidad = new EStickerApostillador();

            objEntidad.CodigoStikerApostillador = NullInt32.Create(row, "ID");
            objEntidad.NombresApostillador = NullString.Create(row, "APOSTILLADOR");
            objEntidad.Oficina = NullString.Create(row, "OFICINA");
            objEntidad.Serie = NullString.Create(row, "SERIE");
            objEntidad.CorrelativoInicial = NullString.Create(row, "CORRELATIVOINICIAL");
            objEntidad.CorrelativoFinal = NullString.Create(row, "CORRELATIVOFINAL");
            objEntidad.SituacionRegistro = NullString.Create(row, "SITUACION");
            objEntidad.DescripcionSituacion = NullString.Create(row, "DESCRIPCIONSITUACION").UINullable;
            objEntidad.CodigoApostillador = NullInt32.Create(row, "CODIGOAPOSTILLADOR");
            objEntidad.CodigoOficina = NullInt32.Create(row, "CODIGOAOFICINA");
            objEntidad.CodigoUbicacionOficina = NullInt32.Create(row, "CODIGOUBICACIONOFICINA");
     

            
            return objEntidad;
        }
       

        #region Miembros de IEServicio


        public NullInt32 CodigoUbicacionOficina
        {
            get { return this.para_icodigo_ubicacion; }
            set { this.para_icodigo_ubicacion = value; }
        }
        public NullInt32 CodigoOficina
        {
            get { return this.icodigo_oficina; }
            set { this.icodigo_oficina = value; }
        }
              public NullInt32 CodigoApostillador
        {
            get { return this.icodigo_apostillador; }
            set { this.icodigo_apostillador = value; }
        }
        public NullInt32 CodigoStikerApostillador
        {
            get { return this.stic_icodigo_sticker_apostillador; }
            set { this.stic_icodigo_sticker_apostillador = value; }
        }
        public NullString Oficina
        {
            get { return this.ofic_vnombre_oficina; }
            set { this.ofic_vnombre_oficina = value; }
        }

        public NullString NombresApostillador
        {
            get { return this._nombres_apostillador; }
            set { this._nombres_apostillador = value; }
        }

        public NullString Serie
        {
            get { return this.stic_vserie; }
            set { this.stic_vserie = value; }
        }
        public NullString CorrelativoInicial
        {
            get { return this.seri_vcorrelativo_inicial; }
            set { this.seri_vcorrelativo_inicial = value; }
        }
        public NullString CorrelativoFinal
        {
            get { return this.seri_vcorrelativo_final; }
            set { this.seri_vcorrelativo_final = value; }
        }



        #region IEAuditoria Members
      
        public NullInt32 UsuarioOficinaPerfilRegistro
        {
            get
            {
               return _auditoria_registra;
            }
            set
            {
              _auditoria_registra=value;
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
               _auditoria_modifica=value;
            }
        }

        public NullInt32 UsuarioRegistro
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

        public NullDateTime FechaRegistro
        {
            get
            {
               return _fecha_registra;
            }
            set
            {
                _fecha_registra = value;
            }
        }

        public NullInt32 UsuarioModifica
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

        public NullDateTime FechaModifica
        {
            get
            {
                return _fecha_modifica;
            }
            set
            {
                _fecha_modifica = value;
              
            }
        }

        public NullString SituacionRegistro
        {
            get
            {
                return seri_csituacion;
            }
            set
            {
                seri_csituacion = value;
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
            get { return seri_descripcionsituacion; }
            set { seri_descripcionsituacion = value; }
        }

        public string DescripcionTipoAtencion
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
   #endregion




    
     
}
