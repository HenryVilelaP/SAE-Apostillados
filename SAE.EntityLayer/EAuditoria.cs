
using SAE.Nullables;
using System;

namespace SAE.EntityLayer
{
    public interface IEAuditoria
    {

        NullInt32 UsuarioOficinaPerfilRegistro { get; set; }
        NullInt32 UsuarioOficinaPerfilModifica { get; set; }
        NullInt32 UsuarioRegistro { get; set; }
        NullDateTime FechaRegistro { get; set; }
        NullInt32 UsuarioModifica { get; set; }
        NullDateTime FechaModifica { get; set; }
        NullString SituacionRegistro { get; set; }
        NullString ATipoAtencion { get; set; }
        string DescripcionSituacion { get; }
        string DescripcionTipoAtencion { get; }
    }

    [Serializable]
    public class EAuditoria : IEAuditoria
    {
        protected NullInt32 _strUsuarioRegistro;
        protected NullInt32 _strPerfilUsuarioRegistro;
        protected NullInt32 _strPerfilUsuarioModifica;
        protected NullDateTime _dtFechaRegistro;
        protected NullInt32 _strUsuarioModifica;
        protected NullDateTime _dtFechaModifica;
        protected NullString _strSituacionRegistro;
        protected NullString _strTipoAtencion;
      
	
        public EAuditoria()
        {
        }

        #region Miembros de IEAuditoria

        public NullInt32 UsuarioOficinaPerfilRegistro
        {
            get { return this._strPerfilUsuarioRegistro; }
            set { this._strPerfilUsuarioRegistro = value; }
        }
        public NullInt32 UsuarioOficinaPerfilModifica
        {
            get { return this._strPerfilUsuarioModifica; }
            set { this._strPerfilUsuarioModifica = value; }
        }
        public NullInt32 UsuarioRegistro
        {
            get { return this._strUsuarioRegistro; }
            set { this._strUsuarioRegistro = value; }
        }
        public NullDateTime FechaRegistro
        {
            get { return this._dtFechaRegistro; }
            set { this._dtFechaRegistro = value; }
        }

        public NullInt32 UsuarioModifica
        {
            get { return this._strUsuarioModifica; }
            set { this._strUsuarioModifica = value; }
        }

        public NullDateTime FechaModifica
        {                                       
            get { return this._dtFechaModifica; }
            set { this._dtFechaModifica = value; }
        }

        public NullString SituacionRegistro
        {
            get { 
                
                return   this._strSituacionRegistro;
                 
            
            }
            set { this._strSituacionRegistro = value; }
        }
        public NullString ATipoAtencion
        {
            get { return this._strTipoAtencion; }
            set { this._strTipoAtencion = value; }
        }
        public virtual String DescripcionSituacion
        {
            get
            {
                if (this._strSituacionRegistro.HasValue)
                {
                    if ("A".Equals(this._strSituacionRegistro.Value))
                        return "ACTIVO";
                    if ("I".Equals(this._strSituacionRegistro.Value))
                        return "INACTIVO";
                    if ("B".Equals(this._strSituacionRegistro.Value))
                        return "BLOQUEADO";
                }
                return "NO DETERMINADO";
            }
        }
        public virtual String DescripcionTipoAtencion
        {
            get
            {
                if (this._strSituacionRegistro.HasValue)
                {
                    if ("0001".Equals(this._strTipoAtencion.Value))
                        return "EMPRESARIAL";
                    if ("0002".Equals(this._strTipoAtencion.Value))
                        return "RESIDENCIAL";
                }
                return "NO DETERMINADO";
            }
        }
        
        
        #endregion
    }
}