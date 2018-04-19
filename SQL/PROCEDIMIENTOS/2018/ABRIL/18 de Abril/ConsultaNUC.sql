CREATE procedure [dbo].[ConsultaNUC]

@IdMunicipio SMALLINT,
    @IdUnidad SMALLINT

AS
BEGIN 

-- =============================================
-- Author:		<JESUS UREÑA>
-- Create date: <18/04/2018>
-- Description:	<SE MODIFICO EL SP PARA QUE LA CONSULTA NO DIERA REGISTROS DUPLICADOS
--				 Y SE CONCATENARAN EN UN SOLO REGISTRO EN EL CASO DE QUE SE HUBIERA 
--               MAS DE UN REGISTRO EN LA MISMA CARPETA>
--		 ESTE PROCEDIMIENTO ES USADO EN LA PANTALLA UnidadPNL.aspx
-- =============================================


    CREATE TABLE #PNL_NUC_AUX
        (
          ID_CARPETA INT ,
          RAC VARCHAR(200) ,
          FECHA_RAC DATE ,
          CARPETA_INCIO VARCHAR(200) ,
          ID_MUNICIPIO INT ,
          ID_UNIDAD INT ,
          NUC VARCHAR(200) ,
          FECHA_NUC DATE ,
          ID_ESTADO_NUC INT ,
          ESTADO_CARPETA VARCHAR(200) ,
          DENUNCIANTE VARCHAR(200) ,
          IMPUTADO VARCHAR(200) ,
          OFENDIDO VARCHAR(200) ,
          fechanuc DATETIME
        );
        
    INSERT  INTO #PNL_NUC_AUX
            ( ID_CARPETA ,
              RAC ,
              FECHA_RAC ,
              CARPETA_INCIO ,
              ID_MUNICIPIO ,
              ID_UNIDAD ,
              NUC ,
              FECHA_NUC ,
              ID_ESTADO_NUC ,
              ESTADO_CARPETA ,
              DENUNCIANTE ,
              IMPUTADO ,
              OFENDIDO ,
              fechanuc
            )
            SELECT  c.ID_CARPETA ,
                    ISNULL(SUBSTRING(c.RAC, 11, 10), '') AS RAC ,
                    ISNULL(CONVERT(VARCHAR, c.FECHA_RAC, 103), '') AS FECHA_RAC ,
                    ISNULL(cc.CARPETA_INCIO, '') AS CARPETA_INCIO ,
                    cu.ID_MNCPIO AS ID_MUNICIPIO ,
                    PR.ID_UNDD ,
                    ISNULL(SUBSTRING(c.NUC, 11, 10), '') AS NUC ,
                    ISNULL(CONVERT(VARCHAR, c.FECHA_NUC, 103), ' ') AS FECHA_NUC ,
                    ISNULL(c.ID_ESTADO_NUC, '') AS ID_ESTADO_NUC ,
                    ISNULL(ce.ESTADO_CARPETA, '') AS ESTADO_CARPETA ,
                    ISNULL(UPPER(P.NOMBRE + ' ' + P.PATERNO + ' ' + P.MATERNO),
                           '') AS DENUNCIANTE ,
                    ISNULL(UPPER(PP.NOMBRE + ' ' + PP.PATERNO + ' '
                                 + PP.MATERNO), '') IMPUTADO ,
                    ISNULL(UPPER(OFENDIDO.NOMBRE + ' ' + OFENDIDO.PATERNO
                                 + ' ' + OFENDIDO.MATERNO), '') OFENDIDO ,
                    FECHA_NUC AS fechanuc
            FROM    PGJ_CARPETA c
                    LEFT OUTER JOIN CAT_CARPETA_INICIO cc ON cc.ID_CARPETA_INCIO = c.ID_FORMA_INICIO
                    LEFT OUTER  JOIN PGJ_CARPETA_PERSONA CP ON CP.ID_CARPETA = c.ID_CARPETA
                                                              AND CP.ID_TIPO_ACTOR = 1
                    LEFT OUTER  JOIN PGJ_PERSONA P ON P.ID_PERSONA = CP.ID_PERSONA
                                                      AND CP.ID_TIPO_ACTOR = 1
                    LEFT OUTER  JOIN PGJ_CARPETA_PERSONA CPP ON CPP.ID_CARPETA = c.ID_CARPETA
                                                              AND CPP.ID_TIPO_ACTOR = 3
                    LEFT OUTER  JOIN PGJ_PERSONA PP ON PP.ID_PERSONA = CPP.ID_PERSONA
                                                       AND CPP.ID_TIPO_ACTOR = 3
                    LEFT OUTER  JOIN PGJ_CARPETA_PERSONA OFCP ON OFCP.ID_CARPETA = c.ID_CARPETA
                                                              AND OFCP.ID_TIPO_ACTOR = 2
                    LEFT OUTER  JOIN PGJ_PERSONA OFENDIDO ON OFENDIDO.ID_PERSONA = OFCP.ID_PERSONA
                                                             AND OFCP.ID_TIPO_ACTOR = 2
                    INNER JOIN PGJ_NUC_TRAMITE PR ON PR.ID_CARPETA = c.ID_CARPETA
                    LEFT OUTER  JOIN CAT_ESTADO_CARPETA ce ON ce.ID_ESTADO_CARPETA = c.ID_ESTADO_NUC
                    INNER JOIN CAT_UNIDAD cu ON cu.ID_UNDD = PR.ID_UNDD
            WHERE   41 = cu.ID_MNCPIO
                    AND 80 = PR.ID_UNDD
                    AND ACTIVO_NUC = 'true'
--ORDER BY SUBSTRING(c.NUC,17,4) DESC, SUBSTRING(c.NUC,11,5) DESC
ORDER BY            fechanuc DESC;


    SELECT DISTINCT
            ax.RAC ,
            ax.ID_CARPETA,
            ax.FECHA_RAC ,
            ax.CARPETA_INCIO ,
            ax.ID_MUNICIPIO ,
            ax.ID_UNIDAD ,
            ax.NUC ,
            ax.FECHA_NUC ,
            ax.ID_ESTADO_NUC ,
            ax.ESTADO_CARPETA ,
            ( SELECT    STUFF(( SELECT DISTINCT ', ' + aux.DENUNCIANTE
                                FROM    #PNL_NUC_AUX aux
                                WHERE   aux.ID_CARPETA BETWEEN ax.ID_CARPETA AND ax.ID_CARPETA
                              FOR
                                XML PATH('')
                              ), 1, 1, '')
            ) AS DENUNCIANTE ,
            ( SELECT    STUFF(( SELECT DISTINCT ', ' + aux.IMPUTADO
                                FROM    #PNL_NUC_AUX aux
                                WHERE   aux.ID_CARPETA BETWEEN ax.ID_CARPETA AND ax.ID_CARPETA
                              FOR
                                XML PATH('')
                              ), 1, 1, '')
            ) AS IMPUTADO ,
            ( SELECT    STUFF(( SELECT DISTINCT  ', ' + aux.OFENDIDO
                                FROM    #PNL_NUC_AUX aux
                                WHERE   aux.ID_CARPETA BETWEEN ax.ID_CARPETA AND ax.ID_CARPETA
                              FOR
                                XML PATH('')
                              ), 1, 1, '')
            ) AS OFENDIDO ,
            ax.fechanuc
    FROM    #PNL_NUC_AUX ax
            LEFT JOIN dbo.PGJ_CARPETA pgjc ON pgjc.ID_CARPETA = ax.ID_CARPETA
    --WHERE   ax.ID_CARPETA BETWEEN 820 AND 829 
    --ORDER BY ax.ID_CARPETA;

--SELECT DISTINCT * FROM #PNL_NUC_AUX

ORDER BY            fechanuc DESC


    DROP TABLE #PNL_NUC_AUX;
END;

