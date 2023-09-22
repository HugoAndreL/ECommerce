using AutoMapper;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.CategoriaDTO;
using ECommerce_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Categoria
        // POST api/Categorias
        /// <summary>
        ///     Cadastra uma nova categoria
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Cat": "Tecnologia",
        ///         "Desc_Cat": null
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Requisição da categoria. ***Obrigatório**</param>
        /// <returns>Categoria que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostCategoria([FromBody] CreateCategoriaDTO input)
        {
            Categoria cat = _mapper.Map<Categoria>(input);
            _context.Categorias.Add(cat);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategoriaById), new { id = cat.Id_Cat }, cat);
        }

        // Read Categorias
        // GET api/Categorias?skip=0&take=50
        /// <summary>
        ///     Obtém todas as categorias
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <param name="nameCat">O nome da categoria. *Opcional*</param>
        /// <returns>Lista de categorias</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategoria([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nameCat = null)
        {
            if (nameCat == null)
            {
                var list = _mapper.Map<List<ReadCategoriaDTO>>(_context.Categorias.Skip(skip).Take(take).ToList());
                return Ok(list);
            }
            var search = _mapper.Map<List<ReadCategoriaDTO>>(_context.Categorias.Skip(skip).Take(take).Where(cat => cat.Name_Cat == nameCat).ToList());
            return Ok(search);
        }

        // Search Categorias
        // GET api/Categorias/{id}
        /// <summary>
        ///     Obtém uma categoria de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador da categoria a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Categoria pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategoriaById([FromRoute] int id)
        {
            var cat = _context.Categorias.FirstOrDefault(cat => cat.Id_Cat == id);
            if (cat == null) return NotFound();
            var input = _mapper.Map<ReadCategoriaDTO>(cat);
            return Ok(input);
        }

        // Update Categoria (PUT)
        // PUT api/Categorias/{id}
        /// <summary>
        ///     Atualiza (toda) a categoria de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Cat": "Tecnologia",
        ///         "Desc_Cat": Produtos de tecnologia
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para a categoria. ***Obrigatório**</param>
        /// <param name="id">Identificador da categoria. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutCategoria([FromBody] UpdateCategoriaDTO input, [FromRoute] int id)
        {
            var cat = _context.Categorias.FirstOrDefault(cat => cat.Id_Cat == id);
            if (cat == null) return NotFound();
            _mapper.Map(input, cat);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Categoria (PATCH)
        // PATCH api/Categorias/{id}
        /// <summary>
        ///     Atualiza (1 valor) da Categoria de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Desc_Cat",
        ///             "op": "replace",
        ///             "value": "Produtos referentes a tecnologia"
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador da categoria. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização da categoria. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchCategoria([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateCategoriaDTO> input)
        {
            var cat = _context.Categorias.FirstOrDefault(cat => cat.Id_Cat == id);
            if (cat == null) return NotFound();
            var patchCat = _mapper.Map<UpdateCategoriaDTO>(cat);
            input.ApplyTo(patchCat, ModelState);
            if (!TryValidateModel(patchCat)) return ValidationProblem(ModelState);
            _mapper.Map(patchCat, cat);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Categoria
        // DELETE api/Categorias/{id}
        /// <summary>
        ///     Apaga a categoria de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador da categoria. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCategoria([FromRoute] int id)
        {
            var cat = _context.Categorias.FirstOrDefault(cat => cat.Id_Cat == id);
            if (cat == null) return NotFound();
            _context.Remove(cat);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
