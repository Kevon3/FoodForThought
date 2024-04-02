CREATE TABLE [dbo].[Person] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (50)  NOT NULL,
    [Username]  NVARCHAR (20)  NOT NULL,
    [Password]  NVARCHAR (200) NOT NULL,
    [url]       NVARCHAR (200) NOT NULL,
    [AllergyId] INT            NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Allergies] FOREIGN KEY ([AllergyId]) REFERENCES [dbo].[Allergies] ([AllergyId])
);







