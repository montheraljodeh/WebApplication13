using Dapper;
using learn.core1.Data;
using learn.core1.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using learn.infra1.domain;
using System.Linq;
using learn.core1.domain;

namespace learn.infra1.Repoisitory
{
    public class categoreyrepoisitorycs : Icategoreyrepoisitory
    {
        private readonly IDBContext context;
        public categoreyrepoisitorycs(IDBContext context)
        {
            this.context = context;


        }
        public string deletecat(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", id, dbType: DbType.Int32, direction:ParameterDirection.Input);

            var result = context.dbConnection.ExecuteAsync("categorey_package_api.deletecat", parameter, commandType: CommandType.StoredProcedure);

            return "VALID";
        }

        public List<categorey_api> getall()
        {
            IEnumerable<categorey_api> result = context.dbConnection.Query<categorey_api>("categorey_package_api.getallcat",commandType:CommandType.StoredProcedure);

            return result.ToList();
        }

        public categorey_api getbyidcat(int id)
        {

            var parameter = new DynamicParameters();
            parameter.Add("idofcat", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            //  IEnumerable<categorey_api> result = context.dbConnection.Query<categorey_api>("categorey_package_api.getbyid",parameter,commandType:CommandType.StoredProcedure);

            return new categorey_api();
            //return result.FirstOrDefault();
        }

        public string insertcat(categorey_api categorey_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("categoreyname", categorey_Api.catname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("dateofcat", categorey_Api.catdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = context.dbConnection.ExecuteAsync("categorey_package_api.insertcat", parameter, commandType: CommandType.StoredProcedure);

            return "VALID";
        }

        public string updatecat(categorey_api categorey_Api)
        {

            var parameter = new DynamicParameters();
            parameter.Add("idofcat", categorey_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("categoreyname", categorey_Api.catname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("dateofcat", categorey_Api.catdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = context.dbConnection.ExecuteAsync("categorey_package_api.updatecat", parameter, commandType: CommandType.StoredProcedure);

            return "VALID";
        }
    }
}
