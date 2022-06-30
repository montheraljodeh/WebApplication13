using Dapper;
using learn.core1.Data;
using learn.core1.Repoisitory;
using learn.infra1.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace learn.infra1.Repoisitory
{
    public class course_apirepoisitory : Icourse_apirepository
    {

        //15min create repoisitory any table interface class 
        private readonly DbContext dbContext;

        public course_apirepoisitory(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deletecoure(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcourse", id, dbType:DbType.Int32,direction:ParameterDirection.Input);


            dbContext.dbConnection.ExecuteAsync("course_package_api.deletecourse", parameter, commandType: CommandType.StoredProcedure);


            return true;

        }
        
        public List<course_api> getallcourse()
        {
            throw new NotImplementedException();
        }

        public bool insertcourse(course_api course)
        {
            throw new NotImplementedException();
        }
    }
}
