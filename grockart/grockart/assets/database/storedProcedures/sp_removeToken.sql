drop procedure if exists sp_removeToken;
delimiter #
CREATE PROCEDURE sp_removeToken(
	IN paramToken VARCHAR(255)
)
	
BEGIN
	
   DELETE FROM
   tbl_user_token
   WHERE token =  paramToken;
    
END#
