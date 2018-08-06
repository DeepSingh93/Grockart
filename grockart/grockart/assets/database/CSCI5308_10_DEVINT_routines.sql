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
-- Dumping routines for database 'CSCI5308_10_DEVINT'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddAddress` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddAddress`(
IN paramToken VARCHAR(255),
IN paramApt VARCHAR(255),
IN paramStreet VARCHAR(255),
IN paramPostal VARCHAR(255),
IN paramPhone VARCHAR(255),
IN paramAddressName VARCHAR(255),
IN paramCID INT
)
BEGIN

    INSERT INTO tbl_address (cid, uid,appt,streetName,postalCode,phone, addressName, atid)
    VALUES (paramCID,
    (SELECT uID FROM tbl_user_token WHERE token = paramToken LIMIT 1),paramApt,paramStreet,paramPostal,paramPhone, paramAddressName, (select atid from tbl_address_type where addressType = 'ACTIVE' LIMIT 1));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddAdmin`(
	IN paramEmail VARCHAR(255)
)
BEGIN
  
	UPDATE tbl_Login
    SET roleID = 
		(
			SELECT roleID FROM tbl_user_role WHERE roleName = 'ADMIN'
		)
	WHERE email = paramEmail;
    
    -- remove the tokens
    DELETE FROM tbl_user_token
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddCard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddCard`(
IN paramToken VARCHAR(255),
IN paramIV VARCHAR(255),
IN paramDecryptionKey VARCHAR(255),
IN paramCardName VARCHAR(255),
IN paramCardNum VARCHAR(255),
IN paramExpiryMonth VARCHAR(255),
IN paramExpiryYear VARCHAR(255),
IN paramCvvNum VARCHAR(255)
)
BEGIN

    INSERT INTO tbl_card (cardNameEncrypt,cardNumberEncrypt,expiryMonthEncrypt,expiryYearEncrypt,cvvEncrypt, ctid)
    VALUES (paramCardName,paramCardNum,paramExpiryMonth,paramExpiryYear,paramCvvNum, (select ctid FROM tbl_card_type WHERE cardType = 'ACTIVE' LIMIT 1 ));
    
    INSERT INTO tbl_card_decrypt (DecryptionKey,salt,caID,uid)
    VALUES (paramDecryptionKey,paramIV,(SELECT caID FROM tbl_card WHERE cardNameEncrypt = paramCardName && 
    cardNumberEncrypt = paramCardNum && expiryMonthEncrypt = paramExpiryMonth && expiryYearEncrypt = paramExpiryYear &&
    cvvEncrypt = paramCvvNum LIMIT 1), (SELECT uID FROM tbl_user_token WHERE token = paramToken LIMIT 1));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddCategory`(
IN paramCategoryName VARCHAR(255)
)
BEGIN

INSERT INTO tbl_category (categoryName)
    VALUES (paramCategoryName);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_addFPToken` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_addFPToken`(
IN paramFPToken VARCHAR(255),
IN paramEmail VARCHAR(255),
In paramTimeStamp DATETIME
)
BEGIN
	DECLARE _uid INT;
    SELECT uID 
    FROM tbl_Login
    WHERE email = paramEmail
    INTO _uid;
    INSERT INTO tbl_ForgotPassword_Tokens(uID, fpToken, dateTimeStamp)
    VALUES (_uid, paramFPToken, paramTimeStamp);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddOrder`(
IN paramToken VARCHAR(255),
IN paramStatusName VARCHAR(255),
IN paramOrderType VARCHAR(255),
IN paramOrderDate VARCHAR(255)
)
BEGIN

    INSERT INTO tbl_order (date,sID,uID,otID)
    VALUES (paramOrderDate,(SELECT sID FROM tbl_orderStatus WHERE statusName = paramStatusName),(SELECT uID FROM tbl_user_token WHERE token = paramToken),
    (SELECT otID FROM tbl_orderType WHERE otName = paramOrderType));
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddProduct` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddProduct`(
IN paramSID INT,
IN paramCID INT,
IN paramPID INT,
IN paramPrice DOUBLE,
IN paramQuantityPerUnit VARCHAR(255),
IN paramQuantity INT
)
BEGIN

    INSERT INTO tbl_productByStore (sID,cID,pID,price,QuantityPerUnit,Quantity)
    VALUES (paramSID,paramCID,paramPID,paramPrice,paramQuantityPerUnit,paramQuantity);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddProductOnly` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddProductOnly`(
IN paramProductName VARCHAR(255),
IN paramProductImage VARCHAR(255)
)
BEGIN

INSERT INTO tbl_product (productName, productImage)
    VALUES (paramProductName,paramProductImage);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddStore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_AddStore`(
IN paramStoreName VARCHAR(255),
IN paramStoreLogo VARCHAR(255)
)
BEGIN
INSERT INTO tbl_store (storeName,storeLogo)
    VALUES (paramStoreName,paramStoreLogo);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_addToken` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_addToken`(
	IN paramToken VARCHAR(255),
    IN paramEmail VARCHAR(255)    
)
BEGIN
	DECLARE _uid INT;
    
    SELECT uID 
    FROM tbl_Login
    WHERE email = paramEmail
    INTO _uid;
    
    INSERT INTO tbl_user_token (token, uID)
    VALUES (paramToken, _uid);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_authToken` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_authToken`(
    IN paramToken VARCHAR(255)
)
BEGIN
	
    SELECT COUNT(*)
    FROM tbl_user_token tk
    INNER JOIN tbl_Login tl
    ON tk.uID = tl.uID
    WHERE token = paramToken;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_cancelOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_cancelOrder`(
	IN paramOID INT,
    IN paramToken VARCHAR(255)
)
BEGIN

	DECLARE UidLocal INT;
    DECLARE OStID INT;
    
    SELECT uID FROM tbl_user_token 
    WHERE token = paramToken
    LIMIT 1
    INTO UidLocal;
    
    SELECT sID FROM tbl_orderStatus
    WHERE statusName = 'Cancelled'
    INTO OStID;
    
    UPDATE tbl_order
    SET sid = OStID
    WHERE oid = paramOID
    AND uid = UidLocal;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CreateOrderID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_CreateOrderID`(
    IN aID INT,
    IN caID INT,
    IN paramToken VARCHAR(255)
)
BEGIN
	
    DECLARE ostIDLocal INT;
    DECLARE orderTime DATETIME;
    DECLARE orderIDLocal INT;
    DECLARE otIDLocal INT;
    DECLARE uIDLocal INT;
    
    SELECT NOW() INTO orderTime;
    SELECT sID FROM tbl_orderStatus WHERE statusName = 'Order_Created' INTO ostIDLocal;
    SELECT otID FROM tbl_orderType WHERE otName = 'Individual' INTO otIDLocal;
    SELECT uid FROM tbl_user_token WHERE token = paramToken LIMIT 1 into uIDLocal;
    
    INSERT INTO tbl_order (date, sID, uID, otID, aID, caID)
    VALUES (orderTime, ostIDLocal, uIDLocal, otIDLocal, aID, caID);
    
     SELECT LAST_INSERT_ID() 'OrderID';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchAddress` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchAddress`(
IN paramToken VARCHAR(255)
)
BEGIN
SELECT aid, addressName, streetName, appt, postalcode, phone, city, province, tbl_city.cid
FROM tbl_address 
INNER JOIN tbl_city
ON tbl_address.cID = tbl_city.cID
INNER JOIN tbl_address_type
ON tbl_address.atID = tbl_address_type.atID
WHERE uid = (SELECT uID FROM tbl_user_token WHERE token = paramToken LIMIT 1)
and tbl_address_type.addressType = 'ACTIVE' ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchAllSettings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchAllSettings`()
BEGIN
	SELECT setting_key, setting_value
    FROM tbl_settings;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchCardDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchCardDetails`(
	IN paramToken VARCHAR(255)
)
BEGIN

DECLARE ctIDLocal INT;

SELECT ctid FROM
tbl_card_type
WHERE cardType = 'ACTIVE'
LIMIT 1
into ctIDLocal;

SELECT ca.caID, CardNameEncrypt, CardNumberEncrypt, ExpiryMonthEncrypt, ExpiryYearEncrypt, CvvEncrypt, DecryptionKey, Salt
FROM tbl_card ca 
INNER JOIN tbl_card_decrypt crd
ON ca.caid = crd.caID
WHERE uid = (SELECT uid FROM tbl_user_token WHERE token = paramToken LIMIT 1)
AND ctID = ctIDLocal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchCategory`()
BEGIN
	
  SELECT cID, categoryName
  FROM tbl_category;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchOrder`(
	IN paramOrderID INT
)
BEGIN
SELECT oID, sID, date, statusName, oTypeName
FROM tbl_order
INNER JOIN tbl_orderStatus
ON tbl_order.sID = tbl_orderStatus.sID
INNER JOIN tbl_orderType
ON tbl_order.otID = tbl_orderType.otID
WHERE oID = paramOrderID
order by oid desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchOrderDetailsByType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchOrderDetailsByType`(
	IN paramToken VARCHAR(255),
    IN paramOrderType VARCHAR(255)
)
BEGIN
	SELECT tbl_order.oId,tbl_order.date,tbl_orderStatus.statusName, sum(((price + taxAmount) * quantity)) AS Amount, sum(quantity) AS Items FROM tbl_order
	INNER JOIN tbl_orderDetails 
	ON tbl_order.oid = tbl_orderDetails.oid
	INNER JOIN tbl_orderStatus
	ON tbl_order.sID = tbl_orderStatus.sID
	INNER JOIN tbl_orderType
	ON tbl_order.otid = tbl_orderType.otid
	INNER JOIN tbl_user_token
	ON tbl_order.uid = tbl_user_token.uid
	WHERE tbl_user_token.token = paramToken
	AND tbl_orderType.otname = paramOrderType
	GROUP BY tbl_order.oID;

	SELECT distinct tbl_order.oId, storeLogo FROM tbl_order
	INNER JOIN tbl_orderDetails 
	ON tbl_order.oid = tbl_orderDetails.oid
	INNER JOIN tbl_orderStatus
	ON tbl_order.sID = tbl_orderStatus.sID
	INNER JOIN tbl_orderType
	ON tbl_order.otid = tbl_orderType.otid
	INNER JOIN tbl_user_token
	ON tbl_order.uid = tbl_user_token.uid
	INNER JOIN tbl_productByStore 
	ON tbl_productByStore.pbsID = tbl_orderDetails.pbsID
	INNER JOIN tbl_store
	ON tbl_store.sID = tbl_productByStore.sID
	WHERE tbl_user_token.token = paramToken
	AND tbl_orderType.otname = paramOrderType;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchOrderDetailsByTypeAndStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchOrderDetailsByTypeAndStatus`(
	IN paramToken VARCHAR(255),
    IN paramOrderType VARCHAR(255),
    IN paramStatus VARCHAR(255)
)
BEGIN
	SELECT tbl_order.oId,tbl_orderStatus.statusName, sum(price * quantity) AS Amount, sum(quantity) AS Items FROM tbl_order
	INNER JOIN tbl_orderDetails 
	ON tbl_order.oid = tbl_orderDetails.oid
	INNER JOIN tbl_orderStatus
	ON tbl_order.sID = tbl_orderStatus.sID
	INNER JOIN tbl_orderType
	ON tbl_order.otid = tbl_orderType.otid
	INNER JOIN tbl_user_token
	ON tbl_order.uid = tbl_user_token.uid
	WHERE tbl_user_token.token = paramToken
	AND tbl_orderStatus.statusName = paramStatus
	AND tbl_orderType.otname = paramOrderType
	GROUP BY tbl_order.oID;

	SELECT distinct tbl_order.oId, storeLogo FROM tbl_order
	INNER JOIN tbl_orderDetails 
	ON tbl_order.oid = tbl_orderDetails.oid
	INNER JOIN tbl_orderStatus
	ON tbl_order.sID = tbl_orderStatus.sID
	INNER JOIN tbl_orderType
	ON tbl_order.otid = tbl_orderType.otid
	INNER JOIN tbl_user_token
	ON tbl_order.uid = tbl_user_token.uid
	INNER JOIN tbl_productByStore 
	ON tbl_productByStore.pbsID = tbl_orderDetails.pbsID
	INNER JOIN tbl_store
	ON tbl_store.sID = tbl_productByStore.sID
	WHERE tbl_user_token.token = paramToken
	AND tbl_orderStatus.statusName = paramStatus
	AND tbl_orderType.otname = paramOrderType;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchOtherStoresThanLowestProductStoreByPBSID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchOtherStoresThanLowestProductStoreByPBSID`(
	IN paramPBSID INT
)
BEGIN
	SELECT  storeLogo, price, QuantityPerUnit, pbsid, Quantity  FROM tbl_productByStore
	INNER JOIN tbl_store
	ON tbl_productByStore.sID = tbl_store.sID
	WHERE tbl_productByStore.pid =  (select pid from tbl_productByStore where pbsid = paramPBSID) 
	AND pbsid <> paramPBSID
    AND Quantity > -1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchProductByPBSID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchProductByPBSID`(
	IN paramPBSID INT
)
BEGIN
	select 
		pbsid,
		categoryName,
		productName,
		quantityperunit, 
		productImage, 
		price,
		quantity,
		storeLogo
	from tbl_productByStore pbs3
	INNER JOIN tbl_category c
	ON pbs3.cID = c.cID
	INNER JOIN tbl_product p
	ON pbs3.pID = p.pID
	INNER JOIN tbl_store s
	ON pbs3.sid = s.sid 
	where pbsid = paramPBSID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchProductByStore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchProductByStore`()
BEGIN
SELECT
	tbl_productByStore.pbsID, 
    tbl_productByStore.sID,
    storeName,
    tbl_productByStore.cID, 
    categoryName, 
    tbl_productByStore.pID, 
    productName,
    price,
    QuantityPerUnit, 
    Quantity
FROM tbl_productByStore
INNER JOIN tbl_store
ON tbl_productByStore.sID = tbl_store.sID
INNER JOIN tbl_category
ON tbl_productByStore.cID = tbl_category.cID 
INNER JOIN tbl_product
ON tbl_product.pID = tbl_productByStore.pID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchProductImageFromProductByStoreTable` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchProductImageFromProductByStoreTable`(
	IN paramPBSID INT
)
BEGIN
	SELECT productImage FROM tbl_productByStore
	INNER JOIN tbl_product
	ON tbl_productByStore.pID = tbl_product.pID
	WHERE tbl_productByStore.pbsid = paramPBSID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchProductOnly` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchProductOnly`()
BEGIN
	
  SELECT pID, productName, productImage
  FROM tbl_product;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_fetchProducts` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_fetchProducts`()
BEGIN
select 
	pbsid,
    categoryName,
    productName,
    quantityperunit, 
    productImage, 
    price,
    quantity,
    storeLogo
from tbl_productByStore pbs3
INNER JOIN tbl_category c
ON pbs3.cID = c.cID
INNER JOIN tbl_product p
ON pbs3.pID = p.pID
INNER JOIN tbl_store s
ON pbs3.sid = s.sid 
where pbsid in (
	select (select pbsid from tbl_productByStore pbs1 where pbs1.cid = pbs.cid and pbs1.pid = pbs.pid and quantity > 0 order by price asc limit 1) 'pbsid' from tbl_productByStore pbs
	group by cid, pid
);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchProductsByID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchProductsByID`(
	IN paramProductID INT
)
BEGIN
	select 
		pbsid,
		categoryName,
		productName,
		quantityperunit, 
		productImage, 
		price,
        storeLogo,
		quantity
	FROM 
		tbl_productByStore pbs
	INNER JOIN 
		tbl_category c
	ON pbs.cID = c.cID
	INNER JOIN 
		tbl_product p
	ON pbs.pID = p.pID
    INNER JOIN 
		tbl_store s
	ON s.sID = pbs.sID
	WHERE quantity > -1
    AND pbsid = paramProductID; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchProductsByQuery` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchProductsByQuery`(
	IN paramQuery VARCHAR(255)
)
BEGIN
SELECT * FROM
(
select 
	pbsid,
    categoryName,
    productName,
    quantityperunit, 
    productImage, 
    price,
    quantity,
    storeLogo
from tbl_productByStore pbs3
INNER JOIN tbl_category c
ON pbs3.cID = c.cID
INNER JOIN tbl_product p
ON pbs3.pID = p.pID
INNER JOIN tbl_store s
ON pbs3.sid = s.sid 
where pbsid in (
	select (select pbsid from tbl_productByStore pbs1 where pbs1.cid = pbs.cid and pbs1.pid = pbs.pid and quantity > 0 order by price asc limit 1) 'pbsid' from tbl_productByStore pbs
	group by cid, pid
)
) a
WHERE categoryName REGEXP paramQuery OR productName REGEXP paramQuery; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchSettings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchSettings`(
    IN paramSettingKey VARCHAR(255)
)
BEGIN
	SELECT setting_value
    FROM tbl_settings
    WHERE setting_key = paramSettingKey;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchStoreLogoFromPBSID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchStoreLogoFromPBSID`(
	IN paramPBSID INT
)
BEGIN
	SELECT storeLogo FROM tbl_store
	INNER JOIN tbl_productByStore 
	ON tbl_productByStore.sID = tbl_store.sID
	WHERE tbl_productByStore.pbsID = paramPBSID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchStores` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchStores`()
BEGIN
	SELECT sID, storeName, storeLogo
    FROM tbl_store;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FetchTaxDetailsByAddressID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_FetchTaxDetailsByAddressID`(
	IN paramAddressID INT
)
BEGIN

SELECT tax,tax_type
FROM tbl_city INNER JOIN
tbl_address ON tbl_city.cID = tbl_address.cID
WHERE aid = paramAddressID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAdminList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_GetAdminList`(
	IN paramToken VARCHAR(255)
)
BEGIN
  
	SELECT firstName, lastName, email
	FROM tbl_Login
	INNER JOIN tbl_user_role
	ON tbl_Login.roleID = tbl_user_role.roleID
	WHERE roleName = 'ADMIN'
	AND uid <> (
		SELECT uid 
		FROM tbl_user_token
		WHERE token = paramToken
	);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getDBVersion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getDBVersion`()
BEGIN
	SELECT setting_value FROM tbl_settings WHERE setting_key = 'version';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getivkey` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getivkey`()
BEGIN
	
    select 
	(select setting_value from tbl_settings where setting_key = 'SETTING_CORE_IV') 'IV',
	(select setting_value from tbl_settings where setting_key = 'SETTING_CORE_Key') 'KEY';
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getMenu` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getMenu`(
	
)
BEGIN
     select 
		pbsid,
		categoryName,
		productName,
		productImage
	from tbl_productByStore pbs3
	INNER JOIN tbl_category c
	ON pbs3.cID = c.cID
	INNER JOIN tbl_product p
	ON pbs3.pID = p.pID
	INNER JOIN tbl_store s
	ON pbs3.sid = s.sid 
	where pbsid in (
		select (select pbsid from tbl_productByStore pbs1 where pbs1.cid = pbs.cid and pbs1.pid = pbs.pid and quantity > 0 order by price asc limit 1) 'pbsid' from tbl_productByStore pbs
		group by cid, pid
	);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetOrderDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_GetOrderDetails`(
	IN paramOID INT,
    IN paramToken VARCHAR(255)
)
BEGIN

	
    DECLARE uidLocal INT;
    DECLARE OIDLocal INT;
    DECLARE aidLocal INT;
    DECLARE caIDLocal INT;
    
    SELECT uID FROM tbl_user_token
    WHERE token = paramToken
    INTO uidLocal;

    SELECT oID FROM tbl_order
    WHERE oid = paramOID AND uID = uidLocal
    INTO OIDLocal;
    
	SELECT date, statusName, caID
    FROM tbl_order INNER JOIN tbl_orderStatus
    ON tbl_order.sID = tbl_orderStatus.sID
    AND oID = OIDLocal;
    
    SELECT aID FROM tbl_order WHERE oID = OIDLocal INTO aidLocal;
    
    SELECT addressName, streetName, appt, postalCode, phone, city, province
    FROM tbl_address 
    INNER JOIN tbl_city
    ON tbl_address.cID = tbl_city.cID
    and aID = aidLocal;
    
    SELECT storeLogo, productName, productImage, tbl_orderDetails.quantity, tbl_orderDetails.quantity*tbl_orderDetails.price 'preTaxProductPrice', ((tbl_orderDetails.price * tbl_orderDetails.quantity) + taxAmount) 'PostTaxProductPrice',taxAmount
    FROM tbl_orderDetails
    INNER JOIN 
    tbl_productByStore
    ON tbl_orderDetails.pbsId = tbl_productByStore.pbsId
    INNER JOIN 
    tbl_product
    ON tbl_product.pID = tbl_productByStore.pID
    INNER JOIN tbl_store
    ON tbl_store.sID = tbl_productByStore.sID
    WHERE oID = OIDLocal;
    
	SELECT count(tbl_orderDetails.quantity) 'TotalUniqueQuantity', SUM(tbl_orderDetails.quantity) 'TotalQuantity', SUM(tbl_orderDetails.quantity*tbl_orderDetails.price) 'TotalPreTaxProductPrice', SUM((tbl_orderDetails.price * tbl_orderDetails.quantity) + taxAmount) 'TotalPostTaxProductPrice', SUM(taxAmount) 'TotalTaxAmount'
    FROM tbl_orderDetails
    WHERE oID = OIDLocal;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getProvinceList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getProvinceList`()
BEGIN

	SELECT cid, city, province 
    FROM tbl_city
    ORDER BY province ASC;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getSaltPass` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getSaltPass`(
	IN paramEmail VARCHAR(255)
)
BEGIN
	
    SELECT password, salt 
    FROM tbl_Login tl 
    INNER JOIN tbl_pswd_salt slt
	ON tl.uID = slt.uID
	WHERE email = paramEmail;	 
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getToken` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getToken`(
	IN paramEmail VARCHAR(255)
)
BEGIN
	
    SELECT token
    FROM tbl_user_token tk
    INNER JOIN tbl_Login tl
    ON tk.uID = tl.uID
    WHERE LOWER(email) = LOWER(paramEmail);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getUserProfile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_getUserProfile`(
	IN paramToken VARCHAR(255)
)
BEGIN
	
	SELECT 
		firstname, 
        lastname, 
        email, 
        roleName
        
	FROM tbl_Login tl
    INNER JOIN tbl_user_token tk
    ON tl.uID = tk.uID
    INNER JOIN tbl_user_role ur
	ON ur.roleID = tl.roleID	 
	WHERE tk.token = paramToken;
     
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertOrderByRow` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_insertOrderByRow`(
	IN paramoID INT,
    IN parampbsID INT,
    IN paramQuantity INT,
    IN paramPrice DOUBLE,
    IN paramTaxAmount DOUBLE
)
BEGIN
	INSERT INTO tbl_orderDetails(oID, pbsId, quantity, price, taxAmount)
    VALUES (paramoID, parampbsID, paramQuantity, paramPrice, paramTaxAmount);
    
    UPDATE tbl_productByStore SET Quantity = (Quantity - paramQuantity)
    WHERE pbsId = parampbsID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyAddress` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyAddress`(
IN paramAID INT,
IN paramToken VARCHAR(255),
IN paramCity VARCHAR(255),
IN paramAddressName VARCHAR(255),
IN paramProvince VARCHAR(255),
IN paramApt VARCHAR(255),
IN paramStreet VARCHAR(255),
IN paramPostal VARCHAR(255),
IN paramPhone VARCHAR(255)
)
BEGIN

UPDATE tbl_address
SET appt = paramApt,
    addressName = paramAddressName,
    streetName = paramStreet,
    postalCode = paramPostal,
    cID = (SELECT cID FROM tbl_city WHERE city = paramCity && province = paramProvince),
    phone = paramPhone,
    uid = (SELECT uID FROM tbl_user_token WHERE token = paramToken)
WHERE aID = paramAID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyCard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyCard`(
IN paramToken VARCHAR(255),
IN paramIV VARCHAR(255),
IN paramDecryptionKey VARCHAR(255),
IN paramCaID INT,
IN paramCardName VARCHAR(255),
IN paramCardNum VARCHAR(255),
IN paramExpiryMonth VARCHAR(255),
IN paramExpiryYear VARCHAR(255),
IN paramCvvNum VARCHAR(255)
)
BEGIN

UPDATE tbl_card
SET cardNameEncrypt = paramCardName,
    cardNumberEncrypt = paramCardNum,
    expiryMonthEncrypt = paramExpiryMonth,
    expiryYearEncrypt = paramExpiryYear,
    cvvEncrypt = paramCvvNum
WHERE caID = paramCaID;

UPDATE tbl_card_decrypt
SET DecryptionKey = paramDecryptionKey,
    salt = paramIV,
    uid = (SELECT uID FROM tbl_user_token WHERE token = paramToken)
WHERE caID = paramCaID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyCategory`(
IN paramCID INT,
IN paramCategoryNewName VARCHAR(255)
)
BEGIN

UPDATE tbl_category
SET categoryName = paramCategoryNewName
WHERE cID = paramCID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyOrder`(
IN paramOrderID INT,
IN paramToken VARCHAR(255),
IN paramStatusName VARCHAR(255),
IN paramOrderType VARCHAR(255),
IN paramOrderDate VARCHAR(255)
)
BEGIN

UPDATE tbl_order
SET date = paramOrderDate,
    sID = (SELECT sID FROM tbl_orderStatus WHERE statusName = paramStatusName),
    otID = (SELECT otID FROM tbl_orderType WHERE otName = paramOrderType),
    uid = (SELECT uID FROM tbl_user_token WHERE token = paramToken)
WHERE oID = paramOrderID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyProduct` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyProduct`(
IN paramSID INT,
IN paramCID INT,
IN paramPbsID INT,
IN paramPID INT,
IN paramPrice DOUBLE,
IN paramQuantityPerUnit VARCHAR(255),
IN paramQuantity INT
)
BEGIN

UPDATE tbl_productByStore
SET sID = paramSID,
    cID = paramCID,
    pID = paramPID,
    price = paramPrice,
    QuantityPerUnit = paramQuantityPerUnit,
    Quantity = paramQuantity
WHERE pbsId = paramPbsID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyProductOnly` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyProductOnly`(
IN paramPID INT,
IN paramProductNewName VARCHAR(255),
IN paramProductNewImage VARCHAR(255)
)
BEGIN

UPDATE tbl_product
SET productName = paramProductNewName,
    productImage = paramProductNewImage
WHERE pID = paramPID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ModifyStore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_ModifyStore`(
IN paramSID INT,
IN paramStoreNewName VARCHAR(255),
IN paramStoreNewLogo VARCHAR(255)
)
BEGIN
UPDATE tbl_store
SET storeName = paramStoreNewName,
	storeLogo = paramStoreNewLogo
WHERE sID = paramSID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registerUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_registerUser`(
	IN paramFirstName VARCHAR(255),
    IN paramLastName VARCHAR(255),
    IN paramEmail VARCHAR(255),
    IN paramPwd VARCHAR(255),
    IN paramSalt VARCHAR(255),
    IN paramToken VARCHAR(255),
    IN paramRoleType VARCHAR(45)
)
BEGIN
	
    DECLARE _uid INT;
    DECLARE role INT;
  
 
	SELECT roleID 
	FROM tbl_user_role 
	WHERE roleName = paramRoleType
	INTO role;
	
	-- the email is unique
	-- add the email to the table
	INSERT INTO tbl_Login (password, email, roleID, firstName, lastName)
	VALUES (paramPwd, paramEmail, role, paramFirstName, paramLastName);
	
	-- now we have inserted the rows, now we can get the uid 
	SELECT uid FROM tbl_Login
	WHERE email = paramEmail
	INTO _uid;
	
	-- insert the token
	INSERT INTO tbl_user_token (token, uID)
	VALUES (paramToken, _uid);
	
	-- now insert the salt
	INSERT INTO tbl_pswd_salt (uID, salt)
	VALUES (_uid, paramSalt);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveAddress` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveAddress`(
	IN paramAID INT,
    IN paramToken VARCHAR(255)
)
BEGIN
DECLARE atidLocal INT;
DECLARE uidLocal INT;

SELECT atid 
FROM tbl_address_type
WHERE addressType = 'DELETED'
INTO atidLocal;

SELECT uID 
FROM tbl_user_token 
WHERE token = paramToken
INTO uidLocal;

UPDATE tbl_address set atid = atidLocal WHERE aid = paramAID AND uid = uidLocal;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveAdmin`(
	IN paramEmail VARCHAR(255)
)
BEGIN
  
	UPDATE tbl_Login
    SET roleID = 
		(
			SELECT roleID FROM tbl_user_role WHERE roleName = 'NORMAL'
		)
	WHERE email = paramEmail;
    
    -- remove the tokens
    DELETE FROM tbl_user_token
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveCard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveCard`(
	IN paramToken VARCHAR(255),
    IN cardID INT
)
BEGIN

	DECLARE uidLocal INT;
    DECLARE cidLocal INT;
    DECLARE statusID INT;
    
    SELECT ctID 
    FROM tbl_card_type 
    WHERE cardType = 'DELETED'
    INTO statusID;
    
    SELECT uID FROM tbl_user_token
    WHERE token = paramToken
    LIMIT 1
    INTO uidLocal;
    
    -- just to verify correct user is deleting the card
    SELECT tbl_card.caID FROM tbl_card
    INNER JOIN tbl_card_decrypt
    ON tbl_card.caID = tbl_card_decrypt.caID
    WHERE tbl_card_decrypt.uid = uidLocal
    AND tbl_card.caID = CardID
    INTO cidLocal;
    
    UPDATE tbl_card SET ctID = statusID WHERE caID = cidLocal;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveCategory`(
IN paramCID INT
)
BEGIN
DELETE FROM
   tbl_category
   WHERE cID =  paramCID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveOrder` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveOrder`(
IN paramOID INT
)
BEGIN
DELETE FROM
   tbl_order
   WHERE oID =  paramOID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveProduct` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveProduct`(
IN paramPbsID INT
)
BEGIN
DELETE FROM
   tbl_productByStore
   WHERE pbsId =  paramPbsID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveProductOnly` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveProductOnly`(
IN paramPID INT
)
BEGIN
DELETE FROM
   tbl_product
   WHERE pID =  paramPID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveSettings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveSettings`(
    IN paramSettingKey VARCHAR(255)
)
BEGIN
	DELETE FROM tbl_settings
    WHERE setting_key = paramSettingKey;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveStore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveStore`(
IN paramSID INT
)
BEGIN
DELETE FROM
   tbl_store
   WHERE sID =  paramSID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_removeToken` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_removeToken`(
	IN paramToken VARCHAR(255)
)
BEGIN
	
   DELETE FROM
   tbl_user_token
   WHERE token =  paramToken;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RemoveUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_RemoveUser`(
    IN paramEmail VARCHAR(255)
)
BEGIN
	DECLARE localUID INT;
    SELECT uID FROM tbl_Login
    WHERE email = paramEmail
    INTO localUID;
    
	-- delete the tokens
    DELETE FROM tbl_user_token
    WHERE uID = localUID;
    
    -- remove the salt
    DELETE FROM tbl_pswd_salt
    WHERE uID = localUID;
    
    -- finally remove the user details
    DELETE FROM tbl_Login
    WHERE uID = localUID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_searchUserList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_searchUserList`(
    IN paramToken VARCHAR(255),
	IN paramSearchQuery VARCHAR(255)
)
BEGIN
	
   SELECT firstName, lastName, email, roleName
	FROM tbl_Login
	INNER JOIN tbl_user_role
	ON tbl_Login.roleID = tbl_user_role.roleID
	WHERE (firstName REGEXP paramSearchQuery OR lastName REGEXP paramSearchQuery OR email REGEXP paramSearchQuery OR roleName REGEXP paramSearchQuery)
	AND uid <> (
		SELECT uid 
		FROM tbl_user_token
		WHERE token = paramToken
	);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateSettings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`CSCI5308_10_DEVINT_USER`@`%` PROCEDURE `sp_UpdateSettings`(
	IN paramSettingKey VARCHAR(255),
    IN paramSettingValue VARCHAR(255)
)
BEGIN

	Declare SettingsCount INT;
    
    SELECT COUNT(*) INTO SettingsCount
    FROM tbl_settings
    WHERE setting_key = paramSettingKey;
    
    IF SettingsCount = 0
    THEN
		INSERT INTO tbl_settings  (setting_key,setting_value) VALUES (paramSettingKey, paramSettingValue);
	ELSE
		UPDATE tbl_settings SET setting_value = paramSettingValue WHERE setting_key = paramSettingKey;
    END IF;	

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-03 18:54:25
