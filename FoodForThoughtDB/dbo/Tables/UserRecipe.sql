CREATE TABLE [dbo].[UserRecipe] (
    [UserRecipeId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]       INT NOT NULL,
    [RecipeId]     INT NOT NULL,
    CONSTRAINT [PK_UserRecipe] PRIMARY KEY CLUSTERED ([UserRecipeId] ASC),
    CONSTRAINT [FK_UserRecipe_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]),
    CONSTRAINT [FK_UserRecipe_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Person] ([UserId])
);





