GO
/****** Object:  Table [dbo].[InmateHazard]    Script Date: 22.11.2013 16:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

if exists( select * from sys.objects where name = 'InmateHazard' and type = 'u') drop table  [dbo].[InmateHazard]
CREATE TABLE [dbo].[InmateHazard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingNbr] [varchar](7) NULL,
	[SSN] [varchar](9) NULL,
	[Hazard_Code] [varchar](2) NULL,
	[Hazard_Literal] [varchar](42) NULL,
	[Start_Date] [varchar](8) NULL,
	[Start_Time] [varchar](5) NULL,
	[Authorized_by_Operator] [varchar](6) NULL,
	[Clear_Date] [varchar](8) NULL,
	[Clear_Time] [varchar](5) NULL,
	[Cleared_by_Operator] [varchar](6) NULL,
	[Remarks] [varchar](204) NULL,
 CONSTRAINT [PK_InmateHazard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InmateKeepSeparate]    Script Date: 22.11.2013 16:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
if exists( select * from sys.objects where name = 'InmateKeepSeparate' and type = 'u') drop table  [dbo].[InmateKeepSeparate]
CREATE TABLE [dbo].[InmateKeepSeparate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingNbr] [varchar](7) NULL,
	[SSN_Inmate_must_be_kept_away_from] [varchar](9) NULL,
	[SSN_inmate] [varchar](9) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Clear_Date] [datetime] NULL,
 CONSTRAINT [PK_InmateKeepSeparate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InmateRestrictions]    Script Date: 22.11.2013 16:39:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
if exists( select * from sys.objects where name = 'InmateRestrictions' and type = 'u') drop table  [dbo].[InmateRestrictions]
CREATE TABLE [dbo].[InmateRestrictions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingNbr] [varchar](7) NULL,
	[SSN] [varchar](9) NULL,
	[Lockdown] [varchar](1) NULL,
	[Lockdown_From_Date] [varchar](8) NULL,
	[Lockdown_From_Time] [varchar](5) NULL,
	[Lockdown_To_Date] [varchar](8) NULL,
	[Lockdown_To_Time] [varchar](5) NULL,
	[Lockdown_Days] [varchar](3) NULL,
	[Phone] [varchar](1) NULL,
	[Phone_From_Date] [varchar](8) NULL,
	[Phone_To_Date] [varchar](8) NULL,
	[Phone_Days] [varchar](3) NULL,
	[Rem_Program] [varchar](1) NULL,
	[Program_From_Date] [varchar](8) NULL,
	[Program_To_Date] [varchar](8) NULL,
	[Program_Days] [varchar](3) NULL,
	[Commissary] [varchar](1) NULL,
	[Comm_From_Date] [varchar](8) NULL,
	[Comm_To_Date] [varchar](8) NULL,
	[Comm_Days] [varchar](3) NULL,
	[Television] [varchar](1) NULL,
	[TV_From_Date] [varchar](8) NULL,
	[TV_To_Date] [varchar](8) NULL,
	[TV_Days] [varchar](3) NULL,
	[Visitation] [varchar](1) NULL,
	[Visit_From_Date] [varchar](8) NULL,
	[Visit_To_Date] [varchar](8) NULL,
	[Visit_Days] [varchar](3) NULL,
 CONSTRAINT [PK_InmateRestrictions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventCode]    Script Date: 22.11.2013 16:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ActivityLog_EventCodeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[ActivityLog]'))
ALTER TABLE [dbo].[ActivityLog]  DROP  CONSTRAINT [FK_ActivityLog_EventCodeID]


if exists( select * from sys.objects where name = 'EventCode' and type = 'u') drop table  [dbo].[EventCode]
CREATE TABLE [dbo].[EventCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NULL,
	[Description] [varchar](250) NULL
 CONSTRAINT [PK_EventCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

truncate table [dbo].[EventCode]

SET IDENTITY_INSERT [dbo].[EventCode] ON 

GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (1, N'CLCK', N'Cell Check')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (2, N'OTCL', N'Out of Cell')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (3, N'SECK', N'Security Check')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (4, N'SPLY', N'Supply')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (5, N'RECR', N'Recreation')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (6, N'HDCT', N'Headcount')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (7, N'MEAL', N'Meals')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (8, N'GENR', N'General')
GO
INSERT [dbo].[EventCode] ([Id], [Code], [Description]) VALUES (9, N'OFFC', N'Officer Log in/out')
GO
SET IDENTITY_INSERT [dbo].[EventCode] OFF
GO




/****** Object:  UserDefinedFunction [dbo].[GetCodeByLog]    Script Date: 22.11.2013 17:10:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists( select * from sys.objects where name = 'GetCodeByLog' and type = 'FN') drop function [dbo].[GetCodeByLog]
GO
CREATE function [dbo].[GetCodeByLog] (@Name varchar(8000))
returns int
as
begin
	declare @result varchar(10) = ''

	select @result = 'OTCL' from OutOfCell where (@Name like '%to%' + Name + '%' or @Name like '%from%' + Name + '%')
	and Name not like '%Recreation%'

	if(@result = '')
	begin	
		select @result =
			case 
				when @Name like '%logged%' then 'OFFC'
				when @Name like '%Head%count%' then 'HDCT'
				when @Name like '%On bunk%' then 'CLCK'
				when @Name like '%Absent%' then 'CLCK'
				when @Name like '%Meal%' then 'MEAL'
				when @Name like '%library%' or @Name like '%services%' or @Name like '%visitation%' or @Name like '%Classroom%' or @Name like '%Court%' or @Name like '%To GED%' or @Name like '%From GED%' or @Name like '%Med on%' or @Name like '%Med off%' or @Name like '%Discipline%' then 'OTCL'
				when @Name like '%Security%Check%' and @Name like '%Wristband%' then 'SECK'
				when @Name like '%General%Security%Check%'then 'SECK'
				when @Name like '%Cell%' then 'CLCK'
				when @Name like '%Resting%' or @Name like '%Recreation%'  or @Name like '%dayroom%' then 'RECR'
				when @Name like '%to inmate%' or @Name like '%from inmate%' or @Name like '%to offender%' or @Name like '%from offender%' then 'SPLY'
				when @Name like '%Security%Check%' or @Name like '%In Doorway%' then 'SECK'
				when @Name like '*%' then 'SECK'
				else 'GENR'
			end
	end

	return (select Id from EventCode where Code = @result)
end



GO


if exists(select * from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME = 'EventCodeID' and TABLE_NAME = 'ActivityLog' and TABLE_SCHEMA = 'dbo')
alter table ActivityLog drop column EventCodeID

alter table ActivityLog add EventCodeID int




IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ActivityLog_EventCodeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[ActivityLog]'))
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_EventCodeID] FOREIGN KEY([EventCodeID])
REFERENCES [dbo].[EventCode] ([Id])

GO


/****** Object:  StoredProcedure [dbo].[Tiburon_ActivityLog]    Script Date: 28.11.2013 13:14:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists( select * from sys.objects where name = 'Tiburon_ActivityLog' and type = 'P') drop procedure [dbo].[Tiburon_ActivityLog]
if exists( select * from sys.objects where name = 'Export_ActivityLog' and type = 'P') drop procedure [dbo].[Export_ActivityLog]
GO
CREATE PROCEDURE [dbo].[Export_ActivityLog]
	@date as datetime
AS
BEGIN

	select 
		i.SSN as JRN
	  , l.BookingNbr as Booking
	  , l.DateTime1 as DateTime
	  , l.OfficerNbr2 as Officer
	  , l.LocationID
	  , loc.Name as LocationName
	  , d.Name as Activity
	  , ec.Code
	  , ec.Description as Code_Description
	from ActivityLog l
	left join ActivityDetails d on l.ActivityLogUID = d.ActivityLogUID
	left join EventCode ec on ec.Id = EventCodeID
	left join Inmate i on l.BookingNbr = i.CurrentBookingNbr
	left join 
	(
		select CellID as ID, CellNbr as Name from dbo.Cell
		union all
		select SubSectionID, Name from SubSection
		union all
		select OutOfCellID, Name from OutOfCell
		union all
		select OtherID, Name from OtherLocations
		union all
		select LocationID, Name from Location
		union all
		select FacilityID, SectionName from Section
	)  loc on loc.ID = l.LocationID
	where l.DateTime1 >= @date                     
	order by l.DateTime1
END

GO


--select distinct LocationID from ActivityLog
--where LocationID not in
--(
--select CellID from dbo.Cell
--union all
--select SubSectionID from SubSection
--union all
--select OutOfCellID from OutOfCell
--union all
--select OtherID from OtherLocations
--union all
--select LocationID from Location
--union all
--select FacilityID from Section
--)


/****** Object:  StoredProcedure [dbo].[Tiburon_Inmates]    Script Date: 28.11.2013 13:14:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
if exists( select * from sys.objects where name = 'Tiburon_Inmates' and type = 'P') drop procedure [dbo].[Tiburon_Inmates]
if exists( select * from sys.objects where name = 'Export_Inamte_OutOfCell' and type = 'P') drop procedure [dbo].[Export_Inamte_OutOfCell]
GO
CREATE PROCEDURE [dbo].[Export_Inamte_OutOfCell]
AS
BEGIN
	select 
		  Inmate.SSN as JRN
		, Inmate.CurrentBookingNbr as Booking
		, OutOfCell.OutOfCellID
		, OutOfCell.Name as OutOfCell_Name
	from dbo.Inmate
	left join dbo.OutOfCell on Inmate.OutofCellID = OutOfCell.OutOfCellID
END

GO



update l set EventCodeID = [dbo].[GetCodeByLog](d.Name) 
from ActivityLog l
join ActivityDetails d on l.ActivityLogUID = d.ActivityLogUID


