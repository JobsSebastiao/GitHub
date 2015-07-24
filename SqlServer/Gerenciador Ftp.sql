--##########################################################################################################################
--# Criar tabela de configurações do Ftp                                                                                   #
--# 17/06/2015												              												   #		
--# Sebastiao Martins 																									   #	
--##########################################################################################################################

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id('tb0077_FtpConfig'))
 
	BEGIN

		CREATE TABLE [dbo].[tb0077_FtpConfig](

			[codigoFTPCONFIG]					[int] IDENTITY(1,1) NOT NULL,
			[siteFTPCONFIG]						[nvarchar](100)		NOT NULL,
			[usuarioFTPCONFIG]					[nvarchar](100)		NOT NULL,
			[senhaFTPCONFIG]					[nvarchar](20)		NOT NULL,
			[ftpscriptFTPCONFIG]				[nvarchar](150)		    NULL,
			[ftpversaoFTPCONFIG]				[nvarchar](150)		    NULL,
			[ftpdiversosFTPCONFIG]				[nvarchar](150)		    NULL,
			[maquinascriptFTPCONFIG]			[nvarchar](150)		    NULL,
			[maquinaversaoFTPCONFIG]			[nvarchar](150)		    NULL,
			[maquinadiversosFTPCONFIG]			[nvarchar](150)		    NULL,


		) ON [PRIMARY]

	END 

GO 

 INSERT INTO  tb0077_FtpConfig 
           VALUES ('ftp.tecwarebrasil.com.br','tecwarebrasil.com.br','jx6ew7p$',
                   'ftp://ftp.tecwarebrasil.com.br/MakeTecware/Scripts/','ftp://ftp.tecwarebrasil.com.br/MakeTecware/Versao/','ftp://ftp.tecwarebrasil.com.br/MakeTecware/Diversos/'
				   ,'C:\Titanium\Scripts','C:\Titanium\Versao','C:\Titanium\arquivos')
GO 

--##########################################################################################################################
--# Realiza o backup da base informormada                                                                                  #
--# 25/06/2015												              												   #		
--# Sebastioa Martins 																									   #	
--##########################################################################################################################


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('sps0071_BackupBeforeScript'))

   DROP PROCEDURE sps0071_BackupBeforeScript

GO 

	CREATE PROCEDURE sps0071_BackupBeforeScript
	@BASE NVARCHAR(100),
	@PATHFORBACKUP  NVARCHAR(100)

	AS

	BEGIN 

		DECLARE @FILEBACKUP AS NVARCHAR(200)
		DECLARE @BACKUPDATE AS DATETIME
		DECLARE @INDEX AS INT

		set @INDEX = 0

		--Seta o caminho e o nome do arquivo para o backup
		SET @FILEBACKUP = @PATHFORBACKUP + @BASE +'ScriptUpdate_' + CONVERT(NVARCHAR(10),GETDATE(),112) +'.BAK'

	  
				BACKUP DATABASE @Base
				TO DISK = @FileBackup
				   WITH FORMAT,
					  MEDIANAME = 'BackupBeforeScript',
					  NAME = 'Full Backup Before Script Update';

	END 


GO

--##########################################################################################################################
--# Verifica se o ultimo script da base informada foi realizado a menos de 20 minutos                                      #
--# 25/06/2015												              												   #		
--# Sebastiao Martins 																									   #	
--##########################################################################################################################

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('fn0071_VerificarScript'))

   DROP FUNCTION fn0071_VerificarScript

GO 

	CREATE FUNCTION fn0071_VerificarScript(@BASE NVARCHAR(100))

	RETURNS BIT

	AS

	BEGIN 
    
		DECLARE @BACKUPDATE AS DATETIME
		DECLARE @INDEX AS INT

		set @INDEX = 0

			--Recupera a data do último BackUp
			SET @BACKUPDATE = (SELECT 
								COALESCE(CONVERT(datetime, MAX(BUS.BACKUP_FINISH_DATE) ),'-') AS LASTBACKUPTIME
								FROM SYS.SYSDATABASES SDB
								LEFT OUTER JOIN MSDB.DBO.BACKUPSET BUS ON BUS.DATABASE_NAME = SDB.NAME
								WHERE SDB.NAME = @BASE
								GROUP BY SDB.NAME,SDB.FILENAME)
         
			--Verifica se o backup está em um intervalo de tempo de 20 minutos 
			IF ((SELECT DATEDIFF(MINUTE,@BACKUPDATE,getDATE())) < 20 )
				BEGIN 
					SET @index = 1
				END
			ELSE 
				BEGIN
					SET @index = 0
				END

		RETURN @index

	END
