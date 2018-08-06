drop procedure if exists sp_RemoveSettings;
delimiter #
CREATE PROCEDURE sp_RemoveSettings(
    IN paramSettingKey VARCHAR(255)
)
BEGIN
	DELETE FROM tbl_settings
    WHERE setting_key = paramSettingKey;
END