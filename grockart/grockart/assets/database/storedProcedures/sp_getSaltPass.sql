drop procedure if exists sp_getSaltPass;
delimiter #
CREATE PROCEDURE sp_getSaltPass(
	IN paramEmail VARCHAR(255)
)
	
BEGIN
	
    SELECT password, salt 
    FROM tbl_Login tl 
    INNER JOIN tbl_pswd_salt slt
	ON tl.uID = slt.uID
	WHERE email = paramEmail;	 
    
END#
