CREATE TABLE [dbo].[Allergies] (
    [AllergyId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED ([AllergyId] ASC),
    CONSTRAINT [FK_Allergies_Allergies] FOREIGN KEY ([AllergyId]) REFERENCES [dbo].[Allergies] ([AllergyId])
);



