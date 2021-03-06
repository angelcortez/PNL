CREATE PROCEDURE [dbo].[PNL_InsertaDatosLocalizacion]
--@IdPNL int,
@IdCarpeta int,
@IdMunicipioCarpeta smallint,
@IdPersona int,


@EstatusPersona bit,
@FechaLocalizacion date,
@HoraLocalizacion varchar(10),
@PosibleCausaDesaparicion varchar(1000),
@IdCondicionLocalizacion smallint,
@IdLugarHallazgo  smallint,
@IdPais smallint,
@IdEntidad smallint,
@IdMunicipio smallint,
@Localidad smallint, 
@Colonia smallint, 
@Calle int, 
@EntreCalle1 int,
@EntreCalle2 int,
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
declare @IdLocalizado Int
	Select @IdLocalizado = ISNULL(MAX(IdLocalizado)+1,1) From PNL_DATOS_LOCALIZACION
	
insert into PNL_DATOS_LOCALIZACION
(IdLocalizado,IdCarpeta,IdMunicipioCarpeta,IdPersona,EstatusPersona ,FechaLocalizacion ,HoraLocalizacion,PosibleCausaDesaparicion ,IdCondicionLocalizacion ,IdLugarHallazgo  ,
IdPais  ,IdEntidad  ,IdMunicipio  ,Localidad  ,Colonia  ,Calle  ,EntreCalle1 ,EntreCalle2  ,NumeroExterior ,NumeroInterior,
CP ,FechaIngreso ,HoraIngreso , IdCausasFallecimiento ,IdentificacionCadaver ,FechaEntregaCuerpo ,FechaProbableFallecimiento ,EnteLocaliza   ,
NombreEnte  ,PaternoEnte ,MaternoEnte ,Institucion ,Autoridad ,NombreAutoridad ,PaternoAutoridad ,MaternoAutoridad ,NombreReclama ,PaternoReclama ,MaternoReclama ,IdParentescoReclama, domicilioReferencia)

values
(@IdLocalizado,@IdCarpeta,@IdMunicipioCarpeta,@IdPersona ,@EstatusPersona ,@FechaLocalizacion ,@HoraLocalizacion ,@PosibleCausaDesaparicion ,@IdCondicionLocalizacion ,@IdLugarHallazgo  ,@IdPais  ,@IdEntidad  ,
@IdMunicipio  ,@Localidad  ,@Colonia  ,@Calle  ,@EntreCalle1  ,@EntreCalle2  ,@NumeroExterior ,@NumeroInterior ,@CP ,@FechaIngreso ,@HoraIngreso , @IdCausasFallecimiento ,
@IdentificacionCadaver ,@FechaEntregaCuerpo ,@FechaProbableFallecimiento ,@EnteLocaliza   ,@NombreEnte  ,@PaternoEnte ,@MaternoEnte ,@Institucion ,@Autoridad ,@NombreAutoridad ,@PaternoAutoridad ,
@MaternoAutoridad ,@NombreReclama ,@PaternoReclama ,@MaternoReclama ,@IdParentescoReclama,@domicilioReferencia)

end
