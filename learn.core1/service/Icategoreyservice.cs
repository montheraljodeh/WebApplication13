using learn.core1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core1.service
{
    public interface Icategoreyservice
    {
        public string insertcategorey(categorey_api categorey_Api);
        public string updatecategorey(categorey_api categorey_Api);
        public string deletecategorey(int id);
        public List<categorey_api> getallcategorey();

        public categorey_api categorey_Api1(int id);

    }
}
