using Dapper;
using learn.core1.Data;
using learn.core1.Repoisitory;
using learn.infra1.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
/*
 
 
 */
namespace learn.infra1.Repoisitory
{
    public class course_apirepoisitory : Icourse_apirepository
    {

        private readonly DbContext dbContext;

        public course_apirepoisitory(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deletecoure(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", id, dbType:DbType.Int32,direction:ParameterDirection.Input);


            var result= dbContext.dbConnection.ExecuteAsync("course_package_api.deletecourse", parameter, commandType: CommandType.StoredProcedure);
            if(result==null)
            {
                return false;
            }
            else
            {
                return true;
            }

           

        }
        
        public List<course_api> getallcourse()
        {
         IEnumerable<course_api> result=dbContext.dbConnection.Query<course_api>("course_package_api.getallcourse",commandType:CommandType.StoredProcedure);
            return result.ToList();
        
        }

        public course_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse",id, dbType:DbType.Int32,direction:ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<course_api> result = dbContext.dbConnection.Query<course_api>("course_package_api.getbyid", parameter, commandType:CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool insertcourse(course_api course)
        {

            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", course.id, dbType: DbType.Int32,direction:ParameterDirection.Input);
            parameter.Add("nameofcourse", course.coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price",course.courseprice,dbType:DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("course_package_api.createinsertcourse", parameter, commandType: CommandType.StoredProcedure);
            return true;

            
        }

        public bool updatecourse(course_api course)
        {

            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", course.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("nameofcourse", course.coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", course.courseprice, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("course_package_api.updatecourse", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }
    }
}
