namespace Grockart.LOGGER
{
    public class Warn : ILogType
    {
        private readonly ENumLogType message = ENumLogType.WARN;
        public string HTMLCSS { get { return "warn-background-color"; } }
        private static readonly Warn Obj = new Warn();

        public static Warn Instance()
        {
            return Obj;
        }
        public string GetMessage()
        {
            return message.ToString();
        }
    }
}
