drop procedure if exists sp_FetchSettings;
delimiter #
CREATE PROCEDURE sp_FetchSettings(
    IN paramSettingKey VARCHAR(255)
)
BEGIN
	SELECT setting_value
    FROM tbl_settings
    WHERE setting_key = paramSettingKey;
END