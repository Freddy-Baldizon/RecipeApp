CREATE DATABASE RecipeApp;
GO
USE RecipeApp;

CREATE TABLE [Users] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [email] nvarchar(255) UNIQUE,
  [username] nvarchar(255) UNIQUE,
  [password] nvarchar(255),
  [avatar] nvarchar(255)
)
GO

CREATE TABLE [Recipes] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [name] nvarchar(255),
  [description] nvarchar(255),
  [country_id] int,
  [user_id] int,
  [photo_url] nvarchar(255)
)
GO

CREATE TABLE [Comments] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [user_id] int,
  [recipe_id] int,
  [username] nvarchar(255) not null,
  [title] nvarchar(255),
  [description] nvarchar(255)
)
GO

CREATE TABLE [Ratings] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [recipe_id] int,
  [user_id] int,
  [value] int
)
GO

CREATE TABLE [Steps] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [recipe_id] int,
  [name] nvarchar(255),
  [description] nvarchar(255),
  [order] int
)
GO

CREATE TABLE [Ingredients] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [name] nvarchar(255) UNIQUE
)
GO

CREATE TABLE [RecipeIngredients] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [recipe_id] int,
  [ingredient_id] int,
  [amount] nvarchar(255)
)
GO

CREATE TABLE [Countries] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [name] nvarchar(255) UNIQUE,
  [flag_url] nvarchar(255),
  [iso_alpha3] nvarchar(255) UNIQUE
)
GO

CREATE TABLE [RecipeFavorites] (
  [recipe_id] int NOT NULL,
  [user_id]   int NOT NULL,
  [created_at] date,
  CONSTRAINT PK_RecipeFavorites PRIMARY KEY ([user_id], [recipe_id])
)
GO

CREATE INDEX [Recipes_index_0] ON [Recipes] ("user_id")
GO

CREATE INDEX [Recipes_index_1] ON [Recipes] ("country_id")
GO

CREATE INDEX [Recipes_index_2] ON [Recipes] ("name")
GO

CREATE INDEX [Comments_index_3] ON [Comments] ("recipe_id")
GO

CREATE INDEX [Ratings_index_4] ON [Ratings] ("recipe_id")
GO

CREATE UNIQUE INDEX [Ratings_index_5] ON [Ratings] ("user_id", "recipe_id")
GO

CREATE INDEX [Steps_index_6] ON [Steps] ("recipe_id")
GO

CREATE INDEX [RecipeIngredients_index_7] ON [RecipeIngredients] ("recipe_id")
GO

CREATE INDEX [RecipeIngredients_index_8] ON [RecipeIngredients] ("ingredient_id")
GO

CREATE UNIQUE INDEX [RecipeFavorites_index_9] ON [RecipeFavorites] ("user_id", "recipe_id")
GO

ALTER TABLE [Recipes] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id])
GO

ALTER TABLE [Recipes] ADD FOREIGN KEY ([country_id]) REFERENCES [Countries] ([id])
GO

ALTER TABLE [Comments] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id])
GO

ALTER TABLE [Comments] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id])
GO

ALTER TABLE [Ratings] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id])
GO

ALTER TABLE [Ratings] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id])
GO

ALTER TABLE [Steps] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id])
GO

ALTER TABLE [RecipeIngredients] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id])
GO

ALTER TABLE [RecipeIngredients] ADD FOREIGN KEY ([ingredient_id]) REFERENCES [Ingredients] ([id])
GO

ALTER TABLE [RecipeFavorites] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id])
GO

ALTER TABLE [RecipeFavorites] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id])
GO
