CREATE TABLE [dbo].[Cuisine] (
    [CuisineId] INT            IDENTITY (1, 1) NOT NULL,
    [Cuisine]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Cuisine] PRIMARY KEY CLUSTERED ([CuisineId] ASC)
);



