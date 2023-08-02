using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager; // Adicionando o RoleManager

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) // Injetando o RoleManager no construtor
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; // Atribuindo RoleManager ao campo
        }
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.email) ||string.IsNullOrWhiteSpace(login.senha) || string.IsNullOrWhiteSpace(login.cpf))
            {
                return Ok("Falta alguns dados");
            }
            var user = new ApplicationUser
            {
                Email = login.email,
                UserName  = login.email,
                CPF = login.cpf,

            };

            var result = await _userManager.CreateAsync(user, login.senha);
            var createRoleResult = await _roleManager.CreateAsync(new IdentityRole("cliente"));
            var usuarioRoleResult = _userManager.AddToRoleAsync(user, "cliente").Result;

            if(result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            //geraçaõ de confirmação 
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code =  WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno do email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_return = await _userManager.ConfirmEmailAsync(user, code);

            if (response_return.Succeeded)
            {
                return Ok("Usuario Adicionado! ");
            }
            else
            {
                return Ok("erro ao confirmar cadastro de usuário!");
            }

        }
    }
}
