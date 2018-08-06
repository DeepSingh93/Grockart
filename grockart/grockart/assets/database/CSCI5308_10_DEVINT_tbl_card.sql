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
-- Table structure for table `tbl_card`
--

DROP TABLE IF EXISTS `tbl_card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_card` (
  `caID` int(11) NOT NULL AUTO_INCREMENT,
  `cardNameEncrypt` varchar(255) NOT NULL,
  `cardNumberEncrypt` varchar(255) NOT NULL,
  `expiryMonthEncrypt` varchar(255) NOT NULL,
  `expiryYearEncrypt` varchar(255) NOT NULL,
  `cvvEncrypt` varchar(255) NOT NULL,
  `ctID` int(11) NOT NULL,
  PRIMARY KEY (`caID`),
  KEY `fk_tbl_card_type_ctid_tbl_card_ctid_idx` (`ctID`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_card`
--

LOCK TABLES `tbl_card` WRITE;
/*!40000 ALTER TABLE `tbl_card` DISABLE KEYS */;
INSERT INTO `tbl_card` VALUES (5,'kcIEK4xc0Hqw1Pt+azMQ7Q==','z8/w9ZoO8s8FNyekrFI2zf9X30hc3zbBrI9UQePCafA=','bk+iVQQrM9pEoUMOu0sQrA==','SysWQWBm4yITnVOq06QT9A==','p+7i8MK9ncx3gf8gecXNfg==',1),(6,'wMQ/0RuUhBKYLUGdI68WRw==','UHwfjRYYPWZleDXm6nspwhIvxhEriCq17A53SLc21+0=','jYrewk5Z7h2eSM8tZNJjgg==','61Bwiou0fQoUDOFuQFljAg==','TDdPvDIdFz9kWTS5ad3a4A==',2),(7,'f3iQL6W96JvotDp3gB0wSA==','YIXx5pW2CpVg+UU6TGKvLkJFgA7DW7kQacRzevLTVWk=','Eh4gsuGd3YXM2shRRq3Dwg==','o52qyupLDiWlpkoW2AgAtw==','2XoEMlHC2Xis8smf5dz+EQ==',2),(8,'m3fKmkL4Z+dFYxqeBs6DLg==','Cc6fbpJHqQAz+/USrzvdJqVYTXuiP0dudxnv7nlTu/8=','TtFH/507m2rWAeSPedAtkA==','ITKsItUNRBkvxiVbqCV4jw==','j8xhSaGn/mzWSXIcBB3xBg==',2),(9,'pYLyLYV7q+dQ1NmQ4NiRJQ==','fZuu0f0vG5tqI1XGmjXsHNtjAF8d/iS5VIGOT7JirHo=','M8xJsJW0VZZS4NWwrfaGAg==','M8xJsJW0VZZS4NWwrfaGAg==','j1wEH4ndmB0FeZa6mZvQJA==',1),(10,'bm/7VKd+IRraNnhwDNRCaw==','93/7QZ6kQaxaO6ZlLW3yskSUHhSdeZX5ue1S0u7h840=','Vl3LzyJIefDC1kxVA/I3AQ==','AK/1cfxtKLs4pKQ9Z0ivtw==','GRqmC3QSQEdp0WZfbBYX4A==',1),(11,'BiH35JxOq0CxXa2cnvfMgg==','rlJTCl8HKr+D7WK1yx2YjN++nroPDOLqKALbCoRgOPI=','vLe70dkqjJWDX3vVThtrqA==','TnlM3WamqG6MtQxbjrWCCw==','YOlNwBT7guDZFK6msjkPBA==',1),(12,'TestUser1','EncryptedCardNumber','12','2019','123',2),(13,'TestUser','1128svcbi28y892bwhhdb29','11','2018','123',2),(15,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',2),(16,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(17,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(18,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(19,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(20,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(21,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(22,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(23,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(24,'TestUser','1128svcbi28y892bwhhdb29','11','2018','123',1),(25,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(26,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(27,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(28,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(29,'TestUser','1128svcbi28y892bwhhdb29','11','2018','123',1),(30,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(31,'TestUser','1128svcbi28y892bwhhdb29','11','2018','123',1),(32,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(33,'TestUser159608','1128svcbi28y892bwhhdb29','11','2018','123',2),(34,'TestUser1','1128svcbi28y892bwhhdb29','11','2018','123',1),(35,'TestUser1299593','1128svcbi28y892bwhhdb29','11','2018','123',2);
/*!40000 ALTER TABLE `tbl_card` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-03 18:54:18
