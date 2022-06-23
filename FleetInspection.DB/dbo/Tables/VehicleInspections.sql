CREATE TABLE [dbo].[VehicleInspections] (
    [Id]            INT  IDENTITY (1, 1) NOT NULL,
    [VehicleId]     INT  NOT NULL,
    [CheckDate]     DATE NULL,
    [NextCheckDate] DATE NULL,
    [IsCheckPassed] BIT  NOT NULL,
    CONSTRAINT [PK_VehicleInspections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VehicleInspections_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleInspections]
    ON [dbo].[VehicleInspections]([VehicleId] ASC);

