using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class MenuResponse
    {
        public bool IsMenuAvailable;
        public string Response { get; set; }
        public System.Data.DataSet Menu { get; set; }
    }
}
