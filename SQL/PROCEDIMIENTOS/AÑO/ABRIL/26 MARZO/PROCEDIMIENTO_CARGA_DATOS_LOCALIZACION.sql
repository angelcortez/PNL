USE [PNL_NSJP2]
GO
/****** Object:  StoredProcedure [dbo].[PNL_CargarDatosLocalizacion]    Script Date: 03/26/2018 12:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[PNL_CargarDatosLocalizacion]
@IdLocalizado int 
as
begin

select 
IdLocalizado 

,IdCarpeta
,IdMunicipioCarpeta
,IdPersona
,convert(smallint,EstatusPersona) as EstatusPersona
,CONVERT(Varchar,FechaLocalizacion,103)as FechaLocalizacion
,HoraLocalizacion
,PosibleCausaDesaparicion
,IdCondicionLocalizacion
,IdLugarHallazgo
,IdPais
,IdEntidad
,IdMunicipio
,Localidad
,Colonia
,Calle
,EntreCalle1
,EntreCalle2
,NumeroExterior
,NumeroInterior
,CP
,FechaIngreso
,HoraIngreso
,IdCausasFallecimiento
,IdentificacionCadaver
,FechaEntregaCuerpo
,FechaProbableFallecimiento
,EnteLocaliza
,NombreEnte
,PaternoEnte
,MaternoEnte
,Institucion
,Autoridad
,NombreAutoridad
,PaternoAutoridad
,MaternoAutoridad
,NombreReclama
,PaternoReclama
,MaternoReclama
,IdParentescoReclama
,domicilioReferencia
 from PNL_DATOS_LOCALIZACION 
where IdLocalizado=@IdLocalizado

end
