CREATE TABLE [dbo].[Ingredient] (
    [IngredientId]   INT             IDENTITY (1, 1) NOT NULL,
    [IngredientName] NVARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED ([IngredientId] ASC)
);





