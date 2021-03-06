--=============================================
-- Author:    <Alfredo Baez>
--Create date: <11 de Abril de 2018>
--Description:  <Se realizaron cambios en el SP con el fin de consultar unicamente los ofendidos no localizados>
-- =============================================
CREATE procedure [dbo].[ConteoOfendidosCapturados]
as
begin

SELECT  COUNT(PERSONA.ID_PERSONA) AS CONTEOCAPTURADOS

FROM            dbo.PGJ_PERSONA     PERSONA
LEFT OUTER JOIN PGJ_CARPETA_PERSONA CP      ON CP.ID_PERSONA=PERSONA.ID_PERSONA AND CP.ID_MUNICIPIO_PEROSNA_CARPETA=PERSONA.ID_MUNICIPIO_PERSONA
LEFT OUTER JOIN PGJ_CARPETA         CARPETA ON CARPETA.ID_CARPETA=CP.ID_CARPETA AND CARPETA.ID_MUNICIPIO_CARPETA=CP.ID_MUNICIPIO_PEROSNA_CARPETA
LEFT OUTER JOIN dbo.CAT_ACTOR_TIPO  A       ON A.ID_ACTR_TPO = CP.ID_TIPO_ACTOR
WHERE A.ACTR_TPO = 'OFENDIDO' 
  and (PATERNO+MATERNO+NOMBRE+CAST(CP.ID_CARPETA AS VARCHAR(10))) not in(
  SELECT (PATERNO+MATERNO+NOMBRE+CAST(CP.ID_CARPETA AS VARCHAR(10))) AS denunciante
  FROM            dbo.PGJ_PERSONA     PERSONA
  LEFT OUTER JOIN PGJ_CARPETA_PERSONA CP      ON CP.ID_PERSONA=PERSONA.ID_PERSONA AND CP.ID_MUNICIPIO_PEROSNA_CARPETA=PERSONA.ID_MUNICIPIO_PERSONA
  LEFT OUTER JOIN PGJ_CARPETA         CARPETA ON CARPETA.ID_CARPETA=CP.ID_CARPETA AND CARPETA.ID_MUNICIPIO_CARPETA=CP.ID_MUNICIPIO_PEROSNA_CARPETA
  LEFT OUTER JOIN dbo.CAT_ACTOR_TIPO  A       ON A.ID_ACTR_TPO = CP.ID_TIPO_ACTOR
  WHERE A.ACTR_TPO = 'DENUNCIANTE') 

end

