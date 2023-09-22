using AutoMapper;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.ProdutoDTO;
using ECommerce_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public ProdutosController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Produto
        // POST api/Produtos
        /// <summary>
        ///     Cadastra um novo produto
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "CodeBar_Prod": "123456789112",
        ///         "Name_Prod": "Monitor",
        ///         "CategoriaId": 1,
        ///         "Val_Prod": 35.00,
        ///         "EstoqueId": 1,
        ///         "FornecedorId": 1
        ///     }
        ///     ```
        ///     *Obs: É necessário ter a **categoria** já criado.*
        ///     
        ///     *Obs: É necessário ter o **estoque** já criado.*
        ///     
        ///     *Obs: É necessário ter o **fornecedor** já criado.*
        /// </remarks>
        /// <param name="input">Requisição do produto. ***Obrigatório**</param>
        /// <returns>Produto que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostProduto([FromBody] CreateProdutoDTO input)
        {
            Produto produto = _mapper.Map<Produto>(input);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id_Prod }, produto);
        }

        // Read Produtos
        // GET api/Produtos?skip=0&take=50
        /// <summary>
        ///     Obtém todos os produtos
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <param name="take">Requisição para pegar um numero de dados ao obter. ***Obrigatório.**</param>
        /// <param name="nameProd">O nome do produto. *Opcional*</param>
        /// <returns>Lista de produtos</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProduto([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nameProd = null)
        {
            if (nameProd == null)
            {
                var list = _mapper.Map<List<ReadProdutoDTO>>(_context.Produtos.Skip(skip).Take(take).ToList());
                return Ok(list);
            }
            var search = _mapper.Map<List<ReadProdutoDTO>>(_context.Produtos.Skip(skip).Take(take).Where(prod => prod.Name_Prod == nameProd).ToList());
            return Ok(search);
        }

        // Search Produtos
        // GET api/Produtos/{id}
        /// <summary>
        ///     Obtém um produto de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador do produto a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Produto pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProdutoById([FromRoute] int id)
        {
            var prod = _context.Produtos.FirstOrDefault(prod => prod.Id_Prod == id);
            if (prod == null) return NotFound();
            var input = _mapper.Map<ReadProdutoDTO>(prod);
            return Ok(input);
        }

        // Update Produto (PUT)
        // PUT api/Produtos/{id}
        /// <summary>
        ///     Atualiza (todo) o produto de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "CodeBar_Prod": "123456789112",
        ///         "Name_Prod": "Mouse",
        ///         "Val_Prod": 25.00
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para o produto. ***Obrigatório**</param>
        /// <param name="id">Identificador do produto. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutProduto([FromBody] UpdateProdutoDTO input, [FromRoute] int id)
        {
            var prod = _context.Produtos.FirstOrDefault(prod => prod.Id_Prod == id);
            if (prod == null) return NotFound();
            _mapper.Map(input, prod);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Produto (PATCH)
        // PATCH api/Produtos/{id}
        /// <summary>
        ///     Atualiza (1 valor) do produto de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Val_Prod",
        ///             "op": "replace",
        ///             "value": 20.00
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador do produto. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização do produto. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchProduto([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateProdutoDTO> input)
        {
            var prod = _context.Produtos.FirstOrDefault(prod => prod.Id_Prod == id);
            if (prod == null) return NotFound();
            var patchProd = _mapper.Map<UpdateProdutoDTO>(prod);
            input.ApplyTo(patchProd, ModelState);
            if (!TryValidateModel(patchProd)) return ValidationProblem(ModelState);
            _mapper.Map(patchProd, prod);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete Produto
        // DELETE api/Produtos/{id}
        /// <summary>
        ///     Apaga o produto de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador do produto. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteProduto([FromRoute] int id)
        {
            var prod = _context.Produtos.FirstOrDefault(prod => prod.Id_Prod == id);
            if (prod == null) return NotFound();
            _context.Remove(prod);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
