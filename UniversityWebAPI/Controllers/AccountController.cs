using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebAPI.Helpers;
using UniversityWebAPI.Models;
using UniversityWebAPI.Models.DataModels;

namespace UniversityWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly JWTSettings _jwtSetting;

        public AccountController(JWTSettings jwtSetting)
        {
            _jwtSetting = jwtSetting;
        }

        //metodo de usuarios que podamos registrar

        //*Lista de ususarios de prueba
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "German@viola.com",
                UserName = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "Juana@gmail.com",
                UserName = "User 1",
                Password = "123"
            }
        };

        //generar un token a un usuario
        [HttpPost]
        public IActionResult GetToken(UserLogin userlogin)
        {
            try
            {
                var token = new UserTokens(); //instanciamos un token de usuario
                //validamos que el usuario obtenido coincida con el contexto (bbdd)
                var valid = Logins.Any(user => 
                user.UserName.Equals(userlogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (valid)
                {
                    var user = Logins.FirstOrDefault(user => 
                    user.UserName.Equals(userlogin.UserName, StringComparison.OrdinalIgnoreCase));
                    //hasta aqui ya tenemos nuestro usuario validado, ahora generamos el token

                    token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName = user.UserName,
                        EmailId = user.Email,
                        Id = user.Id,
                        Guid = Guid.NewGuid()

                    }, _jwtSetting);

                }
                else
                {
                    return BadRequest("Wrong Credencial");
                }
                return Ok(token);
            }
            catch (Exception ex)
            {

                throw new Exception("GetToken Error", ex);
            }
        }

        //autenticar usuarios
        //con esto estamos agregando a nuestro programa que solo se podran acceder a esta ruta
        //si pasa y cumple con estos criterios de autenticacion
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator") ]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }


    }
}
