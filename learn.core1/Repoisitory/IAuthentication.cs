using learn.core1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core1.Repoisitory
{
    public interface IAuthentication
    {
        public login_api auth(login_api login);
    }
}
