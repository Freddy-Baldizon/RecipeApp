CREATE DATABASE RecipeApp;
GO
USE RecipeApp;
GO

CREATE TABLE [Users] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [email] nvarchar(255) NOT NULL,
  [username] nvarchar(100) NOT NULL,
  [password] nvarchar(255) NULL,
  [avatar] nvarchar(500) NULL
);
GO

CREATE TABLE [Countries] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [name] nvarchar(100) NOT NULL,
  [flag_url] nvarchar(500) NULL,
  [iso_alpha3] nvarchar(3) NOT NULL
);
GO

CREATE TABLE [Ingredients] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [name] nvarchar(200) NOT NULL
);
GO

CREATE TABLE [Recipes] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [name] nvarchar(200) NOT NULL,
  [description] nvarchar(2000) NULL,
  [country_id] int NOT NULL,
  [user_id] int NOT NULL,
  [photo_url] nvarchar(500) NULL
);
GO

CREATE TABLE [Comments] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [user_id] int NOT NULL,
  [recipe_id] int NOT NULL,
  [username] nvarchar(255) NOT NULL,
  [title] nvarchar(200) NULL,
  [description] nvarchar(2000) NULL
);
GO

CREATE TABLE [RecipeIngredients] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [recipe_id] int NOT NULL,
  [ingredient_id] int NOT NULL,
  [amount] nvarchar(100) NULL
);
GO

CREATE TABLE [Favorites] (
  [user_id] int NOT NULL,
  [recipe_id] int NOT NULL,
  [created_at] date NULL,
  CONSTRAINT PK_Favorites PRIMARY KEY ([user_id], [recipe_id])
);
GO

-- Indexes
CREATE INDEX [Recipes_index_0] ON [Recipes] ([user_id]);
GO
CREATE INDEX [Recipes_index_1] ON [Recipes] ([country_id]);
GO
CREATE INDEX [Recipes_index_2] ON [Recipes] ([name]);
GO

CREATE INDEX [Comments_index_3] ON [Comments] ([recipe_id]);
GO

CREATE INDEX [Ratings_index_4] ON [Ratings] ([recipe_id]);
GO
CREATE UNIQUE INDEX [Ratings_index_5] ON [Ratings] ([user_id], [recipe_id]);
GO

CREATE INDEX [Steps_index_6] ON [Steps] ([recipe_id]);
GO

CREATE INDEX [RecipeIngredients_index_7] ON [RecipeIngredients] ([recipe_id]);
GO
CREATE INDEX [RecipeIngredients_index_8] ON [RecipeIngredients] ([ingredient_id]);
GO

CREATE UNIQUE INDEX [Favorites_index_9] ON [Favorites] ([user_id], [recipe_id]);
GO

-- Foreign keys
ALTER TABLE [Recipes] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id]);
GO
ALTER TABLE [Recipes] ADD FOREIGN KEY ([country_id]) REFERENCES [Countries] ([id]);
GO

ALTER TABLE [Comments] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id]);
GO
ALTER TABLE [Comments] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id]);
GO

ALTER TABLE [Ratings] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id]);
GO
ALTER TABLE [Ratings] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id]);
GO

ALTER TABLE [Steps] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id]);
GO

ALTER TABLE [RecipeIngredients] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id]);
GO
ALTER TABLE [RecipeIngredients] ADD FOREIGN KEY ([ingredient_id]) REFERENCES [Ingredients] ([id]);
GO

ALTER TABLE [Favorites] ADD FOREIGN KEY ([recipe_id]) REFERENCES [Recipes] ([id]);
GO
ALTER TABLE [Favorites] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([id]);
GO
