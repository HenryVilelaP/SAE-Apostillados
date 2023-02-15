using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using SAE.DataLayer;
using SAE.EntityLayer;
//--------------------------------------------------------------------------------
// Sistema Gestion Consular - SAE
//
// Archivo     : BPerfilUsuario.cs
// Descripción : Lógica de negocio de Usuario.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : N/A
// Fecha       : 01/04/2009
//--------------------------------------------------------------------------------
using SAE.EntityLayer.Collections;
using SAE.Nullables;

namespace SAE.BusinessLayer
{
    public interface IBPerfilUsuario
    {
        void Constructor(string pstrStringConnection);
       // IEPerfilUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario);
        IEPerfilUsuarioCollection ListarPerfilUsuario(int pintCodigoUsuario, string pstrSituacion);
        IEPerfilUsuarioCollection ListarPerfilUsuarioXModulo(int pintCodigoUsuario, string pstrSituacion, int pintCodigoModulo);
        void Eliminar(Int32 pi_codigo);
        void ActualizarSituacionRegistro(int pi_codigo, string pstr_situacion, EApostillador objEApos);
        void InsertarPerfilUsuario(int intCodigoPerfil, int pintCodigoUsuario, int pintCodigoOficina, int pintAuditoria, EDetallePerfilUsuarioCollection objOpcionesUsuario, bool pblEsApostillador);
        void ModificarPerfilUsuario(EDetallePerfilUsuarioCollection objOpcionesUsuario);

    }

    [Transaction(TransactionOption.Supported)]
    public class BPerfilUsuario : ServicedComponent, IBPerfilUsuario
    {
        private string gstrStringConnection;
      

        public BPerfilUsuario()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales

      
        //public IEPerfilUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario)
        //{
        //    IDPerfilUsuario objDPerfilUsuario = null;
             
        //    try
        //    {

        //        objDPerfilUsuario = new DPerfilUsuario();
        //        objDPerfilUsuario.Constructor(gstrStringConnection);
        //        return objDPerfilUsuario.ListarPerfilUsuario(CodUsuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objDPerfilUsuario != null) ((IDisposable)objDPerfilUsuario).Dispose();
        //        objDPerfilUsuario = null;
        //    }

        //}
        public IEPerfilUsuarioCollection ListarPerfilUsuario(int pintCodigoUsuario, string pstrSituacion)
        {
            IDPerfilUsuario objDPerfil = null;
            try
            {
                objDPerfil = new DPerfilUsuario();
                objDPerfil.Constructor(gstrStringConnection);
                return objDPerfil.ListarPerfilUsuario(pintCodigoUsuario, pstrSituacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }

        }
        public IEPerfilUsuarioCollection ListarPerfilUsuarioXModulo(int pintCodigoUsuario, string pstrSituacion,int pintCodigoModulo)
        {
            IDPerfilUsuario objDPerfil = null;
            try
            {
                objDPerfil = new DPerfilUsuario();
                objDPerfil.Constructor(gstrStringConnection);
                return objDPerfil.ListarPerfilUsuarioXModulo(pintCodigoUsuario, pstrSituacion, pintCodigoModulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }

        }
        #endregion

        #region Métodos Transaccionales
        public void InsertarPerfilUsuario(int intCodigoPerfil, int pintCodigoUsuario, int pintCodigoOficina , int pintAuditoria,EDetallePerfilUsuarioCollection objOpcionesUsuario,bool pblEsApostillador)
        {
            IDUsuarioOficina objDUsuarioOficina = null;
            IDPerfilUsuario objDPerfilUsuario = null;
            IDPerfilUsuarioDetalle objDPerfilUsuarioDeta = null;
            IDApostillador objDApos = null;

            IPrimitiveTransaction objTx = null;
            IEUsuarioOficina objUsuarioOficina = null;
            IEPerfilUsuario  objperfilUsuario = null;
            EApostillador objEApos = null;
            try
            {
                objDUsuarioOficina = new DUsuarioOficina();
                objDPerfilUsuario = new DPerfilUsuario();
                objDPerfilUsuarioDeta = new DPerfilUsuarioDetalle();
                objDApos = new DApostillador();

                objUsuarioOficina = new EUsuarioOficina();
                objperfilUsuario = new EPerfilUsuario();
                objEApos = new EApostillador();
                
                objUsuarioOficina.CodigoUsuario = NullInt32.Create(pintCodigoUsuario);
                objUsuarioOficina.CodigoOficina = NullInt32.Create(pintCodigoOficina);

                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                //insertamos en tabla usuario - oficina

                int pintCodigoUsuarioOficina = objDUsuarioOficina.Insertar(objTx.Transaction , objUsuarioOficina ).Value;

                //insertamos tabla perfil usuario oficina

                objperfilUsuario.CodigoUsuarioOficina = NullInt32.Create(pintCodigoUsuarioOficina);
                objperfilUsuario.CodigoPerfil = NullInt32.Create(intCodigoPerfil);
                int CodigoPerfilUsuarioOficina= objDPerfilUsuario.InsertarPerfilUsuario(objTx.Transaction, objperfilUsuario);

                //insertamos el detalle del perfil ,las opciones para el usuario
                foreach(EPerfilUsuarioDetalle oPerfilOpcion in objOpcionesUsuario.Valores )                
                {
                    oPerfilOpcion.CodigoPerfilUsuarioOf = CodigoPerfilUsuarioOficina;
                    objDPerfilUsuarioDeta.Insertar(objTx.Transaction, oPerfilOpcion);
                }

                // insertamos en la tabla apostillador si es de ese perfil 27 09 2010
                if (pblEsApostillador)
                {
                    objEApos.CodigoApostillador = NullInt32.Create(pintCodigoUsuario);
                    objEApos.UsuarioRegistro = NullInt32.Create(pintAuditoria);
                    objDApos.InsertarApostillador(objTx.Transaction, objEApos);
                }
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
        
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDUsuarioOficina != null) ((IDisposable)objDUsuarioOficina).Dispose();
                objDUsuarioOficina = null;

                if (objDPerfilUsuario != null) ((IDisposable)objDPerfilUsuario).Dispose();
                objDPerfilUsuario = null;
         
                objUsuarioOficina = null;
                objperfilUsuario = null;
            }
        }
        public void Eliminar(Int32 pi_codigo)
        {
            IDPerfilUsuario objDPerfilUsuario = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPerfilUsuario = new DPerfilUsuario();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDPerfilUsuario.Eliminar(objTx.Transaction, pi_codigo);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDPerfilUsuario != null) ((IDisposable)objDPerfilUsuario).Dispose();
                objDPerfilUsuario = null;
            }
        }
        public void ActualizarSituacionRegistro(Int32 pi_codigo,string pstr_situacion,EApostillador objEApos)
        {
            IDPerfilUsuario objDPerfilUsuario = null;
            IDApostillador objDApos = null;
            IPrimitiveTransaction objTx = null;
          
            try
            {
                
                objDApos = new DApostillador();
                objDPerfilUsuario = new DPerfilUsuario();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);

                objDPerfilUsuario.ActualizarSituacionRegistro(objTx.Transaction, pi_codigo, pstr_situacion);
                objDApos.ModificarSituacionApostillador(objTx.Transaction, objEApos);

                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDPerfilUsuario != null) ((IDisposable)objDPerfilUsuario).Dispose();
                objDPerfilUsuario = null;
            }
        }



        public void ModificarPerfilUsuario(EDetallePerfilUsuarioCollection objOpcionesUsuario)
        {
            IDUsuarioOficina objDUsuarioOficina = null;
            IDPerfilUsuario objDPerfilUsuario = null;
            IDPerfilUsuarioDetalle objDPerfilUsuarioDeta = null;
            IPrimitiveTransaction objTx = null;
            IEUsuarioOficina objUsuarioOficina = null;
            IEPerfilUsuario objperfilUsuario = null;
            try
            {
                objDUsuarioOficina = new DUsuarioOficina();
                objDPerfilUsuario = new DPerfilUsuario();
                objDPerfilUsuarioDeta = new DPerfilUsuarioDetalle();

                objUsuarioOficina = new EUsuarioOficina();
                objperfilUsuario = new EPerfilUsuario();

                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);

               foreach (EPerfilUsuarioDetalle oPerfilOpcion in objOpcionesUsuario.Valores)
                {
                    objDPerfilUsuarioDeta.Modificar(objTx.Transaction, oPerfilOpcion);
                }
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {

                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDUsuarioOficina != null) ((IDisposable)objDUsuarioOficina).Dispose();
                objDUsuarioOficina = null;

                if (objDPerfilUsuario != null) ((IDisposable)objDPerfilUsuario).Dispose();
                objDPerfilUsuario = null;

                objUsuarioOficina = null;
                objperfilUsuario = null;
            }
        }
        #endregion
    }
}
