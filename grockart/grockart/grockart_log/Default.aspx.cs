using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Grockart.LOGGER;
using Grockart.STORAGE;

public partial class grockart_log_Default : System.Web.UI.Page
{
    string DirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory + "//grockart_log//dumps";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            exportResult.Visible = false;
            logResults.InnerHtml = "";
            DisplayLogs(null);
            LoadDropDown();
        }

    }

    private void LoadDropDown()
    {
        DirectoryInfo dirInfo = new DirectoryInfo(DirectoryPath);
        FileInfo[] files = dirInfo.GetFiles("*.xml");
        int CountFiles = files.Length;
        PreviousLogList.Items.Clear();
        if (CountFiles > 0)
        {
            PreviousLogList.Items.Add(new ListItem("Select a Log file", "0"));
            PreviousLog.Visible = true;
            foreach (FileInfo file in files)
            {
                PreviousLogList.Items.Add(new ListItem(file.Name, file.FullName));
            }
        }
        else
        {
            PreviousLog.Visible = false;
        }

    }

    private void DisplayLogs(XmlElement element)
    {
        Logger log = Logger.Instance();

        // read the XML file
        if (element == null)
        {
            element = Logger.Instance().GetXML();
        }
        XmlNodeList xmlnode = element.GetElementsByTagName("log");
        if (xmlnode.Count == 0)
        {
            nologsfoundID.InnerHtml = "No Logs found";
            nologsfoundID.Visible = true;
            exportDivID.Visible = false;
            logResults.Visible = false;
        }
        else
        {
            nologsfoundID.Visible = false;
            exportDivID.Visible = true;
            logResults.Visible = true;
        }
        logResults.InnerHtml = ParseLog(xmlnode);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "LoadMasterMenu", "google.setOnLoadCallback(function () { drawGrockartLogChart(" + GetLogsForPiechart(xmlnode) + ") });", true);
    }

    private string GetLogsForPiechart(XmlNodeList xmlnode)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i <= xmlnode.Count - 1; i++)
        {
            if (dict.ContainsKey(xmlnode[i].ChildNodes.Item(0).InnerText.Trim().ToString()) == true)
            {
                dict[xmlnode[i].ChildNodes.Item(0).InnerText.Trim().ToString()] += 1;
            }
            else
            {
                dict.Add(xmlnode[i].ChildNodes.Item(0).InnerText.Trim().ToString(), 1);
            }
        }

        List<List<object>> result = new List<List<object>>
        {
            new List<object>
            {
                "Log Type", "Count"
            }
        };
        foreach (string key in dict.Keys)
        {
            List<object> keys = new List<object>
            {
                key,
                dict[key]
            };
            result.Add(keys);
        }

        return new JavaScriptSerializer().Serialize(result);
    }

    public string ParseLog(XmlNodeList xmlnode)
    {
        string HTML = "<div>";
        for (int i = 0; i <= xmlnode.Count - 1; i++)
        {
            xmlnode[i].ChildNodes.Item(0).InnerText.Trim();

            HTML += "<div class='row grockart-row-log " + xmlnode[i].ChildNodes.Item(8).InnerText.Trim().ToString() + "'>" +
                "<div class='col-lg-1'>" +
                   xmlnode[i].ChildNodes.Item(0).InnerText.Trim().ToString() +
                "</div><div class='col-lg-1'>" +
                    xmlnode[i].ChildNodes.Item(1).InnerText.Trim().ToString() +
                "</div><div class='col-lg-1'>" +
                     xmlnode[i].ChildNodes.Item(2).InnerText.Trim().ToString() +
                "</div><div class='col-lg-1'>" +
                    xmlnode[i].ChildNodes.Item(3).InnerText.Trim().ToString() +
                "</div>" +
                "<div class='col-lg-2'>" +
                    xmlnode[i].ChildNodes.Item(4).InnerText.Trim().ToString() +
               "</div><div class='col-lg-1'>" +
                    xmlnode[i].ChildNodes.Item(5).InnerText.Trim().ToString() +
                "</div><div class='col-lg-2'>" +
                    xmlnode[i].ChildNodes.Item(6).InnerText.Trim().ToString() +
                "</div><div class='col-lg-3'>" +
                    xmlnode[i].ChildNodes.Item(7).InnerText.Trim().ToString() +
                "</div></div>";
        }

        return HTML;
    }

    protected void ExportLogButton_Click(object sender, EventArgs e)
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
        DisplayLogs(null);
        string showDirectoryPath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "//grockart_log//dumps" + "//" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + CountFiles.ToString() + ".xml";
        PreviousLog.Visible = true;
        exportResult.InnerHtml = "Successfully exported at : <a class='primary-white' href='" + showDirectoryPath + "'> " + showDirectoryPath + "</a>";
        exportResult.Visible = true;
        LoadDropDown();

    }

    protected void PreviousLogList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string GetSelectedValue = PreviousLogList.SelectedValue.ToString();
        if (GetSelectedValue == "0")
        {
            DisplayLogs(null);
            exportResult.Visible = false;
        }
        else
        {
            exportResult.InnerHtml = "You are currently viewing log file : <a style='color: purple' href='" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "//grockart_log//dumps//" + PreviousLogList.SelectedItem.ToString() + "'> " + PreviousLogList.SelectedItem.ToString() + " </a>";
            exportResult.Visible = true;
            XmlDocument Doc = new XmlDocument();
            Doc.Load(GetSelectedValue);
            XmlElement Root = Doc.DocumentElement;
            exportDivID.Visible = false;
            DisplayLogs(Root);
            exportDivID.Visible = false;

        }
    }
}