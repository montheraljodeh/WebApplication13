using learn.core1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core1.Repoisitory
{
    public interface Icategoreyrepoisitory
    {
        public string insertcat(categorey_api categorey_Api);
        public string updatecat(categorey_api categorey_Api);   

        public string deletecat(int id);

        public List<categorey_api> getall();

        public categorey_api getbyidcat(int id);


    }
}
