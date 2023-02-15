using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{

    public interface IEPerfil : IEAuditoria
    {

        NullInt32 CodigoPerfil { get; set; }
        NullInt32 CodigoUnidad { get; set; }
        NullString NombrePerfil { get; set; }
        NullString Descripcion { get; set; }


        

    }


    public class EPerfil : EAuditoria, IEPerfil
    {

        private NullInt32 perf_icodigo_perfil;
        private NullInt32 unid_icodigo_unidad;
        private NullString perf_vnombre_perfil ;
        private NullString perf_vdescipcion_perfil;
      
   
 


        public static EPerfil Create(DataRow row)
        {

            EPerfil oPerfil = new EPerfil();

            oPerfil.CodigoPerfil = NullInt32.Create(row, "CODIGO_PERFIL");
            oPerfil.CodigoUnidad = NullInt32.Create(row, "CODIGO_UNIDAD");
            oPerfil.NombrePerfil = NullString.Create(row, "NOMBRE_PERFIL");
            oPerfil.SituacionRegistro = NullString.Create( row,"SITUACION");
            oPerfil.Descripcion = NullString.Create(row, "DESCRIPCION");

            return oPerfil;
        }



        #region IEPerfil Members

        public NullInt32 CodigoPerfil
        {
            get
            {
                return  perf_icodigo_perfil;
            }
            set
            {
                perf_icodigo_perfil = value;

            }
        }

        public NullString NombrePerfil
        {
            get
            {
                return  perf_vnombre_perfil;
            }
            set
            {
                this.perf_vnombre_perfil = value;
            }
        }

        public NullInt32  CodigoUnidad
        {
            get
            {
                return  unid_icodigo_unidad ;
            }
            set
            {
                this.unid_icodigo_unidad = value;
            }
        }

        public NullString Descripcion 
        {
            get
            {
                return  perf_vdescipcion_perfil ;
            }
            set
            {
                this.perf_vdescipcion_perfil = value;
            }
        }

   


        #endregion
    }
}
