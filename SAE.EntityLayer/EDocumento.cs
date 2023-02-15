//--------------------------------------------------------------------------------
// Sistema de Gestion Consular -    SGC
//
// Archivo     : EDocumento.cs
// Descripción : Representa a un Documento
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
    public interface IEDocumento : IEAuditoria 
    {
        NullInt32 CodigoDocumento { get;set;}
        NullString NumeroDocumento { get;set;}
        NullInt32 CodigoPersona { get; set; }
        NullInt32 CodigoTipoDoc { get; set; }
    }

    [Serializable]
    public class EDocumento : EAuditoria, IEDocumento  
    {

        private NullInt32 docu_icodigo_doucmento;
        private NullString docu_vnumero_documento;
        private NullInt32 pers_icodigo_persona;
        private NullInt32 docu_icodigo_tipo_documento;

        public static EDocumento Create(DataRow row)
        {
                 
            EDocumento objEntidad = new EDocumento();

            objEntidad.CodigoDocumento = NullInt32.Create(row, "CODIGO_Documento");
            objEntidad.CodigoPersona = NullInt32.Create(row, "CODIGO_REGION");
            objEntidad.CodigoTipoDoc = NullInt32.Create(row, "AUDITORIA_REGISTRO");
            objEntidad.NumeroDocumento = NullString.Create(row, "NOMBRE_Documento");
            
            return objEntidad;
        }

        #region IEDocumento Members

        public NullInt32 CodigoDocumento
        {
            get
            {
                return docu_icodigo_doucmento;
            }
            set
            {
                docu_icodigo_doucmento = value;
            }
        }

        public NullString NumeroDocumento
        {
            get
            {
                return docu_vnumero_documento;
            }
            set
            {
               docu_vnumero_documento=value;
            }
        }

        public NullInt32 CodigoPersona
        {
            get
            {
                return pers_icodigo_persona;
            }
            set
            {
                pers_icodigo_persona = value;
            }
        }

        public NullInt32 CodigoTipoDoc
        {
            get
            {
                return docu_icodigo_tipo_documento;
            }
            set
            {
                docu_icodigo_tipo_documento = value;
            }
        }

        #endregion
    }
}
