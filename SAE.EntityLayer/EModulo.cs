using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{

    public interface IEModulo : IEAuditoria
    {
        NullInt32 CodigoModulo { get; set; }
        NullInt32 CodigoModuloPadre { get; set; }
        NullString Nombre { get; set; }
        NullString Descripcion { get; set; }
        NullString Situacion { get; set; }
        NullString Ruta { get; set; }
        NullInt32 Nivel { get; set; }
        NullString ModuloCritica { get; set; }
    }


    public class EModulo : EAuditoria,  IEModulo
    {


        private NullInt32 modu_icodigo_Modulo;
        private NullInt32 modu_inivel_Modulo;
        private NullString modu_vnombre_Modulo;
        private NullString modu_vruta_pagina;
        private NullString modu_vdescripcion_Modulo;
        private NullInt32 modu_icodigo_Modulo_dependiente;
        private NullString modu_cflag_Modulo_critica;
        private NullInt32 modu_iusuario_crea;
        private NullInt32 modu_sfecha_crea;
        private NullInt32 modu_iusuario_modifica;
        private NullInt32 modu_sfecha_modifica;
        private NullString modu_cestado;

  

        public static EModulo Create(DataRow row)
        {

            EModulo oModulo = new EModulo();

            oModulo.CodigoModulo= NullInt32.Create(row, "CODIGO_MODULO");
            //oModulo.CodigoModuloPadre = NullInt32.Create(row, "CODIGOPADRE");
            oModulo.Nombre = NullString.Create(row, "MODULO");
            //oModulo.Descripcion = NullString.Create(row,"DESCRIPCION");
            //oModulo.Nivel = NullInt32.Create(row, "NIVELModulo");
            //oModulo.ModuloCritica = NullString.Create(row, "ModuloCRITICA");
            //oModulo.Situacion = NullString.Create(row, "SITUACION");
            //oModulo.Ruta  = NullString.Create(row, "RUTA");
     
 
            return oModulo;
        }

        #region IEModulo Members

       public  NullInt32 CodigoModulo
        {
            get
            {
                return this.modu_icodigo_Modulo;
            }
            set
            {
                this.modu_icodigo_Modulo = value;
            }
        }

       public NullInt32 CodigoModuloPadre
        {
            get
            {
                return this.modu_icodigo_Modulo_dependiente;
            }
            set
            {
                this.modu_icodigo_Modulo_dependiente = value;
            }
        }

       public NullString Nombre
        {
            get
            {
                return this.modu_vnombre_Modulo;
            }
            set
            {
                this.modu_vnombre_Modulo = value;
            }
        }

       public NullString Descripcion
        {
            get
            {
                return this.modu_vdescripcion_Modulo;
            }
            set
            {
                this.modu_vdescripcion_Modulo = value;
            }
        }

       public NullString Situacion
        {
            get
            {
                return this.modu_cestado;
            }
            set
            {
                this.modu_cestado = value;
            }
        }

       public NullString Ruta
        {
            get
            {
                return this.modu_vruta_pagina;
            }
            set
            {
                this.modu_vruta_pagina = value;
            }
        }

       public NullInt32 Nivel
        {
            get
            {
                return this.modu_inivel_Modulo;
            }
            set
            {
                this.modu_inivel_Modulo = value;
            }
        }

       public NullString ModuloCritica
        {
            get
            {
                return this.modu_cflag_Modulo_critica;
            }
            set
            {
                this.modu_cflag_Modulo_critica = value;
            }
        }

        #endregion

        
    }
}
