

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniversityWebAPI.Models;

namespace UniversityWebAPI.Helpers
{
    public static class JwtHelpers
    {
        //metodo para generar los claims
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
           
            //** hacemos una lista de claim o es como una tabla de claims y agrega alque pasen por parametro
            List<Claim> Listclaims = new List<Claim>()
            {
                new Claim("Id",userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MM  ddd dd yyyy HH:mm:ss tt"))
            };

            //** definimos los diferentes roles que tendran los usuarios
            if(userAccounts.UserName == "Admin")
            {
                Listclaims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }else if(userAccounts.UserName =="User 1")
            {
                Listclaims.Add(new Claim(ClaimTypes.Role, "User"));
                Listclaims.Add(new Claim("UserOnly", "User 1"));
            }
            
            //devolvemos los claims
            return Listclaims;

        }
        

        //Metodo para generar un nuevo Id y pasarse lo a los claims
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccouts, out Guid Id)
        {
            Id = Guid.NewGuid(); //generamos un nuevo Id

            //se lo pasamos al metodo anterior
            return GetClaims(userAccouts,Id);
        }

        //Obtener el token
        public static UserTokens GetTokenKey(UserTokens model, JWTSettings jWTSetting)
        {
            try
            {
                var userToken = new UserTokens();

                //verificar que el model no este null
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                //PASO 1 necesitamos: llave secreta, tiempo expiracion y la validacion del token

                //obtenemos o generamos la firma o llave secreta
                var key = System.Text.Encoding.ASCII.GetBytes(jWTSetting.LlaveFirmaDelEmisor);

                //esta variable almacenara el id que se generara al llamar el metodo getClaims 
                Guid Id;

                //poner la expiracion del tiken
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                //validacion del tiken: será valido por 1 dia
                userToken.ValidezDelToken = expireTime.TimeOfDay;

                //PASO 2: generar el JWtoken
                var jwToken = new JwtSecurityToken(

                    //le especificamos la siguiente informacion
                    issuer: jWTSetting.Emisor,
                    audience: jWTSetting.AudienciaValida,
                    claims: GetClaims(model, out Id),

                     //el NotBefore es el tiempo de expiracion el que no puede estr antes de cierto momento
                     notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                     //es decir el token no va a expirar antes de este tiempo cuando se genere

                     expires: new DateTimeOffset(expireTime).DateTime, //le pasamos cuando es que debe de expirar
                     signingCredentials: new SigningCredentials( //estructura de la firma
                         new SymmetricSecurityKey(key), //le pasamos la clave
                         SecurityAlgorithms.HmacSha256) //le indicamos el algoritmo que va a cifrar la info
                     );

                //le pasamos todo al token para generarlo
                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.Guid = model.Guid; 

                return userToken;


            }
            catch (Exception exception)
            {

                throw new Exception("Error generando el Jwt", exception);
            }
        }
    }
}
