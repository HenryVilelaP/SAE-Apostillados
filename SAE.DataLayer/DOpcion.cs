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
    public interface IDOpcion
    {
        void Constructor(string pstrCadenaConexion);
        IEOpcionCollection ListarOpcionPerfil(NullInt32 pintCodigoPerfil, Int32 pintCodModulo, NullInt32 pintCodPerfilUsuarioOf);
        Int32 FNC_ObtieneNumeroRegistros(NullInt32 CoDOpcion);



        NullString Insertar(SqlTransaction pobjTx, IEOpcion pobjOpcion);
        NullString Actualizar(SqlTransaction pobjTx, IEOpcion pobjOpcion);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        //  IEOpcionCollection IOpcion(NullInt32 pintCodigoPerfil);

    }



    public class DOpcion : PrimitiveEntity, IDOpcion
    {


        private string _strCadenaConexion;
        public DOpcion() { }



        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
        public Int32 FNC_ObtieneNumeroRegistros(NullInt32 CoDOpcion)
        {
            try
            {
                DataRow dr;
                Clear();
                Add(PrimitiveParameter.CreateInput("@param_codigo", CoDOpcion));
                dr = this.ExecuteDataRow("NumRegistrosListarOpcion", this._strCadenaConexion);

                return (int)dr[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public IEOpcionCollection ObtenerOpcion(NullInt32 CoDOpcion)
        {
            IEOpcionCollection collection = new EOpcionCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@param_codigo", CoDOpcion));

                dt = ExecuteDataTable("ObtenerOpcion", this._strCadenaConexion);

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

        public IEOpcionCollection ListarOpcionPerfil(NullInt32 pintCodigoPerfil, Int32 pintCodModulo, NullInt32 pintCodPerfilUsuarioOf)
        {
            IEOpcionCollection collection = new EOpcionCollection();
            DataTable dt;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERFIL", pintCodigoPerfil));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_MODULO", pintCodModulo));
                Add(PrimitiveParameter.CreateInput("@PI_COD_PERFIL_USUARIO_OF", pintCodPerfilUsuarioOf));

                
                dt = ExecuteDataTable("SAESS_LISTAR_OPCION_X_PERFIL", this._strCadenaConexion);
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
        public NullString Insertar(SqlTransaction pobjTx, IEOpcion pobjOpcion)
        {
            try
            {
                Clear();

                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Opcion", pobjOpcion.NombreOpcion , 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjOpcion.DescripcionOpcion , 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjOpcion.DiferenciaHoraria , 1));


                return NullString.Create(ExecuteNonQuery("INSERTAR_Opcion", pobjTx).ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NullString Actualizar(SqlTransaction pobjTx, IEOpcion pobjOpcion)
        {
            try
            {
                Clear();
                //Add(PrimitiveParameter.CreateInput("@pi_codigo", pobjOpcion.CodigoOpcion.Value ));
                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Opcion", pobjOpcion.NombreOpcion, 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjOpcion.DescripcionOpcion, 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjOpcion.DiferenciaHoraria, 1));


                return NullString.Create(ExecuteNonQuery("ACTUALIZAR_Opcion", pobjTx).ToString());

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
