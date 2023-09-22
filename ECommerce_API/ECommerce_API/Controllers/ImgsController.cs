using AutoMapper;
using ECommerce_API.Datas;
using ECommerce_API.Datas.DTOs.ProdutoDTO;
using ECommerce_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ECommerce_API.Datas.DTOs.ImgPDTO;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImgsProdController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public ImgsProdController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Img
        // POST api/Imgs
        /// <summary>
        ///     Cadastra uma nova imagem para o produto
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Img": "ImgEx01",
        ///         "Src_Img": "Origem da imagem01",
        ///         "ProdutoId": 1
        ///     }
        ///     ```
        ///     *Obs.: É necessário ter o **produto** já criado.*
        /// </remarks>
        /// <param name="input">Requisição da imagem. ***Obrigatório**</param>
        /// <returns>Imagem que foi criado</returns>
        /// <response code="201">**Criado com sucesso**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostImg([FromBody] CreateImgPDTO input)
        {
            ImgProd img = _mapper.Map<ImgProd>(input);
            _context.ImgProds.Add(img);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetImgById), new { id = img.Id_Img }, img);
        }

        // Read Imgs
        // GET api/Imgs?skip=0&take=50
        /// <summary>
        ///     Obtém todas as imagens para os produtos
        /// </summary>
        /// <param name="skip">Requisição para dar um numero de paginas. ***Obrigatório**</param>
        /// <returns>Lista de imagems</returns>
        /// <response code="200">**Sucesso**</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetImg([FromQuery] int skip = 0)
        {
            var search = _mapper.Map<List<ReadImgPDTO>>(_context.ImgProds.Skip(skip).ToList());
            return Ok(search);
        }

        // Search Imgs
        // GET api/Imgs/{id}
        /// <summary>
        ///     Obtém uma imagem para o produto de arcodo com seu identificador
        /// </summary>
        /// <param name="id">Requisição do identificador da imagem a ser pesquisado. ***Obrigatório**</param>
        /// <returns>Imagem pesquisado</returns>
        /// <response code="200">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetImgById([FromRoute] int id)
        {
            var img = _context.ImgProds.FirstOrDefault(img => img.Id_Img == id);
            if (img == null) return NotFound();
            var input = _mapper.Map<ReadImgPDTO>(img);
            return Ok(input);
        }

        // Update Img (PUT)
        // PUT api/Imgs/{id}
        /// <summary>
        ///     Atualiza (toda) a imagem para o produto de acordo com seu identificador
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///     ```json
        ///     {
        ///         "Name_Img": "ImgEx01",
        ///         "Src_Img": "Origem da imagem01"
        ///     }
        ///     ```
        /// </remarks>
        /// <param name="input">Dados para a imagem. ***Obrigatório**</param>
        /// <param name="id">Identificador da imagem. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não Encontrado*</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutImg([FromBody] UpdateImgPDTO input, [FromRoute] int id)
        {
            var img = _context.ImgProds.FirstOrDefault(img => img.Id_Img == id);
            if (img == null) return NotFound();
            _mapper.Map(input, img);
            _context.SaveChanges();
            return NoContent();
        }

        // Update Img (PATCH)
        // PATCH api/Imgs/{id}
        /// <summary>
        ///     Atualiza (1 valor) da imagem para o produto de acordo com seu identificador
        /// </summary>
        /// <remarks> 
        ///     Exemplo:
        ///     ```json
        ///     [    
        ///         {
        ///             "path": "/Name_Img",
        ///             "op": "replace",
        ///             "value": "ImgEx02"
        ///         }
        ///     ]
        ///     ```
        ///     *Obs.: É importante colocar os colchetes sobre a array para este comando funcionar.´*
        /// </remarks>
        /// <param name="id">Identificador da imagem. ***Obrigatório**</param>
        /// <param name="input">Dados para atualização da imagem. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchImg([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateImgPDTO> input)
        {
            var img = _context.ImgProds.FirstOrDefault(img => img.Id_Img == id);
            if (img == null) return NotFound();
            var patchImg = _mapper.Map<UpdateImgPDTO>(img);
            input.ApplyTo(patchImg, ModelState);
            if (!TryValidateModel(patchImg)) return ValidationProblem(ModelState);
            _mapper.Map(patchImg, img);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete ImgProd
        // DELETE api/ImgProds/{id}
        /// <summary>
        ///     Apaga a imagem para o produto de acordo com identificador
        /// </summary>
        /// <param name="id">Identificador da imagem. ***Obrigatório**</param>
        /// <returns>Nada</returns>
        /// <response code="204">**Sucesso**</response>
        /// <response code="404">*Não encontrado*</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteImg([FromRoute] int id)
        {
            var img = _context.ImgProds.FirstOrDefault(img => img.Id_Img == id);
            if (img == null) return NotFound();
            _context.Remove(img);
            _context.SaveChanges();
            return NoContent();
        }
    }

    // imgrate
}
