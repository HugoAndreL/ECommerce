using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.FonecedorDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public FornecedoresController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create fornecedor
        // POST api/Fornecedores
        /// <summary>
        ///     Cadastra um novo fornecedor
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Nome_Fornecedor": "John Doe",
        ///         "Desc_Fornecedor": null,
        ///         "Contato_Fornecedor": "john.doe@mail",
        ///         "Social_Fornecedor": null,
        ///         "EstoqueId": 1
        ///     }
        ///     ```
        ///     *Obs: É necessário ter o **estoque** já criado.*
        /// </remarks>
        /// <param name="input">Requisição do fornecedor. ***Obrigatório**</param>
        /// <returns>Fornecedor que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostFornecedor([FromBody] CreateFornecedorDTO input)
        {
            Fornecedor forn = _mapper.Map<Fornecedor>(input);
            _context.Fornecedores.Add(forn);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFornecedorById), new { id = forn.Id_Fornecedor }, forn);
        }

        // Read Fornecedores
        // GET api/Fornecedores?skip=0&take=50
        /// <summary>
        ///     Obtém todos os fornecedores
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <param name="nameForn">O nome do fornecedor. *Opcional*</param>
        /// <returns>Lista de fornecedores</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFornecedor([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nameForn = null)
        {
            if (nameForn == null)
            {
                var list = _mapper.Map<List<ReadFornecedorDTO>>(_context.Fornecedores.Skip(skip).Take(take).ToList());
                return Ok(list);
            }
            var search = _mapper.Map<List<ReadFornecedorDTO>>(_context.Fornecedores.Skip(skip).Take(take).Where(forn => forn.Nome_Fornecedor == nameForn).ToList());
            return Ok(search);
        }

        // Search Fornecedores
        // GET api/Fornecedores/{id}
        /// <summary>
        ///     Obtém um fornecedor de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador do fornecedor a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Fornecedor pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFornecedorById([FromRoute] int id)
        {
            var forn = _context.Fornecedores.FirstOrDefault(forn => forn.Id_Fornecedor == id);
            if (forn == null) return NotFound();
            var input = _mapper.Map<ReadFornecedorDTO>(forn);
            return Ok(input);
        }

        // Update Fornecedor (PUT)
        // PUT api/Fornecedores/{id}
        /// <summary>
        ///     Atualiza (todo) o fornecedor de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Nome_Fornecedor": "John Doe",
        ///         "Desc_Fornecedor": null,
        ///         "Contato_Fornecedor": "john.doe@mail.com",
        ///         "Social_Fornecedor": null,
        ///     }
        ///     ```
        /// </remarks>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutFornecedor([FromBody] UpdateFornecedorDTO input, [FromRoute] int id)
        {
            var prod = _context.Fornecedores.FirstOrDefault(forn => forn.Id_Fornecedor == id);
            if (prod == null) return NotFound();
            _mapper.Map(input, prod);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Fornecedor (PATCH)
        // PATCH api/Fornecedores/{id}
        /// <summary>
        ///     Atualiza (1 valor) do fornecedor de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Contato_Fornecedor",
        ///             "op": "replace",
        ///             "value": "john.doe@email.com"
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador do fornecedor. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização do fornecedor. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchFornecedor([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateFornecedorDTO> input)
        {
            var forn = _context.Fornecedores.FirstOrDefault(forn => forn.Id_Fornecedor == id);
            if (forn == null) return NotFound();
            var patchProd = _mapper.Map<UpdateFornecedorDTO>(forn);
            input.ApplyTo(patchProd, ModelState);
            if (!TryValidateModel(patchProd)) return ValidationProblem(ModelState);
            _mapper.Map(patchProd, forn);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Fornecedor
        // DELETE api/Fornecedores/{id}
        /// <summary>
        ///     Apaga o Fornecedor de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador do Fornecedor. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteFornecedor([FromRoute] int id)
        {
            var forn = _context.Fornecedores.FirstOrDefault(forn => forn.Id_Fornecedor == id);
            if (forn == null) return NotFound();
            _context.Remove(forn);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
