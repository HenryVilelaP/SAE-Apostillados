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

    public interface IDPerfilUsuario
    {
        void Constructor(string pstrCadenaConexion);
        Int32 InsertarPerfilUsuario(SqlTransaction pTrans, IEPerfilUsuario objPerfilUsuario);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        void ActualizarSituacionRegistro(SqlTransaction pobjTx, Int32 pi_codigo, string pstr_situacion);
        IEPerfilUsuarioCollection ListarPerfilUsuario(int pintCodigoUsuario, string pstrSituacion);
        IEPerfilUsuarioCollection ListarPerfilUsuarioXModulo(int pintCodigoUsuario, string pstrSituacion, int pintCodigoModulo);
      //  IEPerfilUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario);
    }
    public class DPerfilUsuario : PrimitiveEntity,IDPerfilUsuario
    {


          private string _strCadenaConexion;
          public DPerfilUsuario() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }


        #region METODOS NO TRANSACCIONALES

        //[System.Obsolete]  
        //public IEPerfilUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario)
        //{
        //    IEPerfilUsuarioCollection collection = new EPerfilUsuarioCollection();
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", CodUsuario.Value));
        //        return collection.Fill(ExecuteDataTable("SAESS_LISTAR_PERFIL_USUARIO", this._strCadenaConexion));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
            
        //}
         public IEPerfilUsuarioCollection ListarPerfilUsuario(int pintCodigoUsuario, string pstrSituacion)
        {
            IEPerfilUsuarioCollection collection = new EPerfilUsuarioCollection();
            DataTable dt;
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pintCodigoUsuario));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_MODULO", NullInt32.Empty)); 
                dt = ExecuteDataTable("SAESS_LISTAR_PERFIL_X_USUARIO", this._strCadenaConexion);


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
         public IEPerfilUsuarioCollection ListarPerfilUsuarioXModulo(int pintCodigoUsuario, string pstrSituacion,int pintCodigoModulo)
         {
             IEPerfilUsuarioCollection collection = new EPerfilUsuarioCollection();
             DataTable dt;
             try
             {
                 Clear();

                 Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pintCodigoUsuario));
                 Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion, 1));
                 Add(PrimitiveParameter.CreateInput("@PI_CODIGO_MODULO", pintCodigoModulo));
                 dt = ExecuteDataTable("SAESS_LISTAR_PERFIL_X_USUARIO", this._strCadenaConexion);


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



    #region Metodos Transaccionales   
        
           public Int32 InsertarPerfilUsuario(SqlTransaction pTrans, IEPerfilUsuario objPerfilUsuario)
          {
    
                    try{
                        Clear();

                        Add(PrimitiveParameter.CreateOutputInt32("@PI_CODIGO_PERFIL_USU_OFI"));
                        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO_OFICINA", objPerfilUsuario.CodigoUsuarioOficina));
                        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERFIL", objPerfilUsuario.CodigoPerfil));
                        
                        ExecuteNonQuery("SAESI_INSERTAR_PERFIL_USUARIO_OFICINA",pTrans);
                        return Convert.ToInt32(Out(0));
                      }
                    catch(Exception ex){
                        throw ex;
                      } 
          }
           public void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo)
           {
               try
               {
                   Clear();

                   Add(PrimitiveParameter.CreateInput("@PI_CODIGO", pi_codigo));
                   ExecuteNonQuery("SAESD_ELIMINAR_PERFIL_USUARIO_OFICINA", pobjTx);
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           public void ActualizarSituacionRegistro(SqlTransaction pobjTx, Int32 pi_codigo, string pstr_situacion)
           {
               try
               {
                   Clear();
                   Add(PrimitiveParameter.CreateInput("@PI_CODIGO", pi_codigo));
                   Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstr_situacion,1));
                   ExecuteNonQuery("SAESU_SITUACION_PERFIL_USUA_OFI", pobjTx);
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
    #endregion


}


}
