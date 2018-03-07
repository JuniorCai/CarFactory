-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        10.2.13-MariaDB - mariadb.org binary distribution
-- 服务器操作系统:                      Win64
-- HeidiSQL 版本:                  9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 导出  表 CarFactory.abpauditlogs 结构
CREATE TABLE IF NOT EXISTS `abpauditlogs` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) DEFAULT NULL,
  `ServiceName` varchar(256) DEFAULT NULL,
  `MethodName` varchar(256) DEFAULT NULL,
  `Parameters` varchar(1024) DEFAULT NULL,
  `ExecutionTime` datetime NOT NULL,
  `ExecutionDuration` int(11) NOT NULL,
  `ClientIpAddress` varchar(64) DEFAULT NULL,
  `ClientName` varchar(128) DEFAULT NULL,
  `BrowserInfo` varchar(256) DEFAULT NULL,
  `Exception` varchar(2000) DEFAULT NULL,
  `ImpersonatorUserId` bigint(20) DEFAULT NULL,
  `ImpersonatorTenantId` int(11) DEFAULT NULL,
  `CustomData` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpauditlogs 的数据：~3 rows (大约)
DELETE FROM `abpauditlogs`;
/*!40000 ALTER TABLE `abpauditlogs` DISABLE KEYS */;
INSERT INTO `abpauditlogs` (`Id`, `TenantId`, `UserId`, `ServiceName`, `MethodName`, `Parameters`, `ExecutionTime`, `ExecutionDuration`, `ClientIpAddress`, `ClientName`, `BrowserInfo`, `Exception`, `ImpersonatorUserId`, `ImpersonatorTenantId`, `CustomData`) VALUES
	(1, 1, NULL, 'CarFactory.Web.Controllers.HomeController', 'Index', '{}', '2018-03-07 20:08:44', 112, '192.168.7.104', 'DESKTOP-P0AHENK', 'Chrome / 64.0 / WinNT', NULL, NULL, 1, NULL),
	(2, 1, NULL, 'CarFactory.Web.Controllers.AboutController', 'Index', '{}', '2018-03-07 20:09:09', 2, '192.168.7.104', 'DESKTOP-P0AHENK', 'Chrome / 64.0 / WinNT', NULL, NULL, 1, NULL),
	(3, 1, NULL, 'CarFactory.Application.Category.CategoryAppService', 'GetCategorysOnShowAsync', '{}', '2018-03-07 20:09:13', 202, '192.168.7.104', 'DESKTOP-P0AHENK', 'Chrome / 64.0 / WinNT', NULL, NULL, 1, NULL);
/*!40000 ALTER TABLE `abpauditlogs` ENABLE KEYS */;

-- 导出  表 CarFactory.abpbackgroundjobs 结构
CREATE TABLE IF NOT EXISTS `abpbackgroundjobs` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `JobType` varchar(512) NOT NULL,
  `JobArgs` longtext NOT NULL,
  `TryCount` smallint(6) NOT NULL,
  `NextTryTime` datetime NOT NULL,
  `LastTryTime` datetime DEFAULT NULL,
  `IsAbandoned` tinyint(1) NOT NULL,
  `Priority` tinyint(3) unsigned NOT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_IsAbandoned_NextTryTime` (`IsAbandoned`,`NextTryTime`) USING HASH
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpbackgroundjobs 的数据：~0 rows (大约)
DELETE FROM `abpbackgroundjobs`;
/*!40000 ALTER TABLE `abpbackgroundjobs` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpbackgroundjobs` ENABLE KEYS */;

-- 导出  表 CarFactory.abpeditions 结构
CREATE TABLE IF NOT EXISTS `abpeditions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) NOT NULL,
  `DisplayName` varchar(64) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpeditions 的数据：~1 rows (大约)
DELETE FROM `abpeditions`;
/*!40000 ALTER TABLE `abpeditions` DISABLE KEYS */;
INSERT INTO `abpeditions` (`Id`, `Name`, `DisplayName`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, 'Standard', 'Standard', 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL);
/*!40000 ALTER TABLE `abpeditions` ENABLE KEYS */;

-- 导出  表 CarFactory.abpfeatures 结构
CREATE TABLE IF NOT EXISTS `abpfeatures` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` varchar(2000) NOT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  `EditionId` int(11) DEFAULT NULL,
  `Discriminator` varchar(128) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_EditionId` (`EditionId`) USING HASH,
  CONSTRAINT `FK_AbpFeatures_AbpEditions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `abpeditions` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpfeatures 的数据：~0 rows (大约)
DELETE FROM `abpfeatures`;
/*!40000 ALTER TABLE `abpfeatures` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpfeatures` ENABLE KEYS */;

-- 导出  表 CarFactory.abplanguages 结构
CREATE TABLE IF NOT EXISTS `abplanguages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `Name` varchar(10) NOT NULL,
  `DisplayName` varchar(64) NOT NULL,
  `Icon` varchar(128) DEFAULT NULL,
  `IsDisabled` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abplanguages 的数据：~10 rows (大约)
DELETE FROM `abplanguages`;
/*!40000 ALTER TABLE `abplanguages` DISABLE KEYS */;
INSERT INTO `abplanguages` (`Id`, `TenantId`, `Name`, `DisplayName`, `Icon`, `IsDisabled`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, NULL, 'en', 'English', 'famfamfam-flag-gb', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(2, NULL, 'tr', 'Türkçe', 'famfamfam-flag-tr', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(3, NULL, 'zh-CN', '简体中文', 'famfamfam-flag-cn', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(4, NULL, 'pt-BR', 'Português-BR', 'famfamfam-flag-br', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(5, NULL, 'es', 'Español', 'famfamfam-flag-es', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(6, NULL, 'fr', 'Français', 'famfamfam-flag-fr', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(7, NULL, 'it', 'Italiano', 'famfamfam-flag-it', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(8, NULL, 'ja', '日本語', 'famfamfam-flag-jp', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(9, NULL, 'nl-NL', 'Nederlands', 'famfamfam-flag-nl', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(10, NULL, 'lt', 'Lietuvos', 'famfamfam-flag-lt', 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL);
/*!40000 ALTER TABLE `abplanguages` ENABLE KEYS */;

-- 导出  表 CarFactory.abplanguagetexts 结构
CREATE TABLE IF NOT EXISTS `abplanguagetexts` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `LanguageName` varchar(10) NOT NULL,
  `Source` varchar(128) NOT NULL,
  `Key` varchar(256) NOT NULL,
  `Value` longtext NOT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abplanguagetexts 的数据：~0 rows (大约)
DELETE FROM `abplanguagetexts`;
/*!40000 ALTER TABLE `abplanguagetexts` DISABLE KEYS */;
/*!40000 ALTER TABLE `abplanguagetexts` ENABLE KEYS */;

-- 导出  表 CarFactory.abpnotifications 结构
CREATE TABLE IF NOT EXISTS `abpnotifications` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `NotificationName` varchar(96) NOT NULL,
  `Data` longtext DEFAULT NULL,
  `DataTypeName` varchar(512) DEFAULT NULL,
  `EntityTypeName` varchar(250) DEFAULT NULL,
  `EntityTypeAssemblyQualifiedName` varchar(512) DEFAULT NULL,
  `EntityId` varchar(96) DEFAULT NULL,
  `Severity` tinyint(3) unsigned NOT NULL,
  `UserIds` longtext DEFAULT NULL,
  `ExcludedUserIds` longtext DEFAULT NULL,
  `TenantIds` longtext DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpnotifications 的数据：~0 rows (大约)
DELETE FROM `abpnotifications`;
/*!40000 ALTER TABLE `abpnotifications` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpnotifications` ENABLE KEYS */;

-- 导出  表 CarFactory.abpnotificationsubscriptions 结构
CREATE TABLE IF NOT EXISTS `abpnotificationsubscriptions` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `NotificationName` varchar(96) DEFAULT NULL,
  `EntityTypeName` varchar(250) DEFAULT NULL,
  `EntityTypeAssemblyQualifiedName` varchar(512) DEFAULT NULL,
  `EntityId` varchar(96) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_NotificationName_EntityTypeName_EntityId_UserId` (`NotificationName`,`EntityTypeName`,`EntityId`,`UserId`) USING HASH
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpnotificationsubscriptions 的数据：~0 rows (大约)
DELETE FROM `abpnotificationsubscriptions`;
/*!40000 ALTER TABLE `abpnotificationsubscriptions` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpnotificationsubscriptions` ENABLE KEYS */;

-- 导出  表 CarFactory.abporganizationunits 结构
CREATE TABLE IF NOT EXISTS `abporganizationunits` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `ParentId` bigint(20) DEFAULT NULL,
  `Code` varchar(95) NOT NULL,
  `DisplayName` varchar(128) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ParentId` (`ParentId`) USING HASH,
  CONSTRAINT `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `abporganizationunits` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abporganizationunits 的数据：~0 rows (大约)
DELETE FROM `abporganizationunits`;
/*!40000 ALTER TABLE `abporganizationunits` DISABLE KEYS */;
/*!40000 ALTER TABLE `abporganizationunits` ENABLE KEYS */;

-- 导出  表 CarFactory.abppermissions 结构
CREATE TABLE IF NOT EXISTS `abppermissions` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `Name` varchar(128) NOT NULL,
  `IsGranted` tinyint(1) NOT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  `UserId` bigint(20) DEFAULT NULL,
  `Discriminator` varchar(128) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RoleId` (`RoleId`) USING HASH,
  KEY `IX_UserId` (`UserId`) USING HASH,
  CONSTRAINT `FK_AbpPermissions_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_AbpPermissions_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abppermissions 的数据：~5 rows (大约)
DELETE FROM `abppermissions`;
/*!40000 ALTER TABLE `abppermissions` DISABLE KEYS */;
INSERT INTO `abppermissions` (`Id`, `TenantId`, `Name`, `IsGranted`, `CreationTime`, `CreatorUserId`, `RoleId`, `UserId`, `Discriminator`) VALUES
	(1, NULL, 'Pages.Users', 1, '2018-03-07 19:09:31', NULL, 1, NULL, 'RolePermissionSetting'),
	(2, NULL, 'Pages.Roles', 1, '2018-03-07 19:09:31', NULL, 1, NULL, 'RolePermissionSetting'),
	(3, NULL, 'Pages.Tenants', 1, '2018-03-07 19:09:31', NULL, 1, NULL, 'RolePermissionSetting'),
	(4, 1, 'Pages.Users', 1, '2018-03-07 19:09:32', NULL, 2, NULL, 'RolePermissionSetting'),
	(5, 1, 'Pages.Roles', 1, '2018-03-07 19:09:32', NULL, 2, NULL, 'RolePermissionSetting');
/*!40000 ALTER TABLE `abppermissions` ENABLE KEYS */;

-- 导出  表 CarFactory.abproles 结构
CREATE TABLE IF NOT EXISTS `abproles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(5000) DEFAULT NULL,
  `TenantId` int(11) DEFAULT NULL,
  `Name` varchar(32) NOT NULL,
  `DisplayName` varchar(64) NOT NULL,
  `IsStatic` tinyint(1) NOT NULL,
  `IsDefault` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_DeleterUserId` (`DeleterUserId`) USING HASH,
  KEY `IX_LastModifierUserId` (`LastModifierUserId`) USING HASH,
  KEY `IX_CreatorUserId` (`CreatorUserId`) USING HASH,
  CONSTRAINT `FK_AbpRoles_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `abpusers` (`Id`),
  CONSTRAINT `FK_AbpRoles_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `abpusers` (`Id`),
  CONSTRAINT `FK_AbpRoles_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `abpusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abproles 的数据：~2 rows (大约)
DELETE FROM `abproles`;
/*!40000 ALTER TABLE `abproles` DISABLE KEYS */;
INSERT INTO `abproles` (`Id`, `Description`, `TenantId`, `Name`, `DisplayName`, `IsStatic`, `IsDefault`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, NULL, NULL, 'Admin', 'Admin', 1, 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(2, NULL, 1, 'Admin', 'Admin', 1, 0, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:32', NULL);
/*!40000 ALTER TABLE `abproles` ENABLE KEYS */;

-- 导出  表 CarFactory.abpsettings 结构
CREATE TABLE IF NOT EXISTS `abpsettings` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) DEFAULT NULL,
  `Name` varchar(256) NOT NULL,
  `Value` varchar(2000) DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId` (`UserId`) USING HASH,
  CONSTRAINT `FK_AbpSettings_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpsettings 的数据：~3 rows (大约)
DELETE FROM `abpsettings`;
/*!40000 ALTER TABLE `abpsettings` DISABLE KEYS */;
INSERT INTO `abpsettings` (`Id`, `TenantId`, `UserId`, `Name`, `Value`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, NULL, NULL, 'Abp.Net.Mail.DefaultFromAddress', 'admin@mydomain.com', NULL, NULL, '2018-03-07 19:09:32', NULL),
	(2, NULL, NULL, 'Abp.Net.Mail.DefaultFromDisplayName', 'mydomain.com mailer', NULL, NULL, '2018-03-07 19:09:32', NULL),
	(3, NULL, NULL, 'Abp.Localization.DefaultLanguageName', 'en', NULL, NULL, '2018-03-07 19:09:32', NULL);
/*!40000 ALTER TABLE `abpsettings` ENABLE KEYS */;

-- 导出  表 CarFactory.abptenantnotifications 结构
CREATE TABLE IF NOT EXISTS `abptenantnotifications` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `TenantId` int(11) DEFAULT NULL,
  `NotificationName` varchar(96) NOT NULL,
  `Data` longtext DEFAULT NULL,
  `DataTypeName` varchar(512) DEFAULT NULL,
  `EntityTypeName` varchar(250) DEFAULT NULL,
  `EntityTypeAssemblyQualifiedName` varchar(512) DEFAULT NULL,
  `EntityId` varchar(96) DEFAULT NULL,
  `Severity` tinyint(3) unsigned NOT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abptenantnotifications 的数据：~0 rows (大约)
DELETE FROM `abptenantnotifications`;
/*!40000 ALTER TABLE `abptenantnotifications` DISABLE KEYS */;
/*!40000 ALTER TABLE `abptenantnotifications` ENABLE KEYS */;

-- 导出  表 CarFactory.abptenants 结构
CREATE TABLE IF NOT EXISTS `abptenants` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EditionId` int(11) DEFAULT NULL,
  `TenancyName` varchar(64) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `ConnectionString` varchar(1024) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_EditionId` (`EditionId`) USING HASH,
  KEY `IX_DeleterUserId` (`DeleterUserId`) USING HASH,
  KEY `IX_LastModifierUserId` (`LastModifierUserId`) USING HASH,
  KEY `IX_CreatorUserId` (`CreatorUserId`) USING HASH,
  CONSTRAINT `FK_AbpTenants_AbpEditions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `abpeditions` (`Id`),
  CONSTRAINT `FK_AbpTenants_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `abpusers` (`Id`),
  CONSTRAINT `FK_AbpTenants_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `abpusers` (`Id`),
  CONSTRAINT `FK_AbpTenants_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `abpusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abptenants 的数据：~1 rows (大约)
DELETE FROM `abptenants`;
/*!40000 ALTER TABLE `abptenants` DISABLE KEYS */;
INSERT INTO `abptenants` (`Id`, `EditionId`, `TenancyName`, `Name`, `ConnectionString`, `IsActive`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, NULL, 'Default', 'Default', NULL, 1, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:32', NULL);
/*!40000 ALTER TABLE `abptenants` ENABLE KEYS */;

-- 导出  表 CarFactory.abpuseraccounts 结构
CREATE TABLE IF NOT EXISTS `abpuseraccounts` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `UserLinkId` bigint(20) DEFAULT NULL,
  `UserName` longtext DEFAULT NULL,
  `EmailAddress` longtext DEFAULT NULL,
  `LastLoginTime` datetime DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpuseraccounts 的数据：~0 rows (大约)
DELETE FROM `abpuseraccounts`;
/*!40000 ALTER TABLE `abpuseraccounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpuseraccounts` ENABLE KEYS */;

-- 导出  表 CarFactory.abpuserclaims 结构
CREATE TABLE IF NOT EXISTS `abpuserclaims` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId` (`UserId`) USING HASH,
  CONSTRAINT `FK_AbpUserClaims_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpuserclaims 的数据：~0 rows (大约)
DELETE FROM `abpuserclaims`;
/*!40000 ALTER TABLE `abpuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpuserclaims` ENABLE KEYS */;

-- 导出  表 CarFactory.abpuserloginattempts 结构
CREATE TABLE IF NOT EXISTS `abpuserloginattempts` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `TenancyName` varchar(64) DEFAULT NULL,
  `UserId` bigint(20) DEFAULT NULL,
  `UserNameOrEmailAddress` varchar(255) DEFAULT NULL,
  `ClientIpAddress` varchar(64) DEFAULT NULL,
  `ClientName` varchar(128) DEFAULT NULL,
  `BrowserInfo` varchar(256) DEFAULT NULL,
  `Result` tinyint(3) unsigned NOT NULL,
  `CreationTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId_TenantId` (`UserId`,`TenantId`) USING HASH,
  KEY `IX_TenancyName_UserNameOrEmailAddress_Result` (`TenancyName`,`UserNameOrEmailAddress`,`Result`) USING HASH
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpuserloginattempts 的数据：~0 rows (大约)
DELETE FROM `abpuserloginattempts`;
/*!40000 ALTER TABLE `abpuserloginattempts` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpuserloginattempts` ENABLE KEYS */;

-- 导出  表 CarFactory.abpuserlogins 结构
CREATE TABLE IF NOT EXISTS `abpuserlogins` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId` (`UserId`) USING HASH,
  CONSTRAINT `FK_AbpUserLogins_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpuserlogins 的数据：~0 rows (大约)
DELETE FROM `abpuserlogins`;
/*!40000 ALTER TABLE `abpuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpuserlogins` ENABLE KEYS */;

-- 导出  表 CarFactory.abpusernotifications 结构
CREATE TABLE IF NOT EXISTS `abpusernotifications` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `TenantNotificationId` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `State` int(11) NOT NULL,
  `CreationTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId_State_CreationTime` (`UserId`,`State`,`CreationTime`) USING HASH
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpusernotifications 的数据：~0 rows (大约)
DELETE FROM `abpusernotifications`;
/*!40000 ALTER TABLE `abpusernotifications` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpusernotifications` ENABLE KEYS */;

-- 导出  表 CarFactory.abpuserorganizationunits 结构
CREATE TABLE IF NOT EXISTS `abpuserorganizationunits` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `OrganizationUnitId` bigint(20) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpuserorganizationunits 的数据：~0 rows (大约)
DELETE FROM `abpuserorganizationunits`;
/*!40000 ALTER TABLE `abpuserorganizationunits` DISABLE KEYS */;
/*!40000 ALTER TABLE `abpuserorganizationunits` ENABLE KEYS */;

-- 导出  表 CarFactory.abpuserroles 结构
CREATE TABLE IF NOT EXISTS `abpuserroles` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `TenantId` int(11) DEFAULT NULL,
  `UserId` bigint(20) NOT NULL,
  `RoleId` int(11) NOT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId` (`UserId`) USING HASH,
  CONSTRAINT `FK_AbpUserRoles_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpuserroles 的数据：~2 rows (大约)
DELETE FROM `abpuserroles`;
/*!40000 ALTER TABLE `abpuserroles` DISABLE KEYS */;
INSERT INTO `abpuserroles` (`Id`, `TenantId`, `UserId`, `RoleId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, NULL, 1, 1, '2018-03-07 19:09:32', NULL),
	(2, 1, 2, 2, '2018-03-07 19:09:32', NULL);
/*!40000 ALTER TABLE `abpuserroles` ENABLE KEYS */;

-- 导出  表 CarFactory.abpusers 结构
CREATE TABLE IF NOT EXISTS `abpusers` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `AuthenticationSource` varchar(64) DEFAULT NULL,
  `UserName` varchar(32) NOT NULL,
  `TenantId` int(11) DEFAULT NULL,
  `EmailAddress` varchar(256) NOT NULL,
  `Name` varchar(32) NOT NULL,
  `Surname` varchar(32) NOT NULL,
  `Password` varchar(128) NOT NULL,
  `EmailConfirmationCode` varchar(328) DEFAULT NULL,
  `PasswordResetCode` varchar(328) DEFAULT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `IsLockoutEnabled` tinyint(1) NOT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `IsPhoneNumberConfirmed` tinyint(1) NOT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `IsTwoFactorEnabled` tinyint(1) NOT NULL,
  `IsEmailConfirmed` tinyint(1) NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `LastLoginTime` datetime DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_DeleterUserId` (`DeleterUserId`) USING HASH,
  KEY `IX_LastModifierUserId` (`LastModifierUserId`) USING HASH,
  KEY `IX_CreatorUserId` (`CreatorUserId`) USING HASH,
  CONSTRAINT `FK_AbpUsers_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `abpusers` (`Id`),
  CONSTRAINT `FK_AbpUsers_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `abpusers` (`Id`),
  CONSTRAINT `FK_AbpUsers_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `abpusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.abpusers 的数据：~2 rows (大约)
DELETE FROM `abpusers`;
/*!40000 ALTER TABLE `abpusers` DISABLE KEYS */;
INSERT INTO `abpusers` (`Id`, `AuthenticationSource`, `UserName`, `TenantId`, `EmailAddress`, `Name`, `Surname`, `Password`, `EmailConfirmationCode`, `PasswordResetCode`, `LockoutEndDateUtc`, `AccessFailedCount`, `IsLockoutEnabled`, `PhoneNumber`, `IsPhoneNumberConfirmed`, `SecurityStamp`, `IsTwoFactorEnabled`, `IsEmailConfirmed`, `IsActive`, `LastLoginTime`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, NULL, 'admin', NULL, 'admin@aspnetboilerplate.com', 'System', 'Administrator', 'AEtjKoXLzN/LPoZcJSXEDpyMV6oWFCCT0yDW5uPgDLIO+sU5ToEXdB4ny/V0sMFIPg==', NULL, NULL, NULL, 0, 1, NULL, 0, '4568c2e9-b32e-1106-2be0-39e51253bda3', 0, 1, 1, NULL, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:31', NULL),
	(2, NULL, 'admin', 1, 'admin@defaulttenant.com', 'admin', 'admin', 'AFJxiQy9HH7T7KFTzMCtjaLDahnK3Yt+qt25Ue6NP0OgsfcrT722B8gjDLkrqTNvIQ==', NULL, NULL, NULL, 0, 1, NULL, 0, '050408bd-0c87-f920-e3f6-39e51253be8c', 0, 1, 1, NULL, 0, NULL, NULL, NULL, NULL, '2018-03-07 19:09:32', NULL);
/*!40000 ALTER TABLE `abpusers` ENABLE KEYS */;

-- 导出  表 CarFactory.category 结构
CREATE TABLE IF NOT EXISTS `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(4000) NOT NULL,
  `ShortName` varchar(4000) NOT NULL,
  `IsShow` tinyint(1) NOT NULL,
  `Sort` int(11) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.category 的数据：~8 rows (大约)
DELETE FROM `category`;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` (`Id`, `CategoryName`, `ShortName`, `IsShow`, `Sort`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, ' 地坪施工方案 ', 'dpsgfa', 1, 1, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(2, '防水方案', 'fsfa', 1, 2, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(3, '防水产品', 'fscp', 1, 3, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(4, '硅烷纳米抗渗产品', 'gwnmkscp', 1, 4, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(5, '防腐方案', 'fffa', 1, 5, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(6, '防火方案', 'fhfa', 1, 6, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(7, '石材木材保护剂', 'scmcbhj', 1, 7, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1),
	(10, '测试类别', 'cslb', 0, 0, 0, NULL, NULL, NULL, NULL, '2016-10-22 00:00:00', 1);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;

-- 导出  表 CarFactory.company 结构
CREATE TABLE IF NOT EXISTS `company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(2000) NOT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Tel` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Address` varchar(2000) DEFAULT NULL,
  `Longitude` varchar(50) DEFAULT NULL,
  `Latitude` varchar(50) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.company 的数据：~1 rows (大约)
DELETE FROM `company`;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` (`Id`, `CompanyName`, `Phone`, `Tel`, `Email`, `Address`, `Longitude`, `Latitude`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, '宁波澳昌科技有限公司', '13812345678', '0574-87623223', 'nbac@qq.com', '宁波市庄桥石材城', '121.543111', '29.945163', 0, NULL, NULL, NULL, NULL, '2018-03-07 20:03:10', 1);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;

-- 导出  表 CarFactory.product 结构
CREATE TABLE IF NOT EXISTS `product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(4000) NOT NULL,
  `Img` varchar(4000) NOT NULL,
  `Detail` longtext NOT NULL,
  `Url` varchar(4000) DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  `IsShow` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime DEFAULT NULL,
  `LastModificationTime` datetime DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `CreationTime` datetime NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CategoryId` (`CategoryId`) USING HASH,
  CONSTRAINT `FK_Product_Category_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.product 的数据：~0 rows (大约)
DELETE FROM `product`;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` (`Id`, `Title`, `Img`, `Detail`, `Url`, `CategoryId`, `IsShow`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(1, '欣和食品TGA天冬聚脲防紫外线面涂方案111', '/storage/images/uploads/201704/909695dca1124853c24ad0068126c507.jpg', '<p><span style="background-color: rgb(255, 255, 0);"><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong>\r\n</span><br class="Apple-interchange-newline"></p><p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><br></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table width="95%" cellspacing="0" cellpadding="5" align="center" border="1">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><br></div>', '', 1, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(2, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-15112Q645050-L.jpg', '  <p><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong></p>\r\n<p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优良的耐化学品性能。</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093347_1.jpg" alt="" border="0" height="408" width="550"></div>\r\n<div style="text-align: center;">&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093400_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093354_1.jpg" alt="" border="0" height="361" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093405_1.jpg" alt="" border="0" height="733" width="550"></div>\r\n<p>【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215094041_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table cellspacing="0" cellpadding="5" border="1" align="center" width="95%">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151217/1_151215094513_1.jpg" alt="" border="0" height="733" width="550"></div>', '', 2, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(3, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-15112QA0250-L.jpg', '  <p><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong></p>\r\n<p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优良的耐化学品性能。</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093347_1.jpg" alt="" border="0" height="408" width="550"></div>\r\n<div style="text-align: center;">&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093400_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093354_1.jpg" alt="" border="0" height="361" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093405_1.jpg" alt="" border="0" height="733" width="550"></div>\r\n<p>【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215094041_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table cellspacing="0" cellpadding="5" border="1" align="center" width="95%">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151217/1_151215094513_1.jpg" alt="" border="0" height="733" width="550"></div>', '', 1, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(4, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-1512150T4230-L.jpg', '  <p><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong></p>\r\n<p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优良的耐化学品性能。</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093347_1.jpg" alt="" border="0" height="408" width="550"></div>\r\n<div style="text-align: center;">&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093400_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093354_1.jpg" alt="" border="0" height="361" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093405_1.jpg" alt="" border="0" height="733" width="550"></div>\r\n<p>【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215094041_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table cellspacing="0" cellpadding="5" border="1" align="center" width="95%">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151217/1_151215094513_1.jpg" alt="" border="0" height="733" width="550"></div>', '', 2, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(5, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-151221142K70-L.jpg', '  <p><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong></p>\r\n<p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优良的耐化学品性能。</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093347_1.jpg" alt="" border="0" height="408" width="550"></div>\r\n<div style="text-align: center;">&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093400_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093354_1.jpg" alt="" border="0" height="361" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093405_1.jpg" alt="" border="0" height="733" width="550"></div>\r\n<p>【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215094041_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table cellspacing="0" cellpadding="5" border="1" align="center" width="95%">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151217/1_151215094513_1.jpg" alt="" border="0" height="733" width="550"></div>', '', 2, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(6, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-160120104T0629.jpg', '  <p><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong></p>\r\n<p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优良的耐化学品性能。</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093347_1.jpg" alt="" border="0" height="408" width="550"></div>\r\n<div style="text-align: center;">&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093400_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093354_1.jpg" alt="" border="0" height="361" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093405_1.jpg" alt="" border="0" height="733" width="550"></div>\r\n<p>【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215094041_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table cellspacing="0" cellpadding="5" border="1" align="center" width="95%">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151217/1_151215094513_1.jpg" alt="" border="0" height="733" width="550"></div>', '', 1, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(7, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-160120110141B2.jpg', '  <p><strong>烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案</strong></p>\r\n<p>① TGA天冬聚脲防紫外线面涂方案介绍</p>\r\n<p>TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。</p>\r\n<p>【适用区域】</p>\r\n<p>适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。</p>\r\n<p>【产品特性】</p>\r\n<p>¤  整体无缝，易于清洁，维护方便；</p>\r\n<p>¤  产品柔韧性好，附着力优异；</p>\r\n<p>¤  颜色丰富装饰效果好；</p>\r\n<p>¤  维护成本极低；</p>\r\n<p>¤  产品具有优良的耐化学品性能。</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093347_1.jpg" alt="" border="0" height="408" width="550"></div>\r\n<div style="text-align: center;">&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093400_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093354_1.jpg" alt="" border="0" height="361" width="550"></div>\r\n<div>&nbsp;</div>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215093405_1.jpg" alt="" border="0" height="733" width="550"></div>\r\n<p>【颜色选择】</p>\r\n<p>¤ 绿色、蓝色、灰色、黄色等。</p>\r\n<p>【涂层厚度】</p>\r\n<p>¤ 本项目涂层厚度为：1.5mm</p>\r\n<p>1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺</p>\r\n<div>&nbsp;<strong>A. 对地面及环境的要求</strong>：</div>\r\n<p>1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。</p>\r\n<p>2、表面干燥，含水率≤6%，地面的PH值小于9。</p>\r\n<p>3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。</p>\r\n<p>4、施工环境温度在10℃以上。</p>\r\n<p>5、施工环境通风，对密封严实的环境要求有给、排风条件。</p>\r\n<p>6、避免交叉施工，闲人莫入施工现场，以防损坏地面</p>\r\n<p><strong>B. 施工流程</strong>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151215/1_151215094041_1.jpg" alt="" border="0" height="413" width="550"></div>\r\n<p><strong>C. 施工工艺</strong></p>\r\n<p>1、基层基面要求</p>\r\n<p>1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。</p>\r\n<p>2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。</p>\r\n<p>2、含水率测定</p>\r\n<p>含水率的测定有以下几种方法：</p>\r\n<p>1）塑料薄膜法（ASTM4263）：把45cm×45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。</p>\r\n<p>2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。</p>\r\n<p>3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。</p>\r\n<p>4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。</p>\r\n<p>3、水分的排除：</p>\r\n<p>混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：</p>\r\n<p>a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。</p>\r\n<p>b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。</p>\r\n<p>c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。</p>\r\n<p>4、基层表面处理方法</p>\r\n<p>a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。</p>\r\n<p>b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。</p>\r\n<p>c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:</p>\r\n<table cellspacing="0" cellpadding="5" border="1" align="center" width="95%">\r\n    <tbody>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">检查项目</td>\r\n            <td style="text-align: center;" width="87">湿度</td>\r\n            <td style="text-align: center;" width="102">强度</td>\r\n            <td style="text-align: center;" width="91">平整度</td>\r\n            <td style="text-align: center;" width="60">PH值</td>\r\n            <td style="text-align: center;" width="152">表面状况</td>\r\n        </tr>\r\n        <tr>\r\n            <td style="text-align: center;" width="94">合格指标</td>\r\n            <td style="text-align: center;" width="87">≤8%</td>\r\n            <td style="text-align: center;" width="102">&gt;21.0MP</td>\r\n            <td style="text-align: center;" width="91">≤2mm/M</td>\r\n            <td style="text-align: center;" width="60">&lt;10</td>\r\n            <td style="text-align: center;" width="152">无砂无裂无油无坑</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>5、伸缩缝处理</p>\r\n<p>为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：</p>\r\n<p>1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；</p>\r\n<p>2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。</p>\r\n<p>6、施工步骤和方法</p>\r\n<p>1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)</p>\r\n<p>2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。</p>\r\n<p>3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。</p>\r\n<p>4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；</p>\r\n<p>5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。</p>\r\n<p>6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。</p>\r\n<p>7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；</p>\r\n<p>8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。</p>\r\n<p>7、地坪涂装注意事项：</p>\r\n<p>1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。</p>\r\n<p>2）具体施工应参照设计要求及产品的使用说明书。</p>\r\n<p>3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。</p>\r\n<p>4）施工时有凸起或溅落，初凝后可用镘刀撇去。</p>\r\n<p>5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。</p>\r\n<p>6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。</p>\r\n<p>7）在规定的时间内地坪表面不许行人。</p>\r\n<p>8）涂料使用过程中不得交叉污染，未混合材料应密封储存。</p>\r\n<p>&nbsp;</p>\r\n<div style="text-align: center;"><img src="/uploads/allimg/151217/1_151215094513_1.jpg" alt="" border="0" height="733" width="550"></div>', '', 2, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(8, '欣和食品TGA天冬聚脲防紫外线面涂方案', '/storage/images/uploads/20151221/1-1512242232230-L.jpg', '&lt;p&gt;&lt;strong&gt;烟台欣和食品有限公司 TGA天冬聚脲防紫外线面涂方案&lt;/strong&gt;&lt;/p&gt; &lt;p&gt;① TGA天冬聚脲防紫外线面涂方案介绍&lt;/p&gt; &lt;p&gt;TGA天冬聚脲防紫外线面涂地坪厚层涂装体系是采用TGA天冬聚脲防紫外线面涂涂料经过特殊工艺制作的地坪涂装体系。&lt;/p&gt; &lt;p&gt;【适用区域】&lt;/p&gt; &lt;p&gt;适用于石油石化。机械加工、汽车制造、兵工工业、航天工业、重型机械、物流仓库、旧地面改造及表面粗糙的地面装饰涂装；地下停车场行车通道的地面装饰涂装及其他需要耐磨、耐冲击性、抗污的重荷载、物流较多的地面装饰涂装。&lt;/p&gt; &lt;p&gt;【产品特性】&lt;/p&gt; &lt;p&gt;&#164; 整体无缝，易于清洁，维护方便；&lt;/p&gt; &lt;p&gt;&#164; 产品柔韧性好，附着力优异；&lt;/p&gt; &lt;p&gt;&#164; 颜色丰富装饰效果好；&lt;/p&gt; &lt;p&gt;&#164; 维护成本极低；&lt;/p&gt; &lt;p&gt;&#164; 产品具有优良的耐化学品性能。&lt;/p&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&lt;img src=&quot;/uploads/allimg/151215/1_151215093347_1.jpg&quot; alt=&quot;&quot; border=&quot;0&quot; height=&quot;408&quot; width=&quot;550&quot;&gt;&lt;/div&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&amp;nbsp;&lt;/div&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&lt;img src=&quot;/uploads/allimg/151215/1_151215093400_1.jpg&quot; alt=&quot;&quot; border=&quot;0&quot; height=&quot;413&quot; width=&quot;550&quot;&gt;&lt;/div&gt; &lt;div&gt;&amp;nbsp;&lt;/div&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&lt;img src=&quot;/uploads/allimg/151215/1_151215093354_1.jpg&quot; alt=&quot;&quot; border=&quot;0&quot; height=&quot;361&quot; width=&quot;550&quot;&gt;&lt;/div&gt; &lt;div&gt;&amp;nbsp;&lt;/div&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&lt;img src=&quot;/uploads/allimg/151215/1_151215093405_1.jpg&quot; alt=&quot;&quot; border=&quot;0&quot; height=&quot;733&quot; width=&quot;550&quot;&gt;&lt;/div&gt; &lt;p&gt;【颜色选择】&lt;/p&gt; &lt;p&gt;&#164; 绿色、蓝色、灰色、黄色等。&lt;/p&gt; &lt;p&gt;【涂层厚度】&lt;/p&gt; &lt;p&gt;&#164; 本项目涂层厚度为：1.5mm&lt;/p&gt; &lt;p&gt;1.2TGA天冬聚脲防紫外线面涂（1.5mm）涂装体系施工工艺&lt;/p&gt; &lt;div&gt;&amp;nbsp;&lt;strong&gt;A. 对地面及环境的要求&lt;/strong&gt;：&lt;/div&gt; &lt;p&gt;1、要求水泥基面牢固、结实、不起壳，水泥砂浆厚度大于5cm。&lt;/p&gt; &lt;p&gt;2、表面干燥，含水率≤6%，地面的PH值小于9。&lt;/p&gt; &lt;p&gt;3、表面平坦，无凹凸不平、蜂窝麻面、水泥疙瘩现象。&lt;/p&gt; &lt;p&gt;4、施工环境温度在10℃以上。&lt;/p&gt; &lt;p&gt;5、施工环境通风，对密封严实的环境要求有给、排风条件。&lt;/p&gt; &lt;p&gt;6、避免交叉施工，闲人莫入施工现场，以防损坏地面&lt;/p&gt; &lt;p&gt;&lt;strong&gt;B. 施工流程&lt;/strong&gt;&amp;nbsp;&lt;/p&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&lt;img src=&quot;/uploads/allimg/151215/1_151215094041_1.jpg&quot; alt=&quot;&quot; border=&quot;0&quot; height=&quot;413&quot; width=&quot;550&quot;&gt;&lt;/div&gt; &lt;p&gt;&lt;strong&gt;C. 施工工艺&lt;/strong&gt;&lt;/p&gt; &lt;p&gt;1、基层基面要求&lt;/p&gt; &lt;p&gt;1）新旧地面混凝土强度需达到C25以上，涂装前需清除混凝土基面污渍、浮土保证涂装基面牢固。油污或旧涂层基面，须处理油污、旧涂层，露出混凝土面。&lt;/p&gt; &lt;p&gt;2）新浇混凝土不得少于4周，起壳处需修补平整，密实基面需机械方法打磨，并用吸尘器吸净表面疏松颗粒，待其干燥。有坑洞或凹槽处应与1天前以砂浆或腻子先行刮涂整平，超高或凸点应予铲除或磨平，并提升施工质量。&lt;/p&gt; &lt;p&gt;2、含水率测定&lt;/p&gt; &lt;p&gt;含水率的测定有以下几种方法：&lt;/p&gt; &lt;p&gt;1）塑料薄膜法（ASTM4263）：把45cm&#215;45cm塑料薄膜平放在混凝土表面，用胶带 纸密封四边16小时后，薄膜下出现水珠或混凝土表面变黑，说明混凝土过湿，不宜涂装。&lt;/p&gt; &lt;p&gt;2）无线电频率测试法：通过仪器测定传递、接收透过混凝土的无线电波差异来确定含水量。&lt;/p&gt; &lt;p&gt;3）氯化钙测定法：测定水分从混凝土中逸出的速度，是一种间接测定混凝土含水率的方法。&lt;/p&gt; &lt;p&gt;4）测定密封容器中氯化钙在72h后的增重，其值应≤46.8g/m2。&lt;/p&gt; &lt;p&gt;3、水分的排除：&lt;/p&gt; &lt;p&gt;混凝土含水率应小于8%，否则应排除水分后方可进行涂装。排除水分的方法有以下几种：&lt;/p&gt; &lt;p&gt;a.通风：加强空气循环，加速空气流动，带走水分，促进混凝土中水分进一步挥发。&lt;/p&gt; &lt;p&gt;b.加热：提高混凝土及空气的温度，加快混凝土中水份迁移到表层的速率，使其迅速蒸发，宜采用强制空气加热或辐射加热。直接用火源加热时生成的燃烧产物（包括水），会提高空气的雾点温度，导致水在混凝土上凝结，故不宜采用。&lt;/p&gt; &lt;p&gt;c.降低空气中的露点温度：用脱水减湿剂、除湿器或引进室外空气（引进室外空气露点低于混凝土表面及上方的温度）等方法除去空气中的水汽。&lt;/p&gt; &lt;p&gt;4、基层表面处理方法&lt;/p&gt; &lt;p&gt;a.清扫水泥地面，移除地面较大颗粒垃圾，石子等。&lt;/p&gt; &lt;p&gt;b.磨机清除表面突出物，松动颗粒，破坏毛细孔，增加附着面积，以吸尘器吸除砂粒、杂质、灰尘。&lt;/p&gt; &lt;p&gt;c.有较多凹陷、坑洞地面，应用TGA天冬聚脲防紫外线面涂填平修补后再进行下步操作。 经处理后的基层性能应符合以下指标:&lt;/p&gt; &lt;table cellspacing=&quot;0&quot; cellpadding=&quot;5&quot; border=&quot;1&quot; align=&quot;center&quot; width=&quot;95%&quot;&gt; &lt;tbody&gt; &lt;tr&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;94&quot;&gt;检查项目&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;87&quot;&gt;湿度&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;102&quot;&gt;强度&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;91&quot;&gt;平整度&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;60&quot;&gt;PH值&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;152&quot;&gt;表面状况&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;94&quot;&gt;合格指标&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;87&quot;&gt;≤8%&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;102&quot;&gt;&amp;gt;21.0MP&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;91&quot;&gt;≤2mm/M&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;60&quot;&gt;&amp;lt;10&lt;/td&gt; &lt;td style=&quot;text-align: center;&quot; width=&quot;152&quot;&gt;无砂无裂无油无坑&lt;/td&gt; &lt;/tr&gt; &lt;/tbody&gt; &lt;/table&gt; &lt;p&gt;5、伸缩缝处理&lt;/p&gt; &lt;p&gt;为保证地坪表面无接缝，整体性好，我公司对伸缩缝，采用密封胶进行填充。施工步骤如下：&lt;/p&gt; &lt;p&gt;1）将裂缝内表面清理干净，并用手提磨机打磨两侧，密封胶填补所需要的清洁和粗糙度；&lt;/p&gt; &lt;p&gt;2）使用TGA天冬聚脲防紫外线面涂砂浆进行填缝密封处理。&lt;/p&gt; &lt;p&gt;6、施工步骤和方法&lt;/p&gt; &lt;p&gt;1）打磨清洁地坪：用打磨机全面打磨地坪。(说明：打磨后可清理地坪上松散物并改善地坪平整度。)&lt;/p&gt; &lt;p&gt;2）局部地面修补: 用TGA天冬聚脲防紫外线地坪漆甲组份加入大小适当、数量适中的干燥的石英砂搅匀，对地面进行修补 、找平。&lt;/p&gt; &lt;p&gt;3）涂刷底漆一遍：用TGA天冬聚脲防紫外线地坪漆甲组份涂刷底漆。&lt;/p&gt; &lt;p&gt;4)刮TGA天冬聚脲防紫外线面涂砂浆层：用无溶剂TGA天冬聚脲防紫外线面涂地坪漆与石英砂配成TGA天冬聚脲防紫外线面涂石英砂浆，分别满涂刮地坪，以达到地面的平整度，石英砂涂装层干后用打磨机打磨平整，并清洁；&lt;/p&gt; &lt;p&gt;5) 施工TGA天冬聚脲防紫外线面涂腻子层：用TGA天冬聚脲防紫外线面涂树脂地坪漆甲、乙组份调合滑石粉成TGA天冬聚脲防紫外线面涂腻子满刮地坪。&lt;/p&gt; &lt;p&gt;6) 细磨地坪：用打磨机配合人工对地坪进行细磨，然后作最后清洁。&lt;/p&gt; &lt;p&gt;7）施工TGA天冬聚脲防紫外线面涂色漆层：涂刷TGA天冬聚脲防紫外线地坪色漆层。要求颜色统一、无遗漏，不透底，在墙边、柱边、机器旁边应用毛刷小心涂刷，不能用滚筒滚涂，以防弄脏墙边或机器；&lt;/p&gt; &lt;p&gt;8）施工TGA天冬聚脲防紫外线面涂耐磨层：涂刷TGA天冬聚脲防紫外线地坪漆面漆。&lt;/p&gt; &lt;p&gt;7、地坪涂装注意事项：&lt;/p&gt; &lt;p&gt;1）涂层涂装完毕后，在温度20℃时，6～8小时可行走，温度低于5℃，则须1~2天。固化后2天后即可使用。&lt;/p&gt; &lt;p&gt;2）具体施工应参照设计要求及产品的使用说明书。&lt;/p&gt; &lt;p&gt;3）切勿低于5℃时进行施工，施工温度在5-35℃，最佳温度15～30℃，结硬前应避免风吹日晒。&lt;/p&gt; &lt;p&gt;4）施工时有凸起或溅落，初凝后可用镘刀撇去。&lt;/p&gt; &lt;p&gt;5）地坪上需进行其它作业，应在其结硬能行走时进行，如果使用前浆料已结硬的应弃之，不可加水搅拌再用。&lt;/p&gt; &lt;p&gt;6）配料多少要与施工用量相匹配，避免浪费。一次配料要一次用完，不可中间加水稀释，以免影响质量。根据施工经验，一次配制5Kg左右为宜。&lt;/p&gt; &lt;p&gt;7）在规定的时间内地坪表面不许行人。&lt;/p&gt; &lt;p&gt;8）涂料使用过程中不得交叉污染，未混合材料应密封储存。&lt;/p&gt; &lt;p&gt;&amp;nbsp;&lt;/p&gt; &lt;div style=&quot;text-align: center;&quot;&gt;&lt;img src=&quot;/uploads/allimg/151217/1_151215094513_1.jpg&quot; alt=&quot;&quot; border=&quot;0&quot; height=&quot;733&quot; width=&quot;550&quot;&gt;&lt;/div&gt;', '', 1, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(9, '新产品1', '/storage/images/uploads/201704/781a39a4168aa7f7d2f1f4888ed9e43d.jpg', '<p align="center"><img style="width: 640px; float: none;" src="/storage/images/uploads/201704/be5c84c9a1be237663561a700f28a5d7.jpg"></p><p align="center"><img style="width: 640px;" src="/storage/images/uploads/201704/c33b03f91963e7f13b0dfea553c033b2.jpg"></p><p align="center"><img style="width: 640px;" src="/storage/images/uploads/201704/cb5700aabb494db350c9f0221e97689f.jpg"><br></p>', '', 5, 0, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1),
	(10, '文化石', '/storage/images/uploads/201708/41b16269574a143ab5c69cc283645799.jpg', '测试测试测试测试测试测试测试测试测试测试', '', 1, 1, 0, NULL, NULL, NULL, NULL, '2017-04-19 01:15:32', 1);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;

-- 导出  表 CarFactory.__migrationhistory 结构
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  CarFactory.__migrationhistory 的数据：~2 rows (大约)
DELETE FROM `__migrationhistory`;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
	('201803050350081_initialCreate', 'CarFactory', _binary 0x1F3F000000000004003FDB723F72EFA93F4CCD533F3B23C997E3E392764B47B6CF6A57B6B51E9D4D2A2F2A8A84462C733FC9B1A5A4F265793F3F023F89FB3F3943994F3F407703DD683480463FFDCFFF9EFEE97113CDBE3F0B93F86C7E3F9ACF403F4118AFCFE6BBFCFE0F6F3FFAE33FFEC3E9FB603FFB7B553F3F5BC6D9D9FC21CFB76F97CB3F001B2F5B6C423F4DB2E43E5FF8C9663FC9F2E4E8E897E5F13F401073086B363BFDB28BF370033FF0E74512FB609BEFBCE863128028C3DF61C9AA803AFBE46D40B6F57C7036BFF03F9E9F27E9D33F043F7D4861E1F724FDCAFE9ECFCEA3D03FAE40743F9F79719CE45E0E3FFB7B0656799AC4EBD5167EF0A29BA72D80F5EE3F03B85F6F9BEAA65D3C3A415D5C360D2B503FCB933FC0E31778CC966CF356233FAFC7148E6A3950A8D7C5C89ECDCF7741985F25EBF98C45F6F6224A514558E76E3FEA41D158540D7E9AA13F0ED26471916C3649FC532D242F16504A16473F3F7651BE4BC1590C7679EA453FCDAE7777513F153C3F5F417C16EFA23F0F1208CBA80FF0D3759A6C413F7D01F798E8CB603E5BD2ED966CC3BA19D1A6ECCE659CBF7E399F7D82C8BDBB08D4DC27BABE8252067E0331483F04D75E9E8334463040317E1C76063F88BD383F3F3F82A2997244AA9BAC403F3FFA51B5833F3F9F7D3FAF40BCCE1FCEE627AF5ECF671FC24710545F703F8F4338DF613F3F1DAE8F207F488241505D7B68223F3FA88E8F4E5E3AC0F53F3FC4F39BB0E9D93BC8F53F272486D0DEED523C6329093F771185503FB7E74190824C351AAF5D8C45894EC3E2E393370E50FD9A26DF91BCC7F749EFE2F4FE112D31043344988E8E8E1CA0BADCC05F59127B507FB498CF64F3563AE4A2D0E1507C3DD77D3D5D364B877241F9D5F3BFAED36417077F49EE4AFEAA5716AA41B6E03F0BCDB4B8D4B8E03F540A063F3E31E2AF3F8288CFD3B55A27BF7CF3EA673F6B89FC267DBA80423FE37CFCDA1A3FF09843484E74FD9597C96169E679767EE7C54112835A6E7E4D3F783F15D76998A485D460AE408B979E434D0DDBD527059EB395B100663F8DF53FA4640D3F2AF5423F2EE09C5B603F2B87F13F50FF03550A5DBF513AC7483FB4D2115A17EE944E35461AE3E0A5E9D262293DAB87243F267DE1BE3FF6EF5DE7E90A76A09B317899BD0311B48A3BAB8C124C1BFBA468293F7A7509F7F8E17D3FB48A298C563FB8424B365B2FEEA0CFCAF6D5DF493F78570ED19E14CAF5035CF85DE0D51D42443F790F456F00343F3F4457493FF35D30007FAEA0280F83695A399EF7CAF11E1D3F3F08166A3FC8F3423F07BADB6D3F74815B660B21246727BDB35F3F103F8660B5A22929D3AF12CCD87FF2BE85EBA2976280F3D9171015E5D943B8C53F87E1B66E3F4D365F924836F255C5DB55B24B7D242F89493F2F5D83BC3F3F1D37A9993E3FFD9E0D068DA5F0A297F3967761B68D3C9D9562783F6D363F83D0170ED68A3F89F33F96FA3996DC677882DBEA68DFD1B58CA5E0FDDD8B763FBF9EF6483F7B4A06DACDA18F50F8C3A2A1FF3F0118CACCA2BB3F043473FDCA8BD73B6F0D745DBB4A7C2F0AFFB3D40F82F69365313FE8654AEED51CF195B7B76EEEA4A1CD136688A8CE46CF643D3D6FEB49A0E36EC063DE554F2218A3D6958768375583BB179D593F000C6CB6413F70AB716C2BBEFEF9F8E8CD9B7E168849656954D6A7243FC7C42B87AC3FD8D6E3F2C9F96D1706F6AE22443FBAE3975EA693C68BCBC6D7463FA1D1F4D2D4AB487361540BA6D695D4C9FD548DEE3CCBC03F7AFADB0EAEC1708AEB5C595D763FC5F6D2A33F3F38372052849B0A9662583FA5D7D78BE3A39F9D0CD6A31F3F100C88B232290641363F62B5BBCBFC34DC765F2D58483FC0CAE1CE3FEF4BD6A4CBF7A0CB0F5B4D7C4ED75E3FB1B05BDA4D2F593F5BB0ADA7EDAE633D72EDA5806964B07549946E28BFBCDADF79624F1BE4E9846E94DB5D9543C7C543180550F8851E1DACDEB96D6A373FD24A3F87BCA6C88B434575395FFBA0B9A2444F73D5BB56EBC1354837613F5B0CB3CBE45DFE90A4D53128D77CBA487E3FC997D96F29A4B5BBC23D6C3F4DB58E330281C8164240BD5D113F2B3F1167E789673C803F1D071081C81642403F80F6BB3D737D3FC1CE579AE5CA6704B87D563F3F50E8DF308F54BAB43F499BF51EB0FE3FE0E95F3D34B376F4EDE5D5D6B44D78763FACD69AE73F3FD7B9E5EA3676B7A40AB75390D5EBE4ED8D403F78998131E976D5BCABCFAD55278BAEDE6A3FE49FA3533FF1D677A1D53F28D7D33F2D0F7218C2A501A9CD5BAA523FB065DC62C0553F2D22E4444E1D5589A13F13534756B0A58E950539897C4D864EB6829858AE96F5E95BBD6DCBE4C4523F3A3F318964854E6B7E394C6DD7FC664F3C3FBFE73F34663FBEBA3F3F09BA8578B29795BC95CD51BCF7D6BFC6EEC9C3702FE3B4DAA53FF05E7B593F4955D7CD3D9DD5164CBE48E2FB303F3341733FF8C289FB7DD5DF2F20033F183FFF6BB2CBDFC70132397ECF7D5BE3E7DCF73F3F00470B046C74AA56671635454E3F143F3E3F7768E5903FFCD7C9E309021B969D3F58017F87BCD6A0DDBF3FD0879BEF493F3AE2C065463F17F0CE3F3FBAC24186D3553F5B99FCD3AEE7F9ED7A222FDC884DE0C2AEAE3FEB97F8CC19BE6499AD45AEDB7F95B0C5FB2FB64C42588FFB3FA864FFC59689A9EB7DFF554056EDBF3FC4C4763F153A48217755394B5DF159425359E67A2758C0963F3F3161BA9DA08ABAE2C8564E172E66282ABE8A69298B6CA9C0573F423F0C2D5581989CBAB4F30EB9D03A6DAF8B8BC693473FD7DE3C3F3F00BDDB800526DD4B36473FDA9305412A7469DBD954349E663FCEA63FF0DB3F503F7B3A5E3F0FF048D54ADA75B7AA2A612F6F5327593F3859B777551B9BA236F4912B3F3F2DC5C23F3F3F91ED74A8BDA7C7FA8E1262FCA83F96A1A4BABDCE17C3985E5A4AE6DBF4B07F7A3F9AC7A0FD3D3F835EB4717810043FB5AF43CFFE8DB2803F1AD7DF8FFB3F694FBB556837C7C02F661AC6A9D0DC4E52D2B9BAE49BEEE946693A763F2BD59EEC7E3FE58E3F555CDF916114925B32BE544663979B3255F0770C5E10ED9D2E91D1A58AE7DEF9F60EE350DDDF49AAC83FBAC33F473BF7FD3FA6DD511A6E3E1D4DC871EDED343F3FE3AF967AD4C0C7D1CD958AA17B3F643FCD8F3FDB5F9F9DC3B9BDD9B6D63F8C4925CA71B552894E77333F3FADF93935F6BA360BD4A33F9F924E77C7F505643FB3C2768393B798CD6551E9CD30DC998D95E6EA761E2D3F9D465BE8855688A911EFD613F4CC1250B2CB3F3F50F1B58D51275B7CA7687523D893B04C3FCF99657E6006EA6E433F4986F0CBEC43E4ADB39A26F5B4A18064E2ACE39D3F5C720390464F7089C6AC78CAD9405E1F017A71527B367D9FCF8AABEDB33F6E48A9AABF8228F9FE2949375E5437414900546DD8EA1A14E7773FC0B439D1A0F873B87E682ABFE2995BB251C15AF1E53F6715F17C31C461F95A3F78543423B8DA15AFB21A2EA9ABFFAB97C6CD80ABEBBE4F3F3FBF5057FEE03F3FD354CB4991C168C7477A61E3E1B98B8765CB514B2E5DC6DF3F0C645B2233F66120CDC34A3346163A378393A0BA3FB354828DDA639AA926BC940A50BED6535A0C4CD1967875869BFFAC691E7F8D93EFF1FB47B4F27B11F6FEC56DDFA8DBA2978B20F8BCCBEB06BFE869253F4A286635B2D1BC9118AB5D543FA45B1D581A4C4AF6401B203055835FC8BA3FA3789E653F16DDA3AF4924797069E4EFE360663FB7D95C483F17173F49125C6ECEE6FFC2753F631D0895C3C8E238A6FB04717C8E4B6370765E5C0123AF83CCF702DE5C3F1AD05FA0E90E506CD7D0433F51283FCE793B3F8CFD70EB45363D6180186E17103F3AB6E41DD88218593F3C34A1837033E0C9A9B132633FBAD32521AB6A113FD19509934114E04690F83F2D51473FBFB299E012083F173F435A89A03F03889F765C4C686842A1EF45F2AE2541E4643F3F92BA3FC6A7B98A944117C85913EEEED0B4A3A6130308A6864926143F2E3F98E48B6E99B8089F77D3C781BD8A873F81B0123F7BD186828118403F3FC15A3FED513F3F3547454E486A01533FE9CB7E0D4CE1FADC4150780A063F7E408DB4117DAEB83F3FFDC1945C16BA86753F3FD9B03FA060283F0C3F6AC6F1647F92C3393F592DF78B3F435247BA61054946C6503F1B5F133F8FA03DCA55197C44CD742612C9FE4C24263F43093ECBEBCF443F6230613F3D0E133F22A3E43FA2CC3F4C14BF8621E79A4FDCD19FC4098667283F0C3F643F14A464331335687FF2463F62082963353F5C3F0C2556548FC72150753F252BF9E84F2D4C22194C81840CA07D3F0D25236C3F5E4CB8803FAECAA3A7373F9BF60A9883DBE4320A063FD9808EE558800B66AFE4B2E658A095E4ECF5584046C1503FE26301713F25AB4D3F5AC9D0FE8F0594640C254DCFE258804B07A1E4BC66FF2692A69EEC6969260A869CA1F66FB2E1194A185BEEDFAA58627B3FC1D36E19BB55EFBC1B86571136CCF599E271F860CA4C4E3F003F1FD8B1D85482C73F6E6BECAAD652B457DB4A4EC370523462FB8A0991A0E1B4C2F3AFB5F4D8FBF639179EE19DF2C4E3698278DF5E78B2B0151A2E3FE5AD4568FF86B986903F6A84C679F9CA09B6C9618BDAE9B909F7F53F958147D1DB3F482676F5CEF0635E5654106C6802573F7670FA5C2528AC7DF3B8AA7AD48B3FF246033F4B092051153F2F1A9095273F5AE3C43F926CB65E2C8651166941603F02512B630D08DAD1580489F50E3F00BCF2E2F5CE5B0321CFB6683217B2505533867703453FE64D217D1AB8D43303015C3F3FC0D5EEAE4E623F4E3F42C4FAE88A103F3FA0E4E69A0727D89FEAE0E16C3F603F3F044EAEC13FF7EF9AC648233F3F8B413FF38E1002767C34005325521182C13F06606463D15CC9698028263F4BF9D73F68B2B8BA46C0E5008D460947B0920D541D1FCB946F38FC8B927D753F03A0BAB1633F3F6A643F443FE0C4A2CF2D3392D74833A28DEA5D9178D7421988660F98EA0110AC5E3F64FB563F00DEACAEEC3F3D4A0623287F0C23183DC3973354E7F46F67888E09A445316EFAA73236A05B0C9EEC3D8760E88C9E7E50BDD33D3FFAD62C698AD13F3F3F56643F2A3D91F192C53F592CA79D3F3F5E52153F01083A4C2EAB8E7A4CC6DB94755B76702B205D7070DB620004C7B43A286D07800A3F1900E999234FBAE8CCD17E0044278C7D0D001F9053320A3F103F3F10FBF13F783F28D8E83F85C0BF564035ED61DBA2DBB4632C03A0A2D14D8FA9ED8BA4DBD2FB439E743FA2FD003FFEC8F584A4D93FE06D826400044E3FD1B41BA27DA769EF413FA6CF4D671BAB4FD25FB18F1C4F323F67DF6B3F3F0021B34E5BF49BF3E912745DEDF7453FF5FC223FB24C0DA547F5C63F3FC06CD1933A303FC0408B9ED8C346360A168B9E3FC77E3C865C3F3FD9783F01522712FB511874091005A1E70742E7CF20BAB2D1E888FAF046311C0A1F3F244214EB5E3A1466BA42712DDF6E28063F6C587D3FE8CF6724F7CAEDBA3FCCC93F6EBF74182C74A6EEB6B4DDC0F4A139ABE884F5BD5D5D76BA5C3F60E3E10FA74B583FDB7CE7453F106555C1476FBB45664C3F7F99ADB69E3FB4FEB09A3F37519C9D3FF27CFB76B9CC0AD0D96213FA693FF7F9C24F364B2F483F47473F8F8F979B12C6D23F327BCB586382AAC35B033FDDA505E043986639CABC75E7A1205317C1863FB8A53FAE5618D98B489E7B3F6B3FFDCF5E3FCA6A1F52F8FD7B927EE57ED7B799FC3F3FEBAE373F3F174A88823F6CBCF2BDC84B05D1492F9268B789E577D9F2D64DBC511246F3D51C52756B4DC291DD64CBA1AC403FF4713F121455600E3F3F928007477E3787763F1EE7C56C25A191DFCDA1BD7F043FCDEE323F093F6A013FCE512A81DB149BC3E6429A9390B9425B3F8FC8EFE6D0A8F0E42438AAC066443F158C64FDD91CD6E506FECA92987460A4E6AEA03F74F1BC16D7B0E0543F52665E3F457CE7A13F19ADC7AADD25A77799959055E4466A9E7115E949D7F33FF64A3F00463F3F3FE3A13FEA8F5670CED375C6C1293F5AAC46295CE08B4B5D6A35AABF9A433F3FD88ED7AC543F3C643FE151051673353BBFF33F3FCB40B2C06265AA834F53EB52FDD5628E53F1B6A9594E955842142B3C3FF7DE7447739BD793DA905D661A680B79D37E9444854FB04053251646DE433FD67BE2B3CD4482CDBEB373A8FC664111C4CC10537CB1A1A38E774F93527F3687C538A7933F7E3F98C2694D97D8A9443E79153F3F6D303FC3C4695621D7933FFC56FBD273D8F9B5859A93B5EC49CB953F4A3FB0589051506E66352E3FD96C3F765F1E596D5D50107366DB527E323FDCECB5D8E45D253FCC77013F9ACF367A211781AABF4E5A5B357693D61EBDD6663D257B52DEE288F2F6AA5C073F8D4EBCD63FA0FC1157013F89CB1A553F495C7D6A3286C83F1316072B7DC88986A73F3FF3FD3F593097EE3F8F86ADEE4EACF9B5DE763F243F3FFDA80ACD9D3F397AF8BA87D31742C28755172D9795FAA6B6DFF5A405173FFBD1313F03643F3F3FAA6032543F2743F590F47A4B8DD23FEDEBAA5D3FB5C5ADBB0994E76F3F575A3E7B6B5A7EB1527B6186F27BF27AAFFE3E295139C4493F23255A3E3F4E91DE701E55053FCA540CE9D0156A453D3F3F9B6BA6D29590BE682ABF99433F60AE793FC3EE5A27C5F20C140BFD823FC5C23D81B73F7A103D6D03093FEB8A2BB5583F172A99F33F423F1E525362715E5AF39B87C996B5817A9E656073173DFD6DE745683F3FB5956DF17287BFF5571B97D42A3FED8F5A7DB5759165EED2EA8F562E89D12E003F1E5768BF7466E2B5D3CEA97352B0AA284203285B2E145137C5AB0777E8F63F0FF5FE168549014FAA44AA4AF8582C3D3F2EAA90BDDAD0833874553F3D669E79006B97F984F55329BF4C57093FD8A4002D14E0B5F2B5B75BDF886B3642621B3F0EC8F8D4A0C0BEB15636BFA5102DAF6CEACF3F3F70B7628B734E8C4860AB8C102404599688020AE7732149BB71483E5A160C4542376A865AEFB438868A8760145E34D75564C19E3FC36F230FB2963DAD43611E313F7FB2583F360CD78B0F169298320EF0C507FBC74FDCF2407C1FFAB1D264C04F063F0D78593F6736500B3F6ED68F3A7C07EAF353765610053FF3DD9F51AC503F9F5395F8AB9DB2BCF776513F4BFC7952BC728893E27D068AB70C2FD5E35EA5853F37EB47F19EEFF2074843753FF0C111D7B0DBEFF0BAAFF93FA55EBCF414BEDEA44B865C26563FE6803F6D8EE73F4A1F773C5F7D3F25B8FB3FD34DC17CFEBC5E52C59E3F2003390F5F506C3F13FF6BB2CBDFC73F3F3F67564C41B1C5BCF17D28211F60EF4120083F28B6594A6BD284EEBD6CA9C568A357D69F763F14173F67B2C086523F16039E5E711D1B27137F87DC49A081B3D9B29E26543F3FDF93528F4B463FB7814E4E0C1E365B6A031965E9FD065888D5573BE3A2084D2EB65B88A23F548FE264043E0323503FC4992558A6D26A670E4A3F3F3FAFA2A2F37C2C36E2B3252C819337F97D3FD6B3479A68C3D93F33C8B53F92B63FC6EC293A0FBF7D0B03D6EA633FEC48DC867B6D41151C9484F67AC25A2168299F439EB41E9A785ADF6F4F8A5826E67D87BC697F3F5A271F476ED19D0F87A667693F27847890C76992FCB6F6B3DF14D0A12B83E9C9DBF4E2C2E593B749A1D513B16725D65A691D783C3EB9C23F3F54C190D6CB4512C7C02F3FF394F355E44BF7711C3E1D5D4FF6E0083F22E8DCF7D11563AFA71B18473F0E69EB4337F9DC3F3F3F3F82547DDF8743857B3788E95271D2CC93666E263792F73F079B6DBFEA9944D4E592440AE2D015B56BA3D79DE247FF7D4EE5AA5656C7E64EF3473F3F649CE772F56D0855B5473FC8F11F8BA8E5E13F9843572F6ED4813F54481B5BC3E2702AF772D685B4FCF4CCA7C460214044C85A4E8BF13F71332DD87160218ACAF7B37DF8810C5B2E3F5BA5C68EBFD4BF3F3F3F955C3F073FBBE87F86F369B349ADCB2AF359E54E7236FFF8B4FA8F6881CA17C5BF3FD2D43F253F64F94D3FC467F3578B57F3D979147A5999F21CA7EB7E3FC9583F4E723F3F7FF7F10B94BF1B043FDBDC3E0B3882926541243F8ED854BFCAC099AE672CC6B7EF9E620F3F104670B37A5B55BCFD3FFDD93FCA495C5D6C345A8B6A95D13FDF813F163F383F786225AA923FE07E26533DA74BB6E1A9407DA1DE9ECDEF42B8E9806C2CD4E36F003F5CAC826B0F6E433F55044547E6B34F3F426ED867F37B2FCAB829C66268945989A740D2C0C853FEEA3F513F9A503B182B3231770928FEE6A5FE8397CE671FBDC72B10AFF387B3F9C9ABD7B6A03FDD6E213F3F908F8F4E5EDA8266527797D003C8F2BCF87D3F3FCC8A697964CD7241FA6E21EF8D80713FC540BCB61E0672033FE19337B690A9BD945B3F927A3F001F1D1DD9421665F6EE32EBC499BC5B2B02328177A79E93EBB152FD6B725E8F59313F3F23F9EAF8A40D3FA1760977038270B7C9516875EBA5A3CEA85D82CA365E14B5D12154366D56D571EBFA651C80C7B33F158DDF3FFFED96C8767D4BC0FA693F3FCFDBD9C9ECBF3BAA4C2A3FB7A932369A8164A26E2C50491239E9F631EAB665479B5C3F31709D889F5A3F9499EF74FD62CC7D730568AC56EAE43FABB2AA78BB82266CB94D1A8F49D98BDAA2B3792B74D74B661530824E24F7760DBA8AA0434E425BEA8A6CDFED6D2962A7DD3FE67AAE8B7D405FCBB9D47BE26BB97E303F8B712B343F5BABCFCA7A3F7B3F3F958353795B8035113FBDB7633FE1B7633F7B3F708974E0AE21D7D93F039E54FFA4FAFB51FD6C0A593F405777745AAA432A4C3F106E51A2DDE990D8F921B1ED193F5DF86597C559D368F7AE3FB9717927B862706E5037AC4F0A8EE83FA3F5818E9BDB89B1C6BAAC4AE06CA84F2633D678F6BD3F48A482321A9FFA4F1BE1C91A5283EE3F12E568D65E1DF36D06B24D443F3FA451622FC37DAA455F73A7D83F94CC81DD41D74E1A7BD2D883693F11740BDD89DA4D5B3BE75A94CE63ED569B5651741D6F1C8BA84BE65E1FF69B3F8180DA5CAA4FDA6550EDA2763F6262AF776160BF9FE342682884F9177B59267D783F22466B301550C3DC8FC5E8F43FACA19CCCF6F71DBA781A7D74A6910903363F55563F3A3A73D459A0BB4A0497563F4022AB745750CF468F71399675A692AAF158EDA5566A3F676883535956A5DF3FEEB63F3F86FAECF6650B2F2FFDF23FC1855B5A27BDA6D3FD3D127F3F3FE6B5A5C7617AD199C7A3D6C6DC7B353F661B0C74BEC83FE3E13FEF8C9B54DFD6CB41D5B43F5D3F446552BEEAED78B3CDAE7C3A449CB6F9FD28E46B3E09AC4635722D0652C9C21C3F3FA6CB1D3FE08097859E94673FBD833FC459CE83AAC29EDBF9BD94AD3FA8AD37778C793C167F9B6B9CEA593FCB7A3F1FFB511265866A3FE345DA6AD7408B5CD68EDD99C9C4D67693B469293F43BDE699ACD1C91AEDC71A2DB2983F3FDA9C93EE6E3F91485B7516D7EA6D4EFFC6E3A1B97256D9B63BAA629C67FBB015BAC10247B5EF64113EEBE5C0602479203FCBF6B4A298D844647B3F1AAF47451A6D93C33F3F463FF5753F3F6EACA84DB7B67D2C2D0E563C3ADAAB63AFAD3EFA5C3F770BB6C94CEEF8E848929B5C49BDB5A3B12041B95B043F3F3F41A272A1441B3F6C6A3F160995925CEE7E683F2E4E41DE813A26F17857FAF864E39D2C4236BF782760552E3F4098D8FF2E0578327F27F3574E3F6EFE9669C34D0CD3A2E6742976388E736A3F0C62592748EFB63E91C93F421A3F67934ADC644615353FF5AC66143FDDF186E59A4C9EDE69436825D246E7F655C549A09F95400B5C0E9E816B85B1F89BBA4D4D4E4323137E27574E9D9F4B3A8B907D087B3FC8D03F2C378BB93F1BABD2D8D753A3E911E8F40874C047A0CF4051192AA6513FF662B7EC373F9591D2AD5B3F669B6D299F9F5D85A045561827570C3FC0886CC9E91E60D87B802AFFBAC9290F3FCAD562741B5D5BA77622617C97DD193FD3F6385FE4C33FD6B8EF8827EDFE433F7089D38D6F867083B13F0CAA698D8F036FABE674640B87F63F2944FB5B7172F7DB324F3F76483B3F3FC7A8FCB81DB77B46C8F7753F3F98BCB2564453CE47EE7A3F64FE8C3F16BE68E3E2E06AF1B0D2F83FC3A24663D5FC3F4185551C7A3F6E4981E994525070D8DF6D3FFA5A2E7B8ABE3F9F554EC87A6199BCD26A7E5A072A12351AF0553FB068047B6F96493FBAD9958E69FB749E653F16E4D227F14C9EA22A210A4DDDFB383F7F1522614A493F44F78BFADB4768533F48362400F67A3F9EB33F392E477E765E1C6BA387FD993FFC80C07E0432223F54042D6C114DD2BF70683F04282E563FA7FD2C4F3D38C4FC7C0D633FDC7A1133084C3DC3993F5743644BDE812D88D17C15773F2371C5C223AEE133A3AD1B87D32521416AC1E254EAC5431841B3532E54FCA241703F143FCB56396C043F3F99E13F203CC2BE9BE06DC2CCED4582AE713FFCB74E3FE371935D99E06BF391E6674F3AE9BA8A6C4390507FEB45A2C4C3D23F553D314145866AD98B3FAF7D0BC7F94C2A323F658257E587414485781E3F80BFF6222E4507071095A61F263F0B678F82D2985ADDA4453F3FDCE2233F427E1B2F2C8C5D3F3F374A13D7FB3F737D3FAEB3176813EBFB66BDE8CA728FFC473F876B143F6E0C01F8EBE865A6EC3F8C823F686D4769E9EF10E49A8F404C6E3DF8D2510B10DF9F710812A2FE70154EF9FE90C15F7E1CB5B4D4DD188790609176A16AE4E688484B3C0F3F1A8D50BCE21D6ABFC9CDED6730AF8DE7F4213F0B6E0FB5CFFCA1B97D08FBCB82DB83EE2F7F683FCCBEB2E0BBC976C1885DCF7DBB60CCDFBD6C17AA900C7B1124FC527028F3A07ABF48403F8D5A83E04E8CC548C05C1FCA4C98B87E103FE6BA6B679BC3E1FB801E3216ACDFB7670C66FBA0563FE3F7652B968E78B04D0E5B80B47E3F800F619AE5288CC59D97018EFB3FB45A70FDF31D14DAAB041A648D631FE66353B4F21FC0C63B3F773F423F787EB7AD2A6402F9A0B1FCEAF95FD769B28B83BF2477A55F3D874E50478297AAA947DE78EA70383F11AAA6543FD96CBD5888A02A11C2AF0A35E059A7430E0B5B41326EB89A7EC4EA4580C354974850E0723D8AF32D3F85505F79F17AE7AD814804453FA8AB0AAD703FCF5A4DF097353534A04A7A3AF8C7261C017C150966B2A21D663EFBBA3FBEBA014564233D75BCCB2447115F4542055B518F5DB057E5D00BEA48F0935B772DE6CA9F8FC7579588B0D43FF0E53F0007BBFC2C21BFBC5FD2412E3F0E72F9590219159A41C65E6B42F0B84C3F3BEA99203FE14244B84C3F5FFE9B2092703F523FE3885C7475025B5F16E950C842A9711865152504F0D54D6991E2D6E032635A1D6943C8B7BA543F5CC74218EBB7E77299ACABE844135734C36EC05671350515762C15BFF61252613F3FF394103F6712499EB3CC8836B4A564F2FE453F3F84F8C66D2BE48F5688E66C117BAC4B77D86030E44F30040361F85E83EA8C8CF14577F842C5B088DF6758406B313CB2F70582C1317A8A407588DD3F9D90ED543F7ADABC281ACA6C07FB4E935EF1828E4A9DE6052712047D3F453F03A16E86BF3A3F716C2EED9DEC68DD4117393FB56A3FF274583F3FF2A1773F0D93F5507D6C76F0DDC4D6A7AC7302CF54075D3FE6BA19FEEAA6633F4A3FE9FD683F4AB782A5EEE44BDD74199BF892CE0A5C3F7092DC92D4ADCA8F6E3AD5EC2B243F7BA975EC9A886FEEB83F5C09FAA676CAEA3F8E6B3FC6F9163FD6D7B2D06BC74C3F037F9B43EEA2466BAABD4AECC9DCB33F3F083AADF380E8C84F3FA268537D72D541CD8CD45D3F7E0715FB69D59DB6930D3F003F513C4697B807C0C92A12487D0159979D2ECBE3173FFE84D3CD5B033F1065C5D7D3E5975D8CE29894BFDE3F5C37204E9BB83FD0AA0E3A66AAEE60198AAA2A4CB0933F3F2FF7CE3FBCF73F16A3CCA8853F927AA068A77720B88C3FEFF23FAF82E7938381EE6F55F84F3FCDA79FCB3F175D80643FF4CBE7F8D75D1805353F04E1942420D0C5308EDD1316F1BED191C1530DE953121B02C2C357DF67DF803F82C0B2CFF1CA43A1BEED693F7B05D69EFF745D27E092013F3FF6D377A1B74EBD4D866134EDE14F28C3C1E6F13F0F3FBD6E3F0200, '6.2.0-61023'),
	('201803071108467_initialCreate1', 'CarFactory', _binary 0x1F3F000000000004003F5D733F72EFA93F989A3F3F23C96BEFAE4B3FAD64EFE94EB6751E3F3F154542233FE484E4D85252F96579C84FCA5F08403F3F483F94F9240D017437D08D46036874FF3FFCEFE99F3FD1EC2B483F89CFE6C78BA33FC47E1284F1FA6CBECB1FFEF0F3FC4F7FFCC77F387D176C9E667FAFEABD42F5603F3B3FE6F9F6ED7299F98F60E3658B4DE8A7493F3F3F3F3F593F1DFDB23C3E5E0208620E61CD66A79F77711E6E403FFEBC48621F6CF39D177D480210653F2C591550671F3FC8B63FCEE6175EFADEF3F3247D5EBC8340F2E73F2CFC96A45FD8DFF3D979147A90C2153F3F2F8E93DCCB21FD6F7FCFC02A4F9378BDDA3F5E74FBBC05B0DE3F6500F7EB6D53DDB48B4727A88BCBA66105CADF6579B2B104783F8FD9926DDE6AE4E7F598C2512D070AF5BA18D9B3F9F92E08F3EB643D9FB1C8DE5E44293FEBDC6F17453D281A8BAA3F33F4F9DF413F2E92CD263FA885E4D5024AC9E2E887D9C52ECA7729388BC12E4FBDE887D9CDEE3E0AFDBF82E7DBE40B88CFE25D1491E4410261193F7EBA493F48F3E7CFE001137D15CC674BBADD926D583723DA94DDB98AF3373FCE671F21723F0235F789AEAFA09481DF400C522F07C18D97E7203F0C503F879DC1750B622F3F8CAF4E748DA0683F91EA262B907E0D7D807E54EDA074432ECD671FBCA76B10AFF3C7B3F9C93FF3D9FBF009043FDCE1DFE310CE773F4F774087EB033F93601054371E9AC8703F05AAE3A3931F1DE07A3F3FE2F96DD8F43F72BDFC3F3FB4CB5D8A672C250196E02E3F0ADCD53F085290A946E38D8BB128D169587C7CF2B30354BFA63F24EFF143D2BB38BD7B424B0C3F11A6A33F07A8AE36F05796C41E3F2D3FD9BC3F3F7438145FCF755F4F97CDD2A15C507EF5FC2F3FD9C5C15F92FB92BFEA95856A3FB8F6C542332D2E352E382C089582C1AF8F4F8CF86BA98D20E2F374ADD63FFEFC3F3F6B89FC367DBE80423FE37CFCC61ACA47F09443484E74FDB597C96169E679767EEFC54112835A6E7E4D3F783F15376998A485D460AE408B979E434D0DDBD527059EB395B100663F8DF53FA4640D3F2AF5423F2EE09C5B603F2B87F13F50FF03550A5DBF513AC7483FB4D2115A17EE944E35461AE3E047D3A5C5527A568F493F4CFAC27D9541ECDFBACE3FEC4037633F3F11B48A3BAB8C124C1BFBA468293F7A7509F7F8E1433FB48A298C563FB8424B365B2FEEA0CFCAF6D5DF493F78570ED19E14CACD235CF85DE0D51D42443F7907456F00343F3F44D7493FF35D30007FAEA1280F83695A395EF6CA3F1D3FF17B08166A3FC8F3423F07BADB6D3F74815B660B21246727BDB35F3F103F8660B5A22929D3AF12CCD87FF4BE86EBA2976280F3D9671015E5D963B8C53F87E1AE6E3F4D369F934836F255C5BB55B24B7D242F8949ED5B2F5D83BC3F3F1D37A9993E3FFD9E0D068DA5F0AA97F396CB30DB469ECE4A313CF99D361BD392413F076B455F8BC4F97D064B3F4B3F3CC16D75B4EFE85AC652F0FEEE453BE5855F4F7BA4C33F2503EDE63F28FC61D1D07F5E3F000C6566D15D3F029AB97EEDC5EB9D3FBAAE5D273F3F593F41FBC93F58173F25F76A8EF8CADB5B3777D2D03F33445467A367B29E5EB6F524D071B7E029EFAA27118C51EBCA43B49BAAC1DD8BCEAC4F0006363F3FB8D5383FDFFC747CF4F3CFFD2C1093CAD2A8AC8F495E0F8E89570E593F5BB0ADC7E593F33F0CEC5D453F6B743FBD4C273F978DAF8D1E1142A3E9A5A95791E6C2A8164C3FA993FBA91ADD799681CD7DF4FC3F5C83E114D7B9B2BAEC6E238AEDA5473F3F706E403F37152CC5B054414AAFAF57C7473F39193F3F3F2018106565520C826C3C2BC46A779FF969B8EDBE5AB090BE8395C39DF7FFDE97AC4997EF413FB69AF894AEBD186F6261B7B49B5EB27EB6605B4FDB5DC77AE4C64B01D3C860EB9228DD507E79BDBFF3C43FC8D3093FB7BB2A878E8BC7300AA0F00B3D3A58BD73D7D46E3FA495384F0E794D3F878AEA72BEF6417345899EE6AA77ADD63F906E3F2B3F6697C9BBFC3149AB6350AEF97491FC222F92AFB2DF52486B77857BD8D6119A6A1D6704023F84807A3FE649560E1B22CECE13CF7800112B3A0E20023F84800E6500ED777BE6FA384D829D3FCB953F70FBACFA677A47A0D0BF611EA974696F4F3F3F603F1DC0D3BF7A6866EDE8DBCBABAD4B3F7A3FED4FBEF73FD6A7CDBB5581C98FEBDC71751B835F5285DBA2C8EA75723347A06D56169965332D2AAA79571F98AB3F5D3D1273BF837889DE3FC45BDF855FD88307E57A72309B9607390CE1D280D4E61D55A959133F6E313F3F53117222A78EAAC4504794893F2BD852C7CA829C443F43275B414C2C57CBFAD8AF3F667262A94A0C9D44999844B2423F3FA6B66B7E3F1FF59ADFF3411E1A335413DF99EBBC069D44FB423CD9CB4ADECA3F1E9AEB9F81F7E4DAB897715AEDD2781F786F3FFB96A4AA7BEE9E0E3F265F24F143986E8A99A0B9987CE5C4EFBFEAEF6790817C108CD73F25D9E5EFE2003FBFE7BEADF173EEFB701EBC873F02362C56ABC3929A22273F3F171F779B7BB472483FFEEBE4D5063FCB4E3FAC80BF43EE72D0EEDF6C07E8C3EDB7A45C1A1D713F23E7920B78E77E1E7E055D3FC3E93A5987AD4CFE69D7F3F2763D3F6E3F70615757E58DF54B7C3F5FB2CC3FD7EDBF4AD8E23F5B2621ACC7FD5701543F62CBC4D4F53F2A20ABF65F3F62623BEFBF0A1DA490BBAA9CA5AEF82CA1A92C733F2C604B76826C999830DD4E50455D71642B3F173314155FC5B49445B6543F5505214D0D8696AA404C4E5DDA79875C689DB6F7D445E3C915528E6B6F2E3F671080DE6D3F93EE093F5407ED423F15BAB4ED6C2A1A4FB3E90067533FF8ED6B1828773F1D2F543F781D6B25EDBA5B5595B097B7A9933F9CACDBFBC88D4D511B3A3F67106B3F63E1DA116F125985C8763AD4DE533F00473FBED73F3F56DDC20288614C4F3C25F36D3F304514183FD4FE220A8C412F3F3C0822FB8DDAD7A167FF46592467038DEBEFC7FD4F83B4A7DD2AB49B633F330DE354686E27B9F05C5DF24DF7743F1DBBDC8E956A4F763FC69772C7F13FAEEF3F0A3F195F2AA3B1CB4D3F3F062F08334F97C8E8520592EF7C7B8771A8EE3F55643FDDE1599DA39DFB7E3FD3EE280D379F8E26E4B8F6769A569CEB87F1174B3D6AE0E3E8E64AC5D03D3FB2C989E6FB5B9CEDAFCFCEE1DCDE6C5B6B4312C6A412E5B85AA944A7BB193FC395D6FC3F7B5D9B4508D2DD804FD9AEBBE33F32E2815961BBC1C95BCCE6B2A8F46618EECCC64A73753B3F41984E3FF4422BC4D488773F7A660928D965598A6B1CA8F83FC7932DBE5398BC11EC4958267585E73F3F3003753F663F35F9553FF2D6594D937ADA50403271BAF34E7A1F2E3F48A367B84463563CE76C043F003F3F9BBECD67C5D5F6D93F37A454D55F41947CFB983F2FAA9BA0EC033F6C750D8AF3FBE42B60DA9C68503F5C3F36955FF3CC2DD9A860ADF872C88EB38A403FE2B07C2D6D103C2A3F5CED8A57590D97D43FD54BE366C0D575DFA56992D6955F3FBFF77282EF8269AAE5A4C860B4E323BDB0F1F03FE2B2E5A82597AEE2AF5E14063F3F3F90E6613F230B9D9BC149505DCB88592AC1463FCD54135E4A0528DFE8292D06A6684B3FC3CD7F3F8FBFC4C9B7F83F5AF9BD087BFFE2B63FABDBA2973FF8B4CBEB06BFE869253F4A286635B2D1BC9118AB5D543FA45B1D581A4C4AF6401B203055839FC9BA3FA3789E653F16DDA3AF4924097869E4EFE26066958DB7D95C48122717173F3B135C6ECEE6FFC2753F631D8195C3C83FA6FB04717C8A4B6370765E5C0123AF83CCF702DE5C3F1AD05FA0E90E5050D9D0433F510C3FCE793B3F8CFD70EB45363D6180186E17103F3AB6E4126C413F7D1B1E9AD0413FF0E4D45899B13FDDE99290553FCBA3F7CA84C920FC702348FC4E9396A8A3C5825FD94C70098456878B3FAD44503F01C44F3B2E26343431D8F72279373F72325990D41749DD4D155CD45C45CAA00BE4AC09777768DA51D3890104533F130AC8D09A7B114CF245B74C5C84CFBBE9E3C05EC5434C89405889479FBD6843C1400C2066824E9B60AD4E87F6285684E7919A3F2724B580A9D49BF4653FA6707D3F283C0583490B3FA046DA883E57DC9FE490FE604A2E0B5D3F4A8EC8976C583F503094E408063F35E3783FC9E19CE194AC96FBC5753F3FDDB03F23632869928D3F7E91473FE5AA0C3EA2663A1389647F261213F7843F9FE5F567223F3198B0513F87894406915172541851667F02268A5FC39073C3670CE94F3F3F94D80986621CB257060A52B2993F3F79A363143184943F3F2E6A143F2BAAC73F3FE09392957CF4A716263FA64042063F6C97863FB6DB072F265CC0741957E5D13FC69A4D7B05CCC16D72190503C88B6C40C7722C3FB3577259732CD04A72F67A2C20A360283FF1B18038C78092D5263FAD6468FF3F4A3286923F712CC0A58350725E3F1349534FF6B434130543CE503FD9F00C253FF76F552CB1BDC89EE069B78CDDAA773FC3AB081BE6FA4C3F7C306526A76100E1910FEC586C2AC1E37B0D3F76556B29DAAB6D25A76138291AB17DC58448D0705AE1F9D75A7AEC7DFB9C0BCFF04E79E2F13441BC6F2F3C593F0D974D8CF23F3FC35C43C870123542E3BC7C3FDBE4B045EDF4DC84FBBABC4765E049F4F60F92895D3FFC983F15041B9AC03F3F3F3F0A6B3FAEAA1EF5E23281BCD140E8C75202485485F2C18B0664E5492682D638F1E980249BAD178B6194455A1058BB8840D4CA5803827634164162BDC33500AFBD78BDF3D640C8B32D9ACC3F54D58CE1DD423F84795B483F2EF5CC40003F896D0170B5BBAF93D8EA8093753F3F3F04BCCB3F28B9B9E6C109F6A73A78A59F3F58E5443F81936B70EDCBFDBB3FD288A2C6E5C262D0B8CABC2384801D1F0DC05489548460B073800118D9583457721A203F6ECA52FEB53F3FAEAE11703940A3513FAC640355C7C7323F0EFFA2645F1D663F00A86EECD83A46233F99A804513D0E38B1E873CB8C3FD28C68A37A5724DEB55006A2D903A67A00043F6700D9BE552280373F7BE2478F923F3F3F46CFF03F3FFDDB19A2630269518C9BFEA93F3F3F7B3F183AA3A71F54EF743F88BE354B9A62B4743F08783FD9798C4A4F64BC64F1E34216CB69276A89FA8F975445E749003F93CBAAA31E93F13665DD961D3F48171CDCB618003F3F4A3FA082794A06407AE6C83F3A733F003F635F033FE4948C823F84EF84F408C47E3C3F1E3F0A363A654321F0AF15504D7BD8B63F3F3F00A86874D3636A3FE9B6F4FE3F5D7483683F00A28B3F723D216976330C783F19003F224F34ED8668DF69DA7B90698FE973D3D9C6EA93F4573FC793CC79C9D9F79A733F40C8AC3FFDE67C3F5D57FB7D51A44B3D3FEA852C5343E951BD71AE493F305BF4A40E4C3F30D0A227F6B0918D82C5A2A776C6B11F3F173D3F44361E664B80D489C47E14065D024441E8F981D03F88AE6C343A3FBC510C87C287A1073FC5BA3F8599AE505CCBB71B8A8134061B565F3A0CFAF319C9BD72BBEE0F733F8DDB2F1D060B9DA93F6D37307D683F3A617D6F57979D2E573FD878F8C33F56F1C136DF79112402445955F0C1DB6E3FD3B4C45F66ABADE7A30B3FACE6B3A74D146767F3C73CDFBE5D2E3F74B6D8847E9A64C943BEF093CD3F92E5C9D13FCBE3E3E5A684B1F42985CC3FD698A0EAF0D6802945776901781FA6593F6FDD7B28C8D445B0E13F6E292587AB15463F92E75E75CC5AB540FFB397A28BB2DA3F7EFF96A45FB8DFF56D267FF38BE1C2BAEB0DBA402EC285123F6F0A1BAF7C2FF2524174D28B24DA6D62F95DB6BC75136F9484D17C358754DD5A93706437D972282B907E0D7D9CFC3F451598C33F00F2C724E0C191DFCDA1DD7888C779315B4968E4777368EF9E80BF43B3BB0C654A02648A5AC0BC3F4A25709B6273D85C4873123257680B97E711F9DD1C1A159E9C044715D88C2852A08291AC3F9BC3BADAC05F59123F8CD43F94B73F9ED73F163F7C40CACC3FA7883FB4D325A3F558B5BBE4F42E3FB28ADC483F3F3DE97ADEDFC45E3FC0E847FB4374653C541244FDD10ACE79BACE3838E5478BD5283F7C71A94BAD46F55773481F3F00DBF19A952A3087873F213CAAC062AE66E7F75E1C24316019481658AC4C75F0696A5DAABF5ACC712A3F35CBA9124B886285A771E6DE9BEE686EF37A521BB2CB4C036D216FDA8F92A83F1668AAC4C2C87B4C52C17A4F7CB69948B0D937760E95DF2C28829819623F3674D4F1EE6952EACFE6B018E774129EC66F5D035338ADE9123B95C827AF6275235F3F06F1603F3FE47A527484DF6A5F7A0E3BBFB65073B2963D693F9D40C99105160B320ACACDACC63F9BCD79C4EE3FABAD0B0A62CE6C5BCA4F3F849B3F9BBC3F5E87F92E605544F3D9462F3F50F5D7496BABC66ED2DAA3D7DAACA7644FCA5B1C51DE5E95EB00F4A3D189D75A3F3F3F605D247159A38A3F89AB4F4D3F39FD6FC2E2603F39D1F03F43FF7F7A3F0BE6D2FDF9E7D1B0D5DD8935BFD63FF28584D020F0A7EF55A1B9533E25470F5FF770FA4248F8B0EAA2E5B252DFD4F6BB9EB4E0A2B4653F3AA6BB66802CDE469E603B41154C86AA1CE2643F925E6FA9519AF7A37D5D3F1EA1B6B8753781F2F2CD19E74ACB676F4D3F566A2FCC507E4F5EEFD53F252A3F293FA444CB47F3C329D25BCEA3AA40D842998A211DBA42ADA8E7F5215D6273CD543F3F4D3F73287F053F6FF161D85DEBA4585E8062A15FB0F7A4583FF0F61A450FA2A76D208157605D713F2B3DE74225739E5241A8F8C1436A4A2CCE4B6B7E3FD9B23650CFB30C6CEEA3E7BFEDBC08CD5A8157A6B63F5EEEF0B7FE6AE3925A65FFA6FD51ABAF3FB2CC5D5AFDD13F313F2010C2E30AED97CE4CBC763F754E0A561545680065CB8522EAA678F5E00EDD9E73E3A1DEDF3F29E049954855091F8BA52715C24515B2571B7A1087AE2A9AA4C7CC330F603F9FB07E2AE5973F613A053FA08502BC51BEF6763F71C346486C3F3F193F143FD6CAE6B714A2E5954DFDF97B3FEE566C71CE8911096C3F8284203F5140E17C2E2469370EC947CB82A148E846CD50EB9D16C7503F8CC28BE6A68A2CD8937460F86DE441D6B2A775283F4651E34F16EBC786E17AF1C14212533FBEF860FFF8895B1E88EF433F563F39E7D75F7D9BB6017288D336E090EC9F96DA5516F6CE3FD542AF8A9BF5A3542F417D0ACBCE0AA2609C9B053F1D2B94ABC2E7142EFE6A3F1FBC5D94F33F7F3F3FE2A4785F803F8354F5B8E369A178C5CDFA51BCE7BBFC11D250DD86093C793FEC764DBCEE6BBEEE433FEF45856F40E9922197893F3F20F5479B433F83D23FF2575F2D4709EE611FC27453303FF59754B1A73FC840CEC317145BA8CF3F92ECF2777170093FBFE7CC8A2928B698373F253F3F0804C15D043F4B694D9AD0493F3F6DF456FBE36E738FA20B52E34C16D8504A34C462C0D32BAE63E3AAE2EF90530A3470365BD65F3FB2A1FCF65B52EA713FF3E536D0C989C1C3664B6D20A35CBF5F010BB1FA6A675C1401CEC5760B51341981EA519C8C3F60044A333F3FCB845CEDCC4149DB43BF6973E39B54749E8FE8467CB68425701527BF4FB3C77AF648D375383F651EBA76B347D2F6FB983D45E7E1B7AF61C05A7D4C91851D89DB706F36A8828392D05E4F582B042DE573C893D643134FEB5BF24911CBC4BCEF3FEDAFEC473FE4C8B9BAF3E1D0F4B86D9AE33F0FF2C44D3FD77EF69B023A7465303D9C9BDE6DB87C383729B47A22F6ACC45A2B3F8FEA275778BEC0DF802A18D27AB9483FF8C5F5619E721E8F7C3F8EC3A7A3EBC91E1CA1FA44049DFB3EBA62ECF57403E368793F6D7D3F9F9BFD5F710619C65F4490AAEFFB70A8703F315D2A4E9A79D2CCCDE446F27E9EE760B3ED573D9388BA5C9248411CBAA2766DF4BA53FCE8BF4FA95CD5CAEAD8DC697E3F3F838CF35CAEBE0DA1AAF6A8560639FE63113F3F0373E8EAC58D3A101C3F69636B581C4EE55ECEBA90969F5EF894182C90880859CB6931FE80226E3F3B0E2C4451F97E3FDF9161CB65E366ABD4D8F197FA779D8D1B67C2A6527417E380126E17FDCF70566E36357659653EABDC49CEE61F9E57FF112D50F9A2F8B7B4413F1FA0843C802CBF4DBE80F86CFE7AF17A3E3B8F422F2B13A7E3A4DF6F3FA5AB17C7498ED33F64013F7E85B2808360B3649BDB3F47503F3F99C4119BEA5719385FF68CC5F8F6F2393FF8F7610437AB7755C5BB0FDEF39FBDAFA09CC4D5C546A3B5A85619FDF3123C84B12011C1E95F3F2B5195F47E060F3399EA395D3F4F053FF5F66C7E1FC24D0764633F7F0350CCE06215DC78701B92C63F283A329F7DDC4511723F3F7851C64D311643A3CC4A3C053F469EF2573F886ADED184DAC15891E9BD4B40F1572F3FBD743EFBE03D5D83783F9ECD4F5EBFB1054DA6FA760B994CFBAD807C7C74F2A32D68260178093D802CCF8B3F29F0C3AC9896473F17240117F2DE0818B76B520C3FEB612037503F3EF9D91632B597722B16446A7015E0A33F5BC8A2FCE05D663F1F786B45403FEFD473723D563F4DE6EC312B3F0DB762245F1F9FB4815BA6E52EE16E40103F390AD06EBD74D479B94B50D9C68BA2363A84CAC9CD3F6E5DBF8A03F07436FFAFA2F1DBD9D5BFDD1139B3EF08583F3FA5D0E0793B3B99FD77479549653F55C64633904CF78D052A4922273F46DDB6EC683F3F063FF173AB753FF39DAE5F8CB96F3F008DD54A9D625B67555615EF56D0842DB7493F297B515B744E7085EEFA9159058CA01329C25D83AEE2F09093D0963F67787B5B8AD86977A082B99EEB621FD0D7722EF59EF85A3F0C6EC6623F0D27D3D6EAB3B2DEA4CE9EE981EB47E5E084E016604D04B548123F264E1B3FAAC99EB10D5C22A9B86BC8758E71C780273FA9FE7E543F9B88563FD0D51D9D96EA900A536C0F845B94AE773A24767E486C7B866744177ED965713FDABDAB604D6E5C3F3F3F3FEB933FFAA4C0687DA0A3EF7662ACB12EABD2401BEA93C98C359E7DAFEC0F12A9A08CC6A7FED34678B286D4A07BB58644999EB557C77C9B816C1311E6493F6994D8CB709F6AD1D73FB6B80725336977D0B593C63FF6601ABB4827DD4277A276D3D6CEB916A5B361BBD5A655145D3F3FEA92B9D787FD66344A203F97EA93761954BBA81DEE8798D8EB5D18D8EFE7B8101A0A61FEC55E96491F1EB18788D11A4C053FF763313AFD60026B2827B3FD7D3F9E461F9D6964C2808D664E9555A88D8ECE1C752EE9AE123FA7EE0A90C84D3FD48BD1635CA6669DA9A46A3C567BA9955AEDCD19DAE0549655E977B486BBAB74C45D89A13EBBFDB18597977EF9E891E03FAD935ED3E93F3F613FF3DAD2E330BDEACCE3516B63EEBD9A4E033F063A5FE4D08EF170F18077C64DC270EBE5A06ADAE58EAE4C033F295FF776BCD966573E1D224EDBFC7E143F9F4A563F3F03A9646126E381700B93EE8E750370C0CB424FCAB34EA9DE41791E3FE7415561CFEDFC5ECA565D16D4D63F3F1E8BBF3F4E18AD559665BD519A8F3F3FCFB56B87F122F9B56BA045466CC7EECC647A6CBB49DAB494CD96A15EF35429B59D3371B272272B3F2BB7C88E6262600E68CB4E6B4233CD8804DDAA33BE566F7E3F4A0FCD45B4CAE2DDD16B09E7EF3E6C3F8385936ADFC9D27CD1CB81C148F2403A1DC2ED694531B1B5C8F6E67D345E8F8AF4DC263F039E6F8C723DEAEB2C439CB1DC58519B6E99FB585A1CAC78741459C7DE607DF4B9CE713F6C93F1DCF1919424E7B9927A6B076641E2733F04D9CF5D2E593FE8423F3445D8943F2C122AD5B9DCADD1CCCB5C9CDA3F754C42F3AEF4F1493F59846CDEF24EC0AA1C2D1D803039055C0AF064FE4EE6AF9CA4EFDC3FD3913FA645CDE9B2ED701CF2D47261181CB34EBCDE6D7D2293AE773F3F3F45B9C93F6A4E33EA453F2611BBE30D3F9994BDD386D04AA48DCEEDAB8A93403F3F3F3F003F633F75C79A9C914626FC4EAE9C3A3FC37416793FF66EDF913F49846E16CB8B6D3656A5B13F4CD3E3D2E971E9808F4B5F803F544CA3BC7BECC56ED96F3F2AD3A55B3F2D3FDB523EEFBB0A418B6C334E3FA67B8011D9923FC0B03F00555E7793531E5C7794ABC5E836BAB6CEF244223F3F3FA6ED71BEC887A52DAC713F4FDAFD3F293F3F3F3F633D1D18543F1F07DE55CDE93F0EED73035288F677E2A4F17765FE73694C92767E3F8E51F9713B6E3F91EFEB4043C84746796DAD88A65C92DCF55031C8FC194B2F2C7CD5C6C5C1D5E261A5F1AD4F86458DC6AAF947173F3FF46007DC91023F55A1E0B0BF3F15F4B55C3F7D3B713EAB9C90F53F29A6D5FCB40E80246A34E0AB3F103FF6DE2C3F03743F1DD3F63F3F3F2CC8A54FE299FC47553F9ABA777130433F442296923F3F16F5B70FD0A60851F06D4800ECF562713C6745FF535C8EFCECBC38D6460103323F3F81FD086444B0993F5A3F9AA47FE1D03F0850BCADD0434EFB599E7A7088F93FC67EB8F5226610987A3F1B75AE86C8965C3F88D17C15773F2371C5C223AEE133A3AD1B87D32521416AC1E254EAC5631841B3532E54FCA241703F143FCB56396C043F3F99E13F203CC2BE9BE06DC2D7ED45826E705419FCB74E3FE37193B599E06BF391E6674F3AE9A68A984390507FEB45A2C4C3D23F553D3141458680D98B3FAF7D0BC7F94C2A323F658257E587414485781E3F80BFF6222E4507071095A61F263F0B678F82D2985ADDA4453F3FDCE2233F427E1B2F2C8C5D3F3F374A13D7FB3F737D3FAEB3176813EBFB66BDE8CA728FFC473F876B143F6E0C01F8EBE865A6EC3F8C823F186E4769E9EF10E4868F6C4C6E3DF8D2510B10DF9F710812A2FE70154EF9FE90C15F7E1CB5B4D4DD188790609176A16AE4E688484B3F3F1A8D50BCE21D6ABFC9CDED1730AF8DE7F4213F0B6E0FB5CFFCAEB97D08FBCB82DB83EE2FBF6B3FCCBEB2E0BBC976C1885D2F7DBB60CCDFBD6C17AA900C7B1124FC527028F3A07ABF48403F8D5A83E04E8CC548C05C1FCA4C98B87E103FE6BA6B679BC3E1FB801E3216ACDFB7670C66FBA0563FE3F7652B968E78B04D0E5B80B47E3F80F7619AE5288CC5BD97018EFB3FB45A70FDF31D14DAEB041A648D631FE66353B4F21FC1C63B3FF7E81D423F787EBFAD2A6402F9A0B1FCEAF95FD669B28B83BF24F7A55F3D874E50478297AAA947DE78EA70383F11AAA6543FD96CBD5888A02A11C2AF0A35E059A7430E0B5B41326EB89A7EC4EA4580C354974850E0723D8AF32D3F85505F7BF17AE7AD814804453FA8AB0AAD703FCF5A4DF097353534A04A7A3AF8C7261C017C150966B2A21D663EABBB3FBEBA014564233D75BCCB2447115F4542055B518F5DB057E5D00BEA48F0935B772DE6CA9F8FC7579588B0D43FF0E53F0007BBFC2C21BFBC5FD2412E3F0E72F9590219159A41C65E6B42F0B84C3F3BEA99203FE14244B84C3F5FFE9B2092703F523FE3885C7475025B5F16E950C842A9711865152504F0D54D6991E2D6E032635A1D6943C8B7BA543F5CC74218EBB7E77299ACABE844135734C36EC05671350515762C15BFF61252613F3FF394103F6712499EB3CC8836B4A564F2FE453F3F84F8C66D2BE48F5688E66C117BAC4B77D86030E44F30040361F85E83EA8C8CF14577F842C5B088DF6758406B313CB2F70582C1317A8A407588DD3F9D90ED543F7ADABC281ACA6C07FB4E935EF1828E4A9DE6052712047D3F453F03A16E86BF3A3F716C2EED9DEC68DD4117393FB56A3FF274583F3FF2A1773F0D93F5507D6C76F0DDC4D6A7AC7302CF54075D3FE6BA19FEEAA6633F4A3FE9FD683F4AB782A5EEE44BDD74199BF892CE0A5C3F7092DC92D4ADCA8F6E3AD5EC2B243F7BA975EC9A886FEEB83F5C09FAA676CAEA3F8E6B3FC6F9163FD6D7B2D06BC74C3F037F9B43EEA2466BAABD4AECC9DCB33F3F083AADF380E8C84F3FA268537D72D541CD8CD45D3F7E0715FB69D59DB6930D3F003F513C4697B807C0C92A12487D0159979D2ECBE3173FFE84D3CD5B033F1065C5D7D3E5E75D8CE298943F41163F10A74D5C3F6855071D3355773F45551526D8C907907B81977BE7691E3E787E0E8B5166D4423F493D50B4D37B105CC59F76F9769757C1F3C9C140F7B72AFCA74B8EE6D34FE575878B2E40324314FAE553FCEB2E8C829AEEF782704A1210E86218C7EE098B78DFE8C8E0B9863F3F01E1E1ABEFB36FC1661B4160D9A778E5A150DFF6B44181BD066B3FBEA91370C9803F410FFBE965E8AD536F9361184D7B3FCA70B079FAE3FF032D777A383F0200, '6.2.0-61023');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
