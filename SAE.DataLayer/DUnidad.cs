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
    public interface IDUnidad
    {
        void Constructor(string pstrCadenaConexion);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        IEUnidadCollection ListarUnidad( IEUnidad objUnidad);
        NullString Insertar(SqlTransaction pobjTx, IEUnidad pobjUnidad);
        NullString Actualizar(SqlTransaction pobjTx, IEUnidad pobjUnidad);

    }

    public class DUnidad : PrimitiveEntity, IDUnidad
    {
        private string _strCadenaConexion;
        public DUnidad() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales



         /// <summary>
         /// ATRIBUTOS CARGADOS EN EL OBJETO UNIDAD
         /// 
         ///        objUnidad.CodigoUnidad
         ///        objUnidad.NombreUnidad
         ///        objUnidad.SituacionRegistro
         ///        objUnidad.CodigoParametro
         /// </summary>
         /// <param name="objUnidad"></param>
         /// <returns></returns>
        public IEUnidadCollection ListarUnidad(IEUnidad  objUnidad)
        {
            IEUnidadCollection collection = new EUnidadCollection();
            DataTable dt;
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UNIDAD", objUnidad.CodigoUnidad));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE_UNIDAD", objUnidad.NombreUnidad,100));
                Add(PrimitiveParameter.CreateInput("@PC_ESTADO", objUnidad.SituacionRegistro ,1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PARAMETRO", objUnidad.CodigoParamUbicacion ));

                dt = ExecuteDataTable("SAESS_LISTAR_UNIDAD", this._strCadenaConexion);

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
        public NullString Insertar(SqlTransaction pobjTx, IEUnidad pobjUnidad)
        {
            try
            {
                Clear();

                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Unidad", pobjUnidad.NombreUnidad , 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjUnidad.DescripcionUnidad , 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjUnidad.DiferenciaHoraria , 1));


                return NullString.Create(ExecuteNonQuery("INSERTAR_Unidad", pobjTx).ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NullString Actualizar(SqlTransaction pobjTx, IEUnidad pobjUnidad)
        {
            try
            {
                Clear();
                //Add(PrimitiveParameter.CreateInput("@pi_codigo", pobjUnidad.CodigoUnidad.Value ));
                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Unidad", pobjUnidad.NombreUnidad, 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjUnidad.DescripcionUnidad, 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjUnidad.DiferenciaHoraria, 1));


                return NullString.Create(ExecuteNonQuery("ACTUALIZAR_Unidad", pobjTx).ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



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
      


