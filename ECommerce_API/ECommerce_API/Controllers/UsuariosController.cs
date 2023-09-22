
using AutoMapper;
using ECommerce_API.Datas.DTOs.UsuarioDTO;
using ECommerce_API.Datas;
using ECommerce_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Usuario
        // POST api/Usuarios
        /// <summary>
        ///     Cadastra um novo usuario
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_User": "Litle John",
        ///         "CPF_User": "12345678911",
        ///         "Email_User": "LitleJohn@email.com",
        ///         "Password_User": "_John"
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Requisição do Usuario. ***Obrigatório**</param>
        /// <returns>Usuario que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostUsuario([FromBody] CreateUsuarioDTO input)
        {
            Usuario user = _mapper.Map<Usuario>(input);
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsuarioById), new { id = user.Id_User }, user);
        }

        // Read Usuarios
        // GET api/Usuarios?skip=0&take=50
        /// <summary>
        ///     Obtém todos os usuarios
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <param name="nameUser">O nome do usuario. *Opcional*</param>
        /// <returns>Lista de Usuarios</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuario([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nameUser = null)
        {
            if (nameUser == null)
            {
                var list = _mapper.Map<List<ReadUsuarioDTO>>(_context.Usuarios.Skip(skip).Take(take).ToList());
                return Ok(list);
            }
            var search = _mapper.Map<List<ReadUsuarioDTO>>(_context.Usuarios.Skip(skip).Take(take).Where(user => user.Name_User == nameUser).ToList());
            return Ok(search);
        }

        // Search Usuario
        // GET api/Usuarios/{id}
        /// <summary>
        ///     Obtém um usuario de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador do usuario a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Usuario pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuarioById([FromRoute] int id)
        {
            var user = _context.Usuarios.FirstOrDefault(user => user.Id_User == id);
            if (user == null) return NotFound();
            var input = _mapper.Map<ReadUsuarioDTO>(user);
            return Ok(input);
        }

        // Update Usuario (PUT)
        // PUT api/Usuarios/{id}
        /// <summary>
        ///     Atualiza (todo) o usuario de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_User": "Litle John",
        ///         "CPF_User": "12345678911",
        ///         "Email_User": "LiJohn@email.com",
        ///         "Password_User": "_John"
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para o usuario. ***Obrigatório**</param>
        /// <param name="id">Identificador do usuario. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutUsuario([FromBody] UpdateUsuarioDTO input, [FromRoute] int id)
        {
            var user = _context.Usuarios.FirstOrDefault(user => user.Id_User == id);
            if (user == null) return NotFound();
            _mapper.Map(input, user);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Usuario (PATCH)
        // PATCH api/Usuarios/{id}
        /// <summary>
        ///     Atualiza (1 valor) do usuario de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Email_User",
        ///             "op": "replace",
        ///             "value": "li.john@email.com"
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador do usuario. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização do usuario. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchUsuario([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateUsuarioDTO> input)
        {
            var user = _context.Usuarios.FirstOrDefault(user => user.Id_User == id);
            if (user == null) return NotFound();
            var patchUser = _mapper.Map<UpdateUsuarioDTO>(user);
            input.ApplyTo(patchUser, ModelState);
            if (!TryValidateModel(patchUser)) return ValidationProblem(ModelState);
            _mapper.Map(patchUser, user);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Usuario
        // DELETE api/Usuarios/{id}
        /// <summary>
        ///     Apaga o usuario de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador do usuario. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUsuario([FromRoute] int id)
        {
            var user = _context.Usuarios.FirstOrDefault(user => user.Id_User == id);
            if (user == null) return NotFound();
            _context.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
