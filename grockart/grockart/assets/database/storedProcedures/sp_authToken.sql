drop procedure if exists sp_authToken;
delimiter #
CREATE PROCEDURE sp_authToken(
    IN paramToken VARCHAR(255)
)
BEGIN
	
    SELECT COUNT(*)
    FROM tbl_user_token tk
    INNER JOIN tbl_Login tl
    ON tk.uID = tl.uID
    WHERE token = paramToken;
    
END