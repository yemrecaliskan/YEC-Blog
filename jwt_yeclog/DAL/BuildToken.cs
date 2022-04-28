﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jwt_yeclog.DAL
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("yeclogblogprojesijwt");
            SymmetricSecurityKey key = new(bytes);
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new();
            return handler.WriteToken(token);
        }
    }
}
