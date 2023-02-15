using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{

    public interface IEPerfilUsuarioDetalle : IEAuditoria
    {
        Int32  CodigoPerfilUsuarioOf { get; set; }
        Int32  CodigoOpcion { get; set; }
        String TipoOpcion { get; set; }
        String NombreOpcion { get; set; }
     
    }


    public class EPerfilUsuarioDetalle : EAuditoria, IEPerfilUsuarioDetalle
    {

        private Int32  peuo_icodigo_perfil_usuario;
        private Int32  opci_icodigo_opcion;
        private String peuo_ctipo_acceso;
        private String _nombre_opcion;
        

        public static EPerfilUsuarioDetalle  Create(DataRow row)
        {

            EPerfilUsuarioDetalle oPerfilUsuario = new EPerfilUsuarioDetalle();
  
            oPerfilUsuario.CodigoPerfilUsuarioOf= Convert.ToInt32(row["CODIGO_PERFIL_USUARIO_OFICINA"]);
            oPerfilUsuario.CodigoOpcion =  Convert.ToInt32(row["CODIGO_OPCION"]);
            oPerfilUsuario.TipoOpcion = (String)row["TIPO_ACCESO"];
            oPerfilUsuario.NombreOpcion = row.Table.Columns.Contains("NOMBRE_OPCION") ?  (String)row["NOMBRE_OPCION"] : string.Empty;

            return oPerfilUsuario;
        }



        #region IEPerfilUsuarioDetalle Members


        public int CodigoPerfilUsuarioOf
        {
            get
            {
                return peuo_icodigo_perfil_usuario;
            }
            set
            {
                peuo_icodigo_perfil_usuario = value;
            }
        }

        public int CodigoOpcion
        {
            get
            {
                return opci_icodigo_opcion;
            }
            set
            {
                opci_icodigo_opcion = value;
            }
        }


        public string TipoOpcion
        {
            get
            {
                return peuo_ctipo_acceso;
            }
            set
            {
                peuo_ctipo_acceso = value;
            }
        }
        public string NombreOpcion
        {
            get
            {
                return _nombre_opcion;
            }
            set
            {
                _nombre_opcion = value;
            }
        }

        #endregion
    }
       
}
