using AutoMapper;
using ECommerce_API.Datas.DTOs.EnderecoDTO;
using ECommerce_API.Datas;
using ECommerce_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public EnderecosController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Endereco
        // POST api/Enderecos
        /// <summary>
        ///     Cadastra um novo endereço
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "EstoqueId": 1,
        ///         "CEP_Endereco": "12345678911234567892",
        ///         "Desc_Endereco": null
        ///     }
        ///     ```
        ///     *Obs: É necessário ter o **estoque** ja criado.*
        /// </remarks>
        /// <param name="input">Requisição do endereço. ***Obrigatório**</param>
        /// <returns>Endereço que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostEndereco([FromBody] CreateEnderecoDTO input)
        {
            Endereco end = _mapper.Map<Endereco>(input);
            _context.Enderecos.Add(end);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnderecoById), new { id = end.Id_Endereco }, end);
        }

        // Read Enderecos
        // GET api/Enderecos?skip=0&take=50
        /// <summary>
        ///     Obtém todas os Enderecos
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de endereços</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEndereco([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search Endereco
        // GET api/Enderecos/{id}
        /// <summary>
        ///     Obtém um endereço de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador do endereço a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Endereço pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEnderecoById([FromRoute] int id)
        {
            var end = _context.Enderecos.FirstOrDefault(end => end.Id_Endereco == id);
            if (end == null) return NotFound();
            var input = _mapper.Map<ReadEnderecoDTO>(end);
            return Ok(input);
        }
    }
}
