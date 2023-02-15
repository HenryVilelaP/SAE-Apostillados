//--------------------------------------------------------------------------------
//  
//
// Archivo     : DStickerApostillador.cs
// Descripción : Lógica de negocio de StickerApostilladors.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------

using SAE.EntityLayer;
using SAE.EntityLayer.Collections;
using SAE.Nullables;
using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public interface IDStickerApostillador
    {
        void Constructor(string pstrCadenaConexion);



        IEStickerApostilladorCollection ListarStickerAsignados(EStickerApostillador objStiker);
        DataTable ListarSerie();
       
        //DataTable ObtieneCorrelativoSerie(EStickerApostillador objStiker);

        string InsertarStickerApostillador(SqlTransaction pobjTx, EStickerApostillador pobjStiker);
         void ModificarStickerApostillador(SqlTransaction pobjTx, EStickerApostillador pobjStiker);
        //void ModificarStickerApostillador_X_Apostilla(SqlTransaction pobjTx, EStickerApostillador pobjStiker);
        //void EliminarStickerApostillador(SqlTransaction pobjTx, int pintCodigo);
        //void EliminarStickerApostilladorXnumeroApostilla(SqlTransaction pobjTx, string pstrNumeroApostilla);
        //void ActualizarNombreArchivoApostilla(SqlTransaction pobjTx, string psrtNumeroApostilla, string pstrNombreArchivo, string pstrSituacion, string pstrSerie, string pstrNumeroSerie);
        void ActualizarSituacion(SqlTransaction pobjTx, Int32 pintCodigoStickerApostillador, string pstrSituacion, Int32 pintAuditoria);
    }

    public class DStickerApostillador : PrimitiveEntity, IDStickerApostillador
    {
        private string _strCadenaConexion;

        public DStickerApostillador() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No TranSAEcionales


        public IEStickerApostilladorCollection ListarStickerAsignados(EStickerApostillador objStiker)
        {

            IEStickerApostilladorCollection objStikerCollection = new EStickerApostilladorCollection();
            DataTable dt=null;
            try
            {
 
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objStiker.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objStiker.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_STICKER_APOSTILLADOR", objStiker.CodigoStikerApostillador));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", objStiker.SituacionRegistro,1));
                Add(PrimitiveParameter.CreateInput("@PC_SERIE", objStiker.Serie,50));
                dt = ExecuteDataTable("SAESS_LISTAR_ASIGNACION_STICKER", this._strCadenaConexion);

                return objStikerCollection.Fill(dt);

                
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



        public DataTable ListarSerie()
        {

            
            DataTable dt = null;
            try
            {

                Clear();
                dt = ExecuteDataTable("SAESS_LISTAR_SERIE", this._strCadenaConexion);

                return  dt ;


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

        public string InsertarStickerApostillador(SqlTransaction pobjTx, EStickerApostillador pobjStiker)
        {
            try
            {
                Clear();

 
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjStiker.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pobjStiker.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PC_SERIE", pobjStiker.Serie,50));
                Add(PrimitiveParameter.CreateInput("@PC_CORRELATIVO_INCIAL", pobjStiker.CorrelativoInicial, 50));
                Add(PrimitiveParameter.CreateInput("@PC_CORRELATIVO_FINAL", pobjStiker.CorrelativoFinal,50));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION",pobjStiker.SituacionRegistro,1 ));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA",pobjStiker.UsuarioOficinaPerfilRegistro));
              
                ExecuteNonQuery("SAESI_INSERTAR_ASIGNACION_STICKER", pobjTx);
                return Convert.ToString(Out(6));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 
        public void ModificarStickerApostillador(SqlTransaction pobjTx, EStickerApostillador pobjStiker)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_STIKER_APOSTILLADOR", pobjStiker.CodigoStikerApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjStiker.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pobjStiker.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PC_SERIE", pobjStiker.Serie,50));
                Add(PrimitiveParameter.CreateInput("@PC_CORRELATIVO_INCIAL", pobjStiker.CorrelativoInicial, 50));
                Add(PrimitiveParameter.CreateInput("@PC_CORRELATIVO_FINAL", pobjStiker.CorrelativoFinal,50));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjStiker.SituacionRegistro,1));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjStiker.UsuarioOficinaPerfilModifica));

                ExecuteNonQuery("SAESU_ACTUALIZAR_ASIGNACION_STICKER", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public void ActualizarSituacion(SqlTransaction pobjTx, Int32 pintCodigoStickerApostillador, string pstrSituacion, Int32 pintAuditoria)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_STIKER_APOSTILLADOR", pintCodigoStickerApostillador));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", pstrSituacion, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_AUDITORIA", pintAuditoria));
                ExecuteNonQuery("SAESU_ACTUALIZAR_SITUACION_ASIGNACION_STICKER", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public void ActualizarNombreArchivoApostilla(SqlTransaction pobjTx, string psrtNumeroApostilla, string pstrNombreArchivo, string pstrSituacion, string pstrSerie, string pstrNumeroSerie)
        //{
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", psrtNumeroApostilla,255));
        //        Add(PrimitiveParameter.CreateInputChar("@PV_NOMBRE_ARCHIVO", pstrNombreArchivo,255));
        //        Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", pstrSituacion, 1));
        //        Add(PrimitiveParameter.CreateInputChar("@PV_SERIE", pstrSerie, 50));
        //        Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_SERIE", pstrNumeroSerie, 250));
        //        ExecuteNonQuery("SAESU_ACTUALIZAR_NOMBRE_ARCHIVO_APOSTILLA", pobjTx);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void EliminarStickerApostillador(SqlTransaction pobjTx, int pintCodigo)
        //{
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@PI_CODIGO_STIKER_APOSTILLADOR", pintCodigo));

        //        ExecuteNonQuery("SAESD_ELIMINAR_ASIGNACION_STICKER", pobjTx);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void EliminarStickerApostilladorXnumeroApostilla(SqlTransaction pobjTx, string pstrNumeroApostilla)
        //{
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInput("@PV_NUMERO_APOSTILLA", pstrNumeroApostilla,255));

        //        ExecuteNonQuery("SAESD_ELIMINAR_StickerApostillador_X_APOSTILLA", pobjTx);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        #endregion
    }
}