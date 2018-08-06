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
-- Table structure for table `tbl_card_decrypt`
--

DROP TABLE IF EXISTS `tbl_card_decrypt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_card_decrypt` (
  `dID` int(11) NOT NULL AUTO_INCREMENT,
  `DecryptionKey` varchar(255) NOT NULL,
  `salt` varchar(255) NOT NULL,
  `caID` int(11) NOT NULL,
  `uid` int(11) NOT NULL,
  PRIMARY KEY (`dID`),
  KEY `fkIdx_81` (`caID`),
  KEY `FK_tbl_card_decrypt_uid_tbl_login_uid_idx` (`uid`),
  CONSTRAINT `FK_81` FOREIGN KEY (`caID`) REFERENCES `tbl_card` (`caID`),
  CONSTRAINT `FK_tbl_card_decrypt_uid_tbl_login_uid` FOREIGN KEY (`uid`) REFERENCES `tbl_Login` (`uID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_card_decrypt`
--

LOCK TABLES `tbl_card_decrypt` WRITE;
/*!40000 ALTER TABLE `tbl_card_decrypt` DISABLE KEYS */;
INSERT INTO `tbl_card_decrypt` VALUES (5,'6fa/9faAnw1JJhcMhu1mRASN/XcQhfGIiwGOYdzrYk0=','EZJDLm7sh9awZ2Tg7gq42Q==',5,49),(6,'zZJDNUoJuufRpSz10q2GtrBUQGB7iUOJVfMERZ4UyWo=','olvnpDVxyF0Rg9dSWG9Raw==',6,49),(7,'HWvGhbo/xzWrTTCevNK5rn2mXAh7qmDN2zJcvJrRqA8=','mQL+Yl4HRCIcyZ+zmWdv8A==',7,49),(8,'bhjnqAQe0I8534bCYhj1rPcB48uhQ2bUHdRhn+6ijM8=','1eCARCe2UYgVnX3pacJW7Q==',8,49),(9,'thlBlCDp+zSi5PKQJ+aZAtRARA09oIDqJM0v/gDsETU=','eURG5xuV4LTu60Fq4rkaHA==',9,39),(10,'/1MHiq5RaF+M2N5S6sVu1zbT6nNKiVd3AiFVwM/FBeM=','3P3lqHgZegWkS4IZpOK1bQ==',10,50),(11,'PC+I96iAt1szGzYJvZvwkPoQwVCt5l26Q3ovu4NCwek=','8m+IFoYwOopLN3BUN0ckAA==',11,47),(12,'DecryptionKeyTest','SaltValueTest',12,47),(13,'DecryptionKey','SaltValue',15,47),(14,'DecryptionKey','SaltValue',15,47),(15,'DecryptionKey','SaltValue',15,47),(16,'DecryptionKey','SaltValue',15,47),(17,'DecryptionKey','SaltValue',13,47),(18,'DecryptionKey','SaltValue',15,47),(19,'DecryptionKey','SaltValue',13,47),(20,'DecryptionKey','SaltValue',15,47),(21,'DecryptionKey','SaltValue',33,47),(22,'DecryptionKey','SaltValue',15,47),(23,'DecryptionKey','SaltValue',35,47);
/*!40000 ALTER TABLE `tbl_card_decrypt` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-03 18:54:16
