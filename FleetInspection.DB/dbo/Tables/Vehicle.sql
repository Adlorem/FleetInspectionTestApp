CREATE TABLE [dbo].[Vehicle] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Identifier] NVARCHAR (9)    NOT NULL,
    [MakeId]     INT             NOT NULL,
    [ModelId]    INT             NOT NULL,
    [Image]      NVARCHAR (1000) NULL,
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vehicle_Vehicle] FOREIGN KEY ([Id]) REFERENCES [dbo].[Vehicle] ([Id]),
    CONSTRAINT [FK_Vehicle_VehicleMakes] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[VehicleMakes] ([Id]),
    CONSTRAINT [FK_Vehicle_VehicleModels] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[VehicleModels] ([Id])
);

