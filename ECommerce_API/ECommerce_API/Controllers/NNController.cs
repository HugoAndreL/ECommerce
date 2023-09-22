using AutoMapper;
using ECommerce_API.Datas.DTOs.NN_DTO;
using ECommerce_API.Datas;
using ECommerce_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoProdController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public HistoricoProdController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create relationship N:N Histórico and Produto
        // POST api/HistoricoProd
        /// <summary>
        ///     Cadastra uma nova relação N:N histórico e produto
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "HistoricoId": 1,
        ///         "ProdutoId": 1,
        ///     }
        ///     ```
        ///     *Obs: É necessário ter o **histórico** já criado.*
        ///     
        ///     *Obs: É necessário ter o **produto** já criado.*
        /// </remarks>
        /// <param name="input">Requisição da relação N:N histórico e produto. ***Obrigatório**</param>
        /// <returns>Relação N:N histórico e produto que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostNN([FromBody] CreateHistoricoProdDTO input)
        {
            HistoricoProd NN = _mapper.Map<HistoricoProd>(input);
            _context.HistoricosProds.Add(NN);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetNNById), new { hisId = NN.HistoricoId, prodId = NN.ProdutoId }, NN);
        }

        // Read relationship N:N Histórico and Produto
        // GET api/HistoricoProd?skip=0&take=50
        /// <summary>
        ///     Obtém todas as relações N:N histórico e produto
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de relações N:N histórico e produto</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetNN([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadHistoricoProdDTO>>(_context.HistoricosProds.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search relationship N:N Histórico and Produto
        // GET api/HistoricoProd/{id}
        /// <summary>
        ///     Obtém uma relação N:N histórico e produto de arcodo com seu identificador
        /// </summary>
        /// <param name="hisId">Requisição do identificador do histórico relação N:N histórico e produto será pesquisado. ***Obrigatório**</param>
        /// <param name="prodId">Requisição do identificador do produto ao qual a relação N:N histórico e produto será pesquisado. ***Obrigatório**</param>
        /// <returns>Relação N:N histórico e produto pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{hisId}/{prodId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetNNById([FromRoute] int hisId, [FromRoute] int prodId)
        {
            HistoricoProd NN = _context.HistoricosProds.FirstOrDefault(nn => nn.HistoricoId == hisId && nn.ProdutoId == prodId);
            if (NN != null)
            {
                ReadHistoricoProdDTO output = _mapper.Map<ReadHistoricoProdDTO>(NN);
                return Ok(output);
            }
            return NotFound();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ProdCompController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public ProdCompController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create relationship N:N Produto and Compra
        // POST api/ProdComp
        /// <summary>
        ///     Cadastra uma nova relação N:N produto e compra
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "ProdutoId": 1,
        ///         "CompraId": 1
        ///     }
        ///     ```
        ///     *Obs: É necessário ter o **produto** já criado.*
        ///     
        ///     *Obs: É necessário ter a **compra** já criada.*
        /// </remarks>
        /// <param name="input">Requisição da relação N:N produto e compra. ***Obrigatório**</param>
        /// <returns>Relação N:N produto e compra que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostNN([FromBody] CreateProdCompDTO input)
        {
            ProdComp NN = _mapper.Map<ProdComp>(input);
            _context.ProdutosCompras.Add(NN);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdCompById), new { prodId = NN.ProdutoId, buyId = NN.CompraId }, NN);
        }

        // Read relationship N:N Produto and Compra
        // GET api/ProdComp?skip=0&take=50
        /// <summary>
        ///     Obtém todas as relações N:N produto e compra
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de relações N:N produto e compra</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetNN([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadProdCompDTO>>(_context.ProdutosCompras.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search relationship N:N Produto and Compra
        // GET api/ProdComp/{id}
        /// <summary>
        ///     Obtém uma relação N:N produto e compra de arcodo com seu identificador
        /// </summary>
        /// <param name="prodId">Requisição do identificador do produto ao qual a relação N:N histórico e produto será pesquisado. ***Obrigatório**</param>
        /// <param name="buyId">Requisição do identificador da compra relação N:N histórico e produto será pesquisado. ***Obrigatório**</param>
        /// <returns>Relação N:N produto e compra pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{prodId}/{buyId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProdCompById([FromRoute] int prodId, [FromRoute] int buyId)
        {
            ProdComp NN = _context.ProdutosCompras.FirstOrDefault(nn => nn.ProdutoId == prodId && nn.CompraId == buyId);
            if (NN != null)
            {
                ReadProdCompDTO output = _mapper.Map<ReadProdCompDTO>(NN);
                return Ok(output);
            }
            return NotFound();
        }
    }
}
