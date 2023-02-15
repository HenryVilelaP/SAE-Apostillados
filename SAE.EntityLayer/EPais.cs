//--------------------------------------------------------------------------------
// Sistema de Gestion Consular -    SAE
//
// Archivo     : EPais.cs
// Descripción : Representa a un PAIS
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
    public interface IEPais : IEAuditoria 
    {
        NullInt32 CodigoPais { get;set;}
        NullString NombrePais { get;set;}
        NullInt32 CodigoRegion { get; set; }
    }

    [Serializable]
    public class EPais : EAuditoria, IEPais  
    {
        private NullInt32 _strCodigo;
        private NullString _strNombre;
        private NullInt32 _strCodigoRegion;

        public static EPais Create(DataRow row)
        {
                 
            EPais objEntidad = new EPais();
            
            
            
            objEntidad.CodigoPais  =  NullInt32.Create(row, "CODIGO_PAIS") ;
            objEntidad.NombrePais  =  NullString.Create(row, "NOMBRE_PAIS")  ;
            objEntidad.CodigoRegion = NullInt32.Create(row, "CODIGO_REGION");

            objEntidad.UsuarioOficinaPerfilRegistro =  NullInt32.Create(row, "AUDITORIA_REGISTRO")  ;
            objEntidad.UsuarioOficinaPerfilModifica =NullInt32.Create(row, "AUDITORIA_MODIFICA")  ;
            objEntidad.FechaRegistro = NullDateTime.Create(row, "FECHA_REGISTRO");
            objEntidad.FechaModifica =   NullDateTime.Create(row, "FECHA_MODIFICA");
            objEntidad.SituacionRegistro =  NullString.Create(row, "ESTADO_REGISTRO") ;
            
             

            
            return objEntidad;
        }
       

        #region Miembros de IEPais

        public NullString NombrePais
        {
            get { return this._strNombre; }
            set { this._strNombre = value; }
        }
        public NullInt32 CodigoPais
        {
            get { return this._strCodigo; }
            set { _strCodigo = value; }
        }
        public NullInt32 CodigoRegion
        {
            get { return this._strCodigoRegion; }
            set { _strCodigoRegion = value; }
        }

        


        #endregion




    
    }
}
