--получение краткого описания всех статей

SELECT [a].[id_article] AS [Id], [a].[title] AS [Title], [a].[description] AS [Description], [u].[login] AS [UserLogin]
FROM [article] AS [a]
INNER JOIN [user] AS [u] ON [a].[id_user] = [u].[id_user]
ORDER BY [a].[id_article] DESC

--получение статьи по id статьи

DECLARE @__articleId_0 int;  
SET @__articleId_0 = 1

SELECT TOP(2) [a].[id_article] AS [Id], [a].[title] AS [Title], [a].[content] AS [Content], [u].[login] AS [UserLogin]
FROM [article] AS [a]
INNER JOIN [user] AS [u] ON [a].[id_user] = [u].[id_user]
WHERE [a].[id_article] = @__articleId_0

--получение комментов по id статьи

DECLARE @__articleId_5 int;  
SET @__articleId_5 = 1

SELECT [c].[id_comment] AS [Id], [u].[login] AS [Login], [c].[text] AS [Text]
FROM [comment] AS [c]
INNER JOIN [user] AS [u] ON [c].[id_user] = [u].[id_user]
WHERE [c].[id_article] = @__articleId_5

--создание статьи

DECLARE @title nvarchar(200);  
SET @title = N'title'
DECLARE @description nvarchar(max);  
SET @description = N'description'
DECLARE @content nvarchar(max);  
SET @content = N'content'
DECLARE @id_user int;  
SET @id_user = 3

BEGIN TRANSACTION 

SET NOCOUNT ON;
INSERT INTO [article] ([content], [description], [title], [id_user])
VALUES (@description, @content, @title, @id_user);
SELECT [id_article]
FROM [article]
WHERE @@ROWCOUNT = 1 AND [id_article] = scope_identity();

ROLLBACK;

--добавление категории к статье 

DECLARE @id_article int;  
SET @id_article = 68
DECLARE @id_category int;  
SET @id_category = 1

BEGIN TRANSACTION 

SET NOCOUNT ON;

INSERT INTO [article_has_category] ([id_article], [id_category])
VALUES (@id_article, @id_category);

ROLLBACK;

--удаление статьи

DECLARE @p0 int;  
SET @p0 = 4

BEGIN TRANSACTION 

SET NOCOUNT ON;
DELETE FROM [article]
WHERE [id_article] = @p0;
SELECT @@ROWCOUNT;

ROLLBACK;

--создание коммента

DECLARE @p1 int;
SET @p1 = 1;
DECLARE @p2 nvarchar(200);
SET @p2 = N'коммент';
DECLARE @p3 int;
SET @p3 = 2;

BEGIN TRANSACTION 

SET NOCOUNT ON;
INSERT INTO [comment] ([id_article], [text], [id_user])
VALUES (@p1, @p2, @p3);
SELECT [id_comment]
FROM [comment]
WHERE @@ROWCOUNT = 1 AND [id_comment] = scope_identity();

ROLLBACK;

--получение списка категорий по id статьи

DECLARE @__articleId_1 int;  
SET @__articleId_1 = 1

SELECT [c].[id_category] AS [Id], [c].[title] AS [Title]
FROM [category] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [article_has_category] AS [a]
    WHERE ([c].[id_category] = [a].[id_category]) AND ([a].[id_article] = @__articleId_1))


--получение списка изображений по id статьи

DECLARE @__articleId_2 int;  
SET @__articleId_2 = 1

SELECT [i].[id_image] AS [Id], [i].[name] AS [Name]
FROM [image] AS [i]
WHERE EXISTS (
    SELECT 1
    FROM [article_has_image] AS [a]
    WHERE ([i].[id_image] = [a].[id_image]) AND ([a].[id_article] = @__articleId_2))


--поиск статей по заголовку

DECLARE @__title_0 nvarchar(200);  
SET @__title_0 = N'science'

SELECT [a].[id_article] AS [Id], [a].[title] AS [Title], [a].[description] AS [Description], [u].[login] AS [UserLogin]
FROM [article] AS [a]
INNER JOIN [user] AS [u] ON [a].[id_user] = [u].[id_user]
WHERE (@__title_0 = N'') OR (CHARINDEX(@__title_0, [a].[title]) > 0)

--поиск статей по логину автора

DECLARE @__login_0 nvarchar(50);  
SET @__login_0 = N'Alice'

SELECT [a].[id_article] AS [Id], [a].[title] AS [Title], [a].[description] AS [Description], [u].[login] AS [UserLogin]
FROM [article] AS [a]
INNER JOIN [user] AS [u] ON [a].[id_user] = [u].[id_user]
WHERE (@__login_0 = N'') OR (CHARINDEX(@__login_0, [u].[login]) > 0)

--получени статей по id автора

DECLARE @__userId_0 int;  
SET @__userId_0 = 1

SELECT [a].[id_article] AS [Id], [a].[title] AS [Title], [a].[description] AS [Description]
FROM [article] AS [a]
INNER JOIN [user] AS [u] ON [a].[id_user] = [u].[id_user]
WHERE [u].[id_user] = @__userId_0
ORDER BY [a].[id_article] DESC
