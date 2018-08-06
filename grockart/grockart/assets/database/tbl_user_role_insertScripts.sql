drop procedure if exists sp_registerUser;
delimiter #
CREATE PROCEDURE sp_registerUser(
	IN paramFirstName VARCHAR(255),
    IN paramLastName VARCHAR(255),
    IN paramEmail VARCHAR(255),
    IN paramPwd VARCHAR(255),
    IN paramSalt VARCHAR(255),
    IN paramToken VARCHAR(255),
    IN paramRoleType VARCHAR(45)
)
	
BEGIN
	
    DECLARE int_uid INT;
    DECLARE uidCount INT;
    DECLARE role INT;
  
	-- get the ip count for the 
    -- tables
    SELECT Count(*)
    FROM tbl_Login    
    WHERE email = paramEmail
    INTO uidCount;
    
    IF uidCount > 0
    THEN    
		SELECT -1 'status';            
    ELSE
		SELECT roleID 
        FROM tbl_user_role 
        WHERE roleName = paramRoleType
        INTO role;
        
    	-- the email is unique
        -- add the email to the table
        INSERT INTO tbl_Login (token, password, email, roleID, firstName, lastName)
        VALUES (paramToken, paramPwd, paramEmail, role, paramFirstName, paramLastName);
        
        -- now we have inserted the rows, now we can get the uid 
        SELECT uid FROM tbl_Login
        WHERE email = paramEmail
        INTO int_uid;
        
        -- now insert the salt
        INSERT INTO tbl_pswd_salt (uID, salt)
        VALUES (int_uid, paramSalt);
        
        SELECT 1 'status';        
	 
    END IF;
END#
