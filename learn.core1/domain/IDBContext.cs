using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.core1.domain
{
   public  interface IDBContext
    {
        public DbConnection dbConnection { get; }
    }
}
