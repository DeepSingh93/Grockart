DROP procedure IF EXISTS `sp_getMenu`;

DELIMITER $$
 
CREATE PROCEDURE `sp_getMenu`(
	
)
BEGIN
	
	SELECT distinct categoryName, productName, productImage
	FROM tbl_productByStore pbs
	INNER JOIN tbl_category ca
	ON pbs.cID = ca.cID
	INNER JOIN tbl_product pd
	ON pbs.pID = pd.pID;
     
END$$

DELIMITER ;
