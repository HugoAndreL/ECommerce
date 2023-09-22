using AutoMapper;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.ClienteDTO;
using ECommerce_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PDV_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public ClientesController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Cliente
        // POST api/Clientes
        /// <summary>
        ///     Cadastra um novo cliente
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Client": "JohnDoe",
        ///         "Mail_Client": "JohnDoe@mail.com",
        ///         "Password_Client": "12345"
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Requisição do Cliente. ***Obrigatório**</param>
        /// <returns>Cliente que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostCliente([FromBody] CreateClienteDTO input)
        {
            Cliente client = _mapper.Map<Cliente>(input);
            _context.Clientes.Add(client);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteById), new { id = client.Id_Client }, client);
        }

        // Read Clientes
        // GET api/Clientes?skip=0&take=50
        /// <summary>
        ///     Obtém todos os clientes
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <param name="nameClient">O nome do cliente. *Opcional*</param>
        /// <returns>Lista de clientes</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCliente([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nameClient = null)
        {
            if (nameClient == null)
            {
                var list = _mapper.Map<List<ReadClienteDTO>>(_context.Clientes.Skip(skip).Take(take).ToList());
                return Ok(list);
            }
            var search = _mapper.Map<List<ReadClienteDTO>>(_context.Clientes.Skip(skip).Take(take).Where(client => client.Name_Client == nameClient).ToList());
            return Ok(search);
        }

        // Search Clientes
        // GET api/Clientes/{id}
        /// <summary>
        ///     Obtém um cliente de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador do cliente a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Cliente pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetClienteById([FromRoute] int id)
        {
            var client = _context.Clientes.FirstOrDefault(client => client.Id_Client == id);
            if (client == null) return NotFound();
            var input = _mapper.Map<ReadClienteDTO>(client);
            return Ok(input);
        }

        // Update Cliente (PUT)
        // PUT api/Clientes/{id}
        /// <summary>
        ///     Atualiza (todo) o cliente de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Client": "John Doe",
        ///         "Mail_Client": "JohnDoe@email.com",
        ///         "Password_Client": "123456"
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para o cliente. ***Obrigatório**</param>
        /// <param name="id">Identificador do cliente. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutCliente([FromBody] UpdateClienteDTO input, [FromRoute] int id)
        {
            var client = _context.Clientes.FirstOrDefault(client => client.Id_Client == id);
            if (client == null) return NotFound();
            _mapper.Map(input, client);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Cliente (PATCH)
        // PATCH api/Clientes/{id}
        /// <summary>
        ///     Atualiza (1 valor) do cliente de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Name_Client",
        ///             "op": "replace",
        ///             "value": "John Richard"
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador do cliente. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização do cliente. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchCliente([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateClienteDTO> input)
        {
            var client = _context.Clientes.FirstOrDefault(client => client.Id_Client == id);
            if (client == null) return NotFound();
            var patchClient = _mapper.Map<UpdateClienteDTO>(client);
            input.ApplyTo(patchClient, ModelState);
            if (!TryValidateModel(patchClient)) return ValidationProblem(ModelState);
            _mapper.Map(patchClient, client);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Cliente
        // DELETE api/Clientes/{id}
        /// <summary>
        ///     Apaga o cliente de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador do cliente. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCliente([FromRoute] int id)
        {
            var client = _context.Clientes.FirstOrDefault(client => client.Id_Client == id);
            if (client == null) return NotFound();
            _context.Remove(client);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
