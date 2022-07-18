using learn.core1.Data;
using learn.core1.service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace learn.infra1.service
{
    /*
     create table login_api(
id int primary key,
username varchar(255),
password varchar(255),
rolename varchar(255));

create or replace package loginapi_package
as
procedure Auth (username1 in varchar,password1 in varchar);
end loginapi_package;


create or replace package body loginapi_package
as
procedure Auth (username1 in varchar,password1 in varchar)
as
c_all SYS_REFCURSOR;
BEGIN
OPEN c_all  FOR
Select * FROM login_api where username=username1 and password=password1; 
DBMS_SQL.RETURN_RESULT(c_all);
end Auth;
END loginapi_package;



     
     */
    public class Authenticationservice : IAuthenticationservice
    {
        //15 min
        public string Authentication_jwt(login_api login)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Email, "monther@gmail.com"),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Name, 1.ToString())

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }
    }
}
