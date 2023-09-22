using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ECommerce_API.Datas.DTOs.EstoqueDTO;
using ECommerce_API.Datas;
using ECommerce_API.Models;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public EstoquesController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Estoque
        // POST api/Estoques
        /// <summary>
        ///     Cadastra um novo estoque
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Quant_Estoque": 5
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Requisição do estoque. ***Obrigatório**</param>
        /// <returns>Estoque que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostEstoque([FromBody] CreateEstoqueDTO input)
        {
            Estoque estoque = _mapper.Map<Estoque>(input);
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEstoqueById), new { id = estoque.Id_Estoque }, estoque);
        }

        // Read Estoques
        // GET api/Estoques?skip=0&take=50
        /// <summary>
        ///     Obtém todos os estoques
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <returns>Lista de estoques</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEstoque([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var list = _mapper.Map<List<ReadEstoqueDTO>>(_context.Estoques.Skip(skip).Take(take).ToList());
            return Ok(list);
        }

        // Search Estoques
        // GET api/Estoques/{id}
        /// <summary>
        ///     Obtém um estoque de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador do estoque a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Estoque pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEstoqueById([FromRoute] int id)
        {
            var estoque = _context.Estoques.FirstOrDefault(estoque => estoque.Id_Estoque == id);
            if (estoque == null) return NotFound();
            var input = _mapper.Map<ReadEstoqueDTO>(estoque);
            return Ok(input);
        }

        // Update Estoque (PUT)
        // PUT api/Estoques/{id}
        /// <summary>
        ///     Atualiza (todo) o estoque de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Quant_Estoque": 10
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para o estoque. ***Obrigatório**</param>
        /// <param name="id">Identificador do estoque. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutEstoque([FromBody] UpdateEstoqueDTO input, [FromRoute] int id)
        {
            var estoque = _context.Estoques.FirstOrDefault(estoque => estoque.Id_Estoque == id);
            if (estoque == null) return NotFound();
            _mapper.Map(input, estoque);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Estoque (PATCH)
        // PATCH api/Estoques/{id}
        /// <summary>
        ///     Atualiza (1 valor) do estoque de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [
        ///         {
        ///             "path": "/Quant_Estoque",
        ///             "op": "replace",
        ///             "value": 8
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador do estoque. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização do estoque. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchEstoque([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateEstoqueDTO> input)
        {
            var estoque = _context.Estoques.FirstOrDefault(estoque => estoque.Id_Estoque == id);
            if (estoque == null) return NotFound();
            var patchEstoque = _mapper.Map<UpdateEstoqueDTO>(estoque);
            input.ApplyTo(patchEstoque, ModelState);
            if (!TryValidateModel(patchEstoque)) return ValidationProblem(ModelState);
            _mapper.Map(patchEstoque, estoque);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Estoque
        // DELETE api/Estoques/{id}
        /// <summary>
        ///     Apaga o estoque de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador do estoque. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteEstoque([FromRoute] int id)
        {
            var estoque = _context.Estoques.FirstOrDefault(estoque => estoque.Id_Estoque == id);
            if (estoque == null) return NotFound();
            _context.Remove(estoque);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
