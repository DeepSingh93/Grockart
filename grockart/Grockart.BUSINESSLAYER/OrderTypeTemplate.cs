using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    public abstract class OrderTypeTemplate
    {
        public abstract List<IOrderBuilderResponse> FetchAllOrders ();
        public abstract List<IOrderBuilderResponse> FetchUnpaidOrderID();
        public abstract List<IOrderBuilderResponse> FetchShippedOrderID();
        public abstract List<IOrderBuilderResponse> FetchCancelledOrderID();
        public abstract List<IOrderBuilderResponse> FetchOrderCreatedID();
    }
}
