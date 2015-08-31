SELECT codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,clientePROPOSTA,razaoEMPRESA,volumesPROPOSTA FROM vwMobile_tb1601_Proposta ORDER BY  Prioridade ASC,dataLIBERACAOPROPOSTA ASC


SELECT TOP (10) codigoPROPOSTA,numeroPROPOSTA, CONVERT(nvarchar, P.dataLIBERACAOPROPOSTA,103)  +' '+ CONVERT(nvarchar, P.dataLIBERACAOPROPOSTA,108) as dataLIBERACAOPROPOSTA,clientePROPOSTA AS clientePROPOSTA, razaoEMPRESA ,
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
ORDER BY  Prioridade ASC,P.dataLIBERACAOPROPOSTA ASC



SELECT TOP (10) codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,clientePROPOSTA,razaoEMPRESA,volumesPROPOSTA 
FROM vwMobile_tb1601_Proposta  
ORDER BY  P.prioridadeLIBERACAOPROPOSTA ASC,dataLIBERACAOPROPOSTA ASC


SP_HELPTEXT vwMobile_tb1601_Proposta

update tb1611_Liberacoes_Proposta
set prioridadeLIBERACAOPROPOSTA = 1
where propostaLIBERACAOPROPOSTA in(
80457,
80396,
80466,
80471,
76698,
80446,
75899)


SELECT TOP 1 codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,clientePROPOSTA,razaoEMPRESA,volumesPROPOSTA 
FROM vwMobile_tb1601_Proposta  
ORDER BY  Prioridade ASC,dataLIBERACAOPROPOSTA ASC 



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

--NÃO UTILIZO ESTE SELECT POIS EXISTE DUPLICIDADE DE DADOS.
SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD 
,loteRESERVA,localLOTELOCAL,nomeLOCAL
FROM tb1206_Reservas (NOLOCK) 
INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO
LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL
LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL
WHERE propostaITEMPROPOSTA = 80471
AND tipodocRESERVA = 1602 
AND statusITEMPROPOSTA = 3 
AND separadoITEMPROPOSTA = 0  
GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,nomePRODUTO,
         partnumberPRODUTO,loteRESERVA,localLOTELOCAL,nomeLOCAL
ORDER BY nomeLOCAL ASC


--ESTE SELECT É UTILIZADO PARA RETORNAR INFORMAÇÕES DOS ITENS DAS PROPOSTAS.
SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD
FROM tb1206_Reservas (NOLOCK) 
INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO 
LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL 
LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL 
WHERE propostaITEMPROPOSTA = 80471
AND tipodocRESERVA = 1602 
AND statusITEMPROPOSTA = 3 
AND separadoITEMPROPOSTA = 0  
GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,
nomePRODUTO,partnumberPRODUTO

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

PNUMBER:8098|DESCRICAO:Terminal Femea Jst 3.96 Fio 0.3 X 0.6|EAN13:7895479034365|LOTE:LT-01|SEQ:12340|QTD:2α

SELECT TOP (1) codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,clientePROPOSTA,razaoEMPRESA,volumesPROPOSTA 
FROM vwMobile_tb1601_Proposta 
ORDER BY  Prioridade ASC,dataLIBERACAOPROPOSTA ASC 


SELECT * FROM SYS.Tables t WHERE t.name LIKE '%tb16%'
ORDER BY t.name

GO
ALTER TABLE dbo.doc_exz
ADD CONSTRAINT col_b_def
DEFAULT 50 FOR column_b ;
GO


UPDATE tb1651_Picking_Mobile
SET statusPICKINGMOBILE =0
WHERE codigoPICKINGMOBILE =21

UPDATE tb1601_Propostas
SET statusProposta =1
WHERE codigoPROPOSTA = 75899

SELECT * FROM tb1651_Picking_Mobile
DELETE FROM tb1651_Picking_Mobile
SELECT MAX(codigoPICKINGMOBILE) AS maxCodigo FROM tb1651_Picking_Mobile WHERE propostaPICKINGMOBILE = 80457


SELECT TOP (1) codigoPROPOSTA,numeroPROPOSTA,dataLIBERACAOPROPOSTA,razaoEMPRESA,volumesPROPOSTA,codigoPICKINGMOBILE
FROM vwMobile_tb1601_Proposta 
ORDER BY  Prioridade ASC,dataLIBERACAOPROPOSTA ASC 

Insert INTO tb1651_Picking_Mobile(propostaPICKINGMOBILE,usuarioPICKINGMOBILE,statusPICKINGMOBILE,horainicioPICKINGMOBILE,horafimPICKINGMOBILE) 
VALUES (80396,'114','1','8/28/2015 4:04:37 PM',NULL)


UPDATE tb1651_Picking_Mobile 
SET[statusPICKINGMOBILE] = 1,
[horafimPICKINGMOBILE] = NULL 
WHERE propostaPICKINGMOBILE = 80396  AND codigoPICKINGMOBILE = 18







                SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoRESERVA AS codigoPRODUTO,nomePRODUTO,partnumberPRODUTO,statusITEMPROPOSTA,
                ean13PRODUTO,SUM(quantidadeRESERVA) AS QTD
                 FROM tb1206_Reservas (NOLOCK) 
                INNER JOIN tb1602_Itens_Proposta (NOLOCK) ON codigoITEMPROPOSTA = docRESERVA 
                INNER JOIN tb0501_Produtos (NOLOCK) ON produtoITEMPROPOSTA = codigoPRODUTO 
                LEFT JOIN tb1212_Lotes_Locais (NOLOCK) ON loteRESERVA = loteLOTELOCAL 
                LEFT JOIN tb1211_Locais ON codigoLOCAL = localLOTELOCAL 
				WHERE propostaITEMPROPOSTA  < 80446
                AND tipodocRESERVA = 1602 
                --AND statusITEMPROPOSTA = 3 
                AND separadoITEMPROPOSTA <>1  
                GROUP BY codigoITEMPROPOSTA,propostaITEMPROPOSTA,ean13PRODUTO,produtoRESERVA,produtoITEMPROPOSTA,statusITEMPROPOSTA,
                nomePRODUTO,partnumberPRODUTO
				ORDER BY codigoPRODUTO DESC



				SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,statusseparadoITEMPROPOSTA,codigoprodutoITEMPROPOSTA,xmlSequenciaITEMPROPOSTA  
				FROM tb0002_ItensProposta 
				WHERE  statusseparadoITEMPROPOSTA = 1

				select * from tb1651_Picking_Mobile

				delete FROM tb1651_Picking_Mobile

				UPDATE tb1651_Picking_Mobile
				SET statusPIcKINGMOBILE = 0
                WHERE codigoPICKINGMOBILE = 1046

				PROP 75899---
				ITENS
				1143211,1143212,1150875

				UPDATE tb1602_Itens_Proposta
				SET separadoITEMPROPOSTA = 0
				WHERE codigoITEMPROPOSTA IN (1143211,1143212,1150875)


				SELECT codigoITEMPROPOSTA,propostaITEMPROPOSTA,produtoITEMPROPOSTA,quantidadeITEMPROPOSTA,statusITEMPROPOSTA,separadoITEMPROPOSTA,xmlsequenciaITEMPROPOSTA 
				FROM tb1602_Itens_Proposta 
				WHERE propostaITEMPROPOSTA = 75899 AND codigoITEMPROPOSTA IN (1143211,1143212,1150875)





				UPDATE tb1651_Picking_Mobile 
				SET[statusPICKINGMOBILE] = 2,[horafimPICKINGMOBILE] = 8/31/2015 1:58:39 PM
				WHERE propostaPICKINGMOBILE =  AND codigoPICKINGMOBILE = 0

				UPDATE tb1651_Picking_Mobile
				SET[statusPICKINGMOBILE] = 2,[horafimPICKINGMOBILE] = '8/31/2015 2:45:12 PM' 
				WHERE propostaPICKINGMOBILE = 75899  AND codigoPICKINGMOBILE = 1046


