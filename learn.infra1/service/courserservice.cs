using learn.core1.Data;
using learn.core1.Repoisitory;
using learn.core1.service;
using learn.infra1.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra1.service
{
    public class courserservice : Icourseservice
    {
        private readonly Icourse_apirepository repo;
        public courserservice(Icourse_apirepository repo)
        {
            this.repo = repo;
        }
    
        public bool deletecoure(int? id)
        {
            return repo.deletecoure(id);
        }

        public List<course_api> getallcourse()
        {
          return repo.getallcourse();
        }

        public course_api getbyid(int id)
        {
         return repo.getbyid(id);
        }

        public bool insertcourse(course_api course)
        {
         return repo.insertcourse(course);
        }

        public bool updatecourse(course_api course)
        {
           return repo.updatecourse(course);    
        }

        public bool updatecoursename(course_api course)
        {
           string result= repo.updatecoursebyname(course);
           
            if(result=="valid")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
