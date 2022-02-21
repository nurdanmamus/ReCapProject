using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper  
    {
        //"SecurityKey": "mysupersecretkeymysupersecretkey" i byte array(simetrik anahtar) haline getiriyor.
        public static SecurityKey CreateSecurityKey(string securityKey)  
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); 
        }
    }
}
