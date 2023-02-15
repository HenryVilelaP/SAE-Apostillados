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
    public interface IDUsuario
    {
        void Constructor(string pstrCadenaConexion);
        IEUsuarioCollection ListarUsuarios(IEUsuario pobjUsuario , NullInt32 pintCodigoOficina);
        int ObtenerCodigoXNombres(string pstrNombreCompleto);
        IEUsuarioCollection ListarUsuarioPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc);
        NullInt32 Insertar(SqlTransaction pobjTx, IEUsuario pobjUsuario);
        Int32 InsertarPerfilUsuario(SqlTransaction pTrans, Int32 pintCodigoPerfil, Int32 pintCodigoUsuario, Int32 pintCodigoAuditoria);
        Int32 ActualizarPerfilUsuario(SqlTransaction pTrans, Int32 pintCodigoPerfilNuevo, Int32 pintCodigoPerfilAnterior, Int32 pintCodigoUsuario, Int32 pintCodigoAuditoria, String pstrSituacion);
        Int32 Actualizar(SqlTransaction pobjTx, IEUsuario pobjUsuario);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo, Int32 pi_auditoria);
        IEUsuarioCollection ObtenerUsuario(NullInt32 CodUsuario);
        IEUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario);
        IEUsuarioCollection ListarUsuariosPorOficina(int pintCodigoOficina,string pstrSituacion);
        
    }

    public class DUsuario : PrimitiveEntity, IDUsuario
    {
        private string _strCadenaConexion;
        public DUsuario() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
       

        public IEUsuarioCollection ObtenerUsuario(NullInt32 CodUsuario)
        {
            IEUsuarioCollection collection = new EUsuarioCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@param_codigo", CodUsuario));

                dt = ExecuteDataTable("ObtenerUsuario", this._strCadenaConexion);

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
        

        public IEUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario)
        {
            IEUsuarioCollection collection = new EUsuarioCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", CodUsuario.Value ));

                dt = ExecuteDataTable("SAESS_LISTAR_PERFIL_USUARIO", this._strCadenaConexion);

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
        public IEUsuarioCollection ListarUsuarios(IEUsuario pobjUsuario,NullInt32 pintCodigoOficina)
        {
            IEUsuarioCollection collection = new EUsuarioCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pobjUsuario.Codigo.Value));
                Add(PrimitiveParameter.CreateInput("@PC_ESTADO_REGISTRO", pobjUsuario.SituacionRegistro.Value,1));
                Add(PrimitiveParameter.CreateInput("@PV_DOMINIO", pobjUsuario.Dominio,50));
                Add(PrimitiveParameter.CreateInput("@PV_USUARIO_RED", pobjUsuario.UsuarioRed,50));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE_COMPLETO", pobjUsuario.NombreCompleto, 100));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pintCodigoOficina));
                
                                                   
                dt = ExecuteDataTable("SAESS_LISTAR_USUARIO", this._strCadenaConexion);

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
        public IEUsuarioCollection ListarUsuarioPorDocumento( int pintCodigoTipoDocumento, int pintNumeroDoc)
        {
            IEUsuarioCollection collection = new EUsuarioCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", pintCodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PN_NUMERO_DOCUENTO", pintNumeroDoc));

               dt = ExecuteDataTable("SAESS_LISTAR_USUARIO_X_DOCUMENTO", this._strCadenaConexion);

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

        public IEUsuarioCollection ListarUsuariosPorOficina(int pintCodigoOficina,string pstrSituacion)
        {
            IEUsuarioCollection collection = new EUsuarioCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pintCodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion,1));
                
                dt = ExecuteDataTable("SAESS_LISTAR_USUARIO_X_OFICINA", this._strCadenaConexion);

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

        public int ObtenerCodigoXNombres(string pstrNombreCompleto)
        {
            try
            {
                Clear();
                           
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE_COMPLETO", pstrNombreCompleto, 100));
                Add(PrimitiveParameter.CreateOutputInt32("@PI_CODIGO_USUARIO"));
                ExecuteNonQuery("SAESS_OBTENER_CODIGO_USUARIO", this._strCadenaConexion);
                return  Convert.ToInt32(Out(1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Métodos Transaccionales
        public NullInt32 Insertar(SqlTransaction pobjTx, IEUsuario pobjUsuario)
        {
            try
            {
                Clear();
                                 
              
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE", pobjUsuario.Nombres.UINullable , 50));
                Add(PrimitiveParameter.CreateInput("@PV_APE_PATERNO", pobjUsuario.ApellidoPaterno.UINullable, 50));
                Add(PrimitiveParameter.CreateInput("@PV_APE_MATERNO", pobjUsuario.ApellidoMaterno.UINullable, 50));
                Add(PrimitiveParameter.CreateInput("@PV_USUARIO_RED", pobjUsuario.UsuarioRed.UINullable, 30));
                Add(PrimitiveParameter.CreateInput("@PV_DOMINIO", pobjUsuario.Dominio.UINullable, 30));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjUsuario.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PV_CORREO", pobjUsuario.Correo, 50));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pobjUsuario.Codigo));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjUsuario.UsuarioRegistro ));                 
           
                ExecuteNonQuery("SAESI_INSERTAR_USUARIO", pobjTx);

                return  pobjUsuario.Codigo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Int32 Actualizar(SqlTransaction pobjTx, IEUsuario pobjUsuario)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pobjUsuario.Codigo.Value));
                Add(PrimitiveParameter.CreateInput("@PV_USUARIO_RED", pobjUsuario.UsuarioRed.UINullable, 100));
                Add(PrimitiveParameter.CreateInput("@PV_DOMINIO", pobjUsuario.Dominio.UINullable, 100));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjUsuario.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PV_CORREO", pobjUsuario.Correo, 50));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjUsuario.UsuarioRegistro));

                return  ExecuteNonQuery("SAESU_ACTUALIZAR_USUARIO", pobjTx) ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      

        public void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo,Int32 pi_auditoria)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO", pi_codigo));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pi_auditoria));
                ExecuteNonQuery("SAESD_ELIMINAR_USUARIO", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Int32 InsertarPerfilUsuario(SqlTransaction pTrans, Int32 pintCodigoPerfil, Int32 pintCodigoUsuario, Int32 pintCodigoAuditoria)
          {
    
                    try{
                        Clear();     
                        Add(PrimitiveParameter.CreateInput("@pi_codigo_perfil", pintCodigoPerfil));
                        Add(PrimitiveParameter.CreateInput("@pi_codigo_usuario", pintCodigoUsuario));
                        Add(PrimitiveParameter.CreateInput("@pi_codigo_auditoria", pintCodigoAuditoria));
                        return  ExecuteNonQuery("SAESI_INSERTAR_USUARIO_PERFIL",pTrans);
                      }
                    catch(Exception ex){
                        throw ex;
                      } 
          }

        public Int32 ActualizarPerfilUsuario(SqlTransaction pTrans, Int32 pintCodigoPerfilNuevo, Int32 pintCodigoPerfilAnterior, Int32 pintCodigoUsuario, Int32 pintCodigoAuditoria, String pstrSituacion)
        {

            try
            {
                Clear();


                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERFIL_NEO", pintCodigoPerfilNuevo));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERFIL_ANT", pintCodigoPerfilAnterior));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pintCodigoUsuario));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_AUDITORIA", pintCodigoAuditoria));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion,1));

                return ExecuteNonQuery("SAESU_ACTUALIZAR_USUARIO_PERFIL", pTrans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion








    }
}
