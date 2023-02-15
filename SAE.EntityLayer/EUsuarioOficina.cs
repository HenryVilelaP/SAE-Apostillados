using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace SAE.EntityLayer
{
    
    public interface IEUsuarioOficina : IEAuditoria
    {
        NullInt32 CodigoOficina { get; set; }
        NullInt32 CodigoUsuario { get; set; }
        NullInt32 CodigoUsuarioOficina { get; set; }
    }

    public class EUsuarioOficina : EAuditoria, IEUsuarioOficina
    {
             private NullInt32 usof_icodigo_usuario_oficina;
             private NullInt32 ofic_icodigo_oficina;
             private NullInt32 usua_icodigo_usuario;
				 

        public static EUsuarioOficina Create(DataRow row)
        {
            EUsuarioOficina oOficina = new EUsuarioOficina();

            oOficina.CodigoOficina = NullInt32.Create(row, "CodigoOficina");
            oOficina.CodigoUsuario = NullInt32.Create(row, "CodigoUsuario");
            oOficina.CodigoUsuarioOficina = NullInt32.Create(row,"CodigoUsuarioOficina");
            oOficina.SituacionRegistro = NullString.Create(row,"Situacion");
         

            return oOficina;
        }

        #region IEUsuarioOficina Members

        public NullInt32 CodigoOficina
        {
            get { return this.ofic_icodigo_oficina; }
            set { ofic_icodigo_oficina = value; }
        }

        public NullInt32 CodigoUsuario
        {
            get { return this.usua_icodigo_usuario; }
            set { this.usua_icodigo_usuario = value; }
        }

        public NullInt32 CodigoUsuarioOficina
        {
            get { return this.usof_icodigo_usuario_oficina; }
            set { this.usof_icodigo_usuario_oficina = value;  }
        }
      
       

        #endregion


    }
}
