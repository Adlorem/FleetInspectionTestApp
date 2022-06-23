
CREATE PROCEDURE [dbo].[spVehicle_GetAll]
@Search nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	veh.* 
	,make.[MakeName]
    ,model.[ModelName]
	,finsp.CheckDate AS [FirstCheckDate]
	,linsp.[CheckDate]
	,linsp.[NextCheckDate]
	,linsp.[IsCheckPassed]
	FROM [dbo].Vehicle veh
	JOIN [dbo].VehicleMakes make on make.[Id] = veh.[MakeId]
	JOIN [dbo].VehicleModels model on model.[Id] = veh.ModelId
	OUTER APPLY 
    (SELECT TOP 1 *
     FROM [dbo].VehicleInspections ins (NOLOCK)
     WHERE ins.VehicleId = veh.Id 
     ORDER BY ins.CheckDate DESC
    ) AS linsp
	OUTER APPLY 
    (SELECT TOP 1 *
     FROM [dbo].VehicleInspections ins (NOLOCK)
     WHERE ins.VehicleId = veh.Id 
     ORDER BY ins.CheckDate
    ) AS finsp
	WHERE   veh.[Identifier] LIKE CASE 
			WHEN @Search IS NOT NULL
				THEN '%' + @Search + '%'
			ELSE veh.[Identifier]
			END
		OR  make.[MakeName] LIKE CASE 
			WHEN @Search IS NOT NULL
				THEN '%' + @Search + '%'
			ELSE make.[MakeName]
			END
		OR model.[ModelName] LIKE CASE 
			WHEN @Search IS NOT NULL
				THEN '%' + @Search + '%'
			ELSE model.[ModelName]
			END

END