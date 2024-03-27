CREATE TABLE [dbo].[Allergies] (
    [AllergyId] INT           NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED ([AllergyId] ASC),
    CONSTRAINT [FK_Allergies_Allergies] FOREIGN KEY ([AllergyId]) REFERENCES [dbo].[Allergies] ([AllergyId])
);

