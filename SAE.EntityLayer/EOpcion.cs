using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{

    public interface IEOpcion : IEAuditoria
    {
        NullInt32 CodigoOpcion { get; set; }
        NullInt32 CodigoOpcionPadre { get; set; }
        NullString Nombre { get; set; }
        NullString Descripcion { get; set; }
        NullString Situacion { get; set; }
        NullString Ruta { get; set; }
        NullInt32 Nivel { get; set; }
        NullString OpcionCritica { get; set; }
        NullString TipoAcceso { get; set; }
    }


    public class EOpcion : EAuditoria, IEOpcion
    {


        private NullInt32 modu_icodigo_Opcion;
        private NullInt32 modu_inivel_Opcion;
        private NullString modu_vnombre_Opcion;
        private NullString modu_vruta_pagina;
        private NullString modu_vdescripcion_Opcion;
        private NullInt32 modu_icodigo_Opcion_dependiente;
        private NullString modu_cflag_opcion_critica;
        private NullInt32 modu_iusuario_crea;
        private NullInt32 modu_sfecha_crea;
        private NullInt32 modu_iusuario_modifica;
        private NullInt32 modu_sfecha_modifica;
        private NullString modu_cestado;
        private NullString modu_tipo_accceso;



        public static EOpcion Create(DataRow row)
        {

            EOpcion oOpcion = new EOpcion();

            oOpcion.CodigoOpcion = NullInt32.Create(row, "CODIGOOPCION");
            oOpcion.CodigoOpcionPadre = NullInt32.Create(row, "CODIGOPADRE");
            oOpcion.Nombre = NullString.Create(row, "TITULOOPCION");
            oOpcion.Descripcion = NullString.Create(row, "DESCRIPCION");
            oOpcion.Nivel = NullInt32.Create(row, "NIVELOpcion");
            oOpcion.OpcionCritica = NullString.Create(row, "OPCIONCRITICA");
            oOpcion.Situacion = NullString.Create(row, "SITUACION");
            oOpcion.Ruta = NullString.Create(row, "RUTA");
            oOpcion.TipoAcceso = NullString.Create(row, "TIPO_ACCESO");

            return oOpcion;
        }

        #region IEOpcion Members

        public NullString TipoAcceso
        {
            get
            {
                return modu_tipo_accceso;
            }
            set
            {
                modu_tipo_accceso = value;
            }

        }

        public NullInt32 CodigoOpcion
        {
            get
            {
                return this.modu_icodigo_Opcion;
            }
            set
            {
                this.modu_icodigo_Opcion = value;
            }
        }

        public NullInt32 CodigoOpcionPadre
        {
            get
            {
                return this.modu_icodigo_Opcion_dependiente;
            }
            set
            {
                this.modu_icodigo_Opcion_dependiente = value;
            }
        }

        public NullString Nombre
        {
            get
            {
                return this.modu_vnombre_Opcion;
            }
            set
            {
                this.modu_vnombre_Opcion = value;
            }
        }

        public NullString Descripcion
        {
            get
            {
                return this.modu_vdescripcion_Opcion;
            }
            set
            {
                this.modu_vdescripcion_Opcion = value;
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
                return this.modu_inivel_Opcion;
            }
            set
            {
                this.modu_inivel_Opcion = value;
            }
        }

        public NullString OpcionCritica
        {
            get
            {
                return this.modu_cflag_opcion_critica;
            }
            set
            {
                this.modu_cflag_opcion_critica = value;
            }
        }

        #endregion


    }
}