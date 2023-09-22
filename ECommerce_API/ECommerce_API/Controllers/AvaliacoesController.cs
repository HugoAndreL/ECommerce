using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.AvaliacaoDTO;
using ECommerce_API.Models;

namespace PDV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public AvaliacoesController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Avaliacao
        // POST api/Avaliacoes
        /// <summary>
        ///     Cadastra uma nova avaliação
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Title_Rate": "Ótimo produto",
        ///         "Star_Rate": 5,
        ///         "Comment_Rate": "Me ajudou muito",
        ///         "ClienteId": 1,
        ///         "ProdutoId": 1
        ///     }
        ///     ```
        ///     *Obs: É necessário ter o **cliente** ja criado.*
        ///     
        ///     *Obs: É necessário ter o **produto** ja criado.*
        /// </remarks>
        /// <param name="input">Requisição da avaliação. ***Obrigatório**</param>
        /// <returns>Avaliação que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostRating([FromBody] CreateAvaliacaoDTO input)
        {
            Avaliacao rate = _mapper.Map<Avaliacao>(input);
            _context.Avaliacoes.Add(rate);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRateById), new { id = rate.Id_Rate }, rate);
        }

        // Read Avaliações
        // GET api/Avaliacoes?skip=0&take=50
        /// <summary>
        ///     Obtém todas as Avaliações
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de avaliações</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetRate([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadAvaliacaoDTO>>(_context.Avaliacoes.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search Avaliacao
        // GET api/Avaliacao/{id}
        /// <summary>
        ///     Obtém uma avaliação de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador da avaliação a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Avaliação pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetRateById([FromRoute] int id)
        {
            var rate = _context.Avaliacoes.FirstOrDefault(rate => rate.Id_Rate == id);
            if (rate == null) return NotFound();
            var input = _mapper.Map<ReadAvaliacaoDTO>(rate);
            return Ok(input);
        }
    }
}
