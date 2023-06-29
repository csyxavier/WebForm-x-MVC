CREATE DATABASE [Test_MVC_WebForm]
GO
USE [Test_MVC_WebForm]
GO
CREATE TABLE [dbo].[Employee](
	[PK] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Birthday] [date] NOT NULL
)
GO
INSERT [dbo].[Employee] ([PK], [Name], [Age], [Birthday]) VALUES (1, N'Test', 23, CAST(N'2000-01-01' AS Date))
GO
