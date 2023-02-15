using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{

    public interface IEPerfilUsuario : IEAuditoria
    {
        NullInt32 CodigoPerfilUsuarioOfi { get; set; }//llave principal
        NullString NombreUbicacion{get;set;}
        NullInt32 CodigoUbicacion { get; set; }
        NullInt32 CodigoOficina { get; set; }
        NullString NombreOficina { get; set; }
        NullInt32 CodigoUsuario { get; set; }
        NullString NombreCompleto { get; set; }
        NullInt32 CodigoPerfil   { get; set; }
        NullString NombrePerfil { get; set; }
        NullString NombreUnidad { get; set; }
        NullString Modulo { get; set; }
        NullInt32 CodigoModulo { get; set; }
        NullInt32 CodigoUnidad { get; set; }
        NullInt32 CodigoUsuarioOficina { get; set; }
    }


    public class EPerfilUsuario : EAuditoria, IEPerfilUsuario
    {
        private NullInt32 perf_icodigo_perfil;
        private NullString perf_vnombre_perfil;
        private NullString str_nombre_completo;
        private NullString str_nombre_ubicacion;
        private NullString str_nombre_unidad;
        private NullInt32 _icodigo_unidad;
        private NullInt32 _icodigo_ubicacion;
        private NullInt32 _icodigo_usuario;
        private NullInt32 _icodigo_oficina;
        private NullInt32 _icodigo_perfil_usuario_oficina;
        private NullString _vnombre_oficina;
        private NullInt32 _icodigo_usuario_oficina;
        private NullString _vnombre_modulo;
        private NullInt32 _icodigo_modulo;

        public static EPerfilUsuario Create(DataRow row)
        {
            EPerfilUsuario oPerfilUsuario = new EPerfilUsuario();
            oPerfilUsuario.CodigoUsuario = NullInt32.Create(row, "CODIGO_USUARIO");
            oPerfilUsuario.CodigoPerfil = NullInt32.Create(row, "CODIGO_PERFIL");
            oPerfilUsuario.NombreCompleto = NullString.Create(row, "NOMBRE_COMPLETO");
            oPerfilUsuario.NombrePerfil = NullString.Create(row, "NOMBRE_PERFIL");
            oPerfilUsuario.NombreUnidad = NullString.Create(row, "NOMBRE_UNIDAD");
            oPerfilUsuario.NombreUbicacion = NullString.Create(row, "NOMBRE_UBICACION");
            oPerfilUsuario.CodigoUnidad = NullInt32.Create(row, "CODIGO_UNIDAD");
            oPerfilUsuario.CodigoUbicacion = NullInt32.Create(row, "CODIGO_UBICACION");
            oPerfilUsuario.SituacionRegistro = NullString.Create(row, "SITUACION");
            oPerfilUsuario.Modulo = row.Table.Columns.Contains("MODULO").Equals(true) ? NullString.Create(row, "MODULO") : NullString.Empty;
            oPerfilUsuario.CodigoModulo = row.Table.Columns.Contains("CODIGO_MODULO").Equals(true) ? NullInt32.Create(row, "CODIGO_MODULO") : NullInt32.Empty;
            oPerfilUsuario.CodigoOficina = row.Table.Columns.Contains("CODIGO_OFICINA").Equals(true) ? NullInt32.Create(row, "CODIGO_OFICINA") : NullInt32.Empty;
            oPerfilUsuario.NombreOficina = row.Table.Columns.Contains("NOMBRE_OFICINA").Equals(true) ? NullString.Create(row, "NOMBRE_OFICINA") : NullString.Empty;
            oPerfilUsuario.CodigoPerfilUsuarioOfi = NullInt32.Create(row, "CODIGO_PERFIL_USUARIO_OFIC");


            return oPerfilUsuario;
        }


        #region Propiedades

        public NullInt32 CodigoModulo
        {
            get
            {
                return _icodigo_modulo;
            }
            set
            {
                _icodigo_modulo = value;
            }
        }

        public NullString Modulo
        {
            get
            {
                return _vnombre_modulo;
            }
            set
            {
                _vnombre_modulo = value;
            }
        }
        public NullString NombreCompleto
        {
            get
            {
                return str_nombre_completo;
            }
            set
            {
                str_nombre_completo = value;
            }
        }
        public NullInt32 CodigoPerfil
        {
            get
            {
                return perf_icodigo_perfil;
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
                return perf_vnombre_perfil;
            }
            set
            {
                perf_vnombre_perfil = value;
            }
        }
        public NullInt32 CodigoUnidad
        {
            get
            {
                return _icodigo_unidad;
            }
            set
            {
                _icodigo_unidad = value;
            }
        }
        public NullString NombreUnidad
        {
            get
            {
                return str_nombre_unidad;
            }
            set
            {
                str_nombre_unidad = value;
            }
        }
        public NullInt32 CodigoUsuario
        {
            get
            {
                return _icodigo_usuario;
            }
            set
            {
                _icodigo_usuario = value;
            }
        }
        public NullInt32 CodigoPerfilUsuarioOfi
        {
            get
            {
                return _icodigo_perfil_usuario_oficina;
            }
            set
            {
                _icodigo_perfil_usuario_oficina = value;
            }
        }
        public NullString NombreUbicacion
        {
            get
            {
                return str_nombre_ubicacion;
            }
            set
            {
                str_nombre_ubicacion = value;
            }
        }
        public NullInt32 CodigoUbicacion
        {
            get
            {
                return _icodigo_ubicacion;
            }
            set
            {
                _icodigo_ubicacion = value;
            }
        }
        public NullInt32 CodigoOficina
        {
            get
            {
                return _icodigo_oficina;
            }
            set
            {
                _icodigo_oficina=value;
            }
        }
        public NullString NombreOficina
        {
            get
            {
                return _vnombre_oficina;
            }
            set
            {
               _vnombre_oficina=value;
            }
        }
        public NullInt32 CodigoUsuarioOficina
        {
            get
            {
                return _icodigo_usuario_oficina;
            }
            set
            {
                _icodigo_usuario_oficina = value;
            }

        }

        #endregion

    }
       
}
