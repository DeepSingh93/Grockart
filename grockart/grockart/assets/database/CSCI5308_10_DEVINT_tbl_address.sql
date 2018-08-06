-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: db-5308.cs.dal.ca    Database: CSCI5308_10_DEVINT
-- ------------------------------------------------------
-- Server version	5.5.5-10.0.35-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_address`
--

DROP TABLE IF EXISTS `tbl_address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_address` (
  `aID` int(11) NOT NULL AUTO_INCREMENT,
  `uid` int(11) NOT NULL,
  `addressName` varchar(255) NOT NULL,
  `streetName` varchar(255) NOT NULL,
  `appt` varchar(255) NOT NULL,
  `postalCode` varchar(6) NOT NULL,
  `phone` varchar(25) NOT NULL,
  `atID` int(11) NOT NULL,
  `cID` int(11) NOT NULL,
  PRIMARY KEY (`aID`),
  KEY `FK_tbl_login_uid_tbl_address_uid_idx` (`uid`),
  KEY `FK_tbl_Address_atid_tbl_address_type_atid_idx` (`atID`),
  KEY `FK_cityid_city_cityid_idx` (`cID`),
  CONSTRAINT `FK_tbl_login_uid_tbl_address_uid` FOREIGN KEY (`uid`) REFERENCES `tbl_Login` (`uID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_address_city_city` FOREIGN KEY (`cID`) REFERENCES `tbl_city` (`cID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_address`
--

LOCK TABLES `tbl_address` WRITE;
/*!40000 ALTER TABLE `tbl_address` DISABLE KEYS */;
INSERT INTO `tbl_address` VALUES (28,49,'Deep','1333 SPS ','PVA','B3J2K9','1234567890',1,2492),(29,39,'Tanishka Chaturvedi','1107','103','B3H 1R','9027895926',1,2492),(30,50,'Deep','1333 SPS ','PVA','B3J2K9','1234567890',2,581),(31,50,'Deep Singh','1333 South Park Street','Park Victoria Appt','B3J2K9','9029893222',1,1002),(32,50,'Deep Prakash Singh','1333 SOuth Park Street','Par Victoria Appt','B3J2K9','1234567890',1,27),(33,47,'Home','1333 South Park St','815','B3J 2K','9024149453',1,2411),(34,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411),(35,47,'ModifyTestAddress','321 St','321','2A2A2A','9876543210',2,2411),(36,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411),(37,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(38,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(39,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(44,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(45,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(47,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411),(48,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(50,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411),(51,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(53,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411),(54,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(56,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411),(57,47,'TestAddress1','123 St','123','1A1A1A','902123456',2,2411),(59,47,'TestAddress','123 St','123','1A1A1A','902123456',2,2411);
/*!40000 ALTER TABLE `tbl_address` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-03 18:54:21
