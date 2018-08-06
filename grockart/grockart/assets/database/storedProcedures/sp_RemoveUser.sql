drop procedure if exists sp_RemoveUser;
delimiter #
CREATE PROCEDURE sp_RemoveUser(
    IN paramEmail VARCHAR(255)
)
BEGIN
	-- delete the tokens
    DELETE FROM tbl_user_token
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
    
    -- remove the salt
    DELETE FROM tbl_pswd_salt
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
    
    -- finally remove the user details
    DELETE FROM tbl_Login
    WHERE uID = (SELECT uID FROM tbl_Login WHERE email = paramEmail);
END