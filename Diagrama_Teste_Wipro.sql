/*
   sábado, 16 de janeiro de 202120:00:37
   User: 
   Server: DESKTOP-7OH55V6
   Database: TesteWipro
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.tb_Status
	(
	IdStatus int NOT NULL,
	dsStatus varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.tb_Status ADD CONSTRAINT
	PK_tb_Status PRIMARY KEY CLUSTERED 
	(
	IdStatus
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tb_Status SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tb_Status', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tb_Status', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tb_Status', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.tb_Processo
	(
	IdProcesso int NOT NULL,
	nroProcesso bigint NOT NULL,
	Autor varchar(90) NULL,
	DtEntrada date NULL,
	DtEncerramento date NULL,
	IdStatus int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.tb_Processo ADD CONSTRAINT
	PK_tb_Processo PRIMARY KEY CLUSTERED 
	(
	IdProcesso
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tb_Processo ADD CONSTRAINT
	FK_tb_Processo_tb_Status FOREIGN KEY
	(
	IdStatus
	) REFERENCES dbo.tb_Status
	(
	IdStatus
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tb_Processo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tb_Processo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tb_Processo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tb_Processo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.tb_Andamento
	(
	idAndamento int NOT NULL,
	IdProcesso int NOT NULL,
	dtAndamento date NULL,
	dsMovimento varchar(2000) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.tb_Andamento ADD CONSTRAINT
	PK_tb_Andamento PRIMARY KEY CLUSTERED 
	(
	idAndamento
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tb_Andamento ADD CONSTRAINT
	FK_tb_Andamento_tb_Processo FOREIGN KEY
	(
	IdProcesso
	) REFERENCES dbo.tb_Processo
	(
	IdProcesso
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tb_Andamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tb_Andamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tb_Andamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tb_Andamento', 'Object', 'CONTROL') as Contr_Per 