-- ****************** SqlDBM: MySQL ******************;
-- ***************************************************;

DROP TABLE `tbl_groupOrder`;


DROP TABLE `tbl_orderDetails`;


DROP TABLE `tbl_order`;


DROP TABLE `tbl_card_details`;


DROP TABLE `tbl_user_address`;


DROP TABLE `tbl_productByStore`;


DROP TABLE `tbl_card_decrypt`;


DROP TABLE `tbl_address`;


DROP TABLE `tbl_Login`;


DROP TABLE `tbl_user_role`;


DROP TABLE `tbl_settings`;


DROP TABLE `tbl_groupOrderStatus`;


DROP TABLE `tbl_orderType`;


DROP TABLE `tbl_orderStatus`;


DROP TABLE `tbl_product`;


DROP TABLE `tbl_category`;


DROP TABLE `tbl_store`;


DROP TABLE `tbl_card`;


DROP TABLE `tbl_city`;



-- ************************************** `tbl_user_role`

CREATE TABLE `tbl_user_role`
(
 `roleID`   INT NOT NULL AUTO_INCREMENT ,
 `roleName` VARCHAR(45) NOT NULL ,

PRIMARY KEY (`roleID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_settings`

CREATE TABLE `tbl_settings`
(
 `sid`           INT NOT NULL AUTO_INCREMENT ,
 `setting_key`   VARCHAR(255) NOT NULL ,
 `setting_value` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`sid`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_groupOrderStatus`

CREATE TABLE `tbl_groupOrderStatus`
(
 `goSID`   INT NOT NULL AUTO_INCREMENT ,
 `gosName` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`goSID`)
) COMMENT='Can be paid or unpaid';





-- ************************************** `tbl_orderType`

CREATE TABLE `tbl_orderType`
(
 `otID`   INT NOT NULL AUTO_INCREMENT ,
 `otName` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`otID`)
) COMMENT='Can be a group order or an individual order';





-- ************************************** `tbl_orderStatus`

CREATE TABLE `tbl_orderStatus`
(
 `sID`        INT NOT NULL AUTO_INCREMENT ,
 `statusName` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`sID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_product`

CREATE TABLE `tbl_product`
(
 `pID`          INT NOT NULL AUTO_INCREMENT ,
 `productName`  VARCHAR(255) NOT NULL ,
 `quantity`     INT NOT NULL ,
 `price`        DOUBLE NOT NULL ,
 `productImage` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`pID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_category`

CREATE TABLE `tbl_category`
(
 `cID`          INT NOT NULL AUTO_INCREMENT ,
 `categoryName` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`cID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_store`

CREATE TABLE `tbl_store`
(
 `sID`       INT NOT NULL AUTO_INCREMENT ,
 `storeName` VARCHAR(255) NOT NULL ,
 `storeLogo` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`sID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_card`

CREATE TABLE `tbl_card`
(
 `caID`               INT NOT NULL AUTO_INCREMENT ,
 `cardNameEncrypt`    VARCHAR(255) NOT NULL ,
 `cardNumberEncrypt`  VARCHAR(255) NOT NULL ,
 `expiryMonthEncrypt` VARCHAR(255) NOT NULL ,
 `expiryYearEncrypt`  VARCHAR(255) NOT NULL ,
 `cvvEncrypt`         VARCHAR(255) NOT NULL ,

PRIMARY KEY (`caID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_city`

CREATE TABLE `tbl_city`
(
 `cID`      INT NOT NULL AUTO_INCREMENT ,
 `city`     VARCHAR(255) NOT NULL ,
 `province` VARCHAR(255) NOT NULL ,

PRIMARY KEY (`cID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_productByStore`

CREATE TABLE `tbl_productByStore`
(
 `pbsId` INT NOT NULL AUTO_INCREMENT ,
 `sID`   INT NOT NULL ,
 `cID`   INT NOT NULL ,
 `pID`   INT NOT NULL ,

PRIMARY KEY (`pbsId`),
KEY `fkIdx_142` (`sID`),
CONSTRAINT `FK_142` FOREIGN KEY `fkIdx_142` (`sID`) REFERENCES `tbl_store` (`sID`),
KEY `fkIdx_146` (`cID`),
CONSTRAINT `FK_146` FOREIGN KEY `fkIdx_146` (`cID`) REFERENCES `tbl_category` (`cID`),
KEY `fkIdx_150` (`pID`),
CONSTRAINT `FK_150` FOREIGN KEY `fkIdx_150` (`pID`) REFERENCES `tbl_product` (`pID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_card_decrypt`

CREATE TABLE `tbl_card_decrypt`
(
 `dID`  INT NOT NULL AUTO_INCREMENT ,
 `key`  VARCHAR(255) NOT NULL ,
 `salt` VARCHAR(255) NOT NULL ,
 `caID` INT NOT NULL ,

PRIMARY KEY (`dID`),
KEY `fkIdx_81` (`caID`),
CONSTRAINT `FK_81` FOREIGN KEY `fkIdx_81` (`caID`) REFERENCES `tbl_card` (`caID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_address`

CREATE TABLE `tbl_address`
(
 `aID`        INT NOT NULL AUTO_INCREMENT ,
 `appt`       VARCHAR(255) NOT NULL ,
 `streetName` VARCHAR(255) NOT NULL ,
 `postalCode` VARCHAR(6) NOT NULL ,
 `cID`        INT NOT NULL ,

PRIMARY KEY (`aID`),
KEY `fkIdx_241` (`cID`),
CONSTRAINT `FK_241` FOREIGN KEY `fkIdx_241` (`cID`) REFERENCES `tbl_city` (`cID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_Login`

CREATE TABLE `tbl_Login`
(
 `uID`      INT NOT NULL AUTO_INCREMENT ,
 `userName` VARCHAR(255) NOT NULL ,
 `password` VARCHAR(255) NOT NULL ,
 `salt`     VARCHAR(45) NOT NULL ,
 `email`    VARCHAR(255) NOT NULL ,
 `roleID`   INT NOT NULL ,

PRIMARY KEY (`uID`),
KEY `fkIdx_251` (`roleID`),
CONSTRAINT `FK_251` FOREIGN KEY `fkIdx_251` (`roleID`) REFERENCES `tbl_user_role` (`roleID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_order`

CREATE TABLE `tbl_order`
(
 `oID`  INT NOT NULL AUTO_INCREMENT ,
 `date` DATETIME NOT NULL ,
 `sID`  INT NOT NULL ,
 `uID`  INT NOT NULL ,
 `otID` INT NOT NULL ,

PRIMARY KEY (`oID`),
KEY `fkIdx_182` (`sID`),
CONSTRAINT `FK_182` FOREIGN KEY `fkIdx_182` (`sID`) REFERENCES `tbl_orderStatus` (`sID`),
KEY `fkIdx_186` (`uID`),
CONSTRAINT `FK_186` FOREIGN KEY `fkIdx_186` (`uID`) REFERENCES `tbl_Login` (`uID`),
KEY `fkIdx_195` (`otID`),
CONSTRAINT `FK_195` FOREIGN KEY `fkIdx_195` (`otID`) REFERENCES `tbl_orderType` (`otID`)
);





-- ************************************** `tbl_card_details`

CREATE TABLE `tbl_card_details`
(
 `ucID` INT NOT NULL AUTO_INCREMENT ,
 `uID`  INT NOT NULL ,
 `caID` INT NOT NULL ,

PRIMARY KEY (`ucID`),
KEY `fkIdx_92` (`uID`),
CONSTRAINT `FK_92` FOREIGN KEY `fkIdx_92` (`uID`) REFERENCES `tbl_Login` (`uID`),
KEY `fkIdx_96` (`caID`),
CONSTRAINT `FK_96` FOREIGN KEY `fkIdx_96` (`caID`) REFERENCES `tbl_card` (`caID`)
);





-- ************************************** `tbl_user_address`

CREATE TABLE `tbl_user_address`
(
 `uaID` INT NOT NULL AUTO_INCREMENT ,
 `uID`  INT NOT NULL ,
 `aID`  INT NOT NULL ,

PRIMARY KEY (`uaID`),
KEY `fkIdx_58` (`uID`),
CONSTRAINT `FK_58` FOREIGN KEY `fkIdx_58` (`uID`) REFERENCES `tbl_Login` (`uID`),
KEY `fkIdx_62` (`aID`),
CONSTRAINT `FK_62` FOREIGN KEY `fkIdx_62` (`aID`) REFERENCES `tbl_address` (`aID`)
) AUTO_INCREMENT=1;





-- ************************************** `tbl_groupOrder`

CREATE TABLE `tbl_groupOrder`
(
 `gID`   INT NOT NULL AUTO_INCREMENT ,
 `oID`   INT NOT NULL ,
 `uID`   INT NOT NULL ,
 `goSID` INT NOT NULL ,

PRIMARY KEY (`gID`),
KEY `fkIdx_206` (`oID`),
CONSTRAINT `FK_206` FOREIGN KEY `fkIdx_206` (`oID`) REFERENCES `tbl_order` (`oID`),
KEY `fkIdx_210` (`uID`),
CONSTRAINT `FK_210` FOREIGN KEY `fkIdx_210` (`uID`) REFERENCES `tbl_Login` (`uID`),
KEY `fkIdx_223` (`goSID`),
CONSTRAINT `FK_223` FOREIGN KEY `fkIdx_223` (`goSID`) REFERENCES `tbl_groupOrderStatus` (`goSID`)
);





-- ************************************** `tbl_orderDetails`

CREATE TABLE `tbl_orderDetails`
(
 `odID`     INT NOT NULL AUTO_INCREMENT ,
 `oID`      INT NOT NULL ,
 `pbsId`    INT NOT NULL ,
 `quantity` INT NOT NULL ,
 `price`    DOUBLE NOT NULL ,

PRIMARY KEY (`odID`),
KEY `fkIdx_171` (`oID`),
CONSTRAINT `FK_171` FOREIGN KEY `fkIdx_171` (`oID`) REFERENCES `tbl_order` (`oID`),
KEY `fkIdx_175` (`pbsId`),
CONSTRAINT `FK_175` FOREIGN KEY `fkIdx_175` (`pbsId`) REFERENCES `tbl_productByStore` (`pbsId`)
);




