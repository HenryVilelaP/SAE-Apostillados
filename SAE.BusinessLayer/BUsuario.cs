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
// Archivo     : BUsuario.cs
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
    public interface IBUsuario
    {
        void Constructor(string pstrStringConnection);
        IEUsuarioCollection ListarUsuarios(IEUsuario pobjUsuario,NullInt32 pintCodigoOficina);
        IEUsuario ObtenerUsuarioLoginNT(String pstrUsuarioNT, String pstrDominio, string pstrSituacion);
        IEUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario);
        //int NumeroRegistrosListarUsuario(NullInt32 CodUsuario);
        void Insertar(IEUsuario pobjUsuario, IEDocumento pobjDocumento);
        
        void Actualizar(IEUsuario pobjUsuario);
        void Eliminar(Int32 pi_codigo,Int32 pi_codigo_auditor);
        void Eliminar( IEUsuarioCollection objUsuarios);
        int ObtenerCodigoXNombres(string pstrNombreCompleto);
        IEUsuarioCollection ListarUsuariosPorOficina(int pintCodigoOficina,string pstrSituacion);
        IEUsuario ListarUsuarioPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc);

    }

    [Transaction(TransactionOption.Supported)]
    public class BUsuario : ServicedComponent, IBUsuario
    {
        private const string K_ERROR_NO_TIENE_PERFIL = "Usuario no tiene Perfil Asignados";
        private string gstrStringConnection;
        const string K_ERROR_VARIOS_USUARIOS = "Error : Se encontraron más de un registro en búsqueda de usuario";
        const string K_ERROR_USUARIO_DOMINIO = "Error : No existe usuario y dominio registrado en el SAE.";
        const string K_ERROR_ACTUALIZAR = "Error al  actualizar usuario";

        public BUsuario()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales

        //public int NumeroRegistrosListarUsuario(NullInt32 CodUsuario)
        //{
        //    try
        //    {
        //        DUsuario objDUsuario = null;
        //        objDUsuario = new DUsuario();
        //        objDUsuario.Constructor(gstrStringConnection);

        //        return objDUsuario.FNC_ObtieneNumeroRegistros(CodUsuario);

        //        //return objDUsuario.ListarUsuario(pstrCodUsuario, pstrNombre, pstrPaterno, pstrMaterno, pstrSituacion,
        //        //                       pintNumeroPagina, pintNumeroRegistros, out pintRegistrosGenerados);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public IEUsuarioCollection ListarUsuarios(IEUsuario pobjUsuario , NullInt32 pintCodigoOficina)
        {
            IDUsuario objDUsuario = null;
            try
            {
                objDUsuario = new DUsuario();
                objDUsuario.Constructor(gstrStringConnection);

                return objDUsuario.ListarUsuarios(pobjUsuario, pintCodigoOficina);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }
        public IEUsuarioCollection ListarUsuariosPorOficina(int pintCodigoOficina, string pstrSituacion)
        {
            IDUsuario objDUsuario = null;
            try
            {
                objDUsuario = new DUsuario();
                objDUsuario.Constructor(gstrStringConnection);

                return objDUsuario.ListarUsuariosPorOficina(pintCodigoOficina,pstrSituacion);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }
        public int ObtenerCodigoXNombres(string pstrNombreCompleto)
        {
            IDUsuario objDUsuario = null;

            try
            {
                objDUsuario = new DUsuario();
                objDUsuario.Constructor(this.gstrStringConnection);
                
                return objDUsuario.ObtenerCodigoXNombres(pstrNombreCompleto);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }
        public IEUsuarioCollection ListarPerfilUsuario(NullInt32 CodUsuario)
        {
            IDUsuario objDUsuario = null;
            try
            {
                objDUsuario = new DUsuario();
                objDUsuario.Constructor(gstrStringConnection);
                return objDUsuario.ListarPerfilUsuario(CodUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }

           }

        public IEUsuario ObtenerUsuarioLoginNT(String pstrUsuarioNT, String pstrDominio, string pstrSituacion)
        {
            IDUsuario objDUsuario = null;
            IEUsuario objEUsuarioFound = null;
            IEUsuarioCollection objUsuarioCollection = null;
            IEUsuario objEUsuario = null;
            try
            {
                objEUsuario = new EUsuario();
                objEUsuario.Codigo = NullInt32.Empty;
                objEUsuario.SituacionRegistro = NullString.Empty;
                objEUsuario.UsuarioRed = NullString.Create(pstrUsuarioNT);
                objEUsuario.Dominio = NullString.Create(pstrDominio);


                objDUsuario = new DUsuario();
                objDUsuario.Constructor(gstrStringConnection);
                objUsuarioCollection = objDUsuario.ListarUsuarios(objEUsuario,NullInt32.Empty );
                int intNumReg = objUsuarioCollection.Count;

                if (intNumReg > 1)
                    throw new Exception(K_ERROR_VARIOS_USUARIOS);
                if (intNumReg < 1)
                    throw new Exception(K_ERROR_USUARIO_DOMINIO);


                var objOpcion = (BOpcion)null;
                var objPerfil = (BPerfilUsuario)null;
                foreach (IEUsuario _objIEUsuario in objUsuarioCollection)
                {
                    objEUsuarioFound = _objIEUsuario;
                    objPerfil = new BPerfilUsuario();
                    objOpcion = new BOpcion();
                    objOpcion.Constructor(gstrStringConnection);
                    objPerfil.Constructor(gstrStringConnection);
 
                    IEPerfilUsuarioCollection oPerfilesUsuario=null;
                    oPerfilesUsuario=  objPerfil.ListarPerfilUsuario(objEUsuarioFound.Codigo.Value,pstrSituacion);
                    if (oPerfilesUsuario.Equals(null)) throw new Exception(K_ERROR_NO_TIENE_PERFIL);
                    objEUsuarioFound.Perfiles = oPerfilesUsuario;
                    objEUsuarioFound.Opcions = objOpcion.ListarOpcionPerfil(((EPerfilUsuario)oPerfilesUsuario.Valores[0]).CodigoPerfil, 0, ((EPerfilUsuario)oPerfilesUsuario.Valores[0]).CodigoPerfilUsuarioOfi);

                   objOpcion = null;
                   objPerfil = null;
                }

                return objEUsuarioFound;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }
        public IEUsuario ListarUsuarioPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc){

            IDUsuario objDUsuario = null;
            

           try
            {
               
                IEUsuarioCollection objUsuarios = null;
                objDUsuario = new DUsuario();
                IEUsuario objEusuario = new EUsuario();

                objDUsuario.Constructor(gstrStringConnection);
                objUsuarios = objDUsuario.ListarUsuarioPorDocumento(pintCodigoTipoDocumento, pintNumeroDoc);

                if (objUsuarios.Count > 1) throw new Exception("La consulta tiene como resultado mas de un registro, el numero de documento es único.");


                if (objUsuarios.Count == 0) objEusuario = null;   
                else  objEusuario = objUsuarios.Valores[0];

                return objEusuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }


        }
        
        public IEUsuario ObtenerUsuario(NullInt32 pintCodUsuario)
        {
            IDUsuario objDUsuario = null;
            IEUsuario objUsuario = null;

            try
            {
                objDUsuario = new DUsuario();
                objUsuario= new EUsuario();
                objUsuario.Codigo = pintCodUsuario;
                objDUsuario.Constructor(gstrStringConnection);
                objUsuario = objDUsuario.ListarUsuarios(objUsuario,NullInt32.Empty ) [pintCodUsuario.UINullable];

                return objUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }

        public IEUsuario obtenerUsuarioNombreCompleto(String pstrNombreCompleto)
            
        {
            IDUsuario objDUsuario = null;
            IEUsuario objEUsuarioFound = null;
            IEUsuarioCollection objUsuarioCollection = null;
            IEUsuario objEUsuario = null;
            try
            {
                objEUsuario = new EUsuario();
                objEUsuario.NombreCompleto = NullString.Create(pstrNombreCompleto);  

                objDUsuario = new DUsuario();
                objDUsuario.Constructor(gstrStringConnection);
                objUsuarioCollection = objDUsuario.ListarUsuarios(objEUsuario,NullInt32.Empty  );
                int intNumReg = objUsuarioCollection.Count;

                if (intNumReg > 1)
                    throw new Exception(K_ERROR_VARIOS_USUARIOS);
                if (intNumReg < 1)
                    throw new Exception(K_ERROR_USUARIO_DOMINIO);


                var objOpcion = (BOpcion)null;
                //foreach (IEUsuario _objIEUsuario in objUsuarioCollection)
                //{
                //    objOpcion = new BOpcion();
                //    objOpcion.Constructor(gstrStringConnection);
                //    objEUsuarioFound = _objIEUsuario;
                //    objEUsuarioFound.Opcions  = objOpcion.ListarOpcionPerfil(objEUsuarioFound.CodigoPerfil);
                //    objOpcion = null;
                //}

                return objEUsuarioFound;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }

        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEUsuario pobjUsuario, IEDocumento pobjDocumento)
        {
            IDUsuario objDUsuario = null;
            IDPersona objDPersona = null;
            IDDocumento objDDocumento = null;
  
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUsuario = new DUsuario();
                objDPersona = new DPersona();
                 objDDocumento = new DDocumento();
               
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
               
                pobjUsuario.Codigo = NullInt32.Create(objDPersona.Insertar(objTx.Transaction, (EPersona)pobjUsuario));
                pobjDocumento.CodigoPersona = pobjUsuario.Codigo;
                objDUsuario.Insertar(objTx.Transaction, pobjUsuario);
                objDDocumento.Insertar(objTx.Transaction, pobjDocumento);
               
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

                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;


                //if (objDDocumento != null) ((IDisposable)objDDocumento).Dispose();
                //objDDocumento = null;


                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }

        }
        public void Actualizar(IEUsuario pobjUsuario )
        {
            IDUsuario objDUsuario = null;
            IDPersona objDPersona = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUsuario = new DUsuario();
                objDPersona = new DPersona();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);

                  objDUsuario.Actualizar(objTx.Transaction, pobjUsuario);
                  pobjUsuario.SituacionRegistro = NullString.Empty; 
                  objDPersona.Actualizar(objTx.Transaction, (EPersona)pobjUsuario);
                

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

                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;

                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }
        }

        public void Eliminar(IEUsuarioCollection objUsuarios) {

            IDUsuario objDUsuario = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUsuario = new DUsuario();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);

                     foreach(IEUsuario oEUsuario in objUsuarios){
                         objDUsuario.Eliminar(objTx.Transaction, oEUsuario.Codigo.Value, oEUsuario.UsuarioModifica.Value );
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

                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }
        public void Eliminar(Int32 pi_codigo,Int32 pi_auditoria)
        {
            IDUsuario objDUsuario = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUsuario = new DUsuario();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDUsuario.Eliminar(objTx.Transaction, pi_codigo, pi_auditoria);


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

                if (objDUsuario != null) ((IDisposable)objDUsuario).Dispose();
                objDUsuario = null;
            }
        }
     
        #endregion
    }
}
