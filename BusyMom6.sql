USE [master]
GO
/****** Object:  Database [BusyMom]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  Table [dbo].[Activities]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityName] [nvarchar](100) NOT NULL,
	[Approveby] [nvarchar](100) NOT NULL,
	[TimeofActivity] [datetime2](7) NOT NULL,
	[ApproveTime] [datetime2](7) NOT NULL,
	[LocationID] [int] NOT NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupActivities]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupActivities](
	[GroupID] [int] NOT NULL,
	[ActivityID] [int] NOT NULL,
	[ActivityOwner] [int] NOT NULL,
 CONSTRAINT [PK_GroupActivities] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  Table [dbo].[Locations]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  Table [dbo].[LogTrace]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTrace](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](250) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[TimeStamp] [datetime2](7) NULL,
 CONSTRAINT [PK_LogTrace] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  Table [dbo].[UserActivities]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  Table [dbo].[UserGroups]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 11/7/2019 11:14:02 PM ******/
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
	[Hash] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[ActivitiesCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesCreate]
@ActivityID int output,
@ActivityName nvarchar(100),
@Approveby nvarchar(100),
@TimeofActivity datetime,
@LocationID int,
@ApproveTime datetime 

as
begin
insert into Activities(ActivityID, ActivityName,Approveby,TimeofActivity,LocationID,ApproveTime) 
values (@ActivityID,@ActivityName,@Approveby,@TimeofActivity,@LocationID,@ApproveTime);
select @ActivityID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ActivitiesDelete]
@ActivityID int
as
begin
delete from Activities
where ActivityID = @ActivityID
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesFindByID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesFindByID]
@ActivityID int
as
begin
select ActivityID, ActivityName, Approveby, TimeofActivity, ApproveTime, Activities.LocationID, LocationName, 'NA' ActivityOwner from Activities
inner join Locations on Locations.LocationID=Activities.LocationID
where ActivityID = @ActivityID
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesFindByLocationID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesFindByLocationID]
@LocationID int
as
begin
select ActivityID, ActivityName, Approveby, TimeofActivity, ApproveTime, Activities.LocationID, LocationName, 'NA' ActivityOwner from Activities
inner join Locations on Locations.LocationID=Activities.LocationID
where Activities.LocationID = @LocationID
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesGetAll]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesGetAll]
@skip int,
@take int
as
begin
select ActivityID, ActivityName, Approveby, TimeofActivity, ApproveTime, Activities.LocationID, LocationName, 'NA' ActivityOwner from Activities
inner join Locations on Locations.LocationID=Activities.LocationID
order by Activities.ActivityID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesGetAllbyGroupID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesGetAllbyGroupID]
@skip int,
@take int,
@GroupID int
as
begin
select Activities.ActivityID, ActivityName, Approveby, TimeofActivity, ApproveTime, Activities.LocationID, LocationName, ActivityOwner from Activities
inner join Locations on Locations.LocationID=Activities.LocationID
inner join GroupActivities on Activities.ActivityID = GroupActivities.ActivityID
where GroupID = @GroupID
order by GroupID 
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesGetAllbyUserID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesGetAllbyUserID]
@skip int,
@take int,
@UserID int
as
begin
select Activities.ActivityID, ActivityName, Approveby, TimeofActivity, ApproveTime, Activities.LocationID, LocationName,'NA' ActivityOwner from Activities
inner join Locations on Locations.LocationID=Activities.LocationID
inner join UserActivities on Activities.ActivityID = UserActivities.ActivityID
where UserID = @UserID
order by UserActivities.UserID 
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ActivitiesObtainCount]
as
begin
select count(*) from Activities
end
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesUpdateJust]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivitiesUpdateJust] 
@ActivityID int,
@ActivityName nvarchar (200),
@Approveby nvarchar (200),
@TimeofActivity nvarchar (200),
@LocationID int,
@ApproveTime nvarchar (200)
as
begin
update Activities
set ActivityName = @ActivityName, Approveby = @Approveby, TimeofActivity = @TimeofActivity, ApproveTime = @ApproveTime
where ActivityID = @ActivityID 
end
GO
/****** Object:  StoredProcedure [dbo].[GroupActivitiesObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GroupActivitiesObtainCount]
as
begin
select count(*) from GroupActivities
end
GO
/****** Object:  StoredProcedure [dbo].[GroupObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GroupObtainCount]
as
begin
select count(*) from Groups
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsActivitiesCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsActivitiesCreate]
@GroupID int,
@ActivityID int,
@ActivityOwner nvarchar(100)

as
begin
insert into GroupActivities(GroupID, ActivityID,ActivityOwner) 
values (@GroupID,@ActivityID,@ActivityOwner);

end
GO
/****** Object:  StoredProcedure [dbo].[GroupsActivitiesDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsActivitiesDelete]
@GroupID int,
@ActivityID int
as
begin
delete from GroupActivities
where GroupID = @GroupID and ActivityID = @ActivityID
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsCreate]
@GroupID int output,
@GroupName nvarchar(100)

as
begin
insert into Groups( GroupName) 
values (@GroupName);
select @GroupID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GroupsDelete]
@GroupID int
as
begin
delete from Groups
where GroupID = @GroupID
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsFindByID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsFindByID]
@GroupID int
as
begin
select Groups.GroupID, GroupName, UserID, 'NA' ActivityOwner, 6 RoleID, 'Unknown' RoleName from Groups
inner join UserGroups on Groups.GroupID=UserGroups.GroupID
where Groups.GroupID = @GroupID
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsFindByUserID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsFindByUserID]
@skip int,
@take int,
@UserID int
as
begin
Select Groups.GroupID, GroupName, UserID, 'NA' ActivityOwner, 6 RoleID, 'Unknown' RoleName from Groups
inner join UserGroups on Groups.GroupID=UserGroups.GroupID
inner join Roles on UserGroups.RoleID = Roles.RoleID 
where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsGetAll]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsGetAll]
@skip int,
@take int
as
begin
select Groups.GroupID, GroupName, UserID, 'NA' ActivityOwner, 6 RoleID, 'Unknown' RoleName from Groups
inner join UserGroups on Groups.GroupID=UserGroups.GroupID
order by GroupID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsGetAllbyActivityID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GroupsGetAllbyActivityID]
@skip int,
@take int,
@ActivityID int
as
begin
select Groups.GroupID, GroupName, ActivityOwner, 0 RoleID from Groups  
inner join GroupActivities on Groups.GroupID = GroupActivities.GroupID
where ActivityID = @ActivityID
order by Groups.GroupID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[GroupsUpdateJust]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GroupsUpdateJust] 
@GroupID int,
@GroupName nvarchar (200)
as
begin
update Groups set GroupName= @GroupName
where GroupID = @GroupID
end
GO
/****** Object:  StoredProcedure [dbo].[InsertLogItem]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertLogItem] 
        @message varchar(250), 
        @stacktrace varchar(max)
AS
BEGIN
        INSERT INTO [dbo].[LogTrace]
           ([Message]
           ,[StackTrace]
           ,[TimeStamp])
     VALUES
           (@message
           ,@stacktrace
           ,GetDate())
END
GO
/****** Object:  StoredProcedure [dbo].[LocationCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LocationCreate]
@LocationID int output,
@LocationName nvarchar(100),
@Address1 nvarchar(100),
@Address2 nvarchar(100),
@City nvarchar(100),
@State nvarchar(2),
@Zip nvarchar(20)

as
begin
insert into Locations(LocationName,Address1,Address2,City,State,Zip) 
values (@LocationName,@Address1,@Address2,@City,@State,@Zip);
select @LocationID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[LocationDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[LocationFindByID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LocationFindByID]
@LocationID int
as
begin
select Locations.LocationID, LocationName, Address1, Address2, City, State, Zip, Locations.LocationID from Locations
inner join Activities on Locations.LocationID = Activities.LocationID
where Locations.LocationID = @LocationID
end
GO
/****** Object:  StoredProcedure [dbo].[LocationGetAll]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LocationGetAll]
@skip int,
@take int
as
begin
select Locations.LocationID, LocationName, Address1, Address2, City, State, Zip, Locations.LocationID from Locations
order by Locations.LocationID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[LocationsObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[LocationsObtainCount]
as
begin
select count(*) from Locations
end
GO
/****** Object:  StoredProcedure [dbo].[LocationsUpdateJust]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[LocationsUpdateJust] 
@LocationID int,
@LocationName nvarchar (200),
@Address1 nvarchar(200),
@Address2 nvarchar (200),
@City nvarchar (200),
@State nvarchar (4),
@Zip nvarchar (20)
as
begin
update Locations set LocationName= @LocationName, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip
where LocationID = @LocationID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RoleFindByID]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RolesGetAll]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RolesObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[RolesObtainCount]
as
begin
select count(*) from Roles
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateJust]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserActivitiesCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserActivitiesCreate]
@ActivityID int,
@UserID int
as
begin
insert into UserActivities(ActivityID, UserID) 
values (@ActivityID,@UserID);
end
GO
/****** Object:  StoredProcedure [dbo].[UserActivitiesDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserActivitiesDelete]
@UserID int,
@ActivityID int
as
begin
delete from UserActivities
where UserID = @UserID and ActivityID = @ActivityID
end
GO
/****** Object:  StoredProcedure [dbo].[UserActivitiesObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UserActivitiesObtainCount]
as
begin
select count(*) from UserActivities
end
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
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
values (@FirstName,@LastName,@Email,@Phone,@UserName,@Hash,@Salt);
select @UserID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[UserFindByID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserFindByID]
@UserID int
as
begin
select UserID,LastName,Firstname, Email,Phone,UserName, Hash, Salt, 0 RoleID,'NA' RoleName from Users
where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[UserGroupObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UserGroupObtainCount]
as
begin
select count(*) from UserGroup
end
GO
/****** Object:  StoredProcedure [dbo].[UserGroupsCreate]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserGroupsCreate]
@UserID int,
@GroupID int,
@RoleID int

as
begin
insert into UserGroups(UserID, GroupID,RoleID) 
values (@UserID,@GroupID,@RoleID);

end
GO
/****** Object:  StoredProcedure [dbo].[UserGroupsDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserGroupsDelete]
@UserID int,
@GroupID int
as
begin
delete from UserGroups
where UserID = @UserID and GroupID = @GroupID
end
GO
/****** Object:  StoredProcedure [dbo].[UserGroupsObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UserGroupsObtainCount]
as
begin
select count(*) from UserGroups
end
GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 11/7/2019 11:14:02 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UsersFindByEmail]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersFindByEmail]
@Email nvarchar(200)
as
begin
select UserID,LastName,Firstname, Email,Phone,UserName, Hash, Salt, 0 RoleID,'NA' RoleName from Users
where Email = @Email
end
GO
/****** Object:  StoredProcedure [dbo].[UsersFindByUserName]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersFindByUserName]
@UserName nvarchar(100)
as
begin
select UserID,LastName,FirstName, Email,Phone,UserName, Hash, Salt, 0 RoleID, 'NA' RoleName from users
where UserName = @UserName
end
GO
/****** Object:  StoredProcedure [dbo].[UsersGetAll]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersGetAll]
@skip int,
@take int
as
begin
select UserID, LastName, FirstName, Email, Phone, UserName, Hash, Salt, 0 RoleID, 'NA' RoleName from Users
order by Users.UserID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[UsersGetAllbyActivityID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersGetAllbyActivityID]
@skip int,
@take int,
@ActivityID int
as
begin
select Users.UserID,LastName,Firstname, Email,Phone,UserName Hash, Salt, 0 RoleID, 'NA' RoleName from Users 
inner join UserActivities on  Users.UserId = UserActivities.UserID
where ActivityID = @ActivityID
order by Users.UserID 
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[UsersGetAllbyGroupID]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersGetAllbyGroupID]
@skip int,
@take int
as
begin
select Users.UserID, LastName, FirstName, Email, Phone, UserName, Hash, Salt, UserGroups.RoleID, RoleName from Users
inner join UserGroups on Users.UserID = UserGroups.UserID
inner join Roles on UserGroups.RoleID = Roles.RoleID
order by UserGroups.UserID 
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[UsersObtainCount]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UsersObtainCount]
as
begin
select count(*) from Users
end
GO
/****** Object:  StoredProcedure [dbo].[UserUpdateJust]    Script Date: 11/7/2019 11:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserUpdateJust] 
@UserID int,
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
