CREATE TABLE [dbo].[Ingredient] (
    [IngredientId]   INT            NOT NULL,
    [IngredientName] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED ([IngredientId] ASC)
);

