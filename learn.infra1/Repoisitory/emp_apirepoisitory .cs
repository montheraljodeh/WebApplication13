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
