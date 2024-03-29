USE [master]
GO
/****** Object:  Database [BusyMom]    Script Date: 10/15/2019 4:04:50 PM ******/
CREATE DATABASE [BusyMom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusyMom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BusyMom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BusyMom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BusyMom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BusyMom] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusyMom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusyMom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusyMom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusyMom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusyMom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusyMom] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusyMom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BusyMom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusyMom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusyMom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusyMom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusyMom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusyMom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusyMom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusyMom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusyMom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BusyMom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusyMom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusyMom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusyMom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusyMom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusyMom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusyMom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusyMom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BusyMom] SET  MULTI_USER 
GO
ALTER DATABASE [BusyMom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusyMom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusyMom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusyMom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BusyMom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BusyMom] SET QUERY_STORE = OFF
GO
USE [BusyMom]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityName] [nvarchar](100) NOT NULL,
	[Approveby] [nvarchar](100) NOT NULL,
	[TimeofActivity] [date] NOT NULL,
	[LocationID] [int] NOT NULL,
	[ApproveTime] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupActivities]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupActivities](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NOT NULL,
	[ActivityOwner] [int] NOT NULL,
 CONSTRAINT [PK_GroupActivities] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](100) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[State] [nvarchar](2) NOT NULL,
	[Zip] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActivities]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivities](
	[UserID] [int] NOT NULL,
	[ActivityID] [int] NOT NULL,
 CONSTRAINT [PK_UserActivities_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Hash] [nvarchar](100) NOT NULL,
	[Salt] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Locations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locations] ([LocationID])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Locations]
GO
ALTER TABLE [dbo].[GroupActivities]  WITH CHECK ADD  CONSTRAINT [FK_GroupActivities_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[GroupActivities] CHECK CONSTRAINT [FK_GroupActivities_Activities]
GO
ALTER TABLE [dbo].[GroupActivities]  WITH CHECK ADD  CONSTRAINT [FK_GroupActivities_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[GroupActivities] CHECK CONSTRAINT [FK_GroupActivities_Groups]
GO
ALTER TABLE [dbo].[UserActivities]  WITH CHECK ADD  CONSTRAINT [FK_UserActivities_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[UserActivities] CHECK CONSTRAINT [FK_UserActivities_Activities]
GO
ALTER TABLE [dbo].[UserActivities]  WITH CHECK ADD  CONSTRAINT [FK_UserActivities_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserActivities] CHECK CONSTRAINT [FK_UserActivities_Users]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroup_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroup_Groups]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroup_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroup_Roles]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroup_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroup_Users]
GO
/****** Object:  StoredProcedure [dbo].[ActivityCreate]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivityCreate]
@ActivityID int output,
@ActivityName nvarchar(100),
@Approveby nvarchar(100),
@TimeofActivity date,
@LocationID int,
@ApproveTime nvarchar(100)

as
begin
insert into Activities(ActivityID, ActivityName,Approveby,TimeofActivity,LocationID,ApproveTime) 
values (@ActivityID,@ActivityName,@Approveby,@TimeofActivity,@LocationID,@ApproveTime);
select @ActivityID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[ActivityDelete]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ActivityDelete]
@ActivityID int
as
begin
delete from Activities
where ActivityID = @ActivityID
end
GO
/****** Object:  StoredProcedure [dbo].[GroupCreate]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupCreate]
@GroupID int output,
@GroupName nvarchar(100)

as
begin
insert into Groups(GroupID, GroupName) 
values (@GroupID,@GroupName);
select @GroupID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[LocationCreate]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LocationCreate]
@LocationID int output,
@Name nvarchar(100),
@Address1 nvarchar(100),
@Address2 nvarchar(100),
@City nvarchar(100),
@State nvarchar(2),
@Zip nvarchar(20)

as
begin
insert into Locations(LocationID,Name,Address1,Address2,City,State,Zip) 
values (@LocationID,@Name,@Address1,@Address2,@City,@State,@Zip);
select @LocationID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[LocationDelete]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[LocationDelete]
@LocationID int
as
begin
delete from Locations
where LocationID = @LocationID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleCreate]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RoleCreate]
@RoleName nvarchar (200),
@RoleID int output
as
begin
insert into roles (RoleName) values (@RoleName)
select @RoleID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RoleDelete]
@RoleID int
as
begin
delete from Roles
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleFindByID]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RoleFindByID]
@RoleID int
as
begin
select RoleID, RoleName from Roles
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RolesGetAll]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RolesGetAll]
@skip int,
@take int
as
begin
select RoleID, RoleName from Roles 
order by RoleID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateJust]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RoleUpdateJust] 
@RoleID int,
@RoleName nvarchar (200)
as
begin
update roles set RoleName= @Rolename
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserCreate]
@LastName nvarchar(100),
@FirstName nvarchar(100),
@Email nvarchar(100),
@Phone nvarchar(100),
@UserName nvarchar(100),
@UserID int output,
@Hash nvarchar(100),
@Salt nvarchar(100)

as
begin
insert into users(FirstName,LastName,Email,Phone,UserName,Hash,Salt) 
values (@LastName,@FirstName,@Email,@Phone,@UserName,@Hash,@Salt);
select @UserID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[UserGetAll]
@skip int,
@take int
as
begin
select UserID,LastName,FirstName,Email,Phone,UserName, Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID= Roles.RoleID
order by UserID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersDelete]
@UserID int
as
begin
delete from Users
where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[UsersFindByEmail]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[UsersFindByEmail]
@Email nvarchar(200)
as
begin
select UserID,LastName,Firstname, Email,Phone,UserName Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID=Roles.RoleID
where Email = @Email
end
GO
/****** Object:  StoredProcedure [dbo].[UsersFindByUserName]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[UsersFindByUserName]
@UserName nvarchar(100)
as
begin
select UserID,FirstName,LastName, Email,Phone, Hash, Salt, Users.RoleID, RoleName from users
inner join Roles on Users.RoleID=Roles.RoleID
where UserName = @UserName
end
GO
/****** Object:  StoredProcedure [dbo].[UserUpdateJust]    Script Date: 10/15/2019 4:04:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserUpdateJust] 
@UserID int,
@GroupID int,
@LastName nvarchar (100),
@FirstName nvarchar(100),
@Email nvarchar (100),
@Phone nvarchar (100),
@UserName nvarchar (100),
@Hash nvarchar (100),
@Salt nvarchar (100)

as
begin
update users
set LastName = @LastName,FirstName = @FirstName, Email = @Email,Phone = @Phone, UserName= @UserName,Hash = @Hash,Salt= @Salt
where UserID = @UserID
end
GO
USE [master]
GO
ALTER DATABASE [BusyMom] SET  READ_WRITE 
GO
