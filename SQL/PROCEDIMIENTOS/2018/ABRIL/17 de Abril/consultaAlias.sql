--=============================================
--Author:    <Angel Cortez>
--Create date: <17 de Abril de 2018>
--Description:  <Se agregó a la consulta el tipo de actor>
-- =============================================
CREATE PROCEDURE [dbo].[consultaAlias] @IdPersona int
as
begin


	SELECT al.ID_ALIAS   
	,      ALIAS         
	,      al.ID_PERSONA 
	,      actor.ACTR_TPO as tipoActor
	FROM       PGJ_ALIAS           al   
	inner join PGJ_CARPETA_PERSONA cp    ON cp.ID_PERSONA= al.ID_PERSONA
	inner join CAT_ACTOR_TIPO      actor on cp.ID_TIPO_ACTOR = actor.ID_ACTR_TPO
	where al.ID_PERSONA=@IdPersona

end

