
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/25/2017 16:55:33
-- Generated from EDMX file: H:\Dropbox\TaskApplication\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TaskSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_CustomerTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_PriorityTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_PriorityTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceTypeTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_ServiceTypeTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskStatusTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TaskStatusTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_ServiceTask];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_UserTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTicket1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_UserTicket1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Priorities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Priorities];
GO
IF OBJECT_ID(N'[dbo].[ServiceTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceTypes];
GO
IF OBJECT_ID(N'[dbo].[Statuses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Statuses];
GO
IF OBJECT_ID(N'[dbo].[StatusTransitions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusTransitions];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[TicketTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTypes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Priorities'
CREATE TABLE [dbo].[Priorities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ServiceTypes'
CREATE TABLE [dbo].[ServiceTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Statuses'
CREATE TABLE [dbo].[Statuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StatusTransitions'
CREATE TABLE [dbo].[StatusTransitions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [From] int  NOT NULL,
    [To] int  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [CreatedAt] datetime  NULL,
    [UpdatedAt] datetime  NULL,
    [Description] nvarchar(max)  NULL,
    [ResolvedAt] datetime  NULL,
    [Type_Id] int  NOT NULL,
    [Status_Id] int  NOT NULL,
    [Customer_Id] int  NOT NULL,
    [ServiceType_Id] int  NOT NULL,
    [Priority_Id] int  NOT NULL,
    [Creator_Id] int  NOT NULL,
    [Asignee_Id] int  NOT NULL
);
GO

-- Creating table 'TicketTypes'
CREATE TABLE [dbo].[TicketTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Priorities'
ALTER TABLE [dbo].[Priorities]
ADD CONSTRAINT [PK_Priorities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceTypes'
ALTER TABLE [dbo].[ServiceTypes]
ADD CONSTRAINT [PK_ServiceTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Statuses'
ALTER TABLE [dbo].[Statuses]
ADD CONSTRAINT [PK_Statuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusTransitions'
ALTER TABLE [dbo].[StatusTransitions]
ADD CONSTRAINT [PK_StatusTransitions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TicketTypes'
ALTER TABLE [dbo].[TicketTypes]
ADD CONSTRAINT [PK_TicketTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_CustomerTicket]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerTicket'
CREATE INDEX [IX_FK_CustomerTicket]
ON [dbo].[Tickets]
    ([Customer_Id]);
GO

-- Creating foreign key on [Priority_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_PriorityTicket]
    FOREIGN KEY ([Priority_Id])
    REFERENCES [dbo].[Priorities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriorityTicket'
CREATE INDEX [IX_FK_PriorityTicket]
ON [dbo].[Tickets]
    ([Priority_Id]);
GO

-- Creating foreign key on [ServiceType_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_ServiceTypeTicket]
    FOREIGN KEY ([ServiceType_Id])
    REFERENCES [dbo].[ServiceTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceTypeTicket'
CREATE INDEX [IX_FK_ServiceTypeTicket]
ON [dbo].[Tickets]
    ([ServiceType_Id]);
GO

-- Creating foreign key on [Status_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TaskStatusTask]
    FOREIGN KEY ([Status_Id])
    REFERENCES [dbo].[Statuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskStatusTask'
CREATE INDEX [IX_FK_TaskStatusTask]
ON [dbo].[Tickets]
    ([Status_Id]);
GO

-- Creating foreign key on [Type_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_ServiceTask]
    FOREIGN KEY ([Type_Id])
    REFERENCES [dbo].[TicketTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceTask'
CREATE INDEX [IX_FK_ServiceTask]
ON [dbo].[Tickets]
    ([Type_Id]);
GO

-- Creating foreign key on [Creator_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_UserTicket]
    FOREIGN KEY ([Creator_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicket'
CREATE INDEX [IX_FK_UserTicket]
ON [dbo].[Tickets]
    ([Creator_Id]);
GO

-- Creating foreign key on [Asignee_Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_UserTicket1]
    FOREIGN KEY ([Asignee_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicket1'
CREATE INDEX [IX_FK_UserTicket1]
ON [dbo].[Tickets]
    ([Asignee_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------