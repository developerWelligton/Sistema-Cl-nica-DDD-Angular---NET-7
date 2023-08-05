using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Token;
using WebApi.Models;
using System.Security.Claims;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller para autenticação e geração de tokens JWT.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Cria um token JWT para autenticação do usuário entrar no sistema da clínica petz.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/CreateToken
        ///     {
        ///         "Email": "usuario@exemplo.com",
        ///         "Password": "senha"
        ///     }
        ///     
        /// O token gerado será retornado na resposta.
        /// </remarks>
        /// <param name="Input">Dados de login do usuário.</param>
        /// <returns>O token JWT gerado se a autenticação for bem-sucedida.</returns>
        /// <response code="200">Retorna o token JWT se a autenticação for bem-sucedida.</response>
        /// <response code="401">Retorna não autorizado se a autenticação falhar.</response>
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
        {
            if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Retrieve user information
                var user = await _userManager.FindByEmailAsync(Input.Email);

                if (user == null)
                {
                    return Unauthorized();
                }

                // Retrieve user's roles
                var userRoles = await _userManager.GetRolesAsync(user);

                var tokenBuilder = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                    .AddSubject("Canal Dev Net Core")
                    .AddIssuer("Teste.Securiry.Bearer")
                    .AddAudience("Teste.Securiry.Bearer")
                    .AddExpiry(5);

                // Add role claims
                foreach (var role in userRoles)
                {
                    tokenBuilder.AddClaim(ClaimTypes.Role, role);
                }

                var token = tokenBuilder.Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
