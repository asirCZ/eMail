USE [master]
GO
/****** Object:  Database [Korespondence]    Script Date: 08.03.2023 21:04:46 ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 08.03.2023 21:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK__Accounts__3213E83F34B38C93] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Accounts__536C85E4C1CFAD22] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 08.03.2023 21:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [nvarchar](256) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[sendDate] [datetime] NOT NULL,
	[senderId] [int] NOT NULL,
	[receiverId] [int] NOT NULL,
	[senderShow] [bit] NOT NULL,
	[receiverShow] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [fk_receiver] FOREIGN KEY([receiverId])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [fk_receiver]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [fk_sender] FOREIGN KEY([senderId])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [fk_sender]
GO
/****** Object:  StoredProcedure [dbo].[GetMessagesByReceiverId]    Script Date: 08.03.2023 21:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessagesByReceiverId]
@id int
AS
BEGIN
SELECT Messages.id as MessageID, Odesilatel.Username AS Sender, Messages.sendDate AS [Send Date], Messages.subject as Subject
FROM Accounts Odesilatel INNER JOIN Messages on Messages.senderId = Odesilatel.id WHERE Messages.receiverId = @id AND Messages.receiverShow = 'True';
END;
GO
/****** Object:  StoredProcedure [dbo].[GetMessagesBySenderId]    Script Date: 08.03.2023 21:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessagesBySenderId]
@id int
AS
BEGIN
SELECT Messages.id as MessageID, Prijemce.Username AS Recipient, Messages.sendDate AS [Send Date], Messages.subject as Subject
FROM Accounts Prijemce INNER JOIN Messages on Messages.receiverId = Prijemce.id WHERE Messages.senderId = @id AND Messages.senderShow = 'True';
END;
GO
/****** Object:  StoredProcedure [dbo].[SendEmail]    Script Date: 08.03.2023 21:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SendEmail]
@subject nvarchar(256),
@message nvarchar(MAX),
@senderId int,
@recipientId int
AS
BEGIN
INSERT INTO Messages VALUES(@subject, @message, GETDATE(), @senderId, @recipientId, 'True', 'True');
END;
GO
USE [master]
GO
ALTER DATABASE [Korespondence] SET  READ_WRITE 
GO
