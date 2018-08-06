drop procedure if exists sp_addToken;
delimiter #
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
