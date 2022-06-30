using learn.core1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core1.Repoisitory
{
    public interface Icourse_apirepository
    {
        public List<course_api> getallcourse();

        public bool insertcourse(course_api course);

        public bool deletecoure(int? id);

        public course_api getbyid(int id);

        public bool updatecourse(course_api course);




    }
}
