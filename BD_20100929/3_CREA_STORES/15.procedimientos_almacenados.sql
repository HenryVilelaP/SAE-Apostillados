SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESD_ELIMINAR_ACTUACION_X_APOSTILLA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[SAESD_ELIMINAR_ACTUACION_X_APOSTILLA]
(
@PV_NUMERO_APOSTILLA VARCHAR(255)
)
AS

DELETE FROM SAET_ACTUACION WHERE actu_vnumero_apostilla=@PV_NUMERO_APOSTILLA' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_SITUACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_SITUACION]
(

@PI_CODIGO_APOSTILLA INT, 
@PC_SITUACION CHAR(1),
@PI_CODIGO_AUDITORIA INT

)AS
BEGIN
UPDATE SAET_ACTUACION SET 
							peuo_dfecha_modifica=GETDATE(),
							actu_csituacion=@PC_SITUACION,
							peuo_iperfil_usuario_oficina_modifica=@PI_CODIGO_AUDITORIA
WHERE actu_icodigo_actuacion=@PI_CODIGO_APOSTILLA


END
 
' 
 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_PERFIL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

 

create procedure [dbo].[SAESS_LISTAR_PERFIL]
AS

select
perf_icodigo_perfil CODIGOPERFIL,
perf_vnombre_perfil NOMBREPERFIL,
perf_vdescripcion_perfil DESCRIPCION,
perf_cestado SITUACION
from saet_perfil' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_MODULO_X_PERFIL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE   PROCEDURE [dbo].[SAESS_LISTAR_MODULO_X_PERFIL] 
/*********************************************************************
  PROCEDIMIENTO   : [SAESS_LISTAR_MODULO_X_PERFIL]
  PROPÓSITO       : LISTA LOS MODULOS POR PERFIL
  INPUTS/OUTPUT   : @PC_CODIGO_PERFIL	INT
  MODIFICACIONES  : N/A
  AUTOR           : DANIEL BALVIS
  FECHA Y HORA    : 21/09/2010.
**********************************************************************/

@PI_CODIGO_PERFIL	INT
AS

BEGIN

SELECT DISTINCT
	
		CODIGOMODULO	=	O.MODU_ICODIGO_MODULO, 
		NIVELMODULO		=	O.MODU_INIVEL_MODULO, 
		TITULOMODULO 	=	ISNULL(MODU_VNOMBRE_MODULO,''''), 
		RUTA      		=	ISNULL(MODU_VRUTA_PAGINA,''''), 
		DESCRIPCION		= MODU_VDESCRIPCION_MODULO, 
		CODIGOPADRE	  =	ISNULL(MODU_ICODIGO_MODULO_DEPENDIENTE,''''), 
		MODULOCRITICA	=	ISNULL(MODU_CFLAG_OPCION_CRITICA,''''), 
		SITUACION		  =	PO.PEMO_CESTADO,
		ICONO			=ISNULL(MODU_VICONO,''app.gif'')
		
	FROM   
		SAET_PERFIL P INNER JOIN SAET_PERFIL_MODULO PO ON(P.PERF_ICODIGO_PERFIL=PO.PERF_ICODIGO_PERFIL)
		 	             INNER JOIN SAET_MODULO O ON(PO.MODU_ICODIGO_MODULO=O.MODU_ICODIGO_MODULO)

	WHERE (P.PERF_ICODIGO_PERFIL = @PI_CODIGO_PERFIL) AND 
  	      O.MODU_CESTADO = ''A'' 
 
END
 
 





























' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESD_ELIMINAR_FIRMANTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SAESD_ELIMINAR_FIRMANTE]
(
 @PI_CODIGO_FIRMANTE INT
)
AS
BEGIN TRY
			DELETE FROM  SAET_FIRMANTE  WHERE firm_icodigo_firmante=@PI_CODIGO_FIRMANTE
			 
END TRY
BEGIN CATCH
				
IF ERROR_NUMBER()=547
				BEGIN
					RAISERROR(''No se puede eliminar. El registro esta relacionado con otra informacion'',16,1)
				END

END CATCH
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_USUARIO_X_DOCUMENTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




create PROCEDURE [dbo].[SAESS_LISTAR_USUARIO_X_DOCUMENTO]
(
--LISTA A UN USUARIO POR EL NUMERO Y TIPO DE DOCUMENTO
@PI_CODIGO_TIPO_DOCUMENTO INT,
@PN_NUMERO_DOCUENTO       INT
)
AS
BEGIN
SELECT
                                            CODIGO_USUARIO    =   U.USUA_ICODIGO_USUARIO,
																						NOMBRE_USUARIO    =   P.PERS_VNOMBRE_PERSONA,
																						APELLIDO_MATERNO  =   P.PERS_VAPEPATERNO_PERSONA,
																						APELLIDO_PATERNO  =   P.PERS_VAPEMATERNO_PERSONA,
																						NOMBRE_COMPLETO   =   P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA,
																						USUARIO_RED       =   U.USUA_VUSUARIO_RED_USUARIO,
																						DOMINIO_RED       =   U.USUA_VDOMINIO_USUARIO,
																						CORREO_USUARIO    =   U.USUA_VCORREO_USUARIO,
																						AUDITORIA_REGISTRO=   U.USUA_ICODIGO_PERFIL_USUARIO_CREA,
																						FECHA_REGISTRO    =   U.USUA_SFECHA_CREA,
																						AUDITORIA_MODIFICA=   U.USUA_ICODIGO_PERFIL_USUARIO_MODIFICA,
																						FECHA_MODIFICA    =   U.USUA_SFECHA_MODIFICA,
																						ESTADO_REGISTRO   =   U.USUA_CESTADO_USUARIO
													
																						
												FROM SAET_USUARIO U INNER JOIN SAET_PERSONA P ON(U.USUA_ICODIGO_USUARIO=P.pers_icodigo_persona)
												                    INNER JOIN SAET_DOCUMENTO D ON(P.pers_icodigo_persona=D.pers_icodigo_persona)
												WHERE                    
												                    ((@PI_CODIGO_TIPO_DOCUMENTO IS NULL OR @PI_CODIGO_TIPO_DOCUMENTO=0) OR (docu_icodigo_tipo_documento=@PI_CODIGO_TIPO_DOCUMENTO)) AND
												                    docu_vnumero_documento=@PN_NUMERO_DOCUENTO
												                    
END												          
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_PERSONA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




 

CREATE        PROCEDURE [dbo].[SAESI_INSERTAR_PERSONA]
(
/*********************************************************************
  PROCEDIMIENTO	: SAESI_INSERTAR_USUARIO
  PROPÓSITO	: REGISTRA UN USUARIO
  INPUTS/OUTPUT	: 	
                      @PI_CODIGO_PERSONA  INT OUT,
                      @PV_NOMBRE   			  VARCHAR(100),
                      @PV_APE_PATERNO		  VARCHAR(50),
                      @PV_APE_MATERNO		  VARCHAR(50),
                      @PI_CODIGO_PAIS			INT,
                      @PC_SITUACION			  CHAR(1),
                      @PC_SEXO  			    CHAR(1),
                      @PD_FECHA_NAC       DATETIME
  AUTOR           	: DANIEL B.
  FECHA Y HORA    : 04/07/2009
**********************************************************************/

@PI_CODIGO_PERSONA  INT OUT,
@PV_NOMBRE   			  VARCHAR(100),
@PV_APE_PATERNO		  VARCHAR(50),
@PV_APE_MATERNO		  VARCHAR(50),
@PI_CODIGO_PAIS			INT,
@PC_SITUACION			  CHAR(1),
@PC_SEXO  			    CHAR(1),
@PD_FECHA_NAC       DATETIME
)
AS 
 

--IF (EXISTS (SELECT USUA_VUSUARIO_RED_USUARIO FROM SAET_USUARIO WHERE USUA_VUSUARIO_RED_USUARIO=@PV_USUARIO_RED) )
--BEGIN
--		RAISERROR(''EL NOMBRE DEL USUARIO DE RED PARA EL LOGIN YA EXISTE.'',16,1)
--		RETURN
--END

SELECT  @PI_CODIGO_PERSONA=ISNULL(MAX(pers_icodigo_persona),0)+1 FROM SAET_PERSONA
 


                  INSERT INTO SAET_PERSONA(
			                    pers_icodigo_persona,
                          pers_vapepaterno_persona,
                          pers_vapematerno_persona,
                          pers_vnombre_persona,
                          pais_icodigo_pais_nacimiento,
                          pers_cestado_persona,
                          pers_csexo_persona,
                          pers_sfecha_nacimiento
 		                   )VALUES(
			                  @PI_CODIGO_PERSONA,
			                  @PV_APE_PATERNO,
			                  @PV_APE_MATERNO,
			                  @PV_NOMBRE,
			                  @PI_CODIGO_PAIS,
			                  @PC_SITUACION,
                        @PC_SEXO,
                        @PD_FECHA_NAC
                      )


 













' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_APOSTILLADOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






 

CREATE PROCEDURE [dbo].[SAESS_LISTAR_APOSTILLADOR]
(
@PI_CODIGO_APOSTILLADOR INT,
@PV_NOMBRE VARCHAR(100),
@PV_PATERNO VARCHAR(100),
@PV_MATERNO VARCHAR(100),
@PI_DNI INT,
@PI_CODIGO_CARGO INT,
@PC_SITUACION char(1),
@PI_ICODIGO_OFICINA INT


)
AS
 
SELECT  distinct
A.apos_icodigo_apostillador CODIGOAPOSTILLADOR,
pers_vapepaterno_persona +'' ''+ pers_vapematerno_persona+ '' ''+pers_vnombre_persona  NOMBRES,
pers_vnombre_persona NOMBRE,
pers_vapepaterno_persona PATERNO,
pers_vapematerno_persona MATERNO,
CASE UPPER(apos_csituacion) 
								WHEN ''A'' THEN ''Activo''	
								WHEN ''I'' THEN ''Inactivo''	
END									
SITUACIONDESCRIPCION,
apos_csituacion	   SITUACION,

isnull(PARAME.para_vnombre_parametro,'''') CARGO,
A.para_icodigo_cargo CODIGOCARGO,
''''DNI 



FROM
SAET_APOSTILLADOR A left JOIN SAET_PARAMETRO PARAME ON(A.para_icodigo_cargo=PARAME.para_icodigo_parametro)
					inner JOIN SAET_PERSONA P ON(P.pers_icodigo_persona=A.apos_icodigo_apostillador)
					inner JOIN SAET_USUARIO_OFICINA AO ON(AO.usua_icodigo_usuario=A.apos_icodigo_apostillador)
				 
 
WHERE 
((P.pers_vnombre_persona LIKE ''%''+@PV_NOMBRE+''%'') OR (@PV_NOMBRE IS NULL)OR (@PV_NOMBRE ='''')) AND
((P.pers_vapepaterno_persona  LIKE ''%''+@PV_PATERNO+''%'') OR (@PV_PATERNO IS NULL)   OR (@PV_PATERNO='''') )AND
((P.pers_vapematerno_persona  LIKE ''%''+@PV_MATERNO+''%'') OR (@PV_MATERNO IS NULL)  OR (@PV_MATERNO='''')) AND
((A.apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR) OR (@PI_CODIGO_APOSTILLADOR IS NULL) OR (@PI_CODIGO_APOSTILLADOR=-1) ) AND
--((A.apos_idni=@PI_DNI) OR (@PI_DNI IS NULL)) AND
((A.para_icodigo_cargo=@PI_CODIGO_CARGO) OR (@PI_DNI IS NULL)) AND
((A.apos_csituacion=@PC_SITUACION) OR( @PC_SITUACION IS NULL)OR( @PC_SITUACION='''')) AND
((AO.ofic_icodigo_oficina=@PI_ICODIGO_OFICINA) OR( @PI_ICODIGO_OFICINA IS NULL)OR( @PI_ICODIGO_OFICINA=0))  and
((AO.usof_situacion=@PC_SITUACION) OR( @PC_SITUACION IS NULL)OR ( @PC_SITUACION='''')) 

 
 
 







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_PERSONA_X_DOCUMENTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


--SAESS_LISTAR_USUARIO_X_DOCUMENTO NULL,41002550


create PROCEDURE [dbo].[SAESS_LISTAR_PERSONA_X_DOCUMENTO]
(
--LISTA A UN USUARIO POR EL NUMERO Y TIPO DE DOCUMENTO
@PI_CODIGO_TIPO_DOCUMENTO INT,
@PN_NUMERO_DOCUENTO       INT
)
AS
BEGIN
SELECT
                                            CodigoPersona         =   P.pers_icodigo_persona,
																						Nombres               =   P.PERS_VNOMBRE_PERSONA,
																						ApellidoMaterno       =   P.PERS_VAPEPATERNO_PERSONA,
																						ApellidoPaterno       =   P.PERS_VAPEMATERNO_PERSONA,
																						CodigoPaisNacimiento  =   P.pais_icodigo_pais_nacimiento,
																						FechaNacimiento       =   P.pers_sfecha_nacimiento,
																						Sexo                  =   P.pers_csexo_persona,
																						Situacion             =   ''A'',
																						NroDNI                =   null
																						
													
																						
												FROM 	SAET_PERSONA P INNER JOIN SAET_DOCUMENTO D ON(P.pers_icodigo_persona=D.pers_icodigo_persona)
												WHERE                    
												                    ((@PI_CODIGO_TIPO_DOCUMENTO IS NULL OR @PI_CODIGO_TIPO_DOCUMENTO=0) OR (docu_icodigo_tipo_documento=@PI_CODIGO_TIPO_DOCUMENTO)) AND
												                    docu_vnumero_documento=@PN_NUMERO_DOCUENTO
												                    
END				

 						          

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_PERSONA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






create PROCEDURE [dbo].[SAESU_ACTUALIZAR_PERSONA]
(
/*********************************************************************
  PROCEDIMIENTO	  : SAESU_ACTUALIZAR_PERSONA
  PROPÓSITO	      : MODIFICA   LA INFORMACION DE UNA PERSONA
  INPUTS/OUTPUT	  : 	
                          @PI_CODIGO_USUARIO  INT,
                          @PV_NOMBRE   			  VARCHAR(100),
                          @PV_APE_PATERNO		  VARCHAR(50),
                          @PV_APE_MATERNO		  VARCHAR(50),
                          @PI_CODIGO_PAIS_NAC	INT,
                          @PC_SEXO		    	  CHAR(1),	
                          @PC_SITUACION       CHAR(1),
                          @PD_FECHA_NAC       DATETIME
                      
  MODIFICACIONES  : N/A
  AUTOR           : DANIEL B.
  FECHA Y HORA    : 08/07/2008 - 11:00
**********************************************************************/

@PI_CODIGO_USUARIO  INT,
@PV_NOMBRE   			  VARCHAR(100),
@PV_APE_PATERNO		  VARCHAR(50),
@PV_APE_MATERNO		  VARCHAR(50),
@PI_CODIGO_PAIS_NAC	INT,
@PC_SEXO		    	  CHAR(1),	
@PC_SITUACION       CHAR(1),
@PD_FECHA_NAC       DATETIME

)

AS
BEGIN

 
IF (@PC_SITUACION IS NULL OR @PC_SITUACION='''')
BEGIN
  SELECT  @PC_SITUACION=pers_cestado_persona FROM SAET_PERSONA WHERE pers_icodigo_persona  = @PI_CODIGO_USUARIO;			                  
END

UPDATE  SAET_PERSONA  SET

                        pers_vapepaterno_persona      =   @PV_APE_PATERNO,
                        pers_vapematerno_persona      =   @PV_APE_MATERNO,
                        pers_vnombre_persona          =   @PV_NOMBRE,
                        pais_icodigo_pais_nacimiento  =   @PI_CODIGO_PAIS_NAC,
                        pers_csexo_persona            =   @PC_SEXO,
                        pers_sfecha_nacimiento        =   @PD_FECHA_NAC,
                        pers_cestado_persona          =   @PC_SITUACION
WHERE pers_icodigo_persona  = @PI_CODIGO_USUARIO;	              


END




 
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_ACTUACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[SAESS_LISTAR_ACTUACION]
(
@PV_NUMERO_APOSTILLA VARCHAR(255),
@PI_CODIGO_ACTUACION INT,
@PI_CODIGO_APOSTILLADOR INT,
@PI_CODIGO_FIRMANTE  INT,
@PI_CODIGO_TIPO_DOCUMENTO INT,
@PD_FECHA_APOSTILLA DATETIME,
@PV_OPERACION_BANCARIA VARCHAR(255),
@PC_SITUACION  CHAR(1),
@PI_CODIGO_OFICINA INT,
@PI_CODIGO_UBICACION INT


)
AS
BEGIN
 
			SELECT 
							A.actu_icodigo_actuacion											CODIGOACTUACION,
							A.actu_vnumero_apostilla											NUMEROAPOSTILLA,
							A.actu_dfecha_apostilla												FECHAAPOSTILLA,
							A.actu_voperacion_bancaria											OPERACIONBANCARIA,
							A.actu_vnombre_documento											NOMBREDOCUMENTO,
							A.actu_csituacion													SITUACION,
							A.para_icodigo_tipo_documento										CODIGOTIPODOCUMENTO,
							A.apos_icodigo_apostillador											CODIGOAPOSTILLADOR,
							A.firm_icodigo_firmante												CODIGOFIRMANTE,
							U.pers_vapepaterno_persona+'' ''+U.pers_vapematerno_persona+'' ''+U.pers_vnombre_persona				NOMBRESAPOSTILLADOR,
							FIRM.firm_vnombres+'' ''+FIRM.firm_vpaterno+'' ''+FIRM.firm_vmaterno	NOMBRESFIRMANTE,
							PARAME.para_vnombre_parametro										NOMBRETIPODOCUMENTO,
							CASE UPPER(A.actu_csituacion) 
								WHEN ''A'' THEN ''Activo''	
								WHEN ''I'' THEN ''Inactivo''	END									SITUACIONDESCRIPCION,
							A.actu_icodigo_actuacion_oficina									CODIGOACTUACIONOFICINA,
							ROW_NUMBER() OVER(PARTITION BY A.apos_icodigo_apostillador,A.ofic_icodigo_oficina_apostillador ORDER BY A.actu_icodigo_actuacion asc) AS			CORRELATIVO,
							O.ofic_vnombre_oficina												OFICINA,
							isnull(A.actu_vserie,'''')											SERIE,
							isnull(A.actu_vnumero_serie,'''')										NUMEROSERIE

 
			FROM 		SAET_ACTUACION A
						INNER JOIN SAET_APOSTILLADOR APOS ON(A.apos_icodigo_apostillador=APOS.apos_icodigo_apostillador)
						INNER JOIN SAET_FIRMANTE FIRM ON(A.firm_icodigo_firmante=FIRM.firm_icodigo_firmante)
						INNER JOIN SAET_PARAMETRO PARAME ON(PARAME.para_icodigo_parametro=A.para_icodigo_tipo_documento)
						INNER JOIN SAET_PERSONA U ON(U.pers_icodigo_persona=APOS.apos_icodigo_apostillador)
						INNER JOIN SAET_OFICINA O ON(A.ofic_icodigo_oficina_apostillador=O.ofic_icodigo_oficina	)
						INNER JOIN SAET_PARAMETRO PARAM ON(O.para_icodigo_ubicacion=PARAM.para_icodigo_parametro)
			WHERE 

							((A.actu_icodigo_actuacion=@PI_CODIGO_ACTUACION) OR (@PI_CODIGO_ACTUACION IS NULL)) AND
							((A.actu_vnumero_apostilla=@PV_NUMERO_APOSTILLA) OR (@PV_NUMERO_APOSTILLA IS NULL)) AND
							((A.actu_dfecha_apostilla=@PD_FECHA_APOSTILLA) OR (@PD_FECHA_APOSTILLA IS NULL)) AND
							((A.actu_voperacion_bancaria=@PV_OPERACION_BANCARIA) OR (@PV_OPERACION_BANCARIA IS NULL)) AND
							((A.actu_csituacion=@PC_SITUACION) OR (@PC_SITUACION IS NULL)OR (@PC_SITUACION='''')) AND
							((A.para_icodigo_tipo_documento=@PI_CODIGO_TIPO_DOCUMENTO) OR (@PI_CODIGO_TIPO_DOCUMENTO IS NULL)) AND
							((A.apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR) OR (@PI_CODIGO_APOSTILLADOR IS NULL) OR (@PI_CODIGO_APOSTILLADOR =0)) AND
							((A.firm_icodigo_firmante=@PI_CODIGO_FIRMANTE) OR (@PI_CODIGO_FIRMANTE IS NULL)) AND
							((A.ofic_icodigo_oficina_apostillador=@PI_CODIGO_OFICINA) OR (@PI_CODIGO_OFICINA IS NULL)OR (@PI_CODIGO_OFICINA =0)) AND
						    ((O.para_icodigo_ubicacion=@PI_CODIGO_UBICACION) OR (@PI_CODIGO_UBICACION IS NULL)OR (@PI_CODIGO_UBICACION =0))

order by A.apos_icodigo_apostillador, A.actu_icodigo_actuacion asc
END
 
 








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_PERFIL_X_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[SAESS_LISTAR_PERFIL_X_USUARIO]
(
@PI_CODIGO_USUARIO  int, 
@PC_SITUACION       varchar(1),
@PI_CODIGO_MODULO   INT
)
AS
SELECT     PERSON.pers_vnombre_persona + '' '' + PERSON.pers_vapepaterno_persona  + '' ''+ PERSON.pers_vapematerno_persona AS NOMBRE_COMPLETO, 
           U.usua_icodigo_usuario     AS  CODIGO_USUARIO, 
           O.ofic_vnombre_oficina     AS  NOMBRE_OFICINA, 
           O.ofic_icodigo_oficina     AS  CODIGO_OFICINA, 
           P.perf_vnombre_perfil      AS  NOMBRE_PERFIL, 
           P.perf_icodigo_perfil      AS  CODIGO_PERFIL, 
           P.unid_icodigo_unidad      AS  CODIGO_UNIDAD,
		       PUO.peuo_csituacion	      AS  SITUACION,
		       NOMBRE_UNIDAD     			    =   ''-'',---UNID_VNOMBRE_UNIDAD,
           NOMBRE_UBICACION 			    =   PARAM.PARA_VNOMBRE_PARAMETRO,
           CODIGO_UBICACION  			    =   O.PARA_ICODIGO_UBICACION,
		       CODIGO_PERFIL_USUARIO_OFIC =   PUO.peuo_codigo_perfil_usuario,
		       MODULO                     =   M.modu_vnombre,
		       CODIGO_MODULO              =   M.modu_icodigo_modulo
					 
					 
FROM         dbo.SAET_USUARIO U INNER JOIN  SAET_USUARIO_OFICINA UO ON (U.usua_icodigo_usuario = UO.usua_icodigo_usuario )
											INNER JOIN  SAET_PERFIL_USUARIO_OFICINA PUO ON (UO.usof_icodigo_usuario_oficina= PUO.usof_icodigo_usuario_oficina)
											INNER JOIN  SAET_OFICINA O ON (UO.ofic_icodigo_oficina =  O.ofic_icodigo_oficina)
											INNER JOIN  SAET_PERFIL  P ON (PUO.perf_icodigo_perfil= P.perf_icodigo_perfil)
											--INNER JOIN  SAET_UNIDAD UN         ON    (UN.UNID_ICODIGO_UNIDAD=P.UNID_ICODIGO_UNIDAD)
                      INNER JOIN  SAET_PARAMETRO PARAM   ON    (O.PARA_ICODIGO_UBICACION=PARAM.PARA_ICODIGO_PARAMETRO)
                      INNER JOIN  SAET_PERSONA PERSON    ON    (PERSON.pers_icodigo_persona=U.usua_icodigo_usuario )
                      INNER JOIN  SAET_MODULO M ON(M.modu_icodigo_modulo=P.modu_icodigo_modulo)
WHERE
        U.usua_icodigo_usuario=@PI_CODIGO_USUARIO AND
			  ((@PC_SITUACION IS NULL OR @PC_SITUACION='''') OR (PUO.peuo_csituacion=@PC_SITUACION)) AND
			  ((@PI_CODIGO_MODULO IS NULL OR @PI_CODIGO_MODULO='''') OR (P.modu_icodigo_modulo=@PI_CODIGO_MODULO))
			  
			  
			ORDER BY 13,10,3,9,5 ASC
			  

 




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_OBTENER_CODIGO_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
 


create PROCEDURE [dbo].[SAESS_OBTENER_CODIGO_USUARIO]
(
--AUTOR         : DANIEL BALVIS
--FECHA         : 23/09/20010
--PROPOSITO     : OBTIENE EL CODIGO DE UN USARIO POR EL OMBRE COMPLETO
--PARAMETRO     :       @PV_NOMBRE_COMPLETO  
--                      @PI_ESTADO_REGISTRO
--RETORNO       : N/A
--NOTA          : N/A
--MODIFICACION  : N/A
--FEC MODIFICA  : N/A


@PV_NOMBRE_COMPLETO VARCHAR(100),
@PI_CODIGO_USUARIO  INT OUTPUT

)

AS
BEGIN
 


IF (SELECT SUM(1)  FROM SAET_PERSONA P WHERE P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA=@PV_NOMBRE_COMPLETO)>1
BEGIN
      RAISERROR(''existe más de un usuario con el mismo nombres y apellidos.'',16,1)
      RETURN 

END
IF (SELECT SUM(1)  FROM SAET_PERSONA P WHERE P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA=@PV_NOMBRE_COMPLETO) is null
BEGIN
      RAISERROR(''No existe usuario con los datos ingresados'',16,1)
      RETURN 

END

                  SELECT @PI_CODIGO_USUARIO  = (select   P.PERS_ICODIGO_PERSONA FROM SAET_PERSONA P                       
                  WHERE   (@PV_NOMBRE_COMPLETO=P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA))

 RETURN
END                        
  



 









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_UNIDAD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'







create   PROCEDURE [dbo].[SAESS_LISTAR_UNIDAD]
(
/*
NOMBRE 		      :	SAESS_LISTAR_PAIS
DESCRIPCIÓN	    :	LISTA UNIDADES PARA PERFILES
FECHA		        :	20/04/2009
PARAMETROS I/O	: 	@PV_CODIGO INT,
			              @PV_DESCRIPCION VARCHAR(80),
			              @PC_ESTADO CHAR(1)
AUTOR       		:	DANIEL B.
*/
@PI_CODIGO_UNIDAD     INT,
@PV_NOMBRE_UNIDAD     VARCHAR(100),
@PC_ESTADO            CHAR(1),
@PI_CODIGO_PARAMETRO  INT
)
AS
SELECT 
	CODIGO_UNIDAD	              =	U.UNID_ICODIGO_UNIDAD,
	NOMBRE_UNIDAD	              =	U.UNID_VNOMBRE_UNIDAD,
	ABREVIATURA		              =	U.UNID_VABREVIATURA,
	SITUACION 	                =	U.UNID_CESTADO,
	CODIGO_PARAM_UBICACION	    =	P.PARA_ICODIGO_PARAMETRO

 FROM SAET_UNIDAD U INNER JOIN SAET_PARAMETRO P
	ON(U.PARA_ICODIGO_UBICACION=P.PARA_ICODIGO_PARAMETRO)
 WHERE
	((@PI_CODIGO_UNIDAD=0) OR  (@PI_CODIGO_UNIDAD IS NULL) OR (U.UNID_ICODIGO_UNIDAD=@PI_CODIGO_UNIDAD))AND
	((@PV_NOMBRE_UNIDAD='''') OR (@PV_NOMBRE_UNIDAD IS NULL)  OR (U.UNID_VNOMBRE_UNIDAD LIKE ''%''+@PV_NOMBRE_UNIDAD+''%''))AND 
	((@PC_ESTADO='''') OR (@PC_ESTADO IS NULL) OR (U.UNID_CESTADO=@PC_ESTADO ))AND
	((@PI_CODIGO_PARAMETRO=0) OR (@PI_CODIGO_PARAMETRO IS NULL)  OR (P.PARA_ICODIGO_PARAMETRO=@PI_CODIGO_PARAMETRO))








' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_FIRMANTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SAESS_LISTAR_FIRMANTE]
(
@PI_CODIGO_FIRMANTE INT,
@PV_NOMBRE VARCHAR(100),
@PV_PATERNO VARCHAR(100),
@PV_MATERNO VARCHAR(100),
@PI_DNI INT,
@PI_CODIGO_CARGO INT,
@PI_CODIGO_ENTIDAD INT


)
AS
SELECT 
firm_icodigo_firmante CODIGOFIRMANTE,
ltrim(rtrim(firm_vnombres  + '' ''+ firm_vpaterno  +'' ''+  firm_vmaterno)) NOMBRES,
firm_vnombres NOMBRE,
firm_vpaterno PATERNO,
firm_vmaterno MATERNO,
firm_idni DNI,
PARAME.para_vnombre_parametro CARGO,
A.para_icodigo_cargo CODIGOCARGO,
ISNULL(PARAME_B.para_vnombre_parametro,'''') ENTIDAD,
ISNULL(A.para_icodigo_entidad ,0)CODIGOENTIDAD



FROM
SAET_FIRMANTE A 
INNER JOIN SAET_PARAMETRO PARAME ON(A.para_icodigo_cargo=PARAME.para_icodigo_parametro)
LEFT JOIN SAET_PARAMETRO PARAME_B ON(A.para_icodigo_entidad=PARAME_B.para_icodigo_parametro)
WHERE 
((A.firm_vnombres LIKE ''%''+@PV_NOMBRE+''%'') OR (@PV_NOMBRE IS NULL)OR (@PV_NOMBRE ='''')) AND
((A.firm_vpaterno  LIKE ''%''+@PV_PATERNO+''%'') OR (@PV_PATERNO IS NULL)   OR (@PV_PATERNO='''') )AND
((A.firm_vmaterno  LIKE ''%''+@PV_MATERNO+''%'') OR (@PV_MATERNO IS NULL)  OR (@PV_MATERNO='''')) AND
((A.firm_icodigo_firmante=@PI_CODIGO_FIRMANTE) OR (@PI_CODIGO_FIRMANTE IS NULL)) AND
((A.firm_idni=@PI_DNI) OR (@PI_DNI IS NULL)) AND
((A.para_icodigo_cargo=@PI_CODIGO_CARGO) OR (@PI_CODIGO_CARGO IS NULL)) AND
((A.para_icodigo_entidad=@PI_CODIGO_ENTIDAD) OR (@PI_CODIGO_ENTIDAD IS NULL))  

 



 ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_PARAMETRO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/****** Objeto:  StoredProcedure [dbo].[SCF_INSERTAR_PARAMETRO]    Fecha de la secuencia de comandos: 09/02/2008 10:29:28 ******/
CREATE PROCEDURE [dbo].[SAESI_INSERTAR_PARAMETRO]
@pi_codigo_tabla	int,
@pv_nombre_parametro	varchar(100),
@pi_valor_numerico	numeric(8,2),
@pv_valor_texto		varchar(250),
@pc_flag_modificar	char(1),
@pc_flag_eliminar	char(1)


AS

DECLARE @pi_longitud int
DECLARE @pv_error varchar(100)
DECLARE @pi_codigo_registro int
DECLARE @pi_codigo_parametro	int

IF EXISTS(SELECT 1 FROM SAET_PARAMETRO WHERE para_icodigo_tabla = @pi_codigo_tabla AND rtrim(ltrim(para_vnombre_parametro)) = rtrim(ltrim(@pv_nombre_parametro)) )
BEGIN
	SET @pv_error = ''Ya existe un Parametro con el mismo nombre!''
	RAISERROR (@pv_error,16, 1)	
	RETURN
END


SELECT @pi_codigo_parametro = (ISNULL(MAX(para_icodigo_parametro),0)+1) FROM SAET_PARAMETRO

SELECT @pi_codigo_registro = (ISNULL(MAX(para_icodigo_registro),0)+1) FROM SAET_PARAMETRO WHERE para_icodigo_tabla = @pi_codigo_tabla

  
INSERT INTO SAET_PARAMETRO(
			para_icodigo_parametro,
			para_icodigo_tabla,
			para_icodigo_registro, 
			para_vnombre_parametro,
			para_dvalor_numerico, 
			para_vvalor_texto,  
			para_cflag_modificar, 
			para_cflag_eliminar, 
			para_sfecha_crea 
			)
		VALUES(
			@pi_codigo_parametro,
			@pi_codigo_tabla,
			@pi_codigo_registro,
			@pv_nombre_parametro,
			@pi_valor_numerico,
			@pv_valor_texto,
			@pc_flag_modificar,
			@pc_flag_eliminar,
			GETDATE()
		)

SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_PARAMETRO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/****** Objeto:  StoredProcedure [dbo].[SCF_ACTUALIZAR_PARAMETRO]    Fecha de la secuencia de comandos: 09/02/2008 10:29:28 ******/
CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_PARAMETRO]
@pi_codigo_tabla	int,
@pi_codigo_parametro	int,
@pv_nombre_parametro	varchar(200),
@pi_valor_numerico	numeric(8,2),
@pv_valor_texto		varchar(200)


AS

SET NOCOUNT ON

DECLARE @pi_longitud int
DECLARE @pv_error varchar(100)

IF EXISTS(SELECT 1 FROM SAET_PARAMETRO WHERE  para_icodigo_parametro <> @pi_codigo_parametro AND rtrim(ltrim(para_vnombre_parametro)) = rtrim(ltrim(@pv_nombre_parametro)) AND para_icodigo_tabla=@pi_codigo_tabla )
BEGIN
	SET @pv_error = ''Ya existe un Parametro con el mismo nombre!''
	RAISERROR (@pv_error,16, 1)	
	RETURN
END 
 

		UPDATE SAET_PARAMETRO
		SET 	
			para_vnombre_parametro = @pv_nombre_parametro,
			para_dvalor_numerico = @pi_valor_numerico, 
			para_vvalor_texto = LTRIM(RTRIM(UPPER(@pv_valor_texto))) 
			
		WHERE  
		    para_icodigo_parametro = @pi_codigo_parametro
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESD_PARAMETRO_ELIMINAR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SAESD_PARAMETRO_ELIMINAR]
(
 @pi_codtabla INT
)
AS



BEGIN TRY
			DELETE FROM SAET_PARAMETRO WHERE para_icodigo_parametro =@pi_codtabla
			 
END TRY
BEGIN CATCH
				
IF ERROR_NUMBER()=547
				BEGIN
					RAISERROR(''No se puede eliminar. El registro esta relacionado con otra informacion'',16,1)
				END

END CATCH
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_PARAMETRO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE           PROCEDURE [dbo].[SAESS_LISTAR_PARAMETRO]    
/*********************************************************************     
PROCEDIMIENTO 	: [SAESS_LISTAR_PARAMETRO]    
PROPÓSITO 	    : LISTAR LOS PARAMETROS DEL SISTEMA  
		              EL VALOR  -1 SE ASUME QUE ES TODOS.  
 
INPUTS/OUTPUT 	: 	@PI_CODIGO_TABLA	CHAR(4)    
			              @PI_CODIGO_PARAMETRO	CHAR(4)    
			              @PC_SITUACION		CHAR(1)
     
SE ASUME 	      : N/A     
RETORNO         : N/A
AUTOR 		      : DANIEL B.
FECHA Y HORA	  : 20/08/2010   
**********************************************************************/    
@PI_CODIGO_TABLA	INT,
@PI_CODIGO_REGISTRO	INT,
@PI_CODIGO_PARAMETRO	INT,
@PC_SITUACION		CHAR(1)
AS    
    
 
IF ((@PI_CODIGO_PARAMETRO = -1  OR @PI_CODIGO_PARAMETRO IS NULL) AND 
    (@PI_CODIGO_TABLA <> -1     OR @PI_CODIGO_TABLA IS NULL)  AND
    (@PI_CODIGO_REGISTRO = -1   OR @PI_CODIGO_REGISTRO IS NULL
   ))
BEGIN       
	SELECT  
		PARA_ICODIGO_TABLA     CODIGOTABLA,
		PARA_ICODIGO_REGISTRO  CODIGOREGISTRO,
		PARA_ICODIGO_PARAMETRO CODIGOPARAMETRO,
		PARA_VNOMBRE_PARAMETRO NOMBREPARAMETRO,
		PARA_DVALOR_NUMERICO   VALORNUMERICO,
		PARA_VVALOR_TEXTO      VALORTEXTO,
		PARA_CFLAG_MODIFICAR   FLAGMODIFICAR,
		PARA_CFLAG_ELIMINAR    FLAGELIMINAR,
		PARA_CESTADO 	       ESTADO
	FROM	SAET_PARAMETRO     
	WHERE	PARA_ICODIGO_TABLA = @PI_CODIGO_TABLA     
	AND	PARA_ICODIGO_REGISTRO <> ''0''    
	AND	(@PC_SITUACION = '''' OR PARA_CESTADO = @PC_SITUACION OR @PC_SITUACION IS NULL)	
	ORDER BY PARA_CESTADO, PARA_ICODIGO_REGISTRO ASC     
END    
    

---IF (@PI_CODIGO_PARAMETRO <> -1 AND @PI_CODIGO_TABLA <> -1 AND @PI_CODIGO_REGISTRO = -1)

IF ((@PI_CODIGO_PARAMETRO <> -1  OR @PI_CODIGO_PARAMETRO IS NULL) AND 
    (@PI_CODIGO_TABLA <> -1     OR @PI_CODIGO_TABLA IS NULL)  AND
    (@PI_CODIGO_REGISTRO = -1   OR @PI_CODIGO_REGISTRO IS NULL
   ))
BEGIN    
	SELECT  
		PARA_ICODIGO_TABLA     CODIGOTABLA,
		PARA_ICODIGO_REGISTRO  CODIGOREGISTRO,
		PARA_ICODIGO_PARAMETRO CODIGOPARAMETRO,
		PARA_VNOMBRE_PARAMETRO NOMBREPARAMETRO,
		PARA_DVALOR_NUMERICO   VALORNUMERICO,
		PARA_VVALOR_TEXTO      VALORTEXTO,
		PARA_CFLAG_MODIFICAR   FLAGMODIFICAR,
		PARA_CFLAG_ELIMINAR    FLAGELIMINAR,
		PARA_CESTADO 	       ESTADO
	FROM	SAET_PARAMETRO     
	WHERE	PARA_ICODIGO_TABLA = @PI_CODIGO_TABLA     
	AND	PARA_ICODIGO_PARAMETRO = @PI_CODIGO_PARAMETRO    
	AND	(@PC_SITUACION = '''' OR PARA_CESTADO = @PC_SITUACION OR @PC_SITUACION IS NULL)
	ORDER	BY PARA_ICODIGO_REGISTRO DESC 
END    

---IF (@PI_CODIGO_PARAMETRO = -1 AND @PI_CODIGO_TABLA = -1 AND @PI_CODIGO_REGISTRO =-1)
IF ((@PI_CODIGO_PARAMETRO = -1  OR @PI_CODIGO_PARAMETRO IS NULL) AND 
    (@PI_CODIGO_TABLA = -1     OR @PI_CODIGO_TABLA IS NULL)  AND
    (@PI_CODIGO_REGISTRO = -1   OR @PI_CODIGO_REGISTRO IS NULL
   ))
BEGIN    
	SELECT	
		PARA_ICODIGO_TABLA     CODIGOTABLA,
		PARA_ICODIGO_REGISTRO  CODIGOREGISTRO,
		PARA_ICODIGO_PARAMETRO CODIGOPARAMETRO,
		PARA_VNOMBRE_PARAMETRO NOMBREPARAMETRO,
		PARA_DVALOR_NUMERICO   VALORNUMERICO,
		PARA_VVALOR_TEXTO      VALORTEXTO,
		PARA_CFLAG_MODIFICAR   FLAGMODIFICAR,
		PARA_CFLAG_ELIMINAR    FLAGELIMINAR,
		PARA_CESTADO 	       ESTADO
	FROM	SAET_PARAMETRO    
	WHERE	PARA_ICODIGO_REGISTRO = ''0''
	AND	(@PC_SITUACION = '''' OR PARA_CESTADO = @PC_SITUACION OR @PC_SITUACION IS NULL)
	ORDER	BY PARA_ICODIGO_TABLA DESC   
END  

---IF (@PI_CODIGO_PARAMETRO = -1 AND @PI_CODIGO_TABLA <>-1  AND @PI_CODIGO_REGISTRO <>-1)
IF ((@PI_CODIGO_PARAMETRO = -1  OR @PI_CODIGO_PARAMETRO IS NULL) AND 
    (@PI_CODIGO_TABLA <> -1     OR @PI_CODIGO_TABLA IS NULL)  AND
    (@PI_CODIGO_REGISTRO  <>-1  OR @PI_CODIGO_REGISTRO IS NULL
   ))
BEGIN
	SELECT	
		PARA_ICODIGO_TABLA     CODIGOTABLA,
		PARA_ICODIGO_REGISTRO  CODIGOREGISTRO,
		PARA_ICODIGO_PARAMETRO CODIGOPARAMETRO,
		PARA_VNOMBRE_PARAMETRO NOMBREPARAMETRO,
		PARA_DVALOR_NUMERICO   VALORNUMERICO,
		PARA_VVALOR_TEXTO      VALORTEXTO,
		PARA_CFLAG_MODIFICAR   FLAGMODIFICAR,
		PARA_CFLAG_ELIMINAR    FLAGELIMINAR,
		PARA_CESTADO 	       ESTADO
	FROM	SAET_PARAMETRO    
	WHERE	PARA_ICODIGO_REGISTRO = @PI_CODIGO_REGISTRO
		AND PARA_ICODIGO_TABLA = @PI_CODIGO_TABLA
		AND (@PC_SITUACION = '''' OR PARA_CESTADO = @PC_SITUACION OR @PC_SITUACION IS NULL)
	ORDER	BY PARA_ICODIGO_REGISTRO DESC   
END     
--DEVUELVE EL REGISTRPO DE UN PARAMETRO
---IF (@PI_CODIGO_PARAMETRO <> -1 AND @PI_CODIGO_TABLA =-1 AND @PI_CODIGO_REGISTRO = -1)
IF ((@PI_CODIGO_PARAMETRO <> -1  OR @PI_CODIGO_PARAMETRO IS NULL) AND 
    (@PI_CODIGO_TABLA = -1     OR @PI_CODIGO_TABLA IS NULL)  AND
    (@PI_CODIGO_REGISTRO = -1   OR @PI_CODIGO_REGISTRO IS NULL
   ))
BEGIN    
	SELECT  
		PARA_ICODIGO_TABLA     CODIGOTABLA,
		PARA_ICODIGO_REGISTRO  CODIGOREGISTRO,
		PARA_ICODIGO_PARAMETRO CODIGOPARAMETRO,
		PARA_VNOMBRE_PARAMETRO NOMBREPARAMETRO,
		PARA_DVALOR_NUMERICO   VALORNUMERICO,
		PARA_VVALOR_TEXTO      VALORTEXTO,
		PARA_CFLAG_MODIFICAR   FLAGMODIFICAR,
		PARA_CFLAG_ELIMINAR    FLAGELIMINAR,
		PARA_CESTADO 	       ESTADO
	FROM	SAET_PARAMETRO     
	WHERE	1=1 --PARA_ICODIGO_TABLA = @PI_CODIGO_TABLA     
	AND	PARA_ICODIGO_PARAMETRO = @PI_CODIGO_PARAMETRO    
	AND	(@PC_SITUACION = '''' OR PARA_CESTADO = @PC_SITUACION OR @PC_SITUACION IS NULL)
	ORDER	BY PARA_ICODIGO_REGISTRO DESC 
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_OPCION_X_PERFIL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[SAESS_LISTAR_OPCION_X_PERFIL] 
/*********************************************************************
  PROCEDIMIENTO   : SAESS_LISTAR_MODULO_X_PERFIL
  PROPÓSITO       : LISTA LOS MODULOS POR PERFIL
  INPUTS/OUTPUT   : @PC_CODIGO_PERFIL	INT
  MODIFICACIONES  : N/A
  AUTOR           : DANIEL BALVIS
  FECHA Y HORA    : 21/03/2010.
**********************************************************************/

@PI_CODIGO_PERFIL	INT,
@PI_CODIGO_MODULO INT,
@PI_COD_PERFIL_USUARIO_OF INT

AS

BEGIN

SELECT DISTINCT
	
		CODIGOOPCION	=	O.OPCI_ICODIGO_OPCION, 
		NIVELOPCION		=	O.OPCI_INIVEL_OPCION, 
		TITULOOPCION 	=	ISNULL(OPCI_VNOMBRE_OPCION,''''), 
		RUTA      		=	ISNULL(OPCI_VRUTA_PAGINA,''''), 
		DESCRIPCION		=	OPCI_VDESCRIPCION_OPCION, 
		CODIGOPADRE		=	ISNULL(OPCI_ICODIGO_OPCION_DEPENDIENTE,''''), 
		OPCIONCRITICA	=	ISNULL(OPCI_CFLAG_OPCION_CRITICA,''''), 
		SITUACION		=	PO.PEMO_CESTADO,
		TIPO_ACCESO		=	ISNULL(PUOD.PEUO_CTIPO_ACCESO,''N'')

		
	FROM   
		SAET_PERFIL P INNER JOIN SAET_PERFIL_OPCION PO ON(P.PERF_ICODIGO_PERFIL=PO.PERF_ICODIGO_PERFIL)
		 	          INNER JOIN SAET_OPCION O ON(PO.OPCI_ICODIGO_OPCION=O.OPCI_ICODIGO_OPCION)
					  LEFT JOIN SAET_PERFIL_USUARIO_OFICINA_DETALLE PUOD ON(PUOD.OPCI_ICODIGO_OPCION=O.OPCI_ICODIGO_OPCION and PUOD.PEUO_ICODIGO_PERFIL_USUARIO=@PI_COD_PERFIL_USUARIO_OF)

	WHERE (P.PERF_ICODIGO_PERFIL = @PI_CODIGO_PERFIL) AND 
	      (P.MODU_ICODIGO_MODULO=@PI_CODIGO_MODULO) AND
	      O.OPCI_CESTADO = ''A'' 


 
END

 

































' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_DETALLE_PERFIL_USUARIO_OFIC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create  procedure [dbo].[SAESI_DETALLE_PERFIL_USUARIO_OFIC]
(
@PI_ID_PERFIL_USUARIO_OFICINA INT,
@PI_ID_OPCION                 INT,
@PC_TIPO_OPCION               CHAR(1)
)
AS
BEGIN
INSERT INTO SAET_PERFIL_USUARIO_OFICINA_DETALLE(
                                                peuo_icodigo_perfil_usuario,
                                                opci_icodigo_opcion,
                                                peuo_ctipo_acceso
                                                )
                                          VALUES(
                                                @PI_ID_PERFIL_USUARIO_OFICINA,
                                                @PI_ID_OPCION,
                                                @PC_TIPO_OPCION
                                               )
END 
 
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_DETALLE_PERFIL_USUARIO_OFIC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





create procedure [dbo].[SAESU_DETALLE_PERFIL_USUARIO_OFIC]
(
@PI_ID_PERFIL_USUARIO_OFICINA INT,
@PI_ID_OPCION                 INT,
@PC_TIPO_OPCION               CHAR(1)
)
AS
BEGIN


IF( SELECT isnull(SUM(1),0) FROM SAET_PERFIL_USUARIO_OFICINA_DETALLE
                        WHERE
                            peuo_icodigo_perfil_usuario=@PI_ID_PERFIL_USUARIO_OFICINA AND
                            opci_icodigo_opcion=@PI_ID_OPCION )=0
            BEGIN                            

              INSERT INTO SAET_PERFIL_USUARIO_OFICINA_DETALLE(
                                                              peuo_icodigo_perfil_usuario,
                                                              opci_icodigo_opcion,
                                                              peuo_ctipo_acceso
                                                              )
                                                        VALUES(
                                                              @PI_ID_PERFIL_USUARIO_OFICINA,
                                                              @PI_ID_OPCION,
                                                              @PC_TIPO_OPCION
                                                             )
                                                             
              END
ELSE
              BEGIN   
                                                          
              UPDATE SAET_PERFIL_USUARIO_OFICINA_DETALLE SET
                                                              
                                                              peuo_ctipo_acceso=@PC_TIPO_OPCION

                                                        WHERE
                                                              peuo_icodigo_perfil_usuario=@PI_ID_PERFIL_USUARIO_OFICINA AND
                                                              opci_icodigo_opcion=@PI_ID_OPCION
                                                              
                                                              
                                                             
              END 
END
 






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_SITUACION_PERFIL_USUA_OFI]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE procedure [dbo].[SAESU_SITUACION_PERFIL_USUA_OFI]
(
/*
ACTUALIZA LA SITUACION DE REGISTRO DE LA TABLA 
PERFIL USUARIO OFICINA

*/
@PI_CODIGO    INT,
@PC_SITUACION CHAR(1)
)
AS
BEGIN

DECLARE @PI_CODIGO_PERFIL_USU_OFI INT
DECLARE @PI_CODIGO_USUARIO_OFICINA INT
DECLARE	@PI_CODIGO_PERFIL	INT

SET @PI_CODIGO_PERFIL_USU_OFI	=	@PI_CODIGO
SET @PI_CODIGO_USUARIO_OFICINA	=	(SELECT usof_icodigo_usuario_oficina FROM SAET_PERFIL_USUARIO_OFICINA WHERE peuo_codigo_perfil_usuario=@PI_CODIGO_PERFIL_USU_OFI)
SET @PI_CODIGO_PERFIL			=	(SELECT perf_icodigo_perfil FROM SAET_PERFIL_USUARIO_OFICINA WHERE peuo_codigo_perfil_usuario=@PI_CODIGO_PERFIL_USU_OFI)


IF(@PC_SITUACION=''A'')
BEGIN
					IF EXISTS(
							   SELECT PERF_ICODIGO_PERFIL FROM SAET_PERFIL_USUARIO_OFICINA 
							   WHERE USOF_ICODIGO_USUARIO_OFICINA 
							   IN
							   (
								 SELECT USOF_ICODIGO_USUARIO_OFICINA FROM SAET_USUARIO_OFICINA
								 WHERE USUA_ICODIGO_USUARIO=(SELECT USUA_ICODIGO_USUARIO FROM SAET_USUARIO_OFICINA WHERE  USOF_ICODIGO_USUARIO_OFICINA=@PI_CODIGO_USUARIO_OFICINA)
							   )
							   AND PERF_ICODIGO_PERFIL=@PI_CODIGO_PERFIL
							   AND PEUO_CSITUACION=''A''
					 )
					 BEGIN
					 RAISERROR(''Ya existe un perfil asignado y habilitado para el usuario. Si desea continuar primero deshabilite en perfil activo.'',16,1);
					 END
					
END

				--si es situación A y pasó la Validación Actualiza la información ó
				--sino es situacion A actualiza la información
				UPDATE SAET_PERFIL_USUARIO_OFICINA SET peuo_csituacion=@PC_SITUACION WHERE peuo_codigo_perfil_usuario=@PI_CODIGO 
				UPDATE SAET_USUARIO_OFICINA SET usof_situacion=@PC_SITUACION WHERE usof_icodigo_usuario_oficina=@PI_CODIGO_USUARIO_OFICINA

END




 
 


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_PERFIL_USUARIO_OFICINA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



create PROCEDURE [dbo].[SAESI_INSERTAR_PERFIL_USUARIO_OFICINA]
(
@PI_CODIGO_PERFIL_USU_OFI         INT OUTPUT, 
@PI_CODIGO_USUARIO_OFICINA	      INT,
@PI_CODIGO_PERFIL	                INT
)AS
BEGIN TRY
 
DECLARE @PI_CODIGO_GENERADO INT

IF(EXISTS(SELECT 1 FROM SAET_PERFIL_USUARIO_OFICINA WHERE usof_icodigo_usuario_oficina=@PI_CODIGO_USUARIO_OFICINA AND perf_icodigo_perfil=@PI_CODIGO_PERFIL ))
BEGIN

 RAISERROR(''Usuario ya tiene asignado el  perfil que desea registrar.'',16,1);

END

--validacion que el perfil que se quiere registrar para el usuario,
--estee activo solo uno y no existan dos perfiles iguales activos para direferentes oficinas

IF EXISTS(
           SELECT PERF_ICODIGO_PERFIL FROM SAET_PERFIL_USUARIO_OFICINA 
           WHERE USOF_ICODIGO_USUARIO_OFICINA 
           IN
           (
             SELECT USOF_ICODIGO_USUARIO_OFICINA FROM SAET_USUARIO_OFICINA
             WHERE USUA_ICODIGO_USUARIO=(SELECT USUA_ICODIGO_USUARIO FROM SAET_USUARIO_OFICINA WHERE  USOF_ICODIGO_USUARIO_OFICINA=@PI_CODIGO_USUARIO_OFICINA)
           )
           AND PERF_ICODIGO_PERFIL=@PI_CODIGO_PERFIL
           AND PEUO_CSITUACION=''A''
 )
 BEGIN
 
  RAISERROR(''El perfil que desea asignar ya se encuentra registrado, inhabilite el registro anterior para poder registrar'',16,1);
  
 END


SELECT @PI_CODIGO_GENERADO=MAX(ISNULL(peuo_codigo_perfil_usuario,0))+1 FROM SAET_PERFIL_USUARIO_OFICINA
SELECT @PI_CODIGO_PERFIL_USU_OFI=@PI_CODIGO_GENERADO

INSERT INTO SAET_PERFIL_USUARIO_OFICINA (
																				peuo_codigo_perfil_usuario,
																				usof_icodigo_usuario_oficina,
																				perf_icodigo_perfil,
																				peuo_csituacion
																				)
																	VALUES(
																				@PI_CODIGO_GENERADO,
																				@PI_CODIGO_USUARIO_OFICINA,
																				@PI_CODIGO_PERFIL,
																				''A''
																				)



END TRY
BEGIN CATCH
DECLARE @MSG NVARCHAR(4000),@SEVERIDAD  INT,@ESTADO INT;

SELECT @MSG=ERROR_MESSAGE(),
       @SEVERIDAD=ERROR_SEVERITY(),
       @ESTADO=ERROR_STATE();

RAISERROR(@MSG,@SEVERIDAD,@ESTADO);

END CATCH 



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_FIRMANTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SAESI_INSERTAR_FIRMANTE]
(
@PV_VNOMBRE VARCHAR(255),
@PV_VPATERNO VARCHAR(255),
@PV_VMATERNO VARCHAR(255),
@PI_IDNI INT,
@PI_CODIGO_CARGO INT,
@PI_CODIGO_ENTIDAD INT,
@PI_AUDITORIA INT

)
AS


IF((SELECT COUNT(*) FROM SAET_FIRMANTE WHERE firm_idni=@PI_IDNI)>0)
BEGIN
		RAISERROR(''El DNI ingresado ya existe.'',16,1);
END
ELSE
BEGIN


INSERT INTO SAET_FIRMANTE(
								firm_vnombres,
								firm_vpaterno,
								firm_vmaterno,
								firm_idni,
								para_icodigo_cargo,
								para_icodigo_entidad,
								usua_iusuario_crea,
								usua_dfecha_crea
						 )VALUES
							(
							@PV_VNOMBRE,
							@PV_VPATERNO,
							@PV_VMATERNO,
							@PI_IDNI,
							@PI_CODIGO_CARGO,
							@PI_CODIGO_ENTIDAD,
							@PI_AUDITORIA,
							GETDATE()
						)

 
 
END 
 


 ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_FIRMANTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_FIRMANTE]
(
@PI_CODIGO_FIRMANTE INT,
@PV_VNOMBRE VARCHAR(255),
@PV_VPATERNO VARCHAR(255),
@PV_VMATERNO VARCHAR(255),
@PI_IDNI INT,
@PI_CODIGO_CARGO INT,
@PI_CODIGO_ENTIDAD INT,
@PI_AUDITORIA INT


)
AS



IF((SELECT COUNT(*) FROM SAET_FIRMANTE WHERE firm_idni=@PI_IDNI and firm_icodigo_FIRMANTE<>@PI_CODIGO_FIRMANTE )>0)
BEGIN
		RAISERROR(''El DNI ingresado ya existe.'',16,1);
END
ELSE
BEGIN



UPDATE SAET_FIRMANTE SET 
								firm_vnombres=@PV_VNOMBRE,
								firm_vpaterno=@PV_VPATERNO,
								firm_vmaterno=@PV_VMATERNO,
								firm_idni=@PI_IDNI,
								para_icodigo_cargo=@PI_CODIGO_CARGO,
								para_icodigo_entidad=@PI_CODIGO_ENTIDAD,
								usua_iusuario_modifica=@PI_AUDITORIA,
								usua_dfecha_modifica=GETDATE()

WHERE firm_icodigo_FIRMANTE=@PI_CODIGO_FIRMANTE





END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_DOCUMENTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Daniel Balvis
-- Create date: 06/09/2010
-- Description:	Registra los documentos de la Persona
-- =============================================
create  PROCEDURE [dbo].[SAESI_INSERTAR_DOCUMENTO] 


@PI_CODIGO_PERSONA    INT,
@PI_CODIGO_TIPO_DOC   INT,
@PV_NUMERO_DOCUMENTO  VARCHAR(12)

AS
BEGIN
DECLARE @PI_CODIGO_DOC INT


SELECT  @PI_CODIGO_DOC=ISNULL(MAX(docu_icodigo_documento),0)+1 FROM SAEt_documento

INSERT INTO SAET_DOCUMENTO(
                          docu_icodigo_documento,
                          docu_icodigo_tipo_documento,
                          docu_vnumero_documento,
                          pers_icodigo_persona
                          )
                          VALUES
                          (
                          @PI_CODIGO_DOC,
                          @PI_CODIGO_TIPO_DOC,
                          @PV_NUMERO_DOCUMENTO,
                          @PI_CODIGO_PERSONA
                          )
	 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESD_ELIMINAR_APOSTILLADOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SAESD_ELIMINAR_APOSTILLADOR]
(
 @PI_CODIGO_APOSTILLADOR INT
)
AS
BEGIN TRY
			--DELETE FROM  SAET_APOSTILLADOR  WHERE apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR
			UPDATE SAET_APOSTILLADOR SET apos_csituacion=''I'' WHERE apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR
			 
END TRY
BEGIN CATCH
				
IF ERROR_NUMBER()=547
				BEGIN
					RAISERROR(''No se puede eliminar. El registro esta relacionado con otra informacion'',16,1)
				END

END CATCH

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_APOSTILLADOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_APOSTILLADOR]
(
@PI_CODIGO_APOSTILLADOR INT,
@PI_CODIGO_CARGO INT,
@PI_AUDITORIA INT,
@PC_SITUACION CHAR(1)


)
AS
 
BEGIN
IF(@PC_SITUACION=''A'')
BEGIN
		IF((SELECT usua_cestado_usuario FROM saet_usuario WHERE usua_icodigo_usuario=@PI_CODIGO_APOSTILLADOR)=''I'')
		BEGIN
				RAISERROR(''No se puede activar al apostillador. Primero actualice ese estado en el mantenimientos de usuarios'',16,1)
		END
END


UPDATE SAET_APOSTILLADOR SET 
								para_icodigo_cargo=@PI_CODIGO_CARGO,
								usua_iusuario_modifica=@PI_AUDITORIA,
								usua_dfecha_modifica=GETDATE(),
								apos_csituacion=@PC_SITUACION
							

WHERE apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR


END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_APOSTILLADOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[SAESI_INSERTAR_APOSTILLADOR]
(
@PI_CODIGO_APOSTILLADOR INT,
@PI_AUDITORIA INT

)
AS
 
IF((SELECT COUNT(*) FROM SAET_APOSTILLADOR WHERE apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR)=0)
BEGIN
 
INSERT INTO SAET_APOSTILLADOR(	apos_icodigo_apostillador,
								apos_csituacion,
								usua_iusuario_crea,
								usua_dfecha_crea
						 )VALUES
							(
							@PI_CODIGO_APOSTILLADOR,
							''A'',
							@PI_AUDITORIA,
							GETDATE()
						)
 

--IF((SELECT COUNT(*) FROM SAET_APOSTILLADOR WHERE apos_idni=@PI_IDNI)>0)
--BEGIN
--		RAISERROR(''El DNI ingresado ya existe.'',16,1);
--END
--ELSE
--BEGIN
--
--INSERT INTO SAET_APOSTILLADOR(
--								apos_vnombres,
--								apos_vpaterno,
--								apos_vmaterno,
--								apos_idni,
--								para_icodigo_cargo,
--								usua_iusuario_crea,
--								usua_dfecha_crea
--						 )VALUES
--							(
--							@PV_VNOMBRE,
--							@PV_VPATERNO,
--							@PV_VMATERNO,
--							@PI_IDNI,
--							@PI_CODIGO_CARGO,
--							@PI_AUDITORIA,
--							GETDATE()
--						)

 
END
 

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_SITUACION_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
 
CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_SITUACION_USUARIO]
(

@PI_CODIGO_USUARIO INT, 
@PC_SITUACION CHAR(1)
 

)AS
BEGIN
UPDATE SAET_USUARIO SET usua_cestado_usuario=@PC_SITUACION
WHERE usua_icodigo_usuario=@PI_CODIGO_USUARIO

IF(@PC_SITUACION=''I'')
BEGIN
		UPDATE SAET_APOSTILLADOR SET apos_csituacion=@PC_SITUACION
		WHERE apos_icodigo_apostillador=@PI_CODIGO_USUARIO
END

END
 
 
 ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_SITUACION_APOSTILLADOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_SITUACION_APOSTILLADOR]
(
@PI_CODIGO_APOSTILLADOR INT,
@PI_AUDITORIA INT,
@PC_SITUACION CHAR(1)


)
AS
 
BEGIN
 
UPDATE SAET_APOSTILLADOR SET 
						
								usua_iusuario_modifica=@PI_AUDITORIA,
								usua_dfecha_modifica=GETDATE(),
								apos_csituacion=@PC_SITUACION
							

WHERE apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR


END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_NOMBRE_ARCHIVO_APOSTILLA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_NOMBRE_ARCHIVO_APOSTILLA]
(
@PV_NUMERO_APOSTILLA varchar(255),
@PV_NOMBRE_ARCHIVO varchar(255),
@PC_SITUACION	char(1),
@PV_SERIE	VARCHAR(50),
@PV_NUMERO_SERIE	VARCHAR(250)
)
AS

BEGIN
          UPDATE SAET_ACTUACION 
			SET 
			actu_vnombre_documento	=	@PV_NOMBRE_ARCHIVO,
			actu_csituacion			=	@PC_SITUACION,
			actu_vserie				=	@PV_SERIE,
			actu_vnumero_serie		=	@PV_NUMERO_SERIE
			WHERE 
			actu_vnumero_apostilla	=	@PV_NUMERO_APOSTILLA

END

 
 


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_ACTUACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

 
 

CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_ACTUACION]
(
@PI_CODIGO_ACTUACION INT,
@PI_CODIGO_APOSTILLADOR INT,
@PI_CODIGO_FIRMANTE  INT,
@PI_TIPO_DOCUMENTO  INT,
@PV_OPERACION_BANCARIA  VARCHAR(255),
@PD_FECHA DATETIME,
@PI_AUDITORIA  INT,
@PV_SERIE varchar(50),
@PV_NUMERO_SERIE VARCHAR(250)

)
AS
BEGIN

 

UPDATE SAET_ACTUACION SET
							actu_dfecha_apostilla=@PD_FECHA,
							actu_voperacion_bancaria=@PV_OPERACION_BANCARIA,
							para_icodigo_tipo_documento=@PI_TIPO_DOCUMENTO,
							apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR,
							firm_icodigo_firmante=@PI_CODIGO_FIRMANTE,
							peuo_iperfil_usuario_oficina_modifica=@PI_AUDITORIA,
							peuo_dfecha_modifica=getdate(),
							actu_vserie=@PV_SERIE,
							actu_vnumero_serie=@PV_NUMERO_SERIE
							 WHERE 
							actu_icodigo_actuacion=@PI_CODIGO_ACTUACION

 

END
     
 
              

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_ACTUACION_X_APOSTILLA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


 
 

CREATE PROCEDURE [dbo].[SAESU_ACTUALIZAR_ACTUACION_X_APOSTILLA]
(
@PV_NUMERO_APOSTILLA VARCHAR(255),
@PI_CODIGO_APOSTILLADOR INT,
@PI_CODIGO_FIRMANTE  INT,
@PI_TIPO_DOCUMENTO  INT,
@PV_OPERACION_BANCARIA  VARCHAR(255),
@PD_FECHA DATETIME,
@PI_AUDITORIA  INT,
@PV_SERIE varchar(50),
@PV_NUMERO_SERIE VARCHAR(250)

)
AS
BEGIN

 

UPDATE SAET_ACTUACION SET
							actu_dfecha_apostilla=@PD_FECHA,
							actu_voperacion_bancaria=@PV_OPERACION_BANCARIA,
							para_icodigo_tipo_documento=@PI_TIPO_DOCUMENTO,
							apos_icodigo_apostillador=@PI_CODIGO_APOSTILLADOR,
							firm_icodigo_firmante=@PI_CODIGO_FIRMANTE,
							peuo_iperfil_usuario_oficina_modifica=@PI_AUDITORIA,
							peuo_dfecha_modifica=getdate(),
							actu_vserie=@PV_SERIE,
							actu_vnumero_serie=@PV_NUMERO_SERIE
							 WHERE 
							actu_vnumero_apostilla=@PV_NUMERO_APOSTILLA

 

END
     
 
              


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_ACTUACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




 

CREATE PROCEDURE [dbo].[SAESI_INSERTAR_ACTUACION]
(
@PI_CODIGO_APOSTILLADOR INT,
@PI_CODIGO_FIRMANTE  INT,
@PI_TIPO_DOCUMENTO  INT,
@PV_OPERACION_BANCARIA  VARCHAR(255),
@PD_FECHA DATETIME,
@PI_AUDITORIA  INT,
@PV_NUMERO_APOSTILLA VARCHAR(255) OUTPUT,
@PC_SITUACION CHAR(1),
@PI_CODIGO_OFICINA INT,
@PV_SERIE VARCHAR(50),
@PV_NUMERO_SERIE VARCHAR(250)
)
AS
BEGIN

DECLARE @PI_CODIGO_ACTUACION INT
DECLARE @PI_CODIGO_ACTUACION_OFICINA INT

SELECT @PI_CODIGO_ACTUACION				=	isnull(max(actu_icodigo_actuacion),0)+1 FROM SAET_ACTUACION

SELECT  @PI_CODIGO_ACTUACION_OFICINA	=	isnull(max(actu_icodigo_actuacion_oficina),0)+1 FROM SAET_ACTUACION where ofic_icodigo_oficina_apostillador=@PI_CODIGO_OFICINA
     

SELECT  @PV_NUMERO_APOSTILLA = ''MRE''+(convert(varchar,(cast((1000000 * abs(rand()))as int)+1)))
									+
									replace(convert(varchar, getdate(),108),'':'','''') 
									+
									cast (@PI_CODIGO_ACTUACION as varchar)


IF((SELECT COUNT(*) FROM SAET_ACTUACION WHERE actu_vnumero_apostilla=@PV_NUMERO_APOSTILLA)=0)
BEGIN
					INSERT INTO SAET_ACTUACION(
												actu_icodigo_actuacion,
												actu_vnumero_apostilla,
												actu_dfecha_apostilla,
												actu_voperacion_bancaria,
												actu_vnombre_documento,
												actu_csituacion,
												para_icodigo_tipo_documento,
												apos_icodigo_apostillador,
												firm_icodigo_firmante,
												peuo_iperfil_usuario_oficina_crea,
												peuo_dfecha_crea,
												ofic_icodigo_oficina_apostillador,
												actu_icodigo_actuacion_oficina,
												actu_vserie,
												actu_vnumero_serie
												)VALUES(
												@PI_CODIGO_ACTUACION,
												@PV_NUMERO_APOSTILLA,
												@PD_FECHA,
												@PV_OPERACION_BANCARIA,
												'''',
												@PC_SITUACION,
												@PI_TIPO_DOCUMENTO ,
												@PI_CODIGO_APOSTILLADOR,
												@PI_CODIGO_FIRMANTE,
												@PI_AUDITORIA,
												getdate(),
												@PI_CODIGO_OFICINA,
												@PI_CODIGO_ACTUACION_OFICINA,
												@PV_SERIE,
												@PV_NUMERO_SERIE
												)
END
ELSE
BEGIN
				   DECLARE @PV_NUMERO_APOSTILLA_NUEVO VARCHAR(255)
                   EXEC	SAESI_INSERTAR_ACTUACION
													@PI_CODIGO_APOSTILLADOR,
													@PI_CODIGO_FIRMANTE,
													@PI_TIPO_DOCUMENTO,
													@PV_OPERACION_BANCARIA,
													@PD_FECHA,
													@PI_AUDITORIA,
													@PV_NUMERO_APOSTILLA_NUEVO  OUTPUT,
													@PC_SITUACION,
													@PI_CODIGO_OFICINA,
													@PV_SERIE,
													@PV_NUMERO_SERIE

				 SET @PV_NUMERO_APOSTILLA=@PV_NUMERO_APOSTILLA_NUEVO
END

RETURN 

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAEF_OBTIENE_NOMBRE_OFICINA]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE FUNCTION  [dbo].[SAEF_OBTIENE_NOMBRE_OFICINA](@PI_CODIGO_OFICINA int)
RETURNS VARCHAR(250)
AS
BEGIN
DECLARE @PV_OFICINA VARCHAR(250)
		
			SELECT  @PV_OFICINA=O.ofic_vnombre_oficina FROM SAET_OFICINA O 
        WHERE O.ofic_icodigo_oficina=@PI_CODIGO_OFICINA

	RETURN @PV_OFICINA
END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_OFICINA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[SAESS_LISTAR_OFICINA]
/*
	*******************************************************************
	Procedimiento	  : SAESS_LISTAR_OFICINA
	Input/Output	  : Descripción de Parámetros de entrada y salida
	Descripción		  : LISTAR TODAS LA OFICINAES REGISTRADAS CON EL PARAMETRO DE ENTRADA
	Se asume	  	  : N/A
	Retorno		      : N/A
	Notas			  : N/A
	Modificaciones	  : Descripción de Modificaciones
	Autor			  : DANIEL BALVIS
	Fecha y Hora  	  : 16/06/2009
	*******************************************************************
*/
(
@PI_CODIGO_OFICINA INT,
@PI_CODIGO_UBICACION INT
)
AS
BEGIN

    SELECT
            CODIGOOFICINA		    = OFIC_ICODIGO_OFICINA,
            CODIGOOFICINAPADRE 		= OFIC_ICODIGO_OFICINA_PADRE,
            NOMBREOFICINA		    = OFIC_VNOMBRE_OFICINA,
            DESCRIPCIONOFICINA		= OFIC_VDESCRIPCION_OFICINA,
            DIFERENCIAHORARIA		= OFIC_DIFERENCIA_HORARIA,
		    ESTADOOFICINA			= OFIC_CESTADO,
			CODIGOUBICACION			= PARA_ICODIGO_UBICACION
		FROM SAET_OFICINA
    WHERE 
    ((OFIC_ICODIGO_OFICINA=@PI_CODIGO_OFICINA  OR  (@PI_CODIGO_OFICINA =0)  OR (@PI_CODIGO_OFICINA  IS NULL))) AND
    ((PARA_ICODIGO_UBICACION=@PI_CODIGO_UBICACION)  OR  (@PI_CODIGO_UBICACION =0) OR (@PI_CODIGO_UBICACION  IS NULL) or(@PI_CODIGO_UBICACION =-1))

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAEF_OBTIENE_NOMBRE_OFICINAS_USUARIO]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


CREATE FUNCTION [dbo].[SAEF_OBTIENE_NOMBRE_OFICINAS_USUARIO](@PI_CODIGO_USUARIO int)
RETURNS NVARCHAR(4000)
AS
BEGIN

DECLARE _CUR_OFICINA CURSOR FOR (
								SELECT  O.ofic_vnombre_oficina FROM SAET_USUARIO_OFICINA UO INNER JOIN SAET_OFICINA O ON UO.ofic_icodigo_oficina = O.ofic_icodigo_oficina
								WHERE  UO.usua_icodigo_usuario=@PI_CODIGO_USUARIO
								)  
																
DECLARE @OFICINA AS VARCHAR(100),
		@OFICINAS  AS NVARCHAR(4000), 
		@CUENTA	AS INT
				
OPEN _CUR_OFICINA  

SET @OFICINAS='''';   
SET @CUENTA=0;
FETCH _CUR_OFICINA  INTO  @OFICINA  

WHILE @@FETCH_STATUS =0 BEGIN    
   
    
  IF @CUENTA=0 BEGIN
	SET @OFICINAS= @OFICINA;
  END  
  ELSE BEGIN
	SET @OFICINAS=@OFICINAS+'', ''+@OFICINA;
  END
  
  SET @CUENTA=@CUENTA+1;
FETCH _CUR_OFICINA  INTO  @OFICINA  
END   




CLOSE _CUR_OFICINA
DEALLOCATE _CUR_OFICINA

RETURN @OFICINAS


 
END


' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_PAIS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create procedure [dbo].[SAESS_LISTAR_PAIS]
(
@PI_CODIGO_PAIS INT
)
AS

SELECT  
            
            CODIGO_PAIS           =pais_icodigo_pais,
            NOMBRE_PAIS           =pais_vnombre_pais ,
            ESTADO_REGISTRO       =pais_cestado,
            CODIGO_REGION         =regi_icodigo_region,
            AUDITORIA_REGISTRO    = Null,
            AUDITORIA_MODIFICA    = Null,
            FECHA_REGISTRO        = Null,
            FECHA_MODIFICA        = Null
FROM 
            SAET_PAIS
WHERE 
          ((@PI_CODIGO_PAIS IS NULL OR @PI_CODIGO_PAIS=0) OR (@PI_CODIGO_PAIS=pais_icodigo_pais))
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_MODULO_X_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



create PROCEDURE [dbo].[SAESS_LISTAR_MODULO_X_USUARIO]
(
@PI_CODIGO_USUARIO  INT,
@PC_SITUACION       CHAR(1)
)
AS
    SELECT DISTINCT 
        MODULO        = M.modu_vnombre,      
        CODIGO_MODULO = M.modu_icodigo_modulo,
        CODIGO_SISTEMA= M.sist_icodigo_sistema
       
       FROM SAET_PERFIL_USUARIO_OFICINA PUO 
              INNER JOIN SAET_USUARIO_OFICINA UO ON (PUO.USOF_ICODIGO_USUARIO_OFICINA=UO.USOF_ICODIGO_USUARIO_OFICINA)
              INNER JOIN SAET_PERFIL P           ON (PUO.PERF_ICODIGO_PERFIL=P.PERF_ICODIGO_PERFIL)
              INNER JOIN SAET_MODULO M           ON (P.MODU_ICODIGO_MODULO=M.MODU_ICODIGO_MODULO)
       WHERE 
              USUA_ICODIGO_USUARIO=@PI_CODIGO_USUARIO AND
              MODU_CSITUACION =@PC_SITUACION          AND
              peuo_csituacion =@PC_SITUACION           
              
  



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_USUARIO_OFICINA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create PROCEDURE [dbo].[SAESI_INSERTAR_USUARIO_OFICINA]
(
@PI_CODIGO int OUTPUT, 
@PI_CODIGO_OFICINA int, 
@PI_CODIGO_USUARIO int
)
WITH 
EXECUTE AS CALLER
AS
IF(EXISTS (SELECT 1 FROM  SAET_USUARIO_OFICINA UO WHERE   UO.ofic_icodigo_oficina=@PI_CODIGO_OFICINA AND UO.usua_icodigo_usuario=@PI_CODIGO_USUARIO))
BEGIN
			SELECT @PI_CODIGO=usof_icodigo_usuario_oficina FROM SAET_USUARIO_OFICINA UO  WHERE   UO.ofic_icodigo_oficina=@PI_CODIGO_OFICINA AND UO.usua_icodigo_usuario=@PI_CODIGO_USUARIO
END
ELSE
BEGIN
			SELECT @PI_CODIGO=MAX(ISNULL(usof_icodigo_usuario_oficina,0))+1 FROM SAET_USUARIO_OFICINA
					INSERT INTO SAET_USUARIO_OFICINA
										( 
										usof_icodigo_usuario_oficina,
										ofic_icodigo_oficina,
										usua_icodigo_usuario,
										usof_situacion
										)
							VALUES(
										@PI_CODIGO,
										@PI_CODIGO_OFICINA,
										@PI_CODIGO_USUARIO,
										''A'' 
										)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_MODULO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



create procedure [dbo].[SAESS_LISTAR_MODULO]
@PI_CODIGO_SISTEMA  INT,
@PC_SITUACION       CHAR(1)
AS

select 
MODULO        = modu_vnombre,      
CODIGO_MODULO = modu_icodigo_modulo,
CODIGO_SISTEMA= sist_icodigo_sistema

 from SAEt_modulo

where 
((@PI_CODIGO_SISTEMA='''' OR @PI_CODIGO_SISTEMA IS NULL) OR (sist_icodigo_sistema=@PI_CODIGO_SISTEMA)) AND
((@PC_SITUACION='''' OR @PC_SITUACION IS NULL) OR (modu_csituacion=@PC_SITUACION))

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_PERFIL_X_UBICACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



 



CREATE     PROCEDURE [dbo].[SAESS_LISTAR_PERFIL_X_UBICACION]
(
/*
NOMBRE 		    :	SAESS_LISTAR_PERFIL_X_UBICACION
DESCRIPCIÓN	  :	LISTA LOS PERFILES SEGUN EL PARAMETRO UBICACION
FECHA		      :	21/04/2009
PARAMETROS I/O:	@PI_CODIGO_UBICACION INT,
			            @PI_CODIGO_UNIDAD INT
AUTOR		      :	DANIEL B.
*/
@PI_CODIGO_UBICACION INT,
@PI_CODIGO_UNIDAD    INT,
@PC_SITUACION        CHAR(1) ,
@PI_CODIGO_MODULO    INT
)
 
AS
SELECT  
	CODIGO_PERFIL		=		P.PERF_ICODIGO_PERFIL,
	NOMBRE_PERFIL		=		P.PERF_VNOMBRE_PERFIL,
	CODIGO_UNIDAD		=		0,--//U.UNID_ICODIGO_UNIDAD,
	SITUACION   		=		P.PERF_CESTADO,
	DESCRIPCION     =   P.PERF_VDESCRIPCION_PERFIL
	
FROM SAET_PERFIL P --INNER JOIN SAET_UNIDAD U	ON (U.UNID_ICODIGO_UNIDAD=P.UNID_ICODIGO_UNIDAD)

WHERE --((@PI_CODIGO_UBICACION=0) OR (@PI_CODIGO_UBICACION IS NULL) OR (U.PARA_ICODIGO_UBICACION=@PI_CODIGO_UBICACION)) AND
      --((@PI_CODIGO_UNIDAD=0) OR (@PI_CODIGO_UNIDAD IS NULL) OR (U.UNID_ICODIGO_UNIDAD=@PI_CODIGO_UNIDAD)) AND
      ((@PC_SITUACION='''') OR (@PC_SITUACION IS NULL) OR (P.PERF_CESTADO=@PC_SITUACION))and-- AND U.UNID_CESTADO=@PC_SITUACION)) AND
      ((@PI_CODIGO_MODULO=0) OR (@PI_CODIGO_MODULO IS NULL) OR (P.modu_icodigo_modulo=@PI_CODIGO_MODULO)) 
 
      

 
 
 

 



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESU_ACTUALIZAR_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






create PROCEDURE [dbo].[SAESU_ACTUALIZAR_USUARIO]
(
/*********************************************************************
  PROCEDIMIENTO	  : SAESU_ACTUALIZAR_USUARIO
  PROPÓSITO	      : MODIFICA   LA INFORMACION DE UN USUARIO
  INPUTS/OUTPUT	  : 	
                          @PI_CODIGO_USUARIO  INT,
                          @PV_NOMBRE   			  VARCHAR(100),
                          @PV_APE_PATERNO		  VARCHAR(50),
                          @PV_APE_MATERNO		  VARCHAR(50),
                          @PV_USUARIO_RED			VARCHAR(30),	
                          @PV_DOMINIO		    	VARCHAR(30),	
                          @PC_SITUACION       CHAR(1),
                          @PI_CODIGO_MISION   INT,
                          @PV_CORREO          VARCHAR(50),
                          @PI_AUDITORIA       INT,
                          @PI_CODIGO_PERFIL   INT
                      
  MODIFICACIONES  : N/A
  AUTOR           : DANIEL B.
  FECHA Y HORA    : 05/09/2010- 11:00
**********************************************************************/

@PI_CODIGO_USUARIO  INT,
@PV_USUARIO_RED			VARCHAR(30),	
@PV_DOMINIO		    	VARCHAR(30),	
@PC_SITUACION       CHAR(1),
@PV_CORREO          VARCHAR(50),
@PI_AUDITORIA       INT
)

AS
BEGIN

IF @PI_CODIGO_USUARIO=1 AND @PC_SITUACION<>''A''
BEGIN
	RAISERROR(''EL USUARIO QUE DESEA ACTUALIZAR ES ADMINISTRADOR DE SISTEMA,NO PUEDE INACTIVARSE NI BLOQUEARSE.'',16,1)
  RETURN

END

IF (EXISTS (SELECT USUA_VUSUARIO_RED_USUARIO FROM SAET_USUARIO WHERE USUA_VUSUARIO_RED_USUARIO=@PV_USUARIO_RED  AND USUA_ICODIGO_USUARIO  <> @PI_CODIGO_USUARIO		 ) )
BEGIN
		RAISERROR(''EL NOMBRE DEL USUARIO DE RED PARA EL LOGIN, YA EXISTE.'',16,1)
		RETURN
END

UPDATE  SAET_USUARIO    SET

                              usua_vusuario_red_usuario=@PV_USUARIO_RED,
                              usua_vdominio_usuario=@PV_DOMINIO,
                              usua_vcorreo_usuario=@PV_CORREO,
                              usua_icodigo_perfil_usuario_modifica=@PI_AUDITORIA,
                              usua_sfecha_modifica=getdate(),
                              usua_cestado_usuario=@PC_SITUACION
			                  
WHERE USUA_ICODIGO_USUARIO  = @PI_CODIGO_USUARIO			                  

END


 
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESI_INSERTAR_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





CREATE        PROCEDURE [dbo].[SAESI_INSERTAR_USUARIO]
(
/*********************************************************************
  PROCEDIMIENTO	: SAESI_INSERTAR_USUARIO
  PROPÓSITO	: REGISTRA UN USUARIO
  INPUTS/OUTPUT	: 	@PV_NOMBRES 			VARCHAR(100),
                    @PV_NOMBRE   			  VARCHAR(100),
                    @PV_APE_PATERNO		  VARCHAR(50),
                    @PV_APE_PATERNO		  VARCHAR(50),
                    @PV_USUARIO_RED			VARCHAR(30),	
                    @PV_DOMINIO		    	VARCHAR(30),	
                    @PC_SITUACION			  CHAR(1),
                    @PI_CODIGO_MISION		INT,
                    @PV_CORREO			    VARCHAR(50)
  MODIFICACIONES :  08/01/2007
  AUTOR           	: DANIEL B.
  FECHA Y HORA    : 31/08/2009 - 12:00
**********************************************************************/

@PV_NOMBRE   			  VARCHAR(100),
@PV_APE_PATERNO		  VARCHAR(50),
@PV_APE_MATERNO		  VARCHAR(50),
@PV_USUARIO_RED			VARCHAR(30),	
@PV_DOMINIO		    	VARCHAR(30),	
@PC_SITUACION			  CHAR(1),
@PV_CORREO			    VARCHAR(50),
@PI_CODIGO_USUARIO  INT OUT,
@PI_AUDITORIA       INT
)
AS 


IF (EXISTS (SELECT USUA_VUSUARIO_RED_USUARIO FROM SAET_USUARIO WHERE USUA_VUSUARIO_RED_USUARIO=@PV_USUARIO_RED) )
BEGIN
		RAISERROR(''EL NOMBRE DEL USUARIO DE RED PARA EL LOGIN YA EXISTE.'',16,1)
		RETURN
END


                  INSERT INTO SAET_USUARIO(
			                  USUA_ICODIGO_USUARIO,
			                  USUA_VUSUARIO_RED_USUARIO,
			                  USUA_VDOMINIO_USUARIO,
			                  USUA_CESTADO_USUARIO,
			                  USUA_VCORREO_USUARIO,
			                  usua_icodigo_perfil_usuario_crea,
			                  usua_sfecha_crea
 		                   )VALUES(
			                  @PI_CODIGO_USUARIO,
			                  @PV_USUARIO_RED,
			                  @PV_DOMINIO,
			                  @PC_SITUACION,
			                  @PV_CORREO,
			                  @PI_AUDITORIA,
			                  GETDATE() 
                  )


 




 






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESD_ELIMINAR_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'













create PROCEDURE [dbo].[SAESD_ELIMINAR_USUARIO]
(
--AUTOR         : DANIEL BALVIS
--FECHA         : 23/03/2009
--PROPOSITO     : ELIMINAR LOS USUARIOS REGISTRADOS EN EL SISTEMA ASI COMO TAMBIEN ELIMINA LOS PERFILES QUE TIENE ASIGNADO EL USUARIO
--PARAMETRO     :       @PI_CODIGO    INT,
--                      @PI_AUDITORIA INT
--RETORNO       : N/A
--NOTA          : N/A
--MODIFICACION  : N/A
--FEC MODIFICA  : N/A

@PI_CODIGO    INT,
@PI_AUDITORIA INT
)
AS
BEGIN

DECLARE @PI_CODIGO_ADMIN INT
SET @PI_CODIGO_ADMIN=1

IF @PI_CODIGO=@PI_CODIGO_ADMIN 
BEGIN
	RAISERROR(''El usuario administrador de sistema no puede eliminarse.'',16,1)
  RETURN

END

                 UPDATE SAET_USUARIO 
                 SET 
                 USUA_CESTADO_USUARIO=''I'',
                 usua_icodigo_perfil_usuario_modifica=@PI_AUDITORIA,
                 USUA_SFECHA_MODIFICA=GETDATE()
                 
                 WHERE  USUA_ICODIGO_USUARIO=@PI_CODIGO
                        

                                          
END




 



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAESS_LISTAR_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[SAESS_LISTAR_USUARIO]
(
@PI_CODIGO_USUARIO        int, 
@PC_ESTADO_REGISTRO       char(1),
@PV_DOMINIO               varchar(50), 
@PV_USUARIO_RED           varchar(50), 
@PV_NOMBRE_COMPLETO       varchar(100),
@PI_CODIGO_OFICINA        INT
)
WITH 
EXECUTE AS CALLER
AS
BEGIN

IF (@PI_CODIGO_OFICINA IS NULL OR @PI_CODIGO_OFICINA='''')
			BEGIN
												SELECT 
																						CODIGO_USUARIO    =   U.USUA_ICODIGO_USUARIO,
																						NOMBRE_USUARIO    =   P.PERS_VNOMBRE_PERSONA,
																						APELLIDO_MATERNO  =   P.PERS_VAPEPATERNO_PERSONA,
																						APELLIDO_PATERNO  =   P.PERS_VAPEMATERNO_PERSONA,
																						NOMBRE_COMPLETO   =   P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA,
																						USUARIO_RED       =   U.USUA_VUSUARIO_RED_USUARIO,
																						DOMINIO_RED       =   U.USUA_VDOMINIO_USUARIO,
																						CORREO_USUARIO    =   U.USUA_VCORREO_USUARIO,
																						AUDITORIA_REGISTRO=   U.USUA_ICODIGO_PERFIL_USUARIO_CREA,
																						FECHA_REGISTRO    =   U.USUA_SFECHA_CREA,
																						AUDITORIA_MODIFICA=   U.USUA_ICODIGO_PERFIL_USUARIO_MODIFICA,
																						FECHA_MODIFICA    =   U.USUA_SFECHA_MODIFICA,
																						ESTADO_REGISTRO   =   U.USUA_CESTADO_USUARIO,
																						CODIGO_PERFIL     =   (Select top 1 puo.perf_icodigo_perfil from SAET_PERFIL_USUARIO_OFICINA puo 
																																																	inner join SAEt_usuario_oficina uo
																																																	on puo.usof_icodigo_usuario_oficina = uo.usof_icodigo_usuario_oficina
																																																	where puo.peuo_csituacion=''A'' and uo.usua_icodigo_usuario=U.usua_icodigo_usuario),
																						OFICINA_ASIGNADA	=		dbo.SAEF_OBTIENE_NOMBRE_OFICINAS_USUARIO( U.USUA_ICODIGO_USUARIO),
																						CODIGO_PAIS_NAC   =   P.pais_icodigo_pais_nacimiento,
                                            SEXO              =   P.pers_csexo_persona,
                                            FECHA_NACIMIENTO  =   P.pers_sfecha_nacimiento
													
																						
												FROM SAET_USUARIO U INNER JOIN SAET_PERSONA P ON(U.USUA_ICODIGO_USUARIO=P.pers_icodigo_persona)
														
												WHERE   
																						((@PI_CODIGO_USUARIO=0) OR (@PI_CODIGO_USUARIO IS NULL) OR (U.USUA_ICODIGO_USUARIO=@PI_CODIGO_USUARIO)) AND
																						((@PC_ESTADO_REGISTRO='''') OR (@PC_ESTADO_REGISTRO IS NULL) OR (U.USUA_CESTADO_USUARIO=@PC_ESTADO_REGISTRO)) AND
																						((@PV_DOMINIO='''') OR(@PV_DOMINIO IS NULL) OR (UPPER(U.USUA_VDOMINIO_USUARIO)=UPPER(@PV_DOMINIO))) AND
																						((@PV_USUARIO_RED='''') OR (@PV_USUARIO_RED IS NULL) OR (UPPER(U.USUA_VUSUARIO_RED_USUARIO)=UPPER(@PV_USUARIO_RED))) AND
																						((@PV_NOMBRE_COMPLETO='''')OR(@PV_NOMBRE_COMPLETO IS NULL) OR(@PV_NOMBRE_COMPLETO=P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA)) --AND

			END                                     
			ELSE
			BEGIN
												SELECT 
																						CODIGO_USUARIO    =   U.USUA_ICODIGO_USUARIO,
																						NOMBRE_USUARIO    =   P.PERS_VNOMBRE_PERSONA,
																						APELLIDO_MATERNO  =   P.PERS_VAPEPATERNO_PERSONA,
																						APELLIDO_PATERNO  =   P.PERS_VAPEMATERNO_PERSONA,
																						NOMBRE_COMPLETO   =   P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA,
																						USUARIO_RED       =   U.USUA_VUSUARIO_RED_USUARIO,
																						DOMINIO_RED       =   U.USUA_VDOMINIO_USUARIO,
																						CORREO_USUARIO    =   U.USUA_VCORREO_USUARIO,
																						AUDITORIA_REGISTRO=   U.USUA_ICODIGO_PERFIL_USUARIO_CREA,
																						FECHA_REGISTRO    =   U.USUA_SFECHA_CREA,
																						AUDITORIA_MODIFICA=   U.USUA_ICODIGO_PERFIL_USUARIO_MODIFICA,
																						FECHA_MODIFICA    =   U.USUA_SFECHA_MODIFICA,
																						ESTADO_REGISTRO   =   U.USUA_CESTADO_USUARIO,
																						CODIGO_PERFIL     =   (Select top 1 puo.perf_icodigo_perfil from SAET_PERFIL_USUARIO_OFICINA puo 
																																																	inner join SAEt_usuario_oficina uo
																																																	on puo.usof_icodigo_usuario_oficina = uo.usof_icodigo_usuario_oficina
																																																	where puo.peuo_csituacion=''A'' and uo.usua_icodigo_usuario=U.usua_icodigo_usuario),
																						OFICINA_ASIGNADA	=		O.ofic_vnombre_oficina,
																						CODIGO_PAIS_NAC   =   P.pais_icodigo_pais_nacimiento,
                                            SEXO              =   P.pers_csexo_persona,
                                            FECHA_NACIMIENTO  =   P.pers_sfecha_nacimiento
													
																						
												FROM SAET_USUARIO U INNER JOIN   SAET_USUARIO_OFICINA UO ON (UO.usua_icodigo_usuario = U.usua_icodigo_usuario)
																						INNER JOIN SAET_OFICINA O ON (UO.ofic_icodigo_oficina=O.ofic_icodigo_oficina)
																						INNER JOIN SAET_PERSONA P ON(U.USUA_ICODIGO_USUARIO=P.pers_icodigo_persona)
														
												WHERE   
																						((@PI_CODIGO_USUARIO=0) OR (@PI_CODIGO_USUARIO IS NULL) OR (U.USUA_ICODIGO_USUARIO=@PI_CODIGO_USUARIO)) AND
																						((@PC_ESTADO_REGISTRO='''') OR (@PC_ESTADO_REGISTRO IS NULL) OR (U.USUA_CESTADO_USUARIO=@PC_ESTADO_REGISTRO)) AND
																						((@PV_DOMINIO='''') OR(@PV_DOMINIO IS NULL) OR (UPPER(U.USUA_VDOMINIO_USUARIO)=UPPER(@PV_DOMINIO))) AND
																						((@PV_USUARIO_RED='''') OR (@PV_USUARIO_RED IS NULL) OR (UPPER(U.USUA_VUSUARIO_RED_USUARIO)=UPPER(@PV_USUARIO_RED))) AND
																						((@PV_NOMBRE_COMPLETO='''')OR(@PV_NOMBRE_COMPLETO IS NULL) OR(@PV_NOMBRE_COMPLETO=P.PERS_VAPEPATERNO_PERSONA+'' ''+P.PERS_VAPEMATERNO_PERSONA+'' ''+P.PERS_VNOMBRE_PERSONA)) AND
																						(@PI_CODIGO_OFICINA=UO.ofic_icodigo_oficina)
			END                                     
END

 



' 
END
