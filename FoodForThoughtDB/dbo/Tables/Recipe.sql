CREATE TABLE [dbo].[Recipe] (
    [RecipeId]     INT            IDENTITY (1, 1) NOT NULL,
    [DishName]     NVARCHAR (100) NOT NULL,
    [Rating]       INT            NOT NULL,
    [url]          NVARCHAR (200) NOT NULL,
    [CuisineId]    INT            NOT NULL,
    [IngredientId] INT            NOT NULL,
    CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED ([RecipeId] ASC),
    CONSTRAINT [FK_Recipe_Cuisine] FOREIGN KEY ([CuisineId]) REFERENCES [dbo].[Cuisine] ([CuisineId])
);



