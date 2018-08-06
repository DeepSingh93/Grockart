using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;


namespace Grockart.BUSINESSLAYER
{
    public abstract class OrderDetailsTemplate
    {
        public abstract List<IOrderBuilderResponse> BuildOrder();
    }
}
