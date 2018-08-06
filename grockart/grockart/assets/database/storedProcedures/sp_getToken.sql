drop procedure if exists sp_getToken;
delimiter #
CREATE PROCEDURE sp_getToken(
	IN paramEmail VARCHAR(255)
)
	
BEGIN
	
    SELECT token
    FROM tbl_user_token tk
    INNER JOIN tbl_Login tl
    ON tk.uID = tl.uID
    WHERE LOWER(email) = LOWER(paramEmail);
    
END#
