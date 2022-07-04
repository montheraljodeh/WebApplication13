using learn.core1.domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.infra1.domain
{
    /*
     each table across to layers repoisitory layer service layer 
    controller ui layer 
    each table repoisitory service and controller

    course 
    course repoisitory 
    course service 
    course controller 
    each table across to onion pattern 
     */



    public class DbContext : IDBContext
    {
        private DbConnection connection;
        private IConfiguration configuration;


        /*when execute project we will inialize value by constructor */
        public DbContext( IConfiguration configuration)
        {
        
            this.configuration = configuration;

        }

        public DbConnection dbConnection
        {/*
          check connection if null or nut if (connection==null)
            check connection if close () i want open connection string 

            new oracleconnection(configuration)this is get connection string 
            in appsettings.json
          
            create table course_api(
id int primary key,
coursename VARCHAR(255),
courseprice int)

--defineation without body
create or replace package course_package_api as
procedure getallcourse;
procedure createinsertcourse(idofcourse in int,nameofcourse in varchar,price in int);
procedure deletecourse(idofcourse in int);
end course_package_api;
--with body
create or replace package body course_package_api as
procedure getallcourse
as
c_all sys_refcursor;
begin
open c_all for
select * from course_api;
dbms_sql.return_result(c_all);
end getallcourse;
PROCEDURE createinsertcourse(idofcourse in int,nameofcourse in varchar,price in int)
is
begin
            
insert into course_api values(idofcourse,nameofcourse,price);
commit;
end createinsertcourse;
procedure deletecourse(idofcourse in int)
is
begin
DELETE from course_api where id=idofcourse;
commit;
end deletecourse;

end course_package_api;


          
          */
            get
            {
                if(connection==null)
                {
                    
                    connection = new OracleConnection(configuration["ConnectionStrings:DBConnectionString"]);

                    connection.Open();
                }else if (connection.State !=System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
        }
    }
}
