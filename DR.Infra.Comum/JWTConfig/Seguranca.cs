using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DR.Infra.Comum.JWTConfig
{
    public class Seguranca
    {
        public Seguranca()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }

        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }
    }
}
