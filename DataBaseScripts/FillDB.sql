SET IDENTITY_INSERT  ScheduleStatus ON;  
GO
MERGE INTO ScheduleStatus AS [Target]
USING(
VALUES
(1, 'Ordered'),
(2, 'Is Progress'),
(3, 'Cancelled')
)AS [Sourse]([Id],[Name])
ON ([Target].[Id] = [Sourse].Id)
WHEN NOT MATCHED BY TARGET THEN
INSERT([Id],[Name])
VALUES([Sourse].[Id], [Sourse].[Name]);

DECLARE @mergeError int
, @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
    IF @mergeError != 0
        BEGIN
        PRINT 'ERROR OCCURRED IN MERGE FOR dbo.[ScheduleStatus]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
        END
    ELSE
        BEGIN
        PRINT 'dbo.[ScheduleStatus] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
    END
GO
SET IDENTITY_INSERT  ScheduleStatus OFF;  


GO
SET IDENTITY_INSERT  VisitType ON;  
GO
MERGE INTO VisitType AS [Target]
USING(
VALUES
	(1, 'One-time subscription'),
	(2, 'Long-time subscription'),
	(3, 'Witch coach')
)AS [Sourse]([Id],[Name])
ON ([Target].[Id] = [Sourse].Id)
WHEN NOT MATCHED BY TARGET THEN
INSERT([Id],[Name])
VALUES([Sourse].[Id], [Sourse].[Name]);

DECLARE @mergeError int
, @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
    IF @mergeError != 0
        BEGIN
        PRINT 'ERROR OCCURRED IN MERGE FOR dbo.[VisitType]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
        END
    ELSE
        BEGIN
        PRINT 'dbo.[VisitType] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
    END
GO
SET IDENTITY_INSERT  VisitType OFF;  
GO

SET IDENTITY_INSERT  [Role] ON;  
GO
MERGE INTO [Role] AS [Target]
USING(
VALUES
	(1, 'Visitor'),
	(2, 'Administrator'),
	(3, 'Coach')
)AS [Sourse]([Id],[Name])
ON ([Target].[Id] = [Sourse].Id)
WHEN NOT MATCHED BY TARGET THEN
INSERT([Id],[Name])
VALUES([Sourse].[Id], [Sourse].[Name]);

DECLARE @mergeError int
, @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
    IF @mergeError != 0
        BEGIN
        PRINT 'ERROR OCCURRED IN MERGE FOR dbo.[Role]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
        END
    ELSE
        BEGIN
        PRINT 'dbo.[Role] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
    END

GO
SET IDENTITY_INSERT  [Role] OFF;  