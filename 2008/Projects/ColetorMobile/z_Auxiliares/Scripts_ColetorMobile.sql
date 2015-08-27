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
	operadorPROPOSTA					INT
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


CREATE VIEW vwMobile_tb1601_Proposta

AS

SELECT codigoPROPOSTA,numeroPROPOSTA, CONVERT(nvarchar, P.dataLIBERACAOPROPOSTA,103)  +' '+ CONVERT(nvarchar, P.dataLIBERACAOPROPOSTA,108) as dataLIBERACAOPROPOSTA,clientePROPOSTA AS clientePROPOSTA, razaoEMPRESA ,
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

--NOVA TABELA PARA GERENCIAMENTO DE PROPOSTA NO PIKING MOBILE.
CREATE TABLE tb1651_Liberacoes_Mobile
(
	propostaLIBERACAOMOBILE INT NOT NULL,
	usuarioLIBERACAOMOBILE INT NOT NULL,
	statusLIBERACAOMOBILE SMALLINT NOT NULL DEFAULT(0)
)
