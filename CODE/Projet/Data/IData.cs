using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IData<T>
    {
        void Saver(T objCalled);
        T Loader(T objCalled);
    }
}