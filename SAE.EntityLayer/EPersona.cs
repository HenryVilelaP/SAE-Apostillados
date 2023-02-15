using SAE.Nullables;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SAE.EntityLayer
{
    public interface IEPersona : IEAuditoria
    {
        NullInt32 CodigoPersona { get; set; }
        NullString ApellidoPaterno { get; set; }
        NullString ApellidoMaterno { get; set; }
        NullString Nombres { get; set; }
        NullString NroDNI { get; set; }
        NullString NombreCompleto { get; set; }
        NullInt32 CodigoPaisNacimineto { get; set; }
        NullDateTime FechaNacimineto { get; set; }
        NullString Sexo { get; set; }


    }

    public class EPersona : EAuditoria, IEPersona
    {
        private NullInt32 pers_icodigo_persona;
        private NullString pers_vapepaterno_persona;
        private NullString pers_vapematerno_persona;
        private NullString pers_vnombre_persona;
        private NullString pers_vnro_documento_persona;
        private NullInt32  pais_icodigo_pais_nacimiento;
        private NullString pers_csexo_persona;
        private NullDateTime pers_sfecha_nacimiento;
        private NullString strNombreCompleto;

        public static EPersona Create(DataRow row)
        {
            EPersona oPersona = new EPersona();

            oPersona.CodigoPersona = NullInt32.Create(row, "CodigoPersona");
            oPersona.ApellidoPaterno = NullString.Create(row, "ApellidoPaterno");
            oPersona.ApellidoMaterno = NullString.Create(row, "ApellidoMaterno");
            oPersona.Nombres = NullString.Create(row, "Nombres");
            oPersona.NroDNI = NullString.Create(row, "NroDNI");
            oPersona.SituacionRegistro = NullString.Create(row, "Situacion");
            oPersona.CodigoPaisNacimineto = NullInt32.Create(row, "CodigoPaisNacimiento");
            oPersona.Sexo = NullString.Create(row, "Sexo");
            oPersona.FechaNacimineto = NullDateTime.Create(row, "FechaNacimiento");

            return oPersona;
        }



        #region IEPersona Members
        public NullString NombreCompleto
        {
            get { return this.strNombreCompleto; }
            set { this.strNombreCompleto = value; }
        }
        
        public NullInt32 CodigoPersona
        {
            get { return this.pers_icodigo_persona; }
            set { this.pers_icodigo_persona = value; }
        }

        public NullString ApellidoPaterno
        {
            get { return this.pers_vapepaterno_persona; }
            set { this.pers_vapepaterno_persona = value; }
        }

        public NullString ApellidoMaterno
        {
            get { return this.pers_vapematerno_persona; }
            set { this.pers_vapematerno_persona = value; }
        }

        public NullString Nombres
        {
            get { return this.pers_vnombre_persona; }
            set { this.pers_vnombre_persona = value; }
        }

        public NullString NroDNI
        {
            get { return this.pers_vnro_documento_persona; }
            set { this.pers_vnro_documento_persona = value; }
        }
        public NullInt32 CodigoPaisNacimineto
        {
            get { return this.pais_icodigo_pais_nacimiento; }
            set { this.pais_icodigo_pais_nacimiento = value; }
        }
        public NullDateTime FechaNacimineto
        {
            get { return this.pers_sfecha_nacimiento; }
            set { this.pers_sfecha_nacimiento = value; }
        }
        public NullString Sexo
        {
            get { return this.pers_csexo_persona; }
            set { this.pers_csexo_persona = value; }
        }

  

        #endregion
    }
}
