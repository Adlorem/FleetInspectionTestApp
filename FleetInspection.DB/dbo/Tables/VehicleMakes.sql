CREATE TABLE [dbo].[VehicleMakes] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [MakeName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_VehicleMakes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

