CREATE TABLE [dbo].[FlashCardSets] (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY default NewID(),
	[Name] VARCHAR  (max),
	[Description] VARCHAR  (max),
)

CREATE TABLE [dbo].[FlashCards] (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY default NewID(),
    [Term] [nvarchar](max),
    [Definition] [nvarchar](max),
	[FlashCardSetId] [uniqueidentifier] NOT NULL,
)

CREATE INDEX [IX_FlashCardSetId] ON [dbo].[FlashCards]([Id])

ALTER TABLE [dbo].[FlashCards] ADD CONSTRAINT [FK_dbo.FlashCards_dbo.FlashCardSets_Id] FOREIGN KEY ([FlashCardSetId]) REFERENCES [dbo].[FlashCardSets] ([Id]) ON DELETE CASCADE