drop procedure if exists sp_FetchCategory;
delimiter #
CREATE PROCEDURE sp_FetchCategory()	
BEGIN
	
  SELECT cID, categoryName
  FROM tbl_cateogry;
    
END#
