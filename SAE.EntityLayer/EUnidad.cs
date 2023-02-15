using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{

    public interface IEUnidad : IEAuditoria 
    {
       
        NullInt32 CodigoUnidad { get; set; }
        NullInt32 CodigoParamUbicacion { get; set; }
        NullString NombreUnidad { get; set; }
        NullString Abreviatura { get; set; }
        

    }


    public class EUnidad : EAuditoria, IEUnidad 
    {


    
        private NullInt32 unid_icodigo_unidad;
        private NullInt32 para_icodigo_ubicacion;
        private NullString unid_vnombre_unidad;
        private NullString unid_vabreviatura;
     

        public static EUnidad Create(DataRow row)
        {

            EUnidad oUnidad = new EUnidad();

            oUnidad.CodigoUnidad = NullInt32.Create(row, "CODIGO_UNIDAD");
            oUnidad.NombreUnidad = NullString.Create(row, "NOMBRE_UNIDAD");
            oUnidad.Abreviatura = NullString.Create(row, "ABREVIATURA");
            oUnidad.SituacionRegistro = NullString.Create(row, "SITUACION");
            oUnidad.CodigoParamUbicacion = NullInt32.Create(row, "CODIGO_PARAM_UBICACION");
              

            return oUnidad;
        }



        #region IEUnidad Members

        public NullInt32 CodigoUnidad
        {
            get
            {
                return this.unid_icodigo_unidad;
            }
            set
            {
                unid_icodigo_unidad = value;
            }
        }
        public NullInt32 CodigoParamUbicacion
        {
            get
            {
                return this.para_icodigo_ubicacion;
            }
            set
            {
                this.para_icodigo_ubicacion = value;
            }
        }
        public NullString NombreUnidad
        {
            get
            {
                return this.unid_vnombre_unidad;
            }
            set
            {
                this.unid_vnombre_unidad = value;
            }
        }
        public NullString Abreviatura
        {
            get
            {
                return this.unid_vabreviatura;
            }
            set
            {
                this.unid_vabreviatura = value;
            }
        }

        #endregion

    }
}
