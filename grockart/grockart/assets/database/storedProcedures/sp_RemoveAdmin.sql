drop procedure if exists sp_RemoveAdmin;
delimiter #
CREATE PROCEDURE sp_RemoveAdmin(
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
    DELETE FROM tbl_user_address
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
    
END#

