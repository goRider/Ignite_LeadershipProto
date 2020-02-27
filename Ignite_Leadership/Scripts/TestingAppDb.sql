USE infr_common;

CREATE SCHEMA ibs;
GO

CREATE TABLE ibs.IgniteUserRoleType
  (
  IgniteUserRoleTypeId INT NOT NULL,
  IgniteUserRoleTypeName NVARCHAR(40) NULL,
  CONSTRAINT PK_IgniteUserRoleType PRIMARY KEY CLUSTERED (IgniteUserRoleTypeId)
);

CREATE TABLE ibs.IgniteUserRoleTypeMGTSEmployee
  (
  IgniteUserRoleTypeId INT NOT NULL,
  MGTSEmployeeCode INT NOT NULL,
  CONSTRAINT PK_IgniteUserRoleTypeMGTSEmployee PRIMARY KEY CLUSTERED (IgniteUserRoleTypeId)
);

CREATE TABLE ibs.IgniteApplicationStatus
  (
  IgniteApplicationStatusId INT NOT NULL,
  StatusName NVARCHAR(50) NULL,
  CONSTRAINT PK_IgniteApplicationStatus PRIMARY KEY CLUSTERED (IgniteApplicationStatusId)
);

CREATE TABLE ibs.IgniteUserApplication
  (
  IgniteApplicationId INT NOT NULL IDENTITY,
  ApplicationCreationDate DATETIME2(7) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  ManagerName NVARCHAR(130) NULL,
  BuName NVARCHAR(100) NULL,
  LocationName NVARCHAR(240) NULL,
  EmployementOverOneYear BIT NOT NULL DEFAULT 0,
  BachelorDegreeQualifier BIT NOT NULL DEFAULT 0,
  BachelorDegreePursuing BIT NOT NULL DEFAULT 0,
  PreQualificationQuestionsCompletionDate DATETIME2(3),
  ArePrequalificationQuestionComplete BIT NOT NULL DEFAULT 0,
  ManagerStatusChangeDate DATETIME2(3) NULL,
  AreQualificationQuestionsComplete BIT NOT NULL DEFAULT 0,
  IgniteApplicationStatusId INT NOT NULL DEFAULT 1, -- Fk Key To Application Status
  MGTSEmployeeCode INT NOT NULL, -- Fk to MGTSEmployee
  CONSTRAINT PK_IgniteUserApplication PRIMARY KEY CLUSTERED (IgniteApplicationId)
);

CREATE TABLE ibs.MGTSEmployee(
MgtsemployeeCode INT IDENTITY,
LawsonCompanyCode CHAR(4) NULL,
LawsonEmployeeCode CHAR(9) NULL,
MremployeeCode INT NULL,
  MpicemployeeCode INT NULL,
MtcemployeeCode INT NULL,
  ExchangeLoginId CHAR(10) NULL,
MgtsloginId CHAR(10) NULL,
Smtpaddress VARCHAR(100) NULL,
LastName VARCHAR(30) NOT NULL,
  FirstName VARCHAR(30) NULL
,[PreferredName] VARCHAR(30) null
      ,[FullName] VARCHAR(50) NULL
      ,[Extension] VARCHAR(6) null
      ,[PhoneNo] VARCHAR(25) null
      ,[Title] VARCHAR (45) NULL
      ,[JobCode] VARCHAR(12) NULL
      ,[HRDeptCode]CHAR(10) null
      ,[HRDivisionCode]CHAR(10) null
      ,[OfficeCode]CHAR(50) null
      ,[CompanyCode]INT null
      ,[Status]CHAR(2)
      ,[HireDate]SMALLDATETIME null
      ,[TerminationDate]SMALLDATETIME null
      ,[ActiveFlag]VARCHAR(1) NOT NULL
      ,[Building] VARCHAR(20) NULL
      ,[Floor]VARCHAR(10) null
      ,[Room] VARCHAR(20) null
      ,[Jack] VARCHAR(20) null
      ,[TelcoInstrument] VARCHAR(20) null
      ,[TelcoPort]VARCHAR(20) null
      ,[TelcoPair] VARCHAR(11) null
      ,[ManagerMGTSEmployeeCode] INT null
      ,[ManagerLawsonEmployeeCode] CHAR(9) null
      ,[SSN] char(4) null
      ,[ProcessLevel] char(5) null
      ,[SalaryZone] char(8) null
      ,[PayGrade] char(3) null
      ,[SexCode] char(1) null
      ,[BirthMonthDay] char(4) null
      ,[Password] char(10) null
      ,[HideFromApplications] char(1) NOT null
      ,[LastLawsonUpdateDateTime] SMALLDATETIME null
      ,[ExchangeDisplaySuffix] VARCHAR(50) null
      ,[ExchangeMiddleInitial] BIT NOT null
      ,[ExchangeExcludeFromExportFlag] CHAR(1) NOT null
      ,[MGTSEmployeeFlag1] char(1) null
      ,[MGTSEmployeeFlag2] char(1) null
      ,[AdminComment] VARCHAR(500) null
      ,[AdjHireDate] DATETIME null
      ,[JobEffDate] DATETIME null
      ,[RegionName] VARCHAR(50) null
      ,[SupervisorLevel] INT null
      ,[JobClass] CHAR(3) null
      ,[PreviousLawsonEmployeeCode] CHAR(9) null
      ,[HireSourceCode] VARCHAR(30) null
      ,[SupervisorCompany] CHAR(4) null
      ,[ExemptFlag] CHAR(1) null
      ,[Domain] VARCHAR(255)
      ,[RevisionDateTime] SMALLDATETIME null
      ,[Revisor] CHAR(10) null
      ,[LoginEnabled]  INT null
      ,[IndirectManager] CHAR(10) NULL
      ,[Extn] VARCHAR(25) null
      ,[BusinessTitle] VARCHAR(64) null
      ,[PublicMobilePhoneNum] VARCHAR(25) null
      ,[PublicFaxNum] VARCHAR(25) NULL
      ,CONSTRAINT PK_MgtsemployeeCode PRIMARY KEY CLUSTERED (MgtsemployeeCode)
);

CREATE TABLE ibs.QuestionsToAnswer
  (
  QuestionAnswerId INT NOT NULL IDENTITY,
  FirstPreQualQuestion NVARCHAR(40) NULL DEFAULT 'Employee Title',
  FirstPreQualAnswer NVARCHAR(40) NULL DEFAULT '',
  SecondPreQualQuestion NVARCHAR(40) NULL DEFAULT 'Department',
  SecondPreQualAnswer NVARCHAR(40) NULL DEFAULT '',
  ThirdPreQualQuestion NVARCHAR(40) NULL DEFAULT 'BusinessUnit',
  ThirdPreQualAnswer NVARCHAR(40) NULL DEFAULT '',
  FourthPreQualQuestion NVARCHAR(40) NULL DEFAULT 'Manager Name',
  FourthPreQualAnswer NVARCHAR(40) NULL DEFAULT '',
  FifthPreQualQuestion NVARCHAR(40) NULL DEFAULT '',
  FifthPreQualAnswer BIT NOT NULL DEFAULT 0,
  SixthPreQualQuestion TEXT NULL DEFAULT '',
  SixthPreQualAnswer BIT NOT NULL DEFAULT 0,
  FirstQualQuestion TEXT NULL DEFAULT '',
  FirstQualAnswer TEXT NULL DEFAULT '',
  SecondQualQuestion TEXT NULL DEFAULT '',
  SecondQualAnswer TEXT NULL DEFAULT '',
  ThirdQualQuestion TEXT NULL DEFAULT '',
  ThirdQualAnswer TEXT NULL DEFAULT '',
  FourthQualQuestion TEXT NULL DEFAULT '',
  FourthQualAnswer TEXT NULL DEFAULT '',
  CompletePreQualificationQuestionsDate DATETIME2(3) NULL,
  CompleteQualificationQuestionsDate DATETIME2(3) NULL,
  IgniteApplicationId INT NOT NULL -- Fk to Ignite Application
  CONSTRAINT PK_QuestionsToAnswer PRIMARY KEY CLUSTERED (QuestionAnswerId)
);
  



CREATE INDEX IX_Last_Name
    ON ibs.MGTSEmployee (
    	LastName ASC -- , ..., columnN ( ASC | DESC ] 
    );
    --INCLUDE (col_name2 -- , ..., columnN)
    --WITH PAD_INDEX
    --    , FILLFACTOR = 100
    --    , IGNORE_DUP_KEY
    --    , DROP_EXISTING
    --    , STATISTICS_NORECOMPUTE
    --    , SORT_IN_TEMPDB  -- [ ,...n ]
    -- ON "default"
    GO

CREATE INDEX IX_Lawson_EmployeeCode
    ON ibs.MGTSEmployee (
    	LawsonEmployeeCode ASC -- , ..., columnN ( ASC | DESC ] 
    );
    --INCLUDE (col_name2 -- , ..., columnN)
    --WITH PAD_INDEX
    --    , FILLFACTOR = 100
    --    , IGNORE_DUP_KEY
    --    , DROP_EXISTING
    --    , STATISTICS_NORECOMPUTE
    --    , SORT_IN_TEMPDB  -- [ ,...n ]
    -- ON "default"
    GO

CREATE INDEX IX_Exchange_LoginID
    ON ibs.MGTSEmployee (
    	ExchangeLoginId ASC -- , ..., columnN ( ASC | DESC ] 
    );
    --INCLUDE (col_name2 -- , ..., columnN)
    --WITH PAD_INDEX
    --    , FILLFACTOR = 100
    --    , IGNORE_DUP_KEY
    --    , DROP_EXISTING
    --    , STATISTICS_NORECOMPUTE
    --    , SORT_IN_TEMPDB  -- [ ,...n ]
    -- ON "default"
    GO

CREATE INDEX IX_IgniteUserRoleTypeMGTSEmployee_IgniteUserRoleTypeId
ON infr_common.ibs.IgniteUserRoleTypeMGTSEmployee (IgniteUserRoleTypeId)
ON [PRIMARY]
GO

ALTER TABLE infr_common.ibs.IgniteUserRoleTypeMGTSEmployee
ADD CONSTRAINT FK_IgniteUserRoleTypeMGTSEmployee_IgniteUserRoleType_IgniteUserRoleTypeId FOREIGN KEY (IgniteUserRoleTypeId) REFERENCES ibs.IgniteUserRoleType (IgniteUserRoleTypeId) ON DELETE CASCADE
GO

ALTER TABLE infr_common.ibs.IgniteUserRoleTypeMGTSEmployee
ADD CONSTRAINT FK_IgniteUserRoleTypeMGTSEmployee_MGTSEmployee_MgtsemployeeCode FOREIGN KEY (IgniteUserRoleTypeId) REFERENCES ibs.MGTSEmployee (MgtsemployeeCode) ON DELETE CASCADE
GO

CREATE UNIQUE INDEX IX_QuestionsToAnswer_IgniteApplicationId
ON infr_common.ibs.QuestionsToAnswer (IgniteApplicationId)
ON [PRIMARY]
GO

ALTER TABLE infr_common.ibs.QuestionsToAnswer
ADD CONSTRAINT FK_QuestionsToAnswer_IgniteUserApplication_IgniteApplicationId FOREIGN KEY (IgniteApplicationId) REFERENCES ibs.IgniteUserApplication (IgniteApplicationId) ON DELETE CASCADE
GO

CREATE INDEX IX_IgniteUserApplication_MGTSEmployeeCode
ON infr_common.ibs.IgniteUserApplication (MGTSEmployeeCode)
ON [PRIMARY]
GO

ALTER TABLE infr_common.ibs.IgniteUserApplication
ADD CONSTRAINT FK_IgniteUserApplication_MGTSEmployee_MGTSEmployeeCode FOREIGN KEY (MGTSEmployeeCode) REFERENCES ibs.MGTSEmployee (MGTSEmployeeCode)
GO

CREATE INDEX IX_IgniteUserApplication_IgniteApplicationStatus
ON infr_common.ibs.IgniteUserApplication (IgniteApplicationStatusId)
ON [PRIMARY]
GO

ALTER TABLE infr_common.ibs.IgniteUserApplication
ADD CONSTRAINT FK_IgniteUserApplication_IgniteApplicationStatus_IgniteApplicationStatusId FOREIGN KEY (IgniteApplicationStatusId) REFERENCES ibs.IgniteApplicationStatus (IgniteApplicationStatusId) ON DELETE CASCADE
GO

ALTER TABLE infr_common.ibs.IgniteUserApplication
ADD CONSTRAINT DF_IgniteApplicationStatus DEFAULT 1 FOR IgniteApplicationStatusId;
GO
--INSERT INTO ibs.IgniteApplicationStatus
--(
--  IgniteApplicationStatusId
-- ,StatusName
--)
--VALUES
--(
--  1 -- IgniteApplicationStatusId - int NOT NULL
-- ,N'Not Started' -- StatusName - nvarchar(50)
--), (2, 'Incomplete Prequalification'), (3, 'CompletePreQualification'), (4, 'Not Qualified'), (5, 'Start Qualification'), (6, 'Endorse'), (7, 'Hold'), (8, 'Selected'), (9, 'Request Manager');
--GO