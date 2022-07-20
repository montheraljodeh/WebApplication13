using Dapper;
using learn.core1.domain;
using learn.core1.DTO;
using learn.core1.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra1.Repoisitory
{
    public class emp_apirepoisitory : Iemp_apirepositiorycs
    {
        private readonly IDBContext dBContext;

        public emp_apirepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;

        }

        public bool checkemailisexist(empverifiy emp)
        {

            var parameter = new DynamicParameters();
            parameter.Add("emailof",emp.email, dbType: DbType.String, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<empverifiy> result = dBContext.dbConnection.Query<empverifiy>("emp_package.updateemail", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;

            if(result.Count()==0)
            {

                return false;
            }
            else
            {
                return true;
            }
           
        }

        public bool checkverify(empverifiy emp)
        {
            var parameter = new DynamicParameters();

            parameter.Add("veerf", emp.verficationcode, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("emailof",emp.email, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync("emp_package.updayeverifiy", parameter, commandType: CommandType.StoredProcedure);
            return true;


        }

        public List<emp_dto> getfnamedate(emp_Date emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("startdate", emp.startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("endate", emp.enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<emp_dto> result = dBContext.dbConnection.Query<emp_dto>("emp_api_package.getfnamelnamesalarybetween", parameter, commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
        }

        public List<emp_dto> getfnamelnamedate(emp_Date emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("startdate", emp.startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("enddate", emp.enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<emp_dto> result = dBContext.dbConnection.Query<emp_dto>("emp_api_package.getfnamelnamesalarybetweendate", parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<emp_dto> getfnamelnamesalary()
        {

            IEnumerable<emp_dto> result = dBContext.dbConnection.Query<emp_dto>("emp_api_package.getfnamelnamesalary",commandType:System.Data.CommandType.StoredProcedure);

            return result.ToList();

        }
    }
}
