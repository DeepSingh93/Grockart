using Grockart.LOGGER;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class grockart_log_DumpLog : System.Web.UI.Page
{
    string DirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory + "//grockart_log//dumps";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            XmlDocument Doc = new XmlDocument();
            XmlElement element = Logger.Instance().GetXML();
            Doc.LoadXml(element.OuterXml);


            int CountFiles = 0;
            // check if directory exists
            if (Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
                DirectoryInfo dirInfo = new DirectoryInfo(DirectoryPath);
                FileInfo[] files = dirInfo.GetFiles("*.xml");
                CountFiles = files.Length;
            }
            else
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            string finalFilePath = DirectoryPath + "//" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + CountFiles.ToString() + ".xml";
            Doc.Save(finalFilePath);
            CacheProxy.Instance().RemoveKey("Log");
            var output = new
            {
                Result = "Success",
                FilePath = finalFilePath
            };

            Response.Write(new JavaScriptSerializer().Serialize(output));
        }catch(Exception ex)
        {
            var output = new
            {
                Result = "Fail",
                Reason = ex.ToString()
            };

            Response.Write(new JavaScriptSerializer().Serialize(output));
        }
        
    }
}