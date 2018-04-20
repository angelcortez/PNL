-- =============================================
-- Author:		<Angel Cortez>
-- Create date: <20 de Abril de 2018>
-- Description:	<Consulta los servidores de las unidades activas>
-- =============================================
CREATE PROCEDURE [dbo].[spPNLConsultarServidoresUnidades]
AS
    BEGIN
        SELECT  servidor.ID_UNDD AS idUnidad,
                catm.ID_MNCPIO AS idMunicipio,
                servidor.IP_SERVIDOR AS ip,
                catm.MNCPIO AS municipio
        FROM    dbo.CAT_UNIDAD_SERVIDOR servidor
                INNER JOIN dbo.CAT_MUNICIPIO catm ON catm.ID_MNCPIO = servidor.ID_MUNICIPIO
        WHERE   catm.ID_ESTDO = ( SELECT    ID_ESTDO
                                  FROM      dbo.CAT_ESTADO
                                  WHERE     ESTDO LIKE '%TAMAULIPAS%'
                                )
                AND catm.ID_PAIS = ( SELECT ID_PAIS
                                     FROM   dbo.CAT_PAIS
                                     WHERE  PAIS LIKE '%MEXICO%'
                                            AND servidor.ACTIVO = 1
                                   );  


    END;

