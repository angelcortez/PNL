SELECT  per.PATERNO AS APP_PATERNO ,
        per.MATERNO AS APP_MATERNO ,
        per.NOMBRE AS NOMBRE ,
        per.ID_PERSONA ,
        ( SELECT    STUFF(( SELECT  ',' + ALIAS
                            FROM    dbo.PGJ_ALIAS
                            WHERE   ID_PERSONA = per.ID_PERSONA
                          FOR
                            XML PATH('')
                          ), 1, 1, '')
        ) alias ,
        actor.ACTR_TPO AS tipoActor ,
        ( SELECT TOP 1
                    den.PATERNO
          FROM      dbo.PGJ_PERSONA AS den
                    INNER JOIN dbo.PGJ_CARPETA_PERSONA t2 ON t2.ID_PERSONA = den.ID_PERSONA
          WHERE     t2.ID_CARPETA = cp.ID_CARPETA
                    AND t2.ID_TIPO_ACTOR = ( SELECT ID_ACTR_TPO
                                             FROM   dbo.CAT_ACTOR_TIPO
                                             WHERE  ACTR_TPO = 'DENUNCIANTE'
                                           )
        ) AS denunciante ,
        ( SELECT TOP 1
                    den.MATERNO
          FROM      dbo.PGJ_PERSONA AS den
                    INNER JOIN dbo.PGJ_CARPETA_PERSONA t2 ON t2.ID_PERSONA = den.ID_PERSONA
          WHERE     t2.ID_CARPETA = cp.ID_CARPETA
                    AND t2.ID_TIPO_ACTOR = ( SELECT ID_ACTR_TPO
                                             FROM   dbo.CAT_ACTOR_TIPO
                                             WHERE  ACTR_TPO = 'DENUNCIANTE'
                                           )
        ) AS denunciante2 ,
        ( SELECT TOP 1
                    den.NOMBRE
          FROM      dbo.PGJ_PERSONA AS den
                    INNER JOIN dbo.PGJ_CARPETA_PERSONA t2 ON t2.ID_PERSONA = den.ID_PERSONA
          WHERE     t2.ID_CARPETA = cp.ID_CARPETA
                    AND t2.ID_TIPO_ACTOR = ( SELECT ID_ACTR_TPO
                                             FROM   dbo.CAT_ACTOR_TIPO
                                             WHERE  ACTR_TPO = 'DENUNCIANTE'
                                           )
        ) AS denunciante3
FROM    dbo.PGJ_LUGAR_HECHOS hch
        INNER JOIN dbo.PGJ_CARPETA_PERSONA cp ON hch.ID_CARPETA = cp.ID_CARPETA
        INNER JOIN dbo.CAT_PAIS p ON hch.ID_PAIS = p.ID_PAIS
        INNER JOIN dbo.CAT_ESTADO e ON hch.ID_ESTADO = e.ID_ESTDO
                                       AND e.ID_PAIS = p.ID_PAIS
        INNER JOIN dbo.CAT_MUNICIPIO m ON hch.ID_MUNICIPIO = m.ID_MNCPIO
                                          AND m.ID_ESTDO = e.ID_ESTDO
        INNER JOIN dbo.CAT_LOCALIDAD loc ON hch.ID_LOCALIDAD = loc.ID_LCLDD
                                            AND loc.ID_MNCPIO = m.ID_MNCPIO
        INNER JOIN dbo.CAT_COLONIA col ON hch.ID_COLONIA = col.ID_CLNIA
                                          AND col.ID_LCLDD = loc.ID_LCLDD
                                          AND col.ID_MNCPIO = hch.ID_MUNICIPIO
                                          AND col.ID_ESTDO = e.ID_ESTDO
        INNER JOIN dbo.CAT_CALLE calle ON hch.ID_CALLE = calle.ID_CLLE
                                          AND calle.ID_LCLDD = loc.ID_LCLDD
                                          AND calle.ID_MNCPIO = hch.ID_MUNICIPIO
                                          AND calle.ID_ESTDO = e.ID_ESTDO
        INNER JOIN dbo.PGJ_PERSONA per ON cp.ID_PERSONA = per.ID_PERSONA
        INNER JOIN dbo.CAT_NACIONALIDAD nac ON per.ID_NACIONALIDAD = nac.ID_NCIONLDD
        INNER JOIN dbo.CAT_ACTOR_TIPO actor ON actor.ID_ACTR_TPO = cp.ID_TIPO_ACTOR
WHERE   cp.ID_TIPO_ACTOR = 2
ORDER BY cp.ID_PERSONA;



