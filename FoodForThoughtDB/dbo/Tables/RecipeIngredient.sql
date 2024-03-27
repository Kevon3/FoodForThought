CREATE TABLE [dbo].[RecipeIngredient] (
    [RecipeIngredientId] INT NOT NULL,
    [RecipeId]           INT NOT NULL,
    [IngredientId]       INT NOT NULL,
    CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY CLUSTERED ([RecipeIngredientId] ASC),
    CONSTRAINT [FK_RecipeIngredient_Ingredient] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredient] ([IngredientId]),
    CONSTRAINT [FK_RecipeIngredient_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId])
);

