


namespace Grockart.LOGGER
{
    public class Fatal : ILogType
    {
        private readonly ENumLogType message = ENumLogType.FATAL;
        private static readonly Fatal Obj = new Fatal();

        public string HTMLCSS { get { return "fatal-background-color"; } }

        public static Fatal Instance()
        {
            return Obj;
        }
        public string GetMessage()
        {
            return message.ToString();
        }
    }
}
