USE [LMS]
GO
/****** Object:  StoredProcedure [dbo].[P_EventCountByMonth]    Script Date: 2018-11-01 09:02:15 ******/
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
/****** Object:  StoredProcedure [dbo].[p_EventCountByPeriod]    Script Date: 2018-11-01 09:02:15 ******/
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
/****** Object:  StoredProcedure [dbo].[p_EventCountByPeriodAllEvents]    Script Date: 2018-11-01 09:02:15 ******/
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
/****** Object:  StoredProcedure [dbo].[p_EventCountByPeriodSubEvents]    Script Date: 2018-11-01 09:02:15 ******/
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
