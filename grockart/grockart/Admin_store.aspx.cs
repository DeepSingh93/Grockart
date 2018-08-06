using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using System.IO;
using Grockart.STORAGE;

public partial class Admin_store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            notificationArea.Visible = false;
        }
    }

    protected void Btn_AddStore_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_StoreName.Text.ToString().Trim().Length > 0)
            {
                // source : https://msdn.microsoft.com/en-us/library/ms227669.aspx?f=255&MSPPError=-2147217396
                Boolean fileOK = false;
                String path = Server.MapPath("~/assets/images/");
                if (FileUpload1.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions =
                        { ".png", ".jpeg", ".jpg"};
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        // check if file already exists or not ?
                        string FileName = "";
                        if (File.Exists(path + FileUpload1.FileName))
                        {
                            FileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName) + "_1";
                        }
                        else
                        {
                            FileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                        }

                        string DBSavePath = "images\\" + FileName + "" + Path.GetExtension(FileUpload1.FileName);
                        FileUpload1.PostedFile.SaveAs(path + FileName + "" + Path.GetExtension(FileUpload1.FileName));

                        // set store obj
                        IStores StoreObj = new Stores();
                        StoreObj.SetStoreName(txt_StoreName.Text);
                        StoreObj.SetStoreLogo(DBSavePath);

                        // set profile
                        IUserProfile Profile = new UserProfile();
                        Profile.SetToken(CookieProxy.Instance().GetValue("t").ToString());

                        if (new StoreBusinessLayerTemplate(Profile).Insert(StoreObj) == APIResponse.OK)
                        {
                            notificationArea.InnerHtml = "Store added";
                        }
                        else
                        {
                            notificationArea.InnerHtml = "Unable to update the file name in DB, please check logs";
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance().Log(Fatal.Instance(), ex);
                        notificationArea.InnerHtml = "File could not be uploaded. Please check logs";
                    }
                }
                else
                {
                    notificationArea.InnerHtml = "Cannot accept files of this type.";
                }
            }
            else
            {
                notificationArea.InnerHtml = "Store name is empty";
            }
        }
        catch (Exception ex)
        {
            notificationArea.InnerHtml = "Unable to add store this time, please check logs";
            Logger.Instance().Log(Fatal.Instance(), ex);
        }
        finally
        {
            notificationArea.Visible = true;
        }


    }

    protected void ModifyStoreBtn_Click(object sender, EventArgs e)
    {
        try
        {
            // source : https://msdn.microsoft.com/en-us/library/ms227669.aspx?f=255&MSPPError=-2147217396
            Boolean fileOK = false;
            String path = Server.MapPath("~/assets/images/");

            // set store obj
            IStores StoreObj = new Stores();
            StoreObj.SetStoreName(txt_StoreName.Text);


            if (ModifyStoreLogo.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(ModifyStoreLogo.FileName).ToLower();
                String[] allowedExtensions =
                    { ".png", ".jpeg", ".jpg"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        // check if file already exists or not ?
                        string FileName = "";
                        if (File.Exists(path + ModifyStoreLogo.FileName))
                        {
                            FileName = Path.GetFileNameWithoutExtension(ModifyStoreLogo.FileName) + "_1";
                        }
                        else
                        {
                            FileName = Path.GetFileNameWithoutExtension(ModifyStoreLogo.FileName);
                        }

                        string DBSavePath = "images\\" + FileName + "" + Path.GetExtension(ModifyStoreLogo.FileName);
                        ModifyStoreLogo.PostedFile.SaveAs(path + FileName + "" + Path.GetExtension(ModifyStoreLogo.FileName));

                        StoreObj.SetStoreLogo(DBSavePath);
                    }
                    catch (Exception ex)
                    {
                        fileOK = false;
                        Logger.Instance().Log(Fatal.Instance(), ex);
                        notificationArea.InnerHtml = "File could not be uploaded. Please check logs";
                    }
                }
                else
                {
                    fileOK = false;
                    notificationArea.InnerHtml = "Cannot accept files of this type.";
                }

            }
            else
            {
                fileOK = true;
                StoreObj.SetStoreLogo(ModifyStoreLogoName_Old.Value);
            }
            if (fileOK == true)
            {
                StoreObj.SetStoreID(int.Parse(modifyStoreID.Value.ToString()));
                IUserProfile Profile = new UserProfile();
                Profile.SetToken(CookieProxy.Instance().GetValue("t").ToString());

                if (newstoreName.Value.Trim().Length > 0)
                {
                    StoreObj.SetStoreName(newstoreName.Value);
                }
                else
                {
                    StoreObj.SetStoreName(ModifyStoreName_Old_01.Value);
                }

                if (new StoreBusinessLayerTemplate(Profile).Update(StoreObj) == APIResponse.OK)
                {
                    notificationArea.InnerHtml = "Successfully modified store";
                }
                else
                {
                    notificationArea.InnerHtml = "Unable to modify the store, please check logs";
                }

            }


        }
        catch (Exception ex)
        {
            notificationArea.InnerHtml = "Unable to modify store this time, please check logs";
            Logger.Instance().Log(Fatal.Instance(), ex);
        }
        finally
        {
            notificationArea.Visible = true;
        }
    }
}