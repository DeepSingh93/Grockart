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
-- Table structure for table `tbl_product`
--

DROP TABLE IF EXISTS `tbl_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_product` (
  `pID` int(11) NOT NULL AUTO_INCREMENT,
  `productName` varchar(255) NOT NULL,
  `productImage` varchar(255) NOT NULL,
  PRIMARY KEY (`pID`)
) ENGINE=InnoDB AUTO_INCREMENT=167 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_product`
--

LOCK TABLES `tbl_product` WRITE;
/*!40000 ALTER TABLE `tbl_product` DISABLE KEYS */;
INSERT INTO `tbl_product` VALUES (21,'TEST_BISCUIT','images\\test.png'),(22,'Brownie','images\\brownie.png'),(23,'Cake','images\\cake.png'),(24,'Casserole','images\\casserole.png'),(25,'Cookie','images\\cookie.png'),(26,'Cracker','images\\cracker.png'),(27,'Custard','images\\custard.png'),(28,'Pastry','images\\pastry.png'),(29,'Pie','images\\pie.png'),(30,'Pudding','images\\pudding.png'),(31,'Tart','images\\tart.png'),(32,'Arepa','images\\arepa.png'),(33,'Bagel','images\\bagel.png'),(34,'Bammy','images\\bammy.png'),(35,'Breadstick','images\\breadstick.png'),(36,'Brown Bread','images\\brown_bread.png'),(37,'Canadian White','images\\canadian_white.png'),(38,'Chapati','images\\chapati.png'),(39,'Khakhra','images\\khakhra.png'),(40,'Kulcha','images\\kulcha.png'),(41,'Naan','images\\naan.png'),(42,'Papad','images\\papad.png'),(43,'Paratha','images\\paratha.png'),(44,'Pizza','images\\pizza.png'),(45,'Roti','images\\roti.png'),(46,'White Bread','images\\white_bread.png'),(47,'Black Tea','images\\black_tea.png'),(48,'Coca Cola','images\\coca_cola.png'),(49,'Coffee','images\\coffee.png'),(50,'Fanta','images\\fanta.png'),(51,'Frooti','images\\frooti.png'),(52,'Green Tea','images\\green_tea.png'),(53,'Limca','images\\limca.png'),(54,'Mirinda','images\\mirinda.png'),(55,'Mountain Dew','images\\mountain_dew.png'),(56,'Mazaa','images\\mazaa.png'),(57,'Pepsi','images\\pepsi.png'),(58,'Red Bull','images\\red_bull.png'),(59,'Sprite','images\\sprite.png'),(60,'Thumbs Up','images\\thumbs_up.png'),(61,'Soda','images\\soda.png'),(62,'Water','images\\water.png'),(63,'Butter','images\\butter.png'),(64,'Buttermilk','images\\buttermilk.png'),(65,'Chaas','images\\chaas.png'),(66,'Cheese','images\\cheese.png'),(67,'Cottage Cheese','images\\cottage_cheese.png'),(68,'Cream','images\\cream.png'),(69,'Curd','images\\curd.png'),(70,'Ghee','images\\ghee.png'),(71,'Ice Cream','images\\ice_cream.png'),(72,'Khoa','images\\khoa.png'),(73,'Kulfi','images\\kulfi.png'),(74,'Lassi','images\\lassi.png'),(75,'Malai','images\\malai.png'),(76,'Milk','images\\milk.png'),(77,'Yogurt','images\\yogurt.png'),(78,'Apple','images\\apple.png'),(79,'Avocado','images\\avocado.png'),(80,'Blackberry','images\\blackberry.png'),(81,'Banana','images\\banana.png'),(82,'Blueberry','images\\blueberry.png'),(83,'Date','images\\date.png'),(84,'Fig','images\\fig.png'),(85,'Grape','images\\grape.png'),(86,'Guava','images\\guava.png'),(87,'Jackfruit','images\\jackfruit.png'),(88,'Kiwifruit','images\\kiwifruit.png'),(89,'Lemon','images\\lemon.png'),(90,'Mango','images\\mango.png'),(91,'Orange','images\\orange.png'),(92,'Papaya','images\\papaya.png'),(93,'Pineapple','images\\pineapple.png'),(94,'Peach','images\\peach.png'),(95,'Plum','images\\plum.png'),(96,'Strawberry','images\\strawberry.png'),(97,'Vanilla','images\\vanilla.png'),(98,'Watermelon','images\\watermelon.png'),(99,'Beef','images\\beef.png'),(100,'Goat','images\\goat.png'),(101,'Ham','images\\ham.png'),(102,'Lamb','images\\lamb.png'),(103,'Mutton','images\\mutton.png'),(104,'Pork','images\\pork.png'),(105,'Chicken','images\\chicken.png'),(106,'Fish','images\\fish.png'),(107,'Broccoli','images\\broccoli.png'),(108,'Cabbage','images\\cabbage.png'),(109,'Cauliflower','images\\cauliflower.png'),(110,'Chickpea','images\\chickpea.png'),(111,'Onion','images\\onion.png'),(112,'Tomato','images\\tomato.png'),(113,'Radish','images\\radish.png'),(114,'Carrot','images\\carrot.png'),(115,'Potato','images\\potato.png'),(116,'Mushroom','images\\mushroom.png'),(117,'Spinach','images\\spinach.png'),(118,'Garlic','images\\garlic.png'),(119,'Ginger','images\\ginger.png'),(120,'Capsicum','images\\capsicum.png'),(121,'Turnip','images\\turnip.png'),(122,'Green Chilly','images\\green_chilly.png'),(123,'Lentil','images\\lentil.png'),(124,'Tinda','images\\tinda.png'),(125,'Pumpkin','images\\pumpkin.png'),(126,'Brinjal','images\\brinjal.png'),(127,'Cucumber','images\\cucumber.png'),(128,'Kidney Beans','images\\kidney_beans.png'),(147,'Test_Product','images	est.png'),(148,'Test_Product','images	est.png'),(149,'Test_Product','images	est.png'),(150,'Test_Product','images	est.png'),(151,'Test_Product','images	est.png'),(152,'Test_Product','images	est.png'),(153,'Test_Product','images	est.png'),(154,'Test_Product','images	est.png'),(155,'Test_Product','images	est.png'),(156,'Test_Product','images	est.png'),(157,'Test_Product','images	est.png'),(158,'Test_Product','images	est.png'),(159,'Test_Product','images	est.png'),(160,'Test_Product','images	est.png'),(161,'Test_Product','images	est.png'),(162,'Test_Product','images	est.png'),(163,'Test_Product','images	est.png'),(164,'Test_Product','images	est.png'),(165,'Test_Product','images	est.png'),(166,'Test_Product','images	est.png');
/*!40000 ALTER TABLE `tbl_product` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-03 18:54:14
