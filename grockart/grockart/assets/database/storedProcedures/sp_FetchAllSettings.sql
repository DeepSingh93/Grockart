drop procedure if exists sp_FetchAllSettings;
delimiter #
CREATE PROCEDURE sp_FetchAllSettings()
BEGIN
	SELECT setting_key, setting_value
    FROM tbl_settings;
END