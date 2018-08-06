DROP procedure IF EXISTS `sp_getUserProfile`;

DELIMITER $$
 
CREATE PROCEDURE `sp_getUserProfile`(
	IN paramToken VARCHAR(255)
)
BEGIN
	
	SELECT 
		firstname, 
        lastname, 
        email, 
        (	
			SELECT roleName
			FROM tbl_user_role
			INNER JOIN tbl_Login
			ON tbl_user_role.roleID = tbl_Login.roleID
			AND tbl_Login.uID = tl.uID
		) 'roleName'
	FROM tbl_Login tl
    INNER JOIN tbl_user_token tk
    ON tl.uID = tk.uID
	WHERE tk.token = paramToken;
     
END$$

DELIMITER ;
