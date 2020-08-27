using DR.Infra.Seguranca.JWTConfig;
using DR.ModeloVisaoModelo.Identificacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DR.Api.Controllers.BaseContoller
{
    public class BaseController: ControllerBase
    {
        protected object GetToken([FromBody] VisaoModeloUsuario usuario,
                         [FromServices]SegurancaJWT signingConfigurations,
                        [FromServices]ConfiguracaoToken tokenConfigurations)
        {
            try
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                       new GenericIdentity(usuario.Login, "login"),
                       new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
                       }
                   );


                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromMinutes(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();

                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

                var token = handler.WriteToken(securityToken);


                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
