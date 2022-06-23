CREATE TABLE [dbo].[VehicleModels] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [MakeId]    INT           NOT NULL,
    [ModelName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_VehicleModels] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VehicleModels_VehicleMakes] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[VehicleMakes] ([Id])
);

