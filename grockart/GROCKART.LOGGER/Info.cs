


using System;
using System.Diagnostics;
using System.Xml;

namespace Grockart.LOGGER
{
    public class Info : ILogType
    {
        private readonly ENumLogType message = ENumLogType.INFO;
        private static readonly Info Obj = new Info();
        public string HTMLCSS { get { return "Info-background-color"; } }
        public static Info Instance()
        {
            return Obj;
        }
        public string GetMessage()
        {
            return message.ToString();
        }

    }
}
