using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.LOGGER
{
    [Serializable]
    public class WarnDebug : Exception
    {
        public WarnDebug()
        {

        }

        public WarnDebug(string message) : base(message)
        {
        }

        public WarnDebug(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WarnDebug(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
