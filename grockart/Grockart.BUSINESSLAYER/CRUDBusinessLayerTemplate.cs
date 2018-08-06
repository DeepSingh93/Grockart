using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public abstract class CRUDBusinessLayerTemplate<T>
    {
        public abstract List<T> Select();
        public abstract APIResponse Update(T Obj);
        public abstract APIResponse Insert(T Obj);
        public abstract APIResponse Delete(T Obj);
    }
}
