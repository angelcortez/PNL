USE [PNL_NSJP2]
GO
/****** Object:  StoredProcedure [dbo].[PNL_ActualizaDatosLocalizacion]    Script Date: 03/26/2018 12:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PNL_ActualizaDatosLocalizacion]
@IdLocalizado Int,
@EstatusPersona bit,
@FechaLocalizacion date,
@HoraLocalizacion varchar(10),
@PosibleCausaDesaparicion varchar(1000),
@IdCondicionLocalizacion smallint,
@IdLugarHallazgo  smallint,
@IdPais  smallint,
@IdEntidad  smallint,
@IdMunicipio  smallint,
@Localidad  varchar(50),
@Colonia  varchar(50),
@Calle  varchar(50),
@EntreCalle1  varchar(50),
@EntreCalle2  varchar(50),
@NumeroExterior varchar(10),
@NumeroInterior varchar(10),
@CP varchar(10),
@FechaIngreso varchar(10),
@HoraIngreso varchar(10), 
@IdCausasFallecimiento smallint,
@IdentificacionCadaver varchar(50),
@FechaEntregaCuerpo varchar(10),
@FechaProbableFallecimiento varchar(10),
@EnteLocaliza   smallint,
@NombreEnte  varchar(50),
@PaternoEnte varchar(50),
@MaternoEnte varchar(50),
@Institucion varchar(50),
@Autoridad varchar(50),
@NombreAutoridad varchar(50),
@PaternoAutoridad varchar(50),
@MaternoAutoridad varchar(50),
@NombreReclama varchar(50),
@PaternoReclama varchar(50),
@MaternoReclama varchar(50),
@IdParentescoReclama SMALLINT,
@domicilioReferencia VARCHAR(1000)

as
begin

update PNL_DATOS_LOCALIZACION set
EstatusPersona=@EstatusPersona ,
FechaLocalizacion =@FechaLocalizacion,
HoraLocalizacion=@HoraLocalizacion,
PosibleCausaDesaparicion =@PosibleCausaDesaparicion,
IdCondicionLocalizacion= @IdCondicionLocalizacion,
IdLugarHallazgo  =@IdLugarHallazgo,
IdPais = @IdPais,
IdEntidad  =@IdEntidad,
IdMunicipio = @IdMunicipio,
Localidad =@Localidad ,
Colonia = @Colonia,
Calle =@Calle ,
EntreCalle1= @EntreCalle1,
EntreCalle2 =@EntreCalle2 ,
NumeroExterior =@NumeroExterior,
NumeroInterior=@NumeroInterior,
CP= @CP,
FechaIngreso =@FechaIngreso,
HoraIngreso =@HoraIngreso, 
IdCausasFallecimiento= @IdCausasFallecimiento,
IdentificacionCadaver= @IdentificacionCadaver,
FechaEntregaCuerpo= @FechaEntregaCuerpo,
FechaProbableFallecimiento =@FechaProbableFallecimiento,
EnteLocaliza  =@EnteLocaliza ,
NombreEnte  =@NombreEnte,
PaternoEnte=@PaternoEnte ,
MaternoEnte =@MaternoEnte,
Institucion =@Institucion,
Autoridad= @Autoridad,
NombreAutoridad= @NombreAutoridad,
PaternoAutoridad =@PaternoAutoridad,
MaternoAutoridad= @MaternoAutoridad,
NombreReclama= @NombreReclama,
PaternoReclama =@PaternoReclama,
MaternoReclama= @MaternoReclama,
IdParentescoReclama=@IdParentescoReclama,
domicilioReferencia = @domicilioReferencia


where IdLocalizado=@IdLocalizado
end
