


using System;
using System.Diagnostics;
using System.Xml;

namespace Grockart.LOGGER
{
    public class Debug : ILogType
    {
        private readonly ENumLogType message = ENumLogType.DEBUG;
        private static readonly Debug Obj = new Debug();

        public string HTMLCSS { get { return "debug-background-color"; } }
      
        public static Debug Instance()
        {
            return Obj;
        }
        public string GetMessage()
        {
            return message.ToString();
        }
 

    }
}
