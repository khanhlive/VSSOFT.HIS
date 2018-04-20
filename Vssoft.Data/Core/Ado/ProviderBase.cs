using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Enum;

namespace Vssoft.Data.Core.Ado
{
    public abstract class ProviderBase
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected Helper.SqlHelper sqlHelper;
        public ProviderBase()
        {
            this.sqlHelper = new Helper.SqlHelper();
        }

        protected SqlResultType GetResult(int result)
        {
            switch (result)
            {
                case -2:
                    return SqlResultType.NotExisted;
                case -1:
                    return SqlResultType.Existed;
                case 0:
                    return SqlResultType.Failed;
                case 1:
                    return SqlResultType.OK;
                default:
                    return SqlResultType.Failed;
            }
        }
    }
}
