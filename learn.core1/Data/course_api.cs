using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core1.Data
{
    public class course_api
    {


        [Key] // primary key 
        public int id { get; set; }
        public string coursename { get; set; }
        public int? courseprice { get; set; }
    }
}
