drop procedure if exists sp_GetAdminList;
delimiter #
CREATE PROCEDURE sp_GetAdminList(
	IN paramToken VARCHAR(255)
)
	
BEGIN
  
	SELECT firstName, lastName, email
	FROM tbl_Login
	INNER JOIN tbl_user_role
	ON tbl_Login.roleID = tbl_user_role.roleID
	WHERE roleName = 'ADMIN'
	AND uid <> (
		SELECT uid 
		FROM tbl_user_token
		WHERE token = paramToken
	);
    
END#

