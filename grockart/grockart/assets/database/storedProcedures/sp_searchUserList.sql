drop procedure if exists sp_searchUserList;
delimiter #
CREATE PROCEDURE sp_searchUserList(
    IN paramToken VARCHAR(255),
	IN paramSearchQuery VARCHAR(255)
)	
BEGIN
	SELECT uid 
		FROM tbl_user_token
		WHERE token = paramToken;
	
    select paramSearchQuery;
        
   SELECT firstName, lastName, email, roleName
	FROM tbl_Login
	INNER JOIN tbl_user_role
	ON tbl_Login.roleID = tbl_user_role.roleID
	WHERE (firstName LIKE('%' + paramSearchQuery + '%') OR lastName LIKE('%' + paramSearchQuery + '%') );
	
    
END#
