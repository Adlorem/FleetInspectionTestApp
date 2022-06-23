
Create PROCEDURE [dbo].[spVehicleInspections_Insert]
  @VehicleId int
 ,@CheckDate date
 ,@NextCheckDate date
 ,@IsCheckPassed bit
AS
BEGIN
	SET NOCOUNT ON;

	insert into [dbo].VehicleInspections 
	(
        VehicleId
	   ,CheckDate
	   ,NextCheckDate
	   ,IsCheckPassed
	)
	values
	(
	    @VehicleId
	   ,@CheckDate
	   ,@NextCheckDate
	   ,@IsCheckPassed
	)

END