using Domain.Interfaces.IClientes;
using Domain.Interfaces.ISecretarias;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Domain.Interfaces.IVeterinario;
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
    /// <summary>
    /// Controller para adicionar novos usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager; // Adicionando o RoleManager
        private readonly InterfaceUsuarioSistemaClinica _interfaceUsuarioSistemaClinica;
        private readonly InterfaceClientes _interfaceClientes;
        private readonly InterfaceSecretarias _interfaceSecretarias;
        private readonly InterfaceVeterinario _interfaceVeterinario;


        public UsersController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager, 
            InterfaceUsuarioSistemaClinica interfaceUsuarioSistemaClinica,
            InterfaceClientes interfaceClientes,
            InterfaceSecretarias interfaceSecretarias,
            InterfaceVeterinario interfaceVeterinario) // Injetando o RoleManager no construtor
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; // Atribuindo RoleManager ao campo
            _interfaceUsuarioSistemaClinica = interfaceUsuarioSistemaClinica;
            _interfaceClientes = interfaceClientes; // Atribuir a interface
            _interfaceSecretarias = interfaceSecretarias;
            _interfaceVeterinario = interfaceVeterinario;
        }


        /// <summary>
        /// Adiciona um novo usuário ao sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/AdicionaUsuario
        ///     {
        ///         "email": "usuario@exemplo.com",
        ///         "senha": "senha",
        ///         "cpf": "123.456.789-10",
        ///         "role": "Usuario" // Role do usuário (papel)
        ///     }
        ///     
        /// Retorna "Usuario Adicionado!" se o usuário for criado com sucesso.
        /// </remarks>
        /// <param name="loginDTO">Dados do novo usuário.</param>
        /// <returns>Mensagem de sucesso ou lista de erros, se houver.</returns>
        /// <response code="200">Retorna "Usuario Adicionado!" se o usuário for criado com sucesso.</response>
        /// <response code="400">Retorna "Falta alguns dados" se os campos email, senha ou cpf estiverem em branco.</response>
        /// <response code="401">Retorna a lista de erros se a criação do usuário falhar.</response>
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] LoginDTO loginDTO)
        {
            if(string.IsNullOrWhiteSpace(loginDTO.email) ||string.IsNullOrWhiteSpace(loginDTO.senha) || string.IsNullOrWhiteSpace(loginDTO.cpf))
            {
                return Ok("Falta alguns dados");
            }
            var user = new ApplicationUser
            {
                Email = loginDTO.email,
                UserName  = loginDTO.email,
                CPF = loginDTO.cpf,
                Role= loginDTO.role
                
            };

            var result = await _userManager.CreateAsync(user, loginDTO.senha);
            var createRoleResult = await _roleManager.CreateAsync(new IdentityRole(loginDTO.role));
            var usuarioRoleResult = _userManager.AddToRoleAsync(user, loginDTO.role).Result;

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
                // Adicione o usuário ao sistema da clínica depois de adicionar ao sistema principal
                var usuarioSistema = new UsuarioSistemaClinica
                {
                    Nome = loginDTO.nome, // Pode querer usar algo diferente para o nome
                    Email = loginDTO.email,
                    Role = loginDTO.role, // Assumindo que LoginDTO tem uma propriedade "role" correspondente
                    CPF = loginDTO.cpf
                };

                await _interfaceUsuarioSistemaClinica.Add(usuarioSistema); 

                if (usuarioSistema.Role.ToLower() == "cliente")
                {
                    var cliente = new Cliente
                    {
                        Nome = usuarioSistema.Nome,
                        Email = usuarioSistema.Email,
                        // Adicione outros campos conforme necessário.
                        ID_Usuario = usuarioSistema.ID_Usuario
                    };

                    await _interfaceClientes.Add(cliente);
                }
                if (usuarioSistema.Role.ToLower() == "secretaria")
                {
                    var secretaria = new Secretaria
                    {
                        Nome = usuarioSistema.Nome,
                        Email = usuarioSistema.Email,
                        ID_Usuario = usuarioSistema.ID_Usuario,
                        Endereco = "",
                        Telefone = ""

                        // You may need to provide values for other properties like Endereco and Telefone too
                    };

                    await _interfaceSecretarias.Add(secretaria);
                    // I assumed that you might have an _interfaceSecretaria similar to _interfaceClientes for managing 'Secretaria' entities.
                }
                if (usuarioSistema.Role.ToLower() == "veterinario")
                {
                    var veterinario = new Veterinario
                    {
                        Nome = usuarioSistema.Nome,
                        Email = usuarioSistema.Email,
                        ID_Usuario = usuarioSistema.ID_Usuario,
                        Especializacao = "",
                        Telefone = ""

                        // You may need to provide values for other properties like Endereco and Telefone too
                    };
                    await _interfaceVeterinario.Add(veterinario);
                }
                return Ok("Usuario Adicionado!");
            }
            else
            {
                return Ok("erro ao confirmar cadastro de usuário!");
            }

        }


        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 401)]
        [HttpPost("/api/ExcluirUsuarioId")]
        public async Task<IActionResult> ExcluirUsuarioId([FromBody] UserIdDTO userIdDTO)
            {
            // Localizar o usuário pelo ID fornecido
            var user = await _userManager.FindByIdAsync(userIdDTO.id);

            // Se o usuário não for encontrado, retornar um erro
            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            // Tenta excluir o usuário
            var result = await _userManager.DeleteAsync(user);

            // Se a tentativa de exclusão não for bem-sucedida, retornar um erro
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.First().Description);
            }

            // Se o usuário foi excluído com sucesso, retorna uma mensagem de confirmação
            return Ok("Usuário excluído com sucesso!");
        }



        [HttpGet("/api/ListarUsuarios")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationUser>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var users = _userManager.Users.ToList();  // Pode ser que você queira fazer isso de forma assíncrona dependendo da sua implementação

                if (users == null || !users.Any())
                {
                    return NotFound("Nenhum usuário encontrado.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar usuários: {ex.Message}");
            }
        }


    }
}
