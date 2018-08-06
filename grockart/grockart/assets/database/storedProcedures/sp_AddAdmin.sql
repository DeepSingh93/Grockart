drop procedure if exists sp_AddAdmin;
delimiter #
CREATE PROCEDURE sp_AddAdmin(
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
    DELETE FROM tbl_user_address
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
    
END#

drop procedure if exists sp_addToken;
CREATE PROCEDURE sp_addToken(
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
END#

