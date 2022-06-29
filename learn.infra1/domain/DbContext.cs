using learn.core1.domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.infra1.domain
{
    public class DbContext : IDBContext
    {
        private DbConnection connection;
        private IConfiguration configuration;


        /*when execute project we will inialize value by constructor */
        public DbContext(DbConnection connection, IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbConnection dbConnection
        {/*
          check connection if null or nut if (connection==null)
            check connection if close () i want open connection string 

            new oracleconnection(configuration)this is get connection string 
            in appsettings.json
          
          
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
