
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/09/2016 12:44:53
-- Generated from EDMX file: D:\Siddhant\MVC Training\Projects\LibraryManagement\LibraryManagement.Repository\DatabaseEntities\LibraryManagementData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-LibraryManagement-20160614212353];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookIssues_Books]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookIssues] DROP CONSTRAINT [FK_BookIssues_Books];
GO
IF OBJECT_ID(N'[dbo].[FK_BookIssues_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookIssues] DROP CONSTRAINT [FK_BookIssues_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_BookIssues_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookIssues] DROP CONSTRAINT [FK_BookIssues_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_Books_Authors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Books_Authors];
GO
IF OBJECT_ID(N'[dbo].[FK_Books_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Books_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_UserRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_UserRoles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO
IF OBJECT_ID(N'[dbo].[BookIssues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookIssues];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [AuthorID] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(20)  NOT NULL,
    [LastName] varchar(15)  NOT NULL,
    [AboutAuthor] varchar(max)  NOT NULL
);
GO

-- Creating table 'BookIssues'
CREATE TABLE [dbo].[BookIssues] (
    [BookIssueID] int IDENTITY(1,1) NOT NULL,
    [BookID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [IssueDate] datetime  NOT NULL,
    [ReturnDate] datetime  NULL,
    [FineAmount] decimal(18,0)  NULL,
    [IssuerID] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] varchar(50)  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [Role] varchar(20)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(20)  NOT NULL,
    [LastName] varchar(15)  NOT NULL,
    [EmaildID] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [MobileNumber] varbinary(10)  NOT NULL,
    [AddressOne] varchar(50)  NOT NULL,
    [AddressTwo] varchar(50)  NULL,
    [IsActive] bit  NOT NULL,
    [Deposit] decimal(18,0)  NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookID] int IDENTITY(1,1) NOT NULL,
    [BookName] varchar(50)  NOT NULL,
    [ShortDescription] varchar(max)  NOT NULL,
    [LongDescription] varchar(max)  NOT NULL,
    [AutherID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [ImagePath] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AuthorID] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([AuthorID] ASC);
GO

-- Creating primary key on [BookIssueID] in table 'BookIssues'
ALTER TABLE [dbo].[BookIssues]
ADD CONSTRAINT [PK_BookIssues]
    PRIMARY KEY CLUSTERED ([BookIssueID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [BookID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'BookIssues'
ALTER TABLE [dbo].[BookIssues]
ADD CONSTRAINT [FK_BookIssues_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookIssues_Users'
CREATE INDEX [IX_FK_BookIssues_Users]
ON [dbo].[BookIssues]
    ([UserID]);
GO

-- Creating foreign key on [IssuerID] in table 'BookIssues'
ALTER TABLE [dbo].[BookIssues]
ADD CONSTRAINT [FK_BookIssues_Users1]
    FOREIGN KEY ([IssuerID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookIssues_Users1'
CREATE INDEX [IX_FK_BookIssues_Users1]
ON [dbo].[BookIssues]
    ([IssuerID]);
GO

-- Creating foreign key on [RoleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_UserRoles]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[UserRoles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_UserRoles'
CREATE INDEX [IX_FK_Users_UserRoles]
ON [dbo].[Users]
    ([RoleID]);
GO

-- Creating foreign key on [AutherID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Books_Authors]
    FOREIGN KEY ([AutherID])
    REFERENCES [dbo].[Authors]
        ([AuthorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Books_Authors'
CREATE INDEX [IX_FK_Books_Authors]
ON [dbo].[Books]
    ([AutherID]);
GO

-- Creating foreign key on [BookID] in table 'BookIssues'
ALTER TABLE [dbo].[BookIssues]
ADD CONSTRAINT [FK_BookIssues_Books]
    FOREIGN KEY ([BookID])
    REFERENCES [dbo].[Books]
        ([BookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookIssues_Books'
CREATE INDEX [IX_FK_BookIssues_Books]
ON [dbo].[BookIssues]
    ([BookID]);
GO

-- Creating foreign key on [CategoryID] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Books_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Books_Categories'
CREATE INDEX [IX_FK_Books_Categories]
ON [dbo].[Books]
    ([CategoryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------