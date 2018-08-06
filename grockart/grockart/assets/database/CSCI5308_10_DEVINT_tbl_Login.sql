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
-- Table structure for table `tbl_Login`
--

DROP TABLE IF EXISTS `tbl_Login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_Login` (
  `uID` int(11) NOT NULL AUTO_INCREMENT,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `roleID` int(11) NOT NULL,
  `firstName` varchar(255) NOT NULL,
  `lastName` varchar(255) NOT NULL,
  PRIMARY KEY (`uID`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `fkIdx_251` (`roleID`),
  CONSTRAINT `FK_251` FOREIGN KEY (`roleID`) REFERENCES `tbl_user_role` (`roleID`)
) ENGINE=InnoDB AUTO_INCREMENT=150 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_Login`
--

LOCK TABLES `tbl_Login` WRITE;
/*!40000 ALTER TABLE `tbl_Login` DISABLE KEYS */;
INSERT INTO `tbl_Login` VALUES (35,'93a17c642bf6f5cf718a96e77a8e34fb7d31513fc153a9cdba33061b856d7366','d@s.com',2,'D','S'),(36,'b6e6b9216cff0f4d2afe4fc3599e66ef65a05120a647d3011a1e04374d2cb318','deep.prakash.singh.3@gmail.com',2,'Deep','Singh'),(37,'e372268336b1f1eba3b6de544824d391b644877cff7fb682fec0d7da19d5947d','mm@123.com',1,'Mohit','Malik'),(38,'2a1eac3eb3774faf7b02c5007bb1aec94880def21f763275f46a67cc9012641b','a@a.com',2,'A','B'),(39,'ffd58ad7d5c0ddb9185f29b78a84e8f2c475f6ffe9bb956174afce386f85e577','Tanishkacs4061@gmail.com',2,'Tanishka','Chaturvedi'),(40,'f0a93e8e805108cf0d8d88f8f2eadc8650879a1c3b823290ab784cfbc96ac1bc','G@H.com',2,'G','H'),(41,'3f0506236bcb43474380a368f336347158d321b336a59e598443775ea26210df','dev.email@email.com',2,'Dev first','Dev last'),(42,'82b86d6e171a4261143531897d8bf1677303696b10ae6be6a2421b3cf1466987','Dpsc@live.in',2,'Deep','Singj'),(43,'3c47dc4473e11a063bf353248d4ab541b280eb6f5f2e0d7ad4623ea4b0b5ce1b','deep.prakash.singh.4@gmail.com',1,'Deep','Singh'),(44,'eca49a794754e3e187d1c540d9c96d0307717880b2f8315d30b4e4c81c114a9e','dev@dev.com',2,'DevFirstName001','DevLastName001'),(45,'8dd11e3fc0deeb30bb6bd08578c0c456e4d78fff5fe51fcd5831d26d1feb473a','mm1@abc.com',1,'Mohit','Malik'),(46,'64d98af14a3b3e24b1b1514cbed8340e323d5bf360de75fcca7115287d1598e9','deep@deep.com',2,'Deep','Singh'),(47,'fb6e852827282b640f2e431deb4e85de960700e4a78ee45bad4db1f75e1e0d58','mm2@abc.com',2,'Mohit','Malik'),(48,'b1e69c23307f4793bdf767e02f584cd58f016e8173d57411fbc32780aebe8494','deep1@deep.com',2,'deep','singh'),(49,'87d2cd1346842e64f33fcba36f6015486fb11368905ac5277894dc6a34d3c856','Demouser@demouser.com',2,'Demo','User'),(50,'e2a391d38d91c5d4be02105fb0e8a6a2cd8cbd7ff4086192858dac90ab9e0e65','demoadmin@demoadmin.com',1,'Demo','Admin'),(52,'852581e5787f85c41cee359c14677557b033f70d2cb6f90490f3ba63e2787843','deep+@abc.ocm',2,'Deep','Singh'),(77,'hashed_pwd','Demo_Test@Demo_Test.com',2,'Demo Name','Demo_Test_LastName'),(83,'f6787cde86fec8bf1c2cfcb24741aee6e55a073650cc324779e7bff729ac4ddc','deep.prakash.singh.5@gmail.com',2,'Deep','Singh'),(109,'2c6b6ed2a249e4dc1ac4feceec2c7e7ba6f0c596846495b7eb47c8a12febbae9','tn308771@dal.ca',2,'tan','chat'),(110,'144fd5e4b624175c21a96cd0a05e1efabca0c2e2ca9f698957d9195d6c93859e','mohitmalik@yahoo.com',1,'Mohit','Malik'),(111,'1565236867f9fcb16142720973f36e56133424ded061adfe6d3fce573b2d0d3b','meadmin@abc.com',1,'Mohit ','Malik'),(112,'f340bca40fc3d455951e2d8274615754e39175a54d41105872a294fe44902b80','tanishkacs@gmail.com',2,'tani','Chaturvedi'),(113,'6eb196e6bd5d58815033a1960d86f4e9c83f7696f5fd88a5a8c1bdd80514a1aa','tanishka123@gmail.com',2,'Tanishka','Chaturvedi');
/*!40000 ALTER TABLE `tbl_Login` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-03 18:54:20
