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

    public interface IDPerfilUsuarioDetalle
    {
        void Constructor(string pstrCadenaConexion);
        Int32 Insertar(SqlTransaction pTrans, EPerfilUsuarioDetalle objPerfilUsuarioDetalle);
        Int32 Modificar(SqlTransaction pTrans, EPerfilUsuarioDetalle objPerfilUsuarioDetalle);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        IEDetallePerfilUsuarioCollection ListarPerfilUsuarioDetalle(int pintCodigoUsuario, string pstrSituacion);

    }
    public class DPerfilUsuarioDetalle : PrimitiveEntity,IDPerfilUsuarioDetalle
    {


          private string _strCadenaConexion;
          public DPerfilUsuarioDetalle() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }


        #region METODOS NO TRANSACCIONALES

        public IEDetallePerfilUsuarioCollection ListarPerfilUsuarioDetalle(int pintCodigoUsuario, string pstrSituacion)
        {
            IEDetallePerfilUsuarioCollection collection = new EDetallePerfilUsuarioCollection();
            DataTable dt=null;
            try
            {
                //Clear();

                //Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pintCodigoUsuario));
                //Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacion, 1));
                //Add(PrimitiveParameter.CreateInput("@PI_CODIGO_MODULO", NullInt32.Empty)); 
                //dt = ExecuteDataTable("SAESS_LISTAR_PERFIL_X_USUARIO", this._strCadenaConexion);


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
        
           public Int32 Insertar(SqlTransaction pTrans, EPerfilUsuarioDetalle objPerfilUsuarioDetalle)
          {
    
                    try{
                        Clear();     
                        Add(PrimitiveParameter.CreateInput("@PI_ID_PERFIL_USUARIO_OFICINA", objPerfilUsuarioDetalle.CodigoPerfilUsuarioOf));
                        Add(PrimitiveParameter.CreateInput("@PI_ID_OPCION", objPerfilUsuarioDetalle.CodigoOpcion));
                        Add(PrimitiveParameter.CreateInput("@PC_TIPO_OPCION", objPerfilUsuarioDetalle.TipoOpcion,1));
                        
                        return  ExecuteNonQuery("SAESI_DETALLE_PERFIL_USUARIO_OFIC",pTrans);
                      }
                    catch(Exception ex){
                        throw ex;
                      } 
          }
           public Int32 Modificar(SqlTransaction pTrans, EPerfilUsuarioDetalle objPerfilUsuarioDetalle)
           {

               try
               {
                   Clear();
                   Add(PrimitiveParameter.CreateInput("@PI_ID_PERFIL_USUARIO_OFICINA", objPerfilUsuarioDetalle.CodigoPerfilUsuarioOf));
                   Add(PrimitiveParameter.CreateInput("@PI_ID_OPCION", objPerfilUsuarioDetalle.CodigoOpcion));
                   Add(PrimitiveParameter.CreateInput("@PC_TIPO_OPCION", objPerfilUsuarioDetalle.TipoOpcion, 1));

                   return ExecuteNonQuery("SAESU_DETALLE_PERFIL_USUARIO_OFIC", pTrans);
               }
               catch (Exception ex)
               {
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
         
    #endregion


}


}
