DROP TABLE tb0004_Etiquetas
DROP TABLE tb0003_Produtos
DROP TABLE tb0002_ItensProposta
DROP TABLE tb0001_Propostas


CREATE TABLE tb0001_Propostas 
(
	codigoPROPOSTA						INT NOT NULL CONSTRAINT PKPropostas PRIMARY KEY,
	numeroPROPOSTA						NVARCHAR(20) NOT NULL,
	dataliberacaoPROPOSTA				NVARCHAR(20) NOT NULL,
	clientePROPOSTA						INT NOT NULL,
	razaoclientePROPOSTA				NVARCHAR(200),
	volumesPROPOSTA              		SMALLINT,
	operadorPROPOSTA					INT,
	codigopickingmobilePROPOSTA         INT
)

GO 

CREATE TABLE tb0002_ItensProposta (
	codigoITEMPROPOSTA				INT NOT NULL CONSTRAINT PKItensProposta PRIMARY KEY,
	propostaITEMPROPOSTA			INT ,
	quantidadeITEMPROPOSTA			REAL,
	statusseparadoITEMPROPOSTA		SMALLINT,
	codigoprodutoITEMPROPOSTA		INT,
	lotereservaITEMPROPOSTA			INT,
	xmlSequenciaITEMPROPOSTA		NTEXT
		 )

GO

CREATE TABLE tb0003_Produtos (
	codigoPRODUTO				INT NOT NULL ,
	ean13PRODUTO				NVARCHAR(15) NOT NULL ,
	partnumberPRODUTO			NVARCHAR(100) ,
	descricaoPRODUTO			NVARCHAR(100) ,
	codigolotePRODUTO			INT,
	identificacaolotePRODUTO	NVARCHAR(100) ,
	codigolocalPRODUTO			INT , 
	nomelocalPRODUTO			NVARCHAR(100)   )

GO    

CREATE TABLE tb0004_Etiquetas 
(
	codigoETIQUETA				    INT IDENTITY(1,1) NOT NULL CONSTRAINT PKEtiquetas PRIMARY KEY,
	eanItempropostaETIQUETA			NVARCHAR(20) NOT NULL,
	volumeETIQUETA	      			INT NOT NULL,
	quantidadeETIQUETA	      		REAL NOT NULL,
	sequenciaETIQUETA    			INT NOT NULL
)



 --//CARGA DE TESTES

Insert INTO tb0001_Propostas VALUES (75514,'75514-1','20/05/2015 10:37:34',6191,'DIEGO ALEJANDRO RECZEK',0,114)

GO 

		-- INCLUSÃO CAMPOS EM TABELAS ---
ALTER TABLE tb1611_Liberacoes_Proposta ADD prioridadeLIBERACAOPROPOSTA INT NULL

ALTER TABLE tb1602_Itens_Proposta ADD xmlsequenciaITEMPROPOSTA NTEXT NULL

--INICIAL DESATIVADA
CREATE VIEW vwMobile_tb1601_Proposta

AS

SELECT codigoPROPOSTA,numeroPROPOSTA, CONVERT(NVARCHAR, P.dataLIBERACAOPROPOSTA,103)  +' '+ CONVERT(NVARCHAR, P.dataLIBERACAOPROPOSTA,108) as dataLIBERACAOPROPOSTA,clientePROPOSTA AS clientePROPOSTA, razaoEMPRESA ,
COALESCE(ordemseparacaoimpressaPROPOSTA,0) AS ordemseparacaoimpressaPROPOSTA, P.prioridadeLIBERACAOPROPOSTA AS Prioridade,0 as volumesPROPOSTA
FROM tb1601_Propostas (NOLOCK) 
INNER JOIN tb1611_Liberacoes_Proposta P (NOLOCK) ON P.propostaLIBERACAOPROPOSTA = codigoPROPOSTA 
LEFT JOIN tb1611_Liberacoes_Proposta C (NOLOCK) ON C.propostaLIBERACAOPROPOSTA = codigoPROPOSTA 
LEFT JOIN tb0301_Empresas (NOLOCK) ON clientePROPOSTA = codigoEMPRESA
WHERE statusPROPOSTA = 1 
AND P.liberacaoLIBERACAOPROPOSTA = 1 
AND C.liberacaoLIBERACAOPROPOSTA = 2 
AND P.liberadoLIBERACAOPROPOSTA = 1  
AND C.liberadoLIBERACAOPROPOSTA = 0
AND P.prioridadeLIBERACAOPROPOSTA >= 0
--ORDER BY  Prioridade ASC,dataLIBERACAOPROPOSTA ASC


--ATUAL 
CREATE VIEW vwMobile_tb1601_Proposta

AS

SELECT codigoPICKINGMOBILE,
codigoPROPOSTA,numeroPROPOSTA, CONVERT(NVARCHAR, P.dataLIBERACAOPROPOSTA,103)  +' '+ CONVERT(NVARCHAR, P.dataLIBERACAOPROPOSTA,108) as dataLIBERACAOPROPOSTA,clientePROPOSTA AS clientePROPOSTA, razaoEMPRESA ,
COALESCE(ordemseparacaoimpressaPROPOSTA,0) AS ordemseparacaoimpressaPROPOSTA, P.prioridadeLIBERACAOPROPOSTA AS Prioridade,0 as volumesPROPOSTA
FROM tb1601_Propostas (NOLOCK) 
INNER JOIN tb1611_Liberacoes_Proposta P (NOLOCK) ON P.propostaLIBERACAOPROPOSTA = codigoPROPOSTA 
LEFT JOIN tb1611_Liberacoes_Proposta C (NOLOCK) ON C.propostaLIBERACAOPROPOSTA = codigoPROPOSTA 
LEFT JOIN tb0301_Empresas (NOLOCK) ON clientePROPOSTA = codigoEMPRESA
LEFT JOIN tb1651_Picking_Mobile ON propostaPICKINGMOBILE = codigoPROPOSTA AND statusPICKINGMOBILE = 0
WHERE statusPROPOSTA = 1 
AND P.liberacaoLIBERACAOPROPOSTA = 1 
AND C.liberacaoLIBERACAOPROPOSTA = 2 
AND P.liberadoLIBERACAOPROPOSTA = 1  
AND C.liberadoLIBERACAOPROPOSTA = 0
AND P.prioridadeLIBERACAOPROPOSTA >= 0
AND (codigoPROPOSTA NOT IN (
								SELECT propostaPICKINGMOBILE	
								FROM tb1651_Picking_Mobile 
								WHERE statusPICKINGMOBILE > 0
								
							))
OR codigoPROPOSTA IN (
						SELECT propostaPICKINGMOBILE	
						FROM tb1651_Picking_Mobile 
						WHERE statusPICKINGMOBILE =0
								
					 )
AND P.dataLIBERACAOPROPOSTA IS NOT NULL
GROUP BY codigoPICKINGMOBILE,codigoPROPOSTA,numeroPROPOSTA, CONVERT(NVARCHAR, P.dataLIBERACAOPROPOSTA,103)  +' '+ CONVERT(NVARCHAR, P.dataLIBERACAOPROPOSTA,108)
,clientePROPOSTA , razaoEMPRESA ,COALESCE(ordemseparacaoimpressaPROPOSTA,0), P.prioridadeLIBERACAOPROPOSTA ,volumesPROPOSTA 



--NOVA TABELA PARA GERENCIAMENTO DE PROPOSTA NO PIKING MOBILE.
CREATE TABLE tb1651_Picking_Mobile
(
    codigoPICKINGMOBILE int identity(1,1),
	propostaPICKINGMOBILE INT NOT NULL,
	usuarioPICKINGMOBILE INT NOT NULL,
	statusPICKINGMOBILE SMALLINT NOT NULL DEFAULT(0),
	horainicioPICKINGMOBILE DATETIME,
	horafimPICKINGMOBILE DATETIME
	CONSTRAINT PKpickingMobileID PRIMARY KEY (codigoPICKINGMOBILE)
	CONSTRAINT FKpropostaPicking FOREIGN KEY (propostaPICKINGMOBILE)
	REFERENCES tb1601_Propostas(codigoPROPOSTA)
)


----NOA UTILIZO NO CODIO MOBILE
--########################################################################################################################################
--# Atualiza os registros sem vínculos para a embalagem padrão
--# Gabriel
--# dd/mm/yyyy
--########################################################################################################################################

IF ( SELECT COUNT(codigoEMBALAGEMPRODUTO)
	 FROM tb0504_Embalagens_Produtos
	 LEFT JOIN tb0545_Embalagens ON codigoEMBALAGEM = embalagemEMBALAGEMPRODUTO
	 WHERE embalagemEMBALAGEMPRODUTO IS NULL
    ) > 0

BEGIN

	 UPDATE tb0504_Embalagens_Produtos
	 SET embalagemEMBALAGEMPRODUTO = (SELECT codigoEMBALAGEM
			  FROM tb0545_Embalagens
			  WHERE nomeEMBALAGEM = 'Padrão'
			 )
	 WHERE embalagemEMBALAGEMPRODUTO IS NULL

END

GO

--INFORMAÇÔES SOBRE OS ITENS DA PROPOSTA
SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD
,quantidadeEMBALAGEMPRODUTO AS QtdEmbalagem
,dbo.fn1211_LotesReservaProduto(produtoRESERVA,propostaITEMPROPOSTA) AS lotesRESERVA
,DBO.fn1211_LocaisLoteProduto(produtoRESERVA,dbo.fn1211_LotesReservaProduto(produtoRESERVA,propostaITEMPROPOSTA)) AS locaisLOTES
FROM tb1206_Reservas (NOLOCK)
--,LOTEreserva
INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA
INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO 
INNER JOIN tb0504_Embalagens_Produtos ON codigobarrasEMBALAGEMPRODUTO = ean13PRODUTO
LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL 
LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL 
WHERE propostaITEMPROPOSTA = 80471 
AND tipodocRESERVA = 1602 
AND statusITEMPROPOSTA = 3
AND separadoITEMPROPOSTA = 0  
GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,nomePRODUTO,partnumberPRODUTO
,quantidadeEMBALAGEMPRODUTO,codigobarrasEMBALAGEMPRODUTO
ORDER BY codigoPRODUTO



---Informações sobre cada produto exsitente na proposta informada
CREATE FUNCTION fn0003_informacoesProdutos ( @codigoProposta int )

RETURNS @InformationTable TABLE
   (
    codigoPRODUTO				INT,
    partnumberPRODUTO			NVARCHAR(50),
    nomePRODUTO					NVARCHAR(150),
    ean13PRODUTO				NVARCHAR(15),
    codigolotePRODUTO			INT,
	identificacaolotePRODUTO	NVARCHAR(50),
	codigolocalPRODUTO			INT,
	nomelocalPRODUTO			NVARCHAR(20)
   )
AS
BEGIN
   INSERT @InformationTable
        
			SELECT codigoPRODUTO,partnumberPRODUTO,nomePRODUTO,ean13PRODUTO,codigoLOTE, identificacaoLOTE,codigoLOCAL,nomeLOCAL
			FROM tb1205_Lotes
			INNER JOIN tb0501_Produtos ON produtoLOTE = codigoPRODUTO
			INNER JOIN tb0301_Empresas ON codigoEMPRESA = empresaLOTE
			INNER JOIN tb1207_Lotes_Armazens ON codigoLOTE = loteLOTEARMAZEM
			INNER JOIN tb1203_Armazens ON armazemLOTEARMAZEM = codigoARMAZEM
			INNER JOIN tb1201_Estoque ON produtoESTOQUE = produtoLOTEARMAZEM
			INNER JOIN tb1212_Lotes_Locais (NOLOCK) ON codigoLOTE = loteLOTELOCAL AND  codigoLOTE IN  
																									(
																									SELECT loteRESERVA
																									FROM tb1206_Reservas (NOLOCK) 
																									INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
																									INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO
																									INNER JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL
																									INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL
																									WHERE propostaITEMPROPOSTA = @codigoProposta
																									AND tipodocRESERVA = 1602 
																									AND statusITEMPROPOSTA = 3 
																									AND separadoITEMPROPOSTA = 0
																									)
			INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL 
			WHERE codigoPRODUTO IN (   
									SELECT produtoRESERVA AS codigoPRODUTO
									FROM tb1206_Reservas (NOLOCK) 
									INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
									INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO
									INNER JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL
									INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL
									WHERE propostaITEMPROPOSTA = @codigoProposta
									AND tipodocRESERVA = 1602 
									AND statusITEMPROPOSTA = 3 
				  					AND separadoITEMPROPOSTA = 0  
								)
   RETURN
END



---FUNCAO PARA RETORNAR OS LOCAIS DE ARMAZENAMENTO DO PRODUTO.
CREATE FUNCTION fn1211_LocaisLoteProduto(@codigoPRODUTO int,@lotePRODUTO int)

RETURNS NVARCHAR(20)

BEGIN
    
	DECLARE @Local NVARCHAR(20)
	DECLARE @LocalNames NVARCHAR(20)

	SET @LocalNames = ' '

	DECLARE Local_Cursor CURSOR FOR 

	SELECT nomeLOCAL 
	FROM tb1205_Lotes
	INNER JOIN tb1212_Lotes_Locais ON codigoLOTE = loteLOTELOCAL
	INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL
	WHERE produtoLOTE = @codigoPRODUTO AND codigoLOTE = @lotePRODUTO 
	ORDER BY nomeLOCAL ASC

    OPEN Local_Cursor

    FETCH NEXT FROM Local_Cursor INTO @Local

    WHILE @@FETCH_STATUS = 0
    BEGIN


        SET @LocalNames =  @Local  + ',' + @LocalNames


        FETCH NEXT FROM Local_Cursor INTO @Local

    END

    CLOSE Local_Cursor
    DEALLOCATE Local_Cursor

RETURN SUBSTRING(LTRIM(RTRIM(@LocalNames)),1,LEN(LTRIM(RTRIM(@LocalNames)))-1)    

END 



---REALIZA O SPLIT DE UM TEXTO E RETORNA UMA TABELA COM ESTAS INFORMAÇÕES
CREATE FUNCTION SplitTitanium( @InputString VARCHAR(8000), @Delimiter VARCHAR(50))

RETURNS @Items TABLE (Item VARCHAR(8000))

AS
BEGIN
      IF @Delimiter = ' '
      BEGIN
            SET @Delimiter = ','
            SET @InputString = REPLACE(@InputString, ' ', @Delimiter)
      END

      IF (@Delimiter IS NULL OR @Delimiter = '')
            SET @Delimiter = ','

--INSERT INTO @Items VALUES (@Delimiter) -- Diagnostic
--INSERT INTO @Items VALUES (@InputString) -- Diagnostic

      DECLARE @Item                 VARCHAR(8000)
      DECLARE @ItemList       VARCHAR(8000)
      DECLARE @DelimIndex     INT

      SET @ItemList = @InputString
      SET @DelimIndex = CHARINDEX(@Delimiter, @ItemList, 0)
      WHILE (@DelimIndex != 0)
      BEGIN
            SET @Item = SUBSTRING(@ItemList, 0, @DelimIndex)
            INSERT INTO @Items VALUES (@Item)

            -- Set @ItemList = @ItemList minus one less item
            SET @ItemList = SUBSTRING(@ItemList, @DelimIndex+1, LEN(@ItemList)-@DelimIndex)
            SET @DelimIndex = CHARINDEX(@Delimiter, @ItemList, 0)
      END -- End WHILE

      IF @Item IS NOT NULL -- At least one delimiter was encountered in @InputString
      BEGIN
            SET @Item = @ItemList
            INSERT INTO @Items VALUES (@Item)
      END

      -- No delimiters were encountered in @InputString, so just return @InputString
      ELSE INSERT INTO @Items VALUES (@InputString)

      RETURN

END
GO


------TAMBÈM REALIZA UM SPLIT MAS NAO ESTA EM USO.
CREATE FUNCTION fn1211_SplitTitanium( @frase VARCHAR(max), @delimitador VARCHAR(max) = ',') 
RETURNS @result TABLE (item VARCHAR(8000)) 

BEGIN

	DECLARE @parte VARCHAR(8000)

	WHILE CHARINDEX(@delimitador,@frase,0) <> 0

		BEGIN

			SELECT
			  @parte=RTRIM(LTRIM(
					  SUBSTRING(@frase,1,
					CHARINDEX(@delimitador,@frase,0)-1))),
			  @frase=RTRIM(LTRIM(SUBSTRING(@frase,
					  CHARINDEX(@delimitador,@frase,0)
					+ LEN(@delimitador), LEN(@frase))))
			IF LEN(@parte) > 0
			  INSERT INTO @result SELECT @parte

		END 

		IF LEN(@frase) > 0
			INSERT INTO @result SELECT @frase

	RETURN

END
GO



--======RETORNA OS LOTES DOS PRODUTOS DE UMA PROPOSTA
CREATE FUNCTION fn1211_LotesReservaProduto(@codigoPRODUTO int,@propostaReserva int)

RETURNS NVARCHAR(20)

BEGIN
    
	DECLARE @NumLote NVARCHAR(20)
	DECLARE @NumsLotes NVARCHAR(20)

	SET @NumsLotes = ' '

	DECLARE Local_Cursor CURSOR FOR 


		SELECT loteRESERVA
		FROM tb1206_Reservas (NOLOCK)
		INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA
		INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO 
		WHERE produtoRESERVA = @codigoPRODUTO
		AND propostaITEMPROPOSTA = @propostaReserva
		AND tipodocRESERVA = 1602 
		AND statusITEMPROPOSTA = 3
		AND separadoITEMPROPOSTA = 0  
		ORDER BY produtoRESERVA ASC


    OPEN Local_Cursor

    FETCH NEXT FROM Local_Cursor INTO @NumLote

    WHILE @@FETCH_STATUS = 0
    BEGIN


        SET @NumsLotes =  @NumsLotes + ',' + @NumLote


        FETCH NEXT FROM Local_Cursor INTO @NumLote

    END

    CLOSE Local_Cursor
    DEALLOCATE Local_Cursor

RETURN SUBSTRING(LTRIM(RTRIM(@NumsLotes)),2,LEN(LTRIM(RTRIM(@NumsLotes)))-1)    

END 




--=-=-=-=--=--==--=-==-=--==--==-
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
---FUNCAO PARA RETORNAR OS LOCAIS DE ARMAZENAMENTO DO PRODUTO.
CREATE FUNCTION fn1211_LocaisLoteProduto(@codigoPRODUTO INT,@lotePRODUTO NVARCHAR(10))

RETURNS NVARCHAR(20)

BEGIN
    
	DECLARE @Local NVARCHAR(20)
	DECLARE @LocalNames NVARCHAR(20)

	SET @LocalNames = ' '

	DECLARE Local_Cursor CURSOR FOR 

	SELECT nomeLOCAL 
	FROM tb1205_Lotes
	INNER JOIN tb1212_Lotes_Locais ON codigoLOTE = loteLOTELOCAL
	INNER JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL
	WHERE produtoLOTE = @codigoPRODUTO AND codigoLOTE IN (SELECT * FROM  dbo.SplitTitanium(@lotePRODUTO,',') )
	ORDER BY nomeLOCAL ASC

    OPEN Local_Cursor

    FETCH NEXT FROM Local_Cursor INTO @Local

    WHILE @@FETCH_STATUS = 0
    BEGIN


        SET @LocalNames =  @Local  + ',' + @LocalNames


        FETCH NEXT FROM Local_Cursor INTO @Local

    END

    CLOSE Local_Cursor
    DEALLOCATE Local_Cursor

RETURN SUBSTRING(LTRIM(RTRIM(@LocalNames)),1,LEN(LTRIM(RTRIM(@LocalNames)))-1)    

END 








