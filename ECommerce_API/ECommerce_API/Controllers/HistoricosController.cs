using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.HistoricoDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricosController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public HistoricosController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Histórico
        // POST api/Historicos
        /// <summary>
        ///     Cadastra um novo historico
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="input">Requisição do historico. ***Obrigatório**</param>
        /// <returns>Historico que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostHistorico([FromBody] CreateHistoricoDTO input)
        {
            Historico his = _mapper.Map<Historico>(input);
            _context.Historicos.Add(his);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetHistoricoById), new { id = his.Id_Historico }, his);
        }

        // Read Histórico
        // GET api/Historicos?skip=0&take=50
        /// <summary>
        ///     Obtém todos os Históricos
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de históricos</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetHistorico([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadHistoricoDTO>>(_context.Historicos.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search Histórico
        // GET api/Historicos/{id}
        /// <summary>
        ///     Obtém um Historico de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador da historico a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Historico pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetHistoricoById([FromRoute] int id)
        {
            var his = _context.Historicos.FirstOrDefault(his => his.Id_Historico == id);
            if (his == null) return NotFound();
            var input = _mapper.Map<ReadHistoricoDTO>(his);
            return Ok(input);
        }
    }
}
