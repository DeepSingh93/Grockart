using System.Collections.Generic;

namespace Grockart.DATALAYER
{
    public abstract class CRUDTemplate<T>
    {
        public abstract List<T> Select();
        public abstract int Update(T Obj);
        public abstract int Insert(T Obj);
        public abstract int Delete(T Obj);
    }
}
