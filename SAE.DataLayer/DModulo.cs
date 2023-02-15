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
    public interface IDModulo
    {
        void Constructor(string pstrCadenaConexion);
        IEModuloCollection ListarModuloXUsuario(Int32 pintCodigoUsuario, string pstrSituacion);
        IEModuloCollection ListarModulo(NullInt32 pintCodigoSist,string pstrSituacion );

         NullString Insertar(SqlTransaction pobjTx, IEModulo pobjModulo);
         NullString Actualizar(SqlTransaction pobjTx, IEModulo pobjModulo);
         void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
       

    }


    
    public class DModulo: PrimitiveEntity, IDModulo 
    {
       

       private string _strCadenaConexion;
       public DModulo() { }



        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
         

        public IEModuloCollection ObtenerModulo(NullInt32 CoDModulo)
        {
            IEModuloCollection collection = new EModuloCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@param_codigo", CoDModulo));

                dt = ExecuteDataTable("ObtenerModulo", this._strCadenaConexion);

                return collection.Fill(dt) ;
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

        public IEModuloCollection ListarModuloXUsuario(Int32 pintCodigoUsuario, string pstrSituacion)
        {
            IEModuloCollection   collection = new EModuloCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pintCodigoUsuario));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion,1));
                dt = ExecuteDataTable("SAESS_LISTAR_MODULO_X_USUARIO", this._strCadenaConexion);

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
        public IEModuloCollection ListarModulo(NullInt32 pintCodigoSist, string pstrSituacion)
        {
            IEModuloCollection collection = new EModuloCollection();
            DataTable dt;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_SISTEMA", pintCodigoSist));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion,1));
                dt = ExecuteDataTable("SAESS_LISTAR_MODULO", this._strCadenaConexion);
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
        public NullString Insertar(SqlTransaction pobjTx,  IEModulo  pobjModulo)
        {
            try
            {
                Clear();

                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Modulo", pobjModulo.NombreModulo , 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjModulo.DescripcionModulo , 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjModulo.DiferenciaHoraria , 1));
             

                return NullString.Create(ExecuteNonQuery("INSERTAR_Modulo", pobjTx).ToString());
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NullString Actualizar(SqlTransaction pobjTx, IEModulo pobjModulo)
        {
            try
            {
                Clear();
                //Add(PrimitiveParameter.CreateInput("@pi_codigo", pobjModulo.CodigoModulo.Value ));
                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Modulo", pobjModulo.NombreModulo, 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjModulo.DescripcionModulo, 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjModulo.DiferenciaHoraria, 1));


                return NullString.Create(ExecuteNonQuery("ACTUALIZAR_Modulo", pobjTx).ToString());

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
