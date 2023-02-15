using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace SAE.EntityLayer
{
    
    public interface IEOficina : IEAuditoria
    {
        NullInt32 CodigoOficina { get; set; }
        NullInt32 CodigoOficinaPadre { get; set; }
        String NombreOficina { get; set; }
        NullString DescripcionOficina { get; set; }
        NullString DiferenciaHoraria { get; set; }
        NullInt32 CodigoUbicacion { get; set; }
    }

    public class EOficina : EAuditoria, IEOficina
    {
        
        private NullInt32 ofic_icodigo_oficina_padre;
        
        private NullString ofic_vdescripcion_oficina;
        private NullString ofic_diferencia_horaria;


        private NullInt32 ofic_icodigo_oficina;
        private String ofic_vnombre_oficina;
        
        private NullInt32 ofic_codigo_pais;
        private NullString ofic_nombrePais;
        private NullInt32 para_icodigo_tipo_oficina;
        private NullString ofic_nombre_tipo_oficina;
        private NullInt32 para_icodigo_ubicacion;
        private NullString ofic_nombre_ubicacion;


        public static EOficina Create(DataRow row)
        {
            EOficina oOficina = new EOficina();

            //                    ofic_icodigo_oficina				OFICINA,
            //                    ofic_vnombre_oficina				NOMBREOFICINA,
            //                    ofic_vdescripcion_oficina			DESCRIPCIONOFICINA,
            //                    O.pais_icodigo_pais					CODIGOPAIS,
            //                    P.pais_vnombre_pais					NOMBREPAIS,
            //                    para_icodigo_tipo_oficina			CODIGOTIPOOFICINA,
            //                    PARA_A.para_vnombre_parametro		NOMBRETIPOOFICINA,
            //                    ofic_cestado						SITUACION,
            //                    para_icodigo_ubicacion				CODIGOUBICACION,
            //                    PARA_B.para_vnombre_parametro		NOMBREUBICACION,
            //                    para_icodigo_ubicacion_peru			CODIGOUBICACIONPROVINCIA
//                                                                        PROVINCIA
            //oOficina.CodigoOficina = NullInt32.Create(row, "CodigoOficina");
            //oOficina.NombreOficina = NullString.Create(row, "NOMBREOFICINA").UINullable;
            //oOficina.DescripcionOficina = NullString.Create(row, "DESCRIPCIONOFICINA");
            //oOficina.

            oOficina.CodigoOficina = NullInt32.Create(row, "CodigoOficina");
            oOficina.CodigoOficinaPadre = NullInt32.Create(row, "CodigoOficinaPadre");
            oOficina.NombreOficina = (String)row["NombreOficina"];
            oOficina.DescripcionOficina = NullString.Create(row, "DescripcionOficina");
            oOficina.DiferenciaHoraria = NullString.Create(row, "DiferenciaHoraria");
            oOficina.CodigoUbicacion = NullInt32.Create(row, "CodigoUbicacion");

            return oOficina;
        }

        #region IEOficina Members

        public NullInt32 CodigoOficina
        {
            get { return this.ofic_icodigo_oficina; }
            set { ofic_icodigo_oficina = value; }
        }

        public NullInt32 CodigoOficinaPadre
        {
            get { return this.ofic_icodigo_oficina_padre; }
            set { this.ofic_icodigo_oficina_padre = value; }
        }

        public string NombreOficina
        {
            get { return this.ofic_vnombre_oficina; }
            set { this.ofic_vnombre_oficina = value;  }
        }

        public NullString DescripcionOficina
        {
            get { return this.ofic_vdescripcion_oficina; }
            set { this.ofic_vdescripcion_oficina = value; }
        }

        public NullString DiferenciaHoraria
        {
            get { return this.ofic_diferencia_horaria; }
            set { this.ofic_diferencia_horaria = value; }
        }

        public NullInt32 CodigoUbicacion
        {
            get { return this.para_icodigo_ubicacion; }
            set { para_icodigo_ubicacion = value; }
        }

        #endregion


    }
}
