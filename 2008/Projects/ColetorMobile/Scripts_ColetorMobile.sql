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
	xmlSequenciaITEMPROPOSTA		NVARCHAR(500) 
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
	itempropostaETIQUETA			NVARCHAR(20) NOT NULL,
	volumeETIQUETA	      			INT NOT NULL,
	quantidadeETIQUETA	      		REAL NOT NULL,
	sequenciaETIQUETA    			INT NOT NULL
)



 --//CARGA DE TESTES

Insert INTO tb0001_Propostas VALUES (75514,'75514-1','20/05/2015 10:37:34',6191,'DIEGO ALEJANDRO RECZEK',0,114)

GO 

INSERT INTO tb0002_ItensProposta(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA,statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, 
lotereservaITEMPROPOSTA) VALUES (1143154,75514,400,0,1558,46040)

GO 

INSERT INTO tb0002_ItensProposta(codigoITEMPROPOSTA, propostaITEMPROPOSTA, quantidadeITEMPROPOSTA,statusseparadoITEMPROPOSTA, codigoprodutoITEMPROPOSTA, 
lotereservaITEMPROPOSTA) VALUES (1143200,75514,200,0,20683,20620)

GO 

INSERT INTO tb0003_Produtos (codigoPRODUTO, ean13PRODUTO, partnumberPRODUTO, descricaoPRODUTO, codigolotePRODUTO,identificacaolotePRODUTO, 
codigolocalPRODUTO, nomelocalPRODUTO)VALUES (1558,'7895479000995','7085','Soquete Pisca Dianteiro General Motor Nº194.633903',46040,'LT-27796',443,'02D')

GO 

INSERT INTO tb0003_Produtos (codigoPRODUTO, ean13PRODUTO, partnumberPRODUTO, descricaoPRODUTO, codigolotePRODUTO,identificacaolotePRODUTO, 
codigolocalPRODUTO, nomelocalPRODUTO)VALUES (20683,'7895479042575','8031','Chicote Soquete Luz Trazeira - Bravo - Linea - 2 Vias',20620,'LT-10051',996,'F6A')

GO 

INSERT INTO tb0003_Produtos (codigoPRODUTO, ean13PRODUTO, partnumberPRODUTO, descricaoPRODUTO, codigolotePRODUTO,identificacaolotePRODUTO, 
codigolocalPRODUTO, nomelocalPRODUTO)VALUES (1558,'7895479000995','7085','Soquete Pisca Dianteiro General Motor Nº194.633903',46040,'LT-27796',827,'M2')


CREATE VIEW vwMobile_tb1601_Proposta

AS

SELECT codigoPROPOSTA,numeroPROPOSTA, CONVERT(nvarchar, P.dataLIBERACAOPROPOSTA,103)  +' '+ CONVERT(nvarchar, P.dataLIBERACAOPROPOSTA,108) as dataLIBERACAOPROPOSTA,clientePROPOSTA AS clientePROPOSTA, razaoEMPRESA ,
COALESCE(ordemseparacaoimpressaPROPOSTA,0) AS ordemseparacaoimpressaPROPOSTA, P.prioridadeLIBERACAOPROPOSTA,0 as volumesPROPOSTA
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
ORDER BY  P.prioridadeLIBERACAOPROPOSTA ASC,P.dataLIBERACAOPROPOSTA ASC

UPDATE tb1611_Liberacoes_Proposta 
SET prioridadeLIBERACAOPROPOSTA = 0
WHERE propostaLIBERACAOPROPOSTA IN (78691)


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




---                            ////////////////EXEMPLOS /////////////////////////

SELECT TOP (1) TB_PROP.codigoPROPOSTA, TB_PROP.numeroPROPOSTA, TB_PROP.dataliberacaoPROPOSTA,TB_PROP.clientePROPOSTA, TB_PROP.razaoclientePROPOSTA,
TB_PROP.ordemseparacaoimpressaPROPOSTA, TB_ITEMPROPOP.codigoITEMPROPOSTA, TB_ITEMPROPOP.propostaITEMPROPOSTA, TB_ITEMPROPOP.quantidadeITEMPROPOSTA,
TB_ITEMPROPOP.statusseparadoITEMPROPOSTA, TB_ITEMPROPOP.lotereservaITEMPROPOSTA, TB_ITEMPROPOP.localloteITEMPROPOSTA, 
TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA, TB_PROD.ean13PRODUTO, TB_PROD.partnumberPRODUTO,TB_PROD.descricaoPRODUTO, TB_PROD.identificacaolotePRODUTO, 
TB_PROD.codigolotePRODUTO, TB_PROD.codigolocalPRODUTO, TB_PROD.nomelocalPRODUTO, 
SUM(TB_ITEMPROPOP.quantidadeITEMPROPOSTA) AS qtdPECAS,  
COUNT(*) AS qtdITENS  
FROM   tb0001_Propostas AS TB_PROP  
INNER JOIN tb0002_ItensProposta AS TB_ITEMPROPOP ON TB_PROP.codigoPROPOSTA = TB_ITEMPROPOP.propostaITEMPROPOSTA 
INNER JOIN tb0003_Produtos AS TB_PROD ON TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA = TB_PROD.codigoPRODUTO 
WHERE TB_ITEMPROPOP.statusseparadoITEMPROPOSTA = 0 
GROUP BY TB_PROP.codigoPROPOSTA, TB_PROP.numeroPROPOSTA, TB_PROP.dataliberacaoPROPOSTA,TB_PROP.clientePROPOSTA, TB_PROP.razaoclientePROPOSTA, 
TB_PROP.ordemseparacaoimpressaPROPOSTA,TB_ITEMPROPOP.codigoITEMPROPOSTA, TB_ITEMPROPOP.propostaITEMPROPOSTA, TB_ITEMPROPOP.quantidadeITEMPROPOSTA, 
TB_ITEMPROPOP.statusseparadoITEMPROPOSTA,TB_ITEMPROPOP.lotereservaITEMPROPOSTA, TB_ITEMPROPOP.localloteITEMPROPOSTA,  
TB_ITEMPROPOP.codigoprodutoITEMPROPOSTA,TB_PROD.ean13PRODUTO, TB_PROD.partnumberPRODUTO,TB_PROD.descricaoPRODUTO, 
TB_PROD.identificacaolotePRODUTO, TB_PROD.codigolotePRODUTO, TB_PROD.codigolocalPRODUTO,TB_PROD.nomelocalPRODUTO
ORDER BY TB_PROD.nomelocalPRODUTO ASC

SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD,
COALESCE(localLOTELOCAL,0) AS localLOTELOCAL,
COALESCE(nomeLOCAL,'ND') AS nomeLOCAL
FROM tb1206_Reservas (NOLOCK) 
INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO 
LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL 
LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL 
WHERE propostaITEMPROPOSTA = 78691 AND tipodocRESERVA = 1602 AND statusITEMPROPOSTA = 3 AND separadoITEMPROPOSTA = 0  
GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO,loteRESERVA,
localLOTELOCAL,nomeLOCAL 
ORDER BY nomeLOCAL ASC

---SELECT COM LOCALIZAÇÂO DIFERENTE
SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD,
loteRESERVA,COALESCE(localLOTELOCAL,0) AS localLOTELOCAL,COALESCE(nomeLOCAL,'ND') AS nomeLOCAL,LOCALIZACAO = dbo.[fn0501_Local_Produto](produtoRESERVA)
FROM tb1206_Reservas (NOLOCK) 
INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO 
LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL 
LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL 
WHERE propostaITEMPROPOSTA = 75514 AND tipodocRESERVA = 1602 AND statusITEMPROPOSTA = 3 AND separadoITEMPROPOSTA = 0  
GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,nomePRODUTO,partnumberPRODUTO,loteRESERVA,localLOTELOCAL,
nomeLOCAL ORDER BY nomeLOCAL ASC

SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD 
,loteRESERVA,localLOTELOCAL,nomeLOCAL
FROM tb1206_Reservas (NOLOCK) 
INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO
LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL
LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL
WHERE propostaITEMPROPOSTA = 78680
AND tipodocRESERVA = 1602 
AND statusITEMPROPOSTA = 3 
AND separadoITEMPROPOSTA = 0  
GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,nomePRODUTO,
         partnumberPRODUTO,loteRESERVA,localLOTELOCAL,nomeLOCAL
ORDER BY nomeLOCAL ASC


	 
--PADRÃO DO QR-CODE:

--|PNUMBER:8030|DESCRICAO:Chicote Soquete luz|EAN13:7895479042576|LOTE:LT-10051|SEQ:12340|QTD:25

--Partnumber - PartNumber Do item da Proposta
--DescricaoProduto - Nome do Produto
--Ean13 - Ean do Produto
--Lote - Descricao do Lote
--Sequencia - Sequência da Etiqueta 
--Quantidade - Quantidade de Produtos a serem validados na leitura da etiqueta.



--Separar as variáveis
--Verificar se existe na tb000X_Sequencia
--Case exista 
--= mensagem de erro
--ELSE
--Inclui o item na tb000X_Sequencia
--Atualiza a quantidade da tela
	
--If Quantidade = 0
--MontaXML item proposta
--Grava o XML das sequencias do item no item da proposta
--Muda status para separado
--Carrega Proximo item
--End if

--If Itens Faltantes = 0
--Termina o processo
--End if
--End
	

--EXEMPLO XML ITEM PROPOSTA
--<Item id=1>
--<Seq>
--<Id>12345</Id>
--<Id>12346</Id>
--<Id>12347</Id>
--<Id>12348</Id>
--<Id>12350</Id>
--</Seq>
--</Item>

--<Item id=2><Seq><Id>12375</Id><Id>12376</Id><Id>12377</Id><Id>12378</Id><Id>12350</Id></Seq>
--</Item>	 







