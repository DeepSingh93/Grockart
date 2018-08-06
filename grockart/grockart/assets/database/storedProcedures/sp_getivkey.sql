drop procedure if exists sp_getivkey;
delimiter #
CREATE PROCEDURE sp_getivkey()	
BEGIN
	
    select 
	(select setting_value from tbl_settings where setting_key = 'SETTING_CORE_IV') 'IV',
	(select setting_value from tbl_settings where setting_key = 'SETTING_CORE_Key') 'KEY';
    
END#
