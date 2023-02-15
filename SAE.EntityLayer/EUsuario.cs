//--------------------------------------------------------------------------------
// Sistema de Gestion Consular -    SAE
//
// Archivo     : EUsuario.cs
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
    public interface IEUsuario : IEAuditoria  ,IEPersona
    {
        NullInt32 Codigo { get;set;}
        NullInt32 CodigoUsuario { get;set;}
        NullString UsuarioRed { get;set;}
        NullString Dominio { get;set;}
        NullString Correo { get;set;}
        IEOpcionCollection Opcions{ get; set; }
        IEPerfilUsuarioCollection Perfiles  { get; set; }
        //NullString OficinaAsignada { get; set; }
     

       
    }

    [Serializable]
    public class EUsuario : EPersona, IEUsuario  
    {
        private NullInt32 _strCodigo;
        private NullInt32 _strCodigoUsuario;
        private NullString _strNombre;
        private NullString _strPaterno;
        private NullString _strMaterno;
        private NullString _strUsuarioRed;
        private NullString _strDominio;
        private NullString _strCorreo;
 
        private IEOpcionCollection _Opcion_collection;
        private IEPerfilUsuarioCollection _perfil_collection;
 
        private NullString _strNombrePerfil;
        private NullString _strNombreMision;
        private NullString _strListadoOficinaAsignada;



        public EUsuario()
        {
            _Opcion_collection = new EOpcionCollection();
            _perfil_collection = new  EPerfilUsuarioCollection();
        }
        
        public static EUsuario Create(DataRow row)
        {
                 
            EUsuario objEntidad = new EUsuario();
            
            
            
            objEntidad.Codigo  =  NullInt32.Create(row, "CODIGO_USUARIO") ;
            objEntidad.Nombres  = row.Table.Columns.Contains("NOMBRE_USUARIO").Equals(true) ? NullString.Create(row, "NOMBRE_USUARIO") : NullString.Empty;
            objEntidad.ApellidoMaterno = row.Table.Columns.Contains("APELLIDO_MATERNO").Equals(true) ? NullString.Create(row, "APELLIDO_MATERNO") : NullString.Empty;
            objEntidad.ApellidoPaterno = row.Table.Columns.Contains("APELLIDO_PATERNO").Equals(true) ? NullString.Create(row, "APELLIDO_PATERNO") : NullString.Empty;
            objEntidad.UsuarioRed = row.Table.Columns.Contains("USUARIO_RED").Equals(true) ? NullString.Create(row, "USUARIO_RED") : NullString.Empty;
            objEntidad.Dominio = row.Table.Columns.Contains("DOMINIO_RED").Equals(true) ? NullString.Create(row, "DOMINIO_RED") : NullString.Empty;
            objEntidad.UsuarioOficinaPerfilRegistro = row.Table.Columns.Contains("AUDITORIA_REGISTRO").Equals(true) ? NullInt32.Create(row, "AUDITORIA_REGISTRO") : NullInt32.Empty;
            objEntidad.FechaRegistro = row.Table.Columns.Contains("FECHA_REGISTRO").Equals(true) ? NullDateTime.Create(row, "FECHA_REGISTRO") : NullDateTime.Empty;
            objEntidad.UsuarioOficinaPerfilModifica = row.Table.Columns.Contains("AUDITORIA_MODIFICA").Equals(true) ? NullInt32.Create(row, "AUDITORIA_MODIFICA") : NullInt32.Empty;
            objEntidad.FechaModifica = row.Table.Columns.Contains("FECHA_MODIFICA").Equals(true) ? NullDateTime.Create(row, "FECHA_MODIFICA") : NullDateTime.Empty;
            objEntidad.SituacionRegistro = row.Table.Columns.Contains("ESTADO_REGISTRO").Equals(true) ? NullString.Create(row, "ESTADO_REGISTRO") : NullString.Empty;
            objEntidad.Correo = row.Table.Columns.Contains("CORREO_USUARIO").Equals(true) ? NullString.Create(row, "CORREO_USUARIO") : NullString.Empty;
            objEntidad.NombreCompleto = row.Table.Columns.Contains("NOMBRE_COMPLETO").Equals(true) ? NullString.Create(row, "NOMBRE_COMPLETO") : NullString.Empty;
            objEntidad.OficinaAsignada = row.Table.Columns.Contains("OFICINA_ASIGNADA").Equals(true) ? NullString.Create(row, "OFICINA_ASIGNADA") : NullString.Empty;
            objEntidad.Sexo = NullString.Create(row, "SEXO");
            objEntidad.FechaNacimineto = NullDateTime.Create(row, "FECHA_NACIMIENTO");
            objEntidad.CodigoPaisNacimineto = NullInt32.Create(row, "CODIGO_PAIS_NAC");
            
            objEntidad.CodigoUsuario = NullInt32.Create(row, "CODIGO_USUARIO");

            
            return objEntidad;
        }
       

        #region Miembros de IEServicio

        public NullString OficinaAsignada
        {
            get { return this._strListadoOficinaAsignada; }
            set { this._strListadoOficinaAsignada = value; }
        }
         
        public NullString NombreMision
        {
            get { return this._strNombreMision; }
            set { this._strNombreMision = value; }
        }
        public NullString NombrePerfil
        {
            get { return this._strNombrePerfil; }
            set { this._strNombrePerfil = value; }
        }
        public IEOpcionCollection Opcions
        {
            get { return this._Opcion_collection; }
            set { this._Opcion_collection = value; }
        }
        public IEPerfilUsuarioCollection Perfiles
        {
            get { return this._perfil_collection; }
            set { this._perfil_collection = value; }
        }
         
        public NullInt32 Codigo 
        {
            get { return this._strCodigo; }
            set { this._strCodigo = value; }
        }
        public NullInt32 CodigoUsuario
        {
            get { return this._strCodigoUsuario; }
            set { this._strCodigoUsuario = value; }
        }
        
 
        

        public NullString UsuarioRed
        {
            get { return this._strUsuarioRed; }
            set { this._strUsuarioRed = value; }
        }

        public NullString Dominio
        {
            get { return this._strDominio; }
            set { this._strDominio = value; }
        }
        
        public NullString Correo
        {
            get { return _strCorreo; }
            set { _strCorreo = value; }
        }

        


        #endregion




    
    }
}
