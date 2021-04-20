
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/20/2021 20:57:13
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EDMdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Organizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organizations];
GO
IF OBJECT_ID(N'[dbo].[VIPworkers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VIPworkers];
GO
IF OBJECT_ID(N'[dbo].[Workers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Workers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [Id] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [salary] int  NOT NULL,
    [deposit] float  NOT NULL,
    [methodPayments] int  NOT NULL,
    [mounthCreateStandartPaymentMeth] int  NOT NULL,
    [depositType] nvarchar(50)  NOT NULL,
    [type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'VIPworkers'
CREATE TABLE [dbo].[VIPworkers] (
    [Id] int  NOT NULL,
    [firstname] nvarchar(50)  NOT NULL,
    [lastname] nvarchar(50)  NOT NULL,
    [age] int  NOT NULL,
    [salary] int  NOT NULL,
    [deposit] float  NOT NULL,
    [methodPayments] int  NOT NULL,
    [mounthCreateStandartPaymentMeth] int  NOT NULL,
    [depositType] nvarchar(50)  NOT NULL,
    [type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Workers'
CREATE TABLE [dbo].[Workers] (
    [Id] int  NOT NULL,
    [firstname] nvarchar(50)  NOT NULL,
    [lastname] nvarchar(50)  NOT NULL,
    [age] int  NOT NULL,
    [salary] int  NOT NULL,
    [deposit] float  NOT NULL,
    [methodPayments] int  NOT NULL,
    [mounthCreateStandartPaymentMeth] int  NOT NULL,
    [depositType] nvarchar(50)  NOT NULL,
    [type] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VIPworkers'
ALTER TABLE [dbo].[VIPworkers]
ADD CONSTRAINT [PK_VIPworkers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Workers'
ALTER TABLE [dbo].[Workers]
ADD CONSTRAINT [PK_Workers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------