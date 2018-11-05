USE [LMS]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventLog](
	[EventLogId] [int] IDENTITY(1,1) NOT NULL,
	[EventLogTime] [datetime] NOT NULL,
	[EventLogUserId] [nchar](50) NULL,
	[EventTypeId] [int] NOT NULL,
	[EventLogManualTime] [datetime] NULL,
	[CustomerId] [int] NULL,
	[TestBedId] [int] NULL,
	[TestId] [int] NULL,
	[TestObjectId] [int] NULL,
	[DeviceId] [int] NULL,
	[UserObjectId] [int] NULL,
	[ItemId] [int] NULL,
	[EventValue] [int] NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_ErrorLog_ErrorLogID] PRIMARY KEY CLUSTERED 
(
	[EventLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeSubId] [int] NULL,
	[EventTypeDescription] [nchar](100) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemGroup](
	[ItemGroupId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED 
(
	[ItemGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportType]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportType](
	[ReportTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ReportTypeText] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReportType] PRIMARY KEY CLUSTERED 
(
	[ReportTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 2018-11-01 09:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nchar](50) NOT NULL,
	[TestObjectId] [int] NULL,
	[TestBedId] [int] NOT NULL,
	[TestModuleId] [int] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestBed]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestBed](
	[TestBedId] [int] IDENTITY(1,1) NOT NULL,
	[TestBedName] [nchar](50) NOT NULL,
 CONSTRAINT [PK_TestBed] PRIMARY KEY CLUSTERED 
(
	[TestBedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestModule]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestModule](
	[TestModuleId] [int] IDENTITY(1,1) NOT NULL,
	[TestModuleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TestModule] PRIMARY KEY CLUSTERED 
(
	[TestModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestObject]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestObject](
	[TestObjectId] [int] IDENTITY(1,1) NOT NULL,
	[TestObjectIdName] [nchar](50) NOT NULL,
 CONSTRAINT [PK_TestObject] PRIMARY KEY CLUSTERED 
(
	[TestObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserObject]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserObject](
	[UserObjectId] [int] IDENTITY(1,1) NOT NULL,
	[UserObjectName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventLog] ADD  CONSTRAINT [DF_EventLog_EventTime]  DEFAULT (getdate()) FOR [EventLogTime]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Customer]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Device]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_EventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventType] ([EventTypeId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_EventType]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Item]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Test]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_TestBed] FOREIGN KEY([TestBedId])
REFERENCES [dbo].[TestBed] ([TestBedId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_TestBed]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_TestObject] FOREIGN KEY([TestObjectId])
REFERENCES [dbo].[TestObject] ([TestObjectId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_TestObject]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_User] FOREIGN KEY([UserObjectId])
REFERENCES [dbo].[UserObject] ([UserObjectId])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_User]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_TestModule] FOREIGN KEY([TestModuleId])
REFERENCES [dbo].[TestModule] ([TestModuleId])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_TestModule]
GO
/****** Object:  StoredProcedure [dbo].[P_EventCountByMonth]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[P_EventCountByMonth]
	@start DATETIME
	as
SELECT
	DateAdd(MONTH, DateDiff(Month, 0, EventLogTime), 0) as [Month],
	count(DateAdd(MONTH, DateDiff(Month, 0, EventLogTime), 0)) AS [Quantity]
FROM 
	eventlog
WHERE
	EventLogTime >= @start
GROUP BY DateAdd(MONTH, DateDiff(Month, 0, EventLogTime), 0) 

GO
/****** Object:  StoredProcedure [dbo].[p_EventCountByPeriod]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	To group eventtypes occurrences.
	Anders Selborn

*/

CREATE PROCEDURE [dbo].[p_EventCountByPeriod] --'2018-01-01','2018-10-10','38','10','Month'
	@start DATETIME,
	@stop DATETIME,
	@testBedId INT,
	@eventTypeId INT,
	@grpBy varchar(10),
	@isTopCategory TinyInt = null

	AS

	IF @grpBy = 'Year'
		BEGIN
			SELECT
				DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0) as [YEAR],
				count(DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0)) AS [Quantity]
			FROM 
				eventlog
			WHERE
				EventTypeId = @eventTypeId
			AND
				TestBedId= @TestBedId
			AND 
				EventLogManualTime BETWEEN @start AND @stop
			AND
				Deleted != 1
				GROUP BY DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0) 

			END

	ELSE IF @grpBy = 'Month'
		BEGIN
			SELECT
				DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0) as [Month],
					count(DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					EventTypeId = @eventTypeId
				AND
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0) 
			END
	 
	 
	ELSE IF @grpBy = 'Week'
		BEGIN
			SELECT
				DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0) as [WEEK],
					count(DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					EventTypeId = @eventTypeId
				AND
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0) 
			END

	ELSE IF @grpBy = 'Day'
		BEGIN
			SELECT
				DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0) as [DAY],
					count(DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					EventTypeId = @eventTypeId
				AND
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0) 
			END
GO
/****** Object:  StoredProcedure [dbo].[p_EventCountByPeriodAllEvents]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	To group eventtypes occurrences.
	Anders Selborn

*/

CREATE PROCEDURE [dbo].[p_EventCountByPeriodAllEvents] --'2018-10-11','2018-10-11','1','0','Day'
	@start DATETIME,
	@stop DATETIME,
	@testBedId INT,
	@eventTypeId INT,
	@grpBy varchar(10),
	@isTopCategory TinyInt = null

	AS
	DECLARE @DayDiff INT
	

	IF @grpBy = 'Year'
		BEGIN
			SELECT
				DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0) as [YEAR],
				count(DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0)) AS [Quantity]
			FROM 
				eventlog
			WHERE
				TestBedId= @TestBedId
			AND 
				EventLogManualTime BETWEEN @start AND @stop
			AND
				Deleted != 1
				GROUP BY DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0) 
			END

	ELSE IF @grpBy = 'Month'
		BEGIN
			SELECT
				DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0) as [Month],
					count(DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0) 
			END
	 
	 
	ELSE IF @grpBy = 'Week'
		BEGIN
			SELECT
				DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0) as [WEEK],
					count(DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0) 
			END

	ELSE IF @grpBy = 'Day'
		BEGIN
			
			SET @DayDiff = (SELECT DATEDIFF(day, @start,@stop))
			IF @DayDiff = 0
				SELECT 
					et.EventTypeDescription, count(e.eventTypeId) as Number
				FROM 
					EventLog e
					INNER JOIN EventType et ON e.EventTypeId=et.EventTypeId
				WHERE
					TestBedId= @TestBedId
					AND 
						EventLogManualTime BETWEEN @start AND @stop
					AND
						Deleted != 1
					GROUP BY et.EventTypeDescription
							
			ELSE
				SELECT
					DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0) as [DAY],
					count(DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0) 
			END
GO
/****** Object:  StoredProcedure [dbo].[p_EventCountByPeriodSubEvents]    Script Date: 2018-11-01 09:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	To group eventtypes occurrences.
	Anders Selborn

*/

CREATE PROCEDURE [dbo].[p_EventCountByPeriodSubEvents] --'2018-01-01','2018-10-10','38','10','Month'
	@start DATETIME,
	@stop DATETIME,
	@testBedId INT,
	@eventTypeId INT,
	@grpBy varchar(10),
	@isTopCategory TinyInt = null

	AS

	IF @grpBy = 'Year'
		BEGIN
			SELECT
				DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0) as [YEAR],
				count(DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0)) AS [Quantity]
			FROM 
				eventlog
			WHERE
				EventTypeId IN( SELECT eventTypeID from EventType where eventTypeSubId=@eventTypeId)
			AND
				TestBedId= @TestBedId
			AND 
				EventLogManualTime BETWEEN @start AND @stop
			AND
				Deleted != 1
				GROUP BY DateAdd(YEAR, DateDiff(YEAR, 0, EventLogManualTime), 0) 

			END

	ELSE IF @grpBy = 'Month'
		BEGIN
			SELECT
				DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0) as [Month],
					count(DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					EventTypeId IN( SELECT eventTypeID from EventType where eventTypeSubId=@eventTypeId)
				AND
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(MONTH, DateDiff(MONTH, 0, EventLogManualTime), 0) 
			END
	 
	 
	ELSE IF @grpBy = 'Week'
		BEGIN
			SELECT
				DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0) as [WEEK],
					count(DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					EventTypeId IN( SELECT eventTypeID from EventType where eventTypeSubId=@eventTypeId)
				AND
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
					GROUP BY DateAdd(WEEK, DateDiff(WEEK, 0, EventLogManualTime), 0) 
			END

	ELSE IF @grpBy = 'Day'
		BEGIN
			SELECT
				DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0) as [DAY],
					count(DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0)) AS [Quantity]
				FROM 
					eventlog
				WHERE
					EventTypeId IN( SELECT eventTypeID from EventType where eventTypeSubId=@eventTypeId)
				AND
					TestBedId= @TestBedId
				AND 
					EventLogManualTime BETWEEN @start AND @stop
				AND
				Deleted != 1
					GROUP BY DateAdd(DAY, DateDiff(DAY, 0, EventLogManualTime), 0) 
			END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'What kind of report did the user choose?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReportType', @level2type=N'COLUMN',@level2name=N'ReportTypeId'
GO
