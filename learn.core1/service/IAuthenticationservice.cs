using learn.core1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core1.service
{
    public interface IAuthenticationservice
    {
        public string Authentication_jwt(login_api login);
    }
}
