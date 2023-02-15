using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using SAE.EntityLayer.Collections;
using SAE.EntityLayer;
using SAE.Nullables;

namespace SAE.DataLayer
{
    public interface IDOficina
    {
        void Constructor(string pstrCadenaConexion);
        //IEOficinaCollection ListarOficina(NullInt32 CodOficina, Int32 pintNumeroPagina, Int32 pintTamanioPaginacion);
        IEOficinaCollection ListarOficina(NullInt32 pintCodOficina, NullInt32 pintCodUbicacion);
        Int32 FNC_ObtieneNumeroRegistros(NullInt32 CodOficina);

        NullString Insertar(SqlTransaction pobjTx, IEOficina pobjOficina);
        NullString Actualizar(SqlTransaction pobjTx, IEOficina pobjOficina);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        IEOficinaCollection ObtenerOficina(NullInt32 CodOficina);
    }

    public class DOficina : PrimitiveEntity, IDOficina
    {
        private string _strCadenaConexion;
        public DOficina() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
        public Int32 FNC_ObtieneNumeroRegistros(NullInt32 CodOficina)
        {
            try
            {
                DataRow dr;
                Clear();
                Add(PrimitiveParameter.CreateInput("@param_codigo", CodOficina));
                dr = this.ExecuteDataRow("NumRegistrosListarOficina", this._strCadenaConexion);

                return (int)dr[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public IEOficinaCollection ObtenerOficina(NullInt32 CodOficina)
        {
            IEOficinaCollection collection = new EOficinaCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@param_codigo", CodOficina));

                dt = ExecuteDataTable("ObtenerOficina", this._strCadenaConexion);

                return collection.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt = null;
            }
        }

        //public IEOficinaCollection ListarOficina(NullInt32 CodOficina, Int32 pintNumeroPagina, Int32 pintTamanioPaginacion)
        //{
        //    IEOficinaCollection collection = new EOficinaCollection();
        //    DataTable dt;
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", CodOficina));
        //        Add(PrimitiveParameter.CreateInput("@PI_PAGENUM", pintNumeroPagina));
        //        Add(PrimitiveParameter.CreateInput("@PI_PAGESIZE", pintTamanioPaginacion));

        //        dt = ExecuteDataTable("SAESS_LISTAR_OFICINA_PAGINADA", this._strCadenaConexion);

        //        return collection.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dt = null;
        //    }
        //}
        public IEOficinaCollection ListarOficina(NullInt32 pintCodOficina, NullInt32 pintCodUbicacion)
        {
            IEOficinaCollection collection = new EOficinaCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pintCodOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodUbicacion));
                dt = ExecuteDataTable("SAESS_LISTAR_OFICINA", this._strCadenaConexion);

                return collection.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt = null;
            }
        }

        #endregion

        #region Métodos Transaccionales
        public NullString Insertar(SqlTransaction pobjTx, IEOficina pobjOficina)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@pv_nombre_mision", pobjOficina.NombreOficina, 100));
                Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjOficina.DescripcionOficina, 250));
                Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjOficina.DiferenciaHoraria, 1));


                return NullString.Create(ExecuteNonQuery("INSERTAR_OFICINA", pobjTx).ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NullString Actualizar(SqlTransaction pobjTx, IEOficina pobjOficina)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@pi_codigo", pobjOficina.CodigoOficina.Value));
                Add(PrimitiveParameter.CreateInput("@pv_nombre_mision", pobjOficina.NombreOficina, 100));
                Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjOficina.DescripcionOficina, 250));
                Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjOficina.DiferenciaHoraria, 1));


                return NullString.Create(ExecuteNonQuery("ACTUALIZAR_OFICINA", pobjTx).ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void Actualizar(SqlTransaction pobjTx, IEUsuario pobjUsuario)
        //{
        //    try
        //    {
        //        Clear();

        //        Add(PrimitiveParameter.CreateInput("@PC_CODIGO_USU", pobjUsuario.Codigo, 10));
        //        Add(PrimitiveParameter.CreateInput("@PV_NOMBRE_USU", pobjUsuario.Nombre, 50));
        //        Add(PrimitiveParameter.CreateInput("@PV_PATERNO_USU", pobjUsuario.Paterno, 50));
        //        Add(PrimitiveParameter.CreateInput("@PV_MATERNO_USU", pobjUsuario.Materno, 50));
        //        Add(PrimitiveParameter.CreateInput("@PC_COD_VENDEDOR", pobjUsuario.NroDocumento, 10));
        //        Add(PrimitiveParameter.CreateInput("@PC_COD_ENTIDAD", pobjUsuario.CodEntidad, 5));
        //        Add(PrimitiveParameter.CreateInput("@PC_COD_PTOVENTA", pobjUsuario.CodPuntoVenta, 3));
        //        Add(PrimitiveParameter.CreateInput("@PC_COD_TIPOATEN", pobjUsuario.CodTipoAtencion, 4));
        //        Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjUsuario.SituacionRegistro, 1));
        //        Add(PrimitiveParameter.CreateInput("@PC_AUDITORIA", pobjUsuario.UsuarioRegistro, 10));

        //        ExecuteNonQuery("SACSU_USUARIO_Actualizar", pobjTx);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@pi_codigo", pi_codigo));
                ExecuteNonQuery("eliminar", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
