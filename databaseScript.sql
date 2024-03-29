USE [master]
GO
/****** Object:  Database [Korespondence]    Script Date: 08.06.2023 18:08:12 ******/
CREATE DATABASE [Korespondence]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Korespondence', FILENAME = N'C:\Users\richa\Korespondence.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Korespondence_log', FILENAME = N'C:\Users\richa\Korespondence_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Korespondence] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Korespondence].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Korespondence] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Korespondence] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Korespondence] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Korespondence] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Korespondence] SET ARITHABORT OFF 
GO
ALTER DATABASE [Korespondence] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Korespondence] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Korespondence] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Korespondence] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Korespondence] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Korespondence] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Korespondence] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Korespondence] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Korespondence] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Korespondence] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Korespondence] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Korespondence] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Korespondence] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Korespondence] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Korespondence] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Korespondence] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Korespondence] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Korespondence] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Korespondence] SET  MULTI_USER 
GO
ALTER DATABASE [Korespondence] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Korespondence] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Korespondence] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Korespondence] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Korespondence] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Korespondence] SET QUERY_STORE = OFF
GO
USE [Korespondence]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Korespondence]
GO
/****** Object:  Table [dbo].[AccMessage]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccMessage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recipient_id] [int] NOT NULL,
	[message_id] [int] NOT NULL,
	[show_recipient] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](200) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[last_login] [datetime] NULL,
 CONSTRAINT [PK__Accounts__3213E83F34B38C93] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Accounts__536C85E4C1CFAD22] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [nvarchar](256) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[sendDate] [datetime] NOT NULL,
	[sender_id] [int] NOT NULL,
	[sender_show] [bit] NOT NULL,
 CONSTRAINT [PK__Messages__3213E83FD634C554] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccMessage]  WITH CHECK ADD  CONSTRAINT [fk_accmes_message] FOREIGN KEY([message_id])
REFERENCES [dbo].[Messages] ([id])
GO
ALTER TABLE [dbo].[AccMessage] CHECK CONSTRAINT [fk_accmes_message]
GO
ALTER TABLE [dbo].[AccMessage]  WITH CHECK ADD  CONSTRAINT [fk_accmes_recipient] FOREIGN KEY([recipient_id])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[AccMessage] CHECK CONSTRAINT [fk_accmes_recipient]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [fk_mes_send] FOREIGN KEY([sender_id])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [fk_mes_send]
GO
/****** Object:  StoredProcedure [dbo].[AssignRecipient]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AssignRecipient]
@recipient_id int,
@message_id int,
@recipient_show bit
AS
BEGIN 
INSERT INTO AccMessage VALUES(@recipient_id, @message_id, @recipient_show)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRecipient]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteRecipient]
@id_msg int,
@id_recipient int
AS
BEGIN
UPDATE AccMessage SET show_recipient = 'False' WHERE AccMessage.message_id = @id_msg AND AccMessage.recipient_id = @id_recipient;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSender]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSender]
@id_msg int
AS
BEGIN
UPDATE Messages SET sender_show = 'False' WHERE id = @id_msg;
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdByName]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetIdByName]
@username nvarchar(200)
AS
BEGIN
SELECT Accounts.id FROM Accounts WHERE Accounts.username = @username;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMessageById]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessageById]
@id int
AS
BEGIN
SELECT subject, message, sendDate, sender_id FROM Messages M INNER JOIN AccMessage ON M.id = AccMessage.message_id WHERE M.id = @id AND show_recipient = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetMessagesByRecipientID]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessagesByRecipientID]
@id int
AS
BEGIN
SELECT DISTINCT Messages.id as MessageID, Odesilatel.Username AS Sender, Messages.sendDate AS [Send Date], Messages.subject as Subject
FROM  Accounts Odesilatel INNER JOIN Messages ON Odesilatel.id = Messages.sender_id INNER JOIN AccMessage ON AccMessage.message_id = Messages.id WHERE AccMessage.recipient_id = @id AND AccMessage.show_recipient= 'True';
END
GO
/****** Object:  StoredProcedure [dbo].[GetMessagesBySenderId]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessagesBySenderId]
@id int
AS
BEGIN
SELECT DISTINCT Messages.id as MessageID, Odesilatel.Username AS Sender, Messages.sendDate AS [Send Date], Messages.subject as Subject
FROM  Accounts Odesilatel INNER JOIN Messages ON Odesilatel.id = Messages.sender_id INNER JOIN AccMessage ON AccMessage.message_id = Messages.id WHERE Odesilatel.id = @id AND Messages.sender_show = 'True';
END;
GO
/****** Object:  StoredProcedure [dbo].[GetNameById]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNameById]
@id int
AS
BEGIN
SELECT Accounts.username FROM Accounts WHERE Accounts.id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecipientsByMessageId]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRecipientsByMessageId]
@id int
AS
BEGIN
SELECT recipient_id from AccMessage WHERE message_id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[LogAuthentication]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LogAuthentication]
@id int
AS
BEGIN
    UPDATE Accounts
	SET last_login = GETDATE()
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RecentlyLoggedUsers]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecentlyLoggedUsers]
@id int
AS
BEGIN
    SELECT TOP 10 username as Username, last_login as [Last Online]
    FROM Accounts
    WHERE id != @id
    ORDER BY last_login DESC
END
GO
/****** Object:  StoredProcedure [dbo].[SendEmail]    Script Date: 08.06.2023 18:08:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SendEmail]
@subject nvarchar(256),
@message nvarchar(MAX),
@sender_id int,
@sender_show bit
AS
DECLARE @message_id int
BEGIN
BEGIN TRANSACTION;
INSERT INTO Messages OUTPUT INSERTED.id VALUES(@subject, @message, GETDATE(), @sender_id, @sender_show);
COMMIT TRANSACTION;
END;
GO
USE [master]
GO
ALTER DATABASE [Korespondence] SET  READ_WRITE 
GO
