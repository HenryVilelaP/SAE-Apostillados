SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_REGION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_REGION](
	[regi_icodigo_region] [int] NOT NULL,
	[regi_vnombre_region] [varchar](50) NULL,
	[regi_cestado] [char](1) NULL,
	[regi_vcodigo_region] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[regi_icodigo_region] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_UNIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_UNIDAD](
	[unid_icodigo_unidad] [int] NOT NULL,
	[unid_vnombre_unidad] [varchar](50) NULL,
	[unid_vabreviatura] [varchar](10) NULL,
	[unid_sfecha_crea] [smalldatetime] NULL,
	[unid_iusuario_crea] [int] NULL,
	[unid_iusuario_modifica] [int] NULL,
	[unid_sfecha_Modifica] [smalldatetime] NULL,
	[unid_cestado] [char](1) NULL,
	[para_icodigo_ubicacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[unid_icodigo_unidad] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PARAMETRO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PARAMETRO](
	[para_icodigo_parametro] [int] NOT NULL,
	[para_icodigo_tabla] [int] NOT NULL,
	[para_icodigo_registro] [int] NOT NULL,
	[para_vnombre_parametro] [varchar](100) NULL,
	[para_dvalor_numerico] [decimal](18, 0) NULL,
	[para_vvalor_texto] [varchar](250) NULL,
	[para_cflag_modificar] [char](1) NULL,
	[para_cflag_eliminar] [char](1) NULL,
	[para_iusuario_crea] [int] NULL,
	[para_sfecha_crea] [smalldatetime] NULL,
	[para_iusuario_modifica] [int] NULL,
	[para_sfecha_modifica] [smalldatetime] NULL,
	[para_cestado] [char](1) NULL,
 CONSTRAINT [PK_SAET_PARAMETRO] PRIMARY KEY CLUSTERED 
(
	[para_icodigo_parametro] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_OPCION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_OPCION](
	[opci_icodigo_opcion] [int] NOT NULL,
	[opci_inivel_opcion] [int] NULL,
	[opci_vnombre_opcion] [varchar](50) NULL,
	[opci_vruta_pagina] [varchar](250) NULL,
	[opci_vdescripcion_opcion] [varchar](100) NULL,
	[opci_icodigo_opcion_dependiente] [int] NULL,
	[opci_cflag_opcion_critica] [char](1) NULL,
	[opci_iusuario_crea] [int] NULL,
	[opci_sfecha_crea] [smalldatetime] NULL,
	[opci_iusuario_modifica] [int] NULL,
	[opci_sfecha_modifica] [smalldatetime] NULL,
	[opci_cestado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[opci_icodigo_opcion] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_SISTEMA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_SISTEMA](
	[sist_icodigo] [int] NOT NULL,
	[sist_vnombre] [varchar](250) NOT NULL,
	[sist_vdescripcion] [varchar](255) NOT NULL,
	[sist_vprefijo] [varchar](50) NOT NULL,
	[sist_csituacion] [char](1) NOT NULL,
 CONSTRAINT [PK_SAET_SISTEMA] PRIMARY KEY CLUSTERED 
(
	[sist_icodigo] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PAIS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PAIS](
	[pais_icodigo_pais] [int] NOT NULL,
	[pais_vnombre_pais] [varchar](50) NULL,
	[pais_cestado] [char](1) NULL,
	[regi_icodigo_region] [int] NOT NULL,
	[pais_vcodigo_pais] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[pais_icodigo_pais] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_USUARIO_OFICINA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_USUARIO_OFICINA](
	[usof_icodigo_usuario_oficina] [int] NOT NULL,
	[usua_icodigo_usuario] [int] NOT NULL,
	[ofic_icodigo_oficina] [int] NOT NULL,
	[usof_situacion] [char](1) NOT NULL,
 CONSTRAINT [PK_SAET_USUARIO_UBICACION_1] PRIMARY KEY CLUSTERED 
(
	[usof_icodigo_usuario_oficina] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_USUARIO_OFICINA] UNIQUE NONCLUSTERED 
(
	[usua_icodigo_usuario] ASC,
	[ofic_icodigo_oficina] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_ACTUACION](
	[actu_icodigo_actuacion] [int] NOT NULL,
	[actu_icodigo_actuacion_oficina] [int] NULL,
	[actu_vnumero_apostilla] [nvarchar](max) NOT NULL,
	[actu_dfecha_apostilla] [datetime] NOT NULL,
	[actu_voperacion_bancaria] [varchar](255) NOT NULL,
	[actu_vnombre_documento] [varchar](255) NOT NULL,
	[actu_csituacion] [char](1) NOT NULL,
	[para_icodigo_tipo_documento] [int] NOT NULL,
	[actu_vserie] [varchar](50) NULL,
	[actu_vnumero_serie] [varchar](250) NULL,
	[apos_icodigo_apostillador] [int] NOT NULL,
	[ofic_icodigo_oficina_apostillador] [int] NULL,
	[firm_icodigo_firmante] [int] NOT NULL,
	[peuo_iperfil_usuario_oficina_crea] [int] NULL,
	[peuo_dfecha_crea] [smalldatetime] NULL,
	[peuo_iperfil_usuario_oficina_modifica] [int] NULL,
	[peuo_dfecha_modifica] [smalldatetime] NULL,
 CONSTRAINT [PK_ACTUACION] PRIMARY KEY CLUSTERED 
(
	[actu_icodigo_actuacion] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PERFIL](
	[perf_icodigo_perfil] [int] NOT NULL,
	[perf_vnombre_perfil] [varchar](50) NULL,
	[perf_vdescripcion_perfil] [varchar](100) NULL,
	[perf_cestado] [char](1) NULL,
	[perf_iusuario_crea] [int] NULL,
	[perf_sfecha_crea] [char](18) NULL,
	[perf_iusuario_modifica] [int] NULL,
	[perf_sfecha_modifica] [char](18) NULL,
	[unid_icodigo_unidad] [int] NULL,
	[modu_icodigo_modulo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[perf_icodigo_perfil] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_USUARIO_OFICINA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PERFIL_USUARIO_OFICINA](
	[peuo_codigo_perfil_usuario] [int] NOT NULL,
	[usof_icodigo_usuario_oficina] [int] NOT NULL,
	[perf_icodigo_perfil] [int] NOT NULL,
	[peuo_csituacion] [nchar](1) NOT NULL,
 CONSTRAINT [PK_SAET_PERFIL_USUARIO_OFICINA] PRIMARY KEY CLUSTERED 
(
	[peuo_codigo_perfil_usuario] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_PERFIL_USU_OFICINA] UNIQUE NONCLUSTERED 
(
	[usof_icodigo_usuario_oficina] ASC,
	[perf_icodigo_perfil] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_USUARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_USUARIO](
	[usua_icodigo_usuario] [int] NOT NULL,
	[usua_vusuario_red_usuario] [varchar](30) NULL,
	[usua_vdominio_usuario] [varchar](30) NULL,
	[usua_vcorreo_usuario] [varchar](50) NULL,
	[usua_icodigo_perfil_usuario_crea] [int] NULL,
	[usua_sfecha_crea] [smalldatetime] NULL,
	[usua_icodigo_perfil_usuario_modifica] [int] NULL,
	[usua_sfecha_modifica] [smalldatetime] NULL,
	[usua_cestado_usuario] [char](1) NULL,
 CONSTRAINT [PK_SAET_USUARIO_] PRIMARY KEY CLUSTERED 
(
	[usua_icodigo_usuario] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_DOCUMENTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_DOCUMENTO](
	[docu_icodigo_documento] [int] NOT NULL,
	[docu_icodigo_tipo_documento] [int] NOT NULL,
	[docu_vnumero_documento] [varchar](12) NOT NULL,
	[pers_icodigo_persona] [int] NOT NULL,
 CONSTRAINT [PK_SAET_DOCUMENTO] PRIMARY KEY CLUSTERED 
(
	[docu_icodigo_documento] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_NUMERO_DOCUMENTO] UNIQUE NONCLUSTERED 
(
	[docu_vnumero_documento] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_APOSTILLADOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_APOSTILLADOR](
	[apos_icodigo_apostillador] [int] NOT NULL,
	[apos_vnombres] [varchar](255) NULL,
	[apos_vpaterno] [varchar](255) NULL,
	[apos_vmaterno] [varchar](255) NULL,
	[apos_idni] [int] NULL,
	[para_icodigo_cargo] [int] NULL,
	[usua_iusuario_crea] [int] NULL,
	[usua_dfecha_crea] [smalldatetime] NULL,
	[usua_iusuario_modifica] [int] NULL,
	[usua_dfecha_modifica] [smalldatetime] NULL,
	[apos_csituacion] [nchar](1) NULL,
 CONSTRAINT [PK_APOSTILLADOR] PRIMARY KEY CLUSTERED 
(
	[apos_icodigo_apostillador] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_USUARIO_OFICINA_DETALLE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PERFIL_USUARIO_OFICINA_DETALLE](
	[peuo_icodigo_perfil_usuario] [int] NOT NULL,
	[opci_icodigo_opcion] [int] NOT NULL,
	[peuo_ctipo_acceso] [nchar](1) NOT NULL,
 CONSTRAINT [PK_SAET_PERFIL_USUARIO_OFICINA_DETALLE] PRIMARY KEY CLUSTERED 
(
	[peuo_icodigo_perfil_usuario] ASC,
	[opci_icodigo_opcion] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_OPCION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PERFIL_OPCION](
	[perf_icodigo_perfil] [int] NOT NULL,
	[opci_icodigo_opcion] [int] NOT NULL,
	[pemo_iusuario_crea] [int] NULL,
	[pemo_sfecha_crea] [smalldatetime] NULL,
	[pemo_iusuario_modifica] [int] NULL,
	[pemo_sfecha_modifica] [smalldatetime] NULL,
	[pemo_cestado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[perf_icodigo_perfil] ASC,
	[opci_icodigo_opcion] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_PERSONA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_PERSONA](
	[pers_icodigo_persona] [int] NOT NULL,
	[pers_vapepaterno_persona] [varchar](30) NOT NULL,
	[pers_vapematerno_persona] [varchar](30) NOT NULL,
	[pers_vnombre_persona] [varchar](50) NOT NULL,
	[pais_icodigo_pais_nacimiento] [int] NULL,
	[pers_cestado_persona] [char](1) NULL,
	[pers_csexo_persona] [char](1) NULL,
	[pers_sfecha_nacimiento] [smalldatetime] NULL,
 CONSTRAINT [PK_SAET_PERSONA] PRIMARY KEY CLUSTERED 
(
	[pers_icodigo_persona] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_OFICINA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_OFICINA](
	[ofic_icodigo_oficina] [int] NOT NULL,
	[ofic_icodigo_oficina_padre] [int] NULL,
	[ofic_vnombre_oficina] [varchar](30) NULL,
	[ofic_vdescripcion_oficina] [varchar](250) NULL,
	[ofic_diferencia_horaria] [char](1) NULL,
	[pais_icodigo_pais] [int] NOT NULL,
	[ofic_inumero_horas] [int] NULL,
	[ofic_iusuario_crea] [int] NULL,
	[ofic_sfecha_crea] [smalldatetime] NULL,
	[ofic_iusuario_modifica] [int] NULL,
	[ofic_sfecha_modifica] [smalldatetime] NULL,
	[para_icodigo_tipo_oficina] [int] NOT NULL,
	[ofic_cestado] [char](1) NULL,
	[ofic_binicializa] [char](1) NULL,
	[ofic_sfecha_inicializa] [smalldatetime] NULL,
	[ofic_vcodigo_local_oficina] [varchar](6) NULL,
	[para_icodigo_ubicacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ofic_icodigo_oficina] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_FIRMANTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_FIRMANTE](
	[firm_icodigo_firmante] [int] IDENTITY(1,1) NOT NULL,
	[firm_vnombres] [varchar](255) NOT NULL,
	[firm_vpaterno] [varchar](255) NOT NULL,
	[firm_vmaterno] [varchar](255) NOT NULL,
	[firm_idni] [int] NULL,
	[para_icodigo_cargo] [int] NOT NULL,
	[para_icodigo_entidad] [int] NULL,
	[usua_iusuario_crea] [int] NULL,
	[usua_dfecha_crea] [smalldatetime] NULL,
	[usua_iusuario_modifica] [int] NULL,
	[usua_dfecha_modifica] [smalldatetime] NULL,
 CONSTRAINT [PK_FIRMANTE] PRIMARY KEY CLUSTERED 
(
	[firm_icodigo_firmante] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SAET_MODULO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SAET_MODULO](
	[modu_icodigo_modulo] [int] NOT NULL,
	[modu_vnombre] [varchar](50) NULL,
	[modu_vdescripcion] [varchar](250) NULL,
	[modu_csituacion] [char](1) NOT NULL,
	[sist_icodigo_sistema] [int] NOT NULL,
 CONSTRAINT [PK_SAET_MODULO_1] PRIMARY KEY CLUSTERED 
(
	[modu_icodigo_modulo] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__SAET_OPCI__opci___2C3393D0]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_OPCION]'))
ALTER TABLE [dbo].[SAET_OPCION]  WITH NOCHECK ADD  CONSTRAINT [FK__SAET_OPCI__opci___2C3393D0] FOREIGN KEY([opci_icodigo_opcion_dependiente])
REFERENCES [dbo].[SAET_OPCION] ([opci_icodigo_opcion])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_PAIS_SAET_REGION]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PAIS]'))
ALTER TABLE [dbo].[SAET_PAIS]  WITH CHECK ADD  CONSTRAINT [FK_SAET_PAIS_SAET_REGION] FOREIGN KEY([regi_icodigo_region])
REFERENCES [dbo].[SAET_REGION] ([regi_icodigo_region])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_USUARIO_OFICINA_SAET_OFICINA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_USUARIO_OFICINA]'))
ALTER TABLE [dbo].[SAET_USUARIO_OFICINA]  WITH CHECK ADD  CONSTRAINT [FK_SAET_USUARIO_OFICINA_SAET_OFICINA] FOREIGN KEY([ofic_icodigo_oficina])
REFERENCES [dbo].[SAET_OFICINA] ([ofic_icodigo_oficina])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_USUARIO_OFICINA_SAET_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_USUARIO_OFICINA]'))
ALTER TABLE [dbo].[SAET_USUARIO_OFICINA]  WITH CHECK ADD  CONSTRAINT [FK_SAET_USUARIO_OFICINA_SAET_USUARIO] FOREIGN KEY([usua_icodigo_usuario])
REFERENCES [dbo].[SAET_USUARIO] ([usua_icodigo_usuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_APOSTILLADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]'))
ALTER TABLE [dbo].[SAET_ACTUACION]  WITH CHECK ADD  CONSTRAINT [FK_APOSTILLADOR] FOREIGN KEY([apos_icodigo_apostillador])
REFERENCES [dbo].[SAET_APOSTILLADOR] ([apos_icodigo_apostillador])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FIRMANTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]'))
ALTER TABLE [dbo].[SAET_ACTUACION]  WITH CHECK ADD  CONSTRAINT [FK_FIRMANTE] FOREIGN KEY([firm_icodigo_firmante])
REFERENCES [dbo].[SAET_FIRMANTE] ([firm_icodigo_firmante])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_ACTUACION_SAET_OFICINA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]'))
ALTER TABLE [dbo].[SAET_ACTUACION]  WITH CHECK ADD  CONSTRAINT [FK_SAET_ACTUACION_SAET_OFICINA] FOREIGN KEY([ofic_icodigo_oficina_apostillador])
REFERENCES [dbo].[SAET_OFICINA] ([ofic_icodigo_oficina])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_ACTUACION_SAET_PARAMETRO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]'))
ALTER TABLE [dbo].[SAET_ACTUACION]  WITH CHECK ADD  CONSTRAINT [FK_SAET_ACTUACION_SAET_PARAMETRO] FOREIGN KEY([para_icodigo_tipo_documento])
REFERENCES [dbo].[SAET_PARAMETRO] ([para_icodigo_parametro])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_ACTUACION_SAET_PERFIL_USUARIO_OFICINA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]'))
ALTER TABLE [dbo].[SAET_ACTUACION]  WITH NOCHECK ADD  CONSTRAINT [FK_SAET_ACTUACION_SAET_PERFIL_USUARIO_OFICINA] FOREIGN KEY([peuo_iperfil_usuario_oficina_modifica])
REFERENCES [dbo].[SAET_PERFIL_USUARIO_OFICINA] ([peuo_codigo_perfil_usuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_ACTUACION_SAET_PERFIL_USUARIO_OFICINA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_ACTUACION]'))
ALTER TABLE [dbo].[SAET_ACTUACION]  WITH CHECK ADD  CONSTRAINT [FK_SAET_ACTUACION_SAET_PERFIL_USUARIO_OFICINA1] FOREIGN KEY([peuo_iperfil_usuario_oficina_crea])
REFERENCES [dbo].[SAET_PERFIL_USUARIO_OFICINA] ([peuo_codigo_perfil_usuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_PERFIL_SAET_MODULO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL]'))
ALTER TABLE [dbo].[SAET_PERFIL]  WITH CHECK ADD  CONSTRAINT [FK_SAET_PERFIL_SAET_MODULO] FOREIGN KEY([modu_icodigo_modulo])
REFERENCES [dbo].[SAET_MODULO] ([modu_icodigo_modulo])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_PERFIL_USUARIO_OFICINA_SAET_PERFIL]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_USUARIO_OFICINA]'))
ALTER TABLE [dbo].[SAET_PERFIL_USUARIO_OFICINA]  WITH CHECK ADD  CONSTRAINT [FK_SAET_PERFIL_USUARIO_OFICINA_SAET_PERFIL] FOREIGN KEY([perf_icodigo_perfil])
REFERENCES [dbo].[SAET_PERFIL] ([perf_icodigo_perfil])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_PERFIL_USUARIO_OFICINA_SAET_USUARIO_OFICINA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_USUARIO_OFICINA]'))
ALTER TABLE [dbo].[SAET_PERFIL_USUARIO_OFICINA]  WITH CHECK ADD  CONSTRAINT [FK_SAET_PERFIL_USUARIO_OFICINA_SAET_USUARIO_OFICINA] FOREIGN KEY([usof_icodigo_usuario_oficina])
REFERENCES [dbo].[SAET_USUARIO_OFICINA] ([usof_icodigo_usuario_oficina])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_USUARIO_SAET_PER9SONA1_]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_USUARIO]'))
ALTER TABLE [dbo].[SAET_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_SAET_USUARIO_SAET_PER9SONA1_] FOREIGN KEY([usua_icodigo_usuario])
REFERENCES [dbo].[SAET_PERSONA] ([pers_icodigo_persona])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_DOCUMENTO_SAET_PERSONA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_DOCUMENTO]'))
ALTER TABLE [dbo].[SAET_DOCUMENTO]  WITH CHECK ADD  CONSTRAINT [FK_SAET_DOCUMENTO_SAET_PERSONA] FOREIGN KEY([pers_icodigo_persona])
REFERENCES [dbo].[SAET_PERSONA] ([pers_icodigo_persona])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_APOSTILLADOR_SAET_PARAMETRO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_APOSTILLADOR]'))
ALTER TABLE [dbo].[SAET_APOSTILLADOR]  WITH NOCHECK ADD  CONSTRAINT [FK_SAET_APOSTILLADOR_SAET_PARAMETRO] FOREIGN KEY([para_icodigo_cargo])
REFERENCES [dbo].[SAET_PARAMETRO] ([para_icodigo_parametro])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_APOSTILLADOR_SAET_PERSONA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_APOSTILLADOR]'))
ALTER TABLE [dbo].[SAET_APOSTILLADOR]  WITH CHECK ADD  CONSTRAINT [FK_SAET_APOSTILLADOR_SAET_PERSONA] FOREIGN KEY([apos_icodigo_apostillador])
REFERENCES [dbo].[SAET_PERSONA] ([pers_icodigo_persona])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DETALLE_DE_OPCIONES_PERFIL__ASIGNADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_USUARIO_OFICINA_DETALLE]'))
ALTER TABLE [dbo].[SAET_PERFIL_USUARIO_OFICINA_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_DE_OPCIONES_PERFIL__ASIGNADO] FOREIGN KEY([opci_icodigo_opcion])
REFERENCES [dbo].[SAET_OPCION] ([opci_icodigo_opcion])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DETALLE_OPCIONES__X__PERFIL_USUARIO_UBICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_USUARIO_OFICINA_DETALLE]'))
ALTER TABLE [dbo].[SAET_PERFIL_USUARIO_OFICINA_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_OPCIONES__X__PERFIL_USUARIO_UBICACION] FOREIGN KEY([peuo_icodigo_perfil_usuario])
REFERENCES [dbo].[SAET_PERFIL_USUARIO_OFICINA] ([peuo_codigo_perfil_usuario])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__SAET_PERF__perf___2F10007B]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_OPCION]'))
ALTER TABLE [dbo].[SAET_PERFIL_OPCION]  WITH CHECK ADD FOREIGN KEY([perf_icodigo_perfil])
REFERENCES [dbo].[SAET_PERFIL] ([perf_icodigo_perfil])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_PERFIL_OPCION_SAET_OPCION]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERFIL_OPCION]'))
ALTER TABLE [dbo].[SAET_PERFIL_OPCION]  WITH CHECK ADD  CONSTRAINT [FK_SAET_PERFIL_OPCION_SAET_OPCION] FOREIGN KEY([opci_icodigo_opcion])
REFERENCES [dbo].[SAET_OPCION] ([opci_icodigo_opcion])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_PERSONA_SAET_PAhIS]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_PERSONA]'))
ALTER TABLE [dbo].[SAET_PERSONA]  WITH NOCHECK ADD  CONSTRAINT [FK_SAET_PERSONA_SAET_PAhIS] FOREIGN KEY([pais_icodigo_pais_nacimiento])
REFERENCES [dbo].[SAET_PAIS] ([pais_icodigo_pais])
GO
ALTER TABLE [dbo].[SAET_PERSONA] CHECK CONSTRAINT [FK_SAET_PERSONA_SAET_PAhIS]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_OFICINA_PADRE]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_OFICINA]'))
ALTER TABLE [dbo].[SAET_OFICINA]  WITH NOCHECK ADD  CONSTRAINT [FK_SAET_OFICINA_PADRE] FOREIGN KEY([ofic_icodigo_oficina_padre])
REFERENCES [dbo].[SAET_OFICINA] ([ofic_icodigo_oficina])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_OFICINA_SAET_PAIS]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_OFICINA]'))
ALTER TABLE [dbo].[SAET_OFICINA]  WITH CHECK ADD  CONSTRAINT [FK_SAET_OFICINA_SAET_PAIS] FOREIGN KEY([pais_icodigo_pais])
REFERENCES [dbo].[SAET_PAIS] ([pais_icodigo_pais])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_FIRMANTE_SAET_PARAMETRO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_FIRMANTE]'))
ALTER TABLE [dbo].[SAET_FIRMANTE]  WITH CHECK ADD  CONSTRAINT [FK_SAET_FIRMANTE_SAET_PARAMETRO] FOREIGN KEY([para_icodigo_cargo])
REFERENCES [dbo].[SAET_PARAMETRO] ([para_icodigo_parametro])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_FIRMANTE_SAET_PARAMETRO1]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_FIRMANTE]'))
ALTER TABLE [dbo].[SAET_FIRMANTE]  WITH CHECK ADD  CONSTRAINT [FK_SAET_FIRMANTE_SAET_PARAMETRO1] FOREIGN KEY([para_icodigo_entidad])
REFERENCES [dbo].[SAET_PARAMETRO] ([para_icodigo_parametro])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SAET_MODULO_SAET_SISTEMA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SAET_MODULO]'))
ALTER TABLE [dbo].[SAET_MODULO]  WITH CHECK ADD  CONSTRAINT [FK_SAET_MODULO_SAET_SISTEMA] FOREIGN KEY([sist_icodigo_sistema])
REFERENCES [dbo].[SAET_SISTEMA] ([sist_icodigo])
