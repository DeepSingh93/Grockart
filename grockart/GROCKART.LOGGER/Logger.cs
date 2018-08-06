using Grockart.STORAGE;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;


/// <summary>
/// Using singleton design pattern to log the contents
/// </summary>
namespace Grockart.LOGGER
{
    public class Logger
    {
        private static Logger logInstance = new Logger();
        XmlDocument Doc;
        XmlElement Root;
        public Logger()
        {
            Doc = new XmlDocument();
            // since this code is in app code folder
            // we need to go one directory up
            // now we are in the root
            // get the logger directory
            // create if not exists

            if (CacheProxy.Instance().HasKey("Log"))
            {
                Doc.LoadXml(CacheProxy.Instance().GetValue("Log").ToString());
                Root = Doc.DocumentElement;
            }
            else
            {
                // Create the XmlDocument.

                XmlDeclaration xmlDeclaration = Doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = Doc.DocumentElement;
                Doc.InsertBefore(xmlDeclaration, root);

                Root = Doc.CreateElement(string.Empty, "GrockartLog", string.Empty);

                Doc.AppendChild(Root);
                SaveXML();
            }
        }

        private void SaveXML()
        {
            CacheProxy.Instance().SetValue("Log", Doc.DocumentElement.OuterXml);
        }

        public static Logger Instance()
        {
            if (CacheProxy.Instance().HasKey("Log"))
            {
                return logInstance;
            }
            else
            {
                logInstance = new Logger();
            }
            return logInstance;
        }


        public XmlElement GetXML()
        {
            string XML = CacheProxy.Instance().GetValue("Log").ToString();
            Doc.LoadXml(XML);
            Root = Doc.DocumentElement;
            return Root;
        }


        public void Log(ILogType LogType, Exception Ex = null)
        {
            Doc.LoadXml(CacheProxy.Instance().GetValue("Log").ToString());
            string Message = LogType.GetMessage();
            XmlElement X_ChildElement = CreateXMLNode(LogType, Message, Ex);
            Doc.LastChild.PrependChild(X_ChildElement);
            SaveXML();
        }

        private XmlElement CreateXMLNode(ILogType LogType, string Message, Exception ex)
        {
            StackTrace StackTraceObj = new StackTrace(ex, true);
            XmlElement X_Log = Doc.CreateElement("log");

            XmlElement X_ChildElement = Doc.CreateElement("level");
            XmlText X_Text = Doc.CreateTextNode(Message);
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("date");
            X_Text = Doc.CreateTextNode(DateTime.Now.ToString());
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);


            X_ChildElement = Doc.CreateElement("exceptionType");
            X_Text = Doc.CreateTextNode(ex.GetType().Name);
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("functionName");
            X_Text = Doc.CreateTextNode(StackTraceObj.GetFrame(0) != null ? StackTraceObj.GetFrame(0).GetMethod().Name : "");
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("fileLocation");
            X_Text = Doc.CreateTextNode(StackTraceObj.GetFrame(0) != null ? StackTraceObj.GetFrame(0).GetFileName() : "");
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("lineNumber");
            X_Text = Doc.CreateTextNode(StackTraceObj.GetFrame(0) != null ? StackTraceObj.GetFrame(0).GetFileLineNumber().ToString() : "");
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("message");
            X_Text = Doc.CreateTextNode(ex.Message);
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("stackTrace");
            X_Text = Doc.CreateTextNode(ex.ToString());
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            X_ChildElement = Doc.CreateElement("BackgroundColor");
            X_Text = Doc.CreateTextNode(LogType.HTMLCSS);
            X_ChildElement.AppendChild(X_Text);
            X_Log.AppendChild(X_ChildElement);

            return X_Log;
        }
    }
}