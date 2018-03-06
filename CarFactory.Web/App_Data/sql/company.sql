/*
Navicat MySQL Data Transfer

Source Server         : AsfMySql
Source Server Version : 100119
Source Host           : localhost:3306
Source Database       : asfdatabase

Target Server Type    : MYSQL
Target Server Version : 100119
File Encoding         : 65001

Date: 2018-03-06 13:09:52
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for company
-- ----------------------------
DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Tel` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Longitude` varchar(50) DEFAULT NULL,
  `Latitude` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of company
-- ----------------------------
INSERT INTO `company` VALUES ('1', '宁波澳昌科技有限公司', '13812345678', '0574-87623223', 'nbac@qq.com', '宁波市庄桥石材城', '121.543111', '29.945163');
