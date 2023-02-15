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
    public interface IDUsuarioOficina
    {
        void Constructor(string pstrCadenaConexion);
        //IEUsuarioOficinaCollection ListarUsuarioOficina(NullInt32 CodUsuarioOficina, Int32 pintNumeroPagina, Int32 pintTamanioPaginacion);
        //IEUsuarioOficinaCollection ListarUsuarioOficina(NullInt32 pintCodUsuarioOficina, NullInt32 pintCodUbicacion);
        //Int32 FNC_ObtieneNumeroRegistros(NullInt32 CodUsuarioOficina);

        NullInt32 Insertar(SqlTransaction pobjTx, IEUsuarioOficina pobjUsuarioOficina);
        //NullString Actualizar(SqlTransaction pobjTx, IEUsuarioOficina pobjUsuarioOficina);
        //void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        //IEUsuarioOficinaCollection ObtenerUsuarioOficina(NullInt32 CodUsuarioOficina);
    }

    public class DUsuarioOficina : PrimitiveEntity, IDUsuarioOficina
    {
        private string _strCadenaConexion;
        public DUsuarioOficina() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        //#region Métodos No Transaccionales
        //public Int32 FNC_ObtieneNumeroRegistros(NullInt32 CodUsuarioOficina)
        //{
        //    try
        //    {
        //        DataRow dr;
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@param_codigo", CodUsuarioOficina));
        //        dr = this.ExecuteDataRow("NumRegistrosListarUsuarioOficina", this._strCadenaConexion);

        //        return (int)dr[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //public IEUsuarioOficinaCollection ObtenerUsuarioOficina(NullInt32 CodUsuarioOficina)
        //{
        //    IEUsuarioOficinaCollection collection = new EUsuarioOficinaCollection();
        //    DataTable dt;
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@param_codigo", CodUsuarioOficina));

        //        dt = ExecuteDataTable("ObtenerUsuarioOficina", this._strCadenaConexion);

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

        //public IEUsuarioOficinaCollection ListarUsuarioOficina(NullInt32 CodUsuarioOficina, Int32 pintNumeroPagina, Int32 pintTamanioPaginacion)
        //{
        //    IEUsuarioOficinaCollection collection = new EUsuarioOficinaCollection();
        //    DataTable dt;
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UsuarioOficina", CodUsuarioOficina));
        //        Add(PrimitiveParameter.CreateInput("@PI_PAGENUM", pintNumeroPagina));
        //        Add(PrimitiveParameter.CreateInput("@PI_PAGESIZE", pintTamanioPaginacion));

        //        dt = ExecuteDataTable("SAESS_LISTAR_UsuarioOficina_PAGINADA", this._strCadenaConexion);

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
        //public IEUsuarioOficinaCollection ListarUsuarioOficina(NullInt32 pintCodUsuarioOficina, NullInt32 pintCodUbicacion)
        //{
        //    IEUsuarioOficinaCollection collection = new EUsuarioOficinaCollection();
        //    DataTable dt;
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UsuarioOficina", pintCodUsuarioOficina));
        //        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodUbicacion));
        //        dt = ExecuteDataTable("SAESS_LISTAR_UsuarioOficina", this._strCadenaConexion);

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

        //#endregion

        #region Métodos Transaccionales
        public NullInt32 Insertar(SqlTransaction pobjTx, IEUsuarioOficina pobjUsuarioOficina)
        {
            try
            {
                Clear();
 
                Add(PrimitiveParameter.CreateOutputInt32("@PI_CODIGO"));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pobjUsuarioOficina.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pobjUsuarioOficina.CodigoUsuario));
                ExecuteNonQuery("SAESI_INSERTAR_USUARIO_OFICINA", pobjTx);
                return NullInt32.Create(Convert.ToInt32(Out(0)));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public NullString Actualizar(SqlTransaction pobjTx, IEUsuarioOficina pobjUsuarioOficina)
        //{
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@pi_codigo", pobjUsuarioOficina.CodigoUsuarioOficina.Value));
        //        Add(PrimitiveParameter.CreateInput("@pv_nombre_mision", pobjUsuarioOficina.NombreUsuarioOficina, 100));
        //        Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjUsuarioOficina.DescripcionUsuarioOficina, 250));
        //        Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjUsuarioOficina.DiferenciaHoraria, 1));


        //        return NullString.Create(ExecuteNonQuery("ACTUALIZAR_UsuarioOficina", pobjTx).ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

       

        //public void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo)
        //{
        //    try
        //    {
        //        Clear();

        //        Add(PrimitiveParameter.CreateInput("@pi_codigo", pi_codigo));
        //        ExecuteNonQuery("eliminar", pobjTx);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

    }
}
