CREATE PROCEDURE [dbo].[TeacherWorkLoad_Insert]
    @StudyLoad [int],
	@DayOfWeek [int],
	@LessonNumber [int],
	@FromDate [DATE],
	@ToDate [DATE],
	@FkTeacherId [bigint],
    @FkClassId [bigint],
    @FkClassroomId [bigint] 
AS
BEGIN
	IF 	@FromDate < @ToDate
	BEGIN
		INSERT [dbo].[TeacherWorkloadSchedules]
		([StudyLoad],[DayOfWeek],[LessonNumber], [FromDate],
		[ToDate], [FkTeacherId], [FkClassId], [FkClassroomId])
    VALUES (@StudyLoad ,
			@DayOfWeek ,
			@LessonNumber ,
			@FromDate ,
			@ToDate ,
			@FkTeacherId ,
			@FkClassId ,
			@FkClassroomId )
	END
	ELSE
	BEGIN
		RAISERROR (1, -1, -1, 'FromDate should be earlier the ToDate.') 
	END
END
