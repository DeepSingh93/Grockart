using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.DATALAYER
{
    public interface IOrderDetailsDataLayer
    {
        DataSet FetchOrderDetailsByTypeAndStatus();
        DataSet FetchOrderDetailsByType();
        DataSet FetchOrderDetailsByID();
    }
}
