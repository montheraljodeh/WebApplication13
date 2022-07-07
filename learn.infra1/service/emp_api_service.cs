using learn.core1.DTO;
using learn.core1.Repoisitory;
using learn.core1.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra1.service
{
    public class emp_api_service : Iemp_service
    {
        private readonly Iemp_apirepositiorycs iemp_;
        public emp_api_service(Iemp_apirepositiorycs iemp_)
        {
            this.iemp_ = iemp_;
        }

            public List<emp_dto> get()
        {
            return iemp_.getfnamelnamesalary();
        }

        public List<emp_dto> getfnamedate(emp_Date emp)
        {
            return iemp_.getfnamedate(emp);
        }

        public List<emp_dto> getfnamelnamedate(emp_Date emp)
        {
            return iemp_.getfnamelnamedate(emp);
        }
    }
}
