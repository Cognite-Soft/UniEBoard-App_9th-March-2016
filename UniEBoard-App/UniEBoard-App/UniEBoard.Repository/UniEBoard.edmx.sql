



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 02/24/2014 12:55:23
-- Generated from EDMX file: C:\Users\araza\Documents\GitHub\UniEBoard\UniEBoard - WebApp\UniEBoard.Repository\UniEBoard.edmx
-- Target version: 3.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `Courses` DROP CONSTRAINT `FK_AccreditationCourse`;
--    ALTER TABLE `Answers` DROP CONSTRAINT `FK_QuestionAnswer`;
--    ALTER TABLE `Submissions` DROP CONSTRAINT `FK_AssignmentSubmission`;
--    ALTER TABLE `Assignments` DROP CONSTRAINT `FK_QuizAssignment`;
--    ALTER TABLE `CourseModules` DROP CONSTRAINT `FK_CourseCourseModules`;
--    ALTER TABLE `CourseRegistrations` DROP CONSTRAINT `FK_CourseCourseRegistration`;
--    ALTER TABLE `CourseRegistrations` DROP CONSTRAINT `FK_StudentCourseRegistration`;
--    ALTER TABLE `StaffCourses` DROP CONSTRAINT `FK_CourseStaffCourses`;
--    ALTER TABLE `Courses` DROP CONSTRAINT `FK_CourseTemplateCourse`;
--    ALTER TABLE `Users` DROP CONSTRAINT `FK_GenderUser`;
--    ALTER TABLE `Users` DROP CONSTRAINT `FK_UserMembership`;
--    ALTER TABLE `RolePermissions` DROP CONSTRAINT `FK_RolePermissionsPermission`;
--    ALTER TABLE `Users_Staff` DROP CONSTRAINT `FK_PositionStaff`;
--    ALTER TABLE `QuestionChoices` DROP CONSTRAINT `FK_QuestionQuestionOptions`;
--    ALTER TABLE `Questions` DROP CONSTRAINT `FK_QuizQuestion`;
--    ALTER TABLE `QuizEntries` DROP CONSTRAINT `FK_QuizQuizEntry`;
--    ALTER TABLE `QuizEntries` DROP CONSTRAINT `FK_StudentQuizEntry`;
--    ALTER TABLE `RolePermissions` DROP CONSTRAINT `FK_RoleRolePermissions`;
--    ALTER TABLE `StaffCourses` DROP CONSTRAINT `FK_StaffStaffCourses`;
--    ALTER TABLE `Units` DROP CONSTRAINT `FK_StaffUnit`;
--    ALTER TABLE `Submissions` DROP CONSTRAINT `FK_StudentSubmission`;
--    ALTER TABLE `Tasks` DROP CONSTRAINT `FK_UserTask`;
--    ALTER TABLE `UserPermission` DROP CONSTRAINT `FK_UserPermission_Permission`;
--    ALTER TABLE `UserPermission` DROP CONSTRAINT `FK_UserPermission_User`;
--    ALTER TABLE `UserRole` DROP CONSTRAINT `FK_UserRole_Role`;
--    ALTER TABLE `UserRole` DROP CONSTRAINT `FK_UserRole_User`;
--    ALTER TABLE `Messages` DROP CONSTRAINT `FK_UserMessage`;
--    ALTER TABLE `Messages` DROP CONSTRAINT `FK_UserMessage1`;
--    ALTER TABLE `ViewedMessages` DROP CONSTRAINT `FK_UserStudentViewedAlerts`;
--    ALTER TABLE `ViewedMessages` DROP CONSTRAINT `FK_MessageViewedMessage`;
--    ALTER TABLE `Groups` DROP CONSTRAINT `FK_StaffGroup`;
--    ALTER TABLE `UserGroups` DROP CONSTRAINT `FK_UserUserGroup`;
--    ALTER TABLE `UserGroups` DROP CONSTRAINT `FK_GroupUserGroup`;
--    ALTER TABLE `GroupMessages` DROP CONSTRAINT `FK_GroupGroupMessage`;
--    ALTER TABLE `GroupMessages` DROP CONSTRAINT `FK_MessageGroupMessage`;
--    ALTER TABLE `Assignments` DROP CONSTRAINT `FK_CourseAssignment`;
--    ALTER TABLE `Assignments` DROP CONSTRAINT `FK_UnitAssignment`;
--    ALTER TABLE `BaseFiles` DROP CONSTRAINT `FK_SubmissionFileUpload`;
--    ALTER TABLE `BaseFiles` DROP CONSTRAINT `FK_AssignmentFileUpload`;
--    ALTER TABLE `Answers` DROP CONSTRAINT `FK_QuizEntryAnswer`;
--    ALTER TABLE `ModuleQuizs` DROP CONSTRAINT `FK_QuizModuleQuiz`;
--    ALTER TABLE `AnswerQuestionChoices` DROP CONSTRAINT `FK_QuestionChoiceAnswerQuestionChoice`;
--    ALTER TABLE `AnswerQuestionChoices` DROP CONSTRAINT `FK_AnswerAnswerQuestionChoice`;
--    ALTER TABLE `Schedules` DROP CONSTRAINT `FK_CourseSchedule`;
--    ALTER TABLE `Schedules` DROP CONSTRAINT `FK_UnitSchedule`;
--    ALTER TABLE `TopicPosts` DROP CONSTRAINT `FK_UserTopicPost`;
--    ALTER TABLE `TopicPosts` DROP CONSTRAINT `FK_TopicPostTopicPost`;
--    ALTER TABLE `TopicPosts` DROP CONSTRAINT `FK_TopicTopicPost`;
--    ALTER TABLE `BaseQuestionTopics` DROP CONSTRAINT `FK_UserBaseQuestionTopic`;
--    ALTER TABLE `Contacts` DROP CONSTRAINT `FK_CompanyContact`;
--    ALTER TABLE `Courses` DROP CONSTRAINT `FK_DepartmentCourse`;
--    ALTER TABLE `Users` DROP CONSTRAINT `FK_CompanyUser`;
--    ALTER TABLE `Courses` DROP CONSTRAINT `FK_CompanyCourse`;
--    ALTER TABLE `Users_Staff` DROP CONSTRAINT `FK_DepartmentStaff`;
--    ALTER TABLE `TagAsset` DROP CONSTRAINT `FK_TagAsset_Tag`;
--    ALTER TABLE `TagAsset` DROP CONSTRAINT `FK_TagAsset_Asset`;
--    ALTER TABLE `Assets` DROP CONSTRAINT `FK_CompanyAsset`;
--    ALTER TABLE `Units` DROP CONSTRAINT `FK_UnitVideo`;
--    ALTER TABLE `Units` DROP CONSTRAINT `FK_UnitDocument`;
--    ALTER TABLE `Assignments` DROP CONSTRAINT `FK_ModuleAssignment`;
--    ALTER TABLE `CourseModules` DROP CONSTRAINT `FK_ModuleCourseModules`;
--    ALTER TABLE `ModuleQuizs` DROP CONSTRAINT `FK_ModuleModuleQuiz`;
--    ALTER TABLE `Units` DROP CONSTRAINT `FK_ModuleUnit`;
--    ALTER TABLE `Modules` DROP CONSTRAINT `FK_StaffModule`;
--    ALTER TABLE `BaseQuestionTopics_Topic` DROP CONSTRAINT `FK_DiscussionTopic`;
--    ALTER TABLE `Discussions` DROP CONSTRAINT `FK_CourseDiscussion`;
--    ALTER TABLE `Discussions` DROP CONSTRAINT `FK_TopicPostDiscussion`;
--    ALTER TABLE `Assets_WebPage` DROP CONSTRAINT `FK_Assets_WebPage_Assets`;
--    ALTER TABLE `webpages_UsersInRoles` DROP CONSTRAINT `FK_webpages_UsersInRoles_webpages_Roles`;
--    ALTER TABLE `webpages_UsersInRoles` DROP CONSTRAINT `FK_webpages_UsersInRoles_Membership`;
--    ALTER TABLE `UnitAsset` DROP CONSTRAINT `FK_UnitAsset_Asset`;
--    ALTER TABLE `UnitAsset` DROP CONSTRAINT `FK_UnitAsset_Unit`;
--    ALTER TABLE `Units` DROP CONSTRAINT `FK_QuizUnit`;
--    ALTER TABLE `AssignmentAsset` DROP CONSTRAINT `FK_AssignmentAsset_Asset`;
--    ALTER TABLE `AssignmentAsset` DROP CONSTRAINT `FK_AssignmentAsset_Assignment`;
--    ALTER TABLE `Users_Student` DROP CONSTRAINT `FK_Student_inherits_User`;
--    ALTER TABLE `Users_Staff` DROP CONSTRAINT `FK_Staff_inherits_User`;
--    ALTER TABLE `BaseQuestionTopics_Topic` DROP CONSTRAINT `FK_Topic_inherits_BaseQuestionTopic`;
--    ALTER TABLE `Assets_Video` DROP CONSTRAINT `FK_Video_inherits_Asset`;
--    ALTER TABLE `Assets_Document` DROP CONSTRAINT `FK_Document_inherits_Asset`;
--    ALTER TABLE `BaseFiles_File` DROP CONSTRAINT `FK_File_inherits_BaseFile`;
--    ALTER TABLE `BaseQuestionTopics_UserQuestion` DROP CONSTRAINT `FK_UserQuestion_inherits_BaseQuestionTopic`;
--    ALTER TABLE `Assets_Image` DROP CONSTRAINT `FK_Image_inherits_Asset`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `Accreditations`;
    DROP TABLE IF EXISTS `Messages`;
    DROP TABLE IF EXISTS `Answers`;
    DROP TABLE IF EXISTS `Assignments`;
    DROP TABLE IF EXISTS `CourseModules`;
    DROP TABLE IF EXISTS `CourseRegistrations`;
    DROP TABLE IF EXISTS `Courses`;
    DROP TABLE IF EXISTS `CourseTemplates`;
    DROP TABLE IF EXISTS `Departments`;
    DROP TABLE IF EXISTS `BaseFiles`;
    DROP TABLE IF EXISTS `Genders`;
    DROP TABLE IF EXISTS `Groups`;
    DROP TABLE IF EXISTS `Memberships`;
    DROP TABLE IF EXISTS `Permissions`;
    DROP TABLE IF EXISTS `Positions`;
    DROP TABLE IF EXISTS `QuestionChoices`;
    DROP TABLE IF EXISTS `Questions`;
    DROP TABLE IF EXISTS `QuizEntries`;
    DROP TABLE IF EXISTS `Quizs`;
    DROP TABLE IF EXISTS `RolePermissions`;
    DROP TABLE IF EXISTS `Roles`;
    DROP TABLE IF EXISTS `StaffCourses`;
    DROP TABLE IF EXISTS `Submissions`;
    DROP TABLE IF EXISTS `Tasks`;
    DROP TABLE IF EXISTS `Units`;
    DROP TABLE IF EXISTS `Users`;
    DROP TABLE IF EXISTS `ViewedMessages`;
    DROP TABLE IF EXISTS `UserGroups`;
    DROP TABLE IF EXISTS `GroupMessages`;
    DROP TABLE IF EXISTS `ModuleQuizs`;
    DROP TABLE IF EXISTS `AnswerQuestionChoices`;
    DROP TABLE IF EXISTS `Schedules`;
    DROP TABLE IF EXISTS `TopicPosts`;
    DROP TABLE IF EXISTS `BaseQuestionTopics`;
    DROP TABLE IF EXISTS `Companies`;
    DROP TABLE IF EXISTS `Contacts`;
    DROP TABLE IF EXISTS `Assets`;
    DROP TABLE IF EXISTS `Tags`;
    DROP TABLE IF EXISTS `Modules`;
    DROP TABLE IF EXISTS `Discussions`;
    DROP TABLE IF EXISTS `Assets_WebPage`;
    DROP TABLE IF EXISTS `sysdiagrams`;
    DROP TABLE IF EXISTS `webpages_Membership`;
    DROP TABLE IF EXISTS `webpages_OAuthMembership`;
    DROP TABLE IF EXISTS `webpages_Roles`;
    DROP TABLE IF EXISTS `Users_Student`;
    DROP TABLE IF EXISTS `Users_Staff`;
    DROP TABLE IF EXISTS `BaseQuestionTopics_Topic`;
    DROP TABLE IF EXISTS `Assets_Video`;
    DROP TABLE IF EXISTS `Assets_Document`;
    DROP TABLE IF EXISTS `BaseFiles_File`;
    DROP TABLE IF EXISTS `BaseQuestionTopics_UserQuestion`;
    DROP TABLE IF EXISTS `Assets_Image`;
    DROP TABLE IF EXISTS `UserPermission`;
    DROP TABLE IF EXISTS `UserRole`;
    DROP TABLE IF EXISTS `TagAsset`;
    DROP TABLE IF EXISTS `webpages_UsersInRoles`;
    DROP TABLE IF EXISTS `UnitAsset`;
    DROP TABLE IF EXISTS `AssignmentAsset`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

CREATE TABLE `Accreditations`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Description` longtext NOT NULL);

ALTER TABLE `Accreditations` ADD PRIMARY KEY (Id);




CREATE TABLE `Messages`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Body` longtext NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`MessageType` int NOT NULL, 
	`FromUserId` int NOT NULL, 
	`RecipientUserId` int, 
	`Comments` longtext, 
	`EntityId` int, 
	`MessageViewed` bool NOT NULL);

ALTER TABLE `Messages` ADD PRIMARY KEY (Id);




CREATE TABLE `Answers`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Question_Id` int NOT NULL, 
	`QuizEntryId` int NOT NULL);

ALTER TABLE `Answers` ADD PRIMARY KEY (Id);




CREATE TABLE `Assignments`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Deadline` datetime( 3 )  NOT NULL, 
	`PublishFrom` datetime( 3 )  NOT NULL, 
	`PublishTo` datetime( 3 )  NOT NULL, 
	`QuizId` int, 
	`Title` longtext NOT NULL, 
	`Instructions` longtext NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`CourseId` int, 
	`ModuleId` int, 
	`UnitId` int, 
	`PointsPossible` int);

ALTER TABLE `Assignments` ADD PRIMARY KEY (Id);




CREATE TABLE `CourseModules`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Course_Id` int NOT NULL, 
	`Module_Id` int NOT NULL);

ALTER TABLE `CourseModules` ADD PRIMARY KEY (Id);




CREATE TABLE `CourseRegistrations`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`EffectiveFrom` datetime( 3 ) , 
	`EffectiveTo` datetime( 3 ) , 
	`Student_Id` int NOT NULL, 
	`Course_Id` int NOT NULL);

ALTER TABLE `CourseRegistrations` ADD PRIMARY KEY (Id);




CREATE TABLE `Courses`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Overview` longtext, 
	`Length` longtext, 
	`PublishFrom` datetime( 3 ) , 
	`PublishTo` datetime( 3 ) , 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`Approved` bool NOT NULL, 
	`Accreditation_Id` int NOT NULL, 
	`CourseTemplate_Id` int NOT NULL, 
	`DepartmentId` int, 
	`CompanyId` int NOT NULL, 
	`Code` longtext, 
	`SortOrder` int, 
	`OwnerId` int);

ALTER TABLE `Courses` ADD PRIMARY KEY (Id);




CREATE TABLE `CourseTemplates`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Description` longtext NOT NULL);

ALTER TABLE `CourseTemplates` ADD PRIMARY KEY (Id);




CREATE TABLE `Departments`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL);

ALTER TABLE `Departments` ADD PRIMARY KEY (Id);




CREATE TABLE `BaseFiles`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`FileName` longtext NOT NULL, 
	`SubmissionId` int, 
	`AssignmentId` int, 
	`Extension` longtext NOT NULL, 
	`DateCreated` longtext NOT NULL, 
	`FilePath` longtext, 
	`IdentityToken` CHAR(36) BINARY NOT NULL, 
	`UnitId` int);

ALTER TABLE `BaseFiles` ADD PRIMARY KEY (Id);




CREATE TABLE `Genders`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Description` longtext NOT NULL);

ALTER TABLE `Genders` ADD PRIMARY KEY (Id);




CREATE TABLE `Groups`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL, 
	`Description` longtext, 
	`AssignedStaffId` int NOT NULL);

ALTER TABLE `Groups` ADD PRIMARY KEY (Id);




CREATE TABLE `Memberships`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`UserName` longtext NOT NULL);

ALTER TABLE `Memberships` ADD PRIMARY KEY (Id);




CREATE TABLE `Permissions`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL);

ALTER TABLE `Permissions` ADD PRIMARY KEY (Id);




CREATE TABLE `Positions`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Description` longtext NOT NULL);

ALTER TABLE `Positions` ADD PRIMARY KEY (Id);




CREATE TABLE `QuestionChoices`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL, 
	`PointsValue` smallint NOT NULL, 
	`DisplayOrder` smallint NOT NULL, 
	`CorrectAnswer` bool NOT NULL, 
	`Question_Id` int NOT NULL);

ALTER TABLE `QuestionChoices` ADD PRIMARY KEY (Id);




CREATE TABLE `Questions`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL, 
	`AllowMultipleSelections` bool NOT NULL, 
	`HelpText` longtext, 
	`Quiz_Id` int NOT NULL, 
	`QuestionType_Id` int NOT NULL, 
	`Explanation` longtext, 
	`SortOrder` int);

ALTER TABLE `Questions` ADD PRIMARY KEY (Id);




CREATE TABLE `QuizEntries`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Student_Id` int NOT NULL, 
	`Quiz_Id` int NOT NULL, 
	`QuizResult` int);

ALTER TABLE `QuizEntries` ADD PRIMARY KEY (Id);




CREATE TABLE `Quizs`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`PublishFrom` datetime( 3 )  NOT NULL, 
	`PublishTo` datetime( 3 )  NOT NULL, 
	`MaxAttemptsAllowed` int, 
	`Description` longtext, 
	`DisplayEndResults` int NOT NULL, 
	`CorrectUserChoices` bool NOT NULL, 
	`Instructions` longtext, 
	`Deadline` datetime( 3 ) );

ALTER TABLE `Quizs` ADD PRIMARY KEY (Id);




CREATE TABLE `RolePermissions`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Permissions_Id` int NOT NULL, 
	`RoleId` int NOT NULL);

ALTER TABLE `RolePermissions` ADD PRIMARY KEY (Id);




CREATE TABLE `Roles`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Description` longtext);

ALTER TABLE `Roles` ADD PRIMARY KEY (Id);




CREATE TABLE `StaffCourses`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`EffectiveFrom` datetime( 3 ) , 
	`EffectiveTo` datetime( 3 ) , 
	`Staff_Id` int NOT NULL, 
	`Course_Id` int NOT NULL, 
	`DateCreated` datetime( 3 ) , 
	`Location` longtext);

ALTER TABLE `StaffCourses` ADD PRIMARY KEY (Id);




CREATE TABLE `Submissions`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext, 
	`Body` longtext, 
	`DateSubmitted` longtext, 
	`Status` longtext NOT NULL, 
	`StudentId` int NOT NULL, 
	`AssignmentId` int NOT NULL, 
	`GradePointValue` int);

ALTER TABLE `Submissions` ADD PRIMARY KEY (Id);




CREATE TABLE `Tasks`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Note` longtext, 
	`Deadline` datetime( 3 ) , 
	`IsCompleted` bool NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`UserId` int NOT NULL);

ALTER TABLE `Tasks` ADD PRIMARY KEY (Id);




CREATE TABLE `Units`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Description` longtext, 
	`PublishFrom` datetime( 3 ) , 
	`PublishTo` datetime( 3 ) , 
	`StaffId` int NOT NULL, 
	`ModuleId` int, 
	`VideoId` int, 
	`DocumentId` int, 
	`AssignmentId` int, 
	`SortOrder` int, 
	`QuizId` int, 
	`Duration` double);

ALTER TABLE `Units` ADD PRIMARY KEY (Id);




CREATE TABLE `Users`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`UserName` longtext NOT NULL, 
	`FirstName` longtext NOT NULL, 
	`LastName` longtext NOT NULL, 
	`Email` longtext NOT NULL, 
	`DateOfBirth` datetime( 3 ) , 
	`UserGender` int NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`Mobile` longtext, 
	`Phone` longtext, 
	`AccountDisabled` bool NOT NULL, 
	`Membership_Id` int NOT NULL, 
	`CompanyId` int NOT NULL);

ALTER TABLE `Users` ADD PRIMARY KEY (Id);




CREATE TABLE `ViewedMessages`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`UserId` int NOT NULL, 
	`MessageId` int NOT NULL);

ALTER TABLE `ViewedMessages` ADD PRIMARY KEY (Id);




CREATE TABLE `UserGroups`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`UserId` int NOT NULL, 
	`GroupId` int NOT NULL);

ALTER TABLE `UserGroups` ADD PRIMARY KEY (Id);




CREATE TABLE `GroupMessages`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`GroupId` int NOT NULL, 
	`MessageId` int NOT NULL);

ALTER TABLE `GroupMessages` ADD PRIMARY KEY (Id);




CREATE TABLE `ModuleQuizs`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`ModuleId` int NOT NULL, 
	`QuizId` int NOT NULL);

ALTER TABLE `ModuleQuizs` ADD PRIMARY KEY (Id);




CREATE TABLE `AnswerQuestionChoices`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`QuestionChoiceId` int NOT NULL, 
	`AnswerId` int NOT NULL);

ALTER TABLE `AnswerQuestionChoices` ADD PRIMARY KEY (Id);




CREATE TABLE `Schedules`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`PublishFrom` datetime( 3 ) , 
	`PublishTo` datetime( 3 ) , 
	`CourseId` int NOT NULL, 
	`UnitId` int NOT NULL, 
	`ScheduledFrom` datetime( 3 ) , 
	`ScheduledTo` datetime( 3 ) );

ALTER TABLE `Schedules` ADD PRIMARY KEY (Id);




CREATE TABLE `TopicPosts`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`IP` longtext, 
	`Title` longtext NOT NULL, 
	`Status` int NOT NULL, 
	`Body` longtext NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`Votes` int, 
	`PostedByUserId` int NOT NULL, 
	`ParentTopicPostId` int, 
	`TopicId` int NOT NULL);

ALTER TABLE `TopicPosts` ADD PRIMARY KEY (Id);




CREATE TABLE `BaseQuestionTopics`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Status` int NOT NULL, 
	`IsTopic` bool NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`PublishFrom` datetime( 3 ) , 
	`PublishTo` datetime( 3 ) , 
	`Description` longtext, 
	`OriginatorId` int NOT NULL);

ALTER TABLE `BaseQuestionTopics` ADD PRIMARY KEY (Id);




CREATE TABLE `Companies`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL, 
	`Url` longtext, 
	`Logo` longtext);

ALTER TABLE `Companies` ADD PRIMARY KEY (Id);




CREATE TABLE `Contacts`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL, 
	`Title` longtext, 
	`Email` longtext, 
	`Phone` longtext, 
	`Mobile` longtext, 
	`Fax` longtext, 
	`Address` longtext, 
	`PostCode` longtext, 
	`CompanyId` int);

ALTER TABLE `Contacts` ADD PRIMARY KEY (Id);




CREATE TABLE `Assets`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL, 
	`AssetType` int NOT NULL, 
	`Path` longtext, 
	`CompanyId` int NOT NULL, 
	`ContentType` longtext, 
	`IdentityToken` CHAR(36) BINARY NOT NULL);

ALTER TABLE `Assets` ADD PRIMARY KEY (Id);




CREATE TABLE `Tags`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` longtext NOT NULL);

ALTER TABLE `Tags` ADD PRIMARY KEY (Id);




CREATE TABLE `Modules`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`Description` longtext, 
	`PublishFrom` datetime( 3 ) , 
	`PublishTo` datetime( 3 ) , 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`Score` longtext, 
	`Approved` bool NOT NULL, 
	`CreatedByStaff_Id` int NOT NULL, 
	`Course_Id` int NOT NULL, 
	`SortOrder` int);

ALTER TABLE `Modules` ADD PRIMARY KEY (Id);




CREATE TABLE `Discussions`(
	`SortOrder` int, 
	`IsPostModerated` bool NOT NULL, 
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Title` longtext NOT NULL, 
	`DateCreated` datetime( 3 )  NOT NULL, 
	`Description` longtext, 
	`CourseId` int, 
	`LatestPostId` int, 
	`ParentDiscussionId` int);

ALTER TABLE `Discussions` ADD PRIMARY KEY (Id);




CREATE TABLE `Assets_WebPage`(
	`Id` int NOT NULL);

ALTER TABLE `Assets_WebPage` ADD PRIMARY KEY (Id);




CREATE TABLE `sysdiagrams`(
	`name` nvarchar (128) NOT NULL, 
	`principal_id` int NOT NULL, 
	`diagram_id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`version` int, 
	`definition` longblob);

ALTER TABLE `sysdiagrams` ADD PRIMARY KEY (diagram_id);




CREATE TABLE `webpages_Membership`(
	`UserId` int NOT NULL, 
	`CreateDate` datetime( 3 ) , 
	`ConfirmationToken` nvarchar (128), 
	`IsConfirmed` bool, 
	`LastPasswordFailureDate` datetime( 3 ) , 
	`PasswordFailuresSinceLastSuccess` int NOT NULL, 
	`Password` nvarchar (128) NOT NULL, 
	`PasswordChangedDate` datetime( 3 ) , 
	`PasswordSalt` nvarchar (128) NOT NULL, 
	`PasswordVerificationToken` nvarchar (128), 
	`PasswordVerificationTokenExpirationDate` datetime( 3 ) );

ALTER TABLE `webpages_Membership` ADD PRIMARY KEY (UserId);




CREATE TABLE `webpages_OAuthMembership`(
	`Provider` nvarchar (30) NOT NULL, 
	`ProviderUserId` nvarchar (100) NOT NULL, 
	`UserId` int NOT NULL);

ALTER TABLE `webpages_OAuthMembership` ADD PRIMARY KEY (Provider, ProviderUserId);




CREATE TABLE `webpages_Roles`(
	`RoleId` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`RoleName` nvarchar (256) NOT NULL);

ALTER TABLE `webpages_Roles` ADD PRIMARY KEY (RoleId);




CREATE TABLE `Users_Student`(
	`StudentNumber` longtext, 
	`Id` int NOT NULL);

ALTER TABLE `Users_Student` ADD PRIMARY KEY (Id);




CREATE TABLE `Users_Staff`(
	`Position_Id` int NOT NULL, 
	`DepartmentId` int, 
	`Id` int NOT NULL);

ALTER TABLE `Users_Staff` ADD PRIMARY KEY (Id);




CREATE TABLE `BaseQuestionTopics_Topic`(
	`IsPinned` bool NOT NULL, 
	`DiscussionId` int NOT NULL, 
	`Id` int NOT NULL);

ALTER TABLE `BaseQuestionTopics_Topic` ADD PRIMARY KEY (Id);




CREATE TABLE `Assets_Video`(
	`AlternatePath` nvarchar (200), 
	`AlternateContentType` longtext, 
	`Id` int NOT NULL);

ALTER TABLE `Assets_Video` ADD PRIMARY KEY (Id);




CREATE TABLE `Assets_Document`(
	`Id` int NOT NULL);

ALTER TABLE `Assets_Document` ADD PRIMARY KEY (Id);




CREATE TABLE `BaseFiles_File`(
	`Content` longblob NOT NULL, 
	`ContentType` longtext NOT NULL, 
	`ContentLength` int NOT NULL, 
	`Id` int NOT NULL);

ALTER TABLE `BaseFiles_File` ADD PRIMARY KEY (Id);




CREATE TABLE `BaseQuestionTopics_UserQuestion`(
	`Id` int NOT NULL);

ALTER TABLE `BaseQuestionTopics_UserQuestion` ADD PRIMARY KEY (Id);




CREATE TABLE `Assets_Image`(
	`Id` int NOT NULL);

ALTER TABLE `Assets_Image` ADD PRIMARY KEY (Id);




CREATE TABLE `UserPermission`(
	`Permissions_Id` int NOT NULL, 
	`Users_Id` int NOT NULL);

ALTER TABLE `UserPermission` ADD PRIMARY KEY (Permissions_Id, Users_Id);




CREATE TABLE `UserRole`(
	`Roles_Id` int NOT NULL, 
	`Users_Id` int NOT NULL);

ALTER TABLE `UserRole` ADD PRIMARY KEY (Roles_Id, Users_Id);




CREATE TABLE `TagAsset`(
	`Tags_Id` int NOT NULL, 
	`Assets_Id` int NOT NULL);

ALTER TABLE `TagAsset` ADD PRIMARY KEY (Tags_Id, Assets_Id);




CREATE TABLE `webpages_UsersInRoles`(
	`webpages_Roles_RoleId` int NOT NULL, 
	`Memberships_Id` int NOT NULL);

ALTER TABLE `webpages_UsersInRoles` ADD PRIMARY KEY (webpages_Roles_RoleId, Memberships_Id);




CREATE TABLE `UnitAsset`(
	`Assets_Id` int NOT NULL, 
	`Units1_Id` int NOT NULL);

ALTER TABLE `UnitAsset` ADD PRIMARY KEY (Assets_Id, Units1_Id);




CREATE TABLE `AssignmentAsset`(
	`Assets_Id` int NOT NULL, 
	`Assignments_Id` int NOT NULL);

ALTER TABLE `AssignmentAsset` ADD PRIMARY KEY (Assets_Id, Assignments_Id);






-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `Accreditation_Id` in table 'Courses'

ALTER TABLE `Courses`
ADD CONSTRAINT `FK_AccreditationCourse`
    FOREIGN KEY (`Accreditation_Id`)
    REFERENCES `Accreditations`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccreditationCourse'

CREATE INDEX `IX_FK_AccreditationCourse` 
    ON `Courses`
    (`Accreditation_Id`);

-- Creating foreign key on `Question_Id` in table 'Answers'

ALTER TABLE `Answers`
ADD CONSTRAINT `FK_QuestionAnswer`
    FOREIGN KEY (`Question_Id`)
    REFERENCES `Questions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionAnswer'

CREATE INDEX `IX_FK_QuestionAnswer` 
    ON `Answers`
    (`Question_Id`);

-- Creating foreign key on `AssignmentId` in table 'Submissions'

ALTER TABLE `Submissions`
ADD CONSTRAINT `FK_AssignmentSubmission`
    FOREIGN KEY (`AssignmentId`)
    REFERENCES `Assignments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AssignmentSubmission'

CREATE INDEX `IX_FK_AssignmentSubmission` 
    ON `Submissions`
    (`AssignmentId`);

-- Creating foreign key on `QuizId` in table 'Assignments'

ALTER TABLE `Assignments`
ADD CONSTRAINT `FK_QuizAssignment`
    FOREIGN KEY (`QuizId`)
    REFERENCES `Quizs`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizAssignment'

CREATE INDEX `IX_FK_QuizAssignment` 
    ON `Assignments`
    (`QuizId`);

-- Creating foreign key on `Course_Id` in table 'CourseModules'

ALTER TABLE `CourseModules`
ADD CONSTRAINT `FK_CourseCourseModules`
    FOREIGN KEY (`Course_Id`)
    REFERENCES `Courses`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseCourseModules'

CREATE INDEX `IX_FK_CourseCourseModules` 
    ON `CourseModules`
    (`Course_Id`);

-- Creating foreign key on `Course_Id` in table 'CourseRegistrations'

ALTER TABLE `CourseRegistrations`
ADD CONSTRAINT `FK_CourseCourseRegistration`
    FOREIGN KEY (`Course_Id`)
    REFERENCES `Courses`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseCourseRegistration'

CREATE INDEX `IX_FK_CourseCourseRegistration` 
    ON `CourseRegistrations`
    (`Course_Id`);

-- Creating foreign key on `Student_Id` in table 'CourseRegistrations'

ALTER TABLE `CourseRegistrations`
ADD CONSTRAINT `FK_StudentCourseRegistration`
    FOREIGN KEY (`Student_Id`)
    REFERENCES `Users_Student`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourseRegistration'

CREATE INDEX `IX_FK_StudentCourseRegistration` 
    ON `CourseRegistrations`
    (`Student_Id`);

-- Creating foreign key on `Course_Id` in table 'StaffCourses'

ALTER TABLE `StaffCourses`
ADD CONSTRAINT `FK_CourseStaffCourses`
    FOREIGN KEY (`Course_Id`)
    REFERENCES `Courses`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseStaffCourses'

CREATE INDEX `IX_FK_CourseStaffCourses` 
    ON `StaffCourses`
    (`Course_Id`);

-- Creating foreign key on `CourseTemplate_Id` in table 'Courses'

ALTER TABLE `Courses`
ADD CONSTRAINT `FK_CourseTemplateCourse`
    FOREIGN KEY (`CourseTemplate_Id`)
    REFERENCES `CourseTemplates`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTemplateCourse'

CREATE INDEX `IX_FK_CourseTemplateCourse` 
    ON `Courses`
    (`CourseTemplate_Id`);

-- Creating foreign key on `UserGender` in table 'Users'

ALTER TABLE `Users`
ADD CONSTRAINT `FK_GenderUser`
    FOREIGN KEY (`UserGender`)
    REFERENCES `Genders`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GenderUser'

CREATE INDEX `IX_FK_GenderUser` 
    ON `Users`
    (`UserGender`);

-- Creating foreign key on `Membership_Id` in table 'Users'

ALTER TABLE `Users`
ADD CONSTRAINT `FK_UserMembership`
    FOREIGN KEY (`Membership_Id`)
    REFERENCES `Memberships`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMembership'

CREATE INDEX `IX_FK_UserMembership` 
    ON `Users`
    (`Membership_Id`);

-- Creating foreign key on `Permissions_Id` in table 'RolePermissions'

ALTER TABLE `RolePermissions`
ADD CONSTRAINT `FK_RolePermissionsPermission`
    FOREIGN KEY (`Permissions_Id`)
    REFERENCES `Permissions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissionsPermission'

CREATE INDEX `IX_FK_RolePermissionsPermission` 
    ON `RolePermissions`
    (`Permissions_Id`);

-- Creating foreign key on `Position_Id` in table 'Users_Staff'

ALTER TABLE `Users_Staff`
ADD CONSTRAINT `FK_PositionStaff`
    FOREIGN KEY (`Position_Id`)
    REFERENCES `Positions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionStaff'

CREATE INDEX `IX_FK_PositionStaff` 
    ON `Users_Staff`
    (`Position_Id`);

-- Creating foreign key on `Question_Id` in table 'QuestionChoices'

ALTER TABLE `QuestionChoices`
ADD CONSTRAINT `FK_QuestionQuestionOptions`
    FOREIGN KEY (`Question_Id`)
    REFERENCES `Questions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionQuestionOptions'

CREATE INDEX `IX_FK_QuestionQuestionOptions` 
    ON `QuestionChoices`
    (`Question_Id`);

-- Creating foreign key on `Quiz_Id` in table 'Questions'

ALTER TABLE `Questions`
ADD CONSTRAINT `FK_QuizQuestion`
    FOREIGN KEY (`Quiz_Id`)
    REFERENCES `Quizs`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizQuestion'

CREATE INDEX `IX_FK_QuizQuestion` 
    ON `Questions`
    (`Quiz_Id`);

-- Creating foreign key on `Quiz_Id` in table 'QuizEntries'

ALTER TABLE `QuizEntries`
ADD CONSTRAINT `FK_QuizQuizEntry`
    FOREIGN KEY (`Quiz_Id`)
    REFERENCES `Quizs`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizQuizEntry'

CREATE INDEX `IX_FK_QuizQuizEntry` 
    ON `QuizEntries`
    (`Quiz_Id`);

-- Creating foreign key on `Student_Id` in table 'QuizEntries'

ALTER TABLE `QuizEntries`
ADD CONSTRAINT `FK_StudentQuizEntry`
    FOREIGN KEY (`Student_Id`)
    REFERENCES `Users_Student`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentQuizEntry'

CREATE INDEX `IX_FK_StudentQuizEntry` 
    ON `QuizEntries`
    (`Student_Id`);

-- Creating foreign key on `RoleId` in table 'RolePermissions'

ALTER TABLE `RolePermissions`
ADD CONSTRAINT `FK_RoleRolePermissions`
    FOREIGN KEY (`RoleId`)
    REFERENCES `Roles`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleRolePermissions'

CREATE INDEX `IX_FK_RoleRolePermissions` 
    ON `RolePermissions`
    (`RoleId`);

-- Creating foreign key on `Staff_Id` in table 'StaffCourses'

ALTER TABLE `StaffCourses`
ADD CONSTRAINT `FK_StaffStaffCourses`
    FOREIGN KEY (`Staff_Id`)
    REFERENCES `Users_Staff`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StaffStaffCourses'

CREATE INDEX `IX_FK_StaffStaffCourses` 
    ON `StaffCourses`
    (`Staff_Id`);

-- Creating foreign key on `StaffId` in table 'Units'

ALTER TABLE `Units`
ADD CONSTRAINT `FK_StaffUnit`
    FOREIGN KEY (`StaffId`)
    REFERENCES `Users_Staff`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StaffUnit'

CREATE INDEX `IX_FK_StaffUnit` 
    ON `Units`
    (`StaffId`);

-- Creating foreign key on `StudentId` in table 'Submissions'

ALTER TABLE `Submissions`
ADD CONSTRAINT `FK_StudentSubmission`
    FOREIGN KEY (`StudentId`)
    REFERENCES `Users_Student`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentSubmission'

CREATE INDEX `IX_FK_StudentSubmission` 
    ON `Submissions`
    (`StudentId`);

-- Creating foreign key on `UserId` in table 'Tasks'

ALTER TABLE `Tasks`
ADD CONSTRAINT `FK_UserTask`
    FOREIGN KEY (`UserId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTask'

CREATE INDEX `IX_FK_UserTask` 
    ON `Tasks`
    (`UserId`);

-- Creating foreign key on `Permissions_Id` in table 'UserPermission'

ALTER TABLE `UserPermission`
ADD CONSTRAINT `FK_UserPermission_Permission`
    FOREIGN KEY (`Permissions_Id`)
    REFERENCES `Permissions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Users_Id` in table 'UserPermission'

ALTER TABLE `UserPermission`
ADD CONSTRAINT `FK_UserPermission_User`
    FOREIGN KEY (`Users_Id`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPermission_User'

CREATE INDEX `IX_FK_UserPermission_User` 
    ON `UserPermission`
    (`Users_Id`);

-- Creating foreign key on `Roles_Id` in table 'UserRole'

ALTER TABLE `UserRole`
ADD CONSTRAINT `FK_UserRole_Role`
    FOREIGN KEY (`Roles_Id`)
    REFERENCES `Roles`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Users_Id` in table 'UserRole'

ALTER TABLE `UserRole`
ADD CONSTRAINT `FK_UserRole_User`
    FOREIGN KEY (`Users_Id`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'

CREATE INDEX `IX_FK_UserRole_User` 
    ON `UserRole`
    (`Users_Id`);

-- Creating foreign key on `FromUserId` in table 'Messages'

ALTER TABLE `Messages`
ADD CONSTRAINT `FK_UserMessage`
    FOREIGN KEY (`FromUserId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessage'

CREATE INDEX `IX_FK_UserMessage` 
    ON `Messages`
    (`FromUserId`);

-- Creating foreign key on `RecipientUserId` in table 'Messages'

ALTER TABLE `Messages`
ADD CONSTRAINT `FK_UserMessage1`
    FOREIGN KEY (`RecipientUserId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessage1'

CREATE INDEX `IX_FK_UserMessage1` 
    ON `Messages`
    (`RecipientUserId`);

-- Creating foreign key on `UserId` in table 'ViewedMessages'

ALTER TABLE `ViewedMessages`
ADD CONSTRAINT `FK_UserStudentViewedAlerts`
    FOREIGN KEY (`UserId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserStudentViewedAlerts'

CREATE INDEX `IX_FK_UserStudentViewedAlerts` 
    ON `ViewedMessages`
    (`UserId`);

-- Creating foreign key on `MessageId` in table 'ViewedMessages'

ALTER TABLE `ViewedMessages`
ADD CONSTRAINT `FK_MessageViewedMessage`
    FOREIGN KEY (`MessageId`)
    REFERENCES `Messages`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageViewedMessage'

CREATE INDEX `IX_FK_MessageViewedMessage` 
    ON `ViewedMessages`
    (`MessageId`);

-- Creating foreign key on `AssignedStaffId` in table 'Groups'

ALTER TABLE `Groups`
ADD CONSTRAINT `FK_StaffGroup`
    FOREIGN KEY (`AssignedStaffId`)
    REFERENCES `Users_Staff`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StaffGroup'

CREATE INDEX `IX_FK_StaffGroup` 
    ON `Groups`
    (`AssignedStaffId`);

-- Creating foreign key on `UserId` in table 'UserGroups'

ALTER TABLE `UserGroups`
ADD CONSTRAINT `FK_UserUserGroup`
    FOREIGN KEY (`UserId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserGroup'

CREATE INDEX `IX_FK_UserUserGroup` 
    ON `UserGroups`
    (`UserId`);

-- Creating foreign key on `GroupId` in table 'UserGroups'

ALTER TABLE `UserGroups`
ADD CONSTRAINT `FK_GroupUserGroup`
    FOREIGN KEY (`GroupId`)
    REFERENCES `Groups`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUserGroup'

CREATE INDEX `IX_FK_GroupUserGroup` 
    ON `UserGroups`
    (`GroupId`);

-- Creating foreign key on `GroupId` in table 'GroupMessages'

ALTER TABLE `GroupMessages`
ADD CONSTRAINT `FK_GroupGroupMessage`
    FOREIGN KEY (`GroupId`)
    REFERENCES `Groups`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroupMessage'

CREATE INDEX `IX_FK_GroupGroupMessage` 
    ON `GroupMessages`
    (`GroupId`);

-- Creating foreign key on `MessageId` in table 'GroupMessages'

ALTER TABLE `GroupMessages`
ADD CONSTRAINT `FK_MessageGroupMessage`
    FOREIGN KEY (`MessageId`)
    REFERENCES `Messages`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageGroupMessage'

CREATE INDEX `IX_FK_MessageGroupMessage` 
    ON `GroupMessages`
    (`MessageId`);

-- Creating foreign key on `CourseId` in table 'Assignments'

ALTER TABLE `Assignments`
ADD CONSTRAINT `FK_CourseAssignment`
    FOREIGN KEY (`CourseId`)
    REFERENCES `Courses`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseAssignment'

CREATE INDEX `IX_FK_CourseAssignment` 
    ON `Assignments`
    (`CourseId`);

-- Creating foreign key on `UnitId` in table 'Assignments'

ALTER TABLE `Assignments`
ADD CONSTRAINT `FK_UnitAssignment`
    FOREIGN KEY (`UnitId`)
    REFERENCES `Units`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitAssignment'

CREATE INDEX `IX_FK_UnitAssignment` 
    ON `Assignments`
    (`UnitId`);

-- Creating foreign key on `SubmissionId` in table 'BaseFiles'

ALTER TABLE `BaseFiles`
ADD CONSTRAINT `FK_SubmissionFileUpload`
    FOREIGN KEY (`SubmissionId`)
    REFERENCES `Submissions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubmissionFileUpload'

CREATE INDEX `IX_FK_SubmissionFileUpload` 
    ON `BaseFiles`
    (`SubmissionId`);

-- Creating foreign key on `AssignmentId` in table 'BaseFiles'

ALTER TABLE `BaseFiles`
ADD CONSTRAINT `FK_AssignmentFileUpload`
    FOREIGN KEY (`AssignmentId`)
    REFERENCES `Assignments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AssignmentFileUpload'

CREATE INDEX `IX_FK_AssignmentFileUpload` 
    ON `BaseFiles`
    (`AssignmentId`);

-- Creating foreign key on `QuizEntryId` in table 'Answers'

ALTER TABLE `Answers`
ADD CONSTRAINT `FK_QuizEntryAnswer`
    FOREIGN KEY (`QuizEntryId`)
    REFERENCES `QuizEntries`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizEntryAnswer'

CREATE INDEX `IX_FK_QuizEntryAnswer` 
    ON `Answers`
    (`QuizEntryId`);

-- Creating foreign key on `QuizId` in table 'ModuleQuizs'

ALTER TABLE `ModuleQuizs`
ADD CONSTRAINT `FK_QuizModuleQuiz`
    FOREIGN KEY (`QuizId`)
    REFERENCES `Quizs`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizModuleQuiz'

CREATE INDEX `IX_FK_QuizModuleQuiz` 
    ON `ModuleQuizs`
    (`QuizId`);

-- Creating foreign key on `QuestionChoiceId` in table 'AnswerQuestionChoices'

ALTER TABLE `AnswerQuestionChoices`
ADD CONSTRAINT `FK_QuestionChoiceAnswerQuestionChoice`
    FOREIGN KEY (`QuestionChoiceId`)
    REFERENCES `QuestionChoices`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionChoiceAnswerQuestionChoice'

CREATE INDEX `IX_FK_QuestionChoiceAnswerQuestionChoice` 
    ON `AnswerQuestionChoices`
    (`QuestionChoiceId`);

-- Creating foreign key on `AnswerId` in table 'AnswerQuestionChoices'

ALTER TABLE `AnswerQuestionChoices`
ADD CONSTRAINT `FK_AnswerAnswerQuestionChoice`
    FOREIGN KEY (`AnswerId`)
    REFERENCES `Answers`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AnswerAnswerQuestionChoice'

CREATE INDEX `IX_FK_AnswerAnswerQuestionChoice` 
    ON `AnswerQuestionChoices`
    (`AnswerId`);

-- Creating foreign key on `CourseId` in table 'Schedules'

ALTER TABLE `Schedules`
ADD CONSTRAINT `FK_CourseSchedule`
    FOREIGN KEY (`CourseId`)
    REFERENCES `Courses`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseSchedule'

CREATE INDEX `IX_FK_CourseSchedule` 
    ON `Schedules`
    (`CourseId`);

-- Creating foreign key on `UnitId` in table 'Schedules'

ALTER TABLE `Schedules`
ADD CONSTRAINT `FK_UnitSchedule`
    FOREIGN KEY (`UnitId`)
    REFERENCES `Units`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitSchedule'

CREATE INDEX `IX_FK_UnitSchedule` 
    ON `Schedules`
    (`UnitId`);

-- Creating foreign key on `PostedByUserId` in table 'TopicPosts'

ALTER TABLE `TopicPosts`
ADD CONSTRAINT `FK_UserTopicPost`
    FOREIGN KEY (`PostedByUserId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTopicPost'

CREATE INDEX `IX_FK_UserTopicPost` 
    ON `TopicPosts`
    (`PostedByUserId`);

-- Creating foreign key on `ParentTopicPostId` in table 'TopicPosts'

ALTER TABLE `TopicPosts`
ADD CONSTRAINT `FK_TopicPostTopicPost`
    FOREIGN KEY (`ParentTopicPostId`)
    REFERENCES `TopicPosts`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicPostTopicPost'

CREATE INDEX `IX_FK_TopicPostTopicPost` 
    ON `TopicPosts`
    (`ParentTopicPostId`);

-- Creating foreign key on `TopicId` in table 'TopicPosts'

ALTER TABLE `TopicPosts`
ADD CONSTRAINT `FK_TopicTopicPost`
    FOREIGN KEY (`TopicId`)
    REFERENCES `BaseQuestionTopics_Topic`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicTopicPost'

CREATE INDEX `IX_FK_TopicTopicPost` 
    ON `TopicPosts`
    (`TopicId`);

-- Creating foreign key on `OriginatorId` in table 'BaseQuestionTopics'

ALTER TABLE `BaseQuestionTopics`
ADD CONSTRAINT `FK_UserBaseQuestionTopic`
    FOREIGN KEY (`OriginatorId`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBaseQuestionTopic'

CREATE INDEX `IX_FK_UserBaseQuestionTopic` 
    ON `BaseQuestionTopics`
    (`OriginatorId`);

-- Creating foreign key on `CompanyId` in table 'Contacts'

ALTER TABLE `Contacts`
ADD CONSTRAINT `FK_CompanyContact`
    FOREIGN KEY (`CompanyId`)
    REFERENCES `Companies`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyContact'

CREATE INDEX `IX_FK_CompanyContact` 
    ON `Contacts`
    (`CompanyId`);

-- Creating foreign key on `DepartmentId` in table 'Courses'

ALTER TABLE `Courses`
ADD CONSTRAINT `FK_DepartmentCourse`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `Departments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentCourse'

CREATE INDEX `IX_FK_DepartmentCourse` 
    ON `Courses`
    (`DepartmentId`);

-- Creating foreign key on `CompanyId` in table 'Users'

ALTER TABLE `Users`
ADD CONSTRAINT `FK_CompanyUser`
    FOREIGN KEY (`CompanyId`)
    REFERENCES `Companies`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyUser'

CREATE INDEX `IX_FK_CompanyUser` 
    ON `Users`
    (`CompanyId`);

-- Creating foreign key on `CompanyId` in table 'Courses'

ALTER TABLE `Courses`
ADD CONSTRAINT `FK_CompanyCourse`
    FOREIGN KEY (`CompanyId`)
    REFERENCES `Companies`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyCourse'

CREATE INDEX `IX_FK_CompanyCourse` 
    ON `Courses`
    (`CompanyId`);

-- Creating foreign key on `DepartmentId` in table 'Users_Staff'

ALTER TABLE `Users_Staff`
ADD CONSTRAINT `FK_DepartmentStaff`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `Departments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentStaff'

CREATE INDEX `IX_FK_DepartmentStaff` 
    ON `Users_Staff`
    (`DepartmentId`);

-- Creating foreign key on `Tags_Id` in table 'TagAsset'

ALTER TABLE `TagAsset`
ADD CONSTRAINT `FK_TagAsset_Tag`
    FOREIGN KEY (`Tags_Id`)
    REFERENCES `Tags`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Assets_Id` in table 'TagAsset'

ALTER TABLE `TagAsset`
ADD CONSTRAINT `FK_TagAsset_Asset`
    FOREIGN KEY (`Assets_Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TagAsset_Asset'

CREATE INDEX `IX_FK_TagAsset_Asset` 
    ON `TagAsset`
    (`Assets_Id`);

-- Creating foreign key on `CompanyId` in table 'Assets'

ALTER TABLE `Assets`
ADD CONSTRAINT `FK_CompanyAsset`
    FOREIGN KEY (`CompanyId`)
    REFERENCES `Companies`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyAsset'

CREATE INDEX `IX_FK_CompanyAsset` 
    ON `Assets`
    (`CompanyId`);

-- Creating foreign key on `VideoId` in table 'Units'

ALTER TABLE `Units`
ADD CONSTRAINT `FK_UnitVideo`
    FOREIGN KEY (`VideoId`)
    REFERENCES `Assets_Video`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitVideo'

CREATE INDEX `IX_FK_UnitVideo` 
    ON `Units`
    (`VideoId`);

-- Creating foreign key on `DocumentId` in table 'Units'

ALTER TABLE `Units`
ADD CONSTRAINT `FK_UnitDocument`
    FOREIGN KEY (`DocumentId`)
    REFERENCES `Assets_Document`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitDocument'

CREATE INDEX `IX_FK_UnitDocument` 
    ON `Units`
    (`DocumentId`);

-- Creating foreign key on `ModuleId` in table 'Assignments'

ALTER TABLE `Assignments`
ADD CONSTRAINT `FK_ModuleAssignment`
    FOREIGN KEY (`ModuleId`)
    REFERENCES `Modules`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleAssignment'

CREATE INDEX `IX_FK_ModuleAssignment` 
    ON `Assignments`
    (`ModuleId`);

-- Creating foreign key on `Module_Id` in table 'CourseModules'

ALTER TABLE `CourseModules`
ADD CONSTRAINT `FK_ModuleCourseModules`
    FOREIGN KEY (`Module_Id`)
    REFERENCES `Modules`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleCourseModules'

CREATE INDEX `IX_FK_ModuleCourseModules` 
    ON `CourseModules`
    (`Module_Id`);

-- Creating foreign key on `ModuleId` in table 'ModuleQuizs'

ALTER TABLE `ModuleQuizs`
ADD CONSTRAINT `FK_ModuleModuleQuiz`
    FOREIGN KEY (`ModuleId`)
    REFERENCES `Modules`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleModuleQuiz'

CREATE INDEX `IX_FK_ModuleModuleQuiz` 
    ON `ModuleQuizs`
    (`ModuleId`);

-- Creating foreign key on `ModuleId` in table 'Units'

ALTER TABLE `Units`
ADD CONSTRAINT `FK_ModuleUnit`
    FOREIGN KEY (`ModuleId`)
    REFERENCES `Modules`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleUnit'

CREATE INDEX `IX_FK_ModuleUnit` 
    ON `Units`
    (`ModuleId`);

-- Creating foreign key on `CreatedByStaff_Id` in table 'Modules'

ALTER TABLE `Modules`
ADD CONSTRAINT `FK_StaffModule`
    FOREIGN KEY (`CreatedByStaff_Id`)
    REFERENCES `Users_Staff`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StaffModule'

CREATE INDEX `IX_FK_StaffModule` 
    ON `Modules`
    (`CreatedByStaff_Id`);

-- Creating foreign key on `DiscussionId` in table 'BaseQuestionTopics_Topic'

ALTER TABLE `BaseQuestionTopics_Topic`
ADD CONSTRAINT `FK_DiscussionTopic`
    FOREIGN KEY (`DiscussionId`)
    REFERENCES `Discussions`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscussionTopic'

CREATE INDEX `IX_FK_DiscussionTopic` 
    ON `BaseQuestionTopics_Topic`
    (`DiscussionId`);

-- Creating foreign key on `CourseId` in table 'Discussions'

ALTER TABLE `Discussions`
ADD CONSTRAINT `FK_CourseDiscussion`
    FOREIGN KEY (`CourseId`)
    REFERENCES `Courses`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseDiscussion'

CREATE INDEX `IX_FK_CourseDiscussion` 
    ON `Discussions`
    (`CourseId`);

-- Creating foreign key on `LatestPostId` in table 'Discussions'

ALTER TABLE `Discussions`
ADD CONSTRAINT `FK_TopicPostDiscussion`
    FOREIGN KEY (`LatestPostId`)
    REFERENCES `TopicPosts`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicPostDiscussion'

CREATE INDEX `IX_FK_TopicPostDiscussion` 
    ON `Discussions`
    (`LatestPostId`);

-- Creating foreign key on `Id` in table 'Assets_WebPage'

ALTER TABLE `Assets_WebPage`
ADD CONSTRAINT `FK_Assets_WebPage_Assets`
    FOREIGN KEY (`Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `webpages_Roles_RoleId` in table 'webpages_UsersInRoles'

ALTER TABLE `webpages_UsersInRoles`
ADD CONSTRAINT `FK_webpages_UsersInRoles_webpages_Roles`
    FOREIGN KEY (`webpages_Roles_RoleId`)
    REFERENCES `webpages_Roles`
        (`RoleId`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Memberships_Id` in table 'webpages_UsersInRoles'

ALTER TABLE `webpages_UsersInRoles`
ADD CONSTRAINT `FK_webpages_UsersInRoles_Membership`
    FOREIGN KEY (`Memberships_Id`)
    REFERENCES `Memberships`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_webpages_UsersInRoles_Membership'

CREATE INDEX `IX_FK_webpages_UsersInRoles_Membership` 
    ON `webpages_UsersInRoles`
    (`Memberships_Id`);

-- Creating foreign key on `Assets_Id` in table 'UnitAsset'

ALTER TABLE `UnitAsset`
ADD CONSTRAINT `FK_UnitAsset_Asset`
    FOREIGN KEY (`Assets_Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Units1_Id` in table 'UnitAsset'

ALTER TABLE `UnitAsset`
ADD CONSTRAINT `FK_UnitAsset_Unit`
    FOREIGN KEY (`Units1_Id`)
    REFERENCES `Units`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitAsset_Unit'

CREATE INDEX `IX_FK_UnitAsset_Unit` 
    ON `UnitAsset`
    (`Units1_Id`);

-- Creating foreign key on `QuizId` in table 'Units'

ALTER TABLE `Units`
ADD CONSTRAINT `FK_QuizUnit`
    FOREIGN KEY (`QuizId`)
    REFERENCES `Quizs`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizUnit'

CREATE INDEX `IX_FK_QuizUnit` 
    ON `Units`
    (`QuizId`);

-- Creating foreign key on `Assets_Id` in table 'AssignmentAsset'

ALTER TABLE `AssignmentAsset`
ADD CONSTRAINT `FK_AssignmentAsset_Asset`
    FOREIGN KEY (`Assets_Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Assignments_Id` in table 'AssignmentAsset'

ALTER TABLE `AssignmentAsset`
ADD CONSTRAINT `FK_AssignmentAsset_Assignment`
    FOREIGN KEY (`Assignments_Id`)
    REFERENCES `Assignments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AssignmentAsset_Assignment'

CREATE INDEX `IX_FK_AssignmentAsset_Assignment` 
    ON `AssignmentAsset`
    (`Assignments_Id`);

-- Creating foreign key on `Id` in table 'Users_Student'

ALTER TABLE `Users_Student`
ADD CONSTRAINT `FK_Student_inherits_User`
    FOREIGN KEY (`Id`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'Users_Staff'

ALTER TABLE `Users_Staff`
ADD CONSTRAINT `FK_Staff_inherits_User`
    FOREIGN KEY (`Id`)
    REFERENCES `Users`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'BaseQuestionTopics_Topic'

ALTER TABLE `BaseQuestionTopics_Topic`
ADD CONSTRAINT `FK_Topic_inherits_BaseQuestionTopic`
    FOREIGN KEY (`Id`)
    REFERENCES `BaseQuestionTopics`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'Assets_Video'

ALTER TABLE `Assets_Video`
ADD CONSTRAINT `FK_Video_inherits_Asset`
    FOREIGN KEY (`Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'Assets_Document'

ALTER TABLE `Assets_Document`
ADD CONSTRAINT `FK_Document_inherits_Asset`
    FOREIGN KEY (`Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'BaseFiles_File'

ALTER TABLE `BaseFiles_File`
ADD CONSTRAINT `FK_File_inherits_BaseFile`
    FOREIGN KEY (`Id`)
    REFERENCES `BaseFiles`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'BaseQuestionTopics_UserQuestion'

ALTER TABLE `BaseQuestionTopics_UserQuestion`
ADD CONSTRAINT `FK_UserQuestion_inherits_BaseQuestionTopic`
    FOREIGN KEY (`Id`)
    REFERENCES `BaseQuestionTopics`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'Assets_Image'

ALTER TABLE `Assets_Image`
ADD CONSTRAINT `FK_Image_inherits_Asset`
    FOREIGN KEY (`Id`)
    REFERENCES `Assets`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
