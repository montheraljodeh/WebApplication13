using learn.core1.Data;
using learn.core1.Repoisitory;
using learn.core1.service;
using learn.infra1.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra1.service
{
    public class categoreyservice : Icategoreyservice
    {
        private readonly Icategoreyrepoisitory categoreyrepoisitory;
        public categoreyservice(Icategoreyrepoisitory categoreyrepoisitory)
        {
            this.categoreyrepoisitory = categoreyrepoisitory;
        }
        public categorey_api categorey_Api1(int id)
        {
        return    categoreyrepoisitory.getbyidcat(id);
        }

        public string deletecategorey(int id)
        {
            return categoreyrepoisitory.deletecat(id);
        }

        public List<categorey_api> getallcategorey()
        {
            return categoreyrepoisitory.getall();
        }

        public string insertcategorey(categorey_api categorey_Api)
        {
            return categoreyrepoisitory.insertcat(categorey_Api);
        }

        public string updatecategorey(categorey_api categorey_Api)
        {
            return categoreyrepoisitory.updatecat(categorey_Api);
        }
    }
}
