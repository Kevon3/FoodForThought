CREATE TABLE [dbo].[UserAllergies] (
    [UserAllergiesId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]          INT NOT NULL,
    [AllergyId]       INT NOT NULL,
    CONSTRAINT [PK_UserAllergies] PRIMARY KEY CLUSTERED ([UserAllergiesId] ASC),
    CONSTRAINT [FK_UserAllergies_Allergies] FOREIGN KEY ([AllergyId]) REFERENCES [dbo].[Allergies] ([AllergyId])
);



