using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Enum
{
    public class SqlReturnValue
    {

    }
    public enum SqlResultType
    {
        Existed = -1,
        NotExisted = -2,
        OK = 1,
        Failed = 0,
        Exception
    }
}
