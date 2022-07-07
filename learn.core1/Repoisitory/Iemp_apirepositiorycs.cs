using learn.core1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core1.Repoisitory
{
    public interface Iemp_apirepositiorycs
    {
        public List<emp_dto> getfnamelnamesalary();

        public List<emp_dto> getfnamedate(emp_Date emp);
        public List<emp_dto> getfnamelnamedate(emp_Date emp);

    }
}
