using AutoMapper;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.ClienteDTO;
using ECommerce_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ECommerce_API.Datas.DTOs.CompraDTO;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public ComprasController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Compra
        // POST api/Compras
        /// <summary>
        ///     Cadastra uma nova compra
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "ClienteId": 1,
        ///         "HistoricoId": 1,
        ///         "UsuarioId": 1,
        ///         "QuantProd_Compra": 1,
        ///         "Total_Compra": 20.00,
        ///         "MetPag_Compra": 1
        ///     }
        ///     ```
        ///     *Obs: É necessário ter o **cliente** ja criado.*
        ///     
        ///     *Obs: É necessário ter o **histórico** ja criado.*
        ///     
        ///     *Obs: É necessário ter o **usuário** ja criado.*
        /// </remarks>
        /// <param name="input">Requisição da compra. ***Obrigatório**</param>
        /// <returns>Compra que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostCliente([FromBody] CreateCompraDTO input)
        {
            Compra compra = _mapper.Map<Compra>(input);
            _context.Compras.Add(compra);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCompraById), new { id = compra.Id_Compra }, compra);
        }

        // Read Compra
        // GET api/Compra?skip=0&take=50
        /// <summary>
        ///     Obtém todas as compras
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de compras</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCliente([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadCompraDTO>>(_context.Compras.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search Compra
        // GET api/Compras/{id}
        /// <summary>
        ///     Obtém uma compra de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador da compra a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Compra pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCompraById([FromRoute] int id)
        {
            var compra = _context.Compras.FirstOrDefault(compra => compra.Id_Compra == id);
            if (compra == null) return NotFound();
            var input = _mapper.Map<ReadCompraDTO>(compra);
            return Ok(input);
        }

        // Update Compra (PUT)
        // PUT api/Compra/{id}
        /// <summary>
        ///     Atualiza (toda) a compra de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Client": "Teste00",
        ///         "Mail_Client": "test@email.com",
        ///         "Password_Client": "123456",
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para a compra. ***Obrigatório**</param>
        /// <param name="id">Identificador da compra. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutCompra([FromBody] UpdateClienteDTO input, [FromRoute] int id)
        {
            var compra = _context.Compras.FirstOrDefault(buy => buy.Id_Compra == id);
            if (compra == null) return NotFound();
            _mapper.Map(input, compra);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Compra (PATCH)
        // PATCH api/Compras/{id}
        /// <summary>
        ///     Atualiza (1 valor) da compra de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Total_Compra",
        ///             "op": "replace",
        ///             "value": 50.00
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador da compra. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização da compra. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchCompra([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateClienteDTO> input)
        {
            var compra = _context.Compras.FirstOrDefault(buy => buy.Id_Compra == id);
            if (compra == null) return NotFound();
            var patch = _mapper.Map<UpdateClienteDTO>(compra);
            input.ApplyTo(patch, ModelState);
            if (!TryValidateModel(patch)) return ValidationProblem(ModelState);
            _mapper.Map(patch, compra);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Compra
        // DELETE api/Compra/{id}
        /// <summary>
        ///     Apaga a compra de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador da compra. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCompra([FromRoute] int id)
        {
            var compra = _context.Compras.FirstOrDefault(buy => buy.Id_Compra == id);
            if (compra == null) return NotFound();
            _context.Remove(compra);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
